﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Predial10.Resources.CODE
{
    class clsperiodo
    {

        public string periodo="";
        public decimal descuento = 0;
        public decimal porcdedescuento = 0;
        public decimal Impuestobruto = 0;
        public decimal ImpuestoNeto = 0;
        public tipoimpuesto Tipo;
        public decimal Acumulado=0;
        public decimal Recargo;
      
       public  enum tipoimpuesto
        {
            Impuesto,
            Rezago
        }

        public void calcular()
        {
            if (porcdedescuento <= 0)
            {
                ImpuestoNeto = Impuestobruto;
            }
            if (porcdedescuento > 0)
            {

                descuento = (Impuestobruto * (porcdedescuento / 100));
                ImpuestoNeto = Impuestobruto - descuento;
            }



        }
    }
}
