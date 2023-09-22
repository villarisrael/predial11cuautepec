using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Predial10.Resources.CODE;
using System.Diagnostics;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;
using MySql.Data.MySqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data.SqlClient;
using Predial10.Facturacion_V4;

namespace Predial10.caja
{
    public partial class FrmFacturadeldia : DevComponents.DotNetBar.Office2007Form
    {
        public double total=0;
        public double subtotal = 0;
        public double descuento = 0;
        public FrmFacturadeldia()
        {
            InitializeComponent();
            try
            {
                DataTable tabla = new DataTable();
                Conexion_a_BD.Conectar();
                tabla = Conexion_a_BD.Consultasql("*", "Empresa");
                txtCalle.Text = tabla.Rows[0]["CDOMICILIO"].ToString();
                txtColonia.Text = tabla.Rows[0]["CCOLONIA"].ToString();
                txtPoblacion.Text = tabla.Rows[0]["CPOBLACION"].ToString();
                txtEstado.Text = tabla.Rows[0]["CPROVINCIA"].ToString();
                txtCP.Text = tabla.Rows[0]["CCODPOS"].ToString();
                txtEmail.Text = tabla.Rows[0]["CEMAIL"].ToString();
                txtPais.Text = "MEXICO";
                Conexion_a_BD.Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Conexion_a_BD.Conectar();
            Conexion_a_BD.Ejecutar("UPDATE EMPRESA SET CDOMICILIO ='" + txtCalle.Text + "', CCOLONIA='" + txtColonia.Text + "', CPOBLACION='" + txtPoblacion.Text +"', CPROVINCIA='" + txtEstado.Text + "', CCODPOS='" + txtCP.Text  +"', CEMAIL='" + txtEmail.Text +"'");
            Conexion_a_BD.Desconectar();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
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

                if (txtEstado.Text == "")
                {
                    cadena = cadena + "Estado ";
                    bandera = false;
                }

                if (cadena.Length > 0)
                {
                    MessageBox.Show("Los Campos " + cadena + " no pueden ir vacios.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return ;
                }
              }
              catch(Exception on)

              {
              }
            try
            {
                DataTable TBL_Consulta = new DataTable();
                String CAJA="";
                Conexion_a_BD.Conectar();
                TBL_Consulta = Conexion_a_BD.Consultasql("COD_OFI ,CAJA,TCAJA,SERIE", " croape WHERE MAQUINA= '" + System.Environment.MachineName.ToString() + "' AND FEC_APE='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
                Conexion_a_BD.Desconectar();
                var resultado = from myRow in TBL_Consulta.AsEnumerable() select myRow;
                try
                {
                    DataView view = resultado.AsDataView();
                  
                    CAJA = view[0]["CAJA"].ToString();
                   
                }
                catch (Exception x)
                {
                    CAJA = "";
                   // MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                DataTable Datosfac = new DataTable();

                String cpOrganismo = Conexion_a_BD.obtenercampo("select CCODPOS from empresa limit 1");
                String seriefactura = Conexion_a_BD.obtenercampo("select seriefactura from empresa limit 1");
                String numerofactura =( int.Parse(( Conexion_a_BD.obtenercampo("select foliofactura from empresa limit 1"))) + 1).ToString();

                ClsFactura_v4 factu = new ClsFactura_v4();


                MultiFacturasSDK.MFSDK ARCHIVO = factu.construirfacturaV4(seriefactura, numerofactura, "01","PUE","S01", txtRFC.Text, txtNombre.Text,DTGdetalles,"ImporteSD", cpOrganismo, "616", true);
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
                    cadena += "SUBTOTAL = " + subtotal + ",IVA = 0,TOTAL = " + total + ", UUID='" + respuesta.UUID + "',formapago='" + CMBFORMADEPAGO.SelectedValue + "'";
                    cadena += ",TIPO = 'MASIVA', ESTADO = 'A', CAJA = '" + CAJA + "', USUARIO = '', motivocancelacion = '',observacion='" + txtObservaciones.Text + "'";

                    Conexion_a_BD.Ejecutar(cadena);
                    Conexion_a_BD.Ejecutar("UPDATE RECIBOMAESTRO SET FACTURADO=" + numerofactura + " WHERE RECIBOMAESTRO.FECHA>='" + DTPfechainicio.Value.ToString("yyyy-MM-dd") + "' AND FECHA<='" + this.DTPfechafinal.Value.ToString("yyyy-MM-dd") + "' and facturado=0");
                    Conexion_a_BD.Ejecutar("update empresa set foliofactura=" + numerofactura);
                    Conexion_a_BD.Desconectar();



                    string Date = DateTime.Now.ToString("yyyy-MM");

                    if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\facturasPublicoPredial\\" + Date))
                    {
                        //Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\facturas");
                        Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\facturasPublicoPredial\\" + Date);

                    }

                    

                    String cadenaxml = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\facturasPublicoPredial\\" + Date + "\\" + "FACTURA" + seriefactura + numerofactura + ".XML").Trim();
                    String cadenapdf = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\facturasPublicoPredial\\" + Date + "\\" + "FACTURA" + seriefactura + numerofactura + ".PDF").Trim();

                    FileStream fs = File.Create(cadenaxml);

                    Byte[] info = new UTF8Encoding(true).GetBytes(respuesta.CFDI.ToString().TrimStart());
                    fs.Write(info, 0, info.Length);
                    fs.Close();


                    //Obtener contyenido del xml
                    string xmlString = System.IO.File.ReadAllText(cadenaxml);

                    

                    //Byte[] info = new UTF8Encoding(true).GetBytes(linea["CFDI"].ToString().TrimStart());
                    //fs.Write(info, 0, info.Length);
                    //fs.Close();

                    //Por aqui se encuentra el error Caracter no valido
                    //try
                    //{
                       

                    //    EscribeEnArchivo(respuesta.CFDI, cadenaxml, true);
                    //}
                    //catch (Exception err)
                    //{
                    //    string mensajedeerror = err.Message;
                    //}


                    //Byte[] info = new UTF8Encoding(true).GetBytes(respuesta.CFDI.ToString().TrimStart());
                    //fs.Write(info, 0, info.Length);
                    //fs.Close();





                    //System.Drawing.Image imagen = factu.qrdatos(cadenaxml);




                   







                    //DataSet datos = new DataSet();
                    //datos.ReadXml(cadenaxml);


                    byte[] logoempresa = Conexion_a_BD.obtenerimagen("select logo from empresa");

                    System.Drawing.Image logoempresa2 = byteArrayToImage(logoempresa);

                    String cadenapdf2 = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\facturasPublicoPredial\\" + Date).Trim();

                    if (!Directory.Exists(cadenapdf2))
                    {

                        DirectoryInfo di = Directory.CreateDirectory(cadenapdf2);

                    }

                    String cadenapdfGen = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\facturasPublicoPredial\\" + Date + "\\FACTURA" + seriefactura + numerofactura + ".PDF").Trim();

                    Generador.CreaPDF crearPDF = new Generador.CreaPDF(cadenaxml, cadenapdfGen, logoempresa2, txtObservaciones.Text, "4.0");


                    DataTable empresat = new DataTable();
                    empresat = Conexion_a_BD.Consultasql("*", "empresa", "cnombre limit 1");
                   


                }


                LimpiarDatos();



            }
            catch (Exception exvc)
            {
                MessageBox.Show(exvc.Message);
                LimpiarDatos();
            }

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

        public static void EscribeEnArchivo(string contenido, string rutaArchivo, bool sobrescribir = true)
        {
           

            using (FileStream fs = System.IO.File.Create(rutaArchivo))
            {
                byte[] bdata = Encoding.Default.GetBytes(contenido);
                fs.Write(bdata, 0, bdata.Length);
                fs.Close();
            }

        }



        private void btncargar_Click(object sender, EventArgs e)
        {
            String filtromysql = " RECIBOMAESTRO.FECHA>='" + DTPfechainicio.Value.ToString("yyyy-MM-dd") + "' AND FECHA<='" + this.DTPfechafinal.Value.ToString("yyyy-MM-dd") + "' ";
            txtObservaciones.Text = " RECIBOS DE IMPUESTO PREDIAL DEL DIA " + DTPfechainicio.Value.ToString("dd-MM-yyy") + " AL DIA " + this.DTPfechafinal.Value.ToString("dd-MM-yyyy");
            try
            {
              
                Conexion_a_BD.Conectar();
                Conexion_a_BD.Ejecutar("DROP TABLE IF EXISTs TEMESCLAVO; CREATE TABLE `temesclavo` (`FECHA` date DEFAULT NULL,`CANTIDAD` int(1) NOT NULL DEFAULT '0',  `concepto` varchar(50) NOT NULL DEFAULT '',  `IMPORTE` decimal(43,2) DEFAULT 0, `ImporteSD` decimal(43,2) DEFAULT 0, `partida` varchar(50) DEFAULT 0, unidadsat varchar(20) default 'ACT', clavesat varchar(20) default '93151512',  `llave` int(11) NOT NULL AUTO_INCREMENT,  PRIMARY KEY (`llave`)) ENGINE=InnoDB AUTO_INCREMENT=0;");
               // Conexion_a_BD.Ejecutar("INSERT INTO TEMESCLAVO (FECHA,CANTIDAD,CONCEPTO,IMPORTE,PARTIDA) SELECT FECHA,1,'BANCOS ------->',SUM(IMPORTE*CANTIDAD), ' ' FROM esclavodetalle,recibomaestro where  folio=recibo and recibomaestro.serie=esclavodetalle.serie  and " + filtromysql + " and cancelado<>'C' GROUP BY FECHA");
               // Conexion_a_BD.Ejecutar("insert into TEMESCLAVO (FECHA,CANTIDAD,CONCEPTO,IMPORTE,PARTIDA) select FECHA, 1 AS CANTIDAD,concat('DESCUENTO DEL ',PORCDESCUENTO) AS CONCEPTO , SUM((IMPORTE*CANTIDAD)*(PORCDESCUENTO/100)) ,' '  FROM esclavodetalle,recibomaestro where  folio=recibo and recibomaestro.serie=esclavodetalle.serie  and " + filtromysql + "  and cancelado<>'C' AND PORCDESCUENTO>0  AND (concepto='IMPUESTO PREDIAL URBANO' OR CONCEPTO='IMPUESTO PREDIAL RUSTICO' OR CONCEPTO='IMPUESTO PREDIAL EJIDAL') GROUP BY FECHA,PORCDESCUENTO");
               // Conexion_a_BD.Ejecutar("INSERT INTO TEMESCLAVO (FECHA,CANTIDAD,CONCEPTO,IMPORTE,PARTIDA)  SELECT  FECHA ,1 AS CANTIDAD, ' TOTAL ---->',SUM(IMPORTE*CANTIDAD) , ' ' FROM TEMESCLAVO GROUP BY FECHA");
                Conexion_a_BD.Ejecutar("INSERT INTO TEMESCLAVO (FECHA,CANTIDAD,CONCEPTO,IMPORTE,ImporteSD, PARTIDA,unidadsat,clavesat) SELECT FECHA, 1 , UCASE(CONCEPTO), SUM(IMPORTE),SUM(MONTOSINDESCUENTO),  PARTIDA,unidadsat, clavesat FROM esclavodetalle,recibomaestro where  folio=recibo and recibomaestro.serie=esclavodetalle.serie  and " + filtromysql + " and cancelado<>'C' and recibomaestro.facturado=0  GROUP BY FECHA,CONCEPTO ");
             //   Conexion_a_BD.Ejecutar("INSERT INTO TEMESCLAVO (FECHA,CANTIDAD,CONCEPTO,IMPORTE,PARTIDA) SELECT FECHA, 1 , CONCEPTO, SUM((MONTOSINDESCUENTO),  PARTIDA FROM esclavodetalle,recibomaestro where  folio=recibo and recibomaestro.serie=esclavodetalle.serie  and " + filtromysql + " and cancelado<>'C' AND (concepto='IMPUESTO PREDIAL URBANO' OR CONCEPTO='IMPUESTO PREDIAL RUSTICO' OR CONCEPTO='IMPUESTO PREDIAL EJIDAL') GROUP BY FECHA,CONCEPTO ");
              //  Conexion_a_BD.Ejecutar("INSERT INTO TEMESCLAVO (FECHA,CANTIDAD,CONCEPTO,IMPORTE,PARTIDA) SELECT FECHA, 1 , CONCEPTO, SUM(IMPORTE*CANTIDAD),  PARTIDA FROM esclavodetalle,recibomaestro where  folio=recibo and recibomaestro.serie=esclavodetalle.serie  and " + filtromysql + " and cancelado<>'C' AND (concepto<>'IMPUESTO PREDIAL URBANO' AND CONCEPTO<>'IMPUESTO PREDIAL RUSTICO' AND CONCEPTO<>'IMPUESTO PREDIAL EJIDAL') GROUP BY FECHA,CONCEPTO ");

                Conexion_a_BD.Desconectar();
            }
            catch (Exception ex)
            {
            }
            try
            {
                Conexion_a_BD.Conectar();
                DTGdetalles.DataSource = Conexion_a_BD.Consultasql(" CANTIDAD, CONCEPTO, IMPORTE, ImporteSD, unidadsat, clavesat ", " TEMESCLAVO GROUP BY CONCEPTO");
                DTGdetalles.Columns[0].Width = 80;
                DTGdetalles.Columns[1].Width = 400;
                DTGdetalles.Columns[2].Width = 150;
                DTGdetalles.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Conexion_a_BD.Desconectar();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
            try
            {
                Conexion_a_BD.Conectar();

                DataTable datototal = Conexion_a_BD.Consultasql(" SUM(CANTIDAD*ImporteSD) AS total", " TEMESCLAVO");
                Conexion_a_BD.Desconectar();

                double.TryParse( datototal.Rows[0]["total"].ToString(), out subtotal);

                Conexion_a_BD.Conectar();

                DataTable datodescuento = Conexion_a_BD.Consultasql(" SUM(MONtOSINDESCUENTO-(CANTIDAD*IMPORTE)) as descuento " ," esclavodetalle,recibomaestro where  folio=recibo and recibomaestro.serie=esclavodetalle.serie and recibomaestro.facturado=0  and " + filtromysql + "  and cancelado<>'C'   ");
                Conexion_a_BD.Desconectar();

                
                double.TryParse(datodescuento.Rows[0]["descuento"].ToString(), out descuento);
                descuento = Math.Round(descuento,2);
                total = Math.Round(subtotal - descuento,2);
                subtotal = Math.Round(subtotal, 2);
                lblsubtotal.Text = subtotal.ToString();
                descuento = Math.Round(descuento, 2);
                lbldescuento.Text = descuento.ToString();
                lblTotal.Text = Math.Round(total, 2).ToString();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }


           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void labelX7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmFacturadeldia_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'predialchicoDataSet.fpago' table. You can move, or remove it, as needed.
            this.fpagoTableAdapter.Fill(this.predialchicoDataSet.fpago);
            CMBFORMADEPAGO.SelectedIndex = 0;
        }

        // donde quieres meter el logo

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }

        public MySqlConnection GetNewConnection()
        {
            var conn = new MySqlConnection(Predial10.Properties.Settings.Default.predialchicoConnectionString);
            conn.Open();
            return conn;
        }

        public static byte[] GetPhoto(string logo)
        {
            FileStream stream = new FileStream(logo, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);

            byte[] photo = reader.ReadBytes((int)stream.Length);

            reader.Close();
            stream.Close();

            return photo;
        }

        public void LimpiarDatos()
        {

            descuento = 0.0;
            total = 0.0;
            subtotal = 0.0;
            lblsubtotal.Text = "";
            descuento = 0.0;
            lbldescuento.Text = "";
            lblTotal.Text = "";
            DTGdetalles.Rows.Clear();

        }
    }

}
