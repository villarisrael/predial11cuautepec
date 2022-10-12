using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CrystalDecisions.CrystalReports.Engine;

namespace Predial10.PadronUsuarios
{
    public partial class frmreportcomp : DevComponents.DotNetBar.OfficeForm
    {
        ReportDocument reporte = new ReportDocument();
        public frmreportcomp()
        {
            InitializeComponent();
        }

        private void frmreportcomp_Load(object sender, EventArgs e)
        {
            predialchicoDataSet data = new predialchicoDataSet();
            data.EnforceConstraints = false;
            predialchicoDataSetTableAdapters.empresaTableAdapter x = new predialchicoDataSetTableAdapters.empresaTableAdapter();
            x.Fill(data.empresa);
            predialchicoDataSetTableAdapters.vusuarioTableAdapter j = new predialchicoDataSetTableAdapters.vusuarioTableAdapter();
            try
            {
                j.Fill(data.vusuario);

            }
            catch (Exception algo)
            {
            }
            reporte.Load("./reportes/Rptcomtar.rpt");
            reporte.SetDataSource(data);
           

            crystalReportViewer1.ReportSource = reporte;
        }
    }
}