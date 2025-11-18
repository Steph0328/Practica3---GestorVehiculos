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
    }
}
