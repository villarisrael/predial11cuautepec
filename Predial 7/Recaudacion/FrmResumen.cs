using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Predial10.Recaudacion
{
    public partial class FrmResumen :  DevComponents.DotNetBar.OfficeForm
    {
        public FrmResumen()
        {
            InitializeComponent();
        }

        private void btngenerarreporte_Click(object sender, EventArgs e)
        {
            btngenerarreporte.Enabled = false;

            string encabezado1 = ""; string encabezado2 = "";
            //filtrocrystal = " {recibomaestro.fecha} >= date ('" + fechaini.SelectedDate.ToString("dd/MM/yyyy") + "') and {recibomaestro.fecha} <= date ('" + fechafin.SelectedDate.ToString("dd/MM/yyyy") + "') ";
            //filtromysql = " fecha>= '" + fechaini.SelectedDate.ToString("yyyy/MM/dd") + "' and fecha<='" + fechafin.SelectedDate.ToString("yyyy/MM/dd") + "'";
            encabezado1 = "DEL DIA : " + fechaini.SelectedDate.ToString("dd/MM/yyyy") + " AL DIA: " + fechafin.SelectedDate.ToString("dd/MM/yyyy");


            Resumen repo = new Resumen();
            repo.CrearReporte(fechaini.SelectedDate.ToString("yyyy/MM/dd"), fechafin.SelectedDate.ToString("yyyy/MM/dd"), encabezado1, "RESUMEN DE INGRESOS POR FECHAS");
            btngenerarreporte.Enabled = true;
        }

        private void FrmResumen_Load(object sender, EventArgs e)
        {
            fechaini.SelectedDate = DateTime.Now;
            fechafin.SelectedDate = DateTime.Now;
            fechaini.DisplayMonth = DateTime.Now;
            fechafin.DisplayMonth = DateTime.Now;
        }
    }
}
