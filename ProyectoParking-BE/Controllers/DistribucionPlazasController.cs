using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoParkingServices.Services;
using ProyectoParkingServices;
using ProyectoParkingServices.Dto;

namespace ProyectoParking_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistribucionPlazasController : ControllerBase
    {
        private readonly IDistribucionPlazaService _distribucionPlazaService;
        public DistribucionPlazasController(IDistribucionPlazaService plazaService)
        {
            _distribucionPlazaService = plazaService;
        }
        

        [HttpGet("getAllDistribucionPlazas")]
        public ActionResult<List<DistribucionPlazaDto>> Index()
        {
            return Ok(_distribucionPlazaService.GetDistribucionPlazas());
        }

        [HttpPost("postAddDistribucionPlaza")]
        public ActionResult<DistribucionPlazaDto> PostAddCar([FromBody] DistribucionPlazaDto distribucionPlazaDto)
        {
            return Ok(_distribucionPlazaService.StoreDistribucionPlaza(distribucionPlazaDto));
        }

        [HttpGet("getById")]
        public ActionResult<DistribucionPlazaDto> GetById(int id)
        {
            return Ok(_distribucionPlazaService.GetDistribucionPlaza(id));
        }

        [HttpPut("putDistribucionPlaza")]
        public ActionResult<List<DistribucionPlazaDto>> PutDistribucionPlaza(int id, [FromBody] DistribucionPlazaDto distribucionPlazaDto)
        {
            return Ok(_distribucionPlazaService.PutDistribucionPlaza(id, distribucionPlazaDto));
        }

        [HttpDelete("deleteById")]
        public ActionResult<List<DistribucionPlazaDto>> DeleteById(int id)
        {
            return Ok(_distribucionPlazaService.DeleteDistribucionPlaza(id));
        }

        [HttpPost("rellenarDistribucion")]
        public ActionResult<List<DistribucionPlazaDto>> rellenarTabla()
        {
            return Ok(_distribucionPlazaService.rellenarDistribucion());
        }

    }
}
