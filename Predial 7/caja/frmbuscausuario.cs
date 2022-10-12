using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



using Predial10.Resources.CODE;

namespace Predial10.caja
{
    public partial class frmbuscausuario : Form
    {
        frmcaja copiacaja;
        public frmbuscausuario()
        {
            InitializeComponent();
        }

        public frmbuscausuario(frmcaja c)
        {
            
            InitializeComponent();
            copiacaja = c;
        }

        private void frmbuscausuario_Load(object sender, EventArgs e)
        {

        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {
            
            {
               
            }
        }

        public void btnbuscarnombre_Click(object sender, System.EventArgs e)
        {
            try
            {
                Conexion_a_BD.Conectar();
                DataTable tablausuario = new DataTable();

                tablausuario = Conexion_a_BD.Consultasqlpagina("catastral, Nombre,Calle,numext", "vusuario where nombre like '%" + txtnombre.Text + "%'", "Nombre", "0,30");
                this.dgridusuario.DataSource = tablausuario;
                Conexion_a_BD.Desconectar();
                dgridusuario.Visible = true;
                dgridusuario.Columns[1].Width = 300;
                dgridusuario.Columns[2].Width = 300;
               
            }
            catch ( Exception err)
            {
                
            }
        }

        private void btnbuscarcuenta_Click(object sender, System.EventArgs e)
        {
            try
            {
                Conexion_a_BD.Conectar();
                DataTable tablausuario = new DataTable();

                tablausuario = Conexion_a_BD.Consultasqlpagina("catastral, Nombre,Calle,numext", "vusuario where catastral like '%" + txtcatastral.Text + "%'", "Nombre", "0,30");
                this.dgridusuario.DataSource = tablausuario;
                Conexion_a_BD.Desconectar();
                dgridusuario.Visible = true;
                dgridusuario.Columns[1].Width = 300;
                dgridusuario.Columns[2].Width = 300;

            }
            catch (Exception err)
            {

            }
        }

        private void dgridusuario_CellMouseDoubleClick(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string cuenta = dgridusuario.SelectedRows[0].Cells[0].Value.ToString();
              //  MessageBox.Show(cuenta);
             //    frmcaja.ActiveForm.Close();
                copiacaja.txtclave.Text = cuenta;
                copiacaja.btnbuscar1_Click(sender, new System.EventArgs());
                this.Close();
            }
            catch (Exception err)
            {
            }
        }

        
    }
}
