using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Predial10.Resources.CODE;
using System.Windows.Forms;

namespace Predial10.Catalogos
{
    public partial class Frmcol : DevComponents.DotNetBar.Office2007Form
    {

       Predial10.Catalogos.Catalogos frmmio;
        public String Modo = "Insertar";

        public Frmcol(Predial10.Catalogos.Catalogos _frmmio)
        {
            InitializeComponent();
            frmmio = _frmmio;
        }


        public Frmcol()
        {
            InitializeComponent();
        }

        private void Btncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btnaceptar_Click(object sender, EventArgs e)
        {
            if (txtidcolonia.Text == "")
            {
                MessageBox.Show("Debes ingresar un ID de colonia");
                txtidcolonia.BackColor = Color.Yellow;
                txtidcolonia.Focus();
                return;
            }
            if (txtnombre.Text == "")
            {
                MessageBox.Show("Debes ingresar un nombre de colonia");
                txtidcolonia.BackColor = Color.Yellow;
                txtidcolonia.Focus();
                return;
            }
            if (txtidcolonia.TextLength < 3)
            {
                MessageBox.Show("El ID de colonia debe tener 3 letras");
                txtidcolonia.BackColor = Color.Yellow;
                txtidcolonia.Focus();
                return;
            }

            try
            {
                Conexion_a_BD.Conectar();
                if (Modo == "Insertar")
                {
                    String cadena = "INSERT INTO colonia(Id_colonia, Colonia) values ('" + txtidcolonia.Text + " ', '" + txtnombre.Text + "')";
                    Conexion_a_BD.Ejecutar(cadena);
                }
                if (Modo == "Actualizar")
                {
                    Conexion_a_BD.Conectar();
                    String cadena = "UPDATE colonia SET Colonia='" + txtnombre.Text + "' WHERE Id_colonia='" + txtidcolonia.Text + "'";
                    Conexion_a_BD.Ejecutar(cadena);

                }
            }
            catch (Exception cm)
            {
                MessageBox.Show(cm.Message);
            }

            frmmio.llenacolonias();
            Close();
        }

        private void txtidcolonia_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                Btnaceptar_Click(sender, e);
            }
        }

        private void txtidcolonia_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
            {
                txtnombre.Focus();
            }
        }
    }
}
