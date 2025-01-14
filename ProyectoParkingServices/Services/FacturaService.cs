﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoParkingServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoParkingServices.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly ParkingContext _context;
        private readonly IMapper _mapper;
        public FacturaService(ParkingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private decimal cojerPrecio(Factura factura)
        {
            int tiempo = factura.Tiempo;
            int id = factura.Id_Precio;
            Precios precio = _context.Precios.Where(c => c.Id == id).FirstOrDefault();
            Decimal importe = precio.Precio;

            return importe;
        }
        private int calcularTiempo(Factura factura)
        {
            RegistroPlaza entrada = _context.RegistroPlazas.Where(c => c.Id_Coche == factura.Id_Coche && c.tipoEvento == true).FirstOrDefault();
            RegistroPlaza salida = _context.RegistroPlazas.Where(c => c.Id_Coche == factura.Id_Coche && c.tipoEvento == false).FirstOrDefault();
            System.TimeSpan date4 = salida.fechaEvento - entrada.fechaEvento;
            double minutos = date4.TotalMinutes;
            int minutosInt = Convert.ToInt32(minutos);

            return minutosInt;
        }

        private int cojerIdCliente(Factura facturae)
        {
            return _context.Cars.Where(c => c.ClientId == facturae.Id_Coche).FirstOrDefault().Id;
        }

        private decimal calcularImporte(Factura facturae)
        {
            return facturae.Precio * facturae.Tiempo;
        }

        public List<FacturaDto> GetFacturas()
        {
            var facturas = _context.Facturas.ToList();

            return _mapper.Map<List<FacturaDto>>(facturas);
        }

        public FacturaDto GetFactura(int id)
        {
            var factura = _context.Facturas.Where(c => c.Id == id).FirstOrDefault();

            return _mapper.Map<FacturaDto>(factura);
        }

        public FacturaDto StoreFactura(FacturaDto factura)
        {
            var facturae = _mapper.Map<Factura>(factura);

            facturae.Tiempo = calcularTiempo(facturae);
            facturae.Precio = cojerPrecio(facturae);
            facturae.Id_Cliente = cojerIdCliente(facturae);
            facturae.Importe = calcularImporte(facturae);



            _context.Facturas.Add(facturae);
            _context.SaveChanges();

            return _mapper.Map<FacturaDto>(facturae);
        }

        

        public bool DeleteFactura(int id)
        {
            var factura = _context.Facturas.Where(c => c.Id == id).FirstOrDefault();
            _context.Facturas.Remove(factura);
            _context.SaveChanges();

            return true;
        }

        public FacturaDto PutFactura(int id, FacturaDto facturaDto)
        {
            //var cocheAntiguo = _context.Cars.Where(c => c.Id == id).FirstOrDefault();
            var facturaAntiguo = _context.Facturas.AsNoTracking().FirstOrDefault(c => c.Id == id);

            facturaDto.Id = facturaAntiguo.Id;

            var factura = _mapper.Map<Factura>(facturaDto);

            _context.Facturas.Update(factura);
            _context.SaveChanges();

            return _mapper.Map<FacturaDto>(factura);
        }
    }
}
