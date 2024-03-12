
using ProyectoParkingServices.Dto;

namespace ProyectoParkingServices.Services
{
    public interface ICarService
    {
        List<CarDto> GetCars();
        CarDto GetCar(int id);
        bool DeleteCar(int id);
        CarDto StoreCar(CarDto car);
        CarDto PutCar(int id, CarDto carDto);
    }
}