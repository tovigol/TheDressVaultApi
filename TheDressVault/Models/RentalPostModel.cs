using Dresses.Core.Entities;

namespace TheDressVault.Models
{
    public class RentalPostModel
    {

        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public int total_price { get; set; }
        public int userid { get; set; }
    }
}
