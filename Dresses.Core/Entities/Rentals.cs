using Dresses.Core.Enums;
using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;

    namespace Dresses.Core.Entities
    {
        public class Rentals
        {
            [Key]
            public int rental_id { get; set; }
            [Required]
            public int businessId { get; set; }
            public DateTime start_date { get; set; }
            public DateTime end_date { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.Now;
        public int total_price { get; set; }
        public decimal PaidAmount { get; set; } 
        public bool IsDepositReturned { get; set; }

           public RentalStatus Status { get; set; }
            // הגדרת הקשר למשתמש (מי ששכר)
            public int user_id { get; set; }
            [ForeignKey("user_id")]
            public Users User { get; set; }

            // הגדרת הקשר לשמלה (מה הושכר)
            public int dress_id { get; set; }
            [ForeignKey("dress_id")]
            public Dress Dress
            { get; set; }
        }
   }

