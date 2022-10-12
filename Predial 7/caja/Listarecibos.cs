using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

using Predial10.Resources.CODE;


namespace Predial10.caja
{
    public partial class Listarecibos : Form
    {
         ArchivoSql archivox = new ArchivoSql();
        public Listarecibos()
        {
            InitializeComponent();
        }

        private void Listarecibos_Load(object sender, EventArgs e)
        {
            dtinicio.Value = DateTime.Now;
            dtfinal.Value = DateTime.Now;
            Conexion_a_BD.Conectar();
            cmbOficina.ValueMember = "COD_OFI";
            cmbOficina.DisplayMember = "NOMBRE";
            cmbOficina.DataSource = Conexion_a_BD.Consultasql("COD_OFI, Nombre", "oficinas", "COD_OFI");
            Conexion_a_BD.Desconectar();     
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            if (cmbOficina.Text == "" || cmbCajas.Text == "")
            {
                MessageBox.Show("Dame una oficina y una caja ");
                    return ;
            }

          this.recibomaestroTableAdapter.Fillfechaycaja (predialchicoDataSet.recibomaestro, dtinicio.Value, dtfinal.Value, cmbOficina.SelectedValue.ToString(), cmbCajas.SelectedValue.ToString ());
          dataGridView1.Refresh();
           double total=0;
           for (int i = 0; i <= dataGridView1.Rows.Count-1; i++)
           {
               if (dataGridView1.Rows[i].Cells[11].Value.ToString() == "A")
               {
                   total += Double.Parse( dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[9].Value.ToString());
               }
           }

           Lbltotal.Text = String.Format(new AcctNumberFormat(), "{0:C2}", total);
        }

        private void cmboficina_SelectedIndexChanged(object sender, EventArgs e)
        {
            Conexion_a_BD.Desconectar();
            Conexion_a_BD.Conectar();
            cmbCajas.ValueMember = "ID_CAJA";
            cmbCajas.DisplayMember = "descripcion";
            cmbCajas.DataSource = Conexion_a_BD.Consultasql("ID_CAJA, descripcion", "cajas where  COD_OFI= '" + cmbOficina.SelectedValue + "'", "Descripcion");
            Conexion_a_BD.Desconectar();
        }

        private void btncancelarrecibo_Click(object sender, EventArgs e)
        {
            DialogResult Result;
            Result = MessageBox.Show("¿Estas seguro?", "Cuidado!!!", MessageBoxButtons.OKCancel);
            if (Result == DialogResult.OK )

            {
                try
                {
                    string folio = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString(); // la 2 es la columna de folio
              
                clscancelacion cancela = new clscancelacion(cmbOficina.SelectedValue.ToString(), cmbCajas.SelectedValue.ToString(), folio);
                }
                catch(Exception exc)
                {
                    MessageBox.Show(exc.Message );
                }
                this.recibomaestroTableAdapter.Fillfechaycaja(predialchicoDataSet.recibomaestro, dtinicio.Value, dtfinal.Value, cmbOficina.SelectedValue.ToString(), cmbCajas.SelectedValue.ToString());
                dataGridView1.Refresh();
            }
        }


        public void dataGridView1_UserDeletedRow(object sender, EventArgs e)
        {

           
        }

        public void Esclavo_click(object sender, EventArgs e)
        {
            try
            {
                string folio = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                string serie = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[10].Value.ToString();
                advDetalles.Nodes.Clear();

                Conexion_a_BD.Conectar();
                DataTable tablamaestro = Conexion_a_BD.Consultasql("*", "recibomaestro where folio=" + folio + " and Serie='" + serie + "'");
                Conexion_a_BD.Desconectar();

                var resultado = from myRow in tablamaestro.AsEnumerable() select myRow;
                DataView view = resultado.AsDataView();
                string oficina = "";
                string caja = "";
                try
                {
                    oficina = Conexion_a_BD.obtenercampo("select nombre from oficinas where cod_ofi='" + view[0]["ccodofi"].ToString() + "'");
                    caja = Conexion_a_BD.obtenercampo("select descripcion from cajas where cod_ofi='" + view[0]["ccodofi"].ToString() + "' and id_caja='" + view[0]["caja"].ToString() + "'");

                }
                catch (Exception x)
                {
                }

                string formadepago = Conexion_a_BD.obtenercampo("select cdespago from fpago where ccodpago='" + view[0]["idformapago"].ToString() + "'");
                DevComponents.AdvTree.Node Nodo1 = new DevComponents.AdvTree.Node();


                Nodo1.Cells[0].Text = "Recibo " + folio + " fue cobrado en " + oficina + " en la caja " + caja + " forma de pago: " + formadepago + "  El dia " + this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[0].Value.ToString(); ;
                Nodo1.NodesColumns.Add(new DevComponents.AdvTree.ColumnHeader("Concepto"));
                Nodo1.NodesColumns[0].Width.Absolute = 300;
                Nodo1.NodesColumns.Add(new DevComponents.AdvTree.ColumnHeader("Importe"));
                Nodo1.NodesColumns[1].Width.Absolute = 100;

                Conexion_a_BD.Conectar();
                DataTable tablaesclavo = Conexion_a_BD.Consultasql("*", "reciboesclavo where recibo=" + folio + " and serie='" + serie + "'");
                Conexion_a_BD.Desconectar();

                var resultadoesclavo = from myRow in tablaesclavo.AsEnumerable() select myRow;
                DataView view2 = resultadoesclavo.AsDataView();


                for (int i = 0; i <= view2.Count - 1; i++)
                {
                    DevComponents.AdvTree.Node nuevoconcepto = new DevComponents.AdvTree.Node();
                    nuevoconcepto.Cells[0].Text = view2[i]["Concepto"].ToString();
                    nuevoconcepto.Cells.Add(new DevComponents.AdvTree.Cell());
                    nuevoconcepto.Cells[1].HostedControl = monedatext(Convert.ToDouble(view2[i]["Importe"].ToString()));
                    Nodo1.Nodes.Add(nuevoconcepto);
                }
                Nodo1.Expand();
                advDetalles.Nodes.Add(Nodo1);
            }
            catch (Exception exc)
            {
                MessageBox.Show (exc.Message);
            }

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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DialogResult Result;
            Result = MessageBox.Show("¿Estas seguro?", "Cuidado!!!", MessageBoxButtons.OKCancel);
            if (Result == DialogResult.OK)
            {
                try
                {
                    string RECIBO = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString(); ; // la 2 es la columna de folio
                    string OFICINA = cmbOficina.SelectedValue.ToString();
                    string CAJA = cmbCajas.SelectedValue.ToString();
                    clscancelacion cancela = new clscancelacion();
                    cancela.borrar(OFICINA, CAJA, RECIBO);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
                this.recibomaestroTableAdapter.Fillfechaycaja(predialchicoDataSet.recibomaestro, dtinicio.Value, dtfinal.Value, cmbOficina.SelectedValue.ToString(), cmbCajas.SelectedValue.ToString());
                dataGridView1.Refresh();
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            btnrenumerar.Enabled = false;
            try
            {
                  Conexion_a_BD.Conectar();
                string serie = Conexion_a_BD.obtenercampo("select serie from predialchico.cajas where cod_ofi='" + cmbOficina.SelectedValue.ToString () + "' and id_caja='" + cmbCajas.SelectedValue.ToString () + "'");
                Conexion_a_BD.Desconectar ();
                if (iisumando.Value <= -1)
                {

                    Conexion_a_BD.Conectar();
                    DataTable tablamaestro = Conexion_a_BD.Consultasql("*", "recibomaestro where folio=" + (iiinicio.Value + iisumando.Value) + " and Serie='" + serie + "'");
                    Conexion_a_BD.Desconectar();
                    var resultado = from myRow in tablamaestro.AsEnumerable() select myRow;
                    DataView view = resultado.AsDataView();

                    try
                    {
                        if (view[0]["folio"].ToString() != "")
                        {
                            MessageBox.Show("Hay folio en ese lugar ");
                            return;
                        }


                    }


                    catch (Exception x)
                    {
                    }
                }

                     if (iisumando.Value  >=1 )
                {
                    
                    Conexion_a_BD.Conectar();
                    DataTable tablamaestroa = Conexion_a_BD.Consultasql("*", "recibomaestro where folio=" +( iiinicio.Value+iisumando.Value ) + " and Serie='" + serie + "'");
                    Conexion_a_BD.Desconectar();
                    var resultadoa = from myRow in tablamaestroa.AsEnumerable() select myRow;
                    DataView viewa = resultadoa.AsDataView();
               
                    try
                    {
                        if (viewa[0]["folio"].ToString () != "")
                        {
                            MessageBox.Show ("Hay folio en ese lugar ");
                            return;
                        }
                   

                    }


                    catch (Exception x)
                    {
                    }
                }

                for (int i=iiinicio.Value; i<= iifinal.Value ;i++ )
                {
                    Conexion_a_BD.Conectar();
                    string cadena="UPDATE RECIBOMAESTRO SET FOLIO=FOLIO + " + iisumando.Value + " WHERE FOLIO= " + i + " and serie ='" + serie +"'";
                    Conexion_a_BD.Ejecutar(cadena );
                    string cadena2= "UPDATE RECIBOesclavo SET recibo=recibo + " + iisumando.Value + " WHERE recibo= " + i  + " and serie ='" + serie +"'";
                    Conexion_a_BD.Ejecutar(cadena2 );
                    string cadena3 = "use cobroexpress ;UPDATE RECIBOMAESTRO SET FOLIO=FOLIO + " + iisumando.Value + " WHERE FOLIO= " + i + " and serie ='" + serie + "' and catastral<>'';use predialchico";
                    Conexion_a_BD.Ejecutar(cadena3 );
                    string cadena4 = "use cobroexpress;UPDATE RECIBOesclavo SET recibo=recibo + " + iisumando.Value + " WHERE recibo= " + i + " and serie ='" + serie + "' and catastral<>'';use predialchico";
                    Conexion_a_BD.Ejecutar(cadena4 );
                    archivox.Guardar(cadena, cmbOficina.SelectedValue.ToString (), cmbCajas.SelectedValue.ToString(), DateTime.Now.ToString("yyyyMMdd"));
                    archivox.Guardar(cadena2, cmbOficina.SelectedValue.ToString(), cmbCajas.SelectedValue.ToString(), DateTime.Now.ToString("yyyyMMdd"));
                    archivox.Guardar(cadena3, cmbOficina.SelectedValue.ToString(), cmbCajas.SelectedValue.ToString(), DateTime.Now.ToString("yyyyMMdd"));
                    archivox.Guardar(cadena4, cmbOficina.SelectedValue.ToString(), cmbCajas.SelectedValue.ToString(), DateTime.Now.ToString("yyyyMMdd"));

                }


            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message );
            }
            this.recibomaestroTableAdapter.Fillfechaycaja(predialchicoDataSet.recibomaestro, dtinicio.Value, dtfinal.Value, cmbOficina.SelectedValue.ToString(), cmbCajas.SelectedValue.ToString());
            dataGridView1.Refresh();
            btnrenumerar.Enabled = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DialogResult Result;
            Result = MessageBox.Show("¿Estas seguro?", "Cuidado!!!", MessageBoxButtons.OKCancel);
            if (Result == DialogResult.OK)
            {
                

                try
                {
                    string RECIBO = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();  // la 2 es la columna de folio
                    string SERIE = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[10].Value.ToString(); 
                    Conexion_a_BD.Conectar();
                    string cadena = "UPDATE RECIBOMAESTRO SET FACTURADO=1 WHERE FOLIO= " + RECIBO + " and serie ='" + SERIE + "'";
                    Conexion_a_BD.Ejecutar(cadena);
                    Conexion_a_BD.Desconectar();
                  

                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
                this.recibomaestroTableAdapter.Fillfechaycaja(predialchicoDataSet.recibomaestro, dtinicio.Value, dtfinal.Value, cmbOficina.SelectedValue.ToString(), cmbCajas.SelectedValue.ToString());
                dataGridView1.Refresh();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult Result;
            Result = MessageBox.Show("¿Estas seguro?", "Cuidado!!!", MessageBoxButtons.OKCancel);
            if (Result == DialogResult.OK)
            {


                try
                {
                    string RECIBO = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();  // la 2 es la columna de folio
                    string SERIE = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[10].Value.ToString();
                    Conexion_a_BD.Conectar();
                    string cadena = "UPDATE RECIBOMAESTRO SET FACTURADO=0 WHERE FOLIO= " + RECIBO + " and serie ='" + SERIE + "'";
                    Conexion_a_BD.Ejecutar(cadena);
                    Conexion_a_BD.Desconectar();


                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
                this.recibomaestroTableAdapter.Fillfechaycaja(predialchicoDataSet.recibomaestro, dtinicio.Value, dtfinal.Value, cmbOficina.SelectedValue.ToString(), cmbCajas.SelectedValue.ToString());
                dataGridView1.Refresh();
            }
        }
    }
}
