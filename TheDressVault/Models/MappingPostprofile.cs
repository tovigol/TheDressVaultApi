using AutoMapper;
using Dresses.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDressVault.Models;

namespace TheDressVault
{
    public class MappingPostprofile : Profile
    {
        public MappingPostprofile()
        {
            CreateMap<Dress, DressPostModel>().ReverseMap();
            CreateMap<Rentals, RentalPostModel>().ReverseMap();
            CreateMap<Users, UsersPostModel>().ReverseMap();
        }

    }
}

