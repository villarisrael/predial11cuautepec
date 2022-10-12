using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Predial10.Resources.CODE;

namespace Predial10.Catalogos
{
    public partial class frmgiro : DevComponents.DotNetBar.Office2007Form
    {
        Predial10.Catalogos.Catalogos frmmio;
        public String Modo = "Insertar";


        public frmgiro()
        {
            InitializeComponent();
        }

        public frmgiro(Predial10.Catalogos.Catalogos _frmmio)
        {
            InitializeComponent();
        frmmio = _frmmio;
        }

        private void Btncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btnaceptar_Click(object sender, EventArgs e)
        {
            if (txtidgiro.Text == "")
            {
                MessageBox.Show("Debes ingresar un ID de calle");
                txtidgiro.BackColor = Color.Yellow;
                txtidgiro.Focus();
                return;
            }
            if (txtnombre.Text == "")
            {
                MessageBox.Show("Debes ingresar un nombre de calle");
                txtidgiro.BackColor = Color.Yellow;
                txtidgiro.Focus();
                return;
            }
            if (txtidgiro.TextLength < 3)
            {
                MessageBox.Show("El ID de calle debe tener 3 letras");
                txtidgiro.BackColor = Color.Yellow;
                txtidgiro.Focus();
                return;
            }

            Conexion_a_BD.Conectar();
            if (Modo == "Insertar")
            {
                try
                {

                    String cadena = "INSERT INTO GIRO(codgir, descripcion) values ('" + txtidgiro.Text + " ', '" + txtnombre.Text + "')";
                    Conexion_a_BD.Ejecutar(cadena);
                }
                catch (Exception c)
                {
                    if (c.Message.Contains("key"))
                    {
                        MessageBox.Show("El Id ya existe");
                        return;
                    }
                    MessageBox.Show("Error al Insertar " + c.Message);
                }
            }
            if (Modo == "Actualizar")
            {
                Conexion_a_BD.Conectar();
                String cadena = "UPDATE giro SET descripcion='" + txtnombre.Text + "' WHERE codgir='" + txtidgiro.Text + "'";
                Conexion_a_BD.Ejecutar(cadena);

            }

            frmmio.llenagiros();
            Close();
        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                Btnaceptar_Click(sender, e);
            }
        }

    }
}
