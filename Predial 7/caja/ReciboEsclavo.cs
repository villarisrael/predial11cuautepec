using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predial10.caja
{
    class ReciboEsclavo
    {
        public int clave { get; set; }

        public string Concepto { get; set; }

        public decimal Importe { get; set; }

        public bool IVA { get; set; }

        public decimal ImporteIva { get; set; }

        public decimal Cantidad { get; set; }

        public int Recibo { get; set; }

        public int llave { get; set; }
        public string Serie { get; set; }

        
        public int MontoSinDescuento { get; set; }

        public int? PORCDESCUENTO { get; set; }

    }
}
