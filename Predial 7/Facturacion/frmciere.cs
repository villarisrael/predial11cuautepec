﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Predial10.Resources.CODE;

namespace Predial10.Facturacion
{
    public partial class frmcierre : Form
    {
        DataTable tablausuario = new DataTable();
        Pago pago = new Pago();
        int cuantosusuarios = 0;
        public frmcierre()
        {
            InitializeComponent();

        }

        private void frmcierre_Load(object sender, EventArgs e)
        {
            Conexion_a_BD.Conectar();
            tablausuario = Conexion_a_BD.Consultasql("count(cuenta) as conteo ", "usuario");
            Conexion_a_BD.Desconectar();
            var results = from myRow in tablausuario.AsEnumerable() select myRow;
            try
            {
                DataView view = results.AsDataView();
                cuantosusuarios = Convert.ToInt32 (view[0]["conteo"].ToString ());
               lblusuarios.Text  = view[0]["conteo"].ToString();
              
                 progressBarX1.Maximum = cuantosusuarios ;
            }
           
            catch (Exception x)
            {
            }
        }

        private void btnhacer_Click(object sender, EventArgs e)
        {
            btnhacer.Enabled = false;
            btncerrar.Enabled = false;
            Conexion_a_BD.Conectar();
            tablausuario = Conexion_a_BD.Consultasql("*", "usuario,tarifas where usuario.id_tarifa_p =Tarifas.idTarifas");
            Conexion_a_BD.Desconectar();

            var results = from myRow in tablausuario.AsEnumerable() select myRow;
            try
            {
                Conexion_a_BD.Conectar();
                DataView view = results.AsDataView();
                DateTime fechafinal = DateTime.Now;
                for (int i = 0; i < cuantosusuarios; i++)
                {
                    try
                    {
                        DateTime fechainicio;

                        long cuenta = Convert.ToInt64(view[i]["clave"].ToString());
                        fechainicio = Convert.ToDateTime(view[i]["UltimoPagoP"].ToString());
                        pago.fecha = fechainicio;
                        pago.fechadehoy = fechafinal;
                        pago.porcentaje = Convert.ToDecimal(view[i]["porcentajebase"].ToString());
                        pago.porcentajederecargo = Convert.ToDecimal(view[i]["porcentajederecargo"].ToString());
                        pago.valor = Convert.ToDecimal(view[i]["Valor_fiscal_P"].ToString());
                        pago.tarifa = Convert.ToInt32(view[i]["idTarifas"].ToString());
                        pago.Porcentajeimpuesto = Convert.ToDecimal(view[i]["porcentajecobro"].ToString());
                        pago.Periodosdescontados = 0;
                        pago.Porcentaje_de_descuento = Convert.ToDecimal(0);
                        // pago.porcentajederecargo = porcrecargo;

                        pago.tipo = Predial10.Resources.CODE.Pago.tipopago.anual;


                        pago.calcula();
                         
                        decimal adeudo = pago.Impuesto + pago.Rezago;
                        decimal recargo = pago.TotalRecargos;
                        long periodos = pago.periodosCount;
                        decimal total = adeudo + recargo;
                        try
                        {

                            Conexion_a_BD.insertar("update usuario set adeudo_p=" + adeudo + ", recargos_p= " + recargo + " ,totalAdeudo_p=" + total + ",periodos_p =" + periodos + " where clave=" + cuenta);

                        }
                        catch (Exception x)
                        {
                            MessageBox.Show(x.Message);
                        }
                    }
                    catch (Exception y)
                    {
                        MessageBox.Show(y.Message);
                    }
                    
                    progressBarX1.Text = (i / cuantosusuarios).ToString (); 
                    progressBarX1.Value = i;
                    lblusuarios.Text = i.ToString ();
                }
                MessageBox.Show("termine");

                Conexion_a_BD.Desconectar();
                btnhacer.Enabled = true;
                btncerrar.Enabled = true;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
                btnhacer.Enabled = true;
                btncerrar.Enabled = true;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        public static void cierra( string _cuenta, DateTime _fechainicio)
            {

            DataTable tabla;
            Conexion_a_BD.Conectar();
            tabla = Conexion_a_BD.Consultasql("*", "usuario,tarifas where usuario.id_tarifa_p =Tarifas.idTarifas and clave_predial='" + _cuenta +"'");
            Conexion_a_BD.Desconectar();

            var results = from myRow in tabla.AsEnumerable() select myRow;
            try
            {
                Conexion_a_BD.Conectar();
                DataView view = results.AsDataView();
                DateTime fechafinal = DateTime.Now;
                try
                {
                    Pago pago = new Pago();
                    DateTime fechainicio;
                    long cuenta = Convert.ToInt64(view[0]["clave"].ToString());

                    fechainicio = Convert.ToDateTime(view[0]["UltimoPagoP"].ToString());
                    pago.fecha = _fechainicio;
                    pago.fechadehoy = DateTime.Now;
                    pago.porcentaje = Convert.ToDecimal(view[0]["porcentajebase"].ToString());
                    pago.porcentajederecargo = Convert.ToDecimal(view[0]["porcentajederecargo"].ToString());
                    pago.valor = Convert.ToDecimal(view[0]["Valor_fiscal_P"].ToString());
                    pago.tarifa = Convert.ToInt32(view[0]["idTarifas"].ToString());
                    pago.Porcentajeimpuesto = Convert.ToDecimal(view[0]["porcentajecobro"].ToString());
                    pago.Periodosdescontados = 0;
                    pago.Porcentaje_de_descuento = Convert.ToDecimal(0);
                    // pago.porcentajederecargo = porcrecargo;

                    pago.tipo = Predial10.Resources.CODE.Pago.tipopago.anual;


                    pago.calcula();

                    decimal adeudo = pago.Impuesto + pago.Rezago;
                    decimal recargo = pago.Recargo;
                    long periodos = pago.periodosCount;
                    decimal total = adeudo + recargo;
                    try
                    {

                        Conexion_a_BD.insertar("update usuario set adeudo_p=" + adeudo + ", recargos_p= " + recargo + " ,totalAdeudo_p=" + total + ",periodos_p =" + periodos + " where clave=" + cuenta);

                    }
                    catch (Exception x)
                    {
                        MessageBox.Show(x.Message);
                    }
                }
                catch (Exception y)
                {
                    MessageBox.Show(y.Message);
                }
            }
            catch (Exception z)
            {
                MessageBox.Show(z.Message);
            }
            }

    }
}
