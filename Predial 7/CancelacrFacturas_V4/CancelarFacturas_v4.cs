using Predial10.Facturacion_V4;
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

        int idFactura = 0;
        string UUIDCancelar = "";
        DataTable tablaMotivosCancelacion = new DataTable();
        string resultado;

        public CancelarFacturas_v4(string uuidP, int idFacturaP )
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
                        txtFolioFiscal.Enabled = true;
                        ClsFactura_v4 objCancelar = new ClsFactura_v4();

                        resultado = objCancelar.Cancela40(UUIDCancelar, txtFolioFiscal.Text, claveCancelacion, idFactura, 1, "Factura");
                    }

                }
                else
                {
                    //Invocar clase de cancelación
                    txtFolioFiscal.Enabled = true;
                    ClsFactura_v4 objCancelar = new ClsFactura_v4();

                    resultado = objCancelar.Cancela40(UUIDCancelar, claveCancelacion, idFactura, 1, "Factura");
                }


                if (resultado != "")
                {
                    //Una vez cancelada, guardaremos el acuse de cancelacion que nos regresa la respuesta SAT

                    string sqlAcuseCancelacion = "update EncFac set AcuseCancelacion = '" + resultado + "' where IDENCFAC = " + idFactura + "";
                    Conexion_a_BD.Ejecutar(sqlAcuseCancelacion);
                    

                    MessageBox.Show("Factura Cancelada ante el SAT con exito");
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al cancelar la factura ante el SAT");
                }
            

             
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

        private void cmbMotivosCancelacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMotivosCancelacion.SelectedIndex == 0)
            {

                txtFolioFiscal.Enabled = false;
                label3.Enabled = false;
            }

            if (cmbMotivosCancelacion.SelectedIndex == 1)
            {
                MessageBox.Show("POR FAVOR ESCRIBE EL FOLIO FISCAL QUE SUSTITUIRA AL FOLIO FISCAL A CANCELAR");
                txtFolioFiscal.Enabled = true;
                label3.Enabled = true;
            }

            if (cmbMotivosCancelacion.SelectedIndex == 2)
            {

                txtFolioFiscal.Enabled = false;
                label3.Enabled = false;
            }

            if (cmbMotivosCancelacion.SelectedIndex == 3)
            {

                txtFolioFiscal.Enabled = false;
                label3.Enabled = false;
            }

            if (cmbMotivosCancelacion.SelectedIndex == 4)
            {

                txtFolioFiscal.Enabled = false;
                label3.Enabled = false;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
