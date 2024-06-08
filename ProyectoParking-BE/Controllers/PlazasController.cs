using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoParkingServices.Services;
using ProyectoParkingServices;
using ProyectoParkingServices.Dto;

namespace ProyectoParking_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlazasController : ControllerBase
    {
        private readonly IPlazasService _plazaService;
        public PlazasController(IPlazasService plazaService)
        {
            _plazaService = plazaService;
        }
        

        [HttpGet("getAllPlazas")]
        public ActionResult<List<PlazaDto>> Index()
        {
            return Ok(_plazaService.GetPlazas());
        }

        [HttpGet("getAllPlazasByParking")]
        public ActionResult<List<PlazaDto>> GetByParking(Int16 id)
        {
            return Ok(_plazaService.GetByParkingID(id));
        }

        [HttpPost("postAddPlaza")]
        public ActionResult<PlazaDto> PostAddCar([FromBody] PlazaDto plazaDto)
        {
            return Ok(_plazaService.StorePlaza(plazaDto));
        }

        [HttpGet("getById")]
        public ActionResult<PlazaDto> GetById(int id)
        {
            return Ok(_plazaService.GetPlaza(id));
        }

        [HttpPut("putPlaza")]
        public ActionResult<List<PlazaDto>> PutPlaza(int id, [FromBody] PlazaDto plazaDto)
        {
            return Ok(_plazaService.PutPlaza(id, plazaDto));
        }

        [HttpDelete("deleteById")]
        public ActionResult<List<PlazaDto>> DeleteById(int id)
        {
            return Ok(_plazaService.DeletePlaza(id));
        }

    }
}
