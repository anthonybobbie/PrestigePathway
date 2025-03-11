using Microsoft.AspNetCore.Authorization;
using PrestigePathway.Api.Infrastructure;

namespace PrestigePathway.Api.Extensions
{
    public static class AuthorizationPolicyExtensions
    {
        public static void AddCrudPolicies(this AuthorizationOptions options, string resource)
        {
            options.AddPolicy($"{resource}Policy", policy => 
                policy.Requirements.Add(new OperationRequirement($"{resource}.Create",
                    $"{resource}.Read", $"{resource}.Update", $"{resource}.Delete")));
        }
    }
}