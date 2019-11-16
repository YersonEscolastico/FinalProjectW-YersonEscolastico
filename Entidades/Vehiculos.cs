using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Vehiculos
    {
        [Key]

        public int VehiculoId { get; set; }
        public string Vin { get; set; }
        public string Marca { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public string Anio { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
        public int UsuarioId { get; set; }
        public string Estado { get; set; }

        public DateTime Fecha { get; set; }
        public DateTime FechaRegistro { get; set; }

        public Vehiculos()
        {
            VehiculoId = 0;
            Vin = string.Empty;
            Marca = string.Empty;
            Placa = string.Empty;
            Modelo = string.Empty;
            Color = string.Empty;
            Anio = string.Empty;
            Descripcion = string.Empty;
            Costo = 0;
            Precio = 0;
            UsuarioId = 0;
            Estado = string.Empty;
            Fecha = DateTime.Now;
            FechaRegistro = DateTime.Now;
        }
    }
}