using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dresses.Core.Entities
{
    public class Business
    {
        [Key]
        // מזהה ייחודי לעסק (חובה עבור ישות)
        public int business_id { get; set; }


        public string nameBusiness { get; set; }
        public string logoUrl { get; set; }

        public List<Dress> dresses { get; set; }

        public List<Users> users { get; set; }

        public List<Rentals> rentals { get; set; }


    }
}
