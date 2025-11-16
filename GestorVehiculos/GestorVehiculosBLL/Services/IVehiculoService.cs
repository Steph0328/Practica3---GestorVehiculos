using System.Collections.Generic;
using GestorVehiculosDAL.Models;

namespace GestorVehiculosBLL.Services
{
    public interface IVehiculoService
    {
        IEnumerable<Vehiculo> ObtenerTodos();
        Vehiculo ObtenerPorId(int id);
    }
}
