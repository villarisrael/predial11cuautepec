using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Predial10.Resources.CODE
{
    class clsbimestre
    {
        public DateTime fecha = new DateTime();
        public int Nobimestre = 12;
        public string Nombrebimestre = "";

        public clsbimestre(DateTime _fecha)
        {
            fecha = _fecha;
            Nobimestre = Numbimestre();
            Nombrebimestre = _Nombrebimestre(Nobimestre) + " " + fecha.Year.ToString ();
        }

        int Numbimestre()
        {
            int div = 1;
            switch (fecha.Month)
            {
                case 1:
                    {
                        return 1;
                        break;
                    }

                case 2:
                    {
                        return 1;
                        break;
                    }

                case 3:
                    {
                        return 2;
                        break;
                    }
                case 4:
                    {
                        return 2;
                        break;
                    }
                case 5:
                    {
                        return 3;
                        break;
                    }
                case 6:
                    {
                        return 3;
                        break;
                    }

                case 7:
                    {
                        return 4;
                        break;
                    }
                case 8:
                    {
                        return 4;
                        break;
                    }
                case 9:
                    {
                        return 5;
                        break;
                    }
                case 10:
                    {
                        return 5;
                        break;
                    }
                case 11:
                    {
                        return 6;
                        break;
                    }
                case 12:
                    {
                        return 6;
                        break;
                    }
            }

            return div;
        }

        string _Nombrebimestre(int _bim)
        {
            string div = "DIC";
            switch (_bim)
            {
                case 1:
                    {
                        return "FEB";
                        break;
                    }

                case 2:
                    {
                        return "ABR";
                        break;
                    }

                case 3:
                    {
                        return "JUN";
                        break;
                    }
                case 4:
                    {
                        return "AGO";
                        break;
                    }
                case 5:
                    {
                        return "OCT";
                        break;
                    }
                case 6:
                    {
                        return "DIC";
                        break;
                    }

            }

            return div;
        }

        public static DateTime  Restabimestres(DateTime _fecha, int _bimeses)
        {
            DateTime Valor = new DateTime ();
            Valor = DateTime.Now;

            Valor =_fecha.AddMonths(_bimeses * 2 *-1);

            return Valor;
        }

        public static DateTime Sumabimestres(DateTime _fecha, int _bimeses)
        {
            DateTime Valor = new DateTime();
            Valor = DateTime.Now;

            Valor = _fecha.AddMonths(_bimeses * 2);

            return Valor;
        }

       

   }


}
