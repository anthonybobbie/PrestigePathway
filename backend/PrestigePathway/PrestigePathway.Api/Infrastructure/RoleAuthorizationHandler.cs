using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace PrestigePathway.Api.Infrastructure
{
    public class RoleAuthorizationHandler : AuthorizationHandler<OperationRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<RoleAuthorizationHandler> _logger;

        public RoleAuthorizationHandler(IHttpContextAccessor httpContextAccessor, ILogger<RoleAuthorizationHandler> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }
    
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationRequirement requirement)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null)
            {
                _logger.LogWarning("No HttpContext found.");
                context.Fail();
                return Task.CompletedTask;
            }

            var user = httpContext.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                _logger.LogWarning("User is not authenticated.");
                context.Fail();
                return Task.CompletedTask;
            }

            var userRoles = user.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value).ToList();
            _logger.LogInformation("User roles: {Roles}", string.Join(", ", userRoles));

            if (requirement.Operations.Any(userRoles.Contains))
            {
                _logger.LogInformation("Authorization successful for operation: {Operation}", string.Join(", ", requirement.Operations));
                context.Succeed(requirement);
            }
            else
            {
                _logger.LogWarning("Authorization successful for operation: {operation}", string.Join(", ", requirement.Operations));
            }
        
            return Task.CompletedTask;
        }
    }
}

