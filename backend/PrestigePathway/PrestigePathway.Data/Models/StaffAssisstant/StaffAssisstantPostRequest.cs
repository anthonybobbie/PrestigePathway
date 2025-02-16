namespace PrestigePathway.Data.Models.StaffAssisstant
{
    public class StaffAssisstantPostRequest
    {
        public int StaffID { get; set; }
        public int BookingID { get; set; }
        public DateTime AssignmentDate { get; set; }
        public string? Notes { get; set; }
    }
}
