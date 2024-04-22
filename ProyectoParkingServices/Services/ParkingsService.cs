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
    public class ParkingsService : IParkingsService
    {
        private readonly ParkingContext _context;
        private readonly IMapper _mapper;
        public ParkingsService(ParkingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ParkingsDto> GetParkings()
        {
            var parkings = _context.Parkings.ToList();

            return _mapper.Map<List<ParkingsDto>>(parkings);
        }

        public ParkingsDto GetParkings(int id)
        {
            var parkings = _context.Parkings.Where(c => c.Id == id).FirstOrDefault();

            return _mapper.Map<ParkingsDto>(parkings);
        }

        public ParkingsDto PutParkings(int id, ParkingsDto parkingsDto)
        {
            var parkingAntiguo = _context.Parkings.AsNoTracking().FirstOrDefault(c => c.Id == id);

            parkingsDto.Id = parkingAntiguo.Id;
            parkingsDto.Nombre = parkingAntiguo.Nombre;

            var parkings = _mapper.Map<Parking>(parkingsDto);

            _context.Parkings.Update(parkings);
            _context.SaveChanges();

            return _mapper.Map<ParkingsDto>(parkings);
        }

        public ParkingsDto StoreParkings(ParkingsDto parkingsDto)
        {
            //->
            var parkings = _mapper.Map<Parking>(parkingsDto);
            _context.Parkings.Add(parkings);
            _context.SaveChanges();
             
            return _mapper.Map<ParkingsDto>(parkings);
        }

        public bool DeleteParkings(int id)
        {
            var parking = _context.Parkings.Where(c => c.Id == id).FirstOrDefault();
            _context.Parkings.Remove(parking);
            _context.SaveChanges();

            return true;
        }
    }
}
