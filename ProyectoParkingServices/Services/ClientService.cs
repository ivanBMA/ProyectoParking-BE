using AutoMapper;
using ProyectoParkingServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoParkingServices.Services
{
    public class ClientService : IClientService
    {
        private readonly ParkingContext _context;
        private readonly IMapper _mapper;
        public ClientService(ParkingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Client> GetClients()
        {
            var clients = _context.Clients.ToList();

            return _mapper.Map<List<Client>>(clients);
        }


    }
}
