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
    public partial class frmestadopredio : DevComponents.DotNetBar.Office2007Form
    {
        Predial10.Catalogos.Catalogos frmmio;
        public String Modo = "Insertar";
        public frmestadopredio()
        {
            InitializeComponent();
        }

        public frmestadopredio(Predial10.Catalogos.Catalogos _frmmio)
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
                MessageBox.Show("Debes ingresar un estado de predio");
                txtidestpredio.BackColor = Color.Yellow;
                txtidestpredio.Focus();
                return;
            }
           

            Conexion_a_BD.Conectar();
            if (Modo == "Insertar")
            {
                String cadena = "INSERT INTO estado_predio(Descripcion) values ('" + txtnombre.Text + "')";
                Conexion_a_BD.Ejecutar(cadena);
            }
            if (Modo == "Actualizar")
            {
                Conexion_a_BD.Conectar();
                String cadena = "UPDATE estado_predio SET Descripcion='" + txtnombre.Text + "' WHERE Idestado_predio=" + txtidestpredio.Text + "";
                Conexion_a_BD.Ejecutar(cadena);

            }

            frmmio.llenaestadopredio();
            Close();

        }
    }
}
