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
    public partial class frmcaja : DevComponents.DotNetBar.Office2007Form
    {

        Predial10.Catalogos.Catalogos frmmio;
        public String Modo = "Insertar";

        public frmcaja()
        {
            InitializeComponent();
        }

        public frmcaja(Predial10.Catalogos.Catalogos _frmmio)
        {
            InitializeComponent();
            frmmio = _frmmio;
            
        }


        private void CargarDatos()
        {
            //Carga el combo de Oficinas
            Conexion_a_BD.Conectar();
            cmbOficina.ValueMember = "COD_OFI";
            cmbOficina.DisplayMember = "NOMBRE";
            cmbOficina.DataSource = Conexion_a_BD.Consultasql("COD_OFI, Nombre", "oficinas", "COD_OFI");
            Conexion_a_BD.Desconectar();

            if (Modo == "Actualizar")
            {
                Conexion_a_BD.Conectar();
                DataTable xdat = Conexion_a_BD.Consultasql("serie,folio,activo,cod_ofi,Tcaja", "cajas where id_caja='" + txtIdCaja.Text +"'" );
                try
                {
                    var results = from myRow in xdat.AsEnumerable()

                                  select myRow;
                    DataView view = results.AsDataView();

                    try
                    {
                        txtSerie.Text= view[0][0].ToString();
                        int x = 0, activo=0;
                        int.TryParse(view[0][1].ToString(),out x);
                        txtFolio.Value = x;
                        cmbOficina.SelectedValue = view[0][3].ToString();
                        int.TryParse(view[0][2].ToString(), out activo);
                        cmbActivo.SelectedIndex = activo;
                        cmbTipoCaja.Text = view[0][4].ToString();

                    }
                    catch (Exception c)
                    {
                        
                    }
                }
                catch (Exception c)
                {

                }
                
            }

        }

        private void cmbActivo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbActivo.SelectedIndex == 0)
            {
                cmbActivo.ValueMember = "1";
            }
            else if (cmbActivo.SelectedIndex == 1)
            {
                cmbActivo.ValueMember = "-1";
            }
        }

        private void Btnaceptar_Click(object sender, EventArgs e)
        {
            if (Modo == "Insertar")
            {
                try
                {

                    if (txtIdCaja.Text == "")
                    {
                        MessageBox.Show("Debes ingresar el ID de la Caja", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (txtIdCaja.TextLength <3)
                    {
                        MessageBox.Show("El ID de la Caja debe tener por lo menos 3 caractares", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                        Conexion_a_BD.Conectar();
                        if (cmbActivo.SelectedIndex < 0)
                        {
                            cmbActivo.SelectedIndex = 0;
                        }
                        Conexion_a_BD.insertar("Insert into cajas  SET Serie='" + txtSerie.Text + "', COD_OFI='" + cmbOficina.SelectedValue + "', Folio=" + txtFolio.Value + " , Activo=" + cmbActivo.SelectedIndex + ", descripcion='" + txtDescripcion.Text + "', tCaja='" + cmbTipoCaja.Text + "', ID_CAJA='" + txtIdCaja.Text + "'");
                        Conexion_a_BD.Desconectar();
                        MessageBox.Show("Registro guardado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmmio.llenacajas();
                        Close();
                                   }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                    Conexion_a_BD.Desconectar();
                }
            }
            else
            {
                try
                {

                    Conexion_a_BD.Conectar();
                    Conexion_a_BD.insertar("UPDATE CAJAS SET  Serie='" + txtSerie.Text + "', COD_OFI='" + cmbOficina.SelectedValue + "', Folio=" + txtFolio.Value + " , Activo=" + cmbActivo.SelectedIndex + ", descripcion='" + txtDescripcion.Text + "', tCaja='" + cmbTipoCaja.Text + "'  WHERE ID_CAJA='" + txtIdCaja.Text + "'");
                    Conexion_a_BD.Desconectar();
                    MessageBox.Show("Registro guardado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmmio.llenacajas();
                    Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                    Conexion_a_BD.Desconectar();
                }

            }
         
        }

        private void Btncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmcaja_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

    }
}
