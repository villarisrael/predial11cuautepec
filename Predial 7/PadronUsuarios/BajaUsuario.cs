﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Predial10.Resources.CODE;

namespace Predial10.PadronUsuarios
{
    public partial class BajaUsuario : Form
    {
        public String Modo;
        public string cuenta = "";


        public BajaUsuario(string _cuenta = "")
        {
            InitializeComponent();
            if (_cuenta == "")
            {
                Modo = "Baja";
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Esta seguro de dar baja este usuario?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            try
            {
                if (resultado == DialogResult.Yes)
                {
                    Conexion_a_BD.Conectar();
                    StringBuilder strUpdate = new StringBuilder();

                    if (Modo == "Baja")
                    {
                        strUpdate.Append("Update usuario set Estado_P='" + "INACTIVO" + "' where clave='" + cuenta + "'");
                    }
                    Conexion_a_BD.insertar(strUpdate.ToString());
                    Conexion_a_BD.Desconectar();

                    MessageBox.Show("El usuario se ha eliminado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
        }

        private void BajaUsuario_Load(object sender, EventArgs e)
        {

            //Llena el combo de Municipio
            Conexion_a_BD.Conectar();
            cmbMunicipio.ValueMember = "clave";
            cmbMunicipio.DisplayMember = "nombre";
            cmbMunicipio.DataSource = Conexion_a_BD.Consultasql("clave ,nombre", "municipios", "clave");
            Conexion_a_BD.Desconectar();

            //Llena el combo de Comunidad
            Conexion_a_BD.Conectar();
            cmbComunidad.ValueMember = "Id_comunidad";
            cmbComunidad.DisplayMember = "Comunidad";
            cmbComunidad.DataSource = Conexion_a_BD.Consultasql("Id_comunidad ,Comunidad", "comunidades", "Comunidad");
            Conexion_a_BD.Desconectar();

           
            if ((Modo == "Baja"))
            {
                cargardatos(cuenta);

            }

        }

        private void cargardatos(string _cuenta)
        {
            try
            {
                Conexion_a_BD.Conectar();
                DataTable tabla;
                //Modifique la consulta para que busque por clave predial en lugar de cuenta
                tabla = Conexion_a_BD.Consultasql("*", " usuario where clave ='" + _cuenta + "'", "clave");
                Conexion_a_BD.Desconectar();

                var results = from myRow in tabla.AsEnumerable()

                              select myRow;
                DataView view = results.AsDataView();

                txtClaveCatastral.Text = view[0]["clave_predial"].ToString();
                txtTitular.Text = view[0]["NOMBRE"].ToString();
                cmbComunidad.SelectedValue = view[0]["id_comunidad"].ToString();
                cmbMunicipio.SelectedValue = view[0]["NMunicipio"].ToString();
                //cmbTarifa.SelectedValue = view[0]["idTarifa"].ToString();
                txtValorFiscal.Text = view[0]["Valor_Fiscal_P"].ToString();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Esta seguro de ELIMINAR este usuario?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            try
            {
                if (resultado == DialogResult.Yes)
                {
                    Conexion_a_BD.Conectar();
                    StringBuilder strUpdate = new StringBuilder();

                    if (Modo == "Baja")
                    {
                        strUpdate.Append("delete from usuario where clave='" + cuenta    + "'");
                    }
                    Conexion_a_BD.insertar(strUpdate.ToString());
                    Conexion_a_BD.Desconectar();

                    MessageBox.Show("El usuario se ha eliminado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {

        }
    }
}
