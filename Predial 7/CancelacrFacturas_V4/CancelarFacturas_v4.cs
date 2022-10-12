using Predial10.Resources.CODE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Predial10.CancelacrFacturas_V4
{

    public partial class CancelarFacturas_v4 : Form
    {

        string idFactura = "";
        string UUIDCancelar = "";
        DataTable tablaMotivosCancelacion = new DataTable();

        public CancelarFacturas_v4(string uuidP, string idFacturaP )
        {
            InitializeComponent();

            idFactura = idFacturaP;
            UUIDCancelar = uuidP;

        }

        private void btnCancelarFactura_Click(object sender, EventArgs e)
        {
            string valor = cmbMotivosCancelacion.SelectedValue.ToString();

            string claveCancelacion = Conexion_a_BD.obtenercampo($"SELECT ClaveCancelacion from motivos_cancelacionsat WHERE idCancelacion = ' {valor} ';");

            try
            {
                if (claveCancelacion == "01")
                {
                    if (txtFolioFiscal.Text == "")
                    {
                        MessageBox.Show("NO HAS ESCRITO EL FOLIO FISCAL QUE VA A SUSTITUIR AL FOLIO FISCAL A CANCELAR");
                    }
                    else
                    {
                        //Invocar clase de cancelación



                    }

                }
                else
                { 
                    //Invocar clase de cancelación

                }


                //if ()
                //{

                //}
                //else
                //{
                //    //Agregar campo acuse_cancelacion a tabla EncFac



                //}

            }

            catch(Exception ex)
            {
                MessageBox.Show($"Ocurrio un error en el proceso: {ex.ToString()}");
            }

        }

        private void CancelarFacturas_v4_Load(object sender, EventArgs e)
        {

            txtFolioFiscal.Enabled = false;
            lblFolioFiscal.Enabled = false;

            //Conexion_a_BD.Conectar();
            cmbMotivosCancelacion.ValueMember = "idCancelacion";
            cmbMotivosCancelacion.DisplayMember = "DescripcionCancelacion";

            tablaMotivosCancelacion = Conexion_a_BD.Consultasql("idCancelacion, ClaveCancelacion, DescripcionCancelacion", "motivos_cancelacionsat", "idCancelacion");
            cmbMotivosCancelacion.DataSource = tablaMotivosCancelacion;
            cmbMotivosCancelacion.SelectedIndex = -1;
            Conexion_a_BD.Desconectar();

        }
    }
}
