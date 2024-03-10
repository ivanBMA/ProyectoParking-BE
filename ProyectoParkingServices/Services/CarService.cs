using AutoMapper;
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
    public class CarService : ICarService
    {
        private readonly ParkingContext _context;
        private readonly IMapper _mapper;
        public CarService(ParkingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<CarDto> GetCars()
        {
            var cars = _context.Cars.ToList();

            return _mapper.Map<List<CarDto>>(cars);
        }

        public CarDto GetCar(int id)
        {
            var car = _context.Cars.Where(c => c.Id == id).FirstOrDefault();

            return _mapper.Map<CarDto>(car);
        }

        public CarDto StoreCar(CarDto carDto)
        {
            var car = _mapper.Map<Car>(carDto);
            _context.Cars.Add(car);
            _context.SaveChanges();
             
            return _mapper.Map<CarDto>(car);
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
