using System.Collections.Generic;
using GestorVehiculosDAL.Models;

namespace GestorVehiculosBLL.Services
{
    public interface IVehiculoService
    {
        IEnumerable<Vehiculo> ObtenerTodos();
        Vehiculo ObtenerPorId(int id);
        bool Eliminar(int id);

        bool Editar(Vehiculo vehiculo);
    }
}
