﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DevComponents.AdvTree ;

using Predial10.Resources.CODE;

namespace Predial10
{
    public partial class frmcalculadora :  DevComponents.DotNetBar.Office2007Form
    {
        Conexion_a_BD basem = new Conexion_a_BD();
        DataTable tablatarifa = new DataTable();
        DataTable tablaempresa = new DataTable();
        Pago pago = new Pago();
        clsrecargo recargo = new clsrecargo();
        decimal porcrecargo;
        decimal porcINSEN;
        decimal porcJUBI;

        public frmcalculadora()
        {
            InitializeComponent();
            
        }

        private void Calculadora_Load(object sender, EventArgs e)
        {
            Conexion_a_BD.Conectar();
            cmbTarifas.ValueMember = "idTarifas";
            cmbTarifas.DisplayMember = "Descripcion";
            
            tablatarifa = Conexion_a_BD.Consultasql("idTarifas, Descripcion,porcentajebase,porcentajecobro,porcentajederecargo", "tarifas", "Descripcion");
            cmbTarifas.DataSource = tablatarifa;
            Conexion_a_BD.Desconectar();
            Conexion_a_BD.Conectar();
            

            tablaempresa = Conexion_a_BD.Consultasql("*", "empresa","CODEMP");
            
            Conexion_a_BD.Desconectar();


            var results = from myRow in tablaempresa.AsEnumerable() select myRow;
            try
            {
                DataView view = results.AsDataView();
                porcrecargo  = Convert.ToDecimal(view[0]["precargopredial"].ToString());
                porcINSEN = Convert.ToDecimal(view[0]["pdesctoinsen"].ToString());
                porcJUBI = Convert.ToDecimal(view[0]["pdesctopen"].ToString());
               
            }
            catch (Exception x)
            {
            }




            DTinicio.Value = DateTime.Now;
            string final = DateTime.Now.Year.ToString () + "/12/31";
            Dtfinal.Value = DateTime.Parse(final);

        }

       

        private void buttonX1_Click(object sender, EventArgs e)
        {
            lblImpuesto.Text = "0";
            lblRezago.Text = "0";

            validafechafinal();

            advdesgloze.Nodes.Clear();
            pago.fecha = DTinicio.Value;
            pago.fechadehoy = Dtfinal.Value;
            pago.porcentaje = Convert.ToDecimal(DIporcentaje.Value);
            pago.porcentajederecargo  = Convert.ToDecimal(Direcargo.Value);
            pago.valor = Convert.ToDecimal(divalorfiscal.Value);
            pago.tarifa = Convert.ToInt32(cmbTarifas.SelectedValue);
            pago.Porcentajeimpuesto = Convert.ToDecimal(DIimpuesto.Value);
            pago.Periodosdescontados = IIperiodosdescontados.Value;
            pago.Porcentaje_de_descuento = Convert.ToDecimal ( DIporcentajuedescuento.Value);
           // pago.porcentajederecargo = porcrecargo;
           
            if (chkanual.Checked) { pago.tipo = Predial10.Resources.CODE.Pago.tipopago.anual; }
            if (this.chkbimestral.Checked) { pago.tipo = Predial10.Resources.CODE.Pago.tipopago.bimestral; }

            pago.calcula();

            lblperiodo.Text = String.Format(new AcctNumberFormat(), "{0:C2}",pago.periodosCount.ToString());
            lblRezago.Text = String.Format(new AcctNumberFormat(), "{0:C2}",pago.Rezago);
            lblImpuesto.Text = String.Format(new AcctNumberFormat(), "{0:C2}",pago.Impuesto);

            if (chkperdonarrec.Checked == false)
            {
                lblRecargo.Text = String.Format(new AcctNumberFormat(), "{0:C2}", pago.Recargo);
                lblrecanter.Text = String.Format(new AcctNumberFormat(), "{0:C2}", pago.RecargoRezagos);
            }
            else
            {
                pago.Recargo = 0;
                pago.RecargoRezagos = 0;
                lblRecargo.Text = String.Format(new AcctNumberFormat(), "{0:C2}", pago.Recargo );
            }
            decimal total = 0;
            total = pago.Rezago + pago.Impuesto  + pago.TotalRecargos;
            lbltotal.Text = String.Format(new AcctNumberFormat(), "{0:C2}", total);
            llenaadvTreedesgloze();

            /*****************************************aqui calcula recargos bimestrales ***************************************/
           

           


         



        //    listBox1.Items.Add(recargo.periodos[0].periodobi  );


        }

        private void cmbTarifas_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var results = from myRow in tablatarifa.AsEnumerable()
                          where myRow.Field<int>("idTarifas") == Convert.ToInt16(cmbTarifas.SelectedValue)
                          select myRow;
            try
            {
                DataView view = results.AsDataView();
                DIporcentaje.Value = Convert.ToDouble(view[0]["porcentajebase"].ToString());
                DIimpuesto.Value = Convert.ToDouble(view[0]["porcentajecobro"].ToString());
                Direcargo.Value = Convert.ToDouble(view[0]["porcentajederecargo"].ToString());
            }
            catch (Exception x)
            {
            }
        }

       public void llenaadvTreedesgloze()
       {
           for (int i = 0; i <= pago.periodosCount-1; i++)
           {
               Node nodo = new Node();
               nodo.Cells[0].Text = pago.periodos[i].periodo;
               Cell celda = new Cell();
               // añade el impuesto
               DevComponents.DotNetBar.LabelX etiqueta = new DevComponents.DotNetBar.LabelX();
               etiqueta.Text = String.Format(new AcctNumberFormat(), "{0:C2}", pago.periodos[i].Impuestobruto);
               etiqueta.TextAlignment = StringAlignment.Far ;
               celda.HostedControl = etiqueta ;
               nodo.Cells.Add(celda);

               // añade el impuesto bruto
               Cell celda1 = new Cell();
                DevComponents.DotNetBar.LabelX etiqueta1 = new DevComponents.DotNetBar.LabelX();
               etiqueta1.Text =  String.Format ( new AcctNumberFormat(),"{0:C2}", pago.periodos[i].ImpuestoNeto ) ;
               etiqueta1.TextAlignment = StringAlignment.Far ;
               celda1.HostedControl = etiqueta1 ;
               nodo.Cells.Add(celda1);
               
               // añade el descuento al advtree

               Cell celda2 = new Cell();
               DevComponents.DotNetBar.LabelX etiqueta2 = new DevComponents.DotNetBar.LabelX();
               etiqueta2.Text = String.Format(new AcctNumberFormat(), "{0:0%}", (pago.periodos[i].porcdedescuento/100)  );
               etiqueta2.TextAlignment = StringAlignment.Far;
               celda2.HostedControl = etiqueta2;
               nodo.Cells.Add(celda2);

               // añade el descuento en dinero
               Cell celda3 = new Cell();
               DevComponents.DotNetBar.LabelX etiqueta3 = new DevComponents.DotNetBar.LabelX();
               etiqueta3.Text = String.Format(new AcctNumberFormat(), "{0:C2}", pago.periodos[i].descuento);
               etiqueta3.TextAlignment = StringAlignment.Far;
               celda3.HostedControl = etiqueta3;
               nodo.Cells.Add(celda3);
           

               // AÑADE el tipo

               Cell celda4 = new Cell();
               DevComponents.DotNetBar.LabelX etiqueta4 = new DevComponents.DotNetBar.LabelX();
               switch (pago.periodos[i].Tipo)
               {
                   case clsperiodo.tipoimpuesto.Impuesto:
                       etiqueta4.BackColor = Color.Lime  ;
                       etiqueta4.Text = "Periodo Actual";
                       break;
                   case clsperiodo.tipoimpuesto.Rezago:
                       etiqueta4.BackColor = Color.Gainsboro ;
                       etiqueta4.Text = "Periodo Rezagado";
                       break;
               }

               etiqueta4.TextAlignment = StringAlignment.Far;
               celda4.HostedControl = etiqueta4;
               nodo.Cells.Add(celda4);
               // añade el recargo

               Cell celdarecargo = new Cell();
               DevComponents.DotNetBar.LabelX etiquetarecargo = new DevComponents.DotNetBar.LabelX();
               etiquetarecargo.Text = String.Format(new AcctNumberFormat(), "{0:C2}", pago.periodos[i].Recargo );
               etiquetarecargo.TextAlignment = StringAlignment.Far;
               celdarecargo.HostedControl = etiquetarecargo;
               nodo.Cells.Add(celdarecargo);  

               // añade el acumulado
               Cell celda5 = new Cell();
               DevComponents.DotNetBar.LabelX etiqueta5 = new DevComponents.DotNetBar.LabelX();
               etiqueta5.Text = String.Format(new AcctNumberFormat(), "{0:C2}", pago.periodos[i].Acumulado );
               etiqueta5.TextAlignment = StringAlignment.Far;
               celda5.HostedControl = etiqueta5;
               nodo.Cells.Add(celda5);

               

               advdesgloze.Nodes.Add(nodo);

 
           }
       }

       public void validafechafinal()
       {
           int ano = Dtfinal.Value.Year;
           if (ano > DateTime.Now.Year)
           {
               ano = DateTime.Now.Year;
           }
           int mes = this.Dtfinal.Value.Month  ;
   
           switch (mes)
           {
               case 1:
                   {
                       mes = 2;
                       break;
                   }
               case 3:
                   {
                       mes = 4;
                       break;
                   }
               case 5:
                   {
                       mes = 6;
                       break;
                   }
               case 7:
                   {
                       mes = 8;
                       break;
                   }
               case 9:
                   {
                       mes = 10;
                       break;
                   }
               case 11:
                   {
                       mes = 12;
                       break;
                   }

                

           }
           string cadena = ano.ToString() + "/" + mes.ToString() + "/28";
           Dtfinal.Value = DateTime.Parse(cadena);
       }

       private void checkBoxX2_CheckedChanged(object sender, EventArgs e)
       {
           if (chkpen.Checked == true)
           {
               chkinsen.Checked = false;
               DIporcentajuedescuento.Value  = Convert.ToDouble (porcJUBI);
               IIperiodosdescontados.Value  = 1;
           }
           if (chkpen.Checked == false)
           {
               //chkinsen.Checked = false;
               DIporcentajuedescuento.Value = Convert.ToDouble(0);
               IIperiodosdescontados.Value = 0;
           }

       }

       private void chkinsen_CheckedChanged(object sender, EventArgs e)
       {
           if (chkinsen.Checked == true)
           {
               chkpen.Checked = false;
               DIporcentajuedescuento.Value = Convert.ToDouble(porcINSEN );
               IIperiodosdescontados.Value = 1;
           }
           if (chkinsen.Checked == false)
           {
               //chkinsen.Checked = false;
               DIporcentajuedescuento.Value = Convert.ToDouble(0);
               IIperiodosdescontados.Value = 0;
           }
       }
      
    }
}
