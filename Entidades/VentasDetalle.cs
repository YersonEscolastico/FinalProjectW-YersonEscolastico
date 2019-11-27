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
        public decimal Precio { get; set; }
        public string Vin  { get; set; }
        public VentasDetalle()
        {
            VentasDetalleID = 0;
            VentaId = 0;
            VehiculoId = 0;
            Descripcion = "";
            Precio = 0;
            Vin = "";
        }

        public VentasDetalle(int ventaId, int vehiculoId, decimal precio, string descripcion,string vin)
        {
            VentaId = ventaId;
            VehiculoId = vehiculoId;
            Precio = precio;
            Descripcion = descripcion;
            Vin = vin;
        }
    }
}
