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
         

            DataSet1 data = new DataSet1();
            data.EnforceConstraints = false;
            DataSet1TableAdapters.empresaTableAdapter x = new DataSet1TableAdapters.empresaTableAdapter();
            x.Fill(data.empresa);
              if (tipo != "Rubros")
                 {
                        DataSet1TableAdapters.recibomaestroTableAdapter   j = new DataSet1TableAdapters.recibomaestroTableAdapter ();
                        try
                        {
                            j.Fill(data.recibomaestro );

                        }
                        catch (Exception algo)
                        {
                        }

                        DataSet1TableAdapters.esclavodetalleTableAdapter  k = new DataSet1TableAdapters.esclavodetalleTableAdapter()  ;
                        try
                        {
                            k.FillBy(data.esclavodetalle );

                        }
                        catch (Exception algo)
                        {
                        }
                        DataSet1TableAdapters.fpagoTableAdapter  l = new DataSet1TableAdapters.fpagoTableAdapter ();
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
                DataSet1TableAdapters.recibomaestroTableAdapter j = new DataSet1TableAdapters.recibomaestroTableAdapter();
                try
                {
                    j.Fill(data.recibomaestro);

                }
                catch (Exception algo)
                {
                }

                DataSet1TableAdapters.esclavodetalleTableAdapter k = new DataSet1TableAdapters.esclavodetalleTableAdapter();
                try
                {
                    k.FillBy(data.esclavodetalle);

                }
                catch (Exception algo)
                {
                }
               
                  DataSet1TableAdapters.temesclavoTableAdapter l = new DataSet1TableAdapters.temesclavoTableAdapter();
                  
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
