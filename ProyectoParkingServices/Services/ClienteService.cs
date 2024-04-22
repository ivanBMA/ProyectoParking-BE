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
    public class ClienteService : IClienteService
    {
        private readonly ParkingContext _context;
        private readonly IMapper _mapper;
        public ClienteService(ParkingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Cliente> GetClients()
        {
            var clients = _context.Clients.ToList();

            return _mapper.Map<List<Cliente>>(clients);
        }

        public Cliente GetClient(int id)
        {
            var client = _context.Clients.Where(c => c.Id == id).FirstOrDefault();

            return _mapper.Map<Cliente>(client);
        }

        public ClienteDto StoreClient(ClienteDto client)
        {
            var cliente = _mapper.Map<Cliente>(client);
            _context.Clients.Add(cliente);
            _context.SaveChanges();

            return _mapper.Map<ClienteDto>(cliente);
        }

        public bool DeleteClient(int id)
        {
            var client = _context.Clients.Where(c => c.Id == id).FirstOrDefault();
            _context.Clients.Remove(client);
            _context.SaveChanges();

            return true;
        }

        public ClienteDto PutClient(int id, ClienteDto clientDto)
        {
            //var cocheAntiguo = _context.Cars.Where(c => c.Id == id).FirstOrDefault();
            var clientAntiguo = _context.Clients.AsNoTracking().FirstOrDefault(c => c.Id == id);

            clientDto.Id = clientAntiguo.Id;

            if (clientDto.Name == string.Empty)
            {
                clientDto.Name = clientAntiguo.Name;
            }
            if (clientDto.Nif == string.Empty){
                clientDto.Nif = clientAntiguo.Nif;
            }

            var client = _mapper.Map<Cliente>(clientDto);

            _context.Clients.Update(client);
            _context.SaveChanges();

            return _mapper.Map<ClienteDto>(client);
        }
    }
}
