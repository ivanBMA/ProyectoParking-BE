using ProyectoParkingServices.Dto;

namespace ProyectoParkingServices.Services
{
    public interface IClienteService
    {
        public List<Cliente> GetClients();
        public Cliente GetClient(int id);
        public ClienteDto StoreClient(ClienteDto client);
        public bool DeleteClient(int id);
        public ClienteDto PutClient(int id, ClienteDto clientDto);
    }
}
