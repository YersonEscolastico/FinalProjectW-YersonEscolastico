using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioVentas
    {
        public static bool Guardar(Ventas ventas)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                RepositorioBase<Clientes> cl = new RepositorioBase<Clientes>();

                if (db.Ventas.Add(ventas) != null)
                {
                    string estado = "Vendido";
                    foreach (var item in ventas.Detalle)
                    {
                        db.Vehiculos.Find(item.VehiculoId).Estado = estado;
                    }
                    var cliente = cl.Buscar(ventas.ClienteId);
                    db.Usuarios.Find(ventas.UsuarioId).TotalVentas += ventas.Total;
                    ventas.CalcularMonto();
                    paso = db.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Modificar(Ventas ventas)
        {
            bool paso = false;
            Contexto db = new Contexto();
            Contexto dbb = new Contexto();

            var anterior =Buscar(ventas.VentaId);
                RepositorioBase<Usuarios> repositorioBase = new RepositorioBase<Usuarios>();
            try
            {

                foreach (var item in anterior.Detalle.ToList())
                {
                    if (!ventas.Detalle.Exists(A => A.VentasDetalleID == item.VentasDetalleID))
                    {
                        ventas.Total += item.Precio;
                        dbb.Entry(item).State = EntityState.Deleted;

                    }
                    paso = dbb.SaveChanges() > 0;
                }
                foreach (var item in ventas.Detalle)
                {
                    if (item.VentasDetalleID == 0)
                    {
                       ventas.Total -= item.Precio;
                        db.Entry(item).State = EntityState.Added;
                    }
                    else
                    {
                        db.Entry(item).State = EntityState.Modified;
                    }

                }
                Ventas v = new Ventas();
                decimal modificado = ventas.Total - anterior.Total;
                var Usuario = repositorioBase.Buscar(ventas.UsuarioId);
                Usuario.TotalVentas += modificado;
                repositorioBase.Modificar(Usuario);

                ventas.CalcularMonto();
                db.Entry(ventas).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            db.Dispose();
            return paso;

        }



        public static Ventas Buscar(int id)
        {
            Ventas entity;
            Contexto db = new Contexto();

            try
            {
                entity = db.Set<Ventas>().Include(x => x.Detalle).AsNoTracking().Where(w => w.VentaId == id).FirstOrDefault(); 
                
            }
            catch (Exception)
            {
                throw;
            }
            return entity;
        }


        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<Usuarios> cl = new RepositorioBase<Usuarios>();
            Ventas ventas = Buscar(id); 
           
            try
            {
                    string estado = "Disponible";
                    foreach (var item in ventas.Detalle)
                    {
                        db.Vehiculos.Find(item.VehiculoId).Estado = estado;
                    } 
                var Ventas = db.Ventas.Find(id);
                var clientes = cl.Buscar(Ventas.VentaId);
                db.Usuarios.Find(Ventas.UsuarioId).TotalVentas -= Ventas.Total;
                db.Entry(Ventas).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
    }
}