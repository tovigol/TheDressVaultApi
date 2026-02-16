using Dresses.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dresses.Core.DTO
{
    public class RentalDto
    {
        public int rental_id { get; set; }

        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public int total_price { get; set; }
        public UserDto user { get; set; }

        public List<DressDto> Dresses { get; set; }
    }
}
