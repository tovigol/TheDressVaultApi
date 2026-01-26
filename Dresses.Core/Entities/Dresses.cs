using Dresses.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Dresses.Core.Entities
{
    public class Dresess
    {
        [Key]
        public int dress_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int size { get; set; }
        public int rental_price { get; set; }

        // קשר של אחד-לרבים: שמלה אחת יכולה להופיע בהרבה השכרות לאורך זמן
        public List<Rentals> Rentals { get; set; }
    }
}
