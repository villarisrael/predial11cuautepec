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
    public partial class frmexpediente : DevComponents.DotNetBar.Office2007Form
    {
        public string cuenta = "";
        public frmexpediente(string _cuenta = "")
        {
            InitializeComponent();
            cuenta = _cuenta;
            Conexion_a_BD.Desconectar();
           
        }

        private void frmexpediente_Load(object sender, EventArgs e)
        {
            cargardatos(cuenta);
            cargacambios();
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Tabdetalles_Click(object sender, EventArgs e)
        {
            string folio = dtgfacturas.Rows[dtgfacturas.CurrentRow.Index].Cells[1].Value.ToString();
            advDetalles.Nodes.Clear();

            Conexion_a_BD.Conectar ();
            DataTable tablamaestro = Conexion_a_BD.Consultasql ("*" , "recibomaestro where folio=" + folio );
            Conexion_a_BD.Desconectar ();

              var resultado = from myRow in tablamaestro.AsEnumerable() select myRow;
             DataView view = resultado.AsDataView();
            string oficina="";
            string caja="";
             try
             {
                 oficina = Conexion_a_BD.obtenercampo ("select nombre from oficinas where cod_ofi='" + view[0]["ccodofi"].ToString() + "'");
                 caja =Conexion_a_BD.obtenercampo ("select descripcion from cajas where cod_ofi='" + view[0]["ccodofi"].ToString() + "' and id_caja='" +view[0]["caja"].ToString()+"'"  );
           
             }
             catch (Exception x)
             {
             }

            string formadepago = Conexion_a_BD.obtenercampo ("select cdespago from fpago where ccodpago='" +  view[0]["idformapago"].ToString() +"'"); 
            DevComponents.AdvTree.Node Nodo1 = new DevComponents.AdvTree.Node();

           
            Nodo1.Cells[0].Text = "Recibo "  + folio + " fue cobrado en " + oficina + " en la caja " + caja + " forma de pago: " + formadepago + "  El dia " + dtgfacturas.Rows[dtgfacturas.CurrentRow.Index].Cells[0].Value.ToString();  ;
            Nodo1.NodesColumns.Add(new DevComponents.AdvTree.ColumnHeader("Concepto"));
            Nodo1.NodesColumns[0].Width.Absolute  = 300;
            Nodo1.NodesColumns.Add(new DevComponents.AdvTree.ColumnHeader("Importe"));
            Nodo1.NodesColumns[1].Width.Absolute = 100;

            Conexion_a_BD.Conectar();
            DataTable tablaesclavo = Conexion_a_BD.Consultasql("*", "reciboesclavo where recibo=" + folio);
            Conexion_a_BD.Desconectar();

            var resultadoesclavo = from myRow in tablaesclavo.AsEnumerable() select myRow;
            DataView view2 = resultadoesclavo.AsDataView();


            for (int i = 0; i<=view2.Count - 1; i++)
            {
                DevComponents.AdvTree.Node nuevoconcepto = new DevComponents.AdvTree.Node();
                nuevoconcepto.Cells[0].Text = view2[i]["Concepto"].ToString();
                nuevoconcepto.Cells.Add ( new DevComponents.AdvTree.Cell() );
                nuevoconcepto.Cells[1].HostedControl = monedatext ( Convert.ToDouble (view2[i]["Importe"].ToString()));
                Nodo1.Nodes.Add(nuevoconcepto);
            }
            Nodo1.Expand();
            advDetalles.Nodes.Add(Nodo1);

        }


        public Label monedatext(double monto)
        {
            Label mon = new Label();
            mon.Text = String.Format(new AcctNumberFormat(), "{0:C2}", Convert.ToDecimal(monto));
            mon.TextAlign = ContentAlignment.MiddleRight;
            if (monto >= 0)
            {
                mon.ForeColor = Color.Blue;
            }
            return mon;
        }

        private void cargardatos(string _cuenta)
        {
            try
            {
                Conexion_a_BD.Conectar();
                DataTable tabla;
                //Modifique la consulta para que busque por clave predial en lugar de cuenta
                tabla = Conexion_a_BD.Consultasql("*", " vusuario where catastral ='" + cuenta + "'", "catastral");
                Conexion_a_BD.Desconectar();

                var results = from myRow in tabla.AsEnumerable()

                              select myRow;
                DataView view = results.AsDataView();

              
                lblnombre.Text = view[0]["catastral"].ToString() + " " + view[0]["NOMBRE"].ToString();
                lbldireccion.Text = view[0]["calle"].ToString() + " " + view[0]["numext"].ToString() + " " +view[0]["colonia"].ToString() + " "  + view[0]["comunidad"].ToString();
                lblvalor.Text = view[0]["valor_fiscal"].ToString();
                lblfecha.Text = view[0]["UltimoPagop"].ToString();
                lblImpuesto.Text = view[0]["Adeudo_p"].ToString();
                lblRecargo .Text = view[0]["Recargos_p"].ToString();
                lbltotal.Text = view[0]["Totaladeudo_p"].ToString();

                 Conexion_a_BD.Conectar();
                DataTable tablarecibos;
                tablarecibos = Conexion_a_BD.Consultasql("Fecha, Folio, Total, idFormapago, year(fecha_inicial)+1 as anoinicio, year(fecha_final) as anofinal,porcdescuento,porcdescuentorecargos,tipodescuento", " RECIBOMAESTRO where catastral ='" + cuenta + "' and cancelado='A'", "catastral");
                dtgfacturas.DataSource = tablarecibos;
                Conexion_a_BD.Desconectar();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void cargacambios()
        {
            Conexion_a_BD.Conectar();
            DataTable tabla;
            //Modifique la consulta para que busque por clave predial en lugar de cuenta
            tabla = Conexion_a_BD.Consultasql("*", " cambionombre_p where cuenta ='" + cuenta + "'", "Fecha");
            Conexion_a_BD.Desconectar();

            var results = from myRow in tabla.AsEnumerable()

                          select myRow;
            DataView view = results.AsDataView();


            advCambios.Nodes.Clear();
            for (int cambio = 0; cambio < tabla.Rows.Count; cambio++)
            {
                DevComponents.AdvTree.Node Nodo = new DevComponents.AdvTree.Node();
                Nodo.Text = view[cambio]["Fecha"].ToString();
                DevComponents.AdvTree.Cell Celda1 = new DevComponents.AdvTree.Cell();
                Celda1.Text = "Cambio de Nombre " + " " + view[cambio]["NOMBREAntes"].ToString() + " -> " + view[cambio]["NOMBRE"].ToString();
                Nodo.Cells.Add(Celda1);
                advCambios.Nodes.Add(Nodo);
               
            }

            /* cambio de valor ******************************************************************************/
            Conexion_a_BD.Conectar();
            DataTable tabla2;
            //Modifique la consulta para que busque por clave predial en lugar de cuenta
            tabla2 = Conexion_a_BD.Consultasql("*", " cambiovalor_p where cuenta ='" + cuenta + "' ", "Fecha desc");
            Conexion_a_BD.Desconectar();

            var results2 = from myRow in tabla2.AsEnumerable()

                          select myRow;
            DataView view2 = results2.AsDataView();

            for (int cambio = 0; cambio < tabla2.Rows.Count; cambio++)
            {
                DevComponents.AdvTree.Node Nodo = new DevComponents.AdvTree.Node();
                Nodo.Text = view2[cambio]["Fecha"].ToString();
                DevComponents.AdvTree.Cell Celda1 = new DevComponents.AdvTree.Cell();
                Celda1.Text = "Cambio de Valor " + " " + view2[cambio]["ValorAntes"].ToString() + " -> " + view2[cambio]["ValorDespues"].ToString();
                Nodo.Cells.Add(Celda1);
                advCambios.Nodes.Add(Nodo);

            }

            /* cambio de Tarifa ******************************************************************************/
            Conexion_a_BD.Conectar();
            DataTable tabla3;
            //Modifique la consulta para que busque por clave predial en lugar de cuenta
            tabla3 = Conexion_a_BD.Consultasql("*", " cambiotarifa_p where cuenta ='" + cuenta + "'", "Fecha");
            Conexion_a_BD.Desconectar();

            var results3 = from myRow in tabla3.AsEnumerable()

                           select myRow;
            DataView view3 = results3.AsDataView();

            for (int cambio = 0; cambio < tabla3.Rows.Count; cambio++)
            {
                DevComponents.AdvTree.Node Nodo = new DevComponents.AdvTree.Node();
                Nodo.Text = view3[cambio]["Fecha"].ToString();
                DevComponents.AdvTree.Cell Celda1 = new DevComponents.AdvTree.Cell();
                string Valorantes = Conexion_a_BD.obtenercampo("select Descripcion from tarifas where idTarifas=" + view3[cambio]["AntesTarifa"].ToString());
                string Valordespues = Conexion_a_BD.obtenercampo("select Descripcion from tarifas where idTarifas=" + view3[cambio]["Tarifa"].ToString());
                Celda1.Text = "Cambio de tarifa :" + " " + Valorantes  + " -> " + Valordespues ;
                Nodo.Cells.Add(Celda1);
                advCambios.Nodes.Add(Nodo);

            }
        }
    }
}
