using Dresses.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dresses.Core.DTO
{
   public class DressDto
    {
        public int dress_id { get; set; }
        //public int lender_id;
        public string name { get; set; }
        public string description { get; set; }
        public int size { get; set; }
        public int rental_price { get; set; }

  
    }
}
