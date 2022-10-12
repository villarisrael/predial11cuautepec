﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace Predial10.Facturacion
{
    public partial class frmrepcomunidades : DevComponents.DotNetBar.Office2007Form
    {
        ReportDocument reporte = new ReportDocument();
        public frmrepcomunidades()
        {
            InitializeComponent();
        }

        private void frmrepcomunidades_Load(object sender, EventArgs e)
        {
            predialchicoDataSet data = new predialchicoDataSet();
            data.EnforceConstraints = false;
            predialchicoDataSetTableAdapters.empresaTableAdapter x = new predialchicoDataSetTableAdapters.empresaTableAdapter();
            x.Fill(data.empresa);
         
           
            predialchicoDataSetTableAdapters.vusuarioTableAdapter  l = new predialchicoDataSetTableAdapters.vusuarioTableAdapter ();
            try
            {
                l.Fill(data.vusuario );

            }
            catch (Exception algo)
            {
            }

            reporte.Load(Application.StartupPath + "./reportes/repcomunidades.rpt");
            reporte.SetDataSource(data);
            crystalReportViewer1.ReportSource = reporte;
        }
    }
}
