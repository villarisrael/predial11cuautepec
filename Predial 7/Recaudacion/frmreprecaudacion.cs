using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace Predial10.Recaudacion
{
    public partial class frmreprecaudacion : DevComponents.DotNetBar.Office2007Form
    {
        public string filtro;
        public string encabezado1;
        public string encabezado2;
        public string grantotal;
        public string tipo;
        ReportDocument reporte = new ReportDocument();


        public frmreprecaudacion()
        {
            InitializeComponent();
        }

        private void frmreprecaudacion_Load(object sender, EventArgs e)
        {
         

            predialchicoDataSet data = new predialchicoDataSet();
            data.EnforceConstraints = false;
            predialchicoDataSetTableAdapters.empresaTableAdapter x = new predialchicoDataSetTableAdapters.empresaTableAdapter();
            x.Fill(data.empresa);
              if (tipo != "Rubros")
                 {
                        predialchicoDataSetTableAdapters.recibomaestroTableAdapter   j = new predialchicoDataSetTableAdapters.recibomaestroTableAdapter ();
                        try
                        {
                            j.FillBy(data.recibomaestro );

                        }
                        catch (Exception algo)
                        {
                        }

                        predialchicoDataSetTableAdapters.esclavodetalleTableAdapter  k = new predialchicoDataSetTableAdapters.esclavodetalleTableAdapter()  ;
                        try
                        {
                            k.Fill(data.esclavodetalle );

                        }
                        catch (Exception algo)
                        {
                        }
                        predialchicoDataSetTableAdapters.fpagoTableAdapter  l = new predialchicoDataSetTableAdapters.fpagoTableAdapter ();
                        try
                        {
                            l.Fill(data.fpago );

                        }
                        catch (Exception algo)
                        {
                        }

                        reporte.Load(Application.StartupPath +"/reportes/recaudacion.rpt");
                        reporte.SetDataSource(data);
                        reporte.RecordSelectionFormula = filtro;
                        reporte.DataDefinition.FormulaFields["GRANTOTAL"].Text = "'" + grantotal + "'";
                        reporte.Subreports[0].RecordSelectionFormula = filtro;
            
            }
          
         
            if (tipo == "Rubros")
            {
                predialchicoDataSetTableAdapters.recibomaestroTableAdapter j = new predialchicoDataSetTableAdapters.recibomaestroTableAdapter();
                try
                {
                    j.FillBy(data.recibomaestro);

                }
                catch (Exception algo)
                {
                }

                predialchicoDataSetTableAdapters.esclavodetalleTableAdapter k = new predialchicoDataSetTableAdapters.esclavodetalleTableAdapter();
                try
                {
                    k.Fill(data.esclavodetalle);

                }
                catch (Exception algo)
                {
                }
               
                  predialchicoDataSetTableAdapters.temesclavoTableAdapter l = new predialchicoDataSetTableAdapters.temesclavoTableAdapter();
                  
                 try
                {
                    l.Fill(data.temesclavo);

                }
                catch (Exception algo)
                {
                }
                
              




                reporte.Load(Application.StartupPath + "/reportes/rubros.rpt");
               // el valor true suprime la seccion en el reporte => ocultar
                reporte.SetDataSource(data);
                reporte.RecordSelectionFormula = filtro;
           
            }
            reporte.DataDefinition.FormulaFields["ENCABEZADO1"].Text = "'" + encabezado1 + "'";
            reporte.DataDefinition.FormulaFields["ENCABEZADO2"].Text = "'" + encabezado2 + "'";
        
            crystalReportViewer1.ReportSource = reporte;
        }
    }
}
