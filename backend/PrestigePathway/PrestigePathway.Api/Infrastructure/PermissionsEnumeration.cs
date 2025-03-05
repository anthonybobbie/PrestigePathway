
namespace PrestigePathway.Api.Infrastructure
{
    public static class PermissionsEnumeration
    {
        public static string[] GetPermissions()
        {
            return new[] {
               "Booking_GET",
               "Booking_PUT",
               "Booking_DELETE",
               "Booking_POST",

               "Client_GET",
               "Client_PUT",
               "Client_DELETE",
               "Client_POST",

               "User_GET",
               "User_PUT",
               "User_DELETE",
               "User_POST",

               // Add more permissions as needed...


            
            };
        }
    }
}
