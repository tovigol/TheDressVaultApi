using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;

    namespace Dresses.Core.Entities
    {
        public class Rentals
        {
            [Key]
            public int rental_id { get; set; }
            public DateTime start_date { get; set; }
            public DateTime end_date { get; set; }
            public int total_price { get; set; }

            // הגדרת הקשר למשתמש (מי ששכר)
            public int user_id { get; set; }
            [ForeignKey("user_id")]
            public Users User { get; set; }

            // הגדרת הקשר לשמלה (מה הושכר)
            public int dress_id { get; set; }
            [ForeignKey("dress_id")]
            public Dresess Dress
            { get; set; }
        }
   }

