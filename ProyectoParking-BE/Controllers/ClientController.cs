using Microsoft.AspNetCore.Mvc;
using ProyectoParkingServices;
using ProyectoParkingServices.Dto;
using ProyectoParkingServices.Services;

namespace ProyectoParking_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("getAllClients")]
        public ActionResult<List<Client>> Index()
        {
            return Ok(_clientService.GetClients());
        }

        [HttpGet("getById")]
        public ActionResult<Client> GetById(int id)
        {
            return Ok(_clientService.GetClient(id));
        }

        [HttpPost("postAddClient")]
        public ActionResult<ClientDto> PostAddClient([FromBody] ClientDto client)
        {
            return Ok(_clientService.StoreClient(client));
        }

        [HttpPut("putClient")]
        public ActionResult<List<ClientDto>> PutClient(int id, [FromBody] ClientDto clientDto)
        {
            return Ok(_clientService.PutClient(id, clientDto));
        }

        [HttpDelete("deleteById")]
        public ActionResult<List<Client>> DeleteById(int id)
        {
            return Ok(_clientService.DeleteClient(id));
        }

    }
}
