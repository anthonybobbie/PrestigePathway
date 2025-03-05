using Microsoft.AspNetCore.Authorization;

namespace PrestigePathway.Api.Infrastructure
{
    public class OperationRequirement : IAuthorizationRequirement
    {
        public string[] Operations { get; }

        public OperationRequirement(params string[] operations)
        {
            Operations = operations;
        }
    }
}

