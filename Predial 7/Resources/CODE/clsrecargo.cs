using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Predial10.Resources.CODE
{
    class clsrecargo
    {
        public DateTime fecha = new DateTime();
        public DateTime fechadehoy = new DateTime();
        public decimal porcentaje = new decimal();

        public decimal Montobimestral;
        public decimal Montorecargo;
        public decimal recargo = new decimal();
       // public int tarifa = 1;
        public long periodosCount = 0;
       
        public decimal Recargo = 0;
        public int Periodosdescontados = 0;
        public decimal Porcentaje_de_descuento = 0;
        public tipopago tipo;
        public List <periodorecargo> periodos = new List <Predial10.Resources.CODE.periodorecargo >();

       public   enum tipopago
        {
            anual,
            bimestral
        }

        public  enum DateInterval
        {
            Day,
            DayOfYear,
            Hour,
            Minute,
            Month,
            Quarter,
            Second,
            Weekday,
            WeekOfYear,
            Year
        }

        public clsrecargo()
        {
            porcentaje = 0;
          
       
        }

        long diferenciadeperiodos()
        {
            if (tipo == tipopago.anual)
            {
                return DateDiff(DateInterval.Year, fecha, fechadehoy); 
            }
            if (tipo == tipopago.bimestral )
            {
                long bimeses=1;
                long meses = 1;
                
                meses = DateDiff(DateInterval.Month , fecha, fechadehoy);
                double division = 1;
                division = Convert.ToDouble(meses / 2);
                bimeses = Convert.ToInt32 (Math.Floor (division));
                return bimeses;
            }
            return 1;
        }

        int mesesadiciembre()
        {
            return 12 - fecha.Month;
        }
    

        public static long DateDiff(DateInterval interval, DateTime date1, DateTime date2)
        {
            long rs = 0;
            TimeSpan diff = date2.Subtract(date1);
            switch (interval)
            {
                case DateInterval.Day:
                case DateInterval.DayOfYear:
                    rs = (long)diff.TotalDays;
                    break;
                case DateInterval.Hour:
                    rs = (long)diff.TotalHours;
                    break;
                case DateInterval.Minute:
                    rs = (long)diff.TotalMinutes;
                    break;
                case DateInterval.Month:
                    rs = (date2.Month - date1.Month) + (12 * clsrecargo.DateDiff(DateInterval.Year, date1, date2));
                    break;
                case DateInterval.Quarter:
                    rs = (long)Math.Ceiling((double)(clsrecargo.DateDiff(DateInterval.Month, date1, date2) / 3.0));
                    break;
                case DateInterval.Second:
                    rs = (long)diff.TotalSeconds;
                    break;
                case DateInterval.Weekday:
                case DateInterval.WeekOfYear:
                    rs = (long)(diff.TotalDays / 7);
                    break;
                case DateInterval.Year:
                    rs = date2.Year - date1.Year;
                    break;
            }//switch
            return rs;
        }

        public void calcula()
        {
            periodos = null;
            periodos = new List<periodorecargo>();
            periodosCount = diferenciadeperiodos();
            int contadordeanosdescontados = Periodosdescontados;
         //   decimal acumulado = new decimal();
           
                        
             //**************************************************************** pago bimestral ***************************************************//
                              
                           // periodoscount me dice cuantos bimestres hay y hago la coleccion de los bismestre
                           
                   //         acumulado = 0;
                          

                            for (int cicloper = 0; cicloper <= periodosCount -1; cicloper++)
                            {
                                periodorecargo per = new periodorecargo( cicloper , porcentaje  );
                                clsbimestre bim = new clsbimestre( clsbimestre.Restabimestres  ( fechadehoy  ,cicloper));
                                per.periodobi  = bim.Nombrebimestre;
                                per.periodoan = bim.Nombrebimestre.Substring(4, 4);
                                per.Montorecargos = per.recargos * Montobimestral;
                                periodos.Add(per);
                                

                            }
                        
        }

    }

    
}
