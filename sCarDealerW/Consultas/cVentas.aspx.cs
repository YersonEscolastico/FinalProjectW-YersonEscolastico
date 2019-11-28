using BLL;
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
    public partial class cVentas : System.Web.UI.Page
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
            Expression<Func<Ventas, bool>> filtros = x => true;
            RepositorioBase<Ventas> repositorio = new RepositorioBase<Ventas>();
            List<Ventas> lista = new List<Ventas>();

            DateTime Desde = Utils.ToDateTime(DesdeTextBox.Text);
            DateTime Hasta = Utils.ToDateTime(HastaTextBox.Text);

            int criterio = Utils.ToInt(CriterioTextBox.Text);
            switch (BuscarPorDropDownList.SelectedIndex)
            {
                case 0:
                    filtros = x => true;
                    break; //todo
                case 1:
                    filtros = c => c.VentaId == criterio;
                    break;
                case 2:
                    filtros = c => c.VehiculoId == criterio;
                    break;
                case 3:
                    filtros = c => c.VentaId == criterio;
                    break;

            }
            if (DesdeTextBox.Text != "" & HastaTextBox.Text != "")
            {
                lista = repositorio.GetList(filtros).Where(x => x.FechaVenta.Date >= Desde && x.FechaVenta.Date <= Hasta).ToList();
            }
            else
            {
                lista = repositorio.GetList(filtros);
            }
            DatosGridView.DataSource = lista;
            DatosGridView.DataBind();
        }

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~\Reportes\VentasReport.aspx");
        }
    }
}