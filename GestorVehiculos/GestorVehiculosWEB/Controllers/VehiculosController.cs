using GestorVehiculosBLL.Services;
using GestorVehiculosDAL.Models;
using GestorVehiculosDAL.Repositories;
using System.Collections.Generic;
using System.Net;
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

        // ➤ 3. Eliminar un vehículo
        // DELETE: api/vehiculos/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteVehiculo(int id)
        {
            var vehiculo = _service.ObtenerPorId(id);
            if (vehiculo == null)
                return NotFound();

            var eliminado = _service.Eliminar(id);
            if (!eliminado)
                return Content(HttpStatusCode.InternalServerError, "No se pudo eliminar el vehículo.");

            // Devuelve 204 No Content para indicar éxito sin payload
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Editar(Vehiculo vehiculo)
        {
            var respuesta = _service.Editar(vehiculo);
            if (vehiculo == null)
                return NotFound();

            // Devuelve 204 No Content para indicar éxito sin payload
            return StatusCode(HttpStatusCode.NoContent);
        }


    }
}
