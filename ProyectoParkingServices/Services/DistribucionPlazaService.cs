using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoParkingServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace ProyectoParkingServices.Services
{
    public class DistribucionPlazasService : IDistribucionPlazaService
    {
        private readonly ParkingContext _context;
        private readonly IMapper _mapper;

        private Boolean leerFichero(Int16 Id_Parking)
        {
            StreamReader reader = new StreamReader("C:\\Users\\ivan\\source\\repos\\ProyectoParking-BE\\ProyectoParkingServices\\DistribucionA.json");
            string jsonString = reader.ReadToEnd();
            Archivo matrizDatos = JsonConvert.DeserializeObject<Archivo>(jsonString);
            Int16 contador = 1;
            //Borrar la tabla antes de volvar los datos
            foreach (bool[] fila in matrizDatos.Matriz)
            {
                Int16 contadorA = 0;
                foreach (bool valor in fila)
                {
                    Int16 contadorB = 0;

                    Int16 Fila = contadorB;
                    Int16 Columna = contadorA;
                    bool EsPlaza = matrizDatos.Matriz[contadorA][contadorB];
                    contador++;
                    DistribucionPlaza distribucionPlaza = new DistribucionPlaza
                    {
                        
                        Id = contador,
                        Fila = Fila,
                        Columna = Columna,
                        EsPlaza = EsPlaza,
                        Id_Parking = Id_Parking
                    };

                    StoreDistribucionPlaza(distribucionPlaza);


                    contadorB++;
                }
                contadorA++;
            }

            return true;
        }

        private void StoreDistribucionPlaza(DistribucionPlaza distribucionPlaza)
        {
            var distribucion = _mapper.Map<DistribucionPlaza>(distribucionPlaza);
            _context.DistribucionPlazas.Add(distribucion);
            _context.SaveChanges();
        }

        public DistribucionPlazasService(ParkingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<DistribucionPlazaDto> GetDistribucionPlazas()
        {
            var distribucionPlazas = _context.DistribucionPlazas.ToList();

            return _mapper.Map<List<DistribucionPlazaDto>>(distribucionPlazas);
        }

        public DistribucionPlazaDto GetDistribucionPlaza(int id)
        {
            var client = _context.DistribucionPlazas.Where(c => c.Id == id).FirstOrDefault();

            return _mapper.Map<DistribucionPlazaDto>(client);
        }

        public DistribucionPlazaDto StoreDistribucionPlaza(DistribucionPlazaDto distribucionPlaza)
        {
            

            var distribucion = _mapper.Map<DistribucionPlaza>(distribucionPlaza);
            _context.DistribucionPlazas.Add(distribucion);
            _context.SaveChanges();

            return _mapper.Map<DistribucionPlazaDto>(distribucion);
        }

        public bool DeleteDistribucionPlaza(int id)
        {
            var distribucionPlaza = _context.DistribucionPlazas.Where(c => c.Id == id).FirstOrDefault();
            _context.DistribucionPlazas.Remove(distribucionPlaza);
            _context.SaveChanges();

            return true;
        }

        public bool rellenarDistribucion(Int16 Id_Parking)
        {
            leerFichero(Id_Parking);
            return true;
        }

        public DistribucionPlazaDto PutDistribucionPlaza(int id, DistribucionPlazaDto distribucionPlazaDto)
        {
            //var cocheAntiguo = _context.Cars.Where(c => c.Id == id).FirstOrDefault();
            var distribucionPlazaAntiguo = _context.DistribucionPlazas.AsNoTracking().FirstOrDefault(c => c.Id == id);

            distribucionPlazaDto.Id = distribucionPlazaAntiguo.Id;
            

            var client = _mapper.Map<DistribucionPlaza>(distribucionPlazaDto);

            _context.DistribucionPlazas.Update(client);
            _context.SaveChanges();

            return _mapper.Map<DistribucionPlazaDto>(client);
        }
    }
}
