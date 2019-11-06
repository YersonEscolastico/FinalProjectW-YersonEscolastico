using System;
using System.Collections.Generic;
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
        public decimal SubTotal { get; set; }
        public string Descripcion { get; set; }

        public VentasDetalle()
        {
            VentasDetalleID = 0;
            VentaId = 0;
            VehiculoId = 0;
            SubTotal = 0;
            Descripcion = string.Empty;
        }

        public VentasDetalle(int ventasDetalleID, int ventaId, int vehiculoId, int precio, decimal subtotal, string descripcion)
        {
            VentasDetalleID = ventasDetalleID;
            VentaId = ventaId;
            VehiculoId = vehiculoId;
            SubTotal = subtotal;
            Descripcion = descripcion;
        }
    }
}