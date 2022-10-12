using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using Predial10.Resources.CODE;

namespace Predial10.PadronUsuarios
{
    public partial class BuscarUsuario : Form
    {
        public String campo;
        public string cadenafiltro = "";
       DataGridViewX DTv;
        public BuscarUsuario(string _campo, string _mens, Object _Tipo, DataGridViewX _DTv)
        {
            InitializeComponent();
            campo = _campo;
             DTv = _DTv ;
            lblMsg.Text = _mens;
 
            if (_Tipo.GetType().Name == "Date" || _Tipo.GetType().Name == "DateTime")
            {
                txtBus.Visible = false;
                Fecha.Visible = true;
            }

            else
            {
                txtBus.Visible = true;
                Fecha.Visible = false;
            }

        }

        private void txtBus_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBus.Text.Length >3)
                {
                    cadenafiltro = campo + "  like '%" + txtBus.Text + "%'";
                    try
                    {
                        Conexion_a_BD.Conectar();
                        DataTable usuario= Conexion_a_BD.Consultasql("clave,catastral, Nombre,Domicilio, Comunidad", "vusuario where " + cadenafiltro);
                        DTv.DataSource = usuario;
                        DTv.Refresh();
                        Conexion_a_BD.Desconectar();
                        DTv.Columns[0].Visible=false;
                        DTv.Columns[2].Width = 200;
                        DTv.Columns[3].Width = 200;
                        DTv.Columns[4].Width = 200;

                    }
                    catch (Exception error)
                    {
                    }
                }


            }
            catch (Exception error)
            {
            }
          
        }

        private void BuscarUsuario_Load(object sender, EventArgs e)
        {

        }

      
    }
}
