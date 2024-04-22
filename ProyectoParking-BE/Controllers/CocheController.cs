using Microsoft.AspNetCore.Mvc;
using ProyectoParkingServices;
using ProyectoParkingServices.Dto;
using ProyectoParkingServices.Services;


namespace ProyectoParking_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CocheController : ControllerBase
    {
        private readonly ICocheService _carService;
        public CocheController(ICocheService carService)
        {
            _carService = carService;
        }

        [HttpGet("getById")]
        public ActionResult<Coche> GetById(int id)
        {
            return Ok(_carService.GetCar(id));
        }

        [HttpGet("getAllCars")]
        public ActionResult<List<Coche>> Index()
        {
            return Ok(_carService.GetCars());
        }

        [HttpPost("postAddCar")]
        public ActionResult<CocheDto> PostAddCar([FromBody] CocheDto car)
        {
            return Ok(_carService.StoreCar(car));
        }

        [HttpPut("putCar")]
        public ActionResult<List<CocheDto>> PutCar(int id, [FromBody] CocheDto carDto)
        {
            return Ok(_carService.PutCar(id, carDto));
        }

        [HttpDelete("deleteById")]
        public ActionResult<List<Coche>> DeleteById(int id)
        {
            return Ok(_carService.DeleteCar(id));
        }

        
        
        private List<Coche> AllCarsGet()
        {

            Coche car = new Coche()
            {
                Id = 1,
                Name = "Foo",
                Description = "Bar",
            };

            Coche car2 = new Coche()
            {
                Id = 2,
                Name = "Faa",
                Description = "rapido",
            };

            List<Coche> results = new List<Coche>();
            results.Add(car);
            results.Add(car2);

            return results;
        }


    }
}
