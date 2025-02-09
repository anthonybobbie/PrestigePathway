using System.ComponentModel.DataAnnotations;

namespace PrestigePathway.DataAccessLayer.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; } 
    }
}