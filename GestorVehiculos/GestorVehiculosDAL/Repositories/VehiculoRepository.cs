using System.Collections.Generic;
using System.Linq;
using GestorVehiculosDAL.Models;

namespace GestorVehiculosDAL.Repositories
{
    public class VehiculoRepository : IVehiculoRepository
    {
        // Simulación de una "BD" en memoria
        private static readonly List<Vehiculo> _vehiculos = new List<Vehiculo>
        {
            new Vehiculo { Id = 1, Marca = "Toyota", Modelo = "Corolla", Anio = 2020, Precio = 15000000, Color = "Blanco", Placa = "ABC123" },
            new Vehiculo { Id = 2, Marca = "Hyundai", Modelo = "Accent", Anio = 2019, Precio = 13000000, Color = "Gris", Placa = "DEF456" },
            new Vehiculo { Id = 3, Marca = "Kia", Modelo = "Sportage", Anio = 2021, Precio = 22000000, Color = "Negro", Placa = "GHI789" }
        };

        public IEnumerable<Vehiculo> ObtenerTodos()
        {
            return _vehiculos;
        }

        public Vehiculo ObtenerPorId(int id)
        {
            return _vehiculos.FirstOrDefault(v => v.Id == id);
        }
    }
}
