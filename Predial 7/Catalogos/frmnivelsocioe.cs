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
    public partial class frmnivelsocioe : DevComponents.DotNetBar.Office2007Form
    {
        Predial10.Catalogos.Catalogos frmmio;
        public String Modo = "Insertar";
        public frmnivelsocioe()
        {
            InitializeComponent();
        }
        public frmnivelsocioe(Predial10.Catalogos.Catalogos _frmmio)
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
            if (txtnombre.Text == "")
            {
                MessageBox.Show("Debes ingresar una descripcion del nivel socioeconomico");
                txtnombre.BackColor = Color.Yellow;
                txtnombre.Focus();
                return;
            }


            Conexion_a_BD.Conectar();
            if (Modo == "Insertar")
            {
                try
                {
                    String cadena = "INSERT INTO nivelsocioe (Descripcion) values ('" + txtnombre.Text + "')";
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
                String cadena = "UPDATE nivelsocioe SET Descripcion='" + txtnombre.Text + "' WHERE clave=" + txtid.Text + "";
                Conexion_a_BD.Ejecutar(cadena);

            }

            frmmio.llenanivelsocioe();
            Close();
        }

        private void txtnombre_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                Btnaceptar_Click(sender, e);
            }
        }

        private void frmnivelsocioe_Load(object sender, EventArgs e)
        {
            txtnombre.Focus();
        }
    }
}
