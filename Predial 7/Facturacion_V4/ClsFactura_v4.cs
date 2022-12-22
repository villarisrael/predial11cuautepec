using MultiFacturasSDK;
using Predial10.Properties;
using Predial10.Resources.CODE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Predial10.Facturacion_V4
{
    class ClsFactura_v4
    {


        //    public string Cancela40(string uuid, string uuidsusti, string motivo, int IDFactura, int UserID, string viene)
        //    {
        //        //MotivoCancelacionContext db = new MotivoCancelacionContext();


        //        //Certificados de prueba
        //        string usuario = @"C:\sdk2\certificados\lan7008173r5.cer.pem";
        //        string pass = @"C:\sdk2\certificados\lan7008173r5.key.pem";
        //        string rfc = "LAN7008173R5";

        //        string cer = Convert.ToBase64String(File.ReadAllBytes(@"C:\sdk2\certificados\lan7008173r5.cer.pem"));
        //        string key = Convert.ToBase64String(File.ReadAllBytes(@"C:\sdk2\certificados\lan7008173r5.key.pem"));
        //        string passcer = "12345678a";


        //        if (Settings.Default.timbrarprueba.ToUpper() == "NO")
        //        {
        //            string SQLEmpresa = "select * from Empresa";
        //            Empresa datosNomList = new CobroDefault().Database.SqlQuery<Empresa>(SQLEmpresa).FirstOrDefault();


        //            //usuario y pass los proporcionara maestra Gaby
        //            usuario = Settings.Default.UsuarioMultifacturas;
        //            pass = Settings.Default.PasswordMultifacturas;

        //            //Obtener los certificados de Actopan desde Settings o hacer una tabla donde se carguen los certificados y obtenerlos
        //            cer = Convert.ToBase64String(File.ReadAllBytes(Settings.Default.CertificadoCliente));
        //            key = Convert.ToBase64String(File.ReadAllBytes(Settings.Default.keycliente));
        //            //passcer = Convert.ToBase64String(Encoding.UTF8.GetBytes(certificado.PassCertificado));
        //            passcer = Settings.Default.passsCliente;
        //            rfc = datosNomList.RFC; //emisor
        //        }



        //        WSCancelar_v4.Cancelarcfdi40SAT cliente = new WSCancelar_v4.Cancelarcfdi40SAT();
        //        WSCancelar_v4.datos datos = new WSCancelar_v4.datos();

        //        datos.accion = "cancelar";
        //        datos.b64Cer = cer;
        //        datos.b64Key = key;
        //        datos.motivo = motivo;
        //        datos.pass = pass;
        //        datos.password = passcer;
        //        datos.produccion = "SI";
        //        datos.usuario = usuario;
        //        datos.uuid = uuid;
        //        datos.folioSustitucion = uuidsusti;
        //        datos.rfc = rfc;



        //        try
        //        {

        //            WSCancelar_v4.respuesta respuesta = cliente.cancelarCfdi(datos);

        //            if (respuesta.codigo_mf_texto.Contains("OK"))
        //            {

        //                MessageBox.Show("UUID CANCELADO CORRECTAMENTE");

        //                return respuesta.acuse;
        //            }
        //            else
        //            {
        //                //MessageBox.Show(respuesta.Codigo_MF_Texto);
        //                MessageBox.Show("OCURRIO UN ERROR AL CANCELAR EL UUID");
        //                return "";
        //            }
        //        }
        //        catch (Exception err)
        //        {
        //            MessageBox.Show("OCURRIO UN ERROR AL CANCELAR EL UUID \n" + err);
        //            return "";
        //        }
        //    }



        //    public string Cancela40(string uuid, string motivo, int IDFactura, int UserID, string viene)
        //    {
        //        //MotivoCancelacionContext db = new MotivoCancelacionContext();


        //        //Certificados de prueba
        //        string usuario = @"C:\sdk2\certificados\lan7008173r5.cer.pem";
        //        string pass = @"C:\sdk2\certificados\lan7008173r5.key.pem";
        //        string rfc = "LAN7008173R5";

        //        string cer = Convert.ToBase64String(File.ReadAllBytes(@"C:\sdk2\certificados\lan7008173r5.cer.pem"));
        //        string key = Convert.ToBase64String(File.ReadAllBytes(@"C:\sdk2\certificados\lan7008173r5.key.pem"));
        //        string passcer = "12345678a";


        //        if (Settings.Default.timbrarprueba.ToUpper() == "NO")
        //        {
        //            string SQLEmpresa = "select * from Empresa";
        //            Empresa datosNomList = new CobroDefault().Database.SqlQuery<Empresa>(SQLEmpresa).FirstOrDefault();


        //            //usuario y pass los proporcionara maestra Gaby
        //            usuario = Settings.Default.UsuarioMultifacturas;
        //            pass = Settings.Default.PasswordMultifacturas;

        //            //Obtener los certificados de Actopan desde Settings o hacer una tabla donde se carguen los certificados y obtenerlos
        //            cer = Convert.ToBase64String(File.ReadAllBytes(Settings.Default.CertificadoCliente));
        //            key = Convert.ToBase64String(File.ReadAllBytes(Settings.Default.keycliente));
        //            //passcer = Convert.ToBase64String(Encoding.UTF8.GetBytes(certificado.PassCertificado));
        //            passcer = Settings.Default.passsCliente;
        //            rfc = datosNomList.RFC; //emisor
        //        }



        //        WSCancelar_v4.Cancelarcfdi40SAT cliente = new WSCancelar_v4.Cancelarcfdi40SAT();
        //        WSCancelar_v4.datos datos = new WSCancelar_v4.datos();

        //        datos.accion = "cancelar";
        //        datos.b64Cer = cer;
        //        datos.b64Key = key;
        //        datos.motivo = motivo;
        //        datos.pass = pass;
        //        datos.password = passcer;
        //        datos.produccion = "SI";
        //        datos.usuario = usuario;
        //        datos.uuid = uuid;
        //        //datos.folioSustitucion = uuidsusti;
        //        datos.rfc = rfc;



        //        try
        //        {

        //            WSCancelar_v4.respuesta respuesta = cliente.cancelarCfdi(datos);

        //            if (respuesta.codigo_mf_texto.Contains("OK"))
        //            {


        //                //if (viene == "Factura")
        //                //{
        //                //    string insert = "insert into FacturasCanceladasSAT (Estado, IDFactura,Fecha,Usuario) values " +
        //                //   "('C'," + IDFactura + ",sysdatetime()," + "UsuarioDelSistema" + ")";
        //                //    //MessageBox.Show("Hacer procedimiento");
        //                //    new CobroDefault().Database.ExecuteSqlCommand(insert);
        //                //}
        //                //else
        //                //{
        //                //    string insert = "insert into FacturasCanceladasSAT (Estado, IDFactura,Fecha,Usuario) values " +
        //                //   "('C'," + IDFactura + ",sysdatetime()," + "UsuarioDelSistema" + ")";
        //                //    //MessageBox.Show("Hacer procedimiento");
        //                //    new CobroDefault().Database.ExecuteSqlCommand(insert);
        //                //}
        //                //  MessageBox.Show("La factura fue cancelada ante el sat");
        //                MessageBox.Show("UUID CANCELADO CORRECTAMENTE");
        //                return respuesta.acuse;
        //            }
        //            else
        //            {
        //                MessageBox.Show("OCURRIO UN ERROR AL CANCELAR EL UUID");
        //                return "";
        //            }
        //        }
        //        catch (Exception err)
        //        {
        //            MessageBox.Show("OCURRIO UN ERROR AL CANCELAR EL UUID \n" + err);
        //            return "";
        //        }
        //    }

        public MFSDK construirfacturaV4(String _serie, String _folio, string _formadepago, string _metodo, string _uso, String _RFCreceptor, String _nombrereceptor, DevComponents.DotNetBar.Controls.DataGridViewX DATAGRID, string columnaimporte = "importe", string _cpReceptor = "42500", string _regimenFiscalP = "", bool facturaDiaP = false)
        {
            //PRUEBA FACTURACION V4

            string cpEmisor = Conexion_a_BD.obtenercampo("select CCODPOS from empresa");

            MFSDK sdk = new MFSDK();
            //sdk.Iniciales.Add("version_cfdi", "3.3");
            //sdk.Iniciales.Add("MODOINI", "DIVISOR");
            //sdk.Iniciales.Add("cfdi", @"C:\sdk2\timbrados\ejemplo_cfdi33.xml");
            //sdk.Iniciales.Add("xml_debug", @"C:\sdk2\timbrados\debug_ejemplo_cfdi33.xml");
            //sdk.Iniciales.Add("remueve_acentos", "NO");
            //sdk.Iniciales.Add("RESPUESTA_UTF8", "SI");
            //sdk.Iniciales.Add("html_a_txt", "NO");

            sdk.Iniciales.Add("version_cfdi", "4.0");
            sdk.Iniciales.Add("MODOINI", "DIVISOR");

            sdk.Iniciales.Add("cfdi", @"c:\sdk2\timbrados\cfdi_ejemplo_factura4_2.xml");
            sdk.Iniciales.Add("xml_debug", @"c:\sdk2\timbrados\sin_timbrar_ejemplo_factura4_2.xml");
            //sdk.Iniciales.Add("produccion", "NO");
            sdk.Iniciales.Add("RESPUESTA_UTF8", "SI");


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

                //string CNIF = "";
                //string nombreEmpresa = "";
                //emisor["rfc"] = Resources.CODE.Conexion_a_BD.obtenercampo("select CNIF from empresa");
                //emisor["nombre"] = Resources.CODE.Conexion_a_BD.obtenercampo("select CNOMBRE from empresa");
                //emisor["RegimenFiscal"] = Settings.Default.RegimenFiscal;

                emisor["rfc"] = Predial10.Resources.CODE.Conexion_a_BD.obtenercampo("select CNIF from empresa");
                emisor["nombre"] = Predial10.Resources.CODE.Conexion_a_BD.obtenercampo("select CNOMBRE from empresa");
                emisor["RegimenFiscal"] = Properties.Settings.Default.Regimenfiscal;



            }
            MFObject receptor = new MFObject("receptor");


            receptor["rfc"] = _RFCreceptor;
            receptor["nombre"] = _nombrereceptor;
            receptor["UsoCFDI"] = _uso;
            receptor["DomicilioFiscalReceptor"] = _cpReceptor;
            receptor["RegimenFiscalReceptor"] = _regimenFiscalP;//regimenFiscReceptorP


            MFObject conceptos = new MFObject("conceptos");
            decimal acudescuento = 0;
            decimal acusubtotal = 0;
            decimal total = 0;
            decimal descuento = 0;

            //Por si se llegaran a ocupar, por que todos los conceptos de presidencia son sin IVA (Exentos)
            decimal acumuladorBaseTasa = 0;
            decimal acumuladorBaseExento = 0;

            // Si viene no viene del listado de recibos




            for (int iciclo = 0; iciclo <= DATAGRID.Rows.Count - 1; iciclo++)
            {
                //  string clave = DTGdetalles.Rows[iciclo].Cells["clave"].Value.ToString();
                string concepto = DATAGRID.Rows[iciclo].Cells["concepto"].Value.ToString();
                Decimal importe = Math.Round(decimal.Parse(DATAGRID.Rows[iciclo].Cells[columnaimporte].Value.ToString()), 2);
                int Cantidad = int.Parse(DATAGRID.Rows[iciclo].Cells["Cantidad"].Value.ToString());
                string importeTotal = (Cantidad * importe).ToString();
                descuento = 0;
                try
                {
                    String importecondescuento = "0";
                    importecondescuento = DATAGRID.Rows[iciclo].Cells["importe"].Value.ToString();
                    descuento = Math.Round((importe) - Decimal.Parse(importecondescuento), 2);


                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }

                string cantidad = DATAGRID.Rows[iciclo].Cells["cantidad"].Value.ToString();
                string unidadsat = DATAGRID.Rows[iciclo].Cells["unidadsat"].Value.ToString();
                string clavesat = DATAGRID.Rows[iciclo].Cells["clavesat"].Value.ToString();

                MFObject concepto0 = new MFObject(iciclo.ToString());
                concepto0["ClaveProdServ"] = clavesat;
                concepto0["NoIdentificacion"] = "COD" + iciclo.ToString();
                concepto0["ObjetoImp"] = "01";
                concepto0["Cantidad"] = cantidad;
                if (unidadsat == "ACT")
                {
                    concepto0["Unidad"] = "ACTIVIDAD";
                }
                if (unidadsat == "E48")
                {
                    concepto0["Unidad"] = "SERVICIO";
                }
                concepto0["ClaveUnidad"] = unidadsat;
                concepto0["Descripcion"] = concepto.Replace("Ñ", "&ntilde");
                concepto0["ValorUnitario"] = importe.ToString();
                concepto0["Importe"] = importeTotal;
                if (descuento > 0)
                {
                    concepto0["Descuento"] = descuento.ToString();
                }


                MFObject impuestosindv = new MFObject("Impuestos");

                //MFObject itrast = new MFObject("Traslados");
                //MFObject itrast0 = new MFObject(iciclo.ToString());
                //itrast0["Base"] = importeTotal;
                //itrast0["Impuesto"] = "002";
                //itrast0["TipoFactor"] = "Exento";

                //itrast.AgregaSubnodo(itrast0);
                //impuestosindv.AgregaSubnodo(itrast);
                //concepto0.AgregaSubnodo(impuestosindv);

                conceptos.AgregaSubnodo(concepto0);
                acusubtotal = Math.Round(acusubtotal + Decimal.Parse(importeTotal.ToString()), 2);
                acudescuento = Math.Round((acudescuento + descuento), 2);
            }
            total = Math.Round((acusubtotal - acudescuento), 2);



            ////Agrega Nodo Impuestos a Nivel CFDI
            //MFObject impuestos3 = new MFObject("impuestos");
            ////_IVA = Math.Round(acuiva, 2)

            //impuestos3["TotalImpuestosTrasladados"] = 0.ToString();

            //MFObject itraslados = new MFObject("translados");
            //MFObject itraslado0 = new MFObject("0");
            //itraslado0["Impuesto"] = "002";
            //itraslado0["Base"] = acusubtotal.ToString();
            //itraslado0["TipoFactor"] = "Exento";

            //itraslados.AgregaSubnodo(itraslado0);
            //impuestos3.AgregaSubnodo(itraslados);




            //Dim conceptos As MFObject = New MFObject("conceptos")

            //Dim acuiva As Decimal = 0
            //conceptos.Subnodos.Clear()

            //For i = 1 To control.Listadeconceptos.Count
            //    Dim concepto As Clsconcepto = control.Listadeconceptos.Item(i)

            //    If concepto.Preciounitario > 0 Then
            //        Dim concepto0 As MFObject = New MFObject(i.ToString())
            //        concepto0("ClaveProdServ") = concepto.clavesat
            //        concepto0("NoIdentificacion") = "COD" & i.ToString()
            //        concepto0("Cantidad") = concepto.Cantidad
            //        concepto0("ClaveUnidad") = concepto.unidadsat
            //        concepto0("Descripcion") = concepto.Concepto
            //        concepto0("ValorUnitario") = concepto.Preciounitario
            //        concepto0("Importe") = concepto.importe
            //        ' Impuestos de conceptos
            //        Dim impuestos As MFObject = New MFObject("Impuestos")
            //        ' Traslados
            //        Dim itras As MFObject = New MFObject("Traslados")
            //        Dim itra0 As MFObject = New MFObject(i.ToString())
            //        itra0("Base") = concepto.importe
            //        itra0("Impuesto") = "002"

            //        If concepto.IVA > 0 Then
            //            itra0("Importe") = Math.Round(concepto.importe * 0.16, 2)
            //            acuiva = acuiva + Math.Round(concepto.importe * 0.16, 2)
            //            itra0("TasaOCuota") = "0.160000"
            //            itra0("TipoFactor") = "Tasa"
            //        Else
            //            itra0("TipoFactor") = "Exento"
            //        End If

            //        itras.AgregaSubnodo(itra0)
            //        impuestos.AgregaSubnodo(itras)
            //        concepto0.AgregaSubnodo(impuestos)

            //        conceptos.AgregaSubnodo(concepto0)
            //    End If
            //Next









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

            //DataTable table = new DataTable();
            //table = FuncionesBasicas.ConsultaDataTableSQL("", "");



            MFObject factura = new MFObject("factura");
            factura["serie"] = _serie;
            factura["folio"] = _folio;
            factura["fecha_expedicion"] = DateTime.Now.ToString("s");
            factura["metodo_pago"] = _metodo;
            factura["forma_pago"] = _formadepago;
            //factura["condicionesDePago"] = "condiciones";
            factura["tipocomprobante"] = "I";
            factura["moneda"] = "MXN";
            factura["tipocambio"] = "1";
            factura["LugarExpedicion"] = cpEmisor;
            factura["Exportacion"] = "01";
            //factura["RegimenFiscal"] = Settings.Default.RegimenFiscal;
            factura["subtotal"] = acusubtotal.ToString();//100.00
            if (acudescuento > 0)   // cuando se manda la factura ya le indica a la factura digital que hay un descuento  , asi podremos cachar el descuento en el lado del pdf veamos
            {
                factura["descuento"] = acudescuento.ToString();
            }
            factura["total"] = total.ToString();//100.00


            MFObject InformacionGlobal = new MFObject("InformacionGlobal");
            if (facturaDiaP == true)
            {

                string periodicidadFactura = Conexion_a_BD.obtenercampo("select PeriodicidadFacturacion from empresa");

                InformacionGlobal["Periodicidad"] = periodicidadFactura;
                InformacionGlobal["Meses"] = DateTime.Now.ToString("MM");
                InformacionGlobal["Año"] = DateTime.Now.ToString("yyyy");
            }


            sdk.AgregaObjeto(PAC());
            sdk.AgregaObjeto(Conf());
            sdk.AgregaObjeto(factura);
            //  sdk.AgregaObjeto(cfdiRelacionados);
            sdk.AgregaObjeto(emisor);
            sdk.AgregaObjeto(receptor);
            sdk.AgregaObjeto(conceptos);
            if (facturaDiaP == true)
            {

                sdk.AgregaObjeto(InformacionGlobal);

            }
            //sdk.AgregaObjeto(impuestos3);
            //   sdk.AgregaObjeto(impuestos);
            // Muestras la estructura
            return sdk;
        }


        public MFObject PAC()
        {
            MFObject pac = new MFObject("PAC");
            if (Properties.Settings.Default.timbrarprueba.ToUpper() == "SI")
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


        public SDKRespuesta timbrar(MFSDK sdk)
        {
            SDKRespuesta respuesta = sdk.Timbrar(@"C:\sdk2\timbrar32.bat", @"C:\sdk2\timbrados\", "factura", false);
            return respuesta;
        }

        public string Cancela40(string uuid, string uuidsusti, string motivo, int IDFactura, int UserID, string viene)
        {
            //MotivoCancelacionContext db = new MotivoCancelacionContext();


            string usuario = "";
            string pass = "";
            string rfc = "";

            string cer = "";
            string key = "";
            string passcer = "";

            if (Settings.Default.timbrarprueba.ToUpper() == "SI")
            {

                //Certificados de prueba
                usuario = @"C:\sdk2\certificados\lan7008173r5.cer.pem";
                pass = @"C:\sdk2\certificados\lan7008173r5.key.pem";
                rfc = "LAN7008173R5";

                cer = Convert.ToBase64String(File.ReadAllBytes(@"C:\sdk2\certificados\lan7008173r5.cer.pem"));
                key = Convert.ToBase64String(File.ReadAllBytes(@"C:\sdk2\certificados\lan7008173r5.key.pem"));
                passcer = "12345678a";
            }
            else
            {
                //string SQLEmpresa = "select * from Empresa";
                //Empresa datosNomList = new CobroDefault().Database.SqlQuery<Empresa>(SQLEmpresa).FirstOrDefault();


                //usuario y pass los proporcionara maestra Gaby
                usuario = Settings.Default.usuariomultifacturas;
                pass = Settings.Default.passmultifacturas;

                //Obtener los certificados de Actopan desde Settings o hacer una tabla donde se carguen los certificados y obtenerlos
                //cer = Convert.ToBase64String(File.ReadAllBytes(Settings.Default.CertificadoCSD));
                //key = Convert.ToBase64String(File.ReadAllBytes(Settings.Default.keyCSD));
                cer = Convert.ToBase64String(File.ReadAllBytes(Properties.Settings.Default.CertificadoCSD));
                key = Convert.ToBase64String(File.ReadAllBytes(Properties.Settings.Default.keyCSD));
                //passcer = Convert.ToBase64String(Encoding.UTF8.GetBytes(certificado.PassCertificado));
                passcer = Properties.Settings.Default.passCSD;
                rfc = Predial10.Resources.CODE.Conexion_a_BD.obtenercampo("select CNIF from empresa"); //emisor
            }



            WSCancelar_v4.Cancelarcfdi40SAT cliente = new WSCancelar_v4.Cancelarcfdi40SAT();
            WSCancelar_v4.datos datos = new WSCancelar_v4.datos();

            datos.accion = "cancelar";
            datos.b64Cer = cer;
            datos.b64Key = key;
            datos.motivo = motivo;
            datos.pass = pass;
            datos.password = passcer;
            datos.produccion = "SI";
            datos.usuario = usuario;
            datos.uuid = uuid;
            datos.folioSustitucion = uuidsusti;
            datos.rfc = rfc;



            try
            {

                WSCancelar_v4.respuesta respuesta = cliente.cancelarCfdi(datos);

                if (respuesta.codigo_mf_texto.Contains("OK"))
                {

                    MessageBox.Show("UUID CANCELADO CORRECTAMENTE");

                    return respuesta.acuse;
                }
                else
                {
                    //MessageBox.Show(respuesta.Codigo_MF_Texto);
                    MessageBox.Show("OCURRIO UN ERROR AL CANCELAR EL UUID");
                    return "";
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("OCURRIO UN ERROR AL CANCELAR EL UUID \n" + err);
                return "";
            }
        }



        public string Cancela40(string uuid, string motivo, int IDFactura, int UserID, string viene)
        {
            //MotivoCancelacionContext db = new MotivoCancelacionContext();


            string usuario = "";
            string pass = "";
            string rfc = "";

            string cer = "";
            string key = "";
            string passcer = "";

            if (Settings.Default.timbrarprueba.ToUpper() == "SI")
            {

                //Certificados de prueba
                usuario = @"C:\sdk2\certificados\lan7008173r5.cer.pem";
                pass = @"C:\sdk2\certificados\lan7008173r5.key.pem";
                rfc = "LAN7008173R5";

                cer = Convert.ToBase64String(File.ReadAllBytes(@"C:\sdk2\certificados\lan7008173r5.cer.pem"));
                key = Convert.ToBase64String(File.ReadAllBytes(@"C:\sdk2\certificados\lan7008173r5.key.pem"));
                passcer = "12345678a";
            }
            else
            {
                //string SQLEmpresa = "select * from Empresa";
                //Empresa datosNomList = new CobroDefault().Database.SqlQuery<Empresa>(SQLEmpresa).FirstOrDefault();


                //usuario y pass los proporcionara maestra Gaby
                usuario = Settings.Default.usuariomultifacturas;
                pass = Settings.Default.passmultifacturas;

                //Obtener los certificados de Actopan desde Settings o hacer una tabla donde se carguen los certificados y obtenerlos
                cer = Convert.ToBase64String(File.ReadAllBytes(Settings.Default.CertificadoCSD));
                key = Convert.ToBase64String(File.ReadAllBytes(Settings.Default.keyCSD));
                //passcer = Convert.ToBase64String(Encoding.UTF8.GetBytes(certificado.PassCertificado));
                passcer = Settings.Default.passCSD;
                rfc = Predial10.Resources.CODE.Conexion_a_BD.obtenercampo("select CNIF from empresa"); //emisor
            }



            WSCancelar_v4.Cancelarcfdi40SAT cliente = new WSCancelar_v4.Cancelarcfdi40SAT();
            WSCancelar_v4.datos datos = new WSCancelar_v4.datos();

            datos.accion = "cancelar";
            datos.b64Cer = cer;
            datos.b64Key = key;
            datos.motivo = motivo;
            datos.pass = pass;
            datos.password = passcer;
            datos.produccion = "SI";
            datos.usuario = usuario;
            datos.uuid = uuid;
            //datos.folioSustitucion = uuidsusti;
            datos.rfc = rfc;



            try
            {

                WSCancelar_v4.respuesta respuesta = cliente.cancelarCfdi(datos);

                if (respuesta.codigo_mf_texto.Contains("OK"))
                {


                    //if (viene == "Factura")
                    //{
                    //    string insert = "insert into FacturasCanceladasSAT (Estado, IDFactura,Fecha,Usuario) values " +
                    //   "('C'," + IDFactura + ",sysdatetime()," + "UsuarioDelSistema" + ")";
                    //    //MessageBox.Show("Hacer procedimiento");
                    //    new CobroDefault().Database.ExecuteSqlCommand(insert);
                    //}
                    //else
                    //{
                    //    string insert = "insert into FacturasCanceladasSAT (Estado, IDFactura,Fecha,Usuario) values " +
                    //   "('C'," + IDFactura + ",sysdatetime()," + "UsuarioDelSistema" + ")";
                    //    //MessageBox.Show("Hacer procedimiento");
                    //    new CobroDefault().Database.ExecuteSqlCommand(insert);
                    //}
                    //  MessageBox.Show("La factura fue cancelada ante el sat");
                    MessageBox.Show("UUID CANCELADO CORRECTAMENTE");
                    
                }
                //else
                //{
                //    MessageBox.Show("OCURRIO UN ERROR AL CANCELAR EL UUID");
                //    return "";
                //}
                return respuesta.acuse;
            }
            catch (Exception err)
            {
                MessageBox.Show("OCURRIO UN ERROR AL CANCELAR EL UUID \n" + err);
                return "";
            }
        }


    }


}
