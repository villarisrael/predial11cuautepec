﻿

using iTextSharp.text;
using iTextSharp.text.pdf;
using Predial10.Resources.CODE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




class RepAdeudoComu
{
    string SQL1 = "";
    string SQL2 = "";
    string SQLDescuentos = "";

    public Decimal recargos = 0.0M;
    public Decimal acurecargo = 0.0M;
    public Decimal Adeudo = 0.0M;
    public Decimal acuAdeudo = 0.0M;
    Decimal AcumuTotal = 0.0M;
    Decimal Total = 0.00M;
    public string comunidad = "";
    public string recCancelado = "";


    public void CrearReporte()
    {
        try
        {



            //Obtener datos del organismo
            DataTable DatosEmpresa = new DataTable();
            String CNomEmp = "";
            String CDirEmp = "";
            String CColEmp = "";
            String CCodEmp = "";
            String CProEmp = "";

            String CPobEmp = "";
            String CCnifEmp = "";

            DatosEmpresa = Conexion_a_BD.Consultasql("*", "empresa", "CODEMP");

            CNomEmp = DatosEmpresa.Rows[0]["CNOMBRE"].ToString();
            CDirEmp = DatosEmpresa.Rows[0]["CDOMICILIO"].ToString();
            CColEmp = DatosEmpresa.Rows[0]["CCOLONIA"].ToString();
            CPobEmp = DatosEmpresa.Rows[0]["CPOBLACION"].ToString();
            CProEmp = DatosEmpresa.Rows[0]["CPROVINCIA"].ToString();

            CCodEmp = DatosEmpresa.Rows[0]["CCODPOS"].ToString();
            CCnifEmp = DatosEmpresa.Rows[0]["CNIF"].ToString();
            byte[] logoempresa = (byte[])DatosEmpresa.Rows[0]["logo"];

            //Crear ruta para el pdf

            #region "Crear Directorio"

            string Datetime = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
            string cadenapdf2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AdeudoComunidades_");
            if (!Directory.Exists(cadenapdf2))
            {
                Directory.CreateDirectory(cadenapdf2);
            }

            string nombreArchivo = "AdeudoComunidades_" + Datetime + ".pdf";
            string rutaArchivo = Path.Combine(cadenapdf2, nombreArchivo);



            //Obtener Logo de la BD
            //  byte[] logoempresa = Conexion_a_BD.obtenerimagen("select logo from empresa");

            //Obtener los datos de Recaudación
            List<string> ListRecaudacion = new List<string>();
            //System.Drawing.Image logoempresa2 = byteArrayToImage(logoempresa);
            iTextSharp.text.Image LogoEmpresa = iTextSharp.text.Image.GetInstance(logoempresa);

            //Crear los documentos
            Document ReportexRubroPredial = new Document(iTextSharp.text.PageSize.LETTER, 5.0f, 5.0f, 5.0f, 10.0f);
            ReportexRubroPredial.SetMargins(5.0f, 5.0f, 5.0f, 20.0f);

            PdfWriter PdfWrite = PdfWriter.GetInstance(ReportexRubroPredial, new System.IO.FileStream(rutaArchivo, FileMode.Create));

            #endregion


            #region "Formato Letras"



            //Declarar formatos de letras

            iTextSharp.text.Font _FuenteTitulos10 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font _FuenteTitulos10NB = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font _FuenteContenido7B = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font _FuenteSellos5 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 5, iTextSharp.text.Font.ITALIC, BaseColor.BLACK);
            iTextSharp.text.Font _FuenteConceptos7W = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
            iTextSharp.text.Font _FuenteFolio15B = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 15, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font _FuenteNormal7B = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);


            #endregion

            //Abrir el Documento

            ReportexRubroPredial.Open();

            //Crear las tablas

            #region "Tabla Encabezado"



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

            CelTabTitulos = new PdfPCell(new Phrase("REPORTE DE ADEUDO X COMUNIDADES", _FuenteTitulos10));
            CelTabTitulos.Rowspan = 2;
            CelTabTitulos.VerticalAlignment = Element.ALIGN_CENTER;
            CelTabTitulos.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right       
            CelTabTitulos.Border = 0;
            TabTitulos.AddCell(CelTabTitulos);

            TabEncabezado.AddCell(TabTitulos);



            #endregion


            #region "Tabla de Encabezados"

            //Tabla datos Encabezado
            PdfPTable TabEncabezado2 = new PdfPTable(1);
            float[] widthsEnc2 = new float[] { 600.0f };
            TabEncabezado2.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            TabEncabezado2.SetTotalWidth(widthsEnc2);

            PdfPCell CelTabEnc2 = new PdfPCell(new Phrase("", _FuenteTitulos10NB));
            CelTabEnc2.Rowspan = 2;
            CelTabEnc2.VerticalAlignment = Element.ALIGN_LEFT;
            CelTabEnc2.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
            CelTabEnc2.Border = 0;
            TabEncabezado2.AddCell(CelTabEnc2);

            CelTabEnc2 = new PdfPCell(new Phrase( "            FECHA DE EMISIÓN: " + Datetime, _FuenteTitulos10NB));
            CelTabEnc2.Rowspan = 2;
            CelTabEnc2.VerticalAlignment = Element.ALIGN_LEFT;
            CelTabEnc2.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
            CelTabEnc2.Border = 0;
            TabEncabezado2.AddCell(CelTabEnc2);

            #endregion


            #region "Tabla Conceptos"
            //Tabla de Conceptos
            PdfPTable Tabespacio = new PdfPTable(5);
            float[] widthsespacio = new float[] { 50.0f, 50.0f, 80.0f, 90.0f, 90.0f };
            Tabespacio.DefaultCell.Border = iTextSharp.text.Rectangle.ALIGN_LEFT;
            Tabespacio.SetTotalWidth(widthsespacio);


            //Tabla de Conceptos
            PdfPTable TabConceptos = new PdfPTable(4);
            float[] widthsConceptos = new float[] { 300f, 100f, 100f, 100f };
            TabConceptos.DefaultCell.Border = iTextSharp.text.Rectangle.BOX;
            //Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#9b2226");

            //TabConceptos.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor();
            TabConceptos.SetTotalWidth(widthsConceptos);

            PdfPCell CelConceptos = new PdfPCell(new Phrase("Comunidad", _FuenteConceptos7W));
            CelConceptos.Rowspan = 2;
            CelConceptos.VerticalAlignment = Element.ALIGN_LEFT;
            CelConceptos.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
            CelConceptos.BackgroundColor = new iTextSharp.text.BaseColor(141, 67, 40);
            CelConceptos.Border = 3;
            TabConceptos.AddCell(CelConceptos);

            CelConceptos = new PdfPCell(new Phrase("Recargos", _FuenteConceptos7W));
            CelConceptos.Rowspan = 2;
            CelConceptos.VerticalAlignment = Element.ALIGN_LEFT;
            CelConceptos.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
            CelConceptos.BackgroundColor = new iTextSharp.text.BaseColor(141, 67, 40);
            CelConceptos.Border = 3;
            TabConceptos.AddCell(CelConceptos);
            CelConceptos = new PdfPCell(new Phrase("Adeudo", _FuenteConceptos7W));
            CelConceptos.Rowspan = 2;
            CelConceptos.VerticalAlignment = Element.ALIGN_LEFT;
            CelConceptos.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
            CelConceptos.BackgroundColor = new iTextSharp.text.BaseColor(141, 67, 40);
            CelConceptos.Border = 3;
            TabConceptos.AddCell(CelConceptos);

            CelConceptos = new PdfPCell(new Phrase("Total", _FuenteConceptos7W));
            CelConceptos.Rowspan = 2;
            CelConceptos.VerticalAlignment = Element.ALIGN_LEFT;
            CelConceptos.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right       
            CelConceptos.BackgroundColor = new iTextSharp.text.BaseColor(141, 67, 40);
            CelConceptos.Border = 3;
            TabConceptos.AddCell(CelConceptos);



            //Agregar tablas al Documento
            ReportexRubroPredial.Add(TabVacio);
            ReportexRubroPredial.Add(TabEncabezado);
            ReportexRubroPredial.Add(TabVacio);
            ReportexRubroPredial.Add(TabEncabezado2);
            ReportexRubroPredial.Add(Tabespacio);
            ReportexRubroPredial.Add(TabConceptos);

            String CPartida, CConcepto;

            try
            {
                Conexion_a_BD.Conectar();

                SQL1 = "SELECT comunidad,recargos, Adeudo,Total FROM adeudocomunidad";








                DataTable datosconcepto = Conexion_a_BD.Consulta(SQL1);



                //Tabla de Conceptos
                PdfPTable TabDatos = new PdfPTable(4);
                float[] widthsesp = new float[] { 300f, 100f, 100f, 100f };
                TabDatos.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                TabDatos.SetTotalWidth(widthsesp);

                for (int j = 0; j < datosconcepto.Rows.Count; j++)
                {
                    comunidad = datosconcepto.Rows[j]["comunidad"].ToString();
                    recargos = Decimal.Parse(datosconcepto.Rows[j]["recargos"].ToString());
                    Adeudo = Decimal.Parse(datosconcepto.Rows[j]["Adeudo"].ToString());
                    Total = Decimal.Parse(datosconcepto.Rows[j]["Total"].ToString());






                    PdfPCell CelDato = new PdfPCell(new Phrase(comunidad, _FuenteNormal7B));
                    CelDato.Rowspan = 2;
                    CelDato.VerticalAlignment = Element.ALIGN_LEFT;
                    CelDato.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    CelDato.Border = 2;
                    TabDatos.AddCell(CelDato);

                    CelDato = new PdfPCell(new Phrase(recargos.ToString("C"), _FuenteNormal7B));
                    CelDato.Rowspan = 2;
                    CelDato.VerticalAlignment = Element.ALIGN_RIGHT;
                    CelDato.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    CelDato.Border = 2;
                    TabDatos.AddCell(CelDato);
                    CelDato = new PdfPCell(new Phrase(Adeudo.ToString("C"), _FuenteNormal7B));
                    CelDato.Rowspan = 2;
                    CelDato.VerticalAlignment = Element.ALIGN_RIGHT;
                    CelDato.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    CelDato.Border = 2;
                    TabDatos.AddCell(CelDato);

                    CelDato = new PdfPCell(new Phrase(Total.ToString("C"), _FuenteNormal7B));
                    CelDato.Rowspan = 2;
                    CelDato.VerticalAlignment = Element.ALIGN_RIGHT;
                    CelDato.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    CelDato.Border = 2;
                    TabDatos.AddCell(CelDato);

                    AcumuTotal += Total;
                    acurecargo += recargos;
                    acuAdeudo += Adeudo;

                 



                }
                //DataTableReader datoscon = new DataTableReader(datosconcepto);


            #endregion





            #region "Tabla Totales y descuentos"






            PdfPCell CelVac = new PdfPCell(new Phrase("TOTAL GENERAL:  ", _FuenteContenido7B));
            CelVac.Rowspan = 2;
            CelVac.VerticalAlignment = Element.ALIGN_LEFT;
            CelVac.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
            CelVac.Border = 0;
            TabDatos.AddCell(CelVac);

            PdfPCell CelTot = new PdfPCell(new Phrase(acurecargo.ToString("C"), _FuenteContenido7B));
            CelTot.Rowspan = 2;
            CelTot.VerticalAlignment = Element.ALIGN_RIGHT;
            CelTot.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
            CelTot.Border = 0;
            TabDatos.AddCell(CelTot);

            PdfPCell CelTotA = new PdfPCell(new Phrase(acuAdeudo.ToString("C"), _FuenteContenido7B));
            CelTotA.Rowspan = 2;
            CelTotA.VerticalAlignment = Element.ALIGN_RIGHT;
            CelTotA.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
            CelTotA.Border = 0;
                TabDatos.AddCell(CelTotA);

            //totalGeneral = Subtotal - AcumuDescuento;
            PdfPCell CelTotal = new PdfPCell(new Phrase(AcumuTotal.ToString("C"), _FuenteContenido7B));
            CelTotal.Rowspan = 2;
            CelTotal.VerticalAlignment = Element.ALIGN_RIGHT;
            CelTotal.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
            CelTotal.Border = 1;
                TabDatos.AddCell(CelTotal);

            ReportexRubroPredial.Add(TabDatos);


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el reporte: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
            }


            PdfPTable TableFirmas = new PdfPTable(5);
            float[] widthsFirmas = new float[] { 70.0f, 200.0f, 70.0f, 200.0f, 70.0f };
            TableFirmas.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            TableFirmas.SetTotalWidth(widthsFirmas);

            PdfPCell CelFirmas = new PdfPCell(new Phrase(" ", _FuenteContenido7B));
            CelFirmas.Rowspan = 2;
            CelFirmas.VerticalAlignment = Element.ALIGN_LEFT;
            CelFirmas.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
            CelFirmas.Border = 0;
            TableFirmas.AddCell(CelFirmas);






            ReportexRubroPredial.Add(TabVacio);
           



            #endregion





            // Se cierra el documento
            ReportexRubroPredial.Close();
            PdfWrite.Close();
            // Visualizar el pdf
            Process.Start(rutaArchivo);
            Conexion_a_BD.Desconectar();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear el reporte: {ex.Message}");
            Console.WriteLine($"StackTrace: {ex.StackTrace}");
        }

    }
}