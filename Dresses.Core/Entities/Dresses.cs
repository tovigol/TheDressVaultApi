using Dresses.Core.Entities;
using Dresses.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Dresses.Core.Entities
{
    public class Dress
    {
        [Key]
        public int dress_id { get; set; }
        [Required]
        public int businessId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int size { get; set; }
        public string Color { get; set; }
        public int rental_price { get; set; }
        public decimal depositAmount { get; set; }
       
        public Business business { get; set; }
        public string imageUrl { get; set; }
       
        public int cleaningDaysRequired { get; set; } = 2;
        [Required]
        public DressStatus Status { get; set; }

        // קשר של אחד-לרבים: שמלה אחת יכולה להופיע בהרבה השכרות לאורך זמן
        public List<Rentals> Rentals { get; set; }
    }
}
