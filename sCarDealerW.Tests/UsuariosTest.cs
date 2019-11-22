using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace sCarDealerW.Tests
{
    [TestClass()]
    public class UsuarioTest
    {

        [TestMethod()]
        public void GuardarTest()
        {
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();


            Usuarios us = new Usuarios()
            {
                UsuarioId = 1,
                Nombres = "Juan Perez",
                Email = "Juan@gmail.com",
                Usuarioss = "Juan123",
                Clave = "123",
                NivelAcceso = "Usuario",
                Fecha = DateTime.Now
            };
            Assert.IsTrue(db.Guardar(us));
        }

        [TestMethod()]
        public void ModificarTest()
        {
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();

            Usuarios us = new Usuarios()
            {
                UsuarioId = 1,
                Nombres = "Juann",
                Email = "Juan@gmail.com",
                Usuarioss = "Juan123",
                Clave = "123",
                NivelAcceso = "Usuario",
                Fecha = DateTime.Now
            };

            Assert.IsTrue(db.Modificar(us));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();

            Assert.IsNotNull(db.Buscar(1));
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();

            Assert.IsNotNull(db.GetList(t => true));
        }


        [TestMethod()]
        public void EliminarTest()
        {
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();

            Assert.IsTrue(db.Eliminar(1));
        }
    }
}