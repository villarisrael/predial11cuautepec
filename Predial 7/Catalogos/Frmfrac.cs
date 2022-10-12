using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Predial10.Resources.CODE;
using System.Windows.Forms;

namespace Catalogo2
{
    public partial class Frmfrac : DevComponents.DotNetBar.Office2007Form
    {
        Predial10.Catalogos.Catalogos frmmio;
        public String Modo = "Insertar";

        public Frmfrac(Predial10.Catalogos.Catalogos _frmmio)
        {
            InitializeComponent();
            frmmio = _frmmio;
        }

        public Frmfrac()
        {
            InitializeComponent();
        }

        private void Btncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btnaceptar_Click(object sender, EventArgs e)
        {
            if (Txtidfrac.Text == "")
            {
                MessageBox.Show("Debes ingresar un ID de Fraccionamiento");
                Txtidfrac.BackColor = Color.Yellow;
                Txtidfrac.Focus();
                return;
            }
            if (Txtnombre.Text == "")
            {
                MessageBox.Show("Debes ingresar un nombre de Fraccionamiento");
                Txtidfrac.BackColor = Color.Yellow;
                Txtidfrac.Focus();
                return;
            }
            if (Txtidfrac.TextLength < 3)
            {
                MessageBox.Show("El ID de Fraccionamiento debe tener 3 letras");
                Txtidfrac.BackColor = Color.Yellow;
                Txtidfrac.Focus();
                return;
            }
         //  Conexion_a_BD Conexion_a_BD = new Conexion_a_BD();
            Conexion_a_BD.Conectar();
            if (Modo == "Insertar")
            {
                String cadena = "INSERT INTO fracc(Idfraccionamiento, Nombre) values ('" + Txtidfrac.Text + " ', '" + Txtnombre.Text + "')";
                Conexion_a_BD.Ejecutar(cadena);
            }
            if (Modo == "Actualizar")
            {
                Conexion_a_BD.Conectar();
                String cadena = "UPDATE fracc SET Nombre='" + Txtnombre.Text + "' WHERE Idfraccionamiento='" + Txtidfrac.Text + "'";
                Conexion_a_BD.Ejecutar(cadena);

            }

            frmmio.llenafraccs();
            Close();
        }

        private void Txtnombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                Btnaceptar_Click(sender, e);
            }
        }

        private void Txtidfracc_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
            {
                Txtnombre.Focus();
            }
        }
    }
}
