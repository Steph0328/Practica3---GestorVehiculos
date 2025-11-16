namespace GestorVehiculosDAL.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int Anio { get; set; }
        public decimal Precio { get; set; }
        public string Color { get; set; } = string.Empty;
        public string Placa { get; set; } = string.Empty;
    }
}
