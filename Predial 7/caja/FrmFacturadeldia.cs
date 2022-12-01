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
                    try
                    {
                       

                        EscribeEnArchivo(respuesta.CFDI, cadenaxml, true);
                    }
                    catch (Exception err)
                    {
                        string mensajedeerror = err.Message;
                    }


                    //Byte[] info = new UTF8Encoding(true).GetBytes(respuesta.CFDI.ToString().TrimStart());
                    //fs.Write(info, 0, info.Length);
                    //fs.Close();





                    //System.Drawing.Image imagen = factu.qrdatos(cadenaxml);




                   







                    DataSet datos = new DataSet();
                    datos.ReadXml(cadenaxml);


                    byte[] logoempresa = Conexion_a_BD.obtenerimagen("select logo from empresa");

                    System.Drawing.Image logoempresa2 = byteArrayToImage(logoempresa);

                    String cadenapdf2 = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\facturasPublicoPredial\\" + Date).Trim();

                    if (!Directory.Exists(cadenapdf2))
                    {

                        DirectoryInfo di = Directory.CreateDirectory(cadenapdf2);

                    }

                    String cadenapdfGen = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\facturasPublicoPredial\\" + Date + "\\FACTURA" + seriefactura + numerofactura + ".PDF").Trim();

                    Generador.CreaPDF crearPDF = new Generador.CreaPDF(cadenaxml, cadenapdfGen, logoempresa2, txtObservaciones.Text);


                    DataTable empresat = new DataTable();
                    empresat = Conexion_a_BD.Consultasql("*", "empresa", "cnombre limit 1");
                    datos.Tables.Add(empresat);

                    //Generador.CreaPDF documentox = new Generador.CreaPDF(respuesta.CFDI, cadenapdf, null, txtObservaciones.Text);
                    //decimal descuentocfdi = decimal.Parse(documentox._templatePDF.descuento.ToString());




                    // //Rutina para generar factura itextsharp
                    // DateTime fechaActual = DateTime.Today;
                    // String logo;
                    // Byte[] LOGOEMPRESA;


                    // //No tiene funcionamiento estas lineas de código
                    // var directoriopdfFDia = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\facturasItext\\" + fechaActual.Year + fechaActual.Month.ToString().Trim());

                    // if (!Directory.Exists(directoriopdfFDia))
                    // {

                    //     DirectoryInfo di = Directory.CreateDirectory(directoriopdfFDia);

                    // }

                    // //Hasta aqui

                    // //String cadenapdfItext = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\facturasItext\\" + fechaActual.Year + fechaActual.Month.ToString() + /*seriefactura + numerofactura */ "Prueba2" + ".PDF").Trim();
                    // //Aqui comienza factura con ItextSharp


                    // Document facturaITS = new Document(iTextSharp.text.PageSize.LETTER, 5f, 5f, 5, 5);

                    // //String cadenapdf = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\facturas\\" + /*seriefactura + numerofactura*/ "Prueba" + ".PDF").Trim();
                    // //Dim pdfWrite4 As PdfWriter = PdfWriter.GetInstance(pdfDoc, New System.IO.FileStream(cadenafolderDocNombres & "\factura" & seriefactura & foliofactura & ".pdf", FileMode.Create))
                    // PdfWriter PdfWrite = PdfWriter.GetInstance(facturaITS, new System.IO.FileStream(cadenapdf, FileMode.Create));

                    // //BaseFont _fuente1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                    // //BaseFont _fuenteContenido = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                    // iTextSharp.text.Font _FuenteTitulos = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                    // iTextSharp.text.Font _FuenteContenido = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                    // iTextSharp.text.Font _FuenteSellos = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 5, iTextSharp.text.Font.ITALIC, BaseColor.BLACK);
                    // iTextSharp.text.Font _FuenteConceptos = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7, iTextSharp.text.Font.ITALIC, BaseColor.WHITE);



                    // facturaITS.Open();

                    // //DataTable TBL_ConsultaIma = new DataTable();
                    // //Conexion_a_BD.Conectar();
                    // //TBL_ConsultaIma = Conexion_a_BD.Consultasql("logo", "empresa");
                    // //Conexion_a_BD.Desconectar();
                    // //var resultadoIma = from myRow in TBL_ConsultaIma.AsEnumerable() select myRow;

                    // //DataView view1 = resultadoIma.AsDataView();

                    // //logo = view1[0]["LOGO"].ToString();
                    // //LOGOEMPRESA = Encoding.ASCII.GetBytes(logo);

                    // //ImageData data = ImageDataFactory.create(imageFile);




                    // //var res = from myRow in TBL_ConsultaIma.AsEnumerable() select myRow;
                    // //Query.Connection = ConexionBBDD.obtenerConexion();
                    // //Query.CommandText = "SELECT avatar FROM usuarios WHERE NombreUsuario = '" + UOn.getNombre() + "'";
                    // //consultar = Query.ExecuteReader();
                    // //if (consultar.Read())
                    // //{
                    // //    byte[] avatarByte = (byte[])consultar["avatar"];
                    // //    return avatarByte;
                    // //}
                    // //byte[] LOGOEMPRESA = (byte[])ObtenerLogo;
                    // //imgArr = (byte[])cmd.ExecuteScalar();

                    // DataTable DatosEmpresa = new DataTable();
                    // String CNomEmp = "";
                    // String CDirEmp = "";
                    // String CColEmp = "";
                    // String CCodEmp = "";
                    // String CProEmp = "";
                    // String CPaisEmp = "";
                    // String CPobEmp = "";



                    // String CCnifEmp = "";
                    // Conexion_a_BD.Conectar();
                    // TBL_Consulta = Conexion_a_BD.Consultasql("CNOMBRE, CDOMICILIO, CCOLONIA, CCODPOS, CPOBLACION, CNIF", "empresa");





                    // try
                    // {
                    //     DataTable tabla = new DataTable();
                    //     Conexion_a_BD.Conectar();
                    //     tabla = Conexion_a_BD.Consultasql("*", "Empresa");
                    //     CNomEmp = tabla.Rows[0]["CNOMBRE"].ToString();
                    //     CDirEmp = tabla.Rows[0]["CDOMICILIO"].ToString();
                    //     CColEmp = tabla.Rows[0]["CCOLONIA"].ToString();
                    //     CPobEmp = tabla.Rows[0]["CPOBLACION"].ToString();
                    //     CProEmp = tabla.Rows[0]["CPROVINCIA"].ToString();
                    //     CPaisEmp = "MÉXICO";
                    //     CCodEmp = tabla.Rows[0]["CCODPOS"].ToString();
                    //     CCnifEmp = tabla.Rows[0]["CNIF"].ToString();
                    //     //txtEmail.Text = tabla.Rows[0]["CEMAIL"].ToString();

                    //     Conexion_a_BD.Desconectar();
                    // }
                    // catch (Exception ex)
                    // {
                    //     MessageBox.Show(ex.Message);
                    // }




                    // //IDataReader emp = Conexion_a_BD.Consultasql("CNOMBRE, CDOMICILIO, CCOLONIA, CCODPOS, CPOBLACION, CNIF", "empresa");
                    // //Conexion_a_BD.Desconectar();
                    // //var resultadoEmp = from myRow in TBL_Consulta.AsEnumerable() select myRow;
                    // //try
                    // //{

                    // //    DataView view = resultadoEmp.AsDataView();

                    // //    CNomEmp = view[0]["CNOMBRE"].ToString();
                    // //    //CDirEmp = view[1]["CDOMICILIO"].ToString();
                    // //    //CColEmp = view[2]["CCOLONIA"].ToString();
                    // //    //CCodEmp = view[3]["CCODPOS"].ToString();
                    // //    //CPobEmp = view[4]["CPOBLACION"].ToString();
                    // //    //CCnifEmp = view[5]["CNIF"].ToString();

                    // ////    TBL_Consulta
                    // ////RutaImagenes = emp("Rutaimagenes")
                    // ////Empresa = emp("cnombre")
                    // //}
                    // //catch (Exception x)
                    // //{

                    // //    MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // //}





                    // //Aqui voy a formar el recuadro para adormar la factura 
                    // PdfContentByte cb;





                    // //tablaDatosEmisorReceptor.SpacingBefore = 5;
                    // //tablaDatosEmisorReceptor.HorizontalAlignment = Element.ALIGN_LEFT;
                    // //tablaDatosEmisorReceptor.LockedWidth = true;

                    // //using (MemoryStream memstr = new MemoryStream(LOGOEMPRESA))
                    // //{
                    // //    System.Drawing.Image img = System.Drawing.Image.FromStream(memstr);

                    // //}

                    // //iTextSharp.text.Image imagenLogo = iTextSharp.text.Image.GetInstance(img);
                    // //imagenLogo.ScaleAbsoluteWidth(480);
                    // //imagenLogo.ScaleAbsoluteHeight(270);


                    // //Aqui comenzare a formar las tablas con sus filas y columnas
                    // //PdfPTable tableEncabezado = new PdfPTable(2);
                    // //float[] widths = new float[] { 7f, 0.5f};

                    // //tableEncabezado.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    // //tableEncabezado.SetTotalWidth(widths);

                    // //Tabla Vacia
                    // PdfPTable TabVacio = new PdfPTable(1);
                    // float[] widthsVacio = new float[] { 1000f};

                    // TabVacio.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    // TabVacio.SetTotalWidth(widthsVacio);

                    // PdfPCell CelVacia = new PdfPCell(new Phrase(" ", _FuenteContenido));
                    // CelVacia.Rowspan = 2;
                    // CelVacia.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelVacia.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    // CelVacia.Border = 0;
                    // TabVacio.AddCell(CelVacia);


                    // PdfPTable TableDEncabezado = new PdfPTable(2);
                    // float[] widths = new float[] { 800f, 200f };

                    // TableDEncabezado.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    // TableDEncabezado.SetTotalWidth(widths);



                    // PdfPTable TableDireccion = new PdfPTable(1);
                    // PdfPCell CelNombre = new PdfPCell(new Phrase(CNomEmp, _FuenteTitulos));
                    // CelNombre.Rowspan = 2;
                    // CelNombre.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelNombre.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    // CelNombre.Border = 0;


                    // PdfPCell CelDirEmpresa = new PdfPCell(new Phrase(CDirEmp, _FuenteTitulos));
                    // CelDirEmpresa.Rowspan = 2;
                    // CelDirEmpresa.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelDirEmpresa.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    // CelDirEmpresa.Border = 0;

                    // PdfPCell CelColEmpresa = new PdfPCell(new Phrase(CColEmp + ", " + CCodEmp, _FuenteTitulos));
                    // CelColEmpresa.Rowspan = 2;
                    // CelColEmpresa.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelColEmpresa.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    // CelColEmpresa.Border = 0;

                    // PdfPCell CelPobEmpresa = new PdfPCell(new Phrase(CPobEmp + " DE HINOJOSA, " + CProEmp + ", " + CPaisEmp, _FuenteTitulos));
                    // CelPobEmpresa.Rowspan = 2;
                    // CelPobEmpresa.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelPobEmpresa.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    // CelPobEmpresa.Border = 0;


                    // PdfPCell CelCnifEmpresa = new PdfPCell(new Phrase(CCnifEmp, _FuenteTitulos));
                    // CelCnifEmpresa.Rowspan = 2;
                    // CelCnifEmpresa.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelCnifEmpresa.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    // CelCnifEmpresa.Border = 0;

                    // TableDireccion.AddCell(CelNombre);
                    // TableDireccion.AddCell(CelDirEmpresa);
                    // TableDireccion.AddCell(CelColEmpresa);
                    // TableDireccion.AddCell(CelPobEmpresa);
                    // TableDireccion.AddCell(CelCnifEmpresa);





                    // //DataTable tabla = new DataTable();
                    // //Conexion_a_BD.Conectar();



                    // //tabla = Conexion_a_BD.Consultasql("logo", "Empresa");
                    // //logoempresa = (byte[])tabla.Rows[0]["logo"].ToString;

                    // //String LOGO = Conexion_a_BD.obtenercampo("select logo from empresa");
                    // //logoempresa = LOGO.Rows[0]["CNOMBRE"].ToString();
                    // ////string logo1 = LOGO;




                    // //Conexion_a_BD.Desconectar();
                    // //System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                    // //Byte[] bytesImagen = Encoding.GetEncoding(28591).GetBytes(logo1);


                    // ////Convertir arreglo a imágen

                    // //MemoryStream ms = new MemoryStream(bytesImagen);

                    // // obtenemos el logo de mysql en byte[]   22/03/2001 Uziel e Israel

                    // byte[] logoempresa = Conexion_a_BD.obtenerimagen("select logo from empresa");



                    //// lo convertimos a imagen y de imagen a itext.image

                    // System.Drawing.Image logoempresa2 = byteArrayToImage(logoempresa);

                    // iTextSharp.text.Image imagenBMP = iTextSharp.text.Image.GetInstance(logoempresa2, System.Drawing.Imaging.ImageFormat.Jpeg);



                    // TableDEncabezado.AddCell(TableDireccion);

                    // TableDEncabezado.AddCell(imagenBMP);




                    // //Tabla Información de dirección y datos fiscales

                    // PdfPTable TableDFiscales = new PdfPTable(2);
                    // float[] widthsDF = new float[] { 400f, 600f};

                    // TableDFiscales.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    // TableDFiscales.SetTotalWidth(widthsDF);

                    // PdfPTable TabDF1 = new PdfPTable(1);
                    // float[] widthsD1F = new float[] { 700f };

                    // TabDF1.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    // TabDF1.SetTotalWidth(widthsD1F);

                    // PdfPCell CelNomDFNom = new PdfPCell(new Phrase("Nombre: " + txtNombre.Text, _FuenteContenido));
                    // CelNomDFNom.Rowspan = 2;
                    // CelNomDFNom.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelNomDFNom.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    // CelNomDFNom.Border = 0;
                    // TabDF1.AddCell(CelNomDFNom);

                    // PdfPCell CelNomDFDir = new PdfPCell(new Phrase("Dirección: " + txtCalle.Text, _FuenteContenido));
                    // CelNomDFDir.Rowspan = 2;
                    // CelNomDFDir.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelNomDFDir.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    // CelNomDFDir.Border = 0;
                    // TabDF1.AddCell(CelNomDFDir);

                    // PdfPCell CelNomDFCol = new PdfPCell(new Phrase("Colonia: " + CColEmp, _FuenteContenido));
                    // CelNomDFCol.Rowspan = 2;
                    // CelNomDFCol.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelNomDFCol.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    // CelNomDFCol.Border = 0;
                    // TabDF1.AddCell(CelNomDFCol);

                    // PdfPCell CelNomDFCiu = new PdfPCell(new Phrase("Ciudad: " + CPobEmp + "DE HINOJOSA", _FuenteContenido));
                    // CelNomDFCiu.Rowspan = 2;
                    // CelNomDFCiu.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelNomDFCiu.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    // CelNomDFCiu.Border = 0;
                    // TabDF1.AddCell(CelNomDFCiu);

                    // PdfPCell CelNomDFRFCC = new PdfPCell(new Phrase(txtRFC.Text, _FuenteContenido));
                    // CelNomDFRFCC.Rowspan = 2;
                    // CelNomDFRFCC.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelNomDFRFCC.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    // CelNomDFRFCC.Border = 0;
                    // TabDF1.AddCell(CelNomDFRFCC);




                    // //Table 2 Cuerpo

                    // PdfPTable TabDF2 = new PdfPTable(2);
                    // float[] widthsDF2 = new float[] { 400f, 600f };

                    // TableDFiscales.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    // TableDFiscales.SetTotalWidth(widthsDF2);

                    // PdfPCell CelDF2UUID = new PdfPCell(new Phrase("UUID: ", _FuenteContenido));
                    // CelDF2UUID.Rowspan = 2;
                    // CelDF2UUID.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelDF2UUID.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    // CelDF2UUID.Border= 0;
                    // TabDF2.AddCell(CelDF2UUID);

                    // PdfPCell CelDF2UUIDR = new PdfPCell(new Phrase(respuesta.UUID, _FuenteContenido));
                    // CelDF2UUIDR.Rowspan = 2;
                    // CelDF2UUIDR.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelDF2UUIDR.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    // CelDF2UUIDR.Border = 0;
                    // TabDF2.AddCell(CelDF2UUIDR);

                    // PdfPCell CelDF2Factura = new PdfPCell(new Phrase("Factura: ", _FuenteContenido));
                    // CelDF2Factura.Rowspan = 2;
                    // CelDF2Factura.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelDF2Factura.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    // CelDF2Factura.Border = 0;
                    // TabDF2.AddCell(CelDF2Factura);

                    // PdfPCell CelDF2FacturaR = new PdfPCell(new Phrase(seriefactura + numerofactura, _FuenteContenido));
                    // CelDF2FacturaR.Rowspan = 2;
                    // CelDF2FacturaR.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelDF2FacturaR.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    // CelDF2FacturaR.Border = 0;
                    // TabDF2.AddCell(CelDF2FacturaR);

                    // PdfPCell CelDF2FechaC = new PdfPCell(new Phrase("Fecha de comprobante: ", _FuenteContenido));
                    // CelDF2FechaC.Rowspan = 2;
                    // CelDF2FechaC.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelDF2FechaC.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    // CelDF2FechaC.Border = 0;
                    // TabDF2.AddCell(CelDF2FechaC);

                    // PdfPCell CelDF2FechaCR = new PdfPCell(new Phrase(respuesta.FechaTimbrado.ToString(), _FuenteContenido));
                    // CelDF2FechaCR.Rowspan = 2;
                    // CelDF2FechaCR.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelDF2FechaCR.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    // CelDF2FechaCR.Border = 0;
                    // TabDF2.AddCell(CelDF2FechaCR);

                    // PdfPCell CelV = new PdfPCell(new Phrase(" ", _FuenteContenido));
                    // CelV.Rowspan = 2;
                    // CelV.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelV.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    // CelV.Border = 0;
                    // TabDF2.AddCell(CelV);

                    // PdfPCell CelV2 = new PdfPCell(new Phrase(" ", _FuenteContenido));
                    // CelV2.Rowspan = 2;
                    // CelV2.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelV2.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    // CelV2.Border = 0;
                    // TabDF2.AddCell(CelV2);

                    // PdfPCell CelDF2Certificado = new PdfPCell(new Phrase("No. Serie Certificado SAT: ", _FuenteContenido));
                    // CelDF2Certificado.Rowspan = 2;
                    // CelDF2Certificado.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelDF2Certificado.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    // CelDF2Certificado.Border = 0;
                    // TabDF2.AddCell(CelDF2Certificado);

                    // PdfPCell CelDF2CertificadoR = new PdfPCell(new Phrase(respuesta.NoCertificado, _FuenteContenido));
                    // CelDF2CertificadoR.Rowspan = 2;
                    // CelDF2CertificadoR.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelDF2CertificadoR.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    // CelDF2CertificadoR.Border = 0;
                    // TabDF2.AddCell(CelDF2CertificadoR);

                    // PdfPCell CelDF2MPago = new PdfPCell(new Phrase("Método de pago: ", _FuenteContenido));
                    // CelDF2MPago.Rowspan = 2;
                    // CelDF2MPago.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelDF2MPago.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    // CelDF2MPago.Border = 0;
                    // TabDF2.AddCell(CelDF2MPago);

                    // PdfPCell CelDF2MPagoR = new PdfPCell(new Phrase("PUE", _FuenteContenido));
                    // CelDF2MPagoR.Rowspan = 2;
                    // CelDF2MPagoR.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelDF2MPagoR.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    // CelDF2MPagoR.Border = 0;
                    // TabDF2.AddCell(CelDF2MPagoR);

                    // PdfPCell CelDF2FPago = new PdfPCell(new Phrase("Forma de pago: ", _FuenteContenido));
                    // CelDF2FPago.Rowspan = 2;
                    // CelDF2FPago.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelDF2FPago.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    // CelDF2FPago.Border = 0;
                    // TabDF2.AddCell(CelDF2FPago);

                    // PdfPCell CelDF2FPagoR = new PdfPCell(new Phrase(CMBFORMADEPAGO.SelectedValue.ToString(), _FuenteContenido));
                    // CelDF2FPagoR.Rowspan = 2;
                    // CelDF2FPagoR.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelDF2FPagoR.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    // CelDF2FPagoR.Border = 0;
                    // TabDF2.AddCell(CelDF2FPagoR);

                    // TableDFiscales.AddCell(TabDF1);
                    // TableDFiscales.AddCell(TabDF2);

                    // CelV = new PdfPCell(new Phrase(" ", _FuenteContenido));
                    // CelV.Rowspan = 2;
                    // CelV.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelV.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    // CelV.Border = 0;
                    // TabDF2.AddCell(CelV);

                    // CelV2 = new PdfPCell(new Phrase(" ", _FuenteContenido));
                    // CelV2.Rowspan = 2;
                    // CelV2.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelV2.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    // CelV2.Border = 0;
                    // TabDF2.AddCell(CelV2);



                    // //Table Conceptos

                    // ClsColoresReporte colorReporte;
                    // //colorReporte.ClsColoresReporte(My.Settings.colorfactura);

                    // PdfPTable TabConceptos = new PdfPTable(6);
                    // float[] widthsCconceptos = new float[] { 100f, 100f, 500f, 150f, 150f, 150f};

                    // TabConceptos.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    // TabConceptos.SetTotalWidth(widthsCconceptos);

                    // PdfPCell CelConcepCant = new PdfPCell(new Phrase("Cantidad", _FuenteConceptos));
                    // CelConcepCant.Rowspan = 2;
                    // CelConcepCant.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelConcepCant.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    // CelConcepCant.Border = 7;
                    // CelConcepCant.BackgroundColor = new iTextSharp.text.BaseColor(173, 60, 49);
                    // TabConceptos.AddCell(CelConcepCant);

                    // PdfPCell CelConcepUnidad = new PdfPCell(new Phrase("Unidad", _FuenteConceptos));
                    // CelConcepUnidad.Rowspan = 2;
                    // CelConcepUnidad.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelConcepUnidad.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    // CelConcepUnidad.Border = 3;
                    // CelConcepUnidad.BackgroundColor = new iTextSharp.text.BaseColor(173, 60, 49);
                    // TabConceptos.AddCell(CelConcepUnidad);

                    // PdfPCell CelConcepDesc = new PdfPCell(new Phrase("Descripción", _FuenteConceptos));
                    // CelConcepDesc.Rowspan = 2;
                    // CelConcepDesc.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelConcepDesc.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    // CelConcepDesc.Border = 3;
                    // CelConcepDesc.BackgroundColor = new iTextSharp.text.BaseColor(173, 60, 49);
                    // TabConceptos.AddCell(CelConcepDesc);

                    // PdfPCell CelConcepPrecU = new PdfPCell(new Phrase("Precio Unitario", _FuenteConceptos));
                    // CelConcepPrecU.Rowspan = 2;
                    // CelConcepPrecU.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelConcepPrecU.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    // CelConcepPrecU.Border = 3;
                    // CelConcepPrecU.BackgroundColor = new iTextSharp.text.BaseColor(173, 60, 49);
                    // TabConceptos.AddCell(CelConcepPrecU);

                    // PdfPCell CelConcepDes = new PdfPCell(new Phrase("Descuento", _FuenteConceptos));
                    // CelConcepDes.Rowspan = 2;
                    // CelConcepDes.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelConcepDes.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    // CelConcepDes.Border = 3;
                    // CelConcepDes.BackgroundColor = new iTextSharp.text.BaseColor(173, 60, 49);
                    // TabConceptos.AddCell(CelConcepDes);

                    // PdfPCell CelConcepImporte = new PdfPCell(new Phrase("Importe", _FuenteConceptos));
                    // CelConcepImporte.Rowspan = 2;
                    // CelConcepImporte.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelConcepImporte.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    // CelConcepImporte.Border = 11;
                    // CelConcepImporte.BackgroundColor = new iTextSharp.text.BaseColor(173, 60, 49);
                    // TabConceptos.AddCell(CelConcepImporte);

                    // //Cargar la tabla conceptos




                    // try
                    // {

                    //     Conexion_a_BD.Conectar();
                    //     DataTable datosconcepto = Conexion_a_BD.Consultasql(" CANTIDAD, UNIDADSAT, CONCEPTO, ImporteSD, IMPORTE ", " temesclavo GROUP BY CONCEPTO");

                    //     //CNomEmp = datosconcepto.Columns[0][0]["CNOMBRE"].ToString();
                    //     //datosconcepto.Rows[i]["CANTIDAD"].ToString();

                    //     for (int i = 0; i < datosconcepto.Rows.Count; i++)
                    //     {

                    //         CelConcepCant = new PdfPCell(new Phrase(datosconcepto.Rows[i]["CANTIDAD"].ToString(), _FuenteContenido));
                    //         CelConcepCant.Rowspan = 2;
                    //         CelConcepCant.VerticalAlignment = Element.ALIGN_LEFT;
                    //         CelConcepCant.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    //         CelConcepCant.Border = 2;
                    //         TabConceptos.AddCell(CelConcepCant);

                    //         CelConcepUnidad = new PdfPCell(new Phrase(datosconcepto.Rows[i]["UNIDADSAT"].ToString(), _FuenteContenido));
                    //         CelConcepUnidad.Rowspan = 2;
                    //         CelConcepUnidad.VerticalAlignment = Element.ALIGN_LEFT;
                    //         CelConcepUnidad.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right       
                    //         CelConcepUnidad.Border = 1;
                    //         TabConceptos.AddCell(CelConcepUnidad);

                    //         CelConcepDesc = new PdfPCell(new Phrase(datosconcepto.Rows[i]["CONCEPTO"].ToString(), _FuenteContenido));
                    //         CelConcepDesc.Rowspan = 2;
                    //         CelConcepDesc.VerticalAlignment = Element.ALIGN_LEFT;
                    //         CelConcepDesc.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    //         CelConcepDesc.Border = 2;
                    //         TabConceptos.AddCell(CelConcepDesc);




                    //         decimal ImporteSD = Convert.ToDecimal(datosconcepto.Rows[i]["ImporteSD"].ToString());

                    //         //txtMostrarValor.Text = valdec.ToString("N2");
                    //         CelConcepPrecU = new PdfPCell(new Phrase(ImporteSD.ToString("C"), _FuenteContenido));
                    //         CelConcepPrecU.Rowspan = 2;
                    //         CelConcepPrecU.VerticalAlignment = Element.ALIGN_LEFT;
                    //         CelConcepPrecU.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    //         CelConcepPrecU.Border = 2;
                    //         TabConceptos.AddCell(CelConcepPrecU);

                    //         // utilizaresmos descuentocfdi
                    //         CelConcepDes = new PdfPCell(new Phrase(descuentocfdi.ToString("C"), _FuenteContenido));
                    //         CelConcepDes.Rowspan = 2;
                    //         CelConcepDes.VerticalAlignment = Element.ALIGN_LEFT;
                    //         CelConcepDes.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    //         CelConcepDes.Border = 2;
                    //         TabConceptos.AddCell(CelConcepDes);


                    //         decimal Importe = Convert.ToDecimal(datosconcepto.Rows[i]["IMPORTE"].ToString());
                    //         CelConcepImporte = new PdfPCell(new Phrase(Importe.ToString("C"), _FuenteContenido));
                    //         CelConcepImporte.Rowspan = 2;
                    //         CelConcepImporte.VerticalAlignment = Element.ALIGN_LEFT;
                    //         CelConcepImporte.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    //         CelConcepImporte.Border = 2;
                    //         TabConceptos.AddCell(CelConcepImporte);

                    //     }

                    //     DataTableReader datoscon = new DataTableReader(datosconcepto);


                    // }
                    // catch (Exception EX)
                    // {
                    //     MessageBox.Show(EX.Message);
                    // }

                    // Conexion_a_BD.Desconectar();




                    // // Tabla Subtotal y Cantidad con letra

                    // PdfPTable TabCantSubtotal = new PdfPTable(3);
                    // float[] widthsCantSub = new float[] { 700f, 150f, 150f };

                    // TabCantSubtotal.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    // TabCantSubtotal.SetTotalWidth(widthsCantSub);


                    // clsconv let = new clsconv();
                    // string mensaje = let.enletras(total.ToString());
                    // PdfPCell CelCantLetra = new PdfPCell(new Phrase(mensaje, _FuenteContenido));
                    // CelCantLetra.Rowspan = 2;
                    // CelCantLetra.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelCantLetra.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    // CelCantLetra.Border = 1;
                    // TabCantSubtotal.AddCell(CelCantLetra);

                    // PdfPCell CelSub = new PdfPCell(new Phrase("Subtotal", _FuenteContenido));
                    // CelSub.Rowspan = 2;
                    // CelSub.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelSub.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    // CelSub.Border = 1;
                    // TabCantSubtotal.AddCell(CelSub);

                    // decimal Subtotal = Convert.ToDecimal(subtotal.ToString());
                    // PdfPCell CelSubtotal = new PdfPCell(new Phrase(Subtotal.ToString("C"), _FuenteContenido));
                    // CelSubtotal.Rowspan = 2;
                    // CelSubtotal.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelSubtotal.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    // CelSubtotal.Border = 3;
                    // TabCantSubtotal.AddCell(CelSubtotal);


                    // PdfPCell CelVac = new PdfPCell(new Phrase(" ", _FuenteContenido));
                    // CelVac.Rowspan = 2;
                    // CelVac.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelVac.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    // CelVac.Border = 0;
                    // TabCantSubtotal.AddCell(CelVac);

                    // PdfPCell CelDescuento = new PdfPCell(new Phrase("Descuento", _FuenteContenido));
                    // CelDescuento.Rowspan = 2;
                    // CelDescuento.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelDescuento.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    // CelDescuento.Border = 1;
                    // TabCantSubtotal.AddCell(CelDescuento);

                    // decimal Descuento = Convert.ToDecimal(descuento.ToString());
                    // PdfPCell CelDescuentoR = new PdfPCell(new Phrase(Descuento.ToString("C"), _FuenteContenido));
                    // CelDescuentoR.Rowspan = 2;
                    // CelDescuentoR.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelDescuentoR.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    // CelDescuentoR.Border = 1;
                    // TabCantSubtotal.AddCell(CelDescuentoR);

                    // PdfPCell CelNota = new PdfPCell(new Phrase(txtObservaciones.Text.ToString(), _FuenteContenido));
                    // CelNota.Rowspan = 2;
                    // CelNota.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelNota.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    // CelNota.Border = 0;
                    // TabCantSubtotal.AddCell(CelNota);

                    // PdfPCell CelTot = new PdfPCell(new Phrase("Total", _FuenteContenido));
                    // CelTot.Rowspan = 2;
                    // CelTot.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelTot.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    // CelTot.Border = 1;
                    // TabCantSubtotal.AddCell(CelTot);

                    // decimal Total = Convert.ToDecimal(total.ToString());
                    // PdfPCell CelTotal = new PdfPCell(new Phrase(Total.ToString("C"), _FuenteContenido));
                    // CelTotal.Rowspan = 2;
                    // CelTotal.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelTotal.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    // CelTotal.Border = 1;
                    // TabCantSubtotal.AddCell(CelTotal);


                    // //Tabla QR y Sellos

                    // PdfPTable TabQRSellos = new PdfPTable(2);
                    // float[] widthsQRSellos = new float[] { 150f, 800f };

                    // TabQRSellos.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    // TabQRSellos.SetTotalWidth(widthsQRSellos);



                    // StringBuilder codigoQR = new StringBuilder();
                    // codigoQR.Append("https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?id=" + documentox._templatePDF.folioFiscalUUID);
                    // codigoQR.Append("&re=" + documentox._templatePDF.emisor.rfc); //RFC del Emisor
                    // codigoQR.Append("&rr=" + documentox._templatePDF.receptor.rfc); //RFC del receptor
                    // codigoQR.Append("&tt=" + documentox._templatePDF.total); //Total del comprobante 10 enteros y 6 decimales
                    // codigoQR.Append("&fe=" + documentox._templatePDF.selloDigitalCFDI.Substring(documentox._templatePDF.selloDigitalCFDI.Length - 8, 8)); //UUID del comprobante

                    // BarcodeQRCode pdfCodigoQR = new BarcodeQRCode(codigoQR.ToString(), 1, 1, null);
                    // iTextSharp.text.Image codeQRImage = pdfCodigoQR.GetImage();
                    // codeQRImage.SpacingAfter = 0.0f;
                    // codeQRImage.SpacingBefore = 0.0f;
                    // codeQRImage.BorderWidth = 1.0f;


                    // codeQRImage.ScaleAbsolute(80,80);


                    // PdfPTable TabQR = new PdfPTable(1);
                    // float[] widthsQR = new float[] { 1000f};

                    // TabQR.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    // TabQR.SetTotalWidth(widthsQR);

                    // PdfPCell CelQR = new PdfPCell(new Phrase(respuesta.PNG64, _FuenteContenido));
                    // CelQR.Rowspan = 2;
                    // CelQR.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelQR.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    // CelQR.Border = 0;
                    // TabQR.AddCell(codeQRImage);

                    // //Tabla Sellos

                    // PdfPTable TabSellos = new PdfPTable(2);
                    // float[] widthsSellos = new float[] { 200f, 800f };

                    // TabSellos.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    // TabSellos.SetTotalWidth(widthsSellos);


                    // PdfPCell CelSelloC = new PdfPCell(new Phrase("Sello CFDI  ", _FuenteContenido));
                    // CelSelloC.Rowspan = 2;
                    // CelSelloC.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelSelloC.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    // CelSelloC.Border = 0;
                    // TabSellos.AddCell(CelSelloC);

                    // PdfPCell CelSelloCFDI = new PdfPCell(new Phrase(respuesta.Sello, _FuenteSellos));
                    // CelSelloCFDI.Rowspan = 2;
                    // CelSelloCFDI.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelSelloCFDI.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    // CelSelloCFDI.Border = 0;
                    // TabSellos.AddCell(CelSelloCFDI);

                    // PdfPCell CelSelloS = new PdfPCell(new Phrase("Sello SAT  ", _FuenteContenido));
                    // CelSelloS.Rowspan = 2;
                    // CelSelloS.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelSelloS.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    // CelSelloS.Border = 0;
                    // TabSellos.AddCell(CelSelloS);

                    // PdfPCell CelSelloSAT = new PdfPCell(new Phrase(respuesta.SelloSAT, _FuenteSellos));
                    // CelSelloSAT.Rowspan = 2;
                    // CelSelloSAT.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelSelloSAT.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    // CelSelloSAT.Border = 0;
                    // TabSellos.AddCell(CelSelloSAT);

                    // PdfPCell CelSelloCad = new PdfPCell(new Phrase("Cadena Original  ", _FuenteContenido));
                    // CelSelloCad.Rowspan = 2;
                    // CelSelloCad.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelSelloCad.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    // CelSelloCad.Border = 0;
                    // TabSellos.AddCell(CelSelloCad);

                    // PdfPCell CelSelloCadenaO = new PdfPCell(new Phrase(respuesta.Cadena, _FuenteSellos));
                    // CelSelloCadenaO.Rowspan = 2;
                    // CelSelloCadenaO.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelSelloCadenaO.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    // CelSelloCadenaO.Border = 0;
                    // TabSellos.AddCell(CelSelloCadenaO);

                    // TabQRSellos.AddCell(TabQR);
                    // TabQRSellos.AddCell(TabSellos);

                    // //Tabla Final
                    // PdfPTable TabFinal = new PdfPTable(1);
                    // float[] widthsFinal = new float[] { 1000f };

                    // TabFinal.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    // TabFinal.SetTotalWidth(widthsFinal);

                    // PdfPCell CelFinal = new PdfPCell(new Phrase("ESTE DOCUMENTO ES UNA REPRESENTACIÓN IMPRESA DE UN CFDI EFECTOS FISCALES AL PAGO", _FuenteContenido));
                    // CelFinal.Rowspan = 2;
                    // CelFinal.VerticalAlignment = Element.ALIGN_LEFT;
                    // CelFinal.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right       
                    // CelFinal.Border = 0;
                    // TabFinal.AddCell(CelFinal);
                    // //PdfPTable Table3 = new PdfPTable(2);
                    // //PdfPCell col2;
                    // //Table3.WidthPercentage = 100;
                    // //float[] widths2 = new float[] { 100f, 100f};
                    // //Table3.SetTotalWidth(widths2);

                    // //PdfPCell clNom = new PdfPCell(new Phrase("Columna 3", _standardFont));
                    // //clNom.Rowspan = 2;
                    // //clNom.VerticalAlignment = Element.ALIGN_MIDDLE;
                    // //clNom.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right            
                    // //Table3.AddCell(clNom);


                    // //col2 = new PdfPCell(new Phrase("###", _standardFont));
                    // //col2.Rowspan = 2;
                    // //col2.VerticalAlignment = Element.ALIGN_MIDDLE;
                    // //col2.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right            
                    // //Table3.AddCell(col2);
                    // //TableDEncabezado.AddCell(Table3);

                    // ////PdfPCell clNombre = new PdfPCell(new Phrase(CNomEmp, _standardFont));
                    // ////clNombre.BorderWidth = 0;
                    // ////clNombre.BorderWidthBottom = 0.75f;
                    // ////TableDEncabezado.AddCell(clNombre);
                    // //tableEncabezado.AddCell(TableDEncabezado);
                    // //facturaITS.Add(imagenLogo);
                    // // tableEncabezado.AddCell(imagenLogo);
                    // //tableEncabezado.AddCell(TableDEncabezado);

                    // facturaITS.Add(TableDEncabezado);
                    // facturaITS.Add(TabVacio);
                    // facturaITS.Add(TableDFiscales);
                    // facturaITS.Add(TabVacio);
                    // facturaITS.Add(TabConceptos);
                    // facturaITS.Add(TabCantSubtotal);
                    // facturaITS.Add(TabVacio);
                    // facturaITS.Add(TabVacio);
                    // facturaITS.Add(TabQRSellos);
                    // facturaITS.Add(TabVacio);
                    // facturaITS.Add(TabVacio);
                    // facturaITS.Add(TabFinal);


                    // facturaITS.Close();
                    // PdfWrite.Close();




                    // //Termina rutina ItextSharp


                    // //ReportDocument factura = new ReportDocument();
                    // //factura.Load(Application.StartupPath + "\\reportes\\factura.rpt");
                    // //factura.SetDataSource(datos);
                    // //factura.SetParameterValue("nombre", txtNombre.Text);
                    // //factura.SetParameterValue("direccion", txtCalle.Text + " "+txtNoExterior.Text+" " + txtNoInterior.Text);
                    // //factura.SetParameterValue("Fechatimbrado", respuesta.FechaTimbrado.ToString());
                    // //factura.SetParameterValue("certificado", respuesta.NoCertificado);
                    // ////clsconv let = new clsconv();
                    // ////string mensaje = let.enletras(total.ToString());
                    // //factura.SetParameterValue("Cantidadconletra", mensaje);
                    // //factura.SetParameterValue("formadepago", CMBFORMADEPAGO.SelectedValue);
                    // //factura.SetParameterValue("cadenaoriginal", respuesta.Cadena);
                    // //factura.SetParameterValue("foliofiscal",seriefactura+numerofactura);
                    // //factura.SetParameterValue("RFCCLIENTE", txtRFC.Text);
                    // //factura.SetParameterValue("CERTIFICADOSAT",respuesta.CertificadoSAT);
                    // //factura.SetParameterValue("nota", txtObservaciones.Text);
                    // //factura.SetParameterValue("sellodigital",respuesta.Sello);
                    // //factura.SetParameterValue("seriecertificado", respuesta.NoCertificado);
                    // //factura.SetParameterValue("selloCFDI", respuesta.SelloSAT);
                    // //factura.SetParameterValue("UUID", respuesta.UUID);
                    // //factura.SetParameterValue("subtotal", subtotal);
                    // //factura.SetParameterValue("descuento", descuento);
                    // //factura.SetParameterValue("total", total);
                    // //factura.SetParameterValue("metodo", "PUE");
                    // //factura.SetParameterValue("colonia",txtColonia.Text);
                    // //factura.SetParameterValue("ciudad", txtPoblacion.Text+" "+ txtEstado.Text +" "+ txtCP.Text);


                    // //facturaITS.ExportToDisk(ExportFormatType.PortableDocFormat, cadenapdf);
                    // Process.Start(cadenapdf);



                    //this.btnCancelar_Click(this, new EventArgs());





                }






            }
            catch (Exception exvc)
            {
                MessageBox.Show(exvc.Message);
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
    }

}
