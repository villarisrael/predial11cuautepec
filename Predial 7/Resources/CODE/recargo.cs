using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Predial10.Resources.CODE
{
    class periodorecargo
    {
        public string periodobi = "";
        public string periodoan = "";
        public int numerobimes;
        public decimal recargos;
        public decimal porcrecargo=0;
        public decimal Montorecargos = 0;

        public periodorecargo( int nm , decimal pcr)
        {
            numerobimes = nm;
            porcrecargo = pcr;
            if ((porcrecargo == 0) || (numerobimes ==0))
            {
                recargos = 0;
            }
            else
            {
                recargos = numerobimes * (porcrecargo / 100);
            }
        }
        public periodorecargo()
        {

        }
    }
}
