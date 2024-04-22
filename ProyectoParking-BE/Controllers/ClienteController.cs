using Microsoft.AspNetCore.Mvc;
using ProyectoParkingServices;
using ProyectoParkingServices.Dto;
using ProyectoParkingServices.Services;

namespace ProyectoParking_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clientService;
        public ClienteController(IClienteService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("getAllClients")]
        public ActionResult<List<Cliente>> Index()
        {
            return Ok(_clientService.GetClients());
        }

        [HttpGet("getById")]
        public ActionResult<Cliente> GetById(int id)
        {
            return Ok(_clientService.GetClient(id));
        }

        [HttpPost("postAddClient")]
        public ActionResult<ClienteDto> PostAddClient([FromBody] ClienteDto client)
        {
            return Ok(_clientService.StoreClient(client));
        }

        [HttpPut("putClient")]
        public ActionResult<List<ClienteDto>> PutClient(int id, [FromBody] ClienteDto clientDto)
        {
            return Ok(_clientService.PutClient(id, clientDto));
        }

        [HttpDelete("deleteById")]
        public ActionResult<List<Cliente>> DeleteById(int id)
        {
            return Ok(_clientService.DeleteClient(id));
        }

    }
}
