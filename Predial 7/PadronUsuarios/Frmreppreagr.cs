using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace Predial10.PadronUsuarios
{
    public partial class Frmreppreagr : DevComponents.DotNetBar.Office2007Form
    {
        public string encabezado1;
        public string encabezado2;

        public string tipo = "Tarifa";
        ReportDocument reporte = new ReportDocument();
        public Frmreppreagr()
        {
            InitializeComponent();
        }

        private void btngenerarreporte_Click(object sender, EventArgs e)
        {
            btngenerarreporte.Enabled = false;
            string filtrocrystal = "";
            string filtromysql = "";
            string encabezado1 = ""; string encabezado2 = "";
            filtrocrystal = " {vusuario.fechaalta} >= date ('" + fechaini.SelectedDate.ToString("dd/MM/yyyy") + "') and {vusuario.fechaalta} <= date ('" + fechafin.SelectedDate.ToString("dd/MM/yyyy") + "') ";
            //filtromysql = " fecha>= '" + fechaini.SelectedDate.ToString("yyyy/MM/dd") + "' and fecha<='" + fechafin.SelectedDate.ToString("yyyy/MM/dd") + "'";
            encabezado1 = "DEL DIA : " + fechaini.SelectedDate.ToString("dd/MM/yyyy") + " AL DIA: " + fechafin.SelectedDate.ToString("dd/MM/yyyy");

            DataSet1 data = new DataSet1();
            data.EnforceConstraints = false;
            DataSet1TableAdapters.empresaTableAdapter x = new DataSet1TableAdapters.empresaTableAdapter();
            x.Fill(data.empresa);

          

            try
            {
                DataSet1TableAdapters.vusuarioTableAdapter vusu = new DataSet1TableAdapters.vusuarioTableAdapter();
                vusu.Fill(data.vusuario);
            }
            catch (Exception algo4)
            {
            }
            try
            {
               
                    reporte.Load("./reportes/rptpreagrtar.rpt");
               

                reporte.SetDataSource(data);
                reporte.RecordSelectionFormula = filtrocrystal;
                reporte.DataDefinition.FormulaFields["ENCABEZADO"].Text = "'" + encabezado1 + "'";
                crystalReportViewer1.ReportSource = reporte;
                btngenerarreporte.Enabled = true;
            }
            catch (Exception algo4)
            {
            }
        }

        private void Frmreppreagr_Load(object sender, EventArgs e)
        {
            fechaini.SelectedDate = DateTime.Now;
            fechafin.SelectedDate = DateTime.Now;
            fechaini.DisplayMonth = DateTime.Now;
            fechafin.DisplayMonth = DateTime.Now;
        }


    }
}
