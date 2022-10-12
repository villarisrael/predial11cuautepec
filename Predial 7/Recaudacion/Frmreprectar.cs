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
    public partial class Frmreprectar : DevComponents.DotNetBar.Office2007Form
    {
       
        public string encabezado1;
        public string encabezado2;
       
        public string tipo="Tarifa";
        ReportDocument reporte = new ReportDocument();
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
            string filtrocrystal = "";
            string filtromysql = "";
            string encabezado1 = ""; string encabezado2 = "";
            //filtrocrystal = " {recibomaestro.fecha} >= date ('" + fechaini.SelectedDate.ToString("dd/MM/yyyy") + "') and {recibomaestro.fecha} <= date ('" + fechafin.SelectedDate.ToString("dd/MM/yyyy") + "') ";
            //filtromysql = " fecha>= '" + fechaini.SelectedDate.ToString("yyyy/MM/dd") + "' and fecha<='" + fechafin.SelectedDate.ToString("yyyy/MM/dd") + "'";
            encabezado1 = "DEL DIA : " + fechaini.SelectedDate.ToString("dd/MM/yyyy") + " AL DIA: " + fechafin.SelectedDate.ToString("dd/MM/yyyy");

            predialchicoDataSet data = new predialchicoDataSet();
            data.EnforceConstraints = false;
            predialchicoDataSetTableAdapters.empresaTableAdapter x = new predialchicoDataSetTableAdapters.empresaTableAdapter();
            x.Fill(data.empresa);

           predialchicoDataSetTableAdapters.recibomaestroTableAdapter   j = new predialchicoDataSetTableAdapters.recibomaestroTableAdapter ();
                        try
                        {
                            j.FillByfecha(data.recibomaestro,fechaini.SelectedDate,fechafin.SelectedDate );

                        }
                        catch (Exception algo)
                        {
                        }
            try
            {
                predialchicoDataSetTableAdapters.esclavodetalleTableAdapter det = new predialchicoDataSetTableAdapters.esclavodetalleTableAdapter();
                det.Fill(data.esclavodetalle);

              }
                catch (Exception algo2)
                {

                }
            
            try
            {
                predialchicoDataSetTableAdapters.tarifasTableAdapter tar = new predialchicoDataSetTableAdapters.tarifasTableAdapter();
                tar.Fill(data.tarifas);
            }
            catch (Exception algo3)
            {
            }

              try
            {
            predialchicoDataSetTableAdapters.vusuarioTableAdapter vusu = new predialchicoDataSetTableAdapters.vusuarioTableAdapter();
            vusu.Fill(data.vusuario);
                }
        catch (Exception algo4)
                {
                }
               try
            {
                if (tipo == "Tarifa")
                {
                    reporte.Load("./reportes/rptingtar.rpt");
                }
                else
                {
                    reporte.Load("./reportes/rptingcom.rpt");
                }
           
            reporte.SetDataSource(data);
            reporte.DataDefinition.FormulaFields["ENCABEZADO"].Text = "'" + encabezado1 + "'";
            crystalReportViewer1.ReportSource = reporte;
            }
               catch (Exception algo4)
               {
               }
            btngenerarreporte.Enabled = true;

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

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

