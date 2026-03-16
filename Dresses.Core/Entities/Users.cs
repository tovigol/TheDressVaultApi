using Dresses.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Dresses.Core.Entities
{
    public enum UserRole { SuperAdmin, BusinessManager, Customer }
    public class Users
    {
        [Key]
        public int user_id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password_hash { get; set; }
        public string phone_number { get; set; }
        public UserRole role { get; set; }

        public List<Rentals> Rentals { get; set; }
    }
}
