using ProyectoParkingServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoParkingServices.Services
{
    public interface IParkingsService
    {
            public List<ParkingsDto> GetParkings();
            public ParkingsDto StoreParkings(ParkingsDto parking);
            public ParkingsDto GetParkings(int id);
            public bool DeleteParkings(int id);
            public ParkingsDto PutParkings(int id, ParkingsDto parkingDto);
    }
}
