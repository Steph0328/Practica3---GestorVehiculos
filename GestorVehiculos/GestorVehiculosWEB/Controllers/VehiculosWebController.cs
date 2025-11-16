using GestorVehiculosBLL.Services;
using GestorVehiculosDAL.Models;
using GestorVehiculosDAL.Repositories;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace GestorVehiculosWEB.Controllers
{
    public class VehiculosWebController : Controller
    {
        private readonly IVehiculoService _service;

        public VehiculosWebController()
        {
            IVehiculoRepository repo = new VehiculoRepository();
            _service = new VehiculoService(repo);
        }

        // GET: VehiculosWeb
        // Lista de vehículos
        public ActionResult Index()
        {
            IEnumerable<Vehiculo> vehiculos = _service.ObtenerTodos();
            return View(vehiculos);
        }

        // GET: VehiculosWeb/Detalle/5
        // Detalle de un vehículo
        public ActionResult Detalle(int? id)
        {
            if (id == null)
            {
                // 400 Bad Request si llaman a /VehiculosWeb/Detalle sin id
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var vehiculo = _service.ObtenerPorId(id.Value);

            if (vehiculo == null)
            {
                return HttpNotFound();
            }

            return View(vehiculo);
        }
    }
}
