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
    public class VehiculoTest
    {
        [TestMethod()]
    public void GuardarTest()
    {
        RepositorioBase<Vehiculos> db = new RepositorioBase<Vehiculos>();


        Vehiculos vh = new Vehiculos()
        {
            VehiculoId = 1,
            Vin = "21e1",
            Marca = "Toyota",
            Placa = "121",
            Modelo = "Ferr",
            Color = "Rojo",
            Anio = "21",
            Descripcion = "ew",
            Costo = 0,
            Precio = 0,
            Estado = "Vendido",
            FechaRegistro = DateTime.Now
        };
        Assert.IsTrue(db.Guardar(vh));
    }

    [TestMethod()]
    public void ModificarTest()
    {
        RepositorioBase<Vehiculos> db = new RepositorioBase<Vehiculos>();

        Vehiculos vh = new Vehiculos()
        {
            VehiculoId = 1,
            Vin = "21e1",
            Marca = "Toyota",
            Placa = "121",
            Modelo = "Ferr",
            Color = "Rojo",
            Anio = "21",
            Descripcion = "ew",
            Costo = 0,
            Precio = 0,
            Estado = "Vendido",
            FechaRegistro = DateTime.Now
        };

        Assert.IsTrue(db.Modificar(vh));
    }

    [TestMethod()]
    public void BuscarTest()
    {
        RepositorioBase<Vehiculos> db = new RepositorioBase<Vehiculos>();

        Assert.IsNotNull(db.Buscar(1));
    }

    [TestMethod()]
    public void GetListTest()
    {
        RepositorioBase<Vehiculos> db = new RepositorioBase<Vehiculos>();

        Assert.IsNotNull(db.GetList(t => true));
    }


    [TestMethod()]
    public void EliminarTest()
    {
        RepositorioBase<Vehiculos> db = new RepositorioBase<Vehiculos>();

        Assert.IsTrue(db.Eliminar(1));
    }
}
}