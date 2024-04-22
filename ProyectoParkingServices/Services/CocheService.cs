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
    public class CocheService : ICocheService
    {
        private readonly ParkingContext _context;
        private readonly IMapper _mapper;
        public CocheService(ParkingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<CocheDto> GetCars()
        {
            var cars = _context.Cars.ToList();

            return _mapper.Map<List<CocheDto>>(cars);
        }

        public CocheDto GetCar(int id)
        {
            var car = _context.Cars.Where(c => c.Id == id).FirstOrDefault();

            return _mapper.Map<CocheDto>(car);
        }

        public CocheDto PutCar(int id, CocheDto carDto)
        {
            //var cocheAntiguo = _context.Cars.Where(c => c.Id == id).FirstOrDefault();
            var cocheAntiguo = _context.Cars.AsNoTracking().FirstOrDefault(c => c.Id == id);

            carDto.Id = cocheAntiguo.Id;
            carDto.ClientId = cocheAntiguo.ClientId;

            var car = _mapper.Map<Coche>(carDto);

            _context.Cars.Update(car);
            _context.SaveChanges();

            return _mapper.Map<CocheDto>(car);
        }

        public CocheDto StoreCar(CocheDto carDto)
        {
            var car = _mapper.Map<Coche>(carDto);
            _context.Cars.Add(car);
            _context.SaveChanges();
             
            return _mapper.Map<CocheDto>(car);
        }

        public bool DeleteCar(int id)
        {
            var coche = _context.Cars.Where(c => c.Id == id).FirstOrDefault();
            _context.Cars.Remove(coche);
            _context.SaveChanges();

            return true;
        }
    }
}
