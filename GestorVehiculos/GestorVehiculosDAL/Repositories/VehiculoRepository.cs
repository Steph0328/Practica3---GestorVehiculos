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

        public bool Eliminar(int id)
        {
            var v = _vehiculos.FirstOrDefault(x => x.Id == id);
            if (v == null) return false;
            _vehiculos.Remove(v);
            return true;
        }

        // ✔ NUEVO: Editar / Actualizar Vehículo
        public bool Editar(Vehiculo vehiculoActualizado)
        {
            var existente = _vehiculos.FirstOrDefault(v => v.Id == vehiculoActualizado.Id);
            if (existente == null) return false;

            existente.Marca = vehiculoActualizado.Marca;
            existente.Modelo = vehiculoActualizado.Modelo;
            existente.Anio = vehiculoActualizado.Anio;
            existente.Precio = vehiculoActualizado.Precio;
            existente.Color = vehiculoActualizado.Color;
            existente.Placa = vehiculoActualizado.Placa;

            return true;
        }

        // Agregar Vehículo
        public bool Agregar(Vehiculo nuevoVehiculo)
        {
            if (nuevoVehiculo == null) return false;

            // Generar el próximo ID
            int nuevoId = _vehiculos.Any() ? _vehiculos.Max(v => v.Id) + 1 : 1;
            nuevoVehiculo.Id = nuevoId;

            _vehiculos.Add(nuevoVehiculo);
            return true;
        }
    }
}
