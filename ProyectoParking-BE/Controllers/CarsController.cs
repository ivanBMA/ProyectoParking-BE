using Microsoft.AspNetCore.Mvc;
using ProyectoParkingServices;
using ProyectoParkingServices.Dto;
using ProyectoParkingServices.Services;


namespace ProyectoParking_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getById")]
        public ActionResult<Car> GetById(int id)
        {
            return Ok(_carService.GetCar(id));
        }

        [HttpGet("getAllCars")]
        public ActionResult<List<Car>> Index()
        {
            return Ok(_carService.GetCars());
        }

        [HttpPost("postAddCar")]
        public ActionResult<CarDto> PostAddCar([FromBody] CarDto car)
        {
            return Ok(_carService.StoreCar(car));
        }

        [HttpPut("putCar")]
        public ActionResult<List<Car>> PutCar(int id, [FromBody] Car car)
        {
            var coches = AllCarsGet();
            var cocheAntiguo = coches.Where(c => c.Id == id).FirstOrDefault();

            cocheAntiguo.Name = car.Name;
            cocheAntiguo.Description = car.Description;

            return Ok(coches);
        }

        [HttpDelete("deleteById")]
        public ActionResult<List<Car>> DeleteById(int id)
        {
            return Ok(_carService.DeleteCar(id));
        }

        
        
        private List<Car> AllCarsGet()
        {

            Car car = new Car()
            {
                Id = 1,
                Name = "Foo",
                Description = "Bar",
            };

            Car car2 = new Car()
            {
                Id = 2,
                Name = "Faa",
                Description = "rapido",
            };

            List<Car> results = new List<Car>();
            results.Add(car);
            results.Add(car2);

            return results;
        }


    }
}
