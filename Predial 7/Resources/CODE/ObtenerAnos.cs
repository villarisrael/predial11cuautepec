using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Predial_7.Resources.CODE
{
   public class ObtenerAnos
    {

       decimal millar, recargo, PRA;

       /// <summary>
       /// Metodo que calcual los años que debe
       /// </summary>
       /// <param name="VC">Valor Catastral</param>
       /// <param name="PagoAnual">Pago anual</param>
       /// <param name="Total">Total a pagar</param>
       /// <returns></returns>
       public string carcular_anos(decimal VC, decimal PagoAnual, decimal Total)
       {
           string anos = "";
           

           millar = PagoAnual / VC;
           recargo = Total - PagoAnual;
           PRA = recargo / PagoAnual;

           switch (PRA.ToString())
           {               
               case "0.18":
                   anos = "Debe desde el: " + Convert.ToString(DateTime.Now.Year - 1);
                   break;
               case "0.36":                   
                   anos ="Debe desde el: "+ Convert.ToString(DateTime.Now.Year - 2);
                   break;
               case "0.54":
                   anos = "Debe desde el: " + Convert.ToString(DateTime.Now.Year - 3);
                   break;
               case "0.72":
                   anos = "Debe desde el: " + Convert.ToString(DateTime.Now.Year - 4);
                   break;
               case "0.9":
                   anos = "Debe desde el: " + Convert.ToString(DateTime.Now.Year - 5);
                   break;
               default:
                   anos = "No tiene años por deber";
                   break;
           }

           return anos;
       }

       /// <summary>
       /// Metodo que regresa el ultimo año pagado
       /// </summary>
       /// <param name="vc">Valor Catastral</param>
       /// <param name="MILLAR">Millar</param>
       /// <param name="total">Total a pagar</param>
       /// <returns>Regresa el año del ultimo pago</returns>

       public string deuda_anos(double vc, double MILLAR, double total)
       {
           string anos="";
           double pagoanual=0, pagoanualacumulado=0 ,RecargoAnual=0,RecargoAnualAcumulado=0, totalApagar=0, REC=0;
           int i = 0;
                                
           pagoanual = vc * MILLAR;
                    
           while(total!=totalApagar)
           {
               pagoanualacumulado = pagoanual*i;
               Math.Round(pagoanualacumulado,3);
               RecargoAnual = pagoanual * REC;
               Math.Round(RecargoAnual,3);
               RecargoAnualAcumulado = RecargoAnualAcumulado + RecargoAnual;
               Math.Round(RecargoAnualAcumulado,3);
               totalApagar = pagoanualacumulado + RecargoAnualAcumulado;
               Math.Round(totalApagar, 3);
                //if (total == totalApagar)
                //{
                //    anos = "Debe desde el: " + Convert.ToString(DateTime.Now.Year - i);
                //    break;
                //}

               anos = "Debe desde el: " + Convert.ToString(DateTime.Now.Year - i);               
               REC = REC + 0.18;
               i = i + 1;
               //para que no se convirta en un ciclo infinito
               if (i==10)
               {
                   anos = "No se pudo determinar los años en deuda, revise sus datos.";
                   break;
               }
                             
           }
               return anos;
       }
   }
}
