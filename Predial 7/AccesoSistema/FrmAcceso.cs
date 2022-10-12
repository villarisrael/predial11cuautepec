using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Predial10.Resources.CODE;
using System.Threading;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace Predial10.AccesoSistema
{
    public partial class FrmAcceso : DevComponents.DotNetBar.Office2007Form
    {
        Predial10.Resources.CODE.Seguridad Encriptar = new Seguridad();
        string UsuarioEncripatado, PasswordEncriptado, Password, Status;
        public string Usuario;
        DataTable TBL_Consulta = new DataTable();

        public FrmAcceso()
        {
            Thread t = new Thread(new ThreadStart(SplashScreen));
            t.Start();
            Thread.Sleep(5000); 
            InitializeComponent();
            t.Abort();
        }

        private void FrmAcceso_Load(object sender, EventArgs e)
        {
            try
            {
                txtUsuario.Focus();
                Conexion_a_BD.Conectar();
                lblEmpresa.Text = Conexion_a_BD.obtenercampo("select CNOMBRE from empresa");
                Conexion_a_BD.Desconectar();
            }
            catch (Exception err)
            {
                //MessageBox.Show("No fue posible conectarse a la Base de datos, verifique sus conexiones de red.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(err.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" && txtPassword.Text == "")
            {
                MessageBox.Show("Ingresa el Usuario y contraseña", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {               
                UsuarioEncripatado = Encriptar.Encriptar(txtUsuario.Text);
                PasswordEncriptado = Encriptar.Encriptar(txtPassword.Text);

                try
                {
                    Conexion_a_BD.Conectar();
                    Usuario = Conexion_a_BD.obtenercampo("Select User from letras_p where User='"+UsuarioEncripatado+"';");
                    Conexion_a_BD.Desconectar();

                    Conexion_a_BD.Conectar();
                    Password = Conexion_a_BD.obtenercampo("Select Password from letras_p where User='" + UsuarioEncripatado + "';");
                    Conexion_a_BD.Desconectar();

                    Conexion_a_BD.Conectar();
                    Status = Conexion_a_BD.obtenercampo("Select Status from letras_p where User='" + UsuarioEncripatado + "' and Password='" + PasswordEncriptado + "';");
                    Conexion_a_BD.Desconectar();

                   

                    if (UsuarioEncripatado == Usuario && PasswordEncriptado == Password && Status == "True")
                    {
                        string IDUSU = Conexion_a_BD.obtenercampo("SELECT IDUSER from letras_p WHERE User='" + UsuarioEncripatado +  "';");
                        Predial10.Principal programa = new Predial10.Principal();

                        Determinamenu(IDUSU,programa );
                        programa.usuario = txtUsuario.Text;
                       programa.ShowDialog ();
                        this.Visible = false;
                    }
                    else
                    {
                        if (UsuarioEncripatado == Usuario && PasswordEncriptado == Password && Status == "0")
                        {
                            MessageBox.Show("Usuario sin permiso", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Usuario y/o Password incorrectos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("No fue posible conectarse a la Base de datos, verifique sus conexiones de red.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Rutina para generar factura itextsharp
            DateTime fechaActual = DateTime.Today;
            String logo;
            Byte[] LOGOEMPRESA;

            var directoriopdfFDia = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\facturasItext\\" + fechaActual.Year + fechaActual.Month.ToString().Trim());

            if (!Directory.Exists(directoriopdfFDia))
            {
                
                DirectoryInfo di = Directory.CreateDirectory(directoriopdfFDia);

            }

            String cadenapdfItext = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\facturasItext\\" + fechaActual.Year + fechaActual.Month.ToString() + /*seriefactura + numerofactura */ "Prueba2"+ ".PDF").Trim();
            //Aqui comienza factura con ItextSharp
            Document facturaITS = new Document(iTextSharp.text.PageSize.LETTER, 5f, 5f, 5, 5);
            
            //String cadenapdf = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\facturas\\" + /*seriefactura + numerofactura*/ "Prueba" + ".PDF").Trim();
            //Dim pdfWrite4 As PdfWriter = PdfWriter.GetInstance(pdfDoc, New System.IO.FileStream(cadenafolderDocNombres & "\factura" & seriefactura & foliofactura & ".pdf", FileMode.Create))
            PdfWriter PdfWrite = PdfWriter.GetInstance(facturaITS, new System.IO.FileStream(cadenapdfItext, FileMode.Create));

            BaseFont _fuente1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
            BaseFont _fuenteContenido = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font _FuenteTitulos = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);



            facturaITS.Open();

            DataTable TBL_Consulta = new DataTable();
            Conexion_a_BD.Conectar();
            TBL_Consulta = Conexion_a_BD.Consultasql("logo", "empresa");
            Conexion_a_BD.Desconectar();
            var resultadoIma = from myRow in TBL_Consulta.AsEnumerable() select myRow;
            
                DataView view1 = resultadoIma.AsDataView();

                logo = view1[0]["LOGO"].ToString();
                LOGOEMPRESA = Encoding.ASCII.GetBytes(logo);
            

            


            var resultado = from myRow in TBL_Consulta.AsEnumerable() select myRow;
            //Query.Connection = ConexionBBDD.obtenerConexion();
            //Query.CommandText = "SELECT avatar FROM usuarios WHERE NombreUsuario = '" + UOn.getNombre() + "'";
            //consultar = Query.ExecuteReader();
            //if (consultar.Read())
            //{
            //    byte[] avatarByte = (byte[])consultar["avatar"];
            //    return avatarByte;
            //}
            //byte[] LOGOEMPRESA = (byte[])ObtenerLogo;
            //imgArr = (byte[])cmd.ExecuteScalar();

            DataTable DatosEmpresa = new DataTable();
            String CNomEmp = "";
            String CDirEmp = "";
            String CColEmp = "";
            String CCodEmp = "";
            String CProEmp = "";
            String CPaisEmp = "";
            String CPobEmp = "";

            String CCnifEmp = "";
            Conexion_a_BD.Conectar();
            TBL_Consulta = Conexion_a_BD.Consultasql("CNOMBRE, CDOMICILIO, CCOLONIA, CCODPOS, CPOBLACION, CNIF", "empresa");

            try
            {
                DataTable tabla = new DataTable();
                Conexion_a_BD.Conectar();
                tabla = Conexion_a_BD.Consultasql("*", "Empresa");
                CNomEmp = tabla.Rows[0]["CNOMBRE"].ToString();
                CDirEmp = tabla.Rows[0]["CDOMICILIO"].ToString();
                CColEmp = tabla.Rows[0]["CCOLONIA"].ToString();
                CPobEmp = tabla.Rows[0]["CPOBLACION"].ToString();
                CProEmp = tabla.Rows[0]["CPROVINCIA"].ToString();
                CPaisEmp = "MÉXICO";
                CCodEmp = tabla.Rows[0]["CCODPOS"].ToString();
                CCnifEmp = tabla.Rows[0]["CNIF"].ToString();
                //txtEmail.Text = tabla.Rows[0]["CEMAIL"].ToString();
                
                Conexion_a_BD.Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //IDataReader emp = Conexion_a_BD.Consultasql("CNOMBRE, CDOMICILIO, CCOLONIA, CCODPOS, CPOBLACION, CNIF", "empresa");
            Conexion_a_BD.Desconectar();
            //var resultadoEmp = from myRow in TBL_Consulta.AsEnumerable() select myRow;
            //try
            //{

            //    DataView view = resultadoEmp.AsDataView();

            //    CNomEmp = view[0]["CNOMBRE"].ToString();
            //    //CDirEmp = view[1]["CDOMICILIO"].ToString();
            //    //CColEmp = view[2]["CCOLONIA"].ToString();
            //    //CCodEmp = view[3]["CCODPOS"].ToString();
            //    //CPobEmp = view[4]["CPOBLACION"].ToString();
            //    //CCnifEmp = view[5]["CNIF"].ToString();

            ////    TBL_Consulta
            ////RutaImagenes = emp("Rutaimagenes")
            ////Empresa = emp("cnombre")
            //}
            //catch (Exception x)
            //{

            //    MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}


            


            //Aqui voy a formar el recuadro para adormar la factura 
            PdfContentByte cb;





            //tablaDatosEmisorReceptor.SpacingBefore = 5;
            //tablaDatosEmisorReceptor.HorizontalAlignment = Element.ALIGN_LEFT;
            //tablaDatosEmisorReceptor.LockedWidth = true;
            
            //using (MemoryStream memstr = new MemoryStream(LOGOEMPRESA))
            //{
            //    System.Drawing.Image img = System.Drawing.Image.FromStream(memstr);
                
            //}

            //iTextSharp.text.Image imagenLogo = iTextSharp.text.Image.GetInstance(img);
            //imagenLogo.ScaleAbsoluteWidth(480);
            //imagenLogo.ScaleAbsoluteHeight(270);


            //Aqui comenzare a formar las tablas con sus filas y columnas
            //PdfPTable tableEncabezado = new PdfPTable(2);
            //float[] widths = new float[] { 7f, 0.5f};
            
            //tableEncabezado.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            //tableEncabezado.SetTotalWidth(widths);

            PdfPTable TableDEncabezado = new PdfPTable(2);
            float[] widths = new float[] { 800f, 200f};

            TableDEncabezado.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            TableDEncabezado.SetTotalWidth(widths);

            

            PdfPTable TableDireccion = new PdfPTable(1);
            PdfPCell CelNombre = new PdfPCell(new Phrase(CNomEmp, _FuenteTitulos));
            CelNombre.Rowspan = 2;
            CelNombre.VerticalAlignment = Element.ALIGN_LEFT;
            CelNombre.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
            CelNombre.Border = 0;

            
            PdfPCell CelDirEmpresa = new PdfPCell(new Phrase(CDirEmp, _FuenteTitulos));
            CelDirEmpresa.Rowspan = 2;
            CelDirEmpresa.VerticalAlignment = Element.ALIGN_LEFT;
            CelDirEmpresa.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
            CelDirEmpresa.Border = 0;

            PdfPCell CelColEmpresa = new PdfPCell(new Phrase(CColEmp + ", " + CCodEmp, _FuenteTitulos));
            CelColEmpresa.Rowspan = 2;
            CelColEmpresa.VerticalAlignment = Element.ALIGN_LEFT;
            CelColEmpresa.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
            CelColEmpresa.Border = 0;

            PdfPCell CelPobEmpresa = new PdfPCell(new Phrase(CPobEmp + "DE HINOJOSA, " + CProEmp + ", " + CPaisEmp, _FuenteTitulos));
            CelPobEmpresa.Rowspan = 2;
            CelPobEmpresa.VerticalAlignment = Element.ALIGN_LEFT;
            CelPobEmpresa.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
            CelPobEmpresa.Border = 0;

                        
            PdfPCell CelCnifEmpresa = new PdfPCell(new Phrase(CCnifEmp, _FuenteTitulos));
            CelCnifEmpresa.Rowspan = 2;
            CelCnifEmpresa.VerticalAlignment = Element.ALIGN_LEFT;
            CelCnifEmpresa.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
            CelCnifEmpresa.Border = 0;

            TableDireccion.AddCell(CelNombre);
            TableDireccion.AddCell(CelDirEmpresa);
            TableDireccion.AddCell(CelColEmpresa);
            TableDireccion.AddCell(CelPobEmpresa);
            TableDireccion.AddCell(CelCnifEmpresa);
            


            TableDEncabezado.AddCell(TableDireccion);

            TableDEncabezado.AddCell("LOGO");


            //Tabla Información de dirección y datos fiscales

            PdfPTable TableDFiscales = new PdfPTable(2);
            float[] widthsDF = new float[] { 500f, 500f };

            TableDEncabezado.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            TableDEncabezado.SetTotalWidth(widthsDF);

            PdfPTable TabDF1 = new PdfPTable(1);
            PdfPCell CelNomDF = new PdfPCell(new Phrase(CNomEmp, _FuenteTitulos));
            CelNomDF.Rowspan = 2;
            CelNomDF.VerticalAlignment = Element.ALIGN_LEFT;
            CelNomDF.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
            CelNomDF.Border = 0;

            //PdfPTable Table3 = new PdfPTable(2);
            //PdfPCell col2;
            //Table3.WidthPercentage = 100;
            //float[] widths2 = new float[] { 100f, 100f};
            //Table3.SetTotalWidth(widths2);

            //PdfPCell clNom = new PdfPCell(new Phrase("Columna 3", _standardFont));
            //clNom.Rowspan = 2;
            //clNom.VerticalAlignment = Element.ALIGN_MIDDLE;
            //clNom.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right            
            //Table3.AddCell(clNom);


            //col2 = new PdfPCell(new Phrase("###", _standardFont));
            //col2.Rowspan = 2;
            //col2.VerticalAlignment = Element.ALIGN_MIDDLE;
            //col2.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right            
            //Table3.AddCell(col2);
            //TableDEncabezado.AddCell(Table3);

            ////PdfPCell clNombre = new PdfPCell(new Phrase(CNomEmp, _standardFont));
            ////clNombre.BorderWidth = 0;
            ////clNombre.BorderWidthBottom = 0.75f;
            ////TableDEncabezado.AddCell(clNombre);
            //tableEncabezado.AddCell(TableDEncabezado);
            //facturaITS.Add(imagenLogo);
            // tableEncabezado.AddCell(imagenLogo);
            //tableEncabezado.AddCell(TableDEncabezado);

            facturaITS.Add(TableDEncabezado);

            facturaITS.Close();
            PdfWrite.Close();

        }

        public void Determinamenu(string _id, Predial10.Principal _programa)
        {
            Conexion_a_BD.Conectar();
            TBL_Consulta = Conexion_a_BD.Consultasql("*", "arbol_P where id2 =" + _id);
            Conexion_a_BD.Desconectar();
            var resultado = from myRow in TBL_Consulta.AsEnumerable() select myRow;

            Seguridad seg = new Seguridad();
            try
            {
                DataView view = resultado.AsDataView();

                for (int il = 0; il <= view.Count - 1; il++)
                {
                    string campo = seg.Desencriptar(view[il]["ido"].ToString());
                    string que = view[il]["idv"].ToString();



                   
                    for (int i = 0; i <= _programa.menu.Items.Count - 1; i++)
                    {
                        DevComponents.DotNetBar.RibbonTabItem tabuladores = new DevComponents.DotNetBar.RibbonTabItem();
                        tabuladores = (DevComponents.DotNetBar.RibbonTabItem)_programa.menu.Items[i];
                        for (int j = tabuladores.Panel.Controls.Count - 1; j >= 0; j--)
                        {
                            DevComponents.DotNetBar.RibbonBar barras = new DevComponents.DotNetBar.RibbonBar();
                            barras = (DevComponents.DotNetBar.RibbonBar)tabuladores.Panel.Controls[j];

                            for (int k = barras.Items.Count; k >= 0; k--)
                            {

                                DevComponents.DotNetBar.ButtonItem boton = new DevComponents.DotNetBar.ButtonItem();
                                try
                                {
                                    boton = (DevComponents.DotNetBar.ButtonItem)barras.Items[k];
                                    if (campo == boton.Tooltip)
                                    {
                                        if (que == "1")
                                        {
                                            boton.Enabled  = true;
                                        }
                                        else
                                        {
                                            boton.Enabled   = false;
                                        }
                                    }
                                  

                                }
                                catch (Exception err)
                                {
                                }
                            }
                        }
                    }




                }

            }
            catch (Exception err)
            {
            }
        }

        public void SplashScreen()
        {
            Application.Run(new SplashScreen());
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.ToString() == "13")
            {
               txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.ToString() == "13")
            {
                btnAceptar_Click(sender, e);
            }
        }


    }
}
