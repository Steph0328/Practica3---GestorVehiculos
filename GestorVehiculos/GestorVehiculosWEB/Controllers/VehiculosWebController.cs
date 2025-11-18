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

        // GET: VehiculosWeb/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var vehiculo = _service.ObtenerPorId(id.Value);
            if (vehiculo == null) return HttpNotFound();

            return View(vehiculo);
        }

        // POST: VehiculosWeb/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            var eliminado = _service.Eliminar(id);
            if (!eliminado)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "No se pudo eliminar el vehículo.");
            }
            return RedirectToAction("Index");
        }

        //  **EDITAR VEHÍCULO (GET)**
        public ActionResult Editar(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var vehiculo = _service.ObtenerPorId(id.Value);
            if (vehiculo == null)
                return HttpNotFound();

            return View(vehiculo);
        }

       
        //  **EDITAR VEHÍCULO (POST)**
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Vehiculo vehiculo)
        {
            if (!ModelState.IsValid)
            {
                // Vuelve a mostrar el formulario con errores
                return View(vehiculo);
            }

            var actualizado = _service.Editar(vehiculo);
            if (!actualizado)
            {
                ModelState.AddModelError("", "No se pudo actualizar el vehículo.");
                return View(vehiculo);
            }

            // Redirige a la lista tras actualizar
            return RedirectToAction("Index");
        }

        //  AGREGAR VEHÍCULO (GET)
        
        public ActionResult Agregar()
        {
            // Devuelve un formulario vacío
            return View();
        }

        
        //  AGREGAR VEHÍCULO (POST)
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Vehiculo vehiculo)
        {
            if (!ModelState.IsValid)
            {
                // Devuelve la vista con errores de validación
                return View(vehiculo);
            }

            var agregado = _service.Agregar(vehiculo);
            if (!agregado)
            {
                ModelState.AddModelError("", "No se pudo agregar el vehículo.");
                return View(vehiculo);
            }

            // Redirige a la lista de vehículos tras agregar
            return RedirectToAction("Index");
        }


    }
}
