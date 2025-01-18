using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Predial10.Resources.CODE;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions;
using System.IO;
using System.Diagnostics;
using MultiFacturasSDK;
using MySql.Data.MySqlClient;
using Predial10.CancelacrFacturas_V4;

namespace Predial10
{
    public partial class frmlistadofacturas : DevComponents.DotNetBar.OfficeForm
    {
        public frmlistadofacturas()
        {
            InitializeComponent();
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btncargar_Click(object sender, EventArgs e)
        {
            try
                {

                
                DataTable tablausuario = new DataTable();

                if (txtCaja.Text == "")
                {
                    tablausuario = Conexion_a_BD.Consultasql(" fecha, serie, numero, nombre,  Subtotal,IVA, Total, Estado, tipo as Es,MOTIVOCANCELACION,recibo, serierecibo,observacion, UUID, AcuseCancelacion", " encfac where fecha between '" + dtinicio.Value.ToString("yyyy-MM-dd") + " 00:00:01' and '" + dtfinal.Value.ToString("yyyy-MM-dd") + " 23:59:59'", " numero");
                    dataGridView1.DataSource = tablausuario;
            }
                else {
                    tablausuario = Conexion_a_BD.Consultasql(" fecha, serie, numero, nombre,  Subtotal,IVA, Total, Estado, tipo as Es,MOTIVOCANCELACION,recibo, serierecibo,observacion, UUID, AcuseCancelacion", " encfac where fecha between '" + dtinicio.Value.ToString("yyyy-MM-dd") + " 00:00:01' and '" + dtfinal.Value.ToString("yyyy-MM-dd") + " 23:59:59' and caja=" + txtCaja.Text + "", " numero");
                    dataGridView1.DataSource = tablausuario;
                }

                lblencontradas.Text = tablausuario.Rows.Count.ToString();

                dataGridView1.Columns[0].Width = 150;
                dataGridView1.Columns[1].Width = 50;
                dataGridView1.Columns[2].Width = 50;
                dataGridView1.Columns[3].Width = 300;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[5].DefaultCellStyle.Alignment= DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
           
                    }
        catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnreimprimir_Click(object sender, EventArgs e)
        {
            string fecha;
            string metodo = "PUE";
            string uso = "G03";
            string versionCFDI = "";

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                 {
                int fact = (int)dataGridView1.CurrentRow.Cells[2].Value;
                String serie = dataGridView1.CurrentRow.Cells[1].Value.ToString();


                DataTable tablafactura = new DataTable();
                tablafactura = Conexion_a_BD.Consultasql(" *", "encfac where serie='" + serie + "' and numero=" + fact, "numero");

                    
                    DataRow linea = tablafactura.DefaultView[0].Row;

                    //string cadxml = ("select CFDI from encfac where serie='" + serie + "' and numero=" + fact + "numero");
                    //// Obtener contenido del archivo
                    //var elemento = Conexion_a_BD.obtenercampo(m => m.ID == id);


                    


                    //string rutaArchivo = elemento + ".xml";

                    string cadenaxml = (folderBrowserDialog1.SelectedPath + "\\FACTURA" + serie + fact + ".XML").Trim();
                
                    string cadenapdf = (folderBrowserDialog1.SelectedPath + "\\" + serie + fact + ".PDF").Trim();

                    //FileStream fs = File.Create((cadenaxml + "\\FACTURA" & serie & factura & ".XML").Trim);
                    //    Dim fs1 As FileStream = File.Create((directorioreimpresas & "\FACTURA" & serie & factura & ".XML").Trim)
                    //    ' Add text to the file.
                    //    Dim info As Byte() = New UTF8Encoding(True).GetBytes(datosfac("CFDI").ToString().TrimStart().TrimEnd())
                    //    fs.Write(info, 0, info.Length)
                    //    fs.Close()

                    FileStream fs = File.Create(cadenaxml);
                    Byte[] info = new UTF8Encoding(true).GetBytes(linea["CFDI"].ToString().TrimStart());
                    fs.Write(info, 0, info.Length);
                    fs.Close();

                    //string rutaArchivo = elemento.UUID + ".xml";
                    //string fileName = System.Web.HttpContext.Current.Server.MapPath("~/Xmlfacturas/" + rutaArchivo);

                    //Obtener contyenido del xml
                    string xmlString = System.IO.File.ReadAllText(cadenaxml);

                    //FileStream fs = File.Create(cadenaxml);


                    //Byte[] info = new UTF8Encoding(true).GetBytes(linea["CFDI"].ToString().TrimStart());
                    //fs.Write(info, 0, info.Length);
                    //fs.Close();



 



                    String cadenapdf2 = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\facturasReimpresas\\").Trim();

                    if (!Directory.Exists(cadenapdf2))
                    {

                        DirectoryInfo di = Directory.CreateDirectory(cadenapdf2);

                    }

                    String cadenapdfGen = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\facturasReimpresas\\" + serie + fact + ".PDF").Trim();

                    //Generador.CreaPDF crearPDF = new Generador.CreaPDF(xmlString, cadenapdfGen, logoempresa2);

                    string observacion = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                    //string observacion = dataGridView1.Rows[i].Cells[12].Value.ToString();

                    versionCFDI = linea["version"].ToString();

                    Generador.CreaPDF crearPDF = new Generador.CreaPDF(cadenaxml, cadenapdfGen,  observacion, versionCFDI);

                   
                  
             
                }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }


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

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    byte[] logoempresa = Conexion_a_BD.obtenerimagen("select logo from empresa");

                    System.Drawing.Image logoempresa2 = byteArrayToImage(logoempresa);

                    iTextSharp.text.Image imagenBMP = iTextSharp.text.Image.GetInstance(logoempresa2, System.Drawing.Imaging.ImageFormat.Jpeg);

                    for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                    {
                        int fact = (int)dataGridView1.Rows[i].Cells[2].Value;
                        String serie = dataGridView1.Rows[i].Cells[1].Value.ToString();


                        DataTable tablafactura = new DataTable();
                        tablafactura = Conexion_a_BD.Consultasql(" *", "encfac where serie='" + serie + "' and numero=" + fact, "numero");

                        DataRow linea = tablafactura.DefaultView[0].Row;

                        //Error en 2 vuelta 
                        //No agarra la observacion correpondiente, esta invertida
                        // Referencia a objeto no establecida


                        String cadenaxml = (folderBrowserDialog1.SelectedPath + "\\FACTURA" + serie + fact + ".XML").Trim();
                        String cadenapdf = (folderBrowserDialog1.SelectedPath + "\\FACTURA" + serie + fact + ".PDF").Trim();
                        FileStream fs = File.Create(cadenaxml);


                        Byte[] info = new UTF8Encoding(true).GetBytes(linea["CFDI"].ToString().TrimStart());
                        fs.Write(info, 0, info.Length);
                        fs.Close();

                        DataSet datos = new DataSet();
                        datos.ReadXml(cadenaxml);


                        string observacion = dataGridView1.Rows[i].Cells[12].Value.ToString();

                        
                        Generador.CreaPDF crearPDF = new Generador.CreaPDF(cadenaxml, cadenapdf,  observacion);

                        string fecha = crearPDF._templatePDF.fechaEmisionCFDI;
                        string metodo = crearPDF._templatePDF.metodoPago;
                        string uso = crearPDF._templatePDF.receptor.usocfdi;


                        // Reemplazar por factura en ItextSharp


                        //ReportDocument factura = new ReportDocument();
                        //factura.Load(Application.StartupPath + "\\reportes\\factura.rpt");
                        //factura.SetDataSource(datos);

                        //factura.SetParameterValue("nombre", linea["NOMBRE"]);
                        //factura.SetParameterValue("direccion", "");
                        //factura.SetParameterValue("fechatimbrado", fecha);
                        //factura.SetParameterValue("certificado", linea["nodeCertificado"]);
                        //clsconv let = new clsconv();
                        //string mensaje = let.enletras(linea["total"].ToString());
                        //factura.SetParameterValue("Cantidadconletra", mensaje);
                        //factura.SetParameterValue("formadepago", linea["formapago"]);
                        //factura.SetParameterValue("cadenaoriginal", linea["cadena"]);
                        //factura.SetParameterValue("foliofiscal", linea["serie"].ToString() + linea["numero"].ToString());
                        //factura.SetParameterValue("RFCCLIENTE", linea["rfc"]);
                        //factura.SetParameterValue("CERTIFICADOSAT", linea["nodeCertificado"]);
                        //factura.SetParameterValue("nota", linea["OBSERVACION"]);
                        //factura.SetParameterValue("sellodigital", linea["Sello"]);
                        //factura.SetParameterValue("seriecertificado", linea["nodeCertificado"]);
                        //factura.SetParameterValue("selloCFDI", linea["selloSAT"]);
                        //factura.SetParameterValue("UUID", linea["uuid"]);
                        //factura.SetParameterValue("subtotal", (double)linea["subtotal"]);
                        //factura.SetParameterValue("descuento", (double)linea["descuento"]);
                        //factura.SetParameterValue("total", (double)linea["total"]);
                        //factura.SetParameterValue("metodo", metodo);
                        //factura.SetParameterValue("colonia", "");
                        //factura.SetParameterValue("ciudad", "");


                        //factura.ExportToDisk(ExportFormatType.PortableDocFormat, cadenapdf);
                        //Process.Start(cadenapdf);



                        //PDF ItextSharp




                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
                MessageBox.Show("Los archivos xml y pdf fueron colocados en tu carpeta");
            }

        }

        private void btncancelarrecibo_Click(object sender, EventArgs e)
        {
            try
            {
                int fact = (int)dataGridView1.CurrentRow.Cells[2].Value;
                String serie = dataGridView1.CurrentRow.Cells[1].Value.ToString();


                DataTable tablafactura = new DataTable();
                tablafactura = Conexion_a_BD.Consultasql(" *", "encfac where serie='" + serie + "' and numero=" + fact, "numero");

                DataRow linea = tablafactura.DefaultView[0].Row;


                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\facturas"))
                {
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\facturas");


                }
                String cadenaxml = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\facturas\\FACTURA" + serie + fact + ".XML").Trim();

                FileStream fs = File.Create(cadenaxml);


                Byte[] info = new UTF8Encoding(true).GetBytes(linea["CFDI"].ToString().TrimStart());
                fs.Write(info, 0, info.Length);
                fs.Close();

                ClsFactura clasefac = new ClsFactura();
                if (clasefac.cancelar(cadenaxml))
                {
                    Conexion_a_BD.Conectar();
                    Conexion_a_BD.Ejecutar("UPDATE ENCFAC SET ESTADO='C' , OBSERVACION='CANCELADA' WHERE SERIE='" + serie + "',NUMERO=" + fact);
                    Conexion_a_BD.Desconectar();
                }


            }
            catch(Exception ERR)
            {

            }
        }

        public MySqlConnection GetNewConnection()
        {
            var conn = new MySqlConnection(Predial10.Properties.Settings.Default.predialchicoConnectionString);
            conn.Open();
            return conn;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            //variables
            string factura = "";
            string serie = "";
                string uuid = "";


            //CANCELAR FACTURA ANTES EL SAT

            // dataGridView1.CurrentRow.Cells[1].Value.ToString();

            factura = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            serie = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            uuid = dataGridView1.CurrentRow.Cells[13].Value.ToString();

            //Dim IDFactura As String = obtenerCampo("select idENCFAC from Encfac where numero=" & factura & " and serie='" & serie & "'", "idencfac")

        int IDFactura = int.Parse(Conexion_a_BD.obtenercampo($"SELECT IDENCFAC from ENCFAC WHERE SERIE= '{ serie }' and numero = {factura} "));


            CancelarFacturas_v4 objCancelar = new CancelarFacturas_v4(uuid, IDFactura);

            objCancelar.Show();
        //    Dim objCancelaSAT As New CancelarFactura40(uuid, IDFactura)
        //'Dim objCancelaSAT As New CancelarFactura40()
        //objCancelaSAT.Show()

        }
    }

 
}