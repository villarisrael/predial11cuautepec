using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;

namespace Predial10.Resources.CODE
{
    class imprimirnet
    {
        public PrinterSettings prtSettings;
        public PrintDocument prtDoc;
        public System.Drawing.Font prtFont;
        private Graphics lienzo;
        public Collection<lineaimprimir> lineas;
        private int lineaActual = 0;
        internal System.Windows.Forms.PrintPreviewDialog prtprev;


        public imprimirnet()
        {
            lineas = new Collection<lineaimprimir>();
            prtFont = new System.Drawing.Font("Courier New", 13);
            prtDoc = new PrintDocument();
            prtSettings = new PrinterSettings();
        }

        public void imprimir(int x, int y, string cad, lineaimprimir.alineacion ali, string letra, float sizeletra)
        {
            prtFont = new System.Drawing.Font(letra, sizeletra);
            lineas.Add(new lineaimprimir(x, y, cad, prtFont, ali));
        }

        public void mandardocumento(bool espreview)
        {
            if (!prtDoc.PrinterSettings.IsValid)
            {
                prtDoc.PrinterSettings = new PrinterSettings();
            }

            if (prtDoc.PrinterSettings.IsValid)
            {
                prtDoc.PrintPage += new PrintPageEventHandler(prtDoc_PrintPage);
            }
            lineaActual = 0;
            if (espreview)
            {
                prtprev = new System.Windows.Forms.PrintPreviewDialog();
                prtprev.Document = prtDoc;
                prtprev.Show();

            }
            else
            {
                prtDoc.Print();
            }
        }

        public void seleccionarimpresora()
        {
            System.Windows.Forms.PrintDialog prtdialog = new System.Windows.Forms.PrintDialog();
            prtdialog.AllowPrintToFile = false;
            prtdialog.PrintToFile = false;
            prtdialog.PrinterSettings = prtSettings;

            if (prtdialog.ShowDialog() == DialogResult.OK)
            {
                prtDoc.PrinterSettings = prtdialog.PrinterSettings;
            }

        }

        private void prtDoc_PrintPage(object sender, PrintPageEventArgs ev)
        {
            Single lineHeight;
            Single yPos = ev.MarginBounds.Top;
            Single leftMargin = ev.MarginBounds.Left;
            System.Drawing.Font printFont;

            //' Asignar el tipo de letra
            printFont = prtFont;
            lineHeight = printFont.GetHeight(ev.Graphics);

            try
            {
                for (int i = 0; i <= lineas.Count; i++)
                {
                    lineaimprimir l = lineas[i];
                    ev.Graphics.DrawString(l.cadena, l.prtFont, Brushes.Black, (int)(l.coordenadax), (int)(l.coordenaday), l.alinea);
                }
            }
            catch (Exception Exception)
            {
            }
            ev.HasMorePages = false;
        }
    }
}
