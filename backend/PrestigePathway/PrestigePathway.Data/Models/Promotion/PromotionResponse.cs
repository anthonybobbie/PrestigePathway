using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrestigePathway.DataAccessLayer.Repositories;

namespace PrestigePathway.Data.Models.Promotion
{
    public class PromotionResponse : IEntity
    {
        public int ID { get; set; }
        public string PromotionName { get; set; }
        public string Description { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; } = true; 
        public int? ServiceID { get; set; } 
    }
}
