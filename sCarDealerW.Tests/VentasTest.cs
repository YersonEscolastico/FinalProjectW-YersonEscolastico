using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sCarDealerW.Tests
{
    [TestClass()]
    public class VentaTest
        {
            [TestMethod()]
            public void GuardarTest()
            {
                RepositorioBase<Ventas> db = new RepositorioBase<Ventas>();


                Ventas ve = new Ventas()
                {
                    VentaId = 1,
                    ClienteId = 0,
                    UsuarioId = 0,
                    Total = 0,
                    FechaVenta = DateTime.Now
                };
                Assert.IsTrue(db.Guardar(ve));
            }

            [TestMethod()]
            public void ModificarTest()
            {
                RepositorioBase<Ventas> db = new RepositorioBase<Ventas>();

                Ventas ve = new Ventas()
                {

                    Total = 1,
                };

                Assert.IsTrue(db.Modificar(ve));
            }

            [TestMethod()]
            public void BuscarTest()
            {
                RepositorioBase<Ventas> db = new RepositorioBase<Ventas>();


                Assert.IsNotNull(db.Buscar(1));
            }

            [TestMethod()]
            public void GetListTest()
            {
                RepositorioBase<Ventas> db = new RepositorioBase<Ventas>();


                Assert.IsNotNull(db.GetList(t => true));
            }


            [TestMethod()]
            public void EliminarTest()
            {
                RepositorioBase<Ventas> db = new RepositorioBase<Ventas>();

                Assert.IsTrue(db.Eliminar(1));
            }
        }
    }
