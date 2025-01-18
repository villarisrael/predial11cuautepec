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

            using (var accesoForm = new Predial10.AccesoSistema.FrmAcceso())
            {
                
                if (accesoForm.ShowDialog() == DialogResult.OK)
                {
                    // Si el usuario se autentica, abrir el formulario principal
                    var programa = new Predial10.Principal();
                    programa.usuario = accesoForm.UsuarioAutenticado; // Propaga el usuario autenticado si es necesario
                    Application.Run(programa);
                }
            }
        }

    }
}
