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
    public class ClientesTest
    {
        [TestMethod()]
        public void GuardarTest()
        {
            RepositorioBase<Clientes> db = new RepositorioBase<Clientes>();

            Clientes cliente = new Clientes()
            {
                ClienteId = 1,
                Nombres = "Yesica",
                Sexo = "F",
                Email = "Yesica@gmail.com",
                Cedula = "0",
                Direccion = "g",
                Telefono = "8092145",
                Celular = "829213",
                FechaNacimiento = DateTime.Now,
                FechaRegistro = DateTime.Now
            };

            Assert.IsTrue(db.Guardar(cliente));
        }

        [TestMethod()]
        public void ModificarTest()
        {
            RepositorioBase<Clientes> db = new RepositorioBase<Clientes>();

            Clientes cliente = new Clientes()
            {
                ClienteId = 1,
                Nombres = "Yesic",

            };

            Assert.IsTrue(db.Modificar(cliente));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            RepositorioBase<Clientes> db = new RepositorioBase<Clientes>();

            Assert.IsNotNull(db.Buscar(1));
        }

        [TestMethod()]
        public void EliminarTest()
        {
            RepositorioBase<Clientes> db = new RepositorioBase<Clientes>();

            Assert.IsTrue(db.Eliminar(1));
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Clientes> db = new RepositorioBase<Clientes>();

            Assert.IsNotNull(db.GetList(t => true));
        }
    }
}