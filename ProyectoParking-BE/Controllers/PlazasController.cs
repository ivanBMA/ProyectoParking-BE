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
        /*
        [HttpGet("getById")]
        public ActionResult<Plaza> GetById(int id)
        {
            return Ok(_plazaService.GetPlaza(id));
        }
        */

        [HttpGet("getAllPlazas")]
        public ActionResult<List<Plaza>> Index()
        {
            return Ok(_plazaService.GetPlazas());
        }

        [HttpPost("postAddPlaza")]
        public ActionResult<Plaza> PostAddCar([FromBody] Plaza plaza)
        {
            return Ok(_plazaService.StorePlaza(plaza));
        }
    }
}
