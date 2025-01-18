using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Predial10.PadronUsuarios
{
    public partial class Frmreprectar : DevComponents.DotNetBar.Office2007Form
    {
       
        public string encabezado1;
        public string encabezado2;
       
        public string tipo="Tarifa";
       
        public Frmreprectar()
        {
            InitializeComponent();
        }

        private void Frmreprectar_Load(object sender, EventArgs e)
        {
            fechaini.SelectedDate = DateTime.Now;
            fechafin.SelectedDate = DateTime.Now;
            fechaini.DisplayMonth = DateTime.Now;
            fechafin.DisplayMonth = DateTime.Now;
        }

        private void btngenerarreporte_Click(object sender, EventArgs e)
        {
            btngenerarreporte.Enabled = false;
          
            string encabezado1 = ""; string encabezado2 = "";
            //filtrocrystal = " {recibomaestro.fecha} >= date ('" + fechaini.SelectedDate.ToString("dd/MM/yyyy") + "') and {recibomaestro.fecha} <= date ('" + fechafin.SelectedDate.ToString("dd/MM/yyyy") + "') ";
            //filtromysql = " fecha>= '" + fechaini.SelectedDate.ToString("yyyy/MM/dd") + "' and fecha<='" + fechafin.SelectedDate.ToString("yyyy/MM/dd") + "'";
            encabezado1 = "DEL DIA : " + fechaini.SelectedDate.ToString("dd/MM/yyyy") + " AL DIA: " + fechafin.SelectedDate.ToString("dd/MM/yyyy");

          
            reportexTarifaITSharp repo = new reportexTarifaITSharp();
                repo.CrearReporte(fechaini.SelectedDate.ToString("yyyy/MM/dd"), fechafin.SelectedDate.ToString("yyyy/MM/dd"), encabezado1, encabezado2);
            btngenerarreporte.Enabled = true;

        }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void reflectionLabel1_Click(object sender, EventArgs e)
        {

        }

        private void fechafin_ItemClick(object sender, EventArgs e)
        {

        }

        private void fechaini_ItemClick(object sender, EventArgs e)
        {

        }
    }
    }

