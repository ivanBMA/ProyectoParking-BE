using Microsoft.AspNetCore.Mvc;

namespace ProyectoParking_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        public CarsController()
        {

        }

        [HttpGet("getById")]
        public ActionResult<Car> GetById(int id)
        {
            var coches = AllCarsGet();
            var coche = coches.Where(c => c.Id == id).FirstOrDefault();


            return Ok(coche);
        }

        [HttpGet("getAllCars")]
        public ActionResult<List<Car>> Index()
        {
            return Ok(AllCarsGet());
        }

        [HttpPost("postAddCar")]
        public ActionResult<List<Car>> PostAddCar([FromBody]Car car)
        {
            var coches = AllCarsGet();
            coches.Add(car);

            return Ok(coches);
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
            var coches = AllCarsGet();
            var coche = coches.Where(c => c.Id == id).FirstOrDefault();

            coches.Remove(coche);

            return Ok(coches);
        }
        //hola
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
