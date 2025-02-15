using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestigePathway.Data.Models.ServiceLocation
{
    public class ServiceLocationPostRequest
    {
        public int ServiceID { get; set; }
        public int LocationID { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
