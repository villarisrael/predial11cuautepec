using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Predial10.Resources.CODE;

namespace  Predial10.Catalogos
{
    public partial class Frmcalles : DevComponents.DotNetBar.Office2007Form
    {
       Predial10.Catalogos.Catalogos frmmio;
        public String Modo = "Insertar";

        public Frmcalles(Predial10.Catalogos.Catalogos _frmmio)
        {
            InitializeComponent();
            frmmio = _frmmio;
        }


        public Frmcalles()
        {
            InitializeComponent();
        }

        

        private void labelX1_Click(object sender, EventArgs e)
        {
        
        }

        private void Btncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btnaceptar_Click(object sender, EventArgs e)
        {
            if (txtidcalle.Text == "")
            {
                MessageBox.Show("Debes ingresar un ID de calle");
                txtidcalle.BackColor = Color.Yellow;
                txtidcalle.Focus();
                return;
            }
            if (txtnombre.Text == "")
            {
                MessageBox.Show("Debes ingresar un nombre de calle");
                txtidcalle.BackColor = Color.Yellow;
                txtidcalle.Focus();
                return;
            }
            if (txtidcalle.TextLength<3)
            {
                MessageBox.Show("El ID de calle debe tener 3 letras");
                txtidcalle.BackColor = Color.Yellow;
                txtidcalle.Focus();
                return;
            }

            Conexion_a_BD.Conectar();
            if (Modo == "Insertar")
            {
                String cadena = "INSERT INTO calles(Id_calle, Nombre) values ('" + txtidcalle.Text + " ', '" + txtnombre.Text + "')";
                Conexion_a_BD.Ejecutar(cadena);
            }
            if (Modo == "Actualizar")
            {
                Conexion_a_BD.Conectar();
                String cadena = "UPDATE calles SET Nombre='" +txtnombre.Text+"' WHERE Id_calle='"+txtidcalle.Text + "'";
                Conexion_a_BD.Ejecutar(cadena);

            }

            frmmio.llenacalles();
            Close();

        }

        private void txtidcalle_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                Btnaceptar_Click(sender,e);
            }
        }

        private void txtidcalle_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
            {
                txtnombre.Focus();
            }
        }

        private void Frmcalles_Load(object sender, EventArgs e)
        {

        }

        
    }
}
