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
    public partial class Traslado : Form
    {
        public String Modo;
        public string cuenta = "";

        public Traslado(string _cuenta = "")
        {
            InitializeComponent();
            if (_cuenta == "")
            {
                Modo = "Insertar";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Traslado_Load(object sender, EventArgs e)
        {
            

            Conexion_a_BD.Conectar();
            cmbComunidad.ValueMember = "Id_comunidad";
            cmbComunidad.DisplayMember = "Comunidad";
            cmbComunidad.DataSource = Conexion_a_BD.Consultasql("Id_comunidad ,Comunidad", "comunidades", "Comunidad");
            Conexion_a_BD.Desconectar();

            Conexion_a_BD.Conectar();
            cmbCalle.ValueMember = "ID_CALLE";
            cmbCalle.DisplayMember = "NOMBRE";
            cmbCalle.DataSource = Conexion_a_BD.Consultasql("ID_CALLE, NOMBRE", "calles", "NOMBRE");
            Conexion_a_BD.Desconectar();

            if ((Modo == "Insertar"))
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
                tabla = Conexion_a_BD.Consultasql("*", " usuario where clave_predial ='" + _cuenta + "'", "clave_predial");
                Conexion_a_BD.Desconectar();

                var results = from myRow in tabla.AsEnumerable()

                              select myRow;
                DataView view = results.AsDataView();

                txtClavePredial.Text = view[0]["clave_predial"].ToString();
                txtNombre.Text = view[0]["NOMBRE"].ToString();
                cmbComunidad.SelectedValue = view[0]["id_comunidad"].ToString();
                cmbCalle.SelectedValue = view[0]["id_calle"].ToString();             

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Modo == "Insertar")
                {
                    if (txtNuevoNombre.Text == "")
                    {
                        MessageBox.Show("Ingrese el Nuevo Nombre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        Conexion_a_BD.Conectar();
                        StringBuilder StrIntert = new StringBuilder();
                        StringBuilder StrUpdate = new StringBuilder();
                        StrIntert.Append("INSERT INTO cambionombre_p SET ");

                        StrIntert.Append("Cuenta = '" + txtClavePredial.Text + "',");
                        StrIntert.Append("Comunidad ='" + cmbComunidad.SelectedValue.ToString() + "',");
                        StrIntert.Append("NombreAntes='" + txtNombre.Text + "',");
                        StrIntert.Append("Nombre='" + txtNuevoNombre.Text + "',");
                        StrIntert.Append("Fecha ='" + Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("yyyy-MM-dd") + "',");
                        StrIntert.Append("Observacion ='" + txtObservacion.Text + "'");
                        Conexion_a_BD.insertar(StrIntert.ToString());
                        Conexion_a_BD.Desconectar();

                        Conexion_a_BD.Conectar();

                        StrUpdate.Append("Update usuario set NOMBRE='" + txtNuevoNombre.Text + "' where clave_predial='" + txtClavePredial.Text + "'");
                        Conexion_a_BD.insertar(StrUpdate.ToString());
                        Conexion_a_BD.Desconectar();

                        MessageBox.Show("El traslado de dominio se ha realizado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
