using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PrestigePathway.Data.Models.Location;
using PrestigePathway.Data.Models.Service;

namespace PrestigePathway.Data.Models.ServiceLocation
{
    public class ServiceLocationResponse
    {
         
        public int ID { get; set; }
          
        public int ServiceID { get; set; }

 
        public int LocationID { get; set; }

        public bool IsActive { get; set; } = true;

        public ServiceResponse Service { get; set; }
        public LocationResponse Location { get; set; }
    }
}
