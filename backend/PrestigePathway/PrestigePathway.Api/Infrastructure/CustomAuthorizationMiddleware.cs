using Microsoft.EntityFrameworkCore;
using PrestigePathway.DataAccessLayer;
using System.IdentityModel.Tokens.Jwt;

namespace PrestigePathway.Api.Infrastructure
{
    public class CustomAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _loginEndpoint = "/api/auth/login"; 

        public CustomAuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Allow unrestricted access to the login endpoint
            if (context.Request.Path.StartsWithSegments(_loginEndpoint))
            {
                await _next(context);
                return;
            }
            var jwtHandler = new JwtSecurityTokenHandler();
            var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ","");
            var jwtToken = jwtHandler.ReadJwtToken(token);
            // Ensure user is authenticated (JWT is present)
            
            // Extract user ID from JWT claims (assumes "sub" or "nameidentifier" claim)
            var userIdClaim = jwtToken.Claims.FirstOrDefault(x=>x.Type == "nameid").Value;
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out var userId))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized: Invalid user ID in token.");
                return;
            }

            // Get required claim for the endpoint (you can extend this logic)
            var requiredClaim = GetRequiredClaimForEndpoint(context.Request.Path, context.Request.Method);
            if (string.IsNullOrEmpty(requiredClaim))
            {
                await _next(context); // No specific claim required, proceed
                return;
            }

            // Access the DbContext via the request services
            var dbContext = context.RequestServices.GetRequiredService<SocialServicesDbContext>();
            var hasClaim = await CheckUserClaimAsync(dbContext, userId, requiredClaim);

            if (!hasClaim)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync($"Forbidden: Missing required claim '{requiredClaim}'.");
                return;
            }

            // User is authorized, proceed to the next middleware
            await _next(context);
        }

        private readonly Dictionary<string, string> _endpointPermissions = new()
        {
            { "/api/booking", "booking" },
            { "/api/client", "client" },
            { "/api/location", "location" },
            { "/api/partner", "partner" },
            { "/api/promotion", "promotion" },
            { "/api/service", "service" },
            { "/api/servicedetail", "service_detail" },
            { "/api/servicelocation", "service_location" },
            { "/api/serviceoption", "service_option" },
            { "/api/servicepartner", "service_partner" },
            { "/api/servicetype", "service_type" },
            { "/api/serviceassistant", "service_assistant" },
            { "/api/staff", "staff" },
            { "/api/testimonial", "testimonial" }
        };

        // Define required claims per endpoint (customize based on your needs)
        private string? GetRequiredClaimForEndpoint(PathString path, string method)
        {
            // switch (method)
            // {
            //     case "GET":
            //         // GET ENDPOINTS
            //         // Example mapping; replace with your actual endpoints and claims
            //         return path.Value switch
            //         {
            //             string p when p.StartsWith("/api/booking") =>  "Read:booking",
            //             string p when p.StartsWith("/api/client") =>   "Read:client",
            //             string p when p.StartsWith("/api/location") => "Read:location",
            //             _ => null // No specific claim required
            //         };
            //         
            //     case "POST":
            //         // GET ENDPOINTS
            //         // Example mapping; replace with your actual endpoints and claims
            //         return path.Value switch
            //         {
            //             string p when p.StartsWith("/api/booking") =>  "Post:booking",
            //             string p when p.StartsWith("/api/client") =>   "Post:client",
            //             string p when p.StartsWith("/api/location") => "Post:location",
            //             _ => null // No specific claim required
            //         };
            //         
            //     case "DELETE":
            //         // GET ENDPOINTS
            //         // Example mapping; replace with your actual endpoints and claims
            //         return path.Value switch
            //         {
            //             string p when p.StartsWith("/api/booking") => "Delete:booking",
            //             string p when p.StartsWith("/api/client") => "Delete:client",
            //             string p when p.StartsWith("/api/location") => "Delete:location",
            //             _ => null // No specific claim required
            //         };
            //          
            //     case "PUT":
            //         // GET ENDPOINTS
            //         // Example mapping; replace with your actual endpoints and claims
            //         return path.Value switch
            //         {
            //             string p when p.StartsWith("/api/booking") => "Put:booking",
            //             string p when p.StartsWith("/api/client") => "Put:client",
            //             string p when p.StartsWith("/api/location") => "Put:location",
            //             _ => null // No specific claim required
            //         };
            //     default:
            //         break;
            // }

            return (from entry in _endpointPermissions 
                where path.Value.StartsWith(entry.Key, StringComparison.OrdinalIgnoreCase) 
                select $"{method}:{entry.Value}").FirstOrDefault();
        }

        // Check if the user has the required claim in the UserRole table
        private async Task<bool> CheckUserClaimAsync(SocialServicesDbContext dbContext, int userId, string requiredClaim)
        {
            var claimParts = requiredClaim.Split(':');
            var claimType = claimParts[0]; // e.g., "Read"
            var claimValue = claimParts.Length > 1 ? claimParts[1] : requiredClaim; // e.g., "Loans"
            // check in permission table to findout the id of the Read:Booking
            // var permissionId = dbContext.Permissions.firstOrdefault(x=>x.Name==requiredClaim)
            // return await dbContext.UserPermission.AnyAsync(ur => ur.UserID == userId&&ur.PermissionId==permissionId );
            return await dbContext.UserRoles.AnyAsync(ur => ur.UserID == userId );
        }
    }
}
