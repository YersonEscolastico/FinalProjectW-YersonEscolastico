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
    RepositorioBase<Ventas> cl = new RepositorioBase<Ventas>();

    try
    {
        var anterior = cl.Buscar(ventas.VentaId);

        foreach (var item in anterior.Detalle)
        {
            if (!ventas.Detalle.Any(A => A.VentasDetalleID == item.VentasDetalleID))
            {
                db.Ventas.Find(item.VentaId).Total += item.SubTotal;
                db.Entry(item).State = EntityState.Deleted;

            }
        }
        foreach (var item in ventas.Detalle)
        {
            if (item.VentasDetalleID == 0)
            {
                db.Ventas.Find(item.VentaId).Total -= item.SubTotal;
                db.Entry(item).State = EntityState.Added;
            }
            else
            {
                db.Entry(item).State = EntityState.Modified;
            }

            paso = db.SaveChanges() > 0;
        }

        db = new Contexto();
        decimal modificado = ventas.Total - anterior.Total;
        RepositorioBase<Usuarios> repositorioBase = new RepositorioBase<Usuarios>();
        var Usuario = db.Usuarios.Find(ventas.UsuarioId);
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
    return paso;

}



        public static Ventas Buscar(int id)
        {
            Ventas entity;
            Contexto db = new Contexto();

            try
            {
                entity = db.Set<Ventas>().Find(id);

                if (entity != null)
                {
                    entity.Detalle.Count();
                }
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
            Ventas ventas = new Ventas();
            Vehiculos v = new Vehiculos();
            try
            {
                if (v.Estado == "Vendido")
                {
                    string estado = "Disponible";
                    foreach (var item in ventas.Detalle)
                    {
                        db.Vehiculos.Find(item.VehiculoId).Estado = estado;
                    }
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