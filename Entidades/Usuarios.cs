using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Usuarios
    {
        [Key]

        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Email { get; set; }
        public string Usuarioss { get; set; }
        public string Clave { get; set; }
        public string NivelAcceso { get; set; }
        public decimal TotalVentas { get; set; }
        public DateTime Fecha { get; set; }


        public Usuarios()
        {
            UsuarioId = 0;
            Nombres = string.Empty;
            Email = string.Empty;
            Usuarioss = string.Empty;
            Clave = string.Empty;
            NivelAcceso = string.Empty;
            TotalVentas = 0;
            Fecha = DateTime.Now;
        }
    }
}