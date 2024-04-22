
using ProyectoParkingServices.Dto;

namespace ProyectoParkingServices.Services
{
    public interface ICocheService
    {
        List<CocheDto> GetCars();
        CocheDto GetCar(int id);
        bool DeleteCar(int id);
        CocheDto StoreCar(CocheDto car);
        CocheDto PutCar(int id, CocheDto carDto);
    }
}