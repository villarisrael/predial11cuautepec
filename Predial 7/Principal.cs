using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Predial10.caja;
using Predial10.Recaudacion;
using Predial10.Resources.CODE;

namespace Predial10
{
    public partial class Principal : DevComponents.DotNetBar.Office2007Form
    {
        DataTable TBL_Consulta = new DataTable();
        string estado = "";
        public string usuario = "";

        public Principal()
        {
            InitializeComponent();
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            
            if (superTabControl.Visible  == true && Dgridusuario.Visible == true)
            {
                if (Dgridusuario.CurrentRow.Index < 0)
                {
                    MessageBox.Show("No seleccionaeste un usuario");
                }
                string cuenta="";
                cuenta = Dgridusuario.CurrentRow.Cells["catastral"].Value.ToString();
                Contratos contrato = new Contratos();
                contrato.cuenta  = cuenta;
                contrato.Modo = "Visualizar";
           //     contrato.MdiParent = this;
                contrato.ShowDialog ();
            //    superTabControl.Visible = false;                             
                return;

            }
            if (superTabControl.Visible == false)
            {
                // MessageBox.Show("Presiona la pestaña de padron de usuarios");
                ribbonTabItem1_Click(sender,e);
                return;
                
            }
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
           confempresas xform= new confempresas();
            xform.MdiParent =this;
            xform.Show();
        }

       

        private void ribbonTabItem1_Click(object sender, EventArgs e)
        {
            
            llenadatos();

        }

        private void ribbonTabItem3_Click(object sender, EventArgs e)
        {
            superTabControl.Visible = false;
        }

        private void ribbonTabItem4_Click(object sender, EventArgs e)
        {
            superTabControl.Visible = false;
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
           // superTabControl.Visible = false;          

            Contratos contrato = new Contratos();
            //contrato.MdiParent = this;      
            contrato.Show();
        }

        private void btnmodifcar_Click(object sender, EventArgs e)
        {
            if (superTabControl.Visible == true && Dgridusuario.Visible == true)
            {
                if (Dgridusuario.CurrentRow.Index < 0)
                {
                    MessageBox.Show("No seleccionaeste un usuario");
                }
                string cuenta = "";
                cuenta = Dgridusuario.CurrentRow.Cells["catastral"].Value.ToString();
                Contratos contrato = new Contratos();
                contrato.cuenta = cuenta;
                contrato.Modo = "Modificar";
           //     contrato.MdiParent = this;
                contrato.ShowDialog ();
            //    superTabControl.Visible = false;                
                return;

            }
            if (superTabControl.Visible == false)
            {
                // MessageBox.Show("Presiona la pestaña de padron de usuarios");
                ribbonTabItem1_Click(sender, e);
                return;

            }
        }

        private void btnrestaurar_Click(object sender, EventArgs e)
        {
            
                // MessageBox.Show("Presiona la pestaña de padron de usuarios");
                ribbonTabItem1_Click(sender, e);
                return;

            
        }

        private void btnCatalogos_Click(object sender, EventArgs e)
        {
            Catalogos.Catalogos catalogos = new Catalogos.Catalogos();
            catalogos.MdiParent = this;
            catalogos.Show();
        }

        private void ribbonTabItem5_Click(object sender, EventArgs e)
        {
            superTabControl.Visible = false;
        }

        private void ribbonTabItem6_Click(object sender, EventArgs e)
        {
            superTabControl.Visible = false;
        }

        private void btnCalculaAnos_Click(object sender, EventArgs e)
        {
            superTabControl.Visible = false;

          //  configuracion.Calcula_anos c_anos = new configuracion.Calcula_anos();
            //c_anos.MdiParent = this;      
         //   c_anos.Show();

        }

        private void btncaja_Click(object sender, EventArgs e)
        {
            
        }

        private void btncierre_Click(object sender, EventArgs e)
        {
            Facturacion.frmcierre frmc = new Facturacion.frmcierre();
            frmc.MdiParent = this;
            frmc.Show();
        }

        private void btnlistado_Click(object sender, EventArgs e)
        {
            PadronUsuarios.frmlistado lis  = new PadronUsuarios.frmlistado ();
        
            lis.Show();
        }

        private void buttonItem13_Click(object sender, EventArgs e)
        {
            PadronUsuarios.frmrequerimiento reque = new PadronUsuarios.frmrequerimiento();
            reque.Show();

        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            PadronUsuarios.frmaviso avi = new PadronUsuarios.frmaviso();
            avi.Show();
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            if (superTabControl.Visible == true && Dgridusuario.Visible == true)
            {
                if (Dgridusuario.CurrentRow.Index < 0)
                {
                    MessageBox.Show("No seleccionaeste un usuario");
                }
                string cuenta = "";
                cuenta = Dgridusuario.CurrentRow.Cells["catastral"].Value.ToString();
                PadronUsuarios.CambioTarifa CambioTarifa = new PadronUsuarios.CambioTarifa();
                CambioTarifa.cuenta = cuenta;
                CambioTarifa.Modo = "Insertar";
           //     CambioTarifa.MdiParent = this;
                CambioTarifa.ShowDialog ();
             //   superTabControl.Visible = false;              
                return;

            }
            if (superTabControl.Visible == false)
            {
                ribbonTabItem1_Click(sender, e);
                return;
            }        
        }

        private void buttonItem10_Click(object sender, EventArgs e)
        {
            if (superTabControl.Visible == true && Dgridusuario.Visible == true)
            {
                if (Dgridusuario.CurrentRow.Index < 0)
                {
                    MessageBox.Show("No seleccionaeste un usuario");
                }
                string cuenta = "";
                cuenta = Dgridusuario.CurrentRow.Cells["catastral"].Value.ToString();
                PadronUsuarios.Traslado Traslado = new PadronUsuarios.Traslado();
                Traslado.cuenta = cuenta;
                Traslado.Modo = "Insertar";
              //  Traslado.MdiParent = this;
                Traslado.ShowDialog ();
           //     superTabControl.Visible = false;                
                return;

            }
            if (superTabControl.Visible == false)
            {
                ribbonTabItem1_Click(sender, e);
                return;
            }        

        }

        private void buttonItem11_Click(object sender, EventArgs e)
        {
            if (superTabControl.Visible == true && Dgridusuario.Visible == true)
            {
                if (Dgridusuario.CurrentRow.Index < 0)
                {
                    MessageBox.Show("No seleccionaeste un usuario");
                }
                string cuenta = "";
                cuenta = Dgridusuario.CurrentRow.Cells["catastral"].Value.ToString();
                PadronUsuarios.CambioValorCatastral CVC = new PadronUsuarios.CambioValorCatastral();
                CVC.cuenta = cuenta;
                CVC.Modo = "Insertar";
           //     CVC.MdiParent = this;
                CVC.ShowDialog ();
             //   superTabControl.Visible = false;               
                return;

            }
            if (superTabControl.Visible == false)
            {
                ribbonTabItem1_Click(sender, e);
                return;
            }        

        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            if (superTabControl.Visible == true && Dgridusuario.Visible == true)
            {
                if (Dgridusuario.CurrentRow.Index < 0)
                {
                    MessageBox.Show("No seleccionaeste un usuario");
                }
                string cuenta = "";
                cuenta = Dgridusuario.CurrentRow.Cells["clave"].Value.ToString();
                PadronUsuarios.BajaUsuario Baja = new PadronUsuarios.BajaUsuario();
                Baja.cuenta = cuenta;
                Baja.Modo = "Baja";
                //     CVC.MdiParent = this;
                Baja.ShowDialog();
                //   superTabControl.Visible = false;               
                return;
            }
            if (superTabControl.Visible == false)
            {
                ribbonTabItem1_Click(sender, e);
                return;
            }

        }

        private void buttonItem12_Click(object sender, EventArgs e)
        {
            if (superTabControl.Visible == true && Dgridusuario.Visible == true)
            {
                if (Dgridusuario.CurrentRow.Index < 0)
                {
                    MessageBox.Show("No seleccionaeste un usuario");
                }
                string mens = "";                
                mens = "Introduzca el campo: " + Dgridusuario.Columns[ Dgridusuario.CurrentCell.ColumnIndex ].Name ;
 
                Predial10.PadronUsuarios.BuscarUsuario BUsuarios = new PadronUsuarios.BuscarUsuario(Dgridusuario.Columns[Dgridusuario.CurrentCell.ColumnIndex ].DataPropertyName , mens, Dgridusuario[Dgridusuario.CurrentCell.ColumnIndex , Dgridusuario.CurrentRow.Index ].Value, Dgridusuario  ) ;
                BUsuarios.Show();
                // return;

            }
            if (superTabControl.Visible == false)
            {
                // MessageBox.Show("Presiona la pestaña de padron de usuarios");
                ribbonTabItem1_Click(sender, e);
                return;

            }
        }

        

        private void buttonItem17_Click(object sender, EventArgs e)
        {
            Conexion_a_BD.Conectar();

            TBL_Consulta = Conexion_a_BD.Consultasql("STATUSA", "croape WHERE MAQUINA= '" + System.Environment.MachineName.ToString() + "' AND FEC_APE='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
            Conexion_a_BD.Desconectar();
            var results = from myRow in TBL_Consulta.AsEnumerable() select myRow;
            try
            {
                DataView view = results.AsDataView();
                estado = view[0]["STATUSA"].ToString();


            }
            catch (Exception x)
            {
            }

            if (estado == "A")
            {
                Predial10.frmcaja x = new frmcaja();
                x.usuariosis = usuario;
                x.Show();
            }
            else
            {
                MessageBox.Show("Primero debes abrir una caja","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {
            Conexion_a_BD.Conectar();

            TBL_Consulta = Conexion_a_BD.Consultasql("STATUSA", "croape WHERE MAQUINA= '" + System.Environment.MachineName.ToString() + "' AND FEC_APE='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
            Conexion_a_BD.Desconectar();
            var results = from myRow in TBL_Consulta.AsEnumerable() select myRow;
            try
            {
                DataView view = results.AsDataView();
                estado = view[0]["STATUSA"].ToString();
            }
            catch (Exception x)
            {
            }

            if (estado == "A")
            {
                caja.CierreCaja Cierre = new caja.CierreCaja();
                Cierre.MdiParent = this;
                Cierre.Show();
            }
            else
            {
                MessageBox.Show("Primero debes abrir una caja", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            Recaudacion.frmrecaudacion frmreca = new Recaudacion.frmrecaudacion();
            frmreca.Text = "Reporte de Recaudacion";
            frmreca.ShowDialog();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            Recaudacion.frmrecaudacion frmreca = new Recaudacion.frmrecaudacion();
            frmreca.Text = "Reporte de total de rubros";
            frmreca.tipo = "Rubros";
            frmreca.ShowDialog();
        }

        private void btnliscomunidades_Click(object sender, EventArgs e)
        {
            RepAdeudoComu repo = new RepAdeudoComu();
            repo.CrearReporte();

        }

        private void btnexpediente_Click(object sender, EventArgs e)
        {
            if (superTabControl.Visible == true && Dgridusuario.Visible == true)
            {
                if (Dgridusuario.CurrentRow.Index < 0)
                {
                    MessageBox.Show("No seleccionaeste un usuario");
                }
                string cuenta = "";
                cuenta = Dgridusuario.CurrentRow.Cells["catastral"].Value.ToString();
                PadronUsuarios.frmexpediente  expediente = new PadronUsuarios.frmexpediente ();
                expediente.cuenta = cuenta;
                expediente.ShowDialog();
                return;
        }

        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            Predial10.configuracion.frmaccesos  usu = new Predial10.configuracion.frmaccesos ();
            usu.Show();
        }

        private void ribbonBar18_ItemClick(object sender, EventArgs e)
        {

        }

        private void buttonItem3_Click_1(object sender, EventArgs e)
        {
            Conexion_a_BD.Conectar();

            TBL_Consulta = Conexion_a_BD.Consultasql("STATUSA", "croape WHERE MAQUINA= '" + System.Environment.MachineName.ToString() + "' AND FEC_APE='" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
            Conexion_a_BD.Desconectar();
            var results = from myRow in TBL_Consulta.AsEnumerable() select myRow;
            try
            {
                DataView view = results.AsDataView();
                estado = view[0]["STATUSA"].ToString();


            }
            catch (Exception x)
            {
            }

            if (estado == "C" || estado == "")
            {
                caja.AperturaCaja Apertura = new caja.AperturaCaja();
                Apertura.MdiParent = this;
                Apertura.Show();
            }
            else
            {
                MessageBox.Show("Ya existe una caja abierta, necesita cerrarla para poder abrir otra.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btncalculadora2_Click(object sender, EventArgs e)
        {
            frmcalculadora xform = new frmcalculadora();
            xform.MdiParent = this;
            xform.Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            llenadatos();
        }

        private void Principal_Close(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void llenadatos()
        {
            superTabControl.Visible = true;
            Conexion_a_BD.Conectar();
            DataTable tablausuario = new DataTable();

            tablausuario = Conexion_a_BD.Consultasqlpagina("clave,Catastral, Nombre,Domicilio,Comunidad", "vusuario", "cuenta", "0,30");

            this.Dgridusuario.DataSource = tablausuario;
            Conexion_a_BD.Desconectar();
            Dgridusuario.Columns[1].Width = 200;
            Dgridusuario.Columns[2].Width = 200;
            Dgridusuario.Columns[3].Width = 200;

            Dgridusuario.Visible = true;

        

            


        }

        private void btnREcibo_Click(object sender, EventArgs e)
        {
            Predial10.configuracion.frmconfigurar x = new Predial10.configuracion.frmconfigurar();
            x.ShowDialog();
        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {
            Predial10.caja.Listarecibos li = new Predial10.caja.Listarecibos();
            li.Show();
        }

        private void ribbonBar24_ItemClick(object sender, EventArgs e)
        {

        }

        private void btnfacturadia_Click(object sender, EventArgs e)
        {
         
        }

        private void btningresoportarifa_Click(object sender, EventArgs e)
        {
            PadronUsuarios.Frmreprectar rep = new PadronUsuarios.Frmreprectar();
            rep.Show();
        }

        private void btningresoporcomunidad_Click(object sender, EventArgs e)
        {
            FrmResumen rep = new FrmResumen();
           
            rep.Show();
        }

        private void btncomptar_Click(object sender, EventArgs e)
        {
            Predial10.PadronUsuarios.frmreportcomp rep = new Predial10.PadronUsuarios.frmreportcomp();
            rep.Show();
        }

        private void btnreporteagrpred_Click(object sender, EventArgs e)
        {
            Predial10.PadronUsuarios.Frmreppreagr preagrtar = new Predial10.PadronUsuarios.Frmreppreagr();
            preagrtar.Show();
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            Predial10.Recaudacion.FrmIngranuales frmanu = new Predial10.Recaudacion.FrmIngranuales();
            frmanu.Show();
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            caja.FrmFacturadeldia fd = new caja.FrmFacturadeldia();
            fd.Show();
        }

        private void btnlistarfacturas_Click(object sender, EventArgs e)
        {
            frmlistadofacturas X = new frmlistadofacturas();
            X.Show();
        }

        private void rbFacturas_Click(object sender, EventArgs e)
        {
            superTabControl.Visible = false;
        }

        private void buttonItem17_Click_1(object sender, EventArgs e)
        {
            string Date = DateTime.Now.ToString("dd-MM-yyyy");
            //Exportar Padrón de Uusarios a Excel

            //string ConsultaSql = "select * from usuario";
            //string cadenaSQl = string.Empty;

            //var elementos = Conexion_a_BD(ConsultaSql).ToList();
            try
            {
                var elementos2 = Conexion_a_BD.Consultasql("*", "vusuario");


                List<DataRow> PadronList = elementos2.Rows.Cast<DataRow>().ToList();


                //List<var> studentDetails = new List<var>();
                //studentDetails = ConvertDataTable<Student>(dt);

                string renglon = string.Empty;
                renglon = "CUENTA, id_comunidad, NOMBRE, id_colonia, id_calle, cod_gir, estadopredio, cp, rfc, NMunicipio, fechaalta, ID_TIPO_USUARIO, sector,  telefono, clave_predial, NivelEconomico, EscrituraNo, FechaActa, NotarioNo, Representantelegal, DomicilioAudiencia, Gestion_cobranza_P, Servicio_Agua_P, id_Tarifa_P, Estado_P, Valor_Fiscal_P, NombrePredio_P, TipoIdentificacion, MILLAR, UltimoPagoP, Adeudo_P, Recargos_p, Periodos_p, TotalAdeudo_p, clave, DOMICILIO, superficie, superficiec \n";

                renglon = "Clave, Cuenta, catastral, Nombre, domicilio, comunidad, colonia, id_colonia, Calle, id_calle, numext, numint, valor_fiscal, Giro, estadopredio, cp, rfc, Municipio, fechaalta, Estado, Tarifa, lote, manzana, sector, id_comunidad, idTarifa, DirUbi, DirFis, Ubicacion, UltimoPagop, Adeudo_p, Recargos_p, periodos_p, Totaladeudo_p, Tipopredio, Claveusu, Estado_p \n";
                
                //foreach (var Ele in PadronList)
                //{

                //    renglon += Ele. + "," + Ele.Serie + "," + Ele.Numero + "," + Ele.Nombre_cliente.Replace(",", " ") + "," + Ele.Subtotal + "," + Ele.IVA + "," + Ele.Total + "," + Ele.Moneda + "," + Ele.TC + "," + Ele.pagada + "," + Ele.UUID + "," + Ele.Estado + "," + Ele.IDMetododepago + "\n";
                //}

                foreach (DataRow row in elementos2.Rows)
                {
                    renglon += row["Clave"].ToString() + "," + row["Cuenta"].ToString() + "," + row["catastral"].ToString() + "," + row["Nombre"].ToString() + "," + row["domicilio"].ToString() + "," + row["comunidad"].ToString() + "," + row["colonia"].ToString() + "," + row["id_colonia"].ToString() + "," + row["Calle"].ToString() + "," + row["id_calle"].ToString() + "," + row["numext"].ToString() + "," + row["numint"].ToString() + "," + row["valor_fiscal"].ToString() + "," + row["Giro"].ToString() + "," + row["estadopredio"].ToString() + "," + row["cp"].ToString() + "," + row["rfc"].ToString() + "," + row["Municipio"].ToString() + "," + row["fechaalta"].ToString() + "," + row["Estado"].ToString() + "," + row["Tarifa"].ToString() + "," + row["lote"].ToString() + "," + row["manzana"].ToString() + "," + row["sector"].ToString() + "," + row["id_comunidad"].ToString() + "," + row["idTarifa"].ToString() + "," + row["DirUbi"].ToString() + "," + row["DirFis"].ToString() + "," + row["UltimoPagop"].ToString() + "," + row["Adeudo_p"].ToString() + "," + row["Recargos_p"].ToString() + "," + row["periodos_p"].ToString() + "," + row["Totaladeudo_p"].ToString() + "," + row["Tipopredio"].ToString() + "," + row["Claveusu"].ToString() + "," + row["Estado_p"].ToString() + "\n";

                    //renglon += row["CUENTA"].ToString();


                }

                if (renglon != string.Empty)
                {
                    renglon = renglon.TrimEnd('\n');  // le quita el enter
                }


                //Guardar el documento de excel
                String Cadenapdf = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ReportesPadron\\").Trim();
                if (!Directory.Exists(Cadenapdf))
                {

                    DirectoryInfo di = Directory.CreateDirectory(Cadenapdf);

                }



                String PadronExcel = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ReportesPadron\\Padron__" + Date + ".csv").Trim();

                //FileStream fs = File.Create(PadronExcel);


                //var info = new MemoryStream(Encoding.UTF8.GetBytes(renglon));
                //fs.Write(info, 0, info.Length);


                var stream = new MemoryStream(Encoding.UTF8.GetBytes(renglon));

                File.WriteAllText(PadronExcel, renglon.ToString());
            }

            catch (Exception err)
            {

                //FileStream fs1 = File.Create(stream);
                //File(stream, "text/plain", "Listado de Facturas.csv");
                MessageBox.Show(err.ToString());
            }


        }

        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}
