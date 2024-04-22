using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoParkingServices;
using ProyectoParkingServices.Dto;
using ProyectoParkingServices.Services;

namespace ProyectoParking_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreciosController : ControllerBase
    {
        private readonly IPreciosService _preciosService;
        public PreciosController(IPreciosService preciosService)
        {
            _preciosService = preciosService;
        }

        [HttpGet("getById")]
        public ActionResult<Precios> GetById(int id)
        {
            return Ok(_preciosService.GetPrecio(id));
        }

        [HttpGet("getAllPrecios")]
        public ActionResult<List<Precios>> Index()
        {
            return Ok(_preciosService.GetPrecios());
        }

        [HttpPost("postAddPrecio")]
        public ActionResult<PreciosDto> PostAddPrecio([FromBody] PreciosDto precio)
        {
            return Ok(_preciosService.StorePrecio(precio));
        }
        [HttpDelete("deleteById")]
        public ActionResult<List<Precios>> DeleteById(int id)
        {
            return Ok(_preciosService.DeletePrecio(id));
        }

    }
}
