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
    public partial class Frmsector : DevComponents.DotNetBar.Office2007Form
    {
        Predial10.Catalogos.Catalogos frmmio;
        public String Modo = "Insertar";

        public Frmsector(Predial10.Catalogos.Catalogos _frmmio)
        {
            InitializeComponent();
            frmmio = _frmmio;
        }

        public Frmsector()
        {
            InitializeComponent();
        }

        private void Btncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btnaceptar_Click(object sender, EventArgs e)
        {
            if (Txtidsector.Text == "")
            {
                MessageBox.Show("Debes ingresar un ID de sector");
                Txtidsector.BackColor = Color.Yellow;
                Txtidsector.Focus();
                return;
            }
            if (Txtnombre.Text == "")
            {
                MessageBox.Show("Debes ingresar un nombre de sector");
                Txtidsector.BackColor = Color.Yellow;
                Txtidsector.Focus();
                return;
            }
            //if (Txtidsector.TextLength < 3)
            //{
            //    MessageBox.Show("El ID de sector debe tener 3 letras");
            //    Txtidsector.BackColor = Color.Yellow;
            //    Txtidsector.Focus();
            //    return;
            //}

            try
            {
                Conexion_a_BD.Conectar();
                if (Modo == "Insertar")
                {
                    String cadena = "INSERT INTO sectorES(clavesec, descripcion) values ('" + Txtidsector.Text + " ', '" + Txtnombre.Text + "')";
                    Conexion_a_BD.Ejecutar(cadena);
                }
                if (Modo == "Actualizar")
                {
                    Conexion_a_BD.Conectar();
                    String cadena = "UPDATE sectorES SET descripcion='" + Txtnombre.Text + "' WHERE clavesec='" + Txtidsector.Text + "'";
                    Conexion_a_BD.Ejecutar(cadena);

                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            frmmio.llenasectores();
            Close();
        }

        private void Txtnombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                Btnaceptar_Click(sender, e);
            }
        }

        private void Txtidsector_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
            {
                Txtnombre.Focus();
            }
        }

    }
}
