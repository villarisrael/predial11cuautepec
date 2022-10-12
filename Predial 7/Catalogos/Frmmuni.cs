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
    public partial class Frmmuni : DevComponents.DotNetBar.Office2007Form
    {
       Predial10.Catalogos.Catalogos frmmio;
        public String Modo = "Insertar";

        public Frmmuni(Predial10.Catalogos.Catalogos _frmmio)
        {
            InitializeComponent();
            frmmio = _frmmio;
        }

        public Frmmuni()
        {
            InitializeComponent();
        }

        private void Btncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btnaceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Txtidmunicipio.Text == "")
                {
                    MessageBox.Show("Debes ingresar un ID de Municipio");
                    Txtidmunicipio.BackColor = Color.Yellow;
                    Txtidmunicipio.Focus();

                    return;
                }
                if (Txtnombre.Text == "")
                {
                    MessageBox.Show("Debes ingresar un nombre de Municipio");
                    Txtidmunicipio.BackColor = Color.Yellow;
                    Txtidmunicipio.Focus();
                    return;
                }
                //if (Txtidmunicipio.TextLength < 3)
                //{
                //    MessageBox.Show("El ID del Municipio debe tener 3 letras");
                //    Txtidmunicipio.BackColor = Color.Yellow;
                //    Txtidmunicipio.Focus();
                //    return;
                //}

                Conexion_a_BD.Conectar();
                if (Modo == "Insertar")
                {
                    String cadena = "INSERT INTO municipioS(clave, Nombre) values ('" + Txtidmunicipio.Text + " ', '" + Txtnombre.Text + "')";
                    Conexion_a_BD.Ejecutar(cadena);
                }
                if (Modo == "Actualizar")
                {
                    Conexion_a_BD.Conectar();
                    String cadena = "UPDATE municipioS SET Nombre='" + Txtnombre.Text + "' WHERE clave='" + Txtidmunicipio.Text + "'";
                    Conexion_a_BD.Ejecutar(cadena);

                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            frmmio.llenamunicipios();
            Close();
        }

        private void Txtnombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                Btnaceptar_Click(sender, e);
            }
        }

        private void Txtidmuni_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
            {
                Txtnombre.Focus();
            }
        }
    }
}
