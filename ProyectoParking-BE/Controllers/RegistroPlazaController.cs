using Microsoft.AspNetCore.Mvc;
using ProyectoParkingServices;
using ProyectoParkingServices.Dto;
using ProyectoParkingServices.Services;
namespace ProyectoParking_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroPlazaController : ControllerBase { 
    
        private readonly IRegistroPlazaService _registroPlazaService;
        public RegistroPlazaController(IRegistroPlazaService registroPlazasService)
        {
            _registroPlazaService = registroPlazasService;
        }

        [HttpGet("getAllRegistroPlazas")]
        public ActionResult<List<RegistroPlazasDto>> Index()
        {
            return Ok(_registroPlazaService.GetRegistroPlazas());
        }

        [HttpGet("getById")]
        public ActionResult<RegistroPlazasDto> GetById(int id)
        {
            return Ok(_registroPlazaService.GetRegistroPlaza(id));
        }
        [HttpPost("postAddPlaza")]
        public ActionResult<RegistroPlazasDto> PostAddPlaza([FromBody] RegistroPlazasDto registroDto)
        {
            return Ok(_registroPlazaService.StoreRegistroPlaza(registroDto));
        }

        [HttpDelete("deleteById")]
        public ActionResult<List<RegistroPlazasDto>> DeleteById(int id)
        {
            return Ok(_registroPlazaService.DeleteRegistroPlazas(id));
        }

    }
}
