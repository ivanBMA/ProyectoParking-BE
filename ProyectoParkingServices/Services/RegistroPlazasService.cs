using AutoMapper;
using ProyectoParkingServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ProyectoParkingServices.Services
{
    public class RegistroPlazasService : IRegistroPlazasServices
    {
        private readonly ParkingContext _context;
        private readonly IMapper _mapper;
        public RegistroPlazasService(ParkingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<RegistroPlazasDto> GetRegistroPlazas()
        {
            var registroPlazas = _context.RegistroPlazas.ToList();

            return _mapper.Map<List<RegistroPlazasDto>>(registroPlazas);
        }

        public RegistroPlazasDto StoreRegistroPlaza(RegistroPlazasDto registroDto)
        {
            //-> arreglar
            var registro = _mapper.Map<RegistroPlaza>(registroDto);
            registro.horaEntrada = TimeOnly.ParseExact("5:00 pm", "h:mm tt", CultureInfo.InvariantCulture);
            registro.horaSalida = TimeOnly.ParseExact("6:00 pm", "h:mm tt", CultureInfo.InvariantCulture);

            _context.RegistroPlazas.Add(registro);
            _context.SaveChanges();

            return _mapper.Map<RegistroPlazasDto>(registro);
        }
    }
}
