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

        public Plaza GetPlaza(int id)
        {
            var plaza = _context.Plazas.Where(c => c.Id == id).FirstOrDefault();

            return _mapper.Map<Plaza>(plaza);
        }
        public bool DeleteCar(int id)
        {
            var plaza = _context.Plazas.Where(c => c.Id == id).FirstOrDefault();

            if (plaza == null)
            {
                return false;
            }

            _context.Plazas.Remove(plaza);
            _context.SaveChanges();

            return true;
        }

        public Plaza PutPlaza(int id, Plaza plazaDto)
        {
            //var cocheAntiguo = _context.Cars.Where(c => c.Id == id).FirstOrDefault();
            //-> arreglar
            var plazaAntiguo = _context.Plazas.AsNoTracking().FirstOrDefault(c => c.Id == id);

            if (plazaDto.Id == null)
            {
                plazaDto.Id = plazaAntiguo.Id;
            }
            
            if (plazaDto.Ocupado == null)
            {
                plazaDto.Ocupado = plazaAntiguo.Ocupado;
            }
           

            var plaza = _mapper.Map<Plaza>(plazaDto);

            _context.Plazas.Update(plaza);
            _context.SaveChanges();

            return _mapper.Map<Plaza>(plaza);
        }

    }
}
