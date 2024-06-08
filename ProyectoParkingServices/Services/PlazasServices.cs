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

        public List<PlazaDto> GetPlazas()
        {
            var plazas = _context.Plazas.ToList();

            return _mapper.Map<List<PlazaDto>>(plazas);
        }
        public List<PlazaDto> GetByParkingID(Int16 id)
        {
            var plazas = _context.Plazas.ToList().Where(c => c.Id_Parking == id);

            return _mapper.Map<List<PlazaDto>>(plazas);
        }
        

        public PlazaDto StorePlaza(PlazaDto plazaDto)
        {
            var plaza = _mapper.Map<Plaza>(plazaDto);
            _context.Plazas.Add(plaza);
            _context.SaveChanges();

            return _mapper.Map<PlazaDto>(plaza);
        }

        public PlazaDto GetPlaza(int id)
        {
            var plaza = _context.Plazas.Where(c => c.Id == id).FirstOrDefault();

            return _mapper.Map<PlazaDto>(plaza);
        }
        public bool DeletePlaza(int id)
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

        public PlazaDto PutPlaza(int id, PlazaDto plazaDto)
        {
            //var cocheAntiguo = _context.Cars.Where(c => c.Id == id).FirstOrDefault();
            //-> arreglar
            var plazaAntiguo = _context.Plazas.AsNoTracking().FirstOrDefault(c => c.Id == id);

            plazaDto.Id = id;

            if (plazaDto.Ocupado == null)
            {
                plazaDto.Ocupado = plazaAntiguo.Ocupado;
            }
           

            var plaza = _mapper.Map<Plaza>(plazaDto);

            _context.Plazas.Update(plaza);
            _context.SaveChanges();

            return _mapper.Map<PlazaDto>(plaza);
        }

    }
}
