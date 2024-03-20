using Microsoft.AspNetCore.Mvc;
using ProyectoParkingServices;
using ProyectoParkingServices.Dto;
using ProyectoParkingServices.Services;
namespace ProyectoParking_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroPlazasController : ControllerBase { 
    
        private readonly IRegistroPlazasServices _registroPlazasService;
        public RegistroPlazasController(IRegistroPlazasServices registroPlazasService)
        {
            _registroPlazasService = registroPlazasService;
        }

        [HttpGet("getAllRegistroPlazas")]
        public ActionResult<List<RegistroPlazasDto>> Index()
        {
            return Ok(_registroPlazasService.GetRegistroPlazas());
        }

        [HttpPost("postAddPlaza")]
        public ActionResult<RegistroPlazasDto> PostAddCar([FromBody] RegistroPlazasDto registroDto)
        {
            return Ok(_registroPlazasService.StoreRegistroPlaza(registroDto));
        }
    }
}
