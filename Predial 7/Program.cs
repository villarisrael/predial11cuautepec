using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Predial10
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Predial10.AccesoSistema.FrmAcceso ());
          //  Application.Run(new Predial10.configuracion.frmaccesos());
          //Application.Run(new Principal());
        }
    }
}
