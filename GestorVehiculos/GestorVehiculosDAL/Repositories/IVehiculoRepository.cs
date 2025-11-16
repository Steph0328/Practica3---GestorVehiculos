using System.Collections.Generic;
using GestorVehiculosDAL.Models;

namespace GestorVehiculosDAL.Repositories
{
    public interface IVehiculoRepository
    {
        IEnumerable<Vehiculo> ObtenerTodos();
        Vehiculo ObtenerPorId(int id);
    }
}
