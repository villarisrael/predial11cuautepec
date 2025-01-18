using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Predial10.Resources.CODE;
using DevComponents.AdvTree;
using Predial10.DataSet1TableAdapters;

namespace Predial10
{
    public partial class frmcaja : Form
    {
        public long facturado = 0;
        Resources.CODE.imprimirnet imp2;
        Conexion_a_BD basem = new Conexion_a_BD();
        DataTable tablatarifa = new DataTable();
        DataTable tablaempresa = new DataTable();
        DataTable TBL_Consulta = new DataTable();
        DataTable TBL_Consulta2 = new DataTable();
        DataTable TBL_Consulta3 = new DataTable();
        DataTable TBL_Consultadetalle = new DataTable();
        DataSet1 predialchicoDataSet = new DataSet1();


         Pago pago = new Pago();
       public string OFICINA = "";
       public string CAJA = "";
        string TCAJA = "";
       public string serie = "";
        double porcenero = 0;
        double porcfebrero = 0;
        double porcmarzo = 0;
        decimal porcrecargo;
        decimal porcINSEN;
        decimal porcJUBI;
        public decimal descuento = 0;
        public  decimal total = 0;
        string tipo = "";
        string Comunidad = "";
       
        double porcdedescuentorecargos = 0;
        decimal descuentorecargos = 0;
        decimal descuentoimpuesto =0;
        public string usuariosis = "";
        ArchivoSql archivox = new ArchivoSql();
        public Int32 ultimofolio = 0;

        public frmcaja()
        {
            InitializeComponent();
            imp2 = new Resources.CODE.imprimirnet();
            lblImpresora.Text = imp2.prtSettings.PrinterName;
          
        }

        private void frmcaja_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet1.vusuario' Puede moverla o quitarla según sea necesario.
         //   this.vusuarioTableAdapter.Fill(this.dataSet1.vusuario);
            // TODO: This line of code loads data into the 'predialchicoDataSet.detalle' table. You can move, or remove it, as needed.

            Conexion_a_BD.Conectar();

            TBL_Consulta3 = Conexion_a_BD.Consultasql("NOMBRE, DESCRIPCION, Maquina", "croape INNER JOIN oficinas on oficinas.COD_OFI= croape.COD_OFI INNER JOIN cajas on cajas.ID_CAJA= croape.CAJA WHERE MAQUINA= '" + System.Environment.MachineName.ToString() + "' AND FEC_APE='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
            Conexion_a_BD.Desconectar();
            var resultados= from myRow in TBL_Consulta3.AsEnumerable() select myRow;
            try
            {
                DataView view = resultados.AsDataView();

                lblCaja.Text = view[0]["DESCRIPCION"].ToString();
                lblMaquina.Text = view[0]["Maquina"].ToString();
                lblOficina.Text = view[0]["NOMBRE"].ToString();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

                dateTimeInput1.Text = DateTime.Now.ToString();
                Conexion_a_BD.Conectar();
                cmbTarifas.ValueMember = "idTarifas";
                cmbTarifas.DisplayMember = "Descripcion";

                tablatarifa = Conexion_a_BD.Consultasql("idTarifas, Descripcion,porcentajebase,porcentajecobro,porcentajederecargo,tipo", "tarifas", "Descripcion");
                cmbTarifas.DataSource = tablatarifa;
                cmbTarifas.SelectedIndex = -1;
                Conexion_a_BD.Desconectar();

                Conexion_a_BD.Conectar();
                tablaempresa = Conexion_a_BD.Consultasql("*", "empresa", "CODEMP");
                Conexion_a_BD.Desconectar();

                Conexion_a_BD.Conectar();
                cmbFormaPago.ValueMember = "CCODPAGO";
                cmbFormaPago.DisplayMember = "CDESPAGO";
                cmbFormaPago.DataSource = Conexion_a_BD.Consultasql("CCODPAGO, CDESPAGO", "fpago", "CDESPAGO");
                cmbFormaPago.SelectedIndex  = 1;
                Conexion_a_BD.Desconectar();


                var results = from myRow in tablaempresa.AsEnumerable() select myRow;
                try
                {
                    DataView view = results.AsDataView();
                    porcrecargo = Convert.ToDecimal(view[0]["precargopredial"].ToString());
                    porcINSEN = Convert.ToDecimal(view[0]["pdesctoinsen"].ToString());
                    porcJUBI = Convert.ToDecimal(view[0]["pdesctopen"].ToString());
                    porcenero = Convert.ToDouble (view[0]["pdesctoene"].ToString());
                    porcfebrero = Convert.ToDouble (view[0]["pdesctofeb"].ToString());
                    porcmarzo = Convert.ToDouble (view[0]["pdesctomar"].ToString());

                    if (DateTime.Now.Month == 1)
                    {
                        DIporcentajuedescuento.Value =  porcenero;
                        IIperiodosdescontados.Value  = 1;
                    }
                    if (DateTime.Now.Month == 2)
                    {
                        DIporcentajuedescuento.Value = porcfebrero ;
                        IIperiodosdescontados.Value  = 1;
                    }
                    if (DateTime.Now.Month == 3)
                    {
                        DIporcentajuedescuento.Value = porcmarzo ;
                        IIperiodosdescontados.Value = 1;
                    }

                }
                catch (Exception x)
                {
                   
                }


                Conexion_a_BD.Conectar();
                TBL_Consulta = Conexion_a_BD.Consultasql("COD_OFI ,CAJA,TCAJA,SERIE", " croape WHERE MAQUINA= '" + System.Environment.MachineName.ToString() + "' AND FEC_APE='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
                Conexion_a_BD.Desconectar();
                var resultado = from myRow in TBL_Consulta.AsEnumerable() select myRow;
                try
                {
                    DataView view = resultado.AsDataView();
                    OFICINA = view[0]["COD_OFI"].ToString();
                    CAJA = view[0]["CAJA"].ToString();
                    TCAJA = view[0]["TCAJA"].ToString();
                    serie = view[0]["SERIE"].ToString();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ultimofolioimpreso();
        }

        private void caja_KeyDown(Object sender, KeyEventArgs e)
        {
            Keys keyascii = e.KeyData;
            switch (keyascii)
            {
                case Keys.Enter:
                    SendKeys.Send("{TAB}");
                    break;
            }
        }

        bool bandera = false;
        bool error = false;
        public  void btnbuscar1_Click(object sender, EventArgs e)
        {       
            try
            {
                if (bandera == false)
                {
                    bandera = true;
                    btnbuscar1_Click(sender, e);                   
                }

                string clave = txtclave.Text;
                DataSet1TableAdapters.vusuarioTableAdapter VTA = new vusuarioTableAdapter();
                VTA.FillBycuenta(this.predialchicoDataSet.vusuario, clave );

                try
                {

                    if (this.predialchicoDataSet.vusuario[0].Estado_p == "INACTIVO")
                    {
                        MessageBox.Show("La clave predial se encuentra dada de baja");
                        return;
                    }
                    txtnombre.Text = this.predialchicoDataSet.vusuario[0].Nombre;
                    txtcalle.Text = this.predialchicoDataSet.vusuario[0].domicilio ;
                    txtnumext.Text = this.predialchicoDataSet.vusuario[0].numext;
                    txtcolonia.Text = this.predialchicoDataSet.vusuario[0].numint;
                    txtcomunidad.Text = this.predialchicoDataSet.vusuario[0].comunidad;
                    Comunidad = txtcomunidad.Text;
                    divalorfiscal.Value = this.predialchicoDataSet.vusuario[0].valor_fiscal;
                    DTinicio.Value = this.predialchicoDataSet.vusuario[0].UltimoPagop;
                    cmbTarifas.SelectedValue = this.predialchicoDataSet.vusuario[0].idTarifa;


                    //Paso los datos a las variables de la caja para poder pasarlos a la ventana de Datos Fiscales

                    caja.VariablesCajas.Cuenta = txtclave.Text;
                    caja.VariablesCajas.Nombre = txtnombre.Text;
                    caja.VariablesCajas.Calle = txtcalle.Text;
                    caja.VariablesCajas.NoExt = txtnumext.Text;
                    caja.VariablesCajas.Colonia = txtcolonia.Text;
                    caja.VariablesCajas.Comunidad = txtcomunidad.Text;

                    BTNCALCULAR_Click(sender, EventArgs.Empty);
                    btnGuardar.Enabled = true;
                    
                }
                catch (Exception excepciond)
                {
                    MessageBox.Show("No se encuentra esa cuenta, verifique de nuevo.", "Informaci n", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    error = true;
                }
                
            }
            catch (Exception excepcion)
            {
               // MessageBox.Show(excepcion.Message,"Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            btnImprimir.Enabled = false;
           // btnGuardar.Enabled = false;
            btnDatosFiscales.Enabled = false;
        }

        
        private void cmbTarifas_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            var results = from myRow in tablatarifa.AsEnumerable()
                          where myRow.Field<int>("idTarifas") == Convert.ToInt16(cmbTarifas.SelectedValue)
                          select myRow;
            
            try
            {
                DataView view = results.AsDataView();
                DIporcentaje.Value = Convert.ToDouble(view[0]["porcentajebase"].ToString());
                DIimpuesto.Value = Convert.ToDouble(view[0]["porcentajecobro"].ToString());
                Direcargo.Value = Convert.ToDouble(view[0]["porcentajederecargo"].ToString());
                tipo = view[0]["tipo"].ToString();                
            }              
            catch (Exception x)
            {
                //MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void BTNCALCULAR_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (DTinicio.Text == "" && Dtfinal.Text == "" && divalorfiscal.Text=="")
                {
                    MessageBox.Show("Verifica que los campos no esten vacios valorfiscal y fechafinal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            //    lblImpuesto.Text = "0";
             //   lblRezago.Text = "0";

                validafechafinal();

                advdesgloze.Nodes.Clear();
                pago.fecha = DTinicio.Value;
                pago.fechadehoy = Dtfinal.Value;
                pago.porcentaje = Convert.ToDecimal(DIporcentaje.Value);
                pago.porcentajederecargo = Convert.ToDecimal(Direcargo.Value);
                pago.valor = Convert.ToDecimal(divalorfiscal.Value);
                pago.tarifa = Convert.ToInt32(cmbTarifas.SelectedValue);
                pago.Porcentajeimpuesto = Convert.ToDecimal(DIimpuesto.Value);
                pago.Periodosdescontados = IIperiodosdescontados.Value;
                pago.Porcentaje_de_descuento = Convert.ToDecimal(DIporcentajuedescuento.Value);
                // pago.porcentajederecargo = porcrecargo;

                if (chkanual.Checked) { pago.tipo = Predial10.Resources.CODE.Pago.tipopago.anual; }
                if (this.chkbimestral.Checked) { pago.tipo = Predial10.Resources.CODE.Pago.tipopago.bimestral; }


                Decimal minimo = 0;
                try
                {
                    Conexion_a_BD.Conectar();
                    TBL_Consulta = Conexion_a_BD.Consultasql("CNOMBRE, CADMINIS, PorcIVA, SALARIO, porctrasladodom, pdesctoene, pdesctofeb, pdesctomar, pminurb ,pminrus, pdesctopen, pdesctoinsen", "empresa");
                    Conexion_a_BD.Desconectar();
                    var resultado = from myRow in TBL_Consulta.AsEnumerable() select myRow;

                    DataView view = resultado.AsDataView();
                    switch (tipo)
                    {
                        case "URBANO":
                            {
                                minimo = Decimal.Parse(view[0]["SALARIO"].ToString()) * Decimal.Parse(view[0]["pminurb"].ToString());
                                break;
                            }
                        case "RUSTICO":
                            {
                                minimo = Decimal.Parse(view[0]["SALARIO"].ToString()) * Decimal.Parse(view[0]["pminrus"].ToString());
                                break;
                            }
                        case "EJIDAL":
                            {
                                minimo = 0 ;
                                break;
                            }
                    }


                }
                catch(Exception err)
                {

                }
                pago.minimo = minimo;
                    pago.calcula();
                descuento = pago.descuentototal;

                lblperiodo.Text = String.Format(new AcctNumberFormat(), "{0:C2}", pago.periodosCount.ToString());
               // lblRezago.Text = String.Format(new AcctNumberFormat(), "{0:C2}", pago.Rezago);
               // lblImpuesto.Text = String.Format(new AcctNumberFormat(), "{0:C2}", pago.Impuesto);

                int indice=0;
                DTpartidas1.Rows.Clear();
                string conceptorecibo = "IMPUESTO PREDIAL " + tipo + " " + Comunidad;
                string clavedetalle = "";
                string conceptodetalle = "";
                string unidadsat = "ACT";
                string clavesat = "93151512";
                if (pago.Impuesto > 0)
                {


                    DTpartidas1.Rows.Add();
                    Conexion_a_BD.Conectar();

                    TBL_Consultadetalle = Conexion_a_BD.Consultasql("Clave, Concepto,unidadsat,clavesat", "detalle where Concepto='" +conceptorecibo + "'");
                
                    var resultadodetalle = from myRow in TBL_Consultadetalle.AsEnumerable() select myRow;
                    try
                    {
                        DataView viewdetalle = resultadodetalle.AsDataView();
                        clavedetalle = viewdetalle[0][0].ToString();
                        conceptodetalle = viewdetalle[0][1].ToString();
                        unidadsat = viewdetalle[0][2].ToString();
                        clavesat = viewdetalle[0][3].ToString();
                    }



                        
                     catch (Exception x)
                        {
                            //MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    Conexion_a_BD.Desconectar();
                       

                         DTpartidas1.Rows[indice].Cells["Clave"].Value = clavedetalle;
                                                            
                    DTpartidas1.Rows[indice].Cells["Cantidad"].Value = 1;
                    DTpartidas1.Rows[indice].Cells["Concepto"].Value = conceptorecibo;
                    DTpartidas1.Rows[indice].Cells["Importe"].Value = Math.Round(pago.Impuesto,2) ;
                    DTpartidas1.Rows[indice].Cells["ImporteSD"].Value = Math.Round(pago.totalimpuestobruto,2);
                    DTpartidas1.Rows[indice].Cells["Unidadsat"].Value = unidadsat;
                    DTpartidas1.Rows[indice].Cells["Clavesat"].Value = clavesat;
                    indice++;
                }


                if (pago.Rezago  > 0)
                {
                    DTpartidas1.Rows.Add();
                    switch (tipo)
                    {
                        case "URBANO":
                            {
                                DTpartidas1.Rows[indice].Cells["Clave"].Value = Predial10.Properties.Settings.Default.Rezago_urbano;
                                break;
                            }
                        case "RUSTICO":
                            {
                                DTpartidas1.Rows[indice].Cells["Clave"].Value = Predial10.Properties.Settings.Default.Rezago_rustico;
                                break;
                            }
                        case "EJIDAL":
                            {
                                DTpartidas1.Rows[indice].Cells["Clave"].Value = Predial10.Properties.Settings.Default.Rezago_ejidal;
                                break;
                            }
                    }
                 
                    DTpartidas1.Rows[indice].Cells["Cantidad"].Value = 1;
                    DTpartidas1.Rows[indice].Cells["Concepto"].Value = "REZAGO IMPUESTO PREDIAL " + tipo;
                    DTpartidas1.Rows[indice].Cells["Importe"].Value = Math.Round(pago.Rezago,2) ;
                    DTpartidas1.Rows[indice].Cells["ImporteSD"].Value =Math.Round( pago.totalrezagobruto,2);
                    DTpartidas1.Rows[indice].Cells["Unidadsat"].Value = unidadsat;
                    DTpartidas1.Rows[indice].Cells["Clavesat"].Value = clavesat;
                    indice++;
                }

                if (chkperdonarrec.Checked == false)
                {
                  //  lblRecargo.Text = String.Format(new AcctNumberFormat(), "{0:C2}", pago.Recargo);
                    if (pago.Recargo  > 0)
                    {
                        /** verifico el descuento de recargos */

                        if (didescuentoreca.Value > 0)
                        {
                            porcdedescuentorecargos = didescuentoreca.Value ;
                            descuentorecargos =  pago.Recargo * Convert.ToDecimal(porcdedescuentorecargos / 100);
                            /* cambio el valor de los recargos */
                            pago.Recargo = pago.Recargo - descuentorecargos;
                        }


                      DTpartidas1.Rows.Add();
                      DTpartidas1.Rows[indice].Cells["Clave"].Value = Predial10.Properties.Settings.Default.Recargos;
                           
                        
                        DTpartidas1.Rows[indice].Cells["Cantidad"].Value = 1;
                        DTpartidas1.Rows[indice].Cells["Concepto"].Value = "RECARGOS IMPUESTO PREDIAL " ;
                        DTpartidas1.Rows[indice].Cells["Importe"].Value = Math.Round(pago.Recargo,2) ;
                        DTpartidas1.Rows[indice].Cells["ImporteSD"].Value = Math.Round( pago.Recargo,2);
                        DTpartidas1.Rows[indice].Cells["Unidadsat"].Value = unidadsat;
                        DTpartidas1.Rows[indice].Cells["Clavesat"].Value = clavesat;
                        indice++;
                    }
                    if (pago.RecargoRezagos > 0)
                    {
                        /** verifico el descuento de recargos */

                        if (didescuentoreca.Value > 0)
                        {
                            porcdedescuentorecargos = didescuentoreca.Value;
                            descuentorecargos = pago.RecargoRezagos * Convert.ToDecimal(porcdedescuentorecargos / 100);
                            /* cambio el valor de los recargos */
                            pago.RecargoRezagos = pago.RecargoRezagos - descuentorecargos;
                        }


                        DTpartidas1.Rows.Add();
                        DTpartidas1.Rows[indice].Cells["Clave"].Value = Predial10.Properties.Settings.Default.Recargosanteriores;


                        DTpartidas1.Rows[indice].Cells["Cantidad"].Value = 1;
                        DTpartidas1.Rows[indice].Cells["Concepto"].Value = "RECARGOS REZAGOS ";
                        DTpartidas1.Rows[indice].Cells["Importe"].Value = Math.Round(pago.RecargoRezagos, 2);
                        DTpartidas1.Rows[indice].Cells["ImporteSD"].Value = Math.Round(pago.RecargoRezagos, 2);
                        DTpartidas1.Rows[indice].Cells["Unidadsat"].Value = unidadsat;
                        DTpartidas1.Rows[indice].Cells["Clavesat"].Value = clavesat;
                        indice++;
                    }

                }
                else
                {
                    porcdedescuentorecargos = 100;
                    descuentorecargos = pago.Recargo;
                    pago.Recargo = 0;
                    //lblRecargo.Text = String.Format(new AcctNumberFormat(), "{0:C2}", pago.Recargo);
                }

                total = pago.Rezago + pago.Impuesto + pago.Recargo + pago.RecargoRezagos;
                lbltotal.Text = String.Format(new AcctNumberFormat(), "{0:C2}", total);

                
             clsconv let = new clsconv();
             lblletras.Text = let.enletras(total.ToString ());

                llenaadvTreedesgloze();

                btnGuardar.Enabled = true;
                btnDatosFiscales.Enabled = true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        public void llenaadvTreedesgloze()
        {
            descuentoimpuesto = 0;
            for (int i = 0; i <= pago.periodosCount - 1; i++)
            {
                Node nodo = new Node();
                nodo.Cells[0].Text = pago.periodos[i].periodo;
                Cell celda = new Cell();
                // a ade el impuesto
                DevComponents.DotNetBar.LabelX etiqueta = new DevComponents.DotNetBar.LabelX();
                etiqueta.Text = String.Format(new AcctNumberFormat(), "{0:C2}", pago.periodos[i].Impuestobruto);
                etiqueta.TextAlignment = StringAlignment.Far;
                celda.HostedControl = etiqueta;
                nodo.Cells.Add(celda);

                // a ade el impuesto bruto
                Cell celda1 = new Cell();
                DevComponents.DotNetBar.LabelX etiqueta1 = new DevComponents.DotNetBar.LabelX();
                etiqueta1.Text = String.Format(new AcctNumberFormat(), "{0:C2}", pago.periodos[i].ImpuestoNeto);
                etiqueta1.TextAlignment = StringAlignment.Far;
                celda1.HostedControl = etiqueta1;
                nodo.Cells.Add(celda1);

                // a ade el descuento al advtree

                Cell celda2 = new Cell();
                DevComponents.DotNetBar.LabelX etiqueta2 = new DevComponents.DotNetBar.LabelX();
                etiqueta2.Text = String.Format(new AcctNumberFormat(), "{0:0%}", (pago.periodos[i].porcdedescuento / 100));
                etiqueta2.TextAlignment = StringAlignment.Far;
                celda2.HostedControl = etiqueta2;
                nodo.Cells.Add(celda2);

                // a ade el descuento en dinero
                 descuentoimpuesto += pago.periodos[i].descuento;
                Cell celda3 = new Cell();
                DevComponents.DotNetBar.LabelX etiqueta3 = new DevComponents.DotNetBar.LabelX();
                etiqueta3.Text = String.Format(new AcctNumberFormat(), "{0:C2}", pago.periodos[i].descuento);
                etiqueta3.TextAlignment = StringAlignment.Far;
                celda3.HostedControl = etiqueta3;
                nodo.Cells.Add(celda3);


                // A ADE el tipo

                Cell celda4 = new Cell();
                DevComponents.DotNetBar.LabelX etiqueta4 = new DevComponents.DotNetBar.LabelX();
                switch (pago.periodos[i].Tipo)
                {
                    case clsperiodo.tipoimpuesto.Impuesto:
                        etiqueta4.BackColor = Color.Lime;
                        etiqueta4.Text = "Periodo Actual";
                        break;
                    case clsperiodo.tipoimpuesto.Rezago:
                        etiqueta4.BackColor = Color.Gainsboro;
                        etiqueta4.Text = "Periodo Rezagado";
                        break;
                }

                etiqueta4.TextAlignment = StringAlignment.Far;
                celda4.HostedControl = etiqueta4;
                nodo.Cells.Add(celda4);
                // a ade el recargo

                Cell celdarecargo = new Cell();
                DevComponents.DotNetBar.LabelX etiquetarecargo = new DevComponents.DotNetBar.LabelX();
                etiquetarecargo.Text = String.Format(new AcctNumberFormat(), "{0:C2}", pago.periodos[i].Recargo);
                etiquetarecargo.TextAlignment = StringAlignment.Far;
                celdarecargo.HostedControl = etiquetarecargo;
                nodo.Cells.Add(celdarecargo);

                // a ade el acumulado
                Cell celda5 = new Cell();
                DevComponents.DotNetBar.LabelX etiqueta5 = new DevComponents.DotNetBar.LabelX();
                etiqueta5.Text = String.Format(new AcctNumberFormat(), "{0:C2}", pago.periodos[i].Acumulado);
                etiqueta5.TextAlignment = StringAlignment.Far;
                celda5.HostedControl = etiqueta5;
                nodo.Cells.Add(celda5);

                advdesgloze.Nodes.Add(nodo);

            }
        }


         public void validafechafinal()
         {
             int ano = Dtfinal.Value.Year;
             if (ano > DateTime.Now.Year)
             {
                 ano = DateTime.Now.Year;
             }
             int mes = this.Dtfinal.Value.Month;

             switch (mes)
             {
                 case 1:
                     {
                         mes = 2;
                         break;
                     }
                 case 3:
                     {
                         mes = 4;
                         break;
                     }
                 case 5:
                     {
                         mes = 6;
                         break;
                     }
                 case 7:
                     {
                         mes = 8;
                         break;
                     }
                 case 9:
                     {
                         mes = 10;
                         break;
                     }
                 case 11:
                     {
                         mes = 12;
                         break;
                     }

             }
             string cadena = ano.ToString() + "/" + mes.ToString() + "/28";
             Dtfinal.Value = DateTime.Parse(cadena);
                         

             if (chkanual.Checked)
             {
                 ano = Dtfinal.Value.Year;


                 mes = 12;
                 cadena = ano.ToString() + "/" + mes.ToString() + "/31";
                 Dtfinal.Value = DateTime.Parse(cadena);
                 
                 int anoini = DTinicio.Value.Year;
               
                 int mesini = 12;
                 int diaini =31;
                 string cadena1= anoini.ToString () + "/" + mesini.ToString () +"/" + diaini.ToString();

                 DTinicio.Value  = DateTime.Parse(cadena1);
             }
         }
        

         private void btnLimpiar_Click(object sender, EventArgs e)
         {
             limpiar();
             btnGuardar.Enabled = false;
             BTNCALCULAR.Enabled = false;
             btnImprimir.Enabled = false;
             btnDatosFiscales.Enabled = false;
         }


         private void limpiar()
         {
             txtclave.Text = "";
             txtnombre.Text = "";
             txtcalle.Text = "";
             txtnumext.Text = "";
             txtcolonia.Text = "";
             txtcomunidad.Text = "";
             divalorfiscal.Value = 0;
             DTinicio.Text = "";
             Dtfinal.Text = "";
             DTpartidas1.Rows.Clear();
             lblletras.Text = "0 Pesos 00/100 MN";
             total = 0;
             lbltotal.Text = "0.00";
             txtclave.Focus();
             chkperdonarrec.Checked = false;
             chkpen.Checked = false;
             chkinsen.Checked = false;
             if (DateTime.Now.Month == 1)
             {
                 DIporcentajuedescuento.Value = porcenero;
                 IIperiodosdescontados.Value = 1;
             }
             if (DateTime.Now.Month == 2)
             {
                 DIporcentajuedescuento.Value = porcfebrero;
                 IIperiodosdescontados.Value = 1;
             }
             if (DateTime.Now.Month == 3)
             {
                 DIporcentajuedescuento.Value = porcmarzo;
                 IIperiodosdescontados.Value = 1;
             }
         }

         private void btnNuevo_Click(object sender, EventArgs e)
         {
             limpiar();
             lblfolio.Text = "0";
             btnGuardar.Enabled = false;
             BTNCALCULAR.Enabled = false;
             btnImprimir.Enabled = false;
             btnDatosFiscales.Enabled = false;
         }

        public void btnGuardar_Click(object sender, EventArgs e)
         {
          
             if (total == 0)
             {
                 return;
             }
             
             if (txtclave.Text == "")
             {
                 MessageBox.Show("No has puesto una Clave");
                 return;
             }
             btnImprimir.Enabled = true;
             btnDatosFiscales.Enabled = true;
             DataSet1.recibomaestroRow registro = predialchicoDataSet.recibomaestro.NewrecibomaestroRow();

             registro.Nombre = txtnombre.Text;
             registro.Direccion1 = txtcalle.Text;
             registro.Direccion2 = txtcolonia.Text;
             registro.Ubicacion = txtcomunidad.Text;
             registro.serie = Conexion_a_BD.obtenercampo("select serie from cajas where cod_ofi='" + OFICINA + "' and id_caja='" + CAJA + "'");
             serie = registro.serie;
             //string serie = registro.serie;
             registro.fecha = DateTime.Now;
             registro.Subtotal = total;

             registro.IVA = 0;
             registro.Total = total;
             registro.idformapago  = cmbFormaPago.SelectedValue.ToString();
             registro.ccodofi = OFICINA;
             registro.caja = CAJA;
             registro.fecha_inicial = Convert.ToDateTime((DTinicio.Value.ToShortDateString() ));
             registro.fecha_final = Convert.ToDateTime((Dtfinal.Value.ToShortDateString()));
             registro.PorcDescuento  =Convert.ToDecimal(DIporcentajuedescuento.Value);
             registro.descuento = descuentoimpuesto ;
             registro.catastral = txtclave.Text;
             registro.porcdescuentorecargos = Convert.ToDecimal ( porcdedescuentorecargos) ;
             registro.descuentorecargos = descuentorecargos;
             registro.tipodescuento ="Ninguno";
             registro.valorfiscal = Convert.ToDecimal(divalorfiscal.Text);
             
             if (chkinsen.Checked)
             {
                 registro.tipodescuento ="INSEN";
             }
             if (chkpen.Checked )
             {
                 registro.tipodescuento ="PENSIONADO";
             }

            
             ultimofolio = ultimofolioimpreso() + 1;
             registro.folio = ultimofolio;

             DataSet1TableAdapters.recibomaestroTableAdapter x = new DataSet1TableAdapters.recibomaestroTableAdapter();

             try
             {

                 string visualizar = Conexion_a_BD.obtenercampo("select folio from recibomaestro where folio=" + registro.folio +" and serie ='" + registro.serie +"'");
                 if (visualizar == "")
                 {
                    // x.Insert1(registro.fecha, registro.folio, registro.Nombre, registro.Direccion1, registro.Direccion2, registro.Ubicacion, registro.Subtotal, registro.IVA, registro.Total, registro.serie, "A", registro.IDFORMAPAGO, registro.ccodofi, registro.caja, registro.fecha_inicial, registro.fecha_final, registro.porcdescuento, registro.descuento, registro.catastral);
                     string cadenainserta = "use predialchico;INSERT INTO recibomaestro (fecha, folio, Nombre, Direccion1, Direccion2, Ubicacion, Subtotal, IVA, Total, serie, Cancelado, idformapago, ccodofi, caja, fecha_inicial, fecha_final,porcdescuento,descuento,catastral,porcdescuentorecargos,descuentorecargos,tipodescuento,valorfiscal,usuariosis,facturado) VALUES ('" + unixdateformat(registro.fecha) + "'," + registro.folio + ",'" + registro.Nombre + "','" + registro.Direccion1 + "','" + registro.Direccion2 + "','" + registro.Ubicacion + "'," + registro.Subtotal + "," + registro.IVA + "," + registro.Total + ",'" + registro.serie + "','A','" + registro.idformapago + "','" + registro.ccodofi + "','" + registro.caja + "','" + unixdateformat(registro.fecha_inicial) + "','" + unixdateformat(registro.fecha_final) + "'," + registro.PorcDescuento + "," + registro.descuento + ",'" + registro.catastral + "'," + registro.porcdescuentorecargos + "," + registro.descuentorecargos + ",'" + registro.tipodescuento + "','" + registro.valorfiscal + "','" +  usuariosis  +"'," + facturado +" );";
                     facturado = 0;
                     if (TCAJA == "Remota")
                     {
                         archivox.Guardar(cadenainserta, OFICINA, CAJA, DateTime.Now.ToString("yyyyMMdd"));
                     }
                     Conexion_a_BD.Ejecutar(cadenainserta );
                     if (Predial10.Properties.Settings.Default.grabarencobroexpress == "si")
                     {
                        

                         string cadenainserta2 = "use cobroexpress; insert into recibomaestro (fecha,folio,nombre,subtotal,iva,total,serie,cancelado,catastral) values ('" + Convert.ToDateTime(registro.fecha).ToString("yyyy-MM-dd") + "'," + registro.folio + ", '" + registro.Nombre + "'," + registro.Subtotal + "," + registro.IVA + "," + registro.Total + ",'" + registro.serie + "','A','" + registro.catastral + "');use predialchico;";


                         if (TCAJA == "Remota")
                         {
                             archivox.Guardar(cadenainserta2, OFICINA, CAJA, DateTime.Now.ToString("yyyyMMdd"));
                         }
                         try
                         {
                             Conexion_a_BD.Ejecutar(cadenainserta2);
                         }
                         catch (Exception err)
                         {
                        //     MessageBox.Show(err.Message);
                         }

                     }
                   
                     btnGuardar.Enabled = false;
                 }
                 else
                 {
                     throw new Exception("Duplicate");
                 }
             }
             catch (Exception err)
             {
                 if(err.Message.Contains("Duplicate"))
                 {
                     MessageBox.Show("El folio ya fue grabado, cambia a otro","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);                     
                     return;                    
                 }

                 MessageBox.Show(err.Message);
             }
             lblfolio.Text = registro.folio.ToString();
            
             
             string multi = Conexion_a_BD.obtenercampo("use predialchico;select multicajas from cajas where cod_ofi ='" + OFICINA + "' and id_caja='" + CAJA + "'");
             if (multi == "1")
             {
                 DataSet1TableAdapters.empresaTableAdapter empRESA = new DataSet1TableAdapters.empresaTableAdapter();
              
                 empRESA.UpdateQuery(ultimofolio);
                 ultimofolioimpreso();
             }
             else
             {
                
                 Conexion_a_BD.Conectar();
                 Conexion_a_BD.Ejecutar("use predialchico;update cajas set Folio=" + ultimofolio + " where cod_ofi='" + OFICINA + "' AND ID_CAJA ='" + CAJA + "'");
                 Conexion_a_BD.Desconectar();

             }


             for (int iciclo = 0; iciclo <= DTpartidas1.Rows.Count - 1; iciclo++)
             {
                 string clave = DTpartidas1.Rows[iciclo].Cells["clave"].Value.ToString ();
                 string concepto = DTpartidas1.Rows[iciclo].Cells["concepto"].Value.ToString();
                 string importe = DTpartidas1.Rows[iciclo].Cells["importe"].Value.ToString();
                 string cantidad = DTpartidas1.Rows[iciclo].Cells["cantidad"].Value.ToString();
                 string Montosindescuento = DTpartidas1.Rows[iciclo].Cells["ImporteSD"].Value.ToString();

                 string cadenainsertadetalle = "use predialchico;INSERT INTO reciboesclavo(`clave`,`Concepto`,`Importe`,`recibo`,`cantidad`,serie,Montosindescuento) values ('" + clave + "' , '" + concepto + "' , '" + importe + "' , '" + ultimofolio + "'," + cantidad + ",'" + serie +"'," + Montosindescuento +" );";

                 if (TCAJA == "Remota")
                 {
                     archivox.Guardar(cadenainsertadetalle, OFICINA, CAJA, DateTime.Now.ToString("yyyyMMdd"));
                 }
                 try
                 {
                     Conexion_a_BD.Conectar();
                     Conexion_a_BD.insertar(cadenainsertadetalle);

                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message);

                 }
               
                 if (Predial10.Properties.Settings.Default.grabarencobroexpress == "si")
                 {
                     try
                   {
                     string cadenadetallecobro = "use cobroexpress; INSERT INTO reciboesclavo(`clave`,`Concepto`,`Importe`,`recibo`,`cantidad`,serie,catastral, Montosindescuento) values ('" + clave + "' , '" + concepto + "' , '" + importe + "' , '" + ultimofolio + "'," + cantidad + ",'" + serie +"','" + registro.catastral + "'," + Montosindescuento +" );use predialchico;";
                     Conexion_a_BD.Ejecutar(cadenadetallecobro );

                     if (TCAJA == "Remota")
                     {
                         archivox.Guardar(cadenadetallecobro, OFICINA, CAJA, DateTime.Now.ToString("yyyyMMdd"));
                     }
                   }
                     catch (Exception ex)
                     {
                        // MessageBox.Show(ex.Message);

                     }
                 }
                 Conexion_a_BD.Desconectar();
             }
             MessageBox.Show("Registro guardado", "Imformaci n", MessageBoxButtons.OK, MessageBoxIcon.Information);

             //Actualiza la fecha del utimo pago en la tabla usuarios
             try
             {
                 string cadenausuario = "UPDATE usuario SET UltimoPagoP = '" + Convert.ToDateTime(registro.fecha_final).ToString("yyyy-MM-dd") + "' WHERE clave_predial= '" + txtclave.Text + "';";
                 Conexion_a_BD.Conectar();
                 Conexion_a_BD.insertar(cadenausuario );
                 Conexion_a_BD.Desconectar();

                 if (TCAJA == "Remota")
                 {
                     archivox.Guardar(cadenausuario, OFICINA, CAJA, DateTime.Now.ToString("yyyyMMdd"));
                 }

                 Facturacion.frmcierre.cierra(txtclave.Text, Dtfinal.Value);
             }
             catch (Exception error)
             {
                 MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             }

             if (DateTime.Now.Month == 1)
             {
                 DIporcentajuedescuento.Value = porcenero;
                 IIperiodosdescontados.Value = 1;
             }
             if (DateTime.Now.Month == 2)
             {
                 DIporcentajuedescuento.Value = porcfebrero;
                 IIperiodosdescontados.Value = 1;
             }
             if (DateTime.Now.Month == 3)
             {
                 DIporcentajuedescuento.Value = porcmarzo;
                 IIperiodosdescontados.Value = 1;
             }
             didescuentoreca.Value = 0;
             btnGuardar.Enabled = false;
             BTNCALCULAR.Enabled = false;
             btnImprimir.Enabled = true;
             btnDatosFiscales.Enabled = false;
             //limpiar();
         }

         private void btnConfImpresora_Click(object sender, EventArgs e)
         {
             imp2.seleccionarimpresora();
             lblImpresora.Text = imp2.prtSettings.PrinterName;
         }

         private void btnEditar_Click(object sender, EventArgs e)
         {
             txtEditFolio.Text = ultimofolioimpreso().ToString();
             txtEditFolio.Visible = true;
             btnOkFolio.Visible = true;
         }

         private void btnCancelFolio_Click(object sender, EventArgs e)
         {
             txtCancelFolio.Visible = true;
             btnOKCFolio.Visible = true;
         }

         private void btnOkFolio_Click(object sender, EventArgs e)
         {
             try
             {
                 string multi = Conexion_a_BD.obtenercampo("select multicajas from cajas where cod_ofi ='" + OFICINA + "' and id_caja='" + CAJA + "'");
                 if (multi == "1")
                 {
                     DataSet1TableAdapters.empresaTableAdapter emp = new DataSet1TableAdapters.empresaTableAdapter();
                     int ultimofolio = Convert.ToInt32(txtEditFolio.Text);
                     emp.UpdateQuery(ultimofolio);
                     ultimofolioimpreso();
                 }
                 else
                 {
                     int ultimofolio = Convert.ToInt32(txtEditFolio.Text);
                     Conexion_a_BD.Conectar();
                     Conexion_a_BD.Ejecutar("update predialchico.cajas set Folio=" + ultimofolio + " where cod_ofi='" + OFICINA + "' AND ID_CAJA ='" + CAJA + "'");
                     Conexion_a_BD.Desconectar();
                 }
                 ultimofolioimpreso();
                 txtEditFolio.Visible = false;
                 btnOkFolio.Visible = false;
             }
             catch(Exception err)
             {
                 MessageBox.Show(err.Message);
             }

         }

         private void btnOKCFolio_Click(object sender, EventArgs e)
         {
             clscancelacion cancela = new clscancelacion(OFICINA, CAJA, txtCancelFolio.Text);

             txtCancelFolio.Visible = false;
             btnOKCFolio.Visible = false;
         }

         private Int32 ultimofolioimpreso()
         {
             try
             {
                 string multi = Conexion_a_BD.obtenercampo("select multicajas from cajas where cod_ofi ='" + OFICINA + "' and id_caja='" + CAJA + "'");
                 if (multi == "1")
                 {
                     DataSet1TableAdapters.empresaTableAdapter emp = new DataSet1TableAdapters.empresaTableAdapter();
                     emp.Fill(predialchicoDataSet.empresa);
                     DataRow rowempresa;
                     rowempresa = predialchicoDataSet.Tables["empresa"].Rows[0];

                     Int32 ultimo = 0;
                     ultimo = Convert.ToInt32(rowempresa["folioP"].ToString());
                     lblUFolio.Text = ultimo.ToString();

                     return ultimo;
                 }
                 else
                 {
                     string temultimo = Conexion_a_BD.obtenercampo("select folio from cajas where cod_ofi ='" + OFICINA + "' and id_caja='" + CAJA + "'");
                     Int32 ultimo = 0;
                     ultimo = Convert.ToInt32(temultimo);
                     lblUFolio.Text = ultimo.ToString();

                     return ultimo;
                 }

             }
             catch (Exception ERR)
             {
                 MessageBox.Show(ERR.Message);
             }

             return 0;
         }

         public void btnImprimir_Click(object sender, EventArgs e)
         {
             
             if (lblfolio.Text == "0")
             {
                 MessageBox.Show("No has grabado el recibo");
                 return;
             }

             btnImprimir.Enabled = false;
             btnDatosFiscales.Enabled = false;
             imprimirnet imp = new imprimirnet();
             imp.prtDoc.PrinterSettings = imp2.prtSettings;

            string query = " select * from recibomaestro where folio="+ lblfolio.Text + " and serie='" + serie +"'";

            // Llamar al método Consulta de Conexion_a_BD
            DataTable result = Conexion_a_BD.Consulta(query);
            DataRow rowrecibo;
            // Procesar los resultados
           
              
             rowrecibo = result.Rows[0];


            string Queryf = "select * from formatorecibo";
            // Llamar al método Consulta de Conexion_a_BD
            DataTable resultformato = Conexion_a_BD.Consulta(Queryf);
           






            lineaimprimir.alineacion ALI = lineaimprimir.alineacion.Izquierda;
             foreach (DataRow row in resultformato.Rows)
             {

                 string alinea = row["Alineacion"].ToString();
                 string letra = "Microsoft sans serif";
                 float tamano = 8.0f;
                 int x, y;
                 x = Convert.ToInt32(row["COLUMNA"].ToString());
                 y = Convert.ToInt32(row["FILA"].ToString());
                 letra = row["Letra"].ToString();
                 float.TryParse(row["Size"].ToString(), out tamano);

                 switch (alinea)
                 {
                     case "Izquierda": ALI = lineaimprimir.alineacion.Izquierda;
                         break;
                     case "Derecha": ALI = lineaimprimir.alineacion.Derecha;
                         break;
                     case "Centrado": ALI = lineaimprimir.alineacion.Centrado;
                         break;
                 }

                 string tipocampo = "";
                 tipocampo = row["Tipo"].ToString();
                 // obtiene el nombre del campo a trabajar
                 string campo = "";
                 campo = row["Concepto"].ToString();

                 DateTime fec = DateTime.Now;
                 string mensaje = "XX";
                 switch (tipocampo)
                 {
                     case "CampoTexto": ALI = lineaimprimir.alineacion.Izquierda;
                         mensaje = rowrecibo[campo].ToString();
                         break;
                     case "CampoDia":
                         fec = Convert.ToDateTime(rowrecibo[campo].ToString());
                         mensaje = fec.Day.ToString();
                         break;
                     case "CampoMes":
                         fec = Convert.ToDateTime(rowrecibo[campo].ToString());
                         mensaje = cadenames(fec.Month);
                         break;
                     case "CampoAno":
                         fec = Convert.ToDateTime(rowrecibo[campo].ToString());
                         mensaje = fec.Year.ToString();
                         break;
                     case "CampoNumero":
                         mensaje = rowrecibo[campo].ToString();
                         break;
                     case "CampoMoneda":
                         mensaje = String.Format(new AcctNumberFormat(), "{0:C2}", Convert.ToDecimal(rowrecibo[campo].ToString()));
                         break;
                     case "ConvertirLetras":
                         clsconv let = new clsconv();
                         mensaje = let.enletras(rowrecibo[campo].ToString());
                         break;
                     case "Texto": mensaje = row["Concepto"].ToString();
                         break;

                 }

                 imp.imprimir(x, y, mensaje, ALI, letra, tamano);

             }

            string queryd = "select * from esclavodetalle where recibo= " + lblfolio.Text + " and serie='" + serie + "'";
            // Llamar al método Consulta de Conexion_a_BD
            DataTable resultdetalle = Conexion_a_BD.Consulta(queryd);




          
             int linea = Predial10.Properties.Settings.Default.linea_inicial_de_detalle_de_recibo;
             int columnaimporte = Predial10.Properties.Settings.Default.columna_de_importe;
             int columnaConcepto = Predial10.Properties.Settings.Default.columna_de_concepto;

             foreach (DataRow rowdetalle in resultdetalle.Rows)
             {
                 string mensaje = "";
                 int cordx, cordy, cordconcepto = 0;
                 cordx = Convert.ToInt32(rowdetalle["COLUMNARECIBO"].ToString());
                 cordy = Convert.ToInt32(rowdetalle["LINEARECIBO"].ToString());
                 mensaje = String.Format(new AcctNumberFormat(), "{0:C2}", Convert.ToDecimal(rowdetalle["Importe"].ToString()));
                 string letra = Predial10.Properties.Settings.Default.letra_detalle_recibo;
                 float tamano = Predial10.Properties.Settings.Default.tamano_letra_detalle_recibo;
                 if (cordy == 0)
                 {
                     cordy = linea;
                     linea += Predial10.Properties.Settings.Default.avance_de_linea_detalle_recibo;
                 }
                 if (cordx == 0)
                 {
                     cordx = columnaimporte;
                     cordconcepto = columnaConcepto;
                     imp.imprimir(cordconcepto, cordy, rowdetalle["Concepto"].ToString(), lineaimprimir.alineacion.Izquierda, letra, tamano);
                 }

                 ALI = lineaimprimir.alineacion.Derecha;

                 imp.imprimir(cordx, cordy, mensaje, ALI, letra, tamano);
             }


             imp.mandardocumento(false);
             ultimofolioimpreso();
         }

         public string cadenames(int _mes)
         {
             switch (_mes)
             {
                 case 1:
                     {
                         return "Enero";
                         break;
                     }
                 case 2:
                     {
                         return "Febrero";
                         break;
                     }
                 case 3:
                     {
                         return "Marzo";
                         break;
                     }
                 case 4:
                     {
                         return "Abril";
                         break;
                     }
                 case 5:
                     {
                         return "Mayo";
                         break;
                     }
                 case 6:
                     {
                         return "Junio";
                         break;
                     }
                 case 7:
                     {
                         return "Julio";
                         break;
                     }
                 case 8:
                     {
                         return "Agosto";
                         break;
                     }
                 case 9:
                     {
                         return "Septiembre";
                         break;
                     }
                 case 10:
                     {
                         return "Octubre";
                         break;
                     }
                 case 11:
                     {
                         return "Noviembre";
                         break;
                     }
                 case 12:
                     {
                         return "Diciembre";
                         break;
                     }
             }
             return "";
         }

         private void DTpartidas1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
         {

             if (e.ColumnIndex == 3)
             {
                 DTpartidas1.Rows[e.RowIndex].Cells["ImporteSD"].Value = DTpartidas1.Rows[e.RowIndex].Cells["Importe"].Value;
                 calculatotal();
             }
         }

         public void calculatotal()
         {
             try
             {
                 total = DTpartidas1.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDecimal(x.Cells[3].Value) * Convert.ToDecimal(x.Cells[1].Value));
                 lbltotal.Text = String.Format(new AcctNumberFormat(), "{0:C2}", total);

                 clsconv let = new clsconv();
                 lblletras.Text = let.enletras(total.ToString());
             }
             catch (Exception err)
             {
                 MessageBox.Show("Quite el signo de pesos($) para poder continuar", "Informaci n", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }

         }

         private void Dtfinal_Click(object sender, EventArgs e)
         {
             BTNCALCULAR.Enabled = true;
             Dtfinal.Value = dateTimeInput1.Value;
         }

         private void btnagregartraslado_Click(object sender, EventArgs e)
         {
             
         }

         private void chkpen_CheckedChanged_1(object sender, EventArgs e)
         {

             if (chkpen.Checked == true)
             {
                 chkinsen.Checked = false;
                 DIporcentajuedescuento.Value = Convert.ToDouble(porcJUBI);
                 IIperiodosdescontados.Value = 1;
             }
             if (chkpen.Checked == false)
             {
                 //chkinsen.Checked = false;
                 DIporcentajuedescuento.Value = Convert.ToDouble(0);
                 IIperiodosdescontados.Value = 0;
             }
         }

         private void chkinsen_CheckedChanged_1(object sender, EventArgs e)
         {
             if (chkinsen.Checked == true)
             {
                 chkpen.Checked = false;
                 DIporcentajuedescuento.Value = Convert.ToDouble(porcINSEN);
                 IIperiodosdescontados.Value = 1;
             }
             if (chkinsen.Checked == false)
             {
                 //chkinsen.Checked = false;
                 DIporcentajuedescuento.Value = Convert.ToDouble(0);
                 IIperiodosdescontados.Value = 0;
             }
         }

         public string unixdateformat(DateTime fecha)
         {
             string dia = fecha.Day.ToString ();
             string mes = fecha.Month.ToString ();
             string ano = fecha.Year.ToString ();

             string final = ano + "/" + mes + "/" + dia;
             return final;
         }

         private void buttonX1_Click(object sender, EventArgs e)
         {
            
         }

         private void txtclave_KeyDown(object sender, KeyEventArgs e)
        {            
             if (e.KeyValue.ToString() == "13")
             {
                 btnbuscar1_Click(sender, e);
                 if (error == true)
                 {                     
                     BTNCALCULAR.Enabled = false;
                 }
                 else
                 {
                     Dtfinal.Focus();
                     Dtfinal_Click(sender, e);
                 }
                
                                 
             }
         }

         private void Dtfinal_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyValue.ToString() == "13")
             {
                 BTNCALCULAR_Click(sender, e);
             }             
         }

         private void btnbuscausuario_Click(object sender, EventArgs e)
         {
             Predial10.caja.frmbuscausuario fx = new caja.frmbuscausuario(this);
             fx.ShowDialog();
         }

        public void ponusuario( string clave)
        {
            txtclave.Text = clave;
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            
            int cantidad = 1;
            string Concepto = cmbconcepto.Text  ;

            if (Dtfinal.Text == "")
            {
                MessageBox.Show("Se cambiar  la fecha final, para poder guardar el recibo, si ingresa conceptos pertenecientes a predial, ajustar la fecha final", "Informaci n", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dtfinal.Value = DTinicio.Value;
            }

            double VALOR=0;
            string porc;
            double Importe = 1;
            if  (Concepto.TrimEnd().ToUpper()  == "TRASLADO DE DOMINIO")
            {    VALOR =   divalorfiscal.Value;
                 porc = Conexion_a_BD.obtenercampo("Select porctrasladodom from empresa");
                 Importe   = VALOR * (double.Parse(porc) / 100);
            }

           

            int indice = DTpartidas1.RowCount;
            DTpartidas1.Rows.Add();
            DTpartidas1.Rows[indice].Cells["Clave"].Value = cmbconcepto.SelectedValue ;
            btnGuardar.Enabled = true;

            DTpartidas1.Rows[indice].Cells["Cantidad"].Value = cantidad;
            DTpartidas1.Rows[indice].Cells["Concepto"].Value = Concepto;
            DTpartidas1.Rows[indice].Cells["Importe"].Value = Importe ;
            DTpartidas1.Rows[indice].Cells["ImporteSD"].Value = Importe;
            DTpartidas1.Rows[indice].Cells["Unidadsat"].Value = "ACT";
            DTpartidas1.Rows[indice].Cells["Clavesat"].Value = "93151512";
            calculatotal();
        }

        private void btnDatosFiscales_Click(object sender, EventArgs e)
        {
            caja.DatosFiscales DF = new caja.DatosFiscales(this);
                 if (cmbFormaPago.SelectedIndex==-1)
            {
                MessageBox.Show("No has seleccionado una forma de pago");
                return;
            }   
            DF.Show();
        }

        private void DTpartidas1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lbltotal_Click(object sender, EventArgs e)
        {

        }

        private void lbltotal_TextChanged(object sender, EventArgs e)
        {
            if (lbltotal.Text !="0.00")
            {
                btnDatosFiscales.Enabled = true;
            }
        }
    }
}
