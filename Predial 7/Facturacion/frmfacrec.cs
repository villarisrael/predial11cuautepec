using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Predial10;
using Predial10.Resources.CODE;

namespace Predial10.Facturacion
{
    public partial class frmfacrec : DevComponents.DotNetBar.Office2007Form
    {
        DataTable tablausuario = new DataTable();
        Pago pago = new Pago();
        int cuantosusuarios = 0;
        ReportDocument reporte = new ReportDocument();
        public frmfacrec()
        {
            InitializeComponent();
        }

        private void frmfacrec_Load(object sender, EventArgs e)
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

        private void buttonX1_Click(object sender, EventArgs e)
        {
            
            buttonX1.Enabled = false;
            /*************************creando condicion y encabezado **********************************/
            StringBuilder filtro = new StringBuilder();
            StringBuilder filtropredios = new StringBuilder();
            StringBuilder filtrosql = new StringBuilder();
            StringBuilder encabezado = new StringBuilder();
            StringBuilder encabezado1 = new StringBuilder();
            bool masdeuno = false;
            bool masdeunpredio = false;

            if (chkcomunidad.Checked)
            {
                if (masdeuno)
                {
                    filtro.Append(" and ");
                    filtrosql.Append(" and ");
                }
                else
                {
                    masdeuno = true;
                }
                filtro.Append("{vusuario.comunidad}='" + cmbComunidad.Text + "' ");
                encabezado.Append("COMUNIDAD: " + cmbComunidad.Text + " ");
                filtrosql.Append("vusuario.comunidad='" + cmbComunidad.Text + "' ");
            }

            if (chkcolonia.Checked)
            {
                if (masdeuno)
                {
                    filtro.Append(" and ");
                    filtrosql.Append(" and ");
                }
                else
                {
                    masdeuno = true;
                }
                filtro.Append("{vusuario.colonia}='" + cmbColonia.Text + "' ");
                encabezado.Append("COLONIA: " + cmbColonia.Text + " ");
                filtrosql.Append("vusuario.colonia='" + cmbColonia.Text + "' )");
            }

            if (chkCalle.Checked)
            {
                if (masdeuno)
                {
                    filtro.Append(" and ");
                    filtrosql.Append(" and ");
                }
                else
                {
                    masdeuno = true;
                }
                filtro.Append("{vusuario.Calle}='" + cmbCalle.Text + "' ");
                encabezado.Append("CALLE: " + cmbCalle.Text + " ");
                filtrosql.Append("vusuario.Calle='" + cmbCalle.Text + "' )");
            }

            if (chkTarifa.Checked)
            {
                if (masdeuno)
                {
                    filtro.Append(" and ");
                    filtrosql.Append(" and ");
                }
                else
                {
                    masdeuno = true;
                }
                filtro.Append("{vusuario.Tarifa}='" + cmbTarifas.Text + "' ");
                encabezado.Append("TARIFA: " + cmbTarifas.Text + " ");
                filtrosql.Append("vusuario.Tarifa='" + cmbTarifas.Text + "' )");
            }

            if (dddinero.Value > 0)
            {
                if (masdeuno)
                {
                    filtro.Append(" and ");
                    filtrosql.Append(" and ");
                }
                else
                {
                    masdeuno = true;
                }
                filtro.Append("{vusuario.Totaladeudo_p}>=" + dddinero.Value + " ");
                encabezado1.Append("ADEUDOS >= " + String.Format(new AcctNumberFormat(), "{0:C2}", dddinero.Value) + " ");
                filtrosql.Append("vusuario.Totaladeudo_p>=" + dddinero.Value + " ");
            }

            if (ddperiodos.Value > 0)
            {
                if (masdeuno)
                {
                    filtro.Append(" and ");
                    filtrosql.Append(" and ");
                }
                else
                {
                    masdeuno = true;
                }
                filtro.Append("{vusuario.periodos_p}>=" + ddperiodos.Value + " ");
                encabezado1.Append("PERIODOS ANUALES >= " + ddperiodos.Value + " ");
                filtrosql.Append("vusuario.periodos_p>=" + ddperiodos.Value + " ");
            }


            if (IIMANZANA.Value > 0)
            {
                if (masdeuno)
                {
                    filtro.Append(" and ");
                    filtrosql.Append(" and ");
                }
                else
                {
                    masdeuno = true;
                }
                filtro.Append("{vusuario.manzana}='" + IIMANZANA.Value + "' ");
                encabezado1.Append("MANZANA " + IIMANZANA.Value + " ");
                filtrosql.Append("vusuario.manzana='" + IIMANZANA.Value + "' ");
            }


            /* agrupo los predios en un or */

            if (chkEjidales.Checked && chkUrbanos.Checked && chkEjidales.Checked)
            {
                filtropredios.Append(" "); // si estan activados los tres tipos no genera filtro
                filtrosql.Append(" ");
            }
            else if (chkEjidales.Checked || chkUrbanos.Checked || chkEjidales.Checked)
            {
                if (masdeuno)
                {
                    filtro.Append(" and ");
                    filtrosql.Append(" and ");
                }
                else
                {
                    masdeuno = true;
                }

                filtropredios.Append("("); // genera un filtro de la forma: ( condicion or condicion )
                filtrosql.Append("(");
                if (chkUrbanos.Checked)
                {
                    if (masdeunpredio)
                    {
                        filtropredios.Append(" or ");
                        filtrosql.Append(" or ");
                    }
                    else
                    {
                        masdeunpredio = true;
                    }
                    filtropredios.Append("{vusuario.Tipopredio}='URBANO' ");
                    filtrosql.Append("vusuario.Tipopredio='URBANO' ");
                    encabezado1.Append(" URBANOS ");
                }

                if (chkEjidales.Checked)
                {
                    if (masdeunpredio)
                    {
                        filtropredios.Append(" or ");
                        filtrosql.Append(" or ");
                    }
                    else
                    {
                        masdeunpredio = true;
                    }
                    filtropredios.Append("{vusuario.Tipopredio}='EJIDAL' ");
                    filtrosql.Append("vusuario.Tipopredio='EJIDAL' ");
                    encabezado1.Append(" EJIDALES ");
                }

                if (chkRusticos.Checked)
                {
                    if (masdeunpredio)
                    {
                        filtropredios.Append(" or ");
                        filtrosql.Append(" or ");
                    }
                    else
                    {
                        masdeunpredio = true;
                    }
                    filtropredios.Append("{vusuario.Tipopredio}='RUSTICO' ");
                    filtrosql.Append("vusuario.Tipopredio='RUSTICO' ");
                    encabezado1.Append(" RUSTICOS ");
                }

                filtropredios.Append(")");

                filtrosql.Append(")");
            }

            filtro.Append(filtropredios.ToString());

            /************************** calculando cuantos son *************************************************/
            Conexion_a_BD.Conectar();
            if ( filtrosql.ToString() != " ")
            {
                tablausuario = Conexion_a_BD.Consultasql("count(catastral) as conteo  ", "Vusuario where " + filtrosql.ToString());
            }
            else
            {
                tablausuario = Conexion_a_BD.Consultasql("count(catastral) as conteo  ", "Vusuario");
            }
 
            var results3 = from myRow in tablausuario.AsEnumerable() select myRow;
            try
            {
                DataView view3 = results3.AsDataView();
                cuantosusuarios = Convert.ToInt32(view3[0]["conteo"].ToString());
                lblusuarios.Text = view3[0]["conteo"].ToString();

                progressBarX1.Maximum = cuantosusuarios;

                Conexion_a_BD.insertar("Delete from tmpfacrec");
            }


            catch (Exception x)
            {
            }
            Conexion_a_BD.Desconectar();
            /********************************* generando lo facturado ************************************/

            Conexion_a_BD.Conectar();
            if (masdeuno ==true )
            {
            tablausuario = Conexion_a_BD.Consultasql("*", "usuario,tarifas,vusuario where usuario.id_tarifa_p =Tarifas.idTarifas and usuario.clave_predial=vusuario.catastral and " + filtrosql.ToString ());
            }
            else{
                tablausuario = Conexion_a_BD.Consultasql("*", "usuario,tarifas,vusuario where usuario.id_tarifa_p =Tarifas.idTarifas and vusuario.catastral=usuario.clave_predial ") ;
            }
         //   Conexion_a_BD.Desconectar();

            var results = from myRow in tablausuario.AsEnumerable() select myRow;
            try
            {
                
                DataView view = results.AsDataView();
                DateTime fechafinal = DateTime.Now;
                for (int i = 0; i < cuantosusuarios; i++)
                {
                    
                    try
                    {
                        DateTime fechainicio;

                        long cuenta = Convert.ToInt64(view[i]["clave"].ToString());
                        fechainicio = Convert.ToDateTime("31/12/" + (DateTime.Now.Year - 5).ToString());

                        pago.fecha = fechainicio;
                        pago.fechadehoy = DateTime.Now;
                        pago.porcentaje = Convert.ToDecimal(view[i]["porcentajebase"].ToString());
                        pago.porcentajederecargo = Convert.ToDecimal(view[i]["porcentajederecargo"].ToString());
                        pago.valor = Convert.ToDecimal(view[i]["Valor_fiscal_P"].ToString());
                        pago.tarifa = Convert.ToInt32(view[i]["idTarifas"].ToString());
                        pago.Porcentajeimpuesto = Convert.ToDecimal(view[i]["porcentajecobro"].ToString());
                        pago.Periodosdescontados = 0;
                        pago.Porcentaje_de_descuento = Convert.ToDecimal(0);
                        // pago.porcentajederecargo = porcrecargo;

                        pago.tipo = Predial10.Resources.CODE.Pago.tipopago.anual;


                        pago.calcula();

                        decimal adeudo = pago.Impuesto + pago.Rezago;
                        decimal recargo = pago.Recargo;
                        long periodos = pago.periodosCount;
                        decimal total = adeudo + recargo;
                        try
                        {
                            for (int ciclo = 0; ciclo <= pago.periodosCount - 1; ciclo++)
                            {
                               // Conexion_a_BD.Conectar();
                                Conexion_a_BD.insertar("insert into tmpfacrec set facturado=" + pago.periodos[ciclo].Impuestobruto + ", catastral='" + cuenta + "', periodo ='" + pago.periodos[ciclo].periodo + "', idTarifa=" + pago.tarifa );
                                //Conexion_a_BD.Desconectar();
                            }
                        }
                        catch (Exception x)
                        {
                            MessageBox.Show(x.Message);
                        }
                    }
                    catch (Exception y)
                    {
                        MessageBox.Show(y.Message);
                    }

                    progressBarX1.Text = (i / cuantosusuarios).ToString();
                    progressBarX1.Value = i;

                }
            }

            catch (Exception x)
            {
                MessageBox.Show(x.Message);
                buttonX1.Enabled = true;
            }

          
            /********************************* generando lo adedudado ************************************/
            Conexion_a_BD.Desconectar ();
            Conexion_a_BD.Conectar();
            if (masdeuno == true)
            {
                tablausuario = Conexion_a_BD.Consultasql("*", "usuario,tarifas,vusuario where usuario.id_tarifa_p =Tarifas.idTarifas and usuario.clave_predial=vusuario.catastral and " + filtrosql.ToString());
            }
            else
            {
                tablausuario = Conexion_a_BD.Consultasql("*", "usuario,tarifas,vusuario where usuario.id_tarifa_p =Tarifas.idTarifas and vusuario.catastral=usuario.clave_predial ");
            }
            Conexion_a_BD.Desconectar();

            var resultsdos = from myRow in tablausuario.AsEnumerable() select myRow;
            try
            {
                Conexion_a_BD.Conectar();
                DataView view2 = resultsdos.AsDataView();
                DateTime fechafinal2 = DateTime.Now;
                for (int i = 0; i < cuantosusuarios; i++)
                {
                    try
                    {
                        DateTime fechainicio;

                        long cuenta = Convert.ToInt64(view2[i]["clave"].ToString());
                        fechainicio = Convert.ToDateTime(view2[i]["UltimoPagoP"].ToString());
                        pago.fecha = fechainicio;
                        pago.fechadehoy = fechafinal2;
                        pago.porcentaje = Convert.ToDecimal(view2[i]["porcentajebase"].ToString());
                        pago.porcentajederecargo = Convert.ToDecimal(view2[i]["porcentajederecargo"].ToString());
                        pago.valor = Convert.ToDecimal(view2[i]["Valor_fiscal_P"].ToString());
                        pago.tarifa = Convert.ToInt32(view2[i]["idTarifas"].ToString());
                        pago.Porcentajeimpuesto = Convert.ToDecimal(view2[i]["porcentajecobro"].ToString());
                        pago.Periodosdescontados = 0;
                        pago.Porcentaje_de_descuento = Convert.ToDecimal(0);
                        // pago.porcentajederecargo = porcrecargo;

                        pago.tipo = Predial10.Resources.CODE.Pago.tipopago.anual;


                        pago.calcula();

                        decimal adeudo = pago.Impuesto + pago.Rezago;
                        decimal recargo = pago.Recargo;
                        long periodos = pago.periodosCount;
                        decimal total = adeudo + recargo;
                        try
                        {
                            for (int ciclo = 0; ciclo <= pago.periodosCount - 1; ciclo++)
                            {
                                Conexion_a_BD.insertar("update tmpfacrec set adeudado=" + pago.periodos[ciclo].Impuestobruto + " where catastral='" + cuenta + "' and periodo ='" + pago.periodos[ciclo].periodo + "'");
                            }
                        }
                        catch (Exception x)
                        {
                            MessageBox.Show(x.Message);
                        }
                    }
                    catch (Exception y)
                    {
                        MessageBox.Show(y.Message);
                    }

                    progressBarX1.Text = (i / cuantosusuarios).ToString();
                    progressBarX1.Value = i;
                  
                }
               // MessageBox.Show("termine");

                Conexion_a_BD.Desconectar();
               buttonX1.Enabled = true ;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
               buttonX1.Enabled = true ;
            }
            /////////////////////////////////////////////



            DataSet1 data = new DataSet1();
            data.EnforceConstraints = false;
            DataSet1TableAdapters.empresaTableAdapter xa = new DataSet1TableAdapters.empresaTableAdapter();
            xa.Fill(data.empresa);
            DataSet1TableAdapters.tmpfacrecTableAdapter  ja = new DataSet1TableAdapters.tmpfacrecTableAdapter ();

            try
            {
                ja.Fill(data.temfacrec );

            }
            catch (Exception algo)
            {
                MessageBox.Show(algo.Message);
                buttonX1.Enabled = true;
            }
            DataSet1TableAdapters.tarifasTableAdapter  ta = new DataSet1TableAdapters.tarifasTableAdapter ();

            try
            {
                ta.Fill(data.tarifas );

            }

            catch (Exception algo)
            {
            }
            reporte.Load("./reportes/facrec.rpt");
            reporte.SetDataSource(data);
           // reporte.RecordSelectionFormula = filtro.ToString();
            reporte.DataDefinition.FormulaFields["ENCABEZADO"].Text = "'" + encabezado.ToString() + "'";
            reporte.DataDefinition.FormulaFields["ENCABEZADO1"].Text = "'" + encabezado1.ToString() + "'";
            crystalReportViewer1.ReportSource = reporte;
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
