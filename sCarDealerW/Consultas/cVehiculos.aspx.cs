﻿using BLL;
using Entidades;
using sCarDealerW.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sCarDealerW.Consultas
{
    public partial class cVehiculos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Vehiculos, bool>> filtros = x => true;
            RepositorioBase<Vehiculos> repositorio = new RepositorioBase<Vehiculos>();
            List<Vehiculos> lista = new List<Vehiculos>();

            DateTime Desde = Utils.ToDateTime(DesdeTextBox.Text);
            DateTime Hasta = Utils.ToDateTime(HastaTextBox.Text);

            int criterio = Utils.ToInt(CriterioTextBox.Text);
            switch (BuscarPorDropDownList.SelectedIndex)
            {
                case 0:
                    filtros = x => true;
                    break; //todo
                case 1:
                    filtros = c => c.VehiculoId == criterio;
                    break; //ID
                case 2:
                    filtros = c => c.Placa.Contains(CriterioTextBox.Text);
                    break; //Username
                case 3:
                    filtros = c => c.Anio.Contains(CriterioTextBox.Text);
                    break; //Password
                case 4:
                    filtros = c => c.Color.Contains(CriterioTextBox.Text);
                    break; //Tipo
            }
            if (CheckBox.Checked == true)
            {
                lista = repositorio.GetList(filtros).Where(x => x.Fecha.Date >= Desde && x.Fecha.Date <= Hasta).ToList();
            }
            else
            {
                lista = repositorio.GetList(filtros);
            }
            DatosGridView.DataSource = lista;
            DatosGridView.DataBind();
        }
    }
}