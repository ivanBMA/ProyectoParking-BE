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
    public class RegistroPlazaService : IRegistroPlazaService
    {
        private readonly ParkingContext _context;
        private readonly IMapper _mapper;
        public RegistroPlazaService(ParkingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<RegistroPlazasDto> GetRegistroPlazas()
        {
            var registro = _context.RegistroPlazas.ToList();

            return _mapper.Map<List<RegistroPlazasDto>>(registro);
        }

        public RegistroPlazasDto StoreRegistroPlaza(RegistroPlazasDto registroDto)
        {
            var registro = _mapper.Map<RegistroPlaza>(registroDto);
            registro.fechaEvento = DateTime.Now;


            if (registro.tipoEvento == false)
            {
                Random random = new Random();
                int horaSumar = random.Next(0, 24);
                registro.fechaEvento = DateTime.Now.AddHours(horaSumar);
            }


            _context.RegistroPlazas.Add(registro);
            _context.SaveChanges();

            return _mapper.Map<RegistroPlazasDto>(registro);
        }

        public RegistroPlazasDto GetRegistroPlaza(int id)
        {
            var car = _context.RegistroPlazas.Where(c => c.Id == id).FirstOrDefault();

            return _mapper.Map<RegistroPlazasDto>(car);
        }
        public bool DeleteRegistroPlazas(int id)
        {
            var registro = _context.RegistroPlazas.Where(c => c.Id == id).FirstOrDefault();

            if (registro == null) { 
                return false;
            }
            _context.RegistroPlazas.Remove(registro);
            _context.SaveChanges();

            return true;
        }

    }
}
