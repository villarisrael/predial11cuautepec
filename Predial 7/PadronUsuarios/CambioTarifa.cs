using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Predial10.Resources.CODE;

namespace Predial10.PadronUsuarios
{
    public partial class CambioTarifa : Form
    {
        public String Modo;
        public string cuenta = "";

        public CambioTarifa(string _cuenta = "")
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Modo == "Insertar")
                {
                    if (txtObservaciones.Text == "")
                    {
                        MessageBox.Show("Ingrese el motivo del cambio de tarifa", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        Conexion_a_BD.Conectar();
                        StringBuilder StrIntert = new StringBuilder();
                        StringBuilder StrUpdate = new StringBuilder();
                        StrIntert.Append("INSERT INTO cambiotarifa_p SET ");

                        StrIntert.Append("Cuenta = '" + txtClavePredial.Text + "',");
                        StrIntert.Append("Comunidad ='" + cmbComunidad.SelectedValue.ToString() + "',");
                        StrIntert.Append("AntesTipo ='" + cmbTipo.SelectedValue + "',");
                        StrIntert.Append("AntesTarifa ='" + cmbTarifa.SelectedValue.ToString() + "',");
                        StrIntert.Append("Tipo ='" + cmbNTipo.SelectedValue.ToString() + "',");
                        StrIntert.Append("Tarifa ='" + cmbNTarifa.SelectedValue.ToString() + "',");
                        StrIntert.Append("Fecha ='" + Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("yyyy-MM-dd") + "',");
                        StrIntert.Append("Observacion ='" + txtObservaciones.Text + "'");
                        Conexion_a_BD.insertar(StrIntert.ToString());
                        Conexion_a_BD.Desconectar();

                        Conexion_a_BD.Conectar();

                        StrUpdate.Append("Update usuario set id_Tarifa_P='" + cmbNTarifa.SelectedValue + "' where clave_predial='" + txtClavePredial.Text + "'");
                        Conexion_a_BD.insertar(StrUpdate.ToString());
                        Conexion_a_BD.Desconectar();

                        MessageBox.Show("El cambio de tarifa se ha realizado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                   
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CambioTarifa_Load(object sender, EventArgs e)
        {
            //Cargar datos
            Conexion_a_BD.Conectar();
            cmbTarifa.ValueMember = "idTarifas";
            cmbTarifa.DisplayMember = "Descripcion";            
            cmbTarifa.DataSource = Conexion_a_BD.Consultasql("idTarifas, Descripcion", "tarifas", "Descripcion");
            Conexion_a_BD.Desconectar();
           

            Conexion_a_BD.Conectar();
            cmbTipo.ValueMember = "tipo";
            cmbTipo.DisplayMember = "tipo";
            cmbTipo.DataSource = Conexion_a_BD.Consultasql(" distinct tipo", "tarifas", "idTarifas");
            //cmbTipo.DataSource = Conexion_a_BD.Consultasql("tipo", "tarifas where Descripcion='" + cmbTarifa.SelectedValue + "'", "idTarifas");
            Conexion_a_BD.Desconectar();

            
            Conexion_a_BD.Conectar();
            cmbNTipo.ValueMember = "tipo";
            cmbNTipo.DisplayMember = "tipo";
            cmbNTipo.DataSource = Conexion_a_BD.Consultasql("distinct tipo", "tarifas", "idTarifas");
            Conexion_a_BD.Desconectar();

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
            cmbTarifa.SelectedValue = view[0]["id_Tarifa_P"].ToString();           
           
            }            
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmbNTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Conexion_a_BD.Desconectar();
            Conexion_a_BD.Conectar();
            cmbNTarifa.ValueMember = "idTarifas";
            cmbNTarifa.DisplayMember = "Descripcion";
            cmbNTarifa.DataSource = Conexion_a_BD.Consultasql("idTarifas, Descripcion", "tarifas where tipo= '" + cmbNTipo.SelectedValue + "'", "Descripcion");           
            Conexion_a_BD.Desconectar();
        }       
    }
}
