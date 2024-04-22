using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoParkingServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoParkingServices.Services
{
    public class DistribucionPlazasService : IDistribucionPlazaService
    {
        private readonly ParkingContext _context;
        private readonly IMapper _mapper;
        public DistribucionPlazasService(ParkingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<DistribucionPlazaDto> GetDistribucionPlazas()
        {
            var distribucionPlazas = _context.DistribucionPlazas.ToList();

            return _mapper.Map<List<DistribucionPlazaDto>>(distribucionPlazas);
        }

        public DistribucionPlazaDto GetDistribucionPlaza(int id)
        {
            var client = _context.DistribucionPlazas.Where(c => c.Id == id).FirstOrDefault();

            return _mapper.Map<DistribucionPlazaDto>(client);
        }

        public DistribucionPlazaDto StoreDistribucionPlaza(DistribucionPlazaDto distribucionPlaza)
        {
            var distribucion = _mapper.Map<DistribucionPlaza>(distribucionPlaza);
            _context.DistribucionPlazas.Add(distribucion);
            _context.SaveChanges();

            return _mapper.Map<DistribucionPlazaDto>(distribucion);
        }

        public bool DeleteDistribucionPlaza(int id)
        {
            var distribucionPlaza = _context.DistribucionPlazas.Where(c => c.Id == id).FirstOrDefault();
            _context.DistribucionPlazas.Remove(distribucionPlaza);
            _context.SaveChanges();

            return true;
        }

        public DistribucionPlazaDto PutDistribucionPlaza(int id, DistribucionPlazaDto distribucionPlazaDto)
        {
            //var cocheAntiguo = _context.Cars.Where(c => c.Id == id).FirstOrDefault();
            var distribucionPlazaAntiguo = _context.DistribucionPlazas.AsNoTracking().FirstOrDefault(c => c.Id == id);

            distribucionPlazaDto.Id = distribucionPlazaAntiguo.Id;
            

            var client = _mapper.Map<DistribucionPlaza>(distribucionPlazaDto);

            _context.DistribucionPlazas.Update(client);
            _context.SaveChanges();

            return _mapper.Map<DistribucionPlazaDto>(client);
        }
    }
}
