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
    public partial class frmoficinas : Form
    {
        Predial10.Catalogos.Catalogos frmmio;
        public String Modo = "Insertar";
        public frmoficinas()
        {

            InitializeComponent();
        }

        public frmoficinas(Predial10.Catalogos.Catalogos _frmmio)
        {

            InitializeComponent();
            frmmio = _frmmio;
            
        }

        private void Btnaceptar_Click(object sender, EventArgs e)
        {
            if (txtidoficinas.Text == "")
            {
                MessageBox.Show("Debes ingresar un ID de OFICINA");
                txtidoficinas.BackColor = Color.Yellow;
                txtidoficinas.Focus();
                return;
            }
            if (txtnombre.Text == "")
            {
                MessageBox.Show("Debes ingresar un nombre de oficina");
                txtidoficinas.BackColor = Color.Yellow;
                txtidoficinas.Focus();
                return;
            }
            if (txtidoficinas.TextLength < 3)
            {
                MessageBox.Show("El ID de oficina debe tener 3 letras");
                txtidoficinas.BackColor = Color.Yellow;
                txtidoficinas.Focus();
                return;
            }

            Conexion_a_BD.Conectar();
            if (Modo == "Insertar")
            {
                String cadena = "INSERT INTO oficinas (COD_OFI, Nombre) values ('" + txtidoficinas.Text + " ', '" + txtnombre.Text + "')";
                Conexion_a_BD.Ejecutar(cadena);
            }
            if (Modo == "Actualizar")
            {
                Conexion_a_BD.Conectar();
                String cadena = "UPDATE oficinas SET Nombre='" + txtnombre.Text + "' WHERE COD_OFI='" + txtidoficinas.Text + "'";
                Conexion_a_BD.Ejecutar(cadena);

            }

            frmmio.llenaoficinas();
            Close();
        }

        private void Btncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
