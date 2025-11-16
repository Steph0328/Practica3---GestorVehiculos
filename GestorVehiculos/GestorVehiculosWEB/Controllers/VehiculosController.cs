using GestorVehiculosBLL.Services;
using GestorVehiculosDAL.Models;
using GestorVehiculosDAL.Repositories;
using System.Collections.Generic;
using System.Web.Http;

namespace GestorVehiculosWEB.Controllers
{
    [RoutePrefix("api/vehiculos")]
    public class VehiculosController : ApiController
    {
        private readonly IVehiculoService _service;

        public VehiculosController()
        {
            // Instanciamos BLL y DAL “a mano” (sin inyección de dependencias)
            IVehiculoRepository repo = new VehiculoRepository();
            _service = new VehiculoService(repo);
        }

        // ➤ 1. Listado de vehículos
        // GET: api/vehiculos
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetVehiculos()
        {
            IEnumerable<Vehiculo> vehiculos = _service.ObtenerTodos();
            return Ok(vehiculos);
        }

        // ➤ 2. Ver el detalle de un vehículo
        // GET: api/vehiculos/{id}
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetVehiculo(int id)
        {
            Vehiculo vehiculo = _service.ObtenerPorId(id);

            if (vehiculo == null)
                return NotFound();

            return Ok(vehiculo);
        }
    }
}
