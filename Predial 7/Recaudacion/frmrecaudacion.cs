using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Predial10.Resources.CODE;

namespace Predial10.Recaudacion
{

    public partial class frmrecaudacion : DevComponents.DotNetBar.Office2007Form
    {
        Boolean cargar = true;
        public string tipo = "Recaudacion";
        string filtrocrystal = "";
        string filtromysql = "";
        string encabezado1 = "";
        string encabezado2 = "";
        public double total = 0;
        public double subtotal = 0;
        public double descuento = 0;
        public string NumConceptos = "";
        public double recib = 0;
        public double totalFinal = 0;
        public double efectivo = 0;
        string SQL = "";
        string SQL1 = "";
    
        Decimal totalGeneral = 0.0M;
      
        public frmrecaudacion()
        {
            InitializeComponent();
        }
        private void btncerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void frmrecaudacion_Load(object sender, EventArgs e)
        {
            fechaini.SelectedDate = DateTime.Now;
            fechafin.SelectedDate = DateTime.Now;
            fechaini.DisplayMonth = DateTime.Now;
            fechafin.DisplayMonth = DateTime.Now;
            cargar = true;

            Conexion_a_BD.Conectar();
            cmboficina.ValueMember = "cod_ofi";
            cmboficina.DisplayMember = "Nombre";
            cmboficina.DataSource = Conexion_a_BD.Consultasql("cod_ofi, Nombre", "oficinas", "Nombre");
            Conexion_a_BD.Desconectar();
            cmboficina.SelectedIndex = -1;
            cargar = false;
        }

        private void cmboficina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargar == false)
            {
                Conexion_a_BD.Conectar();
                cmbcaja.ValueMember = "ID_CAJA";
                cmbcaja.DisplayMember = "Descripcion";
                cmbcaja.DataSource = Conexion_a_BD.Consultasql("ID_CAJA, Descripcion", "Cajas where COD_OFI ='" + cmboficina.SelectedValue + "'", "Descripcion ");
                Conexion_a_BD.Desconectar();
                cmbcaja.SelectedIndex = -1;
            }
        }

        private void btncAceptar_Click(object sender, EventArgs e)
        {
            if (chkExportExcel.Checked == false)
            {

                filtrocrystal = " {recibomaestro.fecha} >= date ('" + fechaini.SelectedDate.ToString("dd/MM/yyyy") + "') and {recibomaestro.fecha} <= date ('" + fechafin.SelectedDate.ToString("dd/MM/yyyy") + "') ";
                filtromysql = " fecha>= '" + fechaini.SelectedDate.ToString("yyyy/MM/dd") + "' and fecha<='" + fechafin.SelectedDate.ToString("yyyy/MM/dd") + "'";
                encabezado1 = "DEL DIA : " + fechaini.SelectedDate.ToString("dd/MM/yyyy") + " AL DIA: " + fechafin.SelectedDate.ToString("dd/MM/yyyy");
                if (cmboficina.SelectedIndex == -1 && cmbcaja.SelectedIndex == -1)
                {
                    filtromysql += " and ccodofi = '001', and caja = ''";
                    encabezado2 = "OFICINA: " + "CORTE GENERAL";
                }
                else
                {
                    if (cmboficina.SelectedIndex > -1)
                    {
                        filtrocrystal += " and {recibomaestro.ccodofi} = '" + cmboficina.SelectedValue + "' ";
                        string cadena = ("select * from predialchico.vrubros where fecha >=" + fechaini + "and fecha <=" + fechafin);
                        filtromysql += " and ccodofi = '" + cmboficina.SelectedValue + "' ";
                        encabezado2 = "OFICINA: " + cmboficina.Text;
                    }

                    if (cmbcaja.SelectedIndex > -1)
                    {
                        filtrocrystal += " and {recibomaestro.caja} = '" + cmbcaja.SelectedValue + "' ";
                        filtromysql += " and caja = '" + cmbcaja.SelectedValue + "'";
                        encabezado2 += " CAJA: " + cmbcaja.Text;
                    }
                }
                if (tipo == "Rubros")
                {
                    Conexion_a_BD.Conectar();

                    reportexRubrosITSharp reportexRubros = new reportexRubrosITSharp();
                    reportexRubros.CrearReporte(filtromysql, fechaini.SelectedDate.ToString("yyyy-MM-dd"), fechafin.SelectedDate.ToString("yyyy-MM-dd"), encabezado1, encabezado2, cmbcaja.SelectedValue);
                }

                if (tipo == "Recaudacion")
                {
                    Conexion_a_BD.Conectar();
                    ReporteXRrcaudacion(filtromysql);
                }


            }
            else
            {

                filtrocrystal = " {recibomaestro.fecha} >= date ('" + fechaini.SelectedDate.ToString("dd/MM/yyyy") + "') and {recibomaestro.fecha} <= date ('" + fechafin.SelectedDate.ToString("dd/MM/yyyy") + "') ";
                filtromysql = " fecha>= '" + fechaini.SelectedDate.ToString("yyyy/MM/dd") + "' and fecha<='" + fechafin.SelectedDate.ToString("yyyy/MM/dd") + "'";
                encabezado1 = "DEL DIA : " + fechaini.SelectedDate.ToString("dd/MM/yyyy") + " AL DIA: " + fechafin.SelectedDate.ToString("dd/MM/yyyy");
                if (cmboficina.SelectedIndex == -1 && cmbcaja.SelectedIndex == -1)
                {
                    filtromysql += " and ccodofi = '001', and caja = ''";
                    encabezado2 = "OFICINA: " + "CORTE GENERAL";
                }
                else
                {
                    if (cmboficina.SelectedIndex > -1)
                    {
                        filtrocrystal += " and {recibomaestro.ccodofi} = '" + cmboficina.SelectedValue + "' ";
                        string cadena = ("select * from predialchico.vrubros where fecha >=" + fechaini + "and fecha <=" + fechafin);
                        filtromysql += " and ccodofi = '" + cmboficina.SelectedValue + "' ";
                        encabezado2 = "OFICINA: " + cmboficina.Text;
                    }

                    if (cmbcaja.SelectedIndex > -1)
                    {
                        filtrocrystal += " and {recibomaestro.caja} = '" + cmbcaja.SelectedValue + "' ";
                        filtromysql += " and caja = '" + cmbcaja.SelectedValue + "'";
                        encabezado2 += " CAJA: " + cmbcaja.Text;
                    }
                }
                if (tipo == "Rubros")
                {
                    Conexion_a_BD.Conectar();

                    reportexRubrosITSharp reportexRubros = new reportexRubrosITSharp();
                    reportexRubros.CrearReporteExcel(filtromysql, fechaini.SelectedDate.ToString("yyyy-MM-dd"), fechafin.SelectedDate.ToString("yyyy-MM-dd"), encabezado1, encabezado2, cmbcaja.SelectedValue);
                }

            }

        }
        





        public void ReporteXRrcaudacion(string consulta)
        {
            int numConceptos = 0;
            int numConceptosCan = 0;
            string idReciboMaestr = "";
            int folioReciboMaestro = 0;
            DateTime fech;
            string fecha = "";
            string nombre = "";
            decimal total = 0.0M;
            string forma = "";
            string cancelado = "";
            int contador = 0;

            //Obtener datos del organismo
            DataTable DatosEmpresa = new DataTable();
            String CNomEmp = "";
            String CDirEmp = "";
            String CColEmp = "";
            String CCodEmp = "";
            String CProEmp = "";
            String CPaisEmp = "";
            String CPobEmp = "";
            String CCnifEmp = "";

            DatosEmpresa = Conexion_a_BD.Consultasql("*", "empresa", "CODEMP");

            CNomEmp = DatosEmpresa.Rows[0]["CNOMBRE"].ToString();
            CDirEmp = DatosEmpresa.Rows[0]["CDOMICILIO"].ToString();
            CColEmp = DatosEmpresa.Rows[0]["CCOLONIA"].ToString();
            CPobEmp = DatosEmpresa.Rows[0]["CPOBLACION"].ToString();
            CProEmp = DatosEmpresa.Rows[0]["CPROVINCIA"].ToString();
            CPaisEmp = "MÉXICO";
            CCodEmp = DatosEmpresa.Rows[0]["CCODPOS"].ToString();
            CCnifEmp = DatosEmpresa.Rows[0]["CNIF"].ToString();
            //Crear ruta para el pdf

            string Date = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
            String cadenapdf2 = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ReportexRecaudacion\\").Trim();

            if (!Directory.Exists(cadenapdf2))
            {

                DirectoryInfo di = Directory.CreateDirectory(cadenapdf2);

            }
            string ruta = "\\ReportexRecaudacion\\" + "ReportexRecaudacion_" + Date + cmbcaja.SelectedValue + ".PDF";
            String cadenapdf = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + ruta).Trim();

            //Obtener Logo de la BD
            byte[] logoempresa = Conexion_a_BD.obtenerimagen("select logo from empresa");

            //Obtener los datos de Recaudación
            List<string> ListRecaudacion = new List<string>();
            //System.Drawing.Image logoempresa2 = byteArrayToImage(logoempresa);
            iTextSharp.text.Image LogoEmpresa = iTextSharp.text.Image.GetInstance(logoempresa);

            //Crear los documentos
            Document ReportexRubroPredial = new Document(iTextSharp.text.PageSize.LETTER, 10f, 10f, 10f, 10f);
            ReportexRubroPredial.SetMargins(10f, 10f, 20f, 20f);

            PdfWriter PdfWrite = PdfWriter.GetInstance(ReportexRubroPredial, new System.IO.FileStream(cadenapdf, FileMode.Create));


            //Declarar formatos de letras

            iTextSharp.text.Font _FuenteTitulos10 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            iTextSharp.text.Font _FuenteTitulos10NB = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font _FuenteContenido9B = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font _FuenteContenido6 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 6, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font _FuenteSellos5 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 5, iTextSharp.text.Font.ITALIC, BaseColor.BLACK);
            iTextSharp.text.Font _FuenteConceptos9W = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
            iTextSharp.text.Font _FuenteFolio15B = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 15, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font _FuenteNormal7B = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font _Color = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, new BaseColor (0,0,117));


            //Abrir el Documento

            ReportexRubroPredial.Open();

            //Crear las tablas

            //Tabla VACIA
            PdfPTable TabVacio = new PdfPTable(1);
            float[] widthsVacio = new float[] { 1000.0f };
            TabVacio.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            TabVacio.SetTotalWidth(widthsVacio);

            PdfPCell CelTabVac = new PdfPCell(new Phrase(" ", _FuenteTitulos10));
            CelTabVac.Rowspan = 2;
            CelTabVac.VerticalAlignment = Element.ALIGN_LEFT;
            CelTabVac.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
            CelTabVac.Border = 0;
            TabVacio.AddCell(CelTabVac);

            ////Tabla Titulos

            //PdfPTable TabEncabezado = new PdfPTable(3);
            //float[] widthsEnc = new float[] { 200.0f, 600.0f, 200.0f };
            //TabEncabezado.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            //TabEncabezado.SetTotalWidth(widthsEnc);


            //TabEncabezado.AddCell(LogoEmpresa);

            //PdfPCell CelTabEnc = new PdfPCell(new Phrase("PRESIDENCIA MUNICIPAL DE CUAUTEPEC, HGO.", _FuenteTitulos10NB));
            //CelTabEnc.Rowspan = 2;
            //CelTabEnc.VerticalAlignment = Element.ALIGN_CENTER;
            //CelTabEnc.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right       
            //CelTabEnc.Border = 0;
            //TabEncabezado.AddCell(CelTabEnc);

            //CelTabEnc = new PdfPCell(new Phrase(Date, _FuenteTitulos10NB));
            //CelTabEnc.Rowspan = 2;
            //CelTabEnc.VerticalAlignment = Element.ALIGN_RIGHT;
            //CelTabEnc.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right       
            //CelTabEnc.Border = 0;
            //TabEncabezado.AddCell(CelTabEnc);

            //Tabla Titulos

            PdfPTable TabEncabezado = new PdfPTable(2);
            float[] widthsEnc = new float[] { 350.0f, 650.0f };
            TabEncabezado.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            TabEncabezado.SetTotalWidth(widthsEnc);

            //Agregar el Logo a la tabla encabezado
            TabEncabezado.AddCell(LogoEmpresa);



            PdfPTable TabTitulos = new PdfPTable(1);
            float[] widthsTit = new float[] { 500.0f };
            TabTitulos.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            TabTitulos.SetTotalWidth(widthsTit);


            PdfPCell CelTabTitulos = new PdfPCell(new Phrase(CNomEmp, _FuenteTitulos10));
            CelTabTitulos.Rowspan = 2;
            CelTabTitulos.VerticalAlignment = Element.ALIGN_CENTER;
            CelTabTitulos.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right       
            CelTabTitulos.Border = 0;
            TabTitulos.AddCell(CelTabTitulos);

            CelTabTitulos = new PdfPCell(new Phrase(CDirEmp + ", " + CColEmp + ", " + CPobEmp + ", " + CProEmp + ", " + CCodEmp, _FuenteTitulos10NB));
            CelTabTitulos.Rowspan = 2;
            CelTabTitulos.VerticalAlignment = Element.ALIGN_CENTER;
            CelTabTitulos.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right       
            CelTabTitulos.Border = 0;
            TabTitulos.AddCell(CelTabTitulos);

            CelTabTitulos = new PdfPCell(new Phrase(CCnifEmp, _FuenteTitulos10NB));
            CelTabTitulos.Rowspan = 2;
            CelTabTitulos.VerticalAlignment = Element.ALIGN_CENTER;
            CelTabTitulos.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right       
            CelTabTitulos.Border = 0;
            TabTitulos.AddCell(CelTabTitulos);

            CelTabTitulos = new PdfPCell(new Phrase("Reporte por Recaudación", _FuenteTitulos10));
            CelTabTitulos.Rowspan = 2;
            CelTabTitulos.VerticalAlignment = Element.ALIGN_CENTER;
            CelTabTitulos.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right       
            CelTabTitulos.Border = 0;
            TabTitulos.AddCell(CelTabTitulos);

            TabEncabezado.AddCell(TabTitulos);





            //Tabla datos Encabezado
            PdfPTable TabEncabezado2 = new PdfPTable(1);
            float[] widthsEnc2 = new float[] { 900.0f };
            TabEncabezado2.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            TabEncabezado2.SetTotalWidth(widthsEnc2);

            PdfPCell CelTabEnc2 = new PdfPCell(new Phrase(encabezado1, _FuenteTitulos10NB));
            CelTabEnc2.Rowspan = 2;
            CelTabEnc2.VerticalAlignment = Element.ALIGN_LEFT;
            CelTabEnc2.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
            CelTabEnc2.Border = 0;
            TabEncabezado2.AddCell(CelTabEnc2);

            CelTabEnc2 = new PdfPCell(new Phrase(encabezado2 + "             FECHA DE EMISIÓN: " + DateTime.Now, _FuenteTitulos10NB));
            CelTabEnc2.Rowspan = 2;
            CelTabEnc2.VerticalAlignment = Element.ALIGN_LEFT;
            CelTabEnc2.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
            CelTabEnc2.Border = 0;
            TabEncabezado2.AddCell(CelTabEnc2);


            //Tabla de Conceptos
            PdfPTable Tabespacio = new PdfPTable(5);
            float[] widthsespacio = new float[] { 50.0f, 50.0f, 80.0f, 90.0f, 90.0f };
            Tabespacio.DefaultCell.Border = iTextSharp.text.Rectangle.ALIGN_LEFT;
            Tabespacio.SetTotalWidth(widthsespacio);


            //Tabla de Conceptos
            PdfPTable TabConceptos = new PdfPTable(6);
            float[] widthsConceptos = new float[] { 70f, 70f, 250f, 80f, 50f, 80f };
            TabConceptos.DefaultCell.Border = iTextSharp.text.Rectangle.BOX;
            //Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#9b2226");
            //TabConceptos.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(colFromHex);
            TabConceptos.SetTotalWidth(widthsConceptos);

            PdfPCell CelConceptos = new PdfPCell(new Phrase("Recibo", _FuenteConceptos9W));
            CelConceptos.Rowspan = 2;
            CelConceptos.VerticalAlignment = Element.ALIGN_LEFT;
            CelConceptos.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right       
            CelConceptos.Border = 3;
            CelConceptos.BackgroundColor = new iTextSharp.text.BaseColor(141, 67, 40);
            TabConceptos.AddCell(CelConceptos);

            CelConceptos = new PdfPCell(new Phrase("Fecha", _FuenteConceptos9W));
            CelConceptos.Rowspan = 2;
            CelConceptos.VerticalAlignment = Element.ALIGN_LEFT;
            CelConceptos.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right       
            CelConceptos.Border = 3;
            CelConceptos.BackgroundColor = new iTextSharp.text.BaseColor(141, 67, 40);
            TabConceptos.AddCell(CelConceptos);

            CelConceptos = new PdfPCell(new Phrase("Nombre", _FuenteConceptos9W));
            CelConceptos.Rowspan = 2;
            CelConceptos.VerticalAlignment = Element.ALIGN_LEFT;
            CelConceptos.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right       
            CelConceptos.Border = 3;
            CelConceptos.BackgroundColor = new iTextSharp.text.BaseColor(141, 67, 40);
            TabConceptos.AddCell(CelConceptos);

            CelConceptos = new PdfPCell(new Phrase("Total", _FuenteConceptos9W));
            CelConceptos.Rowspan = 2;
            CelConceptos.VerticalAlignment = Element.ALIGN_LEFT;
            CelConceptos.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
            CelConceptos.Border = 3;
            CelConceptos.BackgroundColor = new iTextSharp.text.BaseColor(141, 67, 40);
            TabConceptos.AddCell(CelConceptos);

            CelConceptos = new PdfPCell(new Phrase("Forma", _FuenteConceptos9W));
            CelConceptos.Rowspan = 2;
            CelConceptos.VerticalAlignment = Element.ALIGN_LEFT;
            CelConceptos.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
            CelConceptos.Border = 3;
            CelConceptos.BackgroundColor = new iTextSharp.text.BaseColor(141, 67, 40);
            TabConceptos.AddCell(CelConceptos);

            CelConceptos = new PdfPCell(new Phrase("Cancelado", _FuenteConceptos9W));
            CelConceptos.Rowspan = 2;
            CelConceptos.VerticalAlignment = Element.ALIGN_LEFT;
            CelConceptos.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
            CelConceptos.Border = 3;
            CelConceptos.BackgroundColor = new iTextSharp.text.BaseColor(141, 67, 40);
            TabConceptos.AddCell(CelConceptos);

            //Agregar tablas al Documento
            ReportexRubroPredial.Add(TabVacio);
            ReportexRubroPredial.Add(TabEncabezado);
            ReportexRubroPredial.Add(TabVacio);
            ReportexRubroPredial.Add(TabEncabezado2);
            ReportexRubroPredial.Add(Tabespacio);
            ReportexRubroPredial.Add(TabConceptos);

            try {
                Conexion_a_BD.Conectar();
                if (cmbcaja.SelectedValue != null)
                {
                    //SQL = "select distinct idReciboMaestro, Folio, fecha, Nombre,Total,CCODPAGO,Cancelado  from predialchico.vRecaudacion where fecha between '" + fechaini.SelectedDate.ToString("yyyy/MM/dd") + "' and '" + fechafin.SelectedDate.ToString("yyyy/MM/dd") + "' and caja = '" + cmbcaja.SelectedValue + "' order by Folio asc";

                    //ordenar por folio
                    SQL = "select distinct idReciboMaestro, Folio, fecha, Nombre,Total,idformapago,Cancelado  from ReciboMaestro where fecha between '" + fechaini.SelectedDate.ToString("yyyy/MM/dd") + "' and '" + fechafin.SelectedDate.ToString("yyyy/MM/dd") + "' and caja = '" + cmbcaja.SelectedValue + "' order by Folio asc";
                }

                else
                {
                    SQL = "select distinct idReciboMaestro, Folio, fecha, Nombre,Total,idformapago,Cancelado  from ReciboMaestro where fecha between '" + fechaini.SelectedDate.ToString("yyyy/MM/dd") + "' and '" + fechafin.SelectedDate.ToString("yyyy/MM/dd") + "' order by Folio asc" ;


                }
                
                DataTable datosconc = Conexion_a_BD.Consulta(SQL);

                for (int i = 0; i < datosconc.Rows.Count; i++)
                {
                   idReciboMaestr = datosconc.Rows[i]["idReciboMaestro"].ToString();
                   folioReciboMaestro = int.Parse(datosconc.Rows[i]["Folio"].ToString());
                   fech = DateTime.Parse(datosconc.Rows[i]["fecha"].ToString());
                   fecha = fech.ToShortDateString();
                   nombre = datosconc.Rows[i]["Nombre"].ToString();
                   total = decimal.Parse(datosconc.Rows[i]["Total"].ToString());
                   forma = datosconc.Rows[i]["idformapago"].ToString();
                   cancelado = datosconc.Rows[i]["Cancelado"].ToString();
                    

                    //Tabla de Conceptos
                    PdfPTable TabDatos = new PdfPTable(6);
                    float[] widthsesp = new float[] { 70f, 80f, 250f, 60f, 60f, 80f };
                    TabDatos.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    TabDatos.SetTotalWidth(widthsesp);

                    PdfPCell CelDato = new PdfPCell(new Phrase(folioReciboMaestro.ToString(), _Color));
                    CelDato.Rowspan = 2;
                    CelDato.VerticalAlignment = Element.ALIGN_LEFT;
                    CelDato.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right       
                    CelDato.Border = 3;
                    TabDatos.AddCell(CelDato);

                    CelDato = new PdfPCell(new Phrase(fecha, _Color));
                    CelDato.Rowspan = 2;
                    CelDato.VerticalAlignment = Element.ALIGN_LEFT;
                    CelDato.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    CelDato.Border = 3;
                    TabDatos.AddCell(CelDato);


                    CelDato = new PdfPCell(new Phrase(nombre, _Color));
                    CelDato.Rowspan = 2;
                    CelDato.VerticalAlignment = Element.ALIGN_LEFT;
                    CelDato.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right       
                    CelDato.Border = 3;
                    TabDatos.AddCell(CelDato);

                    CelDato = new PdfPCell(new Phrase(total.ToString("C"), _Color));
                    CelDato.Rowspan = 2;
                    CelDato.VerticalAlignment = Element.ALIGN_LEFT;
                    CelDato.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    CelDato.Border = 3;
                    TabDatos.AddCell(CelDato);

                    CelDato = new PdfPCell(new Phrase(forma, _Color));
                    CelDato.Rowspan = 2;
                    CelDato.VerticalAlignment = Element.ALIGN_LEFT;
                    CelDato.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right       
                    CelDato.Border = 3;
                    TabDatos.AddCell(CelDato);

                    CelDato = new PdfPCell(new Phrase(cancelado, _Color));
                    CelDato.Rowspan = 2;
                    CelDato.VerticalAlignment = Element.ALIGN_LEFT;
                    CelDato.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    CelDato.Border = 3;
                    TabDatos.AddCell(CelDato);
                    ReportexRubroPredial.Add(TabDatos);

                    DataTableReader datoscon = new DataTableReader(datosconc);

                    SQL = " select * from reciboesclavo RE inner join ReciboMaestro RM on RM.SERIE=RE.SERIE AND RE.recibo=RM.folio and RM.idReciboMaestro = '" + idReciboMaestr + "' ";
                    DataTable datosconceptoReca = Conexion_a_BD.Consulta(SQL);

                    for (int k = 0; k < datosconceptoReca.Rows.Count; k++)
                    {

                        string cantidad = datosconceptoReca.Rows[k]["Cantidad"].ToString();
                        string concepto = datosconceptoReca.Rows[k]["Concepto"].ToString();
                        decimal importe = decimal.Parse(datosconceptoReca.Rows[k]["Importe"].ToString());

                        PdfPTable TabDatos1 = new PdfPTable(6);
                        float[] widthsesp1 = new float[] { 40f, 300f, 80f, 80f, 70f, 30f };
                        TabDatos1.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        TabDatos1.SetTotalWidth(widthsesp1);

                        PdfPCell CelDato1 = new PdfPCell(new Phrase(cantidad, _FuenteNormal7B));
                        CelDato1 = new PdfPCell(new Phrase(cantidad, _FuenteNormal7B));
                        CelDato1.Rowspan = 2;
                        CelDato1.VerticalAlignment = Element.ALIGN_LEFT;
                        CelDato1.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                        CelDato1.Border = 0;
                        TabDatos1.AddCell(CelDato1);


                        CelDato1 = new PdfPCell(new Phrase(concepto, _FuenteNormal7B));
                        CelDato1.Rowspan = 2;
                        CelDato1.VerticalAlignment = Element.ALIGN_LEFT;
                        CelDato1.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                        CelDato1.Border = 0;
                        TabDatos1.AddCell(CelDato1);

                        CelDato1 = new PdfPCell(new Phrase(importe.ToString("C"), _FuenteNormal7B));
                        CelDato1.Rowspan = 2;
                        CelDato1.VerticalAlignment = Element.ALIGN_LEFT;
                        CelDato1.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                        CelDato1.Border = 0;
                        TabDatos1.AddCell(CelDato1);

                        CelDato1 = new PdfPCell(new Phrase(importe.ToString("C"), _FuenteNormal7B));
                        CelDato1.Rowspan = 2;
                        CelDato1.VerticalAlignment = Element.ALIGN_LEFT;
                        CelDato1.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                        CelDato1.Border = 0;
                        TabDatos1.AddCell(CelDato1);

                        CelDato1 = new PdfPCell(new Phrase("", _FuenteNormal7B));
                        CelDato1.Rowspan = 2;
                        CelDato1.VerticalAlignment = Element.ALIGN_LEFT;
                        CelDato1.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                        CelDato1.Border = 0;
                        TabDatos1.AddCell(CelDato1);

                        CelDato1 = new PdfPCell(new Phrase("", _FuenteNormal7B));
                        CelDato1.Rowspan = 2;
                        CelDato1.VerticalAlignment = Element.ALIGN_LEFT;
                        CelDato1.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                        CelDato1.Border = 0;
                        TabDatos1.AddCell(CelDato1);

                        ReportexRubroPredial.Add(TabDatos1);
                        
                        

                    }
                    ReportexRubroPredial.Add(TabVacio);
                    DataTableReader dat = new DataTableReader(datosconceptoReca);

                    totalFinal += double.Parse(total.ToString());
                    contador = contador + 1;
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
            Conexion_a_BD.Desconectar();

            try
            {
                if (cmbcaja.SelectedValue != null)
                {
                    //SQL = "select SUM(Total) as totalGeneral from predialchico.VRecaudacion where fecha between '" + fechaini.SelectedDate.ToString("yyyy/MM/dd") + "' and '" + fechafin.SelectedDate.ToString("yyyy/MM/dd") + "' and caja = '" + cmbcaja.SelectedValue + "' and Cancelado = 'A'";

                    SQL = "select count(RE.llave) as NumConceptos from reciboesclavo RE inner join Recibomaestro RM on RM.FOLIO=RE.RECIBO AND RM.SERIE=RE.SERIE where fecha between '" + fechaini.SelectedDate.ToString("yyyy/MM/dd") + "' and '" + fechafin.SelectedDate.ToString("yyyy/MM/dd") + "' and caja = '" + cmbcaja.SelectedValue + "' and cancelado = 'A'";

                    SQL1 = "select count(RE.llave) as NumConceptos from reciboesclavo RE inner join Recibomaestro RM on RM.FOLIO=RE.RECIBO AND RM.SERIE=RE.SERIE where fecha between '" + fechaini.SelectedDate.ToString("yyyy/MM/dd") + "' and '" + fechafin.SelectedDate.ToString("yyyy/MM/dd") + "' and caja = '" + cmbcaja.SelectedValue + "' and cancelado = 'C'";
                }

                else
                {
                    //SQL = "select SUM(Total) as totalGeneral from predialchico.VRecaudacion where fecha between '" + fechaini.SelectedDate.ToString("yyyy/MM/dd") + "' and '" + fechafin.SelectedDate.ToString("yyyy/MM/dd") + "' and Cancelado = 'A'";

                    SQL = "select count(RE.llave) as NumConceptos from reciboesclavo RE inner join Recibomaestro RM on RM.FOLIO=RE.RECIBO AND RM.SERIE=RE.SERIE where fecha between '" + fechaini.SelectedDate.ToString("yyyy/MM/dd") + "' and '" + fechafin.SelectedDate.ToString("yyyy/MM/dd") + "' and cancelado = 'A'";

                    SQL1 = "select count(RE.llave) as NumConceptos from reciboesclavo RE inner join Recibomaestro RM on RM.FOLIO=RE.RECIBO AND RM.SERIE=RE.SERIE where fecha between '" + fechaini.SelectedDate.ToString("yyyy/MM/dd") + "' and '" + fechafin.SelectedDate.ToString("yyyy/MM/dd") + "' and cancelado = 'C'";

                }

                
                DataTable NumConc = Conexion_a_BD.Consultas(SQL);
                for (int i = 0; i < NumConc.Rows.Count; i++)
                {
                    //double.TryParse(totalG.Rows[i]["recib"].ToString(), out recib);
                    int.TryParse(NumConc.Rows[i]["NumConceptos"].ToString(), out numConceptos);
                }

                DataTable NumConcCan = Conexion_a_BD.Consultas(SQL1);
                for (int i = 0; i < NumConcCan.Rows.Count; i++)
                {
                    //double.TryParse(totalG.Rows[i]["recib"].ToString(), out recib);
                    int.TryParse(NumConcCan.Rows[i]["NumConceptos"].ToString(), out numConceptosCan);
                }

                //recib = Math.Round(recib, 2);
                descuento = Math.Round(descuento, 2);
                totalFinal = Math.Round(totalFinal, 2);
                descuento = Math.Round(descuento, 2);

                // recib   = Math.Round(recib, 2);
                // total1  = Math.Round(total1, 2);
                //efectivo = Math.Round(efectivo, 2);
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }


            PdfPTable TabCantSubtotal = new PdfPTable(4);
            float[] widthsCantSub = new float[] { 200f, 200f, 100f, 100f };
            TabCantSubtotal.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            TabCantSubtotal.SetTotalWidth(widthsCantSub);

            clsconv let = new clsconv();
            //string mensaje = let.enletras(CTBruto.ToString());
            PdfPCell CelCantLetra = new PdfPCell(new Phrase("Conceptos Totales: ", _FuenteContenido9B));
            CelCantLetra.Rowspan = 2;
            CelCantLetra.VerticalAlignment = Element.ALIGN_LEFT;
            CelCantLetra.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
            CelCantLetra.Border = 0;
            TabCantSubtotal.AddCell(CelCantLetra);

            //decimal Subtotal = Convert.ToDecimal(contador.ToString());
            PdfPCell CelSubtotal = new PdfPCell(new Phrase(numConceptos.ToString(), _FuenteContenido9B));
            CelSubtotal.Rowspan = 2;
            CelSubtotal.VerticalAlignment = Element.ALIGN_CENTER;
            CelSubtotal.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
            CelSubtotal.Border = 0;
            TabCantSubtotal.AddCell(CelSubtotal);


            PdfPCell CelSub = new PdfPCell(new Phrase("Cancelados: ", _FuenteContenido9B));
            CelSub.Rowspan = 2;
            CelSub.VerticalAlignment = Element.ALIGN_LEFT;
            CelSub.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
            CelSub.Border = 0;
            TabCantSubtotal.AddCell(CelSub);

            //decimal TG = Convert.ToDecimal(subtotal.ToString());
            PdfPCell CelTG = new PdfPCell(new Phrase(numConceptosCan.ToString(), _FuenteContenido9B));
            CelTG.Rowspan = 2;
            CelTG.VerticalAlignment = Element.ALIGN_CENTER;
            CelTG.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
            CelTG.Border = 0;
            TabCantSubtotal.AddCell(CelTG);

            ReportexRubroPredial.Add(TabCantSubtotal);
            ReportexRubroPredial.Add(TabVacio);
            ReportexRubroPredial.Add(TabVacio);






            PdfPTable TabForma = new PdfPTable(2);
            float[] widthsForm = new float[] { 200f, 200f };
            TabForma.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            TabForma.SetTotalWidth(widthsForm);

            PdfPCell CelForm = new PdfPCell(new Phrase("TOTAL POR FORMA DE PAGO", _FuenteContenido9B));
            CelForm.Rowspan = 2;
            CelForm.VerticalAlignment = Element.ALIGN_LEFT;
            CelForm.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
            CelForm.Border = 0;
            TabForma.AddCell(CelForm);
            
            PdfPCell CelVacio = new PdfPCell(new Phrase("", _FuenteContenido9B));
            CelVacio.Rowspan = 2;
            CelVacio.VerticalAlignment = Element.ALIGN_LEFT;
            CelVacio.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
            CelVacio.Border = 0;
            TabForma.AddCell(CelVacio);

            Conexion_a_BD.Conectar();

            if (cmbcaja.SelectedValue != null)
            {
                SQL = "select  P.CDESPAGO, sum(Total) as TotalxFPago from recibomaestro Rm inner join fpago P on Rm.idformapago=P.CCODPAGO where fecha between '" + fechaini.SelectedDate.ToString("yyyy/MM/dd") + "' and '" + fechafin.SelectedDate.ToString("yyyy/MM/dd") + "' and  caja = '" + cmbcaja.SelectedValue + "'and Cancelado ='A' group by idformapago order by idformapago asc; ";
            }

            else
            {
                SQL = "select  P.CDESPAGO, sum(Total) as TotalxFPago from recibomaestro Rm inner join fpago P on Rm.idformapago=P.CCODPAGO where fecha between '" + fechaini.SelectedDate.ToString("yyyy/MM/dd") + "' and '" + fechafin.SelectedDate.ToString("yyyy/MM/dd") + "' and cancelado = 'A'";
            }

            


            DataTable tipoPgo = Conexion_a_BD.Consulta(SQL);
            totalGeneral = 0.0M;
            for (int i = 0; i < tipoPgo.Rows.Count; i++)
            {

                string Tipo = tipoPgo.Rows[i]["CDESPAGO"].ToString();
                Decimal totalFormaPago = decimal.Parse(tipoPgo.Rows[i]["TotalxFPago"].ToString());

                PdfPTable TabF = new PdfPTable(3);
                float[] widthsF = new float[] { 400f, 100f, 100f };
                TabF.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                TabF.SetTotalWidth(widthsF);

                PdfPCell CelEfectivo = new PdfPCell(new Phrase(Tipo, _FuenteContenido9B));
                CelEfectivo.Rowspan = 2;
                CelEfectivo.VerticalAlignment = Element.ALIGN_LEFT;
                CelEfectivo.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                CelEfectivo.Border = 0;
                TabF.AddCell(CelEfectivo);

                //decimal TotalEfe = Convert.ToDecimal(total1.ToString());
                PdfPCell CelTotalEfec = new PdfPCell(new Phrase(totalFormaPago.ToString("C"), _FuenteContenido9B));
                CelTotalEfec.Rowspan = 2;
                CelTotalEfec.VerticalAlignment = Element.ALIGN_LEFT;
                CelTotalEfec.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                CelTotalEfec.Border = 2;
                TabF.AddCell(CelTotalEfec);

                PdfPCell CelVacioEfe = new PdfPCell(new Phrase("", _FuenteContenido9B));
                CelVacioEfe.Rowspan = 2;
                CelVacioEfe.VerticalAlignment = Element.ALIGN_LEFT;
                CelVacioEfe.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                CelVacioEfe.Border = 0;
                TabF.AddCell(CelVacioEfe);

                ReportexRubroPredial.Add(TabF);

                totalGeneral += totalFormaPago;

            }
            PdfPTable TabTG = new PdfPTable(3);
            float[] widthsTG = new float[] { 400f, 100f, 100f };
            TabTG.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            TabTG.SetTotalWidth(widthsTG);

            PdfPCell CelTot = new PdfPCell(new Phrase("TOTAL GENERAL: ", _FuenteContenido9B));
            CelTot.Rowspan = 2;
            CelTot.VerticalAlignment = Element.ALIGN_LEFT;
            CelTot.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
            CelTot.Border = 0;
            TabTG.AddCell(CelTot);


            //decimal TotalGeneral = Convert.ToDecimal(total1.ToString());
            PdfPCell CelTotalGeneral = new PdfPCell(new Phrase(totalGeneral.ToString("C"), _FuenteContenido9B));
            CelTotalGeneral.Rowspan = 2;
            CelTotalGeneral.VerticalAlignment = Element.ALIGN_RIGHT;
            CelTotalGeneral.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
            CelTotalGeneral.Border = 0;
            TabTG.AddCell(CelTotalGeneral);

            PdfPCell CelTotal1 = new PdfPCell(new Phrase("", _FuenteContenido9B));
            CelTotal1.Rowspan = 2;
            CelTotal1.VerticalAlignment = Element.ALIGN_RIGHT;
            CelTotal1.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
            CelTotal1.Border = 0;
            TabTG.AddCell(CelTotal1);

            // Tabla firmas
            PdfPTable TableFirmas = new PdfPTable(5);
            float[] widthsFirmas = new float[] { 150.0f, 200.0f, 100.0f, 200.0f , 150.0f};
            TableFirmas.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            TableFirmas.SetTotalWidth(widthsFirmas);

            PdfPCell CelFirmas = new PdfPCell(new Phrase(" ", _FuenteContenido9B));
            CelFirmas.Rowspan = 2;
            CelFirmas.VerticalAlignment = Element.ALIGN_LEFT;
            CelFirmas.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
            CelFirmas.Border = 0;
            TableFirmas.AddCell(CelFirmas);


            CelFirmas = new PdfPCell(new Phrase("FIRMA CAJERO", _FuenteContenido9B));
            CelFirmas.Rowspan = 2;
            CelFirmas.VerticalAlignment = Element.ALIGN_LEFT;
            CelFirmas.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right       
            CelFirmas.Border = 1;
            TableFirmas.AddCell(CelFirmas);

            CelFirmas = new PdfPCell(new Phrase(" ", _FuenteContenido9B));
            CelFirmas.Rowspan = 2;
            CelFirmas.VerticalAlignment = Element.ALIGN_LEFT;
            CelFirmas.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
            CelFirmas.Border = 0;
            TableFirmas.AddCell(CelFirmas);

            CelFirmas = new PdfPCell(new Phrase("FIRMA RESPONSABLE", _FuenteContenido9B));
            CelFirmas.Rowspan = 2;
            CelFirmas.VerticalAlignment = Element.ALIGN_LEFT;
            CelFirmas.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right       
            CelFirmas.Border = 1;
            TableFirmas.AddCell(CelFirmas);

            CelFirmas = new PdfPCell(new Phrase(" ", _FuenteContenido9B));
            CelFirmas.Rowspan = 2;
            CelFirmas.VerticalAlignment = Element.ALIGN_LEFT;
            CelFirmas.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
            CelFirmas.Border = 0;
            TableFirmas.AddCell(CelFirmas);



            ReportexRubroPredial.Add(TabTG);
            ReportexRubroPredial.Add(TabVacio);
            ReportexRubroPredial.Add(TabVacio);
            ReportexRubroPredial.Add(TabVacio);
            ReportexRubroPredial.Add(TabVacio);
            ReportexRubroPredial.Add(TableFirmas);
            ReportexRubroPredial.Close();
            PdfWrite.Close();
            Process.Start(cadenapdf);

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
    }
}
