using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Predial10.Resources.CODE
{
    class Pago
    {
        public DateTime fecha = new DateTime();
        public DateTime fechadehoy = new DateTime();
        public decimal porcentaje = new decimal();
        public decimal Porcentajeimpuesto = new decimal();
        public decimal valor = new decimal();
        public decimal totalimpuestobruto=0;
        public decimal totalrezagobruto = 0;
        
        public int tarifa = 1;
        public long periodosCount = 0;
        public decimal Impuesto = 0;
        public decimal Rezago = 0;
        public decimal Recargo = 0;
        public decimal RecargoRezagos = 0;
        public decimal TotalRecargos = 0;
        public int Periodosdescontados = 0;
        public decimal Porcentaje_de_descuento = 0;
        public tipopago tipo;
        public List <clsperiodo> periodos = new List <Predial10.Resources.CODE.clsperiodo>();
        public clsrecargo perrecargo;
        public decimal porcentajederecargo=0;
        public decimal descuentototalimpuesto = 0;
        public decimal descuentototalrezago = 0;
        public decimal descuentototal = 0;
        public decimal tarifaanual;
        public decimal tarifabimestral;
        public decimal minimo=0;

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

        public Pago()
        {
            porcentaje = 0;
            Porcentajeimpuesto = 0;
       
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

      

        decimal basegravamen()
        {

            if (porcentaje == 0)
            {
                return 0;
            }
            if (valor == 0)
            {
                return 0;
            }
            return valor * (porcentaje / 100);

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
                    rs = (date2.Month - date1.Month) + (12 * Pago.DateDiff(DateInterval.Year, date1, date2));
                    break;
                case DateInterval.Quarter:
                    rs = (long)Math.Ceiling((double)(Pago.DateDiff(DateInterval.Month, date1, date2) / 3.0));
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
            periodos = new List<clsperiodo>();
            periodosCount = diferenciadeperiodos();
            int contadordeanosdescontados = Periodosdescontados;
            decimal acumulado = new decimal();
            tarifaanual = (basegravamen() * (Porcentajeimpuesto / 100));
            tarifabimestral = (basegravamen() * (Porcentajeimpuesto / 100)) / 6;

            if (tarifaanual < minimo)
            {
                tarifaanual = minimo;
            }

            Impuesto = 0;
            Rezago = 0;
            acumulado = 0;
            Recargo = 0;
            RecargoRezagos = 0;
            TotalRecargos = 0;
            descuentototalimpuesto = 0;
            descuentototalrezago = 0;
            totalimpuestobruto = 0;
            totalrezagobruto = 0;
            totalrezagobruto = 0;

            switch (tipo)
            {
                   
                case tipopago.anual:   /// ******************************************************pago anual **************************************************************


                              decimal acumularecargoanteriores = 0;

                            DateTime fechaciclo = fechadehoy;

                            for (int cicloper = 0; cicloper <= periodosCount - 1; cicloper++)
                            {
                                clsperiodo per = new clsperiodo();
                                
                                per.periodo = fechaciclo.Year.ToString ();
                                
                                per.Impuestobruto = tarifaanual;

                                if (contadordeanosdescontados >= 1)
                                {
                                    per.porcdedescuento = Porcentaje_de_descuento;
                                    contadordeanosdescontados -= 1;
                                }

                                ///**********************
                                per.calcular();

                                /*******************************************************************************************/
                                perrecargo = new clsrecargo();
                                perrecargo.porcentaje = porcentajederecargo ;
                                perrecargo.fecha = this.fecha;
                                perrecargo.fechadehoy = DateTime.Now;
                                perrecargo.tipo = clsrecargo.tipopago.bimestral;
                                perrecargo.Montobimestral = per.ImpuestoNeto /6;
                                perrecargo.calcula();
                                decimal acumularecargo = 0;
                                
                                /*******************************************************************************************/
                               
                                for (int gaby = 0; gaby <= perrecargo.periodos.Count - 1; gaby++)
                                {
                                   
                                    string periodoan = perrecargo.periodos[gaby].periodoan;
                                    if (periodoan == per.periodo)
                                    {

                                        acumularecargo += perrecargo.periodos[gaby].Montorecargos;
                                    }
                                   
                                }
                                  per.Recargo = acumularecargo;
                                

                                    /**********************************************************************************************/
                                    if (fechaciclo.Year == DateTime.Now.Year)
                                    {
                                        per.Tipo = per.Tipo = Predial10.Resources.CODE.clsperiodo.tipoimpuesto.Impuesto;
                                        Impuesto += per.ImpuestoNeto;
                                        descuentototalimpuesto += per.Impuestobruto - per.ImpuestoNeto;
                                        totalimpuestobruto += per.Impuestobruto;
                                    }
                                if (fechaciclo.Year < DateTime.Now.Year)
                                {
                                    per.Tipo = per.Tipo = Predial10.Resources.CODE.clsperiodo.tipoimpuesto.Rezago;
                                    Rezago += per.ImpuestoNeto;
                                    descuentototalrezago += per.Impuestobruto - per.ImpuestoNeto;
                                    totalrezagobruto += per.Impuestobruto;
                                }

                               
                                if (per.periodo == DateTime.Now.Year.ToString())
                                {
                                          Recargo += per.Recargo;
                                }
                                else
                                {
                                    this.RecargoRezagos += per.Recargo;
                                }
                                
                          

                                periodos.Add(per);

                                fechaciclo = fechaciclo.AddYears(-1);
                               
                                
                            }


                          

                          
                            for (int ciclo =( Convert.ToInt32(periodosCount)  - 1); ciclo >= 0; ciclo--)
                            {
                                acumulado += periodos[ciclo].ImpuestoNeto + periodos[ciclo].Recargo;
                                periodos[ciclo].Acumulado = acumulado; 
                            }
                            TotalRecargos = Recargo + RecargoRezagos;
                            break;
                        
               case tipopago.bimestral :  //**************************************************************** pago bimestral ***************************************************//
                              
                           // periodoscount me dice cuantos bimestres hay y hago la coleccion de los bismestre
                        
                     

                            for (int cicloper = 0; cicloper <= periodosCount -1; cicloper++)
                            {
                                clsperiodo per = new clsperiodo();
                                clsbimestre bim = new clsbimestre( clsbimestre.Restabimestres  ( fechadehoy  ,cicloper));
                                per.periodo = bim.Nombrebimestre;
                                per.Impuestobruto = tarifabimestral;
                     
                                if (contadordeanosdescontados >= 1)
                                {
                                    per.porcdedescuento = Porcentaje_de_descuento;
                                    contadordeanosdescontados -= 1;
                                }
                                per.calcular();


                                /*******************************************************************************************/
                                perrecargo = new clsrecargo();
                                perrecargo.porcentaje = porcentajederecargo;
                                perrecargo.fecha = this.fecha;
                                perrecargo.fechadehoy = DateTime.Now;
                                perrecargo.tipo = clsrecargo.tipopago.bimestral;
                                perrecargo.Montobimestral = per.ImpuestoNeto;
                                perrecargo.calcula();

                                /**********************************************************************************************/
                                decimal acumularecargo = 0;

                                for (int gaby = 0; gaby <= perrecargo.periodos.Count - 1; gaby++)
                                {

                                    string periodoan = perrecargo.periodos[gaby].periodobi ;
                                    if (periodoan == per.periodo)
                                    {
                                        acumularecargo += perrecargo.periodos[gaby].Montorecargos;
                                    }
                                }

                                per.Recargo = acumularecargo;

                                /**********************************************************************************************/

                                if (bim.fecha.Year == DateTime.Now.Year)
                                {
                                    per.Tipo = per.Tipo = Predial10.Resources.CODE.clsperiodo.tipoimpuesto.Impuesto;
                                    Impuesto += per.ImpuestoNeto;
                                    descuentototalimpuesto += per.Impuestobruto - per.ImpuestoNeto;
                                    totalimpuestobruto += per.Impuestobruto;
                                }
                                if (bim.fecha.Year < DateTime.Now.Year)
                                {
                                    per.Tipo = per.Tipo = Predial10.Resources.CODE.clsperiodo.tipoimpuesto.Rezago;
                                    Rezago += per.ImpuestoNeto;
                                    descuentototalrezago += per.Impuestobruto - per.ImpuestoNeto;
                                    totalrezagobruto += per.Impuestobruto;
                                }
                                if (per.periodo == DateTime.Now.Year.ToString())
                                {
                                    Recargo += per.Recargo;
                                }
                                else
                                {
                                    this.RecargoRezagos += per.Recargo;
                                }

                               
                                periodos.Add(per);
                               
                            }

                            for (int ciclo = (Convert.ToInt32(periodosCount) - 1); ciclo >= 0; ciclo--)
                            {
                                acumulado += periodos[ciclo].ImpuestoNeto + periodos[ciclo].Recargo  ;
                                periodos[ciclo].Acumulado = acumulado;
                            }

                            TotalRecargos = Recargo + RecargoRezagos;
                            break;
                        
                 
            }
            descuentototal = descuentototalimpuesto + descuentototalrezago;
        }
    }
}
