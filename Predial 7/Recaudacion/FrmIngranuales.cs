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

            string Encabezado1 = "", encabezado2 = "";
            if (!chkprimer.Checked && !chksegundo.Checked && !chktercero.Checked && !chkcuarto.Checked && !chkanual.Checked)
            {
                MessageBox.Show("Seleccione al menos un período.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                DateTime dt1 = DateTime.MinValue;
                DateTime dt2 = DateTime.MinValue;

                if (chkprimer.Checked)
                {
                    dt1 = new DateTime(Int32.Parse(cmnperiodo.Text) ,1, 1, 4, 0, 0);
                    dt2 = new DateTime(Int32.Parse(cmnperiodo.Text), 3, 31, 23, 59, 0);



                    Encabezado1 = "'PRIMER TRIMESTRE  " +cmnperiodo.Text + " '";
                }
                if (chksegundo.Checked)
                {
                    dt1 = new DateTime(Int32.Parse(cmnperiodo.Text), 4, 1, 4, 0, 0);
                    dt2 = new DateTime(Int32.Parse(cmnperiodo.Text), 6, 30, 23, 59, 0);

                    Encabezado1 = "'SEGUNDO TRIMESTRE " + cmnperiodo.Text + " '";
                }
                if (chktercero.Checked)
                {
                    dt1 = new DateTime(Int32.Parse(cmnperiodo.Text), 7, 1, 4, 0, 0);
                    dt2 = new DateTime(Int32.Parse(cmnperiodo.Text), 9, 30, 23, 59, 0);

                    Encabezado1 = "'TERCER TRIMESTRE " + cmnperiodo.Text + " '";

                }
                if (chkcuarto.Checked)
                {
                    dt1 = new DateTime(Int32.Parse(cmnperiodo.Text), 10, 1, 4, 0, 0);
                    dt2 = new DateTime(Int32.Parse(cmnperiodo.Text), 12, 31,23, 59, 0);

                    Encabezado1 = "'CUARTO TRIMESTRE "+ cmnperiodo.Text + " '";
                }

                if (chkanual.Checked)
                {
                    dt1 = new DateTime(Int32.Parse(cmnperiodo.Text), 1, 1, 4, 0, 0);
                    dt2 = new DateTime(Int32.Parse(cmnperiodo.Text), 12, 31, 23, 59, 0);

                    Encabezado1 = "'TODO EL AÑO " + cmnperiodo.Text + " '";
                    
                }
                string fechainicio = dt1.ToString("yyyy/MM/dd");

                ReporteTrimestralcs repo = new  ReporteTrimestralcs();
                repo.CrearReporte(fechainicio , dt2.ToString("yyyy/MM/dd"), Encabezado1, encabezado2);
            }

            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

             
            
        }

        private void FrmIngranuales_Load_1(object sender, EventArgs e)
        {
            for (int i=DateTime.Now.Year; i> DateTime.Now.Year-5; i--)
            {
                cmnperiodo.Items.Add(i);
            }
            cmnperiodo.SelectedIndex = 0;
        }
    }
}