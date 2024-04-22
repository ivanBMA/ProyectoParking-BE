using Microsoft.AspNetCore.Mvc;
using ProyectoParkingServices;
using ProyectoParkingServices.Dto;
using ProyectoParkingServices.Services;


namespace ProyectoParking_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingsController : ControllerBase
    {
        private readonly IParkingsService _parkingsService;
        public ParkingsController(IParkingsService parkingsService)
        {
            _parkingsService = parkingsService;
        }

        [HttpGet("getById")]
        public ActionResult<Parkings> GetById(int id)
        {
            return Ok(_parkingsService.GetParkings(id));
        }

        [HttpGet("getAllParkings")]
        public ActionResult<List<Parkings>> Index()
        {
            return Ok(_parkingsService.GetParkings());
        }

        [HttpPost("postAddParkings")]
        public ActionResult<ParkingsDto> PostAddParkings([FromBody] ParkingsDto parking)
        {
            return Ok(_parkingsService.StoreParkings(parking));
        }

        [HttpPut("putParkings")]
        public ActionResult<List<ParkingsDto>> PutParkings(int id, [FromBody] ParkingsDto parkingDto)
        {
            return Ok(_parkingsService.PutParkings(id, parkingDto));
        }

        [HttpDelete("deleteById")]
        public ActionResult<List<Parkings>> DeleteById(int id)
        {
            return Ok(_parkingsService.DeleteParkings(id));
        }

        
        
       


    }
}
