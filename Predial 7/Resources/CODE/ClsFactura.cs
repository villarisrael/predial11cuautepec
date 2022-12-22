using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;
using MultiFacturasSDK;
using ThoughtWorks.QRCode.Codec;
using System.Drawing;
using System.Xml;

namespace Predial10.Resources.CODE
{
    class ClsFactura
    {
    
      public String Mensaje="";

        #region "factupronto"
        public long  WebServiceToInvoice(String Documento ,  String cliente , String passcliente , String nombre ) 
    {
        // Create a request using a URL that can receive a post.
        WebRequest request ;

        StringBuilder Data = new StringBuilder();

        Byte[] byt   = System.Text.Encoding.UTF8.GetBytes(Documento);
        String  Documento2 = Convert.ToBase64String(byt);

        if (Predial10.Properties.Settings.Default.timbrarprueba== "SI")
        {
            request = WebRequest.Create("http://rwsdev.homeunix.com:8181/prometheus/txt_timbrado_factupronto.php");
            Data.Append("usuario=eduardovime@outlook.com");
            Data.Append("&pass=Kelcay74@");
            Data.Append("&txt=" + Documento2);
        }
        else
        {
            request = WebRequest.Create("http://www.factupronto.mx/prometheus/txt_timbrado_factupronto.php");
            Data.Append("usuario=" + cliente);
            Data.Append("&pass=" + passcliente);
            Data.Append("&txt=" + Documento2);
        }
        // Set the Method property of the request to POST.
        request.Method = "POST";
        //request.Credentials = New System.Net.NetworkCredential("eduardovime@outlook.com", "Kelcay74@")
        //request.UseDefaultCredentials = False




        //Dim encodedString As Byte() = Encoding.UTF8.GetBytes(Data.ToString())

        //Dim PosData As String = "usuario=eduardovime@outlook.com&Pass=Kelcay74@&txt=''" ' & Documento
        Byte[] byteArray   = UTF8Encoding.UTF8.GetBytes(Data.ToString());
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = byteArray.Length;
        Stream dataStream  = request.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();

        // Get the response.
        WebResponse response  = request.GetResponse();
        //Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
        dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        String responseFromServer   = reader.ReadToEnd();

        String[] ContenidoWeb  = responseFromServer.ToString().Split('|');
        String xmlfile ;
        String pdffile  = String.Empty;
        String xmlFactura ;
        String serieregresada   = "";
        String folioregresado   = "";
        String directorio  = "";

       

        if( ContenidoWeb[0].Contains("200" ))
        {


         
            
            xmlfile = ContenidoWeb[2];

            Byte[] b   = Convert.FromBase64String(xmlfile);
            xmlFactura = System.Text.Encoding.UTF8.GetString(b);

            //Dim xmltexto As String
            //xmltexto = 'Convert.FromBase64CharArray(xmlfile, 0, xmlfile.Length);
            //Dim xmltexto As String = ConvertUTF8IntPtrtoString(xmlfile)

            pdffile = ContenidoWeb[3];

            int FacturaFaltam = 0;
            Int32.TryParse (ContenidoWeb[4], out FacturaFaltam);
           FacturaFaltam=  FacturaFaltam- 1;

            serieregresada = ContenidoWeb[5];
            folioregresado = ContenidoWeb[6];

            if( ! Directory.Exists(Directory.GetCurrentDirectory() + "\\facturas\\" + nombre) )
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\facturas\\" + nombre);
            }

            directorio = Directory.GetCurrentDirectory()  + "\\facturas\\" + nombre;

            try
            {
                DownloadFile(xmlfile, directorio + "\\XmlFactura" + serieregresada + folioregresado + ".xml");
                DownloadFile(pdffile, directorio + "\\PdfFactura" + serieregresada + folioregresado + ".pdf");
            }
            catch (Exception ex )
            {
               // MessageBox.Show("Error" + ex.Message());
            }
            

            String timbres ;
            timbres = ContenidoWeb[4];
            MessageBox.Show("Te quedan " +timbres + " Timbres");

            long folio  = 0;
            long.TryParse (folioregresado, out folio);
            reader.Close();
            dataStream.Close();
            response.Close();
            //FrmVisor x = new FrmVisor();
            //x.Visorpdf.LoadFile(directorio + "\\PdfFactura" + serieregresada + folioregresado + ".pdf");

           // ' FrmVisor.pdfvisor
            //'   FrmVisor.MdiParent = Me
            //x.Show();
            return folio;
        }
        else
        {
            if (ContenidoWeb[1].Contains("501") ){
               Mensaje="El usuario y contraseña posiblemente han cambiado";
              
            }
            if (ContenidoWeb[1].Contains("503")) {
               Mensaje="No hay timbres disponibles";
              
            }
            if (ContenidoWeb[1].Contains("507")) {

               Mensaje="La serie no es correcta";
              
            }
            if (ContenidoWeb[1].Contains("505")) {

               Mensaje="PROBLEMAS EN EL SISTEMA DE CONTRIBUYENTES";
              
                  }
            if (! (ContenidoWeb[1].Contains("200")) ){
               Mensaje="Error en el servidor  y/o servicio factuprontro";
              
                }

            MessageBox.Show(Mensaje);

            return 0;
        
       
        }
    }
        

    public static int DownloadFile(String remoteFilename, String localFilename)
    {
        // Function will return the number of bytes processed
        // to the caller. Initialize to 0 here.
        int bytesProcessed = 0;

        // Assign values to these objects here so that they can
        // be referenced in the finally block
        Stream remoteStream = null;
        Stream localStream = null;
        WebResponse response = null;

        // Use a try/catch/finally block as both the WebRequest and Stream
        // classes throw exceptions upon error
        try
        {
            // Create a request for the specified remote file name
            WebRequest request = WebRequest.Create(remoteFilename);
            if (request != null)
            {
                // Send the request to the server and retrieve the
                // WebResponse object 
                response = request.GetResponse();
                if (response != null)
                {
                    // Once the WebResponse object has been retrieved,
                    // get the stream object associated with the response's data
                    remoteStream = response.GetResponseStream();

                    // Create the local file
                    localStream = File.Create(localFilename);

                    // Allocate a 1k buffer
                    byte[] buffer = new byte[1024];
                    int bytesRead;

                    // Simple do/while loop to read from stream until
                    // no bytes are returned
                    do
                    {
                        // Read data (up to 1k) from the stream
                        bytesRead = remoteStream.Read(buffer, 0, buffer.Length);

                        // Write the data to the local file
                        localStream.Write(buffer, 0, bytesRead);

                        // Increment total bytes processed
                        bytesProcessed += bytesRead;
                    } while (bytesRead > 0);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            // Close the response and streams objects here 
            // to make sure they're closed even if an exception
            // is thrown at some point
            if (response != null) response.Close();
            if (remoteStream != null) remoteStream.Close();
            if (localStream != null) localStream.Close();
        }

        // Return total bytes processed to caller.
        return bytesProcessed;
    }
        #endregion



        #region  "multifacturas"

        public MFSDK construirfactura(String _serie, String _folio, string _formadepago,string _metodo, string _uso,  String _RFCreceptor, String _nombrereceptor,DevComponents.DotNetBar.Controls.DataGridViewX DATAGRID, string columnaimporte = "importe",string _cp="43740")
        {
            MFSDK sdk = new MFSDK();
            sdk.Iniciales.Add("version_cfdi", "3.3");
            sdk.Iniciales.Add("MODOINI", "DIVISOR");
            sdk.Iniciales.Add("cfdi", @"C:\sdk2\timbrados\ejemplo_cfdi33.xml");
            sdk.Iniciales.Add("xml_debug", @"C:\sdk2\timbrados\debug_ejemplo_cfdi33.xml");
            sdk.Iniciales.Add("remueve_acentos", "NO");
            sdk.Iniciales.Add("RESPUESTA_UTF8", "SI");
            sdk.Iniciales.Add("html_a_txt", "NO");
           
           
            MFObject emisor = new MFObject("emisor");
            if (Properties.Settings.Default.timbrarprueba.ToUpper() == "SI")
            {
                //emisor["rfc"] = "AAA010101AAA";
                //emisor["nombre"] = "CINDEMEX SA DE CV";
                //emisor["RegimenFiscal"] = "601";

                //emisor["rfc"] = "KIJ0906199R1";
                //emisor["nombre"] = "KERNEL INDUSTIA JUGUETERA SA DE CV";
                //emisor["RegimenFiscal"] = "603";

                emisor["rfc"] = "EKU9003173C9";
                emisor["nombre"] = "ESCUELA KEMPER URGATE";
                emisor["RegimenFiscal"] = "601";

                //
            }
            else
            {
                 
                
                emisor["rfc"] = Predial10.Resources.CODE.Conexion_a_BD.obtenercampo("select CNIF from empresa");
                emisor["nombre"] = Predial10.Resources.CODE.Conexion_a_BD.obtenercampo("select CNOMBRE from empresa");
                emisor["RegimenFiscal"] = Properties.Settings.Default.Regimenfiscal;

            }
            MFObject receptor = new MFObject("receptor");

           
                receptor["rfc"] = _RFCreceptor;
                receptor["nombre"] = _nombrereceptor;
                receptor["UsoCFDI"] = _uso;

            
            MFObject conceptos = new MFObject("conceptos");
            decimal acudescuento = 0;
            decimal acusubtotal = 0;
            decimal total = 0;
            decimal descuento = 0;
            for (int iciclo = 0; iciclo <= DATAGRID.Rows.Count - 1; iciclo++)
            {
                //  string clave = DTGdetalles.Rows[iciclo].Cells["clave"].Value.ToString();
                string concepto = DATAGRID.Rows[iciclo].Cells["concepto"].Value.ToString();
                string importe = DATAGRID.Rows[iciclo].Cells[columnaimporte].Value.ToString();

                descuento = 0;
                try
                {
                    String importecondescuento = "0";
                    importecondescuento = DATAGRID.Rows[iciclo].Cells["importe"].Value.ToString();
                    descuento = Math.Round(Decimal.Parse(importe) - Decimal.Parse(importecondescuento), 2);


                }
                catch (Exception err)
                {

                }
                string cantidad = DATAGRID.Rows[iciclo].Cells["cantidad"].Value.ToString();
                string unidadsat = DATAGRID.Rows[iciclo].Cells["unidadsat"].Value.ToString();
                string clavesat = DATAGRID.Rows[iciclo].Cells["clavesat"].Value.ToString();

                MFObject concepto0 = new MFObject(iciclo.ToString());
                concepto0["ClaveProdServ"] = clavesat;
                concepto0["NoIdentificacion"] = "COD" + iciclo.ToString();
                concepto0["Cantidad"] = "1";
                if (unidadsat == "ACT")
                { 
                concepto0["Unidad"] = "ACTIVIDAD";
                }
                if (unidadsat == "E48")
                {
                    concepto0["Unidad"] = "SERVICIO";
                }
                    concepto0["ClaveUnidad"] = unidadsat;
                concepto0["Descripcion"] = concepto.Replace("Ñ","&ntilde");
                concepto0["ValorUnitario"] = importe;
                concepto0["Importe"] = importe;
                if (descuento > 0)
                {
                    concepto0["Descuento"] = descuento.ToString();
                }
                MFObject impuestosindv = new MFObject("Impuestos");

                MFObject itrast = new MFObject("Traslados");
                MFObject itrast0 = new MFObject(iciclo.ToString());
                itrast0["Base"] = importe;
                itrast0["Impuesto"] = "002";
                itrast0["TipoFactor"] = "Exento";

                itrast.AgregaSubnodo(itrast0);
                impuestosindv.AgregaSubnodo(itrast);
                concepto0.AgregaSubnodo(impuestosindv);

                conceptos.AgregaSubnodo(concepto0);
                acusubtotal = acusubtotal + Decimal.Parse(importe);
                acudescuento = acudescuento + descuento;
            }
            total = acusubtotal - acudescuento;
            // Impuestos
            //MFObject impuestos = new MFObject("impuestos");
            //impuestos["TotalImpuestosTrasladados"] = "0.00";
            //// Traslados
            //MFObject itras = new MFObject("translados");
            //MFObject itra0 = new MFObject("0");
            //itra0["Impuesto"] = "002";
         
            //itra0["TipoFactor"] = "Excento";
            //itras.AgregaSubnodo(itra0);
            //impuestos.AgregaSubnodo(itras);



            MFObject factura = new MFObject("factura");
            factura["serie"] = _serie;
            factura["folio"] = _folio;
            factura["fecha_expedicion"] = DateTime.Now.ToString("s");
            factura["metodo_pago"] = _metodo;
            factura["forma_pago"] = _formadepago;
            factura["condicionesDePago"] = "condiciones";
            factura["tipocomprobante"] = "I";
            factura["moneda"] = "MXN";
            factura["tipocambio"] = "1";
            factura["LugarExpedicion"] = _cp;
            factura["RegimenFiscal"] = Predial10.Properties.Settings.Default.Regimenfiscal;
            factura["subtotal"] = acusubtotal.ToString();//100.00
            if (acudescuento > 0)   // cuando se manda la factura ya le indica a la factura digital que hay un descuento  , asi podremos cachar el descuento en el lado del pdf veamos
                {
                factura["descuento"] = acudescuento.ToString();
            }
            factura["total"] = total.ToString();//100.00





            sdk.AgregaObjeto(PAC());
            sdk.AgregaObjeto(Conf());
            sdk.AgregaObjeto(factura);
            //  sdk.AgregaObjeto(cfdiRelacionados);
            sdk.AgregaObjeto(emisor);
            sdk.AgregaObjeto(receptor);
            sdk.AgregaObjeto(conceptos);
         //   sdk.AgregaObjeto(impuestos);
            // Muestras la estructura
            return sdk;
        }


        public SDKRespuesta timbrar(MFSDK sdk)
        {
            SDKRespuesta respuesta = sdk.Timbrar(@"C:\sdk2\timbrar32.bat", @"C:\sdk2\timbrados\", "factura", false);
            return respuesta;
        }

        public MFObject PAC()
        {
            MFObject pac = new MFObject("PAC");
            if (Predial10.Properties.Settings.Default.timbrarprueba.ToUpper() == "SI")
            {
               
                pac["usuario"] = "DEMO700101XXX";
                pac["pass"] = "DEMO700101XXX";
                pac["produccion"] = "NO";
            }
            else
            {
               
                pac["usuario"] = Properties.Settings.Default.usuariomultifacturas;
                pac["pass"] = Properties.Settings.Default.passmultifacturas;
                pac["produccion"] = "SI";
            }
            return pac;
        }

        public MFObject PAC2()
        {
            MFObject pac = new MFObject("PAC");
            if (Properties.Settings.Default.timbrarprueba.ToUpper() == "SI")
            {
                pac["usuario"] = "DEMO700101XXX";
                pac["pass"] = "DEMO700101XXX";
            }
            else
            {
                pac["usuario"] = Properties.Settings.Default.usuariomultifacturas;
                pac["pass"] = Properties.Settings.Default.passmultifacturas;

            }
            return pac;
        }

        public MFObject Conf()
        {
            MFObject conf = new MFObject("conf");
            if (Properties.Settings.Default.timbrarprueba.ToUpper() == "SI")
            {
                //conf["cer"] = @"C:\sdk2\certificados\lan7008173r5.cer.pem";
                //conf["key"] = @"C:\sdk2\certificados\lan7008173r5.key.pem";
                //conf["pass"] = "12345678a";

                conf["cer"] = @"C:\sdk2\certificados\EKU9003173C9.cer.pem";
                conf["key"] = @"C:\sdk2\certificados\EKU9003173C9.key.pem";
                conf["pass"] = "12345678a";
            }
            else
            {
                conf["cer"] = Properties.Settings.Default.CertificadoCSD;
                conf["key"] = Properties.Settings.Default.keyCSD;
                conf["pass"] = Properties.Settings.Default.passCSD;
            }
            return conf;
        }



        public bool cancelar(string cadenaxml)
        {
            MFSDK sdk = new MFSDK();
            sdk.Iniciales.Add("cfdi", cadenaxml);
            sdk.Iniciales.Add("cancelar", "SI");
            sdk.AgregaObjeto(PAC());
            sdk.AgregaObjeto(Conf());
            SDKRespuesta respuesta= timbrar(sdk);
            if (respuesta.Codigo_MF_Texto == "OK" || respuesta.Codigo_MF_Texto.Trim()=="")
            {
                MessageBox.Show("La factura fue cancelada ante el sat");
                return true;
            }
            else
            {
                MessageBox.Show(respuesta.Codigo_MF_Texto);
                return false;
            }
        }
        public Image qrdatos(string cadenaxml)
        {
            XmlDocument varXmlFile = new XmlDocument();

            XmlNamespaceManager varXmlNsMngr = new XmlNamespaceManager(varXmlFile.NameTable);


            varXmlFile.Load(cadenaxml);

            varXmlNsMngr.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");
            varXmlNsMngr.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");


            string varUUID = "";
            string varTotal = "";
            string VARRFCEMISOR = "";
            string varRFCRECEPTOR = "";
            string varcertificado = "";

         //   varTotal = varXmlFile.SelectSingleNode("/cfdi:Comprobante/@total", varXmlNsMngr).InnerXml;
            //varUUID = varXmlFile.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@UUID", varXmlNsMngr).InnerText;
          //  varcertificado = varXmlFile.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@noCertificadoSAT", varXmlNsMngr).InnerText;
            XmlNodeList LISTANODOSEMISOR  = varXmlFile.GetElementsByTagName("cfdi:Emisor");
            foreach (XmlElement xAtt in LISTANODOSEMISOR)
                    {
                VARRFCEMISOR = VarXml(xAtt, "Rfc");
                // strEmisorNombre = VarXml(xAtt, "nombre");
            }
            XmlNodeList LISTANODORECEPTOR = varXmlFile.GetElementsByTagName("cfdi:Receptor");
            foreach (XmlElement xAtt in LISTANODORECEPTOR)
            {
                varRFCRECEPTOR = VarXml(xAtt, "Rfc");
                    }

            XmlNodeList LISTACOMPROBANTE = varXmlFile.GetElementsByTagName("cfdi:Comprobante");
            foreach (XmlElement xAtt in LISTACOMPROBANTE)
            {
                varTotal = VarXml(xAtt, "Total");
                varcertificado = VarXml(xAtt, "NoCertificado");
            }

            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();

            string texto = "https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?&id=";
            texto += varUUID;
            texto += "&re=";
            texto += VARRFCEMISOR;
            texto += "&rr=";
            texto += varRFCRECEPTOR;
            //texto += "&tt=";
            //texto += varTotal.ToString();
            //texto += "&fe=";
            //texto += varcertificado.Substring(12);

            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;



            qrCodeEncoder.QRCodeScale = 1;



            string errorCorrect = "L";
            if (errorCorrect == "L")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
            else if (errorCorrect == "M")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            else if (errorCorrect == "Q")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;
            else if (errorCorrect == "H")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;

            int colorFondoQR =
     Color.FromArgb(255, 255, 255, 255).ToArgb();
            int colorQR =
            Color.FromArgb(255, 0, 0, 0).ToArgb();
            qrCodeEncoder.QRCodeBackgroundColor =
           System.Drawing.Color.FromArgb(colorFondoQR);
            qrCodeEncoder.QRCodeForegroundColor =
                System.Drawing.Color.FromArgb(colorQR);

            return qrCodeEncoder.Encode(texto);

        }

        public string VarXml(XmlElement xAtt, string strVar)
        {
            string valor = "";
            valor = xAtt.GetAttribute(strVar);
           if (valor == null)
            {
                valor = "";
            }
            return valor;
    }
        #endregion
    }

   
}
