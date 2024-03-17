using ProyectoParkingServices.Dto;

namespace ProyectoParkingServices.Services
{
    public interface IClientService
    {
        public List<Client> GetClients();
        public Client GetClient(int id);
        public ClientDto StoreClient(ClientDto client);
        public bool DeleteClient(int id);
        public ClientDto PutClient(int id, ClientDto clientDto);
    }
}
