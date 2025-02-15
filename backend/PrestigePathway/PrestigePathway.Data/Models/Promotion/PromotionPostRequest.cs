namespace PrestigePathway.Data.Models.Promotion
{
    public class PromotionPostRequest
    {
        public string PromotionName { get; set; }
        public string Description { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; } = true; 
        public int? ServiceID { get; set; } 
    }
}
