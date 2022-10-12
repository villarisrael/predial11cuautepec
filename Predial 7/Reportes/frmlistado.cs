using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Predial10;
using Predial10.Resources.CODE;

namespace Predial10.PadronUsuarios
{
    public partial class frmlistado :  DevComponents.DotNetBar.Office2007Form
    {
        ReportDocument reporte = new ReportDocument();
        public frmlistado()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            /*************************creando condicion y encabezado **********************************/
            StringBuilder filtro = new StringBuilder();
            StringBuilder filtropredios = new StringBuilder();
            StringBuilder encabezado = new StringBuilder();
            StringBuilder encabezado1 = new StringBuilder();
            bool masdeuno = false;
            bool masdeunpredio = false;

            if (chkcomunidad.Checked)
            {
                if (masdeuno)
                {
                    filtro.Append(" and ");
                }
                else
                {
                    masdeuno = true;
                }
                filtro.Append("{vusuario.comunidad}='" + cmbComunidad.Text + "' ");
                encabezado.Append ("COMUNIDAD: " + cmbComunidad.Text + " ");
             }

            if (chkcolonia.Checked )
            {
                if (masdeuno)
                {
                    filtro.Append(" and ");
                }
                else
                {
                    masdeuno = true;
                }
                filtro.Append("{vusuario.colonia}='" + cmbColonia.Text + "' ");
                encabezado.Append("COLONIA: " + cmbColonia.Text + " ");
            }

            if (chkCalle.Checked)
            {
                if (masdeuno)
                {
                    filtro.Append(" and ");
                }
                else
                {
                    masdeuno = true;
                }
                filtro.Append("{vusuario.Calle}='" + cmbCalle.Text + "' ");
                encabezado.Append("CALLE: " + cmbCalle.Text + " ");
            }

            if (chkTarifa.Checked)
            {
                if (masdeuno)
                {
                    filtro.Append(" and ");
                }
                else
                {
                    masdeuno = true;
                }
                filtro.Append("{vusuario.Tarifa}='" + cmbTarifas.Text + "' ");
                encabezado.Append("TARIFA: " + cmbTarifas.Text + " ");
            }

            if (dddinero.Value >0)
            {
                if (masdeuno)
                {
                    filtro.Append(" and ");
                }
                else
                {
                    masdeuno = true;
                }
                filtro.Append("{vusuario.Totaladeudo_p}>=" + dddinero.Value  + " ");
                encabezado1.Append("ADEUDOS >= " + String.Format(new AcctNumberFormat(), "{0:C2}", dddinero.Value) + " ");
            }

            if (ddperiodos.Value > 0)
            {
                if (masdeuno)
                {
                    filtro.Append(" and ");
                }
                else
                {
                    masdeuno = true;
                }
                filtro.Append("{vusuario.periodos_p}>=" + ddperiodos.Value + " ");
                encabezado1.Append("PERIODOS ANUALES >= " + ddperiodos.Value + " ");
            }


            if (IIMANZANA.Value  > 0)
            {
                if (masdeuno)
                {
                    filtro.Append(" and ");
                }
                else
                {
                    masdeuno = true;
                }
                filtro.Append("{vusuario.manzana}='" + IIMANZANA.Value + "' ");
                encabezado1.Append("MANZANA " + IIMANZANA.Value + " ");
            }


            /* agrupo los predios en un or */

            if (chkEjidales.Checked && chkUrbanos.Checked && chkEjidales.Checked)
            {
                filtropredios.Append(" "); // si estan activados los tres tipos no genera filtro
            }
            else if (chkEjidales.Checked || chkUrbanos.Checked || chkEjidales.Checked)
            {
                if (masdeuno)      
                {
                    filtro.Append(" and ");
                }
                else
                {
                    masdeuno = true;
                }

                filtropredios.Append("("); // genera un filtro de la forma: ( condicion or condicion )
                if (chkUrbanos.Checked)
                {
                    if (masdeunpredio)
                    {
                        filtropredios.Append(" or ");
                    }
                    else
                    {
                        masdeunpredio = true;
                    }
                    filtropredios.Append("{vusuario.Tipopredio}='URBANO' ");
                    encabezado1.Append(" URBANOS ");
                }

                if (chkEjidales.Checked)
                {
                    if (masdeunpredio)
                    {
                        filtropredios.Append(" or ");
                    }
                    else
                    {
                        masdeunpredio = true;
                    }
                    filtropredios.Append("{vusuario.Tipopredio}='EJIDAL' ");
                    encabezado1.Append(" EJIDALES ");
                }

                if (chkRusticos.Checked)
                {
                    if (masdeunpredio)
                    {
                        filtropredios.Append(" or ");
                    }
                    else
                    {
                        masdeunpredio = true;
                    }
                    filtropredios.Append("{vusuario.Tipopredio}='RUSTICO' ");
                    encabezado1.Append(" RUSTICOS ");
                }
                
                filtropredios.Append(")");
            }

            filtro.Append(filtropredios.ToString());




            predialchicoDataSet  data = new predialchicoDataSet  ();
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
            try
            {
                reporte.Load(Application.StartupPath + "\\reportes\\listado.rpt");
                reporte.SetDataSource(data);
                reporte.RecordSelectionFormula = filtro.ToString();
                reporte.DataDefinition.FormulaFields["ENCABEZADO"].Text = "'" + encabezado.ToString() + "'";
                reporte.DataDefinition.FormulaFields["ENCABEZADO1"].Text = "'" + encabezado1.ToString() + "'";

                crystalReportViewer1.ReportSource = reporte;
            }
            catch(Exception err)
            { }
        }

        private void frmlistado_Load(object sender, EventArgs e)
        {
            Conexion_a_BD.Conectar();
            cmbTarifas.ValueMember = "idTarifas";
            cmbTarifas.DisplayMember = "Descripcion";
            cmbTarifas.DataSource = Conexion_a_BD.Consultasql("idTarifas, Descripcion", "tarifas", "Descripcion");
            Conexion_a_BD.Desconectar();

            Conexion_a_BD.Conectar();
            cmbComunidad.ValueMember = "Id_comunidad";
            cmbComunidad.DisplayMember = "Comunidad";
            cmbComunidad.DataSource = Conexion_a_BD.Consultasql("Id_comunidad ,Comunidad", "comunidades", "Comunidad");
            Conexion_a_BD.Desconectar();

            Conexion_a_BD.Conectar();
            cmbColonia.ValueMember = "id_colonia";
            cmbColonia.DisplayMember = "Colonia";
            cmbColonia.DataSource = Conexion_a_BD.Consultasql(" id_colonia, Colonia", "Colonia", "Colonia");
            Conexion_a_BD.Desconectar();

            Conexion_a_BD.Conectar();
            cmbCalle.ValueMember = "ID_CALLE";
            cmbCalle.DisplayMember = "NOMBRE";
            cmbCalle.DataSource = Conexion_a_BD.Consultasql("ID_CALLE, NOMBRE", "calles", "NOMBRE");
            Conexion_a_BD.Desconectar();

        }

       
    }
}
