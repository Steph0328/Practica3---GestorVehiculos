using System.Collections.Generic;
using GestorVehiculosDAL.Models;
using GestorVehiculosDAL.Repositories;

namespace GestorVehiculosBLL.Services
{
    public class VehiculoService : IVehiculoService
    {
        private readonly IVehiculoRepository _vehiculoRepository;

        public VehiculoService(IVehiculoRepository vehiculoRepository)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        public IEnumerable<Vehiculo> ObtenerTodos()
        {
            return _vehiculoRepository.ObtenerTodos();
        }

        public Vehiculo ObtenerPorId(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            return _vehiculoRepository.ObtenerPorId(id);
        }

        public bool Eliminar(int id)
        {
            if (id <= 0) return false;
            return _vehiculoRepository.Eliminar(id);
        }

        public bool Editar(Vehiculo vehiculo)
        {
            // Validaciones básicas antes de actualizar
            if (vehiculo == null) return false;
            if (vehiculo.Id <= 0) return false;

            // Validar que exista antes de editar
            var existente = _vehiculoRepository.ObtenerPorId(vehiculo.Id);
            if (existente == null) return false;

            return _vehiculoRepository.Editar(vehiculo);
        }

        // AGREGAR VEHÍCULO
        public bool Agregar(Vehiculo vehiculo)
        {
            // Validación básica
            if (vehiculo == null) return false;

            // Validaciones adicionales opcionales:
            if (string.IsNullOrWhiteSpace(vehiculo.Marca)) return false;
            if (string.IsNullOrWhiteSpace(vehiculo.Modelo)) return false;
            if (vehiculo.Anio <= 0) return false;

            return _vehiculoRepository.Agregar(vehiculo);
        }


    }
}
