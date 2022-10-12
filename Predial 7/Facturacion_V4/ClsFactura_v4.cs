using Predial10.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Predial10.Facturacion_V4
{
    //class ClsFactura_v4
    //{


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


    //}
}
