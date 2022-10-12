using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Predial10.Resources.CODE
{
    class lineaimprimir
    {

        public System.Drawing.Font prtFont;
        public System.Drawing.Font letradefault = new System.Drawing.Font("Sans Serif Condensed", 7);
        public int coordenadax;
        public int coordenaday;
        public string cadena = "";
        public System.Drawing.StringFormat alinea = new System.Drawing.StringFormat();

        public enum alineacion
        {
            Izquierda,
            Derecha,
            Centrado
        }
        public lineaimprimir(int x, int y, string cad, System.Drawing.Font f, alineacion aline)
        {
            coordenadax = x;
            coordenaday = y;
            cadena = cad;

            prtFont = f;
            if (aline == alineacion.Derecha)
            { alinea.Alignment = System.Drawing.StringAlignment.Far; }

            if (aline == alineacion.Izquierda)
            { alinea.Alignment = System.Drawing.StringAlignment.Near; }
            if (aline == alineacion.Centrado)
            { alinea.Alignment = System.Drawing.StringAlignment.Center; }
        }
    }
}
