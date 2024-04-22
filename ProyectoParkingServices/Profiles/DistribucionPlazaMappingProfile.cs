using AutoMapper;
using ProyectoParkingServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoParkingServices.Profiles
{
    public class DistribucionPlazaMappingProfile : Profile
    {

        public DistribucionPlazaMappingProfile()
        {
            CreateMap<DistribucionPlazaDto, DistribucionPlaza>().ReverseMap();
        }

    }
}

