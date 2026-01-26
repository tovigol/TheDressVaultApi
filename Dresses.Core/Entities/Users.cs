using Dresses.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Dresses.Core.Entities
{
    public class Users
    {
        [Key]
        public int user_id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password_hash { get; set; }
        public string phone_number { get; set; }

        public List<Rentals> Rentals { get; set; }
    }
}
