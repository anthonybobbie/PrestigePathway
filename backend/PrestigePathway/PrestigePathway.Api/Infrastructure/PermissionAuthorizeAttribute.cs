namespace PrestigePathway.Api.Infrastructure
{
    using Microsoft.AspNetCore.Authorization;

    public class PermissionAuthorizeAttribute : AuthorizeAttribute
    {
        public PermissionAuthorizeAttribute(string permission)
        {
            Policy = permission;
        }
    }


}
