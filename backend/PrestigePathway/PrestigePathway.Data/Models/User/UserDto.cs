using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Migrations;
using PrestigePathway.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestigePathway.Data.Models.User
{
    public class UserDto:IEntity,IEntityTracker
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
   public class AuthUser
    {
        public string Token { get; set; }
        public UserDto User { get; set; }
    }
}
