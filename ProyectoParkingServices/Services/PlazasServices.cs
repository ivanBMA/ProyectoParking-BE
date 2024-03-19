using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoParkingServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoParkingServices.Services
{
    public class PlazasServices : IPlazasService
    {
        private readonly ParkingContext _context;
        private readonly IMapper _mapper;
        public PlazasServices(ParkingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Plaza> GetPlazas()
        {
            var plazas = _context.Plazas.ToList();

            return _mapper.Map<List<Plaza>>(plazas);
        }

        public Plaza StorePlaza(Plaza plaza)
        {
            _context.Plazas.Add(plaza);
            _context.SaveChanges();

            return _mapper.Map<Plaza>(plaza);
        }
    }
}
