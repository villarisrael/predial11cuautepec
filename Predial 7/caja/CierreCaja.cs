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
    public partial class CierreCaja : Form
    {
        DataTable TBL_Consulta = new DataTable();
        string oficina, caja;

        public CierreCaja()
        {
            InitializeComponent();
        }

        private void CierreCaja_Load(object sender, EventArgs e)
        {                 
            
                lblFecha.Text = DateTime.Now.ToShortDateString();
                lblHora.Text = DateTime.Now.ToString("HH:mm:ss");

                Conexion_a_BD.Conectar();

                TBL_Consulta = Conexion_a_BD.Consultasql("croape.COD_OFI, CAJA, NOMBRE, DESCRIPCION, Maquina", "croape INNER JOIN oficinas on oficinas.COD_OFI= croape.COD_OFI INNER JOIN cajas on cajas.ID_CAJA= croape.CAJA WHERE MAQUINA= '" + System.Environment.MachineName.ToString() + "' AND FEC_APE='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
                Conexion_a_BD.Desconectar();
                var results = from myRow in TBL_Consulta.AsEnumerable() select myRow;
                try
                {
                    DataView view = results.AsDataView();
                    oficina = view[0]["COD_OFI"].ToString();
                    caja = view[0]["CAJA"].ToString();
                    txtOficina.Text = view[0]["NOMBRE"].ToString();
                    txtCaja.Text = view[0]["DESCRIPCION"].ToString();
                    txtMaquina.Text = view[0]["Maquina"].ToString();
                }
                catch (Exception x)
                {
                }         
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                Conexion_a_BD.Conectar();
                StringBuilder cadena = new StringBuilder();
               
                    cadena.Append("UPDATE croape SET ");                   
                    cadena.Append("FEC_CIE='" + Convert.ToDateTime(lblFecha.Text).ToString("yyyy-MM-dd") + "',");
                    cadena.Append("HOR_CIE='" + lblHora.Text + "', ");
                    cadena.Append("STATUSA='" + "C" + "' ");  
                    cadena.Append("WHERE COD_OFI='" + oficina + "' ");
                    cadena.Append("AND CAJA='" + caja + "' ");
                    cadena.Append("AND Maquina='" + txtMaquina.Text + "'");                    

                    Conexion_a_BD.insertar(cadena.ToString());
                    Conexion_a_BD.Desconectar();
                    MessageBox.Show("Caja Cerrada exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   
                    this.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Conexion_a_BD.Desconectar();
            }
        }
    }
}
