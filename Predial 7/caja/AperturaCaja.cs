﻿using System;
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
    public partial class AperturaCaja : DevComponents.DotNetBar.Office2007Form
    {
        string PC = "";
                
        public AperturaCaja()
        {
            InitializeComponent();
        }

        private void AperturaCaja_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToShortDateString();
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
           

            //Carga el combo de Oficinas
            Conexion_a_BD.Conectar();
            cmbOficina.ValueMember = "COD_OFI";
            cmbOficina.DisplayMember = "NOMBRE";
            cmbOficina.DataSource = Conexion_a_BD.Consultasql("COD_OFI, Nombre", "oficinas", "COD_OFI");
            Conexion_a_BD.Desconectar();            
                
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                    Conexion_a_BD.Conectar();
                    StringBuilder cadena = new StringBuilder();
                    PC = System.Environment.MachineName.ToString();
                    if (txtRemanente.Text == "")
                    {
                        MessageBox.Show("Debes ingresar la Cantidad del Remanete", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Conexion_a_BD.Desconectar();
                    }
                    else
                    {
                        cadena.Append("INSERT INTO croape SET ");
                        cadena.Append("COD_OFI= '" + cmbOficina.SelectedValue + "',");
                        cadena.Append("CAJA='" + cmbCajas.SelectedValue + "',");
                        cadena.Append("SERIE='" + cmbSerie.SelectedValue + "',");
                        cadena.Append("FEC_APE='" + Convert.ToDateTime(lblFecha.Text).ToString("yyyy-MM-dd") + "',");
                        cadena.Append("HOR_APE='" + lblHora.Text + "',");
                        cadena.Append("SAL_INI='" + txtRemanente.Text + "',");
                        cadena.Append("STATUSA='" + "A" + "',");
                        cadena.Append("Maquina='" + PC + "',");
                        cadena.Append("Tcaja='" + cmbTipoCaja.SelectedValue + "'");

                        Conexion_a_BD.insertar(cadena.ToString());
                        Conexion_a_BD.Desconectar();
                        MessageBox.Show("Caja abierta exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        VariablesCajas.Oficina = cmbOficina.Text;
                        VariablesCajas.Caja = cmbCajas.Text;
                        VariablesCajas.Maquina = PC;
                        VariablesCajas.CODOFI = Convert.ToInt16(cmbOficina.SelectedValue);
                        VariablesCajas.CAJA = Convert.ToInt16(cmbCajas.SelectedValue);
                        this.Close();


                    }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Conexion_a_BD.Desconectar();
            }
        }

        private void cmbCajas_SelectedIndexChanged(object sender, EventArgs e)
        {     

            //Carga el combo de Serie
            Conexion_a_BD.Desconectar();
            Conexion_a_BD.Conectar();
            cmbSerie.ValueMember = "Serie";
            cmbSerie.DisplayMember = "Serie";
            cmbSerie.DataSource = Conexion_a_BD.Consultasql("Serie", "cajas where ID_CAJA = '" + cmbCajas.SelectedValue + "' and COD_OFI = '" + cmbOficina.SelectedValue + "'");
            Conexion_a_BD.Desconectar();  

            //Carga el combo de Tipo de caja
            Conexion_a_BD.Desconectar();
            Conexion_a_BD.Conectar();
            cmbTipoCaja.ValueMember = "Tcaja";
            cmbTipoCaja.DisplayMember = "Tcaja";
            cmbTipoCaja.DataSource = Conexion_a_BD.Consultasql("Tcaja", "cajas where ID_CAJA = '" + cmbCajas.SelectedValue + "' and COD_OFI = '" + cmbOficina.SelectedValue + "'");
            Conexion_a_BD.Desconectar(); 

        }

        private void cmbOficina_SelectedIndexChanged(object sender, EventArgs e)
        {
            Conexion_a_BD.Desconectar();
            Conexion_a_BD.Conectar();
            cmbCajas.ValueMember = "ID_CAJA";
            cmbCajas.DisplayMember = "descripcion";
            cmbCajas.DataSource = Conexion_a_BD.Consultasql("ID_CAJA, descripcion", "cajas where  COD_OFI= '" + cmbOficina.SelectedValue + "'", "Descripcion");
            Conexion_a_BD.Desconectar();
            
        }
    }
}
