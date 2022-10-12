using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CrystalDecisions.CrystalReports.Engine;
using System.Globalization;

namespace Predial10.Recaudacion
{
    public partial class FrmIngranuales : DevComponents.DotNetBar.OfficeForm
    {

        ReportDocument reporte = new ReportDocument();
        public FrmIngranuales()
        {
            InitializeComponent();
        }

        private void FrmIngranuales_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'predialchicoDataSet.esclavodetalle' table. You can move, or remove it, as needed.
           

       
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            predialchicoDataSet data = new predialchicoDataSet();
            data.EnforceConstraints = false;
            predialchicoDataSetTableAdapters.reciboesclavoTableAdapter es = new predialchicoDataSetTableAdapters.reciboesclavoTableAdapter();
            predialchicoDataSetTableAdapters.usuarioTableAdapter us = new predialchicoDataSetTableAdapters.usuarioTableAdapter();

            us.Fill(data.usuario);
            try
            {
                reporte.Load("./reportes/ReporteAnuales.rpt");
                reporte.SetDataSource(data);
                reporte.Subreports[0].SetDataSource(data);
            }
            catch (Exception c)
            {
            }
              DateTime dt1;
              DateTime dt2;
              DateTime dt3;
              DateTime dt4;
            
            try
            {
                if (chkprimer.Checked)
                {
                    dt1 = new DateTime(DateTime.Now.Year ,1, 1, 4, 0, 0);
                    dt2 = new DateTime(DateTime.Now.Year, 3, 31, 4, 0, 0);
                    dt3 = new DateTime(DateTime.Now.Year-1, 1, 1, 4, 0, 0);
                    dt4 = new DateTime(DateTime.Now.Year-1, 3, 31, 4, 0, 0);
                    es.Fillbyperiodos(data.reciboesclavo, dt1 ,dt2,dt3,dt4);

                    reporte.DataDefinition.FormulaFields["ENCABEZADO"].Text = "'PRIMER TRIMESTRE  " + DateTime.Now.Year + " '";
                }
                if (chksegundo.Checked)
                {
                    dt1 = new DateTime(DateTime.Now.Year, 4, 1, 4, 0, 0);
                    dt2 = new DateTime(DateTime.Now.Year, 6, 30, 4, 0, 0);
                    dt3 = new DateTime(DateTime.Now.Year - 1, 4, 1, 4, 0, 0);
                    dt4 = new DateTime(DateTime.Now.Year - 1, 6, 30, 4, 0, 0);
                    es.Fillbyperiodos(data.reciboesclavo, dt1, dt2, dt3, dt4);
                    reporte.DataDefinition.FormulaFields["ENCABEZADO"].Text = "'SEGUNDO TRIMESTRE " + DateTime.Now.Year + " '";
                }
                if (chktercero.Checked)
                {
                    dt1 = new DateTime(DateTime.Now.Year, 7, 1, 4, 0, 0);
                    dt2 = new DateTime(DateTime.Now.Year, 9, 30, 4, 0, 0);
                    dt3 = new DateTime(DateTime.Now.Year - 1, 7, 1, 4, 0, 0);
                    dt4 = new DateTime(DateTime.Now.Year - 1, 9, 30, 4, 0, 0);
                    es.Fillbyperiodos(data.reciboesclavo, dt1, dt2, dt3, dt4);
                    reporte.DataDefinition.FormulaFields["ENCABEZADO"].Text = "'TERCER TRIMESTRE " + DateTime.Now.Year + " '";

                }
                if (chkcuarto.Checked)
                {
                    dt1 = new DateTime(DateTime.Now.Year, 10, 1, 4, 0, 0);
                    dt2 = new DateTime(DateTime.Now.Year, 12, 31, 4, 0, 0);
                    dt3 = new DateTime(DateTime.Now.Year - 1, 10, 1, 4, 0, 0);
                    dt4 = new DateTime(DateTime.Now.Year - 1, 12, 31, 4, 0, 0);
                    es.Fillbyperiodos(data.reciboesclavo, dt1, dt2, dt3, dt4);
                    reporte.DataDefinition.FormulaFields["ENCABEZADO"].Text = "'CUARTO TRIMESTRE "+ DateTime.Now.Year + " '";
                }

                if (chkanual.Checked)
                {
                    dt1 = new DateTime(DateTime.Now.Year, 1, 1, 4, 0, 0);
                    dt2 = new DateTime(DateTime.Now.Year, 12, 31, 4, 0, 0);

                    es.FillByfecha(data.reciboesclavo, dt1, dt2);
                    reporte.DataDefinition.FormulaFields["ENCABEZADO"].Text = "'TODO EL AÑO " + DateTime.Now.Year + " '";
                    
                }
                
                CrystalReportViewer1.ReportSource = reporte;
            }

            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

             
            
        }

        
    }
}