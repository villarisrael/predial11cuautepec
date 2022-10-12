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

namespace Predial10.Catalogos
{
    public partial class Frmcmndd : DevComponents.DotNetBar.Office2007Form
    {
       Predial10.Catalogos.Catalogos frmmio;
        public String Modo = "Insertar";

        public Frmcmndd(Predial10.Catalogos.Catalogos _frmmio)
        {
            InitializeComponent();
            frmmio = _frmmio;
        }
        public Frmcmndd()
        {
            InitializeComponent();
        }

        private void Btncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btnaceptar_Click(object sender, EventArgs e)
        {
            if (Txtidcomunidad.Text == "")
            {
                MessageBox.Show("Debes ingresar un ID de comunidad");
                Txtidcomunidad.BackColor = Color.Yellow;
                Txtidcomunidad.Focus();
                return;
            }
            if (Txtnombre.Text == "")
            {
                MessageBox.Show("Debes ingresar un nombre de comunidad");
                Txtidcomunidad.BackColor = Color.Yellow;
                Txtidcomunidad.Focus();
                return;
            }
            //if (Txtidcomunidad.TextLength < 3)
            //{
            //    MessageBox.Show("El ID de comunidad debe tener 3 letras");
            //    Txtidcomunidad.BackColor = Color.Yellow;
            //    Txtidcomunidad.Focus();
            //    return;
            //}
           // Conexion_a_BD Conexion_a_BD = new Conexion_a_BD();
            try
            {
                Conexion_a_BD.Conectar();
                if (Modo == "Insertar")
                {
                    String cadena = "INSERT INTO comunidades(Id_comunidad, Comunidad) values ('" + Txtidcomunidad.Text + " ', '" + Txtnombre.Text + "')";
                    Conexion_a_BD.Ejecutar(cadena);
                }
                if (Modo == "Actualizar")
                {
                    Conexion_a_BD.Conectar();
                    String cadena = "UPDATE comunidades SET Comunidad='" + Txtnombre.Text + "' WHERE Id_comunidad='" + Txtidcomunidad.Text + "'";
                    Conexion_a_BD.Ejecutar(cadena);

                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            frmmio.llenacomunidades();
            Close();
        }

        private void Txtnombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                Btnaceptar_Click(sender, e);
            }
        }

        private void Txtidcomunidad_TextChanged(object sender, EventArgs e)
        {

        }
        private void Txtidcomunidad_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
            {
                Txtnombre.Focus();                
            }
        }
    }
}
