using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using OfficeOpenXml.Style;
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
using System.Windows.Forms;


namespace Predial10.Recaudacion
{
    class reportexRubrosITSharp
    {
        string SQL1 = "";
        string SQL2 = "";
        string SQLDescuentos = "";
        Decimal totalGeneral = 0.0M;
        Decimal totalBruto = 0.0M;
        Decimal totalNeto = 0.0M;
        Decimal AcumuDescuento = 0.0M;
        Decimal CTNeto, CTBruto = 0.00M;
        public string NumConceptos = "";
        public string recCancelado = "";
        public Int64 numRecCancelados = 0;
        DataTable datosCancelados;
        public void CrearReporte(string consulta, string FechaInicio, string FechaFin, string encabezado1, string encabezado2, object idCaja)
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

            #region "Crear Directorio"

            string Date = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
            String cadenapdf2 = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ReportexRubroPredial\\").Trim();

            if (!Directory.Exists(cadenapdf2))
            {

                DirectoryInfo di = Directory.CreateDirectory(cadenapdf2);

            }
            string ruta = "\\ReportexRubroPredial\\" + "ReportexRubro_" + FechaInicio + "-" + FechaFin + idCaja + ".PDF";
            String cadenapdf = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + ruta).Trim();

            //Obtener Logo de la BD
            byte[] logoempresa = Conexion_a_BD.obtenerimagen("select logo from empresa");

            //Obtener los datos de Recaudación
            List<string> ListRecaudacion = new List<string>();
            //System.Drawing.Image logoempresa2 = byteArrayToImage(logoempresa);
            iTextSharp.text.Image LogoEmpresa = iTextSharp.text.Image.GetInstance(logoempresa);

            //Crear los documentos
            Document ReportexRubroPredial = new Document(iTextSharp.text.PageSize.LETTER, 5.0f, 5.0f, 5.0f, 10.0f);
            ReportexRubroPredial.SetMargins(5.0f, 5.0f, 5.0f, 20.0f);

            PdfWriter PdfWrite = PdfWriter.GetInstance(ReportexRubroPredial, new System.IO.FileStream(cadenapdf, FileMode.Create));

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

                CelTabTitulos = new PdfPCell(new Phrase("Reporte por Rubros", _FuenteTitulos10));
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

            PdfPCell CelTabEnc2 = new PdfPCell(new Phrase(encabezado1, _FuenteTitulos10NB));
            CelTabEnc2.Rowspan = 2;
            CelTabEnc2.VerticalAlignment = Element.ALIGN_LEFT;
            CelTabEnc2.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
            CelTabEnc2.Border = 0;
            TabEncabezado2.AddCell(CelTabEnc2);

            CelTabEnc2 = new PdfPCell(new Phrase(encabezado2 + "            FECHA DE EMISIÓN: " + Date, _FuenteTitulos10NB));
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
            PdfPTable TabConceptos = new PdfPTable(5);
            float[] widthsConceptos = new float[] { 70f, 230f, 100f, 100f, 100f };
            TabConceptos.DefaultCell.Border = iTextSharp.text.Rectangle.BOX;
            //Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#9b2226");

            //TabConceptos.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor();
            TabConceptos.SetTotalWidth(widthsConceptos);

            PdfPCell CelConceptos = new PdfPCell(new Phrase("Partida", _FuenteConceptos7W));
            CelConceptos.Rowspan = 2;
            CelConceptos.VerticalAlignment = Element.ALIGN_LEFT;
            CelConceptos.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
            CelConceptos.BackgroundColor = new iTextSharp.text.BaseColor(141, 67, 40);
            CelConceptos.Border = 3;
            TabConceptos.AddCell(CelConceptos);

            CelConceptos = new PdfPCell(new Phrase("Concepto", _FuenteConceptos7W));
            CelConceptos.Rowspan = 2;
            CelConceptos.VerticalAlignment = Element.ALIGN_LEFT;
            CelConceptos.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
            CelConceptos.BackgroundColor = new iTextSharp.text.BaseColor(141, 67, 40);
            CelConceptos.Border = 3;
            TabConceptos.AddCell(CelConceptos);

            CelConceptos = new PdfPCell(new Phrase("No. Recibos", _FuenteConceptos7W));
            CelConceptos.Rowspan = 2;
            CelConceptos.VerticalAlignment = Element.ALIGN_LEFT;
            CelConceptos.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right       
            CelConceptos.BackgroundColor = new iTextSharp.text.BaseColor(141, 67, 40);
            CelConceptos.Border = 3;
            TabConceptos.AddCell(CelConceptos);

            CelConceptos = new PdfPCell(new Phrase("Total Bruto", _FuenteConceptos7W));
            CelConceptos.Rowspan = 2;
            CelConceptos.VerticalAlignment = Element.ALIGN_LEFT;
            CelConceptos.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
            CelConceptos.BackgroundColor = new iTextSharp.text.BaseColor(141, 67, 40);
            CelConceptos.Border = 3;
            TabConceptos.AddCell(CelConceptos);

            CelConceptos = new PdfPCell(new Phrase("Total Neto", _FuenteConceptos7W));
            CelConceptos.Rowspan = 2;
            CelConceptos.VerticalAlignment = Element.ALIGN_LEFT;
            CelConceptos.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
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
                    //SQL = "select count(IdReciboMaestro) as NumConcepto, sum(MontoSindescuento) as TotalB, SUM(MontoSindescuento * PORCDESCUENTO /100 ) as TotalN, Partida, Concepto, Cantidad, Importe, Importe from predialchico.vrubros where fecha between '" + fechaini.SelectedDate.ToString("yyyy/MM/dd") + "' and '" + fechafin.SelectedDate.ToString("yyyy/MM/dd") + "' and caja = '" + cmbcaja.SelectedValue + "' group by Partida";

                    //Consulta hecha por los chicos de estadía
                    //SQL = "select count(IdReciboMaestro) as NumConcepto, sum(MontoSindescuento) as TotalB, SUM(Importe) as TotalN, Partida, Concepto, Cantidad, Importe, Importe from predialchico.vrubros where fecha between '" + fechaini.SelectedDate.ToString("yyyy/MM/dd") + "' and '" + fechafin.SelectedDate.ToString("yyyy/MM/dd") + "' and caja = '" + cmbcaja.SelectedValue + "' group by Partida";
                    

                    if (idCaja == null)
                    {
                        SQL1 = "select count(RM.idReciboMaestro) as NumConcepto, sum(RE.MontoSinDescuento) as TotalBruto,  sum(RE.importe) as TotalNeto, RE.Concepto as Concepto, D.Partida as Partida, RM.Cancelado as Cancelado from recibomaestro RM inner join reciboesclavo RE inner join Detalle D on RM.serie = RE.serie and RM.folio = RE.recibo and RE.Clave = D.clave and RM.fecha between '" + FechaInicio + "' and '" + FechaFin + "' and RM.Cancelado = 'A' group by D.Partida";

                        //SQL2 = "select count(RM.idReciboMaestro) as NumConcepto, sum(RE.MontoSinDescuento) as TotalBruto,  sum(RE.importe) as TotalNeto, RE.Concepto as Concepto, D.Partida as Partida, RM.Cancelado as Cancelado from recibomaestro RM inner join reciboesclavo RE inner join Detalle D on RM.serie = RE.serie and RM.folio = RE.recibo and RE.Clave = D.clave and RM.fecha between '" + FechaInicio + "' and '" + FechaFin + "' and RM.Cancelado = 'C' group by D.Partida";

                        string SQLCancelados = $"SELECT COUNT(CANCELADO) AS CANCELADOS FROM RECIBOMAESTRO WHERE FECHA BETWEEN '{FechaInicio}' AND '{FechaFin}' and cancelado = 'C'";

                        datosCancelados = Conexion_a_BD.Consulta(SQLCancelados);
                    }
                    else
                    {
                        SQL1 = "select count(RM.idReciboMaestro) as NumConcepto, sum(RE.MontoSinDescuento) as TotalBruto,  sum(RE.importe) as TotalNeto, RE.Concepto as Concepto, D.Partida as Partida, RM.Cancelado as Cancelado from recibomaestro RM inner join reciboesclavo RE inner join Detalle D on RM.serie = RE.serie and RM.folio = RE.recibo and RE.Clave = D.clave and RM.fecha between '" + FechaInicio + "' and '" + FechaFin + "' and RM.Cancelado = 'A' and caja = '" + idCaja + "' group by D.Partida";

                        //SQL2 = "select count(RM.idReciboMaestro) as NumConcepto, sum(RE.MontoSinDescuento) as TotalBruto,  sum(RE.importe) as TotalNeto, RE.Concepto as Concepto, D.Partida as Partida, RM.Cancelado as Cancelado from recibomaestro RM inner join reciboesclavo RE inner join Detalle D on RM.serie = RE.serie and RM.folio = RE.recibo and RE.Clave = D.clave and RM.fecha between '" + FechaInicio + "' and '" + FechaFin + "' and RM.Cancelado = 'C' and caja = '" + idCaja + "' group by D.Partida";

                        string SQLCancelados = $"SELECT COUNT(CANCELADO) AS CANCELADOS FROM RECIBOMAESTRO WHERE FECHA BETWEEN '{FechaInicio}' AND '{FechaFin}' and cancelado = 'C' and caja = '{idCaja}'";

                        datosCancelados = Conexion_a_BD.Consulta(SQLCancelados);

                    }
                


                DataTable datosconcepto = Conexion_a_BD.Consulta(SQL1);

                    //DataTable datosconcepto2 = Conexion_a_BD.Consulta(SQL2);

                    //for (int j = 0; j < datosconcepto2.Rows.Count; j++)
                    //{
                    //    numRecCancelados = numRecCancelados + 1;
                    //}


                    for (int j = 0; j < datosconcepto.Rows.Count; j++)
                {
                    NumConceptos = datosconcepto.Rows[j]["NumConcepto"].ToString();
                    CPartida = datosconcepto.Rows[j]["Partida"].ToString();
                    CConcepto = datosconcepto.Rows[j]["Concepto"].ToString();
                        recCancelado = datosconcepto.Rows[j]["Cancelado"].ToString();

                        CTNeto = Decimal.Parse(datosconcepto.Rows[j]["TotalNeto"].ToString());
                        CTBruto = Decimal.Parse(datosconcepto.Rows[j]["TotalBruto"].ToString());

                        
                        //CTNeto = datosconcepto.Rows[j]["TotalN"].ToString();

                        //string neto = CTNeto.ToString();
                        //if (CTNeto == 0M)
                        //{
                        //    CTNeto = Decimal.Parse(datosconcepto.Rows[j]["TotalB"].ToString());
                        //}
                        //else
                        //{
                        //    CTNeto = Decimal.Parse(datosconcepto.Rows[j]["TotalN"].ToString());
                        //}
                        

                    //Tabla de Conceptos
                    PdfPTable TabDatos = new PdfPTable(5);
                    float[] widthsesp = new float[] { 70f, 230f, 100f, 100f, 100f };
                    TabDatos.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    TabDatos.SetTotalWidth(widthsesp);

                    PdfPCell CelDato = new PdfPCell(new Phrase(CPartida, _FuenteNormal7B));
                    CelDato.Rowspan = 2;
                    CelDato.VerticalAlignment = Element.ALIGN_LEFT;
                    CelDato.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    CelDato.Border = 2;
                    TabDatos.AddCell(CelDato);

                    CelDato = new PdfPCell(new Phrase(CConcepto, _FuenteNormal7B));
                    CelDato.Rowspan = 2;
                    CelDato.VerticalAlignment = Element.ALIGN_LEFT;
                    CelDato.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
                    CelDato.Border = 2;
                    TabDatos.AddCell(CelDato);

                    CelDato = new PdfPCell(new Phrase(NumConceptos, _FuenteNormal7B));
                    CelDato.Rowspan = 2;
                    CelDato.VerticalAlignment = Element.ALIGN_LEFT;
                    CelDato.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right       
                    CelDato.Border = 2;
                    TabDatos.AddCell(CelDato);

                    CelDato = new PdfPCell(new Phrase(CTBruto.ToString("C"), _FuenteNormal7B));
                    CelDato.Rowspan = 2;
                    CelDato.VerticalAlignment = Element.ALIGN_LEFT;
                    CelDato.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    CelDato.Border = 2;
                    TabDatos.AddCell(CelDato);

                    
                    CelDato = new PdfPCell(new Phrase(CTNeto.ToString("C"), _FuenteNormal7B));
                    CelDato.Rowspan = 2;
                    CelDato.VerticalAlignment = Element.ALIGN_LEFT;
                    CelDato.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                    CelDato.Border = 2;
                    TabDatos.AddCell(CelDato);
                    ReportexRubroPredial.Add(TabDatos);

                    totalBruto += CTBruto;
                    totalNeto += CTNeto;


                }
                //DataTableReader datoscon = new DataTableReader(datosconcepto);
                AcumuDescuento = totalBruto - totalNeto;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }

            #endregion





            #region "Tabla Totales y descuentos"

            //try
            //{
            //    SQL1 = "select tipodescuento, sum(MontoSinDescuento-Importe) As TotalxDesc from recibomaestro RM inner join reciboesclavo RE on RM.serie = RE.serie and RM.folio = RE.recibo and RM.fecha between '" + fechaini.SelectedDate.ToString("yyyy/MM/dd") + "' and '" + fechafin.SelectedDate.ToString("yyyy/MM/dd") + "' and caja = '" + cmboficina.SelectedValue + "' and RM.Cancelado = 'A' group by tipodescuento";
            //    DataTable datototal = Conexion_a_BD.Consultas(SQL1);

            //    for (int i = 0; i < datototal.Rows.Count; i++)
            //    {
            //        double.TryParse(datototal.Rows[i]["total"].ToString(), out subtotal);
            //        double.TryParse(datototal.Rows[i]["descuento"].ToString(), out descuento);
            //    }
            //    subtotal = Math.Round(subtotal, 2);
            //    descuento = Math.Round(descuento, 2);
            //    total = Math.Round(subtotal - descuento, 2);
            //    descuento = Math.Round(descuento, 2);
            //}
            //catch (Exception EX)
            //{
            //    MessageBox.Show(EX.Message);
            //}


            // Tabla Subtotal y Cantidad con letra
            PdfPTable TabCantSubtotal = new PdfPTable(3);
            float[] widthsCantSub = new float[] { 350f, 250f, 100f };
            TabCantSubtotal.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            TabCantSubtotal.SetTotalWidth(widthsCantSub);

            clsconv let = new clsconv();
            //string mensaje = let.enletras(CTBruto.ToString());
            PdfPCell CelCantLetra = new PdfPCell(new Phrase("", _FuenteContenido7B));
            CelCantLetra.Rowspan = 2;
            CelCantLetra.VerticalAlignment = Element.ALIGN_LEFT;
            CelCantLetra.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
            CelCantLetra.Border = 0;
            TabCantSubtotal.AddCell(CelCantLetra);

            //decimal Subtotal = Convert.ToDecimal(subtotal.ToString());
            PdfPCell CelSubtotal = new PdfPCell(new Phrase(totalBruto.ToString("C"), _FuenteContenido7B));
            CelSubtotal.Rowspan = 2;
            CelSubtotal.VerticalAlignment = Element.ALIGN_CENTER;
            CelSubtotal.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
            CelSubtotal.Border = 0;
            TabCantSubtotal.AddCell(CelSubtotal);

            CelSubtotal = new PdfPCell(new Phrase(" ", _FuenteContenido7B));
            CelSubtotal.Rowspan = 2;
            CelSubtotal.VerticalAlignment = Element.ALIGN_CENTER;
            CelSubtotal.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
            CelSubtotal.Border = 0;
            TabCantSubtotal.AddCell(CelSubtotal);



            //Mostrar total en descuentos

            PdfPTable TabTotDesc = new PdfPTable(3);
            float[] widthsTotDesc = new float[] { 400f, 200f, 120f };
            TabTotDesc.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            TabTotDesc.SetTotalWidth(widthsTotDesc);

            //clsconv let = new clsconv();
            //string mensaje = let.enletras(CTBruto.ToString());
            PdfPCell CelTotDesc = new PdfPCell(new Phrase("Conceptos cancelados: " + datosCancelados.Rows[0]["CANCELADOS"], _FuenteContenido7B));
            CelTotDesc.Rowspan = 2;
            CelTotDesc.VerticalAlignment = Element.ALIGN_LEFT;
            CelTotDesc.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
            CelTotDesc.Border = 0;
            TabTotDesc.AddCell(CelTotDesc);

            //decimal Subtotal = Convert.ToDecimal(subtotal.ToString());
            CelTotDesc = new PdfPCell(new Phrase("Descuentos: ", _FuenteContenido7B));
            CelTotDesc.Rowspan = 2;
            CelTotDesc.VerticalAlignment = Element.ALIGN_RIGHT;
            CelTotDesc.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
            CelTotDesc.Border = 0;
            TabTotDesc.AddCell(CelTotDesc);

            CelTotDesc = new PdfPCell(new Phrase(AcumuDescuento.ToString("C"), _FuenteContenido7B));
            CelTotDesc.Rowspan = 2;
            CelTotDesc.VerticalAlignment = Element.ALIGN_RIGHT;
            CelTotDesc.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
            CelTotDesc.Border = 1;
            TabTotDesc.AddCell(CelTotDesc);

            //PdfPCell CelVac1 = new PdfPCell(new Phrase("Descuentos: ", _FuenteContenido7B));
            //CelVac1.Rowspan = 2;
            //CelVac1.VerticalAlignment = Element.ALIGN_LEFT;
            //CelVac1.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
            //CelVac1.Border = 0;
            //TabCantSubtotal.AddCell(CelVac1);

            //decimal Descuento = Convert.ToDecimal(descuento.ToString());
            //PdfPCell CelDescuento = new PdfPCell(new Phrase(Descuento.ToString("C"), _FuenteContenido7B));
            //CelDescuento.Rowspan = 2;
            //CelDescuento.VerticalAlignment = Element.ALIGN_RIGHT;
            //CelDescuento.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
            //CelDescuento.Border = 0;
            //TabCantSubtotal.AddCell(CelDescuento);


            //PdfPCell CelDescuentoR = new PdfPCell(new Phrase(" ", _FuenteContenido7B));
            //CelDescuentoR.Rowspan = 2;
            //CelDescuentoR.VerticalAlignment = Element.ALIGN_LEFT;
            //CelDescuentoR.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
            //CelDescuentoR.Border = 0;
            //TabCantSubtotal.AddCell(CelDescuentoR);




            PdfPTable TabCantDescuentos = new PdfPTable(2);
            float[] widthsCantDescu = new float[] { 800.0f, 300.0f };
            TabCantDescuentos.DefaultCell.Border = iTextSharp.text.Rectangle.TOP_BORDER;
            TabCantDescuentos.SetTotalWidth(widthsCantDescu);


            //Obtener todos los descuentos según el tipo
            if (idCaja == null)
                {
                    SQLDescuentos = "select tipodescuento, sum(MontoSinDescuento-Importe) As TotalxDesc from recibomaestro RM inner join reciboesclavo RE on RM.serie = RE.serie and RM.folio = RE.recibo and RM.fecha between '" + FechaInicio + "' and '" + FechaFin + "' and RM.Cancelado = 'A' group by tipodescuento order by TotalxDesc asc";
                }
                else
                {
                    SQLDescuentos = "select tipodescuento, sum(MontoSinDescuento-Importe) As TotalxDesc from recibomaestro RM inner join reciboesclavo RE on RM.serie = RE.serie and RM.folio = RE.recibo and RM.fecha between '" + FechaInicio + "' and '" + FechaFin + "' and caja = '" + idCaja + "' and RM.Cancelado = 'A' group by tipodescuento order by TotalxDesc asc";
                }
            

            DataTable datosdescuentos = Conexion_a_BD.Consulta(SQLDescuentos);

            string tipoDescuento = "";
            Decimal totalxTDesc = 0.0M;


                PdfPCell CelVa1 = new PdfPCell();


            for (int j = 0; j < datosdescuentos.Rows.Count; j++)
            {

                tipoDescuento = datosdescuentos.Rows[j]["tipodescuento"].ToString();
                totalxTDesc = Decimal.Parse(datosdescuentos.Rows[j]["TotalxDesc"].ToString());

                    if (tipoDescuento == "Ninguno" & DateTime.Now.Month == 1)
                    {
                        CelVa1 = new PdfPCell(new Phrase("Descuentos Enero 30%: ", _FuenteContenido7B));
                        CelVa1.Rowspan = 2;
                        CelVa1.VerticalAlignment = Element.ALIGN_RIGHT;
                        CelVa1.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                        CelVa1.Border = 0;
                        TabCantDescuentos.AddCell(CelVa1);
                    }
                    else if (tipoDescuento == "Ninguno" & DateTime.Now.Month == 2)
                    {
                        CelVa1 = new PdfPCell(new Phrase("Descuentos Febrero 20%: ", _FuenteContenido7B));
                        CelVa1.Rowspan = 2;
                        CelVa1.VerticalAlignment = Element.ALIGN_RIGHT;
                        CelVa1.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                        CelVa1.Border = 0;
                        TabCantDescuentos.AddCell(CelVa1);
                    }
                    else if(tipoDescuento == "Ninguno" & DateTime.Now.Month == 3)
                    {
                        CelVa1 = new PdfPCell(new Phrase("Descuentos Marzo 10%: ", _FuenteContenido7B));
                        CelVa1.Rowspan = 2;
                        CelVa1.VerticalAlignment = Element.ALIGN_RIGHT;
                        CelVa1.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                        CelVa1.Border = 0;
                        TabCantDescuentos.AddCell(CelVa1);
                    }

                    else
                    {
                        CelVa1 = new PdfPCell(new Phrase(tipoDescuento + ": ", _FuenteContenido7B));
                        CelVa1.Rowspan = 2;
                        CelVa1.VerticalAlignment = Element.ALIGN_RIGHT;
                        CelVa1.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                        CelVa1.Border = 0;
                        TabCantDescuentos.AddCell(CelVa1);
                    }
                

                CelVa1 = new PdfPCell(new Phrase(totalxTDesc.ToString("C"), _FuenteTitulos10NB));
                CelVa1.Rowspan = 2;
                CelVa1.VerticalAlignment = Element.ALIGN_RIGHT;
                CelVa1.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                CelVa1.Border = 0;
                TabCantDescuentos.AddCell(CelVa1);

            }


            PdfPTable TabCantSubtotal2 = new PdfPTable(3);
            float[] widthsCantSub2 = new float[] { 400f, 200f, 120f };
            TabCantSubtotal2.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            TabCantSubtotal2.SetTotalWidth(widthsCantSub2);

            PdfPCell CelVac = new PdfPCell(new Phrase(" ", _FuenteContenido7B));
            CelVac.Rowspan = 2;
            CelVac.VerticalAlignment = Element.ALIGN_LEFT;
            CelVac.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
            CelVac.Border = 0;
            TabCantSubtotal2.AddCell(CelVac);

            PdfPCell CelTot = new PdfPCell(new Phrase("TOTAL GENERAL: ", _FuenteContenido7B));
            CelTot.Rowspan = 2;
            CelTot.VerticalAlignment = Element.ALIGN_RIGHT;
            CelTot.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right       
            CelTot.Border = 0;
            TabCantSubtotal2.AddCell(CelTot);



            //totalGeneral = Subtotal - AcumuDescuento;
            PdfPCell CelTotal = new PdfPCell(new Phrase(totalNeto.ToString("C"), _FuenteContenido7B));
            CelTotal.Rowspan = 2;
            CelTotal.VerticalAlignment = Element.ALIGN_RIGHT;
            CelTotal.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
            CelTotal.Border = 1;
            TabCantSubtotal2.AddCell(CelTotal);



                PdfPTable TableFirmas = new PdfPTable(5);
                float[] widthsFirmas = new float[] { 70.0f, 200.0f, 70.0f, 200.0f, 70.0f};
                TableFirmas.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                TableFirmas.SetTotalWidth(widthsFirmas);

                PdfPCell CelFirmas = new PdfPCell(new Phrase(" ", _FuenteContenido7B));
                CelFirmas.Rowspan = 2;
                CelFirmas.VerticalAlignment = Element.ALIGN_LEFT;
                CelFirmas.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                CelFirmas.Border = 0;
                TableFirmas.AddCell(CelFirmas);

                CelFirmas = new PdfPCell(new Phrase("FIRMA CAJERO", _FuenteContenido7B));
                CelFirmas.Rowspan = 2;
                CelFirmas.VerticalAlignment = Element.ALIGN_CENTER;
                CelFirmas.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right       
                CelFirmas.Border = 1;
                TableFirmas.AddCell(CelFirmas);

                CelFirmas = new PdfPCell(new Phrase(" ", _FuenteContenido7B));
                CelFirmas.Rowspan = 2;
                CelFirmas.VerticalAlignment = Element.ALIGN_LEFT;
                CelFirmas.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                CelFirmas.Border = 0;
                TableFirmas.AddCell(CelFirmas);

                CelFirmas = new PdfPCell(new Phrase("FIRMA RESPONSABLE", _FuenteContenido7B));
                CelFirmas.Rowspan = 2;
                CelFirmas.VerticalAlignment = Element.ALIGN_CENTER;
                CelFirmas.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right       
                CelFirmas.Border = 1;
                TableFirmas.AddCell(CelFirmas);

                CelFirmas = new PdfPCell(new Phrase(" ", _FuenteContenido7B));
                CelFirmas.Rowspan = 2;
                CelFirmas.VerticalAlignment = Element.ALIGN_LEFT;
                CelFirmas.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right       
                CelFirmas.Border = 0;
                TableFirmas.AddCell(CelFirmas);



                ReportexRubroPredial.Add(TabCantSubtotal);
            ReportexRubroPredial.Add(TabVacio);
            ReportexRubroPredial.Add(TabTotDesc);
            ReportexRubroPredial.Add(TabVacio);
            ReportexRubroPredial.Add(TabCantDescuentos);
            ReportexRubroPredial.Add(TabVacio);
            ReportexRubroPredial.Add(TabCantSubtotal2);
                ReportexRubroPredial.Add(TabVacio);
                ReportexRubroPredial.Add(TabVacio);
                ReportexRubroPredial.Add(TabVacio);
                ReportexRubroPredial.Add(TabVacio);
                ReportexRubroPredial.Add(TableFirmas);


                #endregion





                // Se cierra el documento
                ReportexRubroPredial.Close();
            PdfWrite.Close();
            // Visualizar el pdf
            Process.Start(cadenapdf);
            Conexion_a_BD.Desconectar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void CrearReporteExcel(string consultaSQLP, string fechaInicioP, string fechaFinP, string encabezado1P, string encabezado2P, object idCajaP)
        {

            string SQL1 = "";
            string SQL2 = "";

            decimal acumuladorDescuento = 0.0M;
            decimal totalBruto = 0.0M;
            decimal totalNeto = 0.0M;

            String path = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ReportexRubroPredial\\").Trim();

            if (!Directory.Exists(path))
            {

                DirectoryInfo di = Directory.CreateDirectory(path);

            }

            string ruta = "\\ReportexRubroPredial\\" + "ReportexRubro_" + fechaInicioP + "-" + fechaFinP + idCajaP + ".xlsx";
            string pathReporte = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + ruta).Trim();



            if (idCajaP == null)
            {
                SQL1 = "select count(RM.idReciboMaestro) as NumRecibos, sum(RE.MontoSinDescuento) as TotalBruto,  sum(RE.importe) as TotalNeto, RE.Concepto as Concepto, D.Partida as Partida, RM.Cancelado as Cancelado from recibomaestro RM inner join reciboesclavo RE inner join Detalle D on RM.serie = RE.serie and RM.folio = RE.recibo and RE.Clave = D.clave and RM.fecha between '" + fechaInicioP + "' and '" + fechaFinP + "' and RM.Cancelado = 'A' group by D.Partida";

                SQL2 = "select count(RM.idReciboMaestro) as NumRecibos, sum(RE.MontoSinDescuento) as TotalBruto,  sum(RE.importe) as TotalNeto, RE.Concepto as Concepto, D.Partida as Partida, RM.Cancelado as Cancelado from recibomaestro RM inner join reciboesclavo RE inner join Detalle D on RM.serie = RE.serie and RM.folio = RE.recibo and RE.Clave = D.clave and RM.fecha between '" + fechaInicioP + "' and '" + fechaFinP + "' and RM.Cancelado = 'C' group by D.Partida";
            }
            else
            {
                SQL1 = "select count(RM.idReciboMaestro) as NumRecibos, sum(RE.MontoSinDescuento) as TotalBruto,  sum(RE.importe) as TotalNeto, RE.Concepto as Concepto, D.Partida as Partida, RM.Cancelado as Cancelado from recibomaestro RM inner join reciboesclavo RE inner join Detalle D on RM.serie = RE.serie and RM.folio = RE.recibo and RE.Clave = D.clave and RM.fecha between '" + fechaInicioP + "' and '" + fechaFinP + "' and RM.Cancelado = 'A' and caja = '" + idCajaP + "' group by D.Partida";

                SQL2 = "select count(RM.idReciboMaestro) as NumRecibos, sum(RE.MontoSinDescuento) as TotalBruto,  sum(RE.importe) as TotalNeto, RE.Concepto as Concepto, D.Partida as Partida, RM.Cancelado as Cancelado from recibomaestro RM inner join reciboesclavo RE inner join Detalle D on RM.serie = RE.serie and RM.folio = RE.recibo and RE.Clave = D.clave and RM.fecha between '" + fechaInicioP + "' and '" + fechaFinP + "' and RM.Cancelado = 'C' and caja = '" + idCajaP + "' group by D.Partida";
            }

            //new reportexRubrosITSharp().Export(pathReporte);

            //var elementos2 = Conexion_a_BD.Consulta(SQL1);


            //List<ReportexRurbos> reportexRubrosList = elementos2.Rows.Cast<ReportexRurbos>().ToList();

            try
            {

            
               
            DataTable datosconcepto = Conexion_a_BD.Consulta(SQL1);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage Ep = new ExcelPackage())
            {

            

            var Sheet = Ep.Workbook.Worksheets.Add("Reporte por Rubros");

            int row = 1;

            Sheet.Cells["A1:E1"].Style.Font.Size = 20;
            Sheet.Cells["A1:E1"].Style.Font.Name = "Calibri";
            Sheet.Cells["A1:E3"].Style.Font.Bold = true;
            Sheet.Cells["A1:E1"].Style.Font.Color.SetColor(Color.DarkBlue);
            Sheet.Cells["A1:E1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            Sheet.Cells["A1"].RichText.Add("Reporte por Rubros");


            row = 2;
            Sheet.Cells["A1:E1"].Style.Font.Size = 12;
            Sheet.Cells["A1:E1"].Style.Font.Name = "Calibri";
            Sheet.Cells["A1:E1"].Style.Border.Bottom.Style = ExcelBorderStyle.Hair;
            Sheet.Cells["A2:E2"].Style.Font.Bold = true;


            row = 2;
            string Fec = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
            Sheet.Cells[string.Format("A2", row)].Value = "FECHA DE EMISIÓN: ";
            Sheet.Cells[string.Format("B2", row)].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
            Sheet.Cells[string.Format("B2", row)].Value = Fec;

                Sheet.Cells[string.Format("B3", 3)].Value = encabezado2P + " " + encabezado1P;
                //Sheet.Cells[string.Format("D2", row)].Value = encabezado2P + " " + encabezado1P;
            //Sheet.Cells[string.Format("E2", row)].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
            //Sheet.Cells[string.Format("E2", row)].Value = encabezado2P;

            //Sheet.Cells[string.Format("F2", row)].Value = "DEL DÍA: ";
            //Sheet.Cells[string.Format("G2", row)].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
            //Sheet.Cells[string.Format("G2", row)].Value = encabezado1P;


            row = 4;
            Sheet.Cells.Style.Font.Name = "Calibri";
            Sheet.Cells.Style.Font.Size = 10;
            Sheet.Cells["A4:G4"].Style.Font.Bold = true;
            Sheet.Cells["A4:G4"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            Sheet.Cells["A4:G4"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);



            Sheet.Cells["A4"].RichText.Add("PARTIDA");
            
            Sheet.Cells["B4"].RichText.Add("CONCEPTO");
            Sheet.Cells["C4"].RichText.Add("NO. RECIBOS");
            
            Sheet.Cells["D4"].RichText.Add("TOTAL BRUTO");
            Sheet.Cells["E4"].RichText.Add("TOTAL NETO");


            row = 5;
            Sheet.Cells.Style.Font.Bold = false;


            for (int j = 0; j < datosconcepto.Rows.Count; j++)
            {
                string NumRecibos = datosconcepto.Rows[j]["NumRecibos"].ToString();
                string CPartida = datosconcepto.Rows[j]["Partida"].ToString();
                string CConcepto = datosconcepto.Rows[j]["Concepto"].ToString();
                string recCancelado = datosconcepto.Rows[j]["Cancelado"].ToString();

                decimal CTNeto = Decimal.Parse(datosconcepto.Rows[j]["TotalNeto"].ToString());
                decimal CTBruto = Decimal.Parse(datosconcepto.Rows[j]["TotalBruto"].ToString());
                //foreach (ReportexRurbos item in reportexRubrosList)
                //{
                //Clientes cliente = new ClientesContext().Clientes.Find(item.IDCliente);
                //Vendedor vendedor = new VendedorContext().Vendedores.Find(cliente.IDVendedor);
                //Oficina oficina = new OficinaContext().Oficinas.Find(cliente.IDOficina);

                Sheet.Cells[string.Format("A{0}", row)].Value = CPartida;
                //Sheet.Cells[string.Format("B{0}", row)].Style.Numberformat.Format = "$#,##0.00";
                Sheet.Cells[string.Format("B{0}", row)].Value = CConcepto.ToUpper();
                //Sheet.Cells[string.Format("C{0}", row)].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                Sheet.Cells[string.Format("C{0}", row)].Value = NumRecibos;
                //if (cliente.noExpediente == null)
                //{
                //    Sheet.Cells[string.Format("D{0}", row)].Value = "S/N";
                //}
                //else
                //{
                Sheet.Cells[string.Format("D{0}", row)].Style.Numberformat.Format = "$#,##0.00";
                Sheet.Cells[string.Format("D{0}", row)].Value = CTBruto;
                Sheet.Cells[string.Format("E{0}", row)].Style.Numberformat.Format = "$#,##0.00";
                Sheet.Cells[string.Format("E{0}", row)].Value = CTNeto;

                    totalBruto += CTBruto;
                    totalNeto += CTNeto;

                    
                    acumuladorDescuento = totalBruto - totalNeto;

                    row++;
                //}

            }

                row++;
                Sheet.Cells[string.Format("D{0}", row)].Style.Numberformat.Format = "$#,##0.00";
                Sheet.Cells[string.Format("D{0}", row)].Value = totalBruto;


                row = row + 2;

                
                string SQLCancelados = $"SELECT COUNT(CANCELADO) AS CANCELADOS FROM RECIBOMAESTRO WHERE FECHA BETWEEN '{fechaInicioP}' AND '{fechaFinP}' and cancelado = 'C'";
                DataTable datosCancelados = Conexion_a_BD.Consulta(SQLCancelados);
                //datosconcepto.Rows[j]["NumConcepto"].ToString();

                Sheet.Cells[string.Format("A{0}", row)].Value = "RECIBOS CANCELADOS";
                Sheet.Cells[string.Format("B{0}", row)].Value = datosCancelados.Rows[0]["CANCELADOS"];

                row = row + 2;

                Sheet.Cells[string.Format("A{0}", row)].Value = "DESCUENTOS";
                Sheet.Cells[string.Format("B{0}", row)].Style.Numberformat.Format = "$#,##0.00";
                Sheet.Cells[string.Format("B{0}", row)].Value = acumuladorDescuento;


                row = row + 2;



                if (idCajaP == null)
                {
                    SQLDescuentos = "select tipodescuento, sum(MontoSinDescuento-Importe) As TotalxDesc from recibomaestro RM inner join reciboesclavo RE on RM.serie = RE.serie and RM.folio = RE.recibo and RM.fecha between '" + fechaInicioP + "' and '" + fechaFinP + "' and RM.Cancelado = 'A' group by tipodescuento order by TotalxDesc asc";
                }
                else
                {
                    SQLDescuentos = "select tipodescuento, sum(MontoSinDescuento-Importe) As TotalxDesc from recibomaestro RM inner join reciboesclavo RE on RM.serie = RE.serie and RM.folio = RE.recibo and RM.fecha between '" + fechaInicioP + "' and '" + fechaFinP + "' and caja = '" + idCajaP + "' and RM.Cancelado = 'A' group by tipodescuento order by TotalxDesc asc";
                }


                row = row + 2;


                DataTable datosdescuentos = Conexion_a_BD.Consulta(SQLDescuentos);

                string tipoDescuento = "";
                decimal totalxTDesc = 0.0M;




                for (int j = 0; j < datosdescuentos.Rows.Count; j++)
                {

                    tipoDescuento = datosdescuentos.Rows[j]["tipodescuento"].ToString();
                    totalxTDesc = Decimal.Parse(datosdescuentos.Rows[j]["TotalxDesc"].ToString());

                    if (tipoDescuento == "Ninguno" & DateTime.Now.Month == 1)
                    {
                        Sheet.Cells[string.Format("A{0}", row)].Value = "DESCUENTOS ENERO 30%";
                        Sheet.Cells[string.Format("B{0}", row)].Value = acumuladorDescuento;
                    }
                    else if (tipoDescuento == "Ninguno" & DateTime.Now.Month == 2)
                    {
                        Sheet.Cells[string.Format("A{0}", row)].Value = "DESCUENTOS ENERO 20%";
                        Sheet.Cells[string.Format("B{0}", row)].Value = acumuladorDescuento;
                    }
                    else if (tipoDescuento == "Ninguno" & DateTime.Now.Month == 3)
                    {
                        Sheet.Cells[string.Format("A{0}", row)].Value = "DESCUENTOS ENERO 10%";
                        Sheet.Cells[string.Format("B{0}", row)].Value = acumuladorDescuento;
                    }

                    else
                    {

                        Sheet.Cells[string.Format("A{0}", row)].Value = tipoDescuento;
                        
                    }

                    Sheet.Cells[string.Format("B{0}", row)].Style.Numberformat.Format = "$#,##0.00";
                    Sheet.Cells[string.Format("B{0}", row)].Value = totalxTDesc;

                    row = row + 1;
                }

                row = row + 2;


                Sheet.Cells[string.Format("A{0}", row)].Value = "TOTAL GENERAL: ";
                Sheet.Cells[string.Format("B{0}", row)].Style.Numberformat.Format = "$#,##0.00";
                Sheet.Cells[string.Format("B{0}", row)].Value = totalNeto;


                Sheet.Cells["A:AZ"].AutoFitColumns();

                Ep.SaveAs(new FileInfo(pathReporte));

                    MessageBox.Show("DATOS EXPORTADOS A EXCEL CORRECTAMENTE");

            }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

    }

    public class ReportexRurbos
    {

        public int NumRecibos { get; set; }
        public string TotalBruto { get; set; }
        public decimal TotalNeto { get; set; }
        public string Concepto { get; set; }
        public decimal Partida { get; set; }
        public string Estatus { get; set; }
        
    }

    
}
