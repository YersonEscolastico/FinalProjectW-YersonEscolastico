using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public int VehiculoId { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaVenta { get; set; }

        public virtual List<VentasDetalle> Detalle { get; set; }
        public Ventas()
        {
            VentaId = 0;
            Total = 0;
            ClienteId = 0;
            UsuarioId = 0;
            VehiculoId = 0;
            FechaVenta = DateTime.Now;
            Detalle = new List<VentasDetalle>();
        }
        public void CalcularMonto()
        {
            decimal total = 0;

            foreach (var item in Detalle)
            {
                total += item.SubTotal;
            }
            Total = total;
        }
    }
}