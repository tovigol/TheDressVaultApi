using Dresses.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dresses.Core.DTO
{
    public class UserDto
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public bool is_lender { get; set; }
        public string phone_number { get; set; }



    }
}
