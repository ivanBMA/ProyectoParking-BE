using Microsoft.AspNetCore.Mvc;
using ProyectoParkingServices;
using ProyectoParkingServices.Dto;
using ProyectoParkingServices.Services;

namespace ProyectoParking_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService _facturaService;
        public FacturaController(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        [HttpGet("getAllFacturas")]
        public ActionResult<List<Factura>> Index()
        {
            return Ok(_facturaService.GetFacturas());
        }

        [HttpGet("getById")]
        public ActionResult<Factura> GetById(int id)
        {
            return Ok(_facturaService.GetFactura(id));
        }

        [HttpPost("postAddFactura")]
        public ActionResult<FacturaDto> PostAddFactura([FromBody] FacturaDto factura)
        {
            return Ok(_facturaService.StoreFactura(factura));
        }

        [HttpPut("putFactura")]
        public ActionResult<List<FacturaDto>> PutFactura(int id, [FromBody] FacturaDto facturaDto)
        {
            return Ok(_facturaService.PutFactura(id, facturaDto));
        }

        [HttpDelete("deleteById")]
        public ActionResult<List<Factura>> DeleteById(int id)
        {
            return Ok(_facturaService.DeleteFactura(id));
        }

    }
}
