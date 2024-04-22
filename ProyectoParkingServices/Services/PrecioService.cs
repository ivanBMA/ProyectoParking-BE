using AutoMapper;
using ProyectoParkingServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProyectoParkingServices.Services
{
    public class PrecioService : IPreciosService
    {
        private readonly ParkingContext _context;
        private readonly IMapper _mapper;
        public PrecioService(ParkingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<PreciosDto> GetPrecios()
        {
            var precios = _context.Precios.ToList();

            return _mapper.Map<List<PreciosDto>>(precios);
        }

        public PreciosDto GetPrecio(int id)
        {
            var precio = _context.Precios.Where(c => c.Id == id).FirstOrDefault();

            return _mapper.Map<PreciosDto>(precio);
        }

        public PreciosDto StorePrecio(PreciosDto precioDto)
        {
            var precio = _mapper.Map<Precios>(precioDto);
            _context.Precios.Add(precio);
            _context.SaveChanges();

            return _mapper.Map<PreciosDto>(precio);
        }

        public bool DeletePrecio(int id)
        {
            var precio = _context.Precios.Where(c => c.Id == id).FirstOrDefault();
            _context.Precios.Remove(precio);
            _context.SaveChanges();

            return true;
        }
    }
}
