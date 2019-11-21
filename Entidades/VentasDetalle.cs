using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class VentasDetalle
    {
        public int VentasDetalleID { get; set; }
        public int VentaId { get; set; }
        public int VehiculoId { get; set; }
        public string Descripcion { get; set; }
        public decimal SubTotal { get; set; }

        public virtual Vehiculos Vehiculos { get; set; }

        public VentasDetalle()
        {
            VentasDetalleID = 0;
            VentaId = 0;
            VehiculoId = 0;
            Descripcion = "";
            SubTotal = 0;
        }

        public VentasDetalle(int ventaId, int vehiculoId, decimal subtotal, string descripcion)
        {
            VentaId = ventaId;
            VehiculoId = vehiculoId;
            SubTotal = subtotal;
            Descripcion = descripcion;
        }
    }
}