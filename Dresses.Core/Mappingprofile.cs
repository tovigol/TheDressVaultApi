using AutoMapper;
using Dresses.Core.DTO;
using Dresses.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dresses.Core
{
    public class Mappingprofile:Profile
    {
        public Mappingprofile() {
            CreateMap<Dress, UserDto>().ReverseMap();
            CreateMap<Rentals, RentalDto>().ReverseMap();
            CreateMap<Dress,DressDto>().ReverseMap();
           
        }
    }
}
