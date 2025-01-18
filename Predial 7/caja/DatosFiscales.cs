using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Predial10.Resources.CODE;
using System.IO;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.Diagnostics;
using CrystalDecisions.Shared;
using Predial10.Facturacion_V4;

namespace Predial10.caja
{
    public partial class DatosFiscales : DevComponents.DotNetBar.Office2007Form
    {
        Conexion_a_BD ConexionBD = new Conexion_a_BD();
        DataTable Datos = new DataTable();
       
        frmcaja caja;

        string idCaja = "";
        string serieRecibo = "";
        int folioRecibo = 0;
        string departamento = "";
        string vieneDe = "";
        string serieFacturacion = "";
        string cuentaCatastral = "";
        double totalListado = 0.0;
        double descuentoListado = 0.0;


        //Este contructor se usuara para facturar desde el listado de recibos
        public DatosFiscales(string seriePa, int folioPa, string cuenta, string ListadoRecibo, string idCajaP, double totalP, double descuentoP)
        {
            InitializeComponent();
            //autocompletar();
            //idCaja = IDcaja;
            serieRecibo = seriePa;
            folioRecibo = folioPa;
            cuentaCatastral = cuenta;
            vieneDe = ListadoRecibo;
            totalListado = totalP;
            descuentoListado = descuentoP;
            idCaja = idCajaP;

            //serieFacturacion = new CobroDefault().Database.SqlQuery<string>("select Serie from [dbo].[FolioVentas] where IDCaja = '" + Settings.Default.IDCaja + "'").LastOrDefault();

            //labelSerieFactura.Text = serieFacturacion;


            Conexion_a_BD.Conectar();
            Datos = Conexion_a_BD.Consultasql("*", "datosfiscales where cuenta='" + cuentaCatastral + "'");




            try
            {

                Conexion_a_BD.Conectar();
                Datos = Conexion_a_BD.Consultasql("*", "datosfiscales where cuenta='" + cuentaCatastral + "'");

                cmbforma.ValueMember = "ccodpago";
                cmbforma.DisplayMember = "cdespago";
                cmbforma.DataSource = Conexion_a_BD.Consultasql("ccodpago, cdespago", "fpago", "cdespago");
                cmbforma.SelectedValue = "01";

                cmbmetodo.ValueMember = "c_MetodoPago";
                cmbmetodo.DisplayMember = "descripcion";
                cmbmetodo.DataSource = Conexion_a_BD.Consultasql("c_MetodoPago, concat(c_MetodoPago,' ',descripcion) as descripcion", "c_metodopago", "descripcion");
                cmbmetodo.SelectedValue = "PUE";

                cmbuso.ValueMember = "c_UsoCFDI";
                cmbuso.DisplayMember = "descripcion";
                cmbuso.DataSource = Conexion_a_BD.Consultasql("c_UsoCFDI, concat(c_UsoCFDI,' ',descripcion) as descripcion", "c_UsoCFDI", "descripcion");
                cmbuso.SelectedValue = "G03";

                //Agregar RegimenFíscal para la facturación CFDI 4.0
                cmbRegimenFiscal.ValueMember = "ClaveRegimenFiscal";
                cmbRegimenFiscal.DisplayMember = "Descripcion";
                cmbRegimenFiscal.DataSource = Conexion_a_BD.Consultasql("ClaveRegimenFiscal, concat(ClaveRegimenFiscal,' | ',Descripcion) as Descripcion", "regimenfiscal", "idRegimenFiscal");
                cmbRegimenFiscal.SelectedValue = "601";
            }
            catch (Exception err)
            {

            }

            Conexion_a_BD.Desconectar();


            if (Datos.Rows.Count > 0)
            {
                txtCuenta.Text = Datos.Rows[0]["cuenta"].ToString();
                txtNombre.Text = Datos.Rows[0]["NOMBRE"].ToString();
                txtCalle.Text = Datos.Rows[0]["CALLE"].ToString();
                txtNoExterior.Text = Datos.Rows[0]["NUMEXT"].ToString();
                txtNoInterior.Text = Datos.Rows[0]["NUMINT"].ToString();
                txtColonia.Text = Datos.Rows[0]["COLONIA"].ToString();
                txtPoblacion.Text = Datos.Rows[0]["POBLACION"].ToString();
                txtEstado.Text = Datos.Rows[0]["ESTADO"].ToString();
                txtCP.Text = Datos.Rows[0]["CP"].ToString();
                txtRFC.Text = Datos.Rows[0]["RFC"].ToString();
                if (txtRFC.Text == "XAXX010101000")
                {
                    cmbuso.SelectedValue = "S01";
                }
                else
                {
                    cmbuso.SelectedValue = "G03";
                }
                txtEmail.Text = Datos.Rows[0]["maildeenvio"].ToString();
                txtDelegacion.Text = Datos.Rows[0]["DELEGACION"].ToString();
                txtPais.Text = Datos.Rows[0]["PAIS"].ToString();
                txtCPimpreso.Text = Datos.Rows[0]["CP_Impreso"].ToString();
                if (Datos.Rows[0]["regimenfiscal"].ToString() != "")
                {

                    cmbRegimenFiscal.SelectedValue = Datos.Rows[0]["regimenfiscal"].ToString();

                }
            }
            else
            {
                //traigo los datos del la caja
                txtCuenta.Text = VariablesCajas.Cuenta;
                txtNombre.Text = VariablesCajas.Nombre;
                txtCalle.Text = VariablesCajas.Calle;
                txtNoExterior.Text = VariablesCajas.NoExt;
                txtColonia.Text = VariablesCajas.Colonia;
                txtPoblacion.Text = VariablesCajas.Comunidad;

            }




        }

        public DatosFiscales(frmcaja _caja)
        {
            InitializeComponent();
            caja = _caja;

            
            try
            {

                Conexion_a_BD.Conectar();
                Datos = Conexion_a_BD.Consultasql("*", "datosfiscales where cuenta='" + VariablesCajas.Cuenta + "'");

                cmbforma.ValueMember = "ccodpago";
                cmbforma.DisplayMember = "cdespago";
                cmbforma.DataSource = Conexion_a_BD.Consultasql("ccodpago, cdespago", "fpago", "cdespago");
                cmbforma.SelectedValue = "01";

                cmbmetodo.ValueMember = "c_MetodoPago";
                cmbmetodo.DisplayMember = "descripcion";
                cmbmetodo.DataSource = Conexion_a_BD.Consultasql("c_MetodoPago, concat(c_MetodoPago,' ',descripcion) as descripcion", "c_metodopago", "descripcion");
                cmbmetodo.SelectedValue = "PUE";

                cmbuso.ValueMember = "c_UsoCFDI";
                cmbuso.DisplayMember = "descripcion";
                cmbuso.DataSource = Conexion_a_BD.Consultasql("c_UsoCFDI, concat(c_UsoCFDI,' ',descripcion) as descripcion", "c_UsoCFDI", "descripcion");
                cmbuso.SelectedValue = "G03";

                //Agregar RegimenFíscal para la facturación CFDI 4.0
                cmbRegimenFiscal.ValueMember = "ClaveRegimenFiscal";
                cmbRegimenFiscal.DisplayMember = "Descripcion";
                cmbRegimenFiscal.DataSource = Conexion_a_BD.Consultasql("ClaveRegimenFiscal, concat(ClaveRegimenFiscal,' | ',Descripcion) as Descripcion", "regimenfiscal", "idRegimenFiscal");
                cmbRegimenFiscal.SelectedValue = "601";
            }
            catch (Exception err)
            {

            }

            Conexion_a_BD.Desconectar();


            if (Datos.Rows.Count>0)
            {
                txtCuenta.Text = Datos.Rows[0]["cuenta"].ToString();
                txtNombre.Text = Datos.Rows[0]["NOMBRE"].ToString();
                txtCalle.Text = Datos.Rows[0]["CALLE"].ToString();
                txtNoExterior.Text = Datos.Rows[0]["NUMEXT"].ToString();
                txtNoInterior.Text = Datos.Rows[0]["NUMINT"].ToString();
                txtColonia.Text = Datos.Rows[0]["COLONIA"].ToString();
                txtPoblacion.Text = Datos.Rows[0]["POBLACION"].ToString();
                txtEstado.Text = Datos.Rows[0]["ESTADO"].ToString();
                txtCP.Text = Datos.Rows[0]["CP"].ToString();
                txtRFC.Text = Datos.Rows[0]["RFC"].ToString();
                if (txtRFC.Text == "XAXX010101000")
                {
                    cmbuso.SelectedValue = "S01";
                }
                else
                {
                    cmbuso.SelectedValue = "G03";
                }
                txtEmail.Text = Datos.Rows[0]["maildeenvio"].ToString();
                txtDelegacion.Text = Datos.Rows[0]["DELEGACION"].ToString();
                txtPais.Text = Datos.Rows[0]["PAIS"].ToString();
                txtCPimpreso.Text = Datos.Rows[0]["CP_Impreso"].ToString();
                if (Datos.Rows[0]["regimenfiscal"].ToString() != "")
                {

                    cmbRegimenFiscal.SelectedValue = Datos.Rows[0]["regimenfiscal"].ToString();

                }
            }
            else
            {
                //traigo los datos del la caja
                txtCuenta.Text = VariablesCajas.Cuenta;
                txtNombre.Text = VariablesCajas.Nombre;
                txtCalle.Text = VariablesCajas.Calle;
                txtNoExterior.Text = VariablesCajas.NoExt;
                txtColonia.Text = VariablesCajas.Colonia;
                txtPoblacion.Text = VariablesCajas.Comunidad;
                       
            }
            
               

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            btnGenerar.Enabled = false;
          try
            {
                string cadena = string.Empty;
                bool bandera = true;

                if (txtNombre.Text =="")
                {
                    cadena = "Nombre ";
                    bandera = false;
                }

                if (txtCalle.Text == "")
                {
                    cadena = cadena + "Calle ";
                    bandera = false;
                }

                if (txtPoblacion.Text == "")
                {
                    cadena = cadena + "Población ";
                    bandera = false;
                }

                if (txtRFC.Text == "")
                {
                    cadena = cadena + "RFC ";
                    bandera = false;
                }

                if (txtCP.Text == "")
                {
                    cadena = cadena + "CP ";
                    bandera = false;
                }

                if (txtPais.Text == "")
                {
                    cadena = cadena + "Pais ";
                    bandera = false;
                }

                if (txtEstado.Text == "")
                {
                    cadena = cadena + "Estado ";
                    bandera = false;
                }

                if (cadena.Length > 0)
                {
                    MessageBox.Show("Los Campos " + cadena + " no pueden ir vacios.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    btnGenerar.Enabled = true;
                    return ;
                }
              }
              catch(Exception on)

              {
              }

            try
            {
                String CAJA = "";
                

                if (vieneDe == "LISTADORECIBO")
                {

                    CAJA = idCaja;

                }
                else
                {

                
                
                CAJA = caja.CAJA;


                caja.btnGuardar_Click(sender, e);

                }


                DataTable Datosfac = new DataTable();

                String seriefactura = Conexion_a_BD.obtenercampo("select seriefactura from empresa limit 1");
                String numerofactura = (int.Parse((Conexion_a_BD.obtenercampo("select foliofactura from empresa limit 1"))) + 1).ToString();
                
                ClsFactura_v4 factu = new ClsFactura_v4();

                double total;
                double descuento;

                double subtotal;

                if (vieneDe == "LISTADORECIBO")
                {

                    total = totalListado;
                    descuento = descuentoListado;

                    subtotal = (double)Math.Round(total + descuento, 2);

                    
                }
                else
                {
                    total = (double)Math.Round(caja.total, 2);
                    descuento = (double)Math.Round(caja.descuento, 2);

                    subtotal = (double)Math.Round(total + descuento, 2);


                }


                
                

                //Invocar a la clase facturación CFDI 4.0 15/06/2022 UMG
                //MultiFacturasSDK.MFSDK ARCHIVO = factu.construirfactura(seriefactura, numerofactura, this.cmbforma.SelectedValue.ToString(), cmbmetodo.SelectedValue.ToString(), cmbuso.SelectedValue.ToString(),  txtRFC.Text, txtNombre.Text, caja.DTpartidas1,"importeSD");
                MultiFacturasSDK.MFSDK ARCHIVO;

                if (vieneDe == "LISTADORECIBO")
                {

                    var elementosReciboEsclavo = Conexion_a_BD.Consulta($"SELECT * FROM RECIBOESCLAVO WHERE SERIE = '{serieRecibo}' AND RECIBO = {folioRecibo}");

                    ARCHIVO = factu.construirfacturaV4(seriefactura, numerofactura, this.cmbforma.SelectedValue.ToString(), cmbmetodo.SelectedValue.ToString(), cmbuso.SelectedValue.ToString(), txtRFC.Text, txtNombre.Text, elementosReciboEsclavo, "importeSD", txtCP.Text.ToString(), cmbRegimenFiscal.SelectedValue.ToString(), false);

                }
                else
                {
                    ARCHIVO = factu.construirfacturaV4(seriefactura, numerofactura, this.cmbforma.SelectedValue.ToString(), cmbmetodo.SelectedValue.ToString(), cmbuso.SelectedValue.ToString(), txtRFC.Text, txtNombre.Text, caja.DTpartidas1, "importeSD", txtCP.Text.ToString(), cmbRegimenFiscal.SelectedValue.ToString(), false);
                }
                
                MultiFacturasSDK.SDKRespuesta respuesta = factu.timbrar(ARCHIVO);

                if (!respuesta.Codigo_MF_Texto.Contains("OK"))
                {
                    MessageBox.Show(respuesta.Codigo_MF_Texto);
                    return;
                }

                if (respuesta.Codigo_MF_Texto.Contains("OK"))
                {
                    String cadena;
                    


                    cadena = "insert into encfac SET FECHA = CONCAT('" + DateTime.Now.Year + "-" + DateTime.Now.Month;
                    cadena += "-" + DateTime.Now.Day + "', ' ', curtime()), SERIE = '" + seriefactura + "', numero = " + numerofactura + ",NOMBRE = '" + txtNombre.Text + "',";
                    cadena += "cadena='" + respuesta.Cadena + "', sello ='" + respuesta.Sello + "', sellosat='" + respuesta.SelloSAT + "', cfdi='" + respuesta.CFDI + "',";
                    cadena += " nodecertificado='" + respuesta.NoCertificado + "',descuento=" + descuento + ",rfc='" + txtRFC.Text + "',";
                    cadena += "SUBTOTAL = " + subtotal + ",IVA = 0,TOTAL = " + total + ", UUID='" + respuesta.UUID + "',formapago='" + this.cmbforma.SelectedValue.ToString() + "'";
                    cadena += ",TIPO = 'INDIVIDUAL', ESTADO = 'A', CAJA = '" + CAJA + "', USUARIO = '', motivocancelacion = '', version = '4.0', observacion='" + txtObservaciones.Text + "'";




                    Conexion_a_BD.Ejecutar(cadena);


                    if(vieneDe == "LISTADORECIBO")
                    {

                        Conexion_a_BD.Ejecutar("UPDATE RECIBOMAESTRO SET FACTURADO=" + numerofactura + " WHERE RECIBOMAESTRO.serie='" + serieRecibo + "' AND  RECIBOMAESTRO.folio=" + folioRecibo + " and facturado=0");

                    }
                    else
                    {

                    
                    Conexion_a_BD.Ejecutar("UPDATE RECIBOMAESTRO SET FACTURADO=" + numerofactura + " WHERE RECIBOMAESTRO.serie='" +caja.serie  + "' AND  RECIBOMAESTRO.folio=" + caja.ultimofolio + " and facturado=0");

                    }

                    Conexion_a_BD.Ejecutar("update empresa set foliofactura=" + numerofactura);
                    Conexion_a_BD.Desconectar();

                    if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\facturas"))
                    {
                        Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\facturas");


                    }
                    String cadenaxml = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\facturas\\FACTURA" + seriefactura + numerofactura + ".XML").Trim();
                    String cadenapdf = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\facturas\\" + seriefactura + numerofactura + ".PDF").Trim();
                    FileStream fs = File.Create(cadenaxml);


                    Byte[] info = new UTF8Encoding(true).GetBytes(respuesta.CFDI.ToString().TrimStart());
                    fs.Write(info, 0, info.Length);
                    fs.Close();

                

                    //Factura de cliente con ItextSharp
                    Generador.CreaPDF crearPDF = new Generador.CreaPDF(cadenaxml, cadenapdf,  txtObservaciones.Text, "4.0");


                    //System.Drawing.Image imagen = factu.qrdatos(cadenaxml);
                    //try
                    //{
                    //    using (MySqlConnection conn = GetNewConnection())
                    //    {
                    //        using (MySqlCommand cmd = new MySqlCommand())
                    //        {
                    //            cmd.Connection = conn;
                    //            cmd.CommandText = "update empresa set imagentem=@imagentem";

                    //            cmd.Parameters.AddWithValue("@imagentem", ImageToByteArray(imagen));
                    //            cmd.ExecuteNonQuery();
                    //        }
                    //    }
                    //}
                    //catch (Exception error)
                    //{
                    //    MessageBox.Show(error.Message);
                    //}



                    DataSet datos = new DataSet();
                    datos.ReadXml(cadenaxml);
                    //DataTable empresat = new DataTable();
                    //empresat = Conexion_a_BD.Consultasql("*","empresa","cnombre limit 1");
                    //datos.Tables.Add(empresat);

                    //ReportDocument factura = new ReportDocument();
                    //factura.Load(Application.StartupPath + "\\reportes\\factura.rpt");
                    //factura.SetDataSource(datos);
                    //factura.SetParameterValue("nombre", txtNombre.Text);
                    //factura.SetParameterValue("direccion", txtCalle.Text + " " + txtNoExterior.Text + " " + txtNoInterior.Text);
                    //factura.SetParameterValue("fechatimbrado", respuesta.FechaTimbrado);
                    //factura.SetParameterValue("certificado", respuesta.NoCertificado);
                    //clsconv let = new clsconv();
                    //string mensaje = let.enletras(total.ToString());
                    //factura.SetParameterValue("Cantidadconletra", mensaje);
                    //factura.SetParameterValue("formadepago", this.cmbforma.SelectedValue.ToString());
                    //factura.SetParameterValue("cadenaoriginal", respuesta.Cadena);
                    //factura.SetParameterValue("foliofiscal", seriefactura + numerofactura);
                    //factura.SetParameterValue("RFCCLIENTE", txtRFC.Text);
                    //factura.SetParameterValue("CERTIFICADOSAT", respuesta.CertificadoSAT);
                    //factura.SetParameterValue("nota", txtObservaciones.Text);
                    //factura.SetParameterValue("sellodigital", respuesta.Sello);
                    //factura.SetParameterValue("seriecertificado", respuesta.NoCertificado);
                    //factura.SetParameterValue("selloCFDI", respuesta.SelloSAT);
                    //factura.SetParameterValue("UUID", respuesta.UUID);
                    //factura.SetParameterValue("subtotal", subtotal);
                    //factura.SetParameterValue("descuento", descuento);
                    //factura.SetParameterValue("total", total);
                    //factura.SetParameterValue("metodo", "PUE");
                    //factura.SetParameterValue("colonia", txtColonia.Text);
                    //factura.SetParameterValue("ciudad", txtPoblacion.Text + " " + txtEstado.Text + " " + txtCP.Text);


                    //factura.ExportToDisk(ExportFormatType.PortableDocFormat, cadenapdf);


                    Process.Start(cadenapdf);
                }
            }
            catch (Exception exvc)
            {
                MessageBox.Show($"Ocurrio un error mientras se generraba la factura: {exvc.ToString()}");
            }
            Close();
        }
        public MySqlConnection GetNewConnection()
        {
            var conn = new MySqlConnection(Predial10.Properties.Settings.Default.predialchicoConnectionString);
            conn.Open();
            return conn;
        }

        public System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            System.Drawing.Image returnImage = null;
            try
            {
                MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
                ms.Write(byteArrayIn, 0, byteArrayIn.Length);
                returnImage = System.Drawing.Image.FromStream(ms, true);//Exception occurs here
            }
            catch { }
            return returnImage;

        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string cadena = string.Empty;
                bool bandera = true;

                if (txtNombre.Text =="")
                {
                    cadena = "Nombre ";
                    bandera = false;
                }

                if (txtCalle.Text == "")
                {
                    cadena = cadena + "Calle ";
                    bandera = false;
                }

                if (txtPoblacion.Text == "")
                {
                    cadena = cadena + "Población ";
                    bandera = false;
                }

                if (txtRFC.Text == "")
                {
                    cadena = cadena + "RFC ";
                    bandera = false;
                }

                if (txtCP.Text == "")
                {
                    cadena = cadena + "CP ";
                    bandera = false;
                }

                if (txtPais.Text == "")
                {
                    cadena = cadena + "Pais ";
                    bandera = false;
                }

                if (cadena.Length > 0)
                {
                    MessageBox.Show("Los Campos " + cadena + " no pueden ir vacios.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return ;
                }

                if (bandera==true)
                {
                    StringBuilder Cadena = new StringBuilder();

                    Conexion_a_BD.Conectar();
                    Conexion_a_BD.insertar("delete from datosfiscales where cuenta='" +  txtCuenta.Text + "'");
                    Cadena.Append("INSERT INTO datosfiscales SET ");
                    Cadena.Append("cuenta='" + txtCuenta.Text + "',");
                    Cadena.Append("NOMBRE='" + txtNombre.Text + "',");
                    Cadena.Append("CALLE='" + txtCalle.Text + "',");
                    Cadena.Append("NUMEXT='" + txtNoExterior.Text + "',");
                    Cadena.Append("NUMINT='" + txtNoInterior.Text + "',");
                    Cadena.Append("COLONIA='" + txtColonia.Text + "',");
                    Cadena.Append("POBLACION='" + txtPoblacion.Text + "',");
                    Cadena.Append("ESTADO='" + txtEstado.Text + "',");
                    Cadena.Append("CP='" + txtCP.Text + "',");
                    Cadena.Append("RFC='" + txtRFC.Text + "',");
                    Cadena.Append("maildeenvio='" + txtEmail.Text + "',");
                    Cadena.Append("DELEGACION='" + txtDelegacion.Text + "',");
                    Cadena.Append("PAIS='" + txtPais.Text + "',");
                    Cadena.Append("regimenfiscal='" + cmbRegimenFiscal.SelectedValue + "',");
                    Cadena.Append("CP_Impreso='" + txtCPimpreso.Text + "'");
                    //Cadena.Append("regimenfiscal='616'" + "',");
                    //Cadena.Append("CP_Impreso='43730'");

                    Conexion_a_BD.insertar(Cadena.ToString());
                    Conexion_a_BD.Desconectar();
                    MessageBox.Show("Datos guardados exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

               
              
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                Conexion_a_BD.Desconectar();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DatosFiscales_Load(object sender, EventArgs e)
        {
           
        }

    }
}
