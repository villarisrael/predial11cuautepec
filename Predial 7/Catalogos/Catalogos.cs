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
    public partial class Catalogos : DevComponents.DotNetBar.Office2007Form
    {
        public Catalogos()
        {
            InitializeComponent();
        }

        private void Catalogos_Load(object sender, EventArgs e)
        {
            SetFontAndColors();

        }

        private void SetFontAndColors()
        {
            this.Dtgdatos.DefaultCellStyle.Font = new Font("Biondi", 12);
            this.Dtgdatos.DefaultCellStyle.SelectionForeColor = Color.SkyBlue;
            this.Dtgdatos.DefaultCellStyle.ForeColor = Color.Black;
            //this.Dtgdatos.DefaultCellStyle.BackColor = Color.SlateGray;
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            try
            {
                String idcalle = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[0].Value.ToString());
                String calle = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[1].Value.ToString());
                Frmcalles fc = new Frmcalles(this);
                fc.txtidcalle.Text = idcalle;
                fc.txtnombre.Text = calle;
                fc.txtidcalle.ReadOnly = true;
                fc.Modo = "Actualizar";
                fc.Show();


            }
            catch (Exception ex1)
            {
                MessageBox.Show("No has seleccionado ninguna fila");
            }
        }

        public void llenacalles()//
        {
            try
            {
                Conexion_a_BD.Conectar();
                DataTable tabladedatos = Conexion_a_BD.consultaTable("Select id_Calle as Id, Nombre As Calle from calles ");
                Dtgdatos.DataSource = tabladedatos;
                Conexion_a_BD.Desconectar();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public void llenacolonias()
        {
            try{
            Conexion_a_BD.Conectar();

            DataTable tabladedatos = Conexion_a_BD.consultaTable("Select id_colonia As ID, colonia As Colonia from colonia ");
            Dtgdatos.DataSource = tabladedatos;
            Conexion_a_BD.Desconectar();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public void llenacomunidades()
        {
            try{
            Conexion_a_BD.Conectar();
            DataTable tabladedatos = Conexion_a_BD.consultaTable("Select id_comunidad as ID, comunidad as Comunidad from comunidades ");
            Dtgdatos.DataSource = tabladedatos;
            Conexion_a_BD.Desconectar();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public void llenaregiones()
        {
            try
            {
                Conexion_a_BD.Conectar();
                DataTable tabladedatos = Conexion_a_BD.consultaTable("Select id_region as ID, region as Region from Region ");
                Dtgdatos.DataSource = tabladedatos;
                Conexion_a_BD.Desconectar();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public void llenafraccs()
        {
            try{
            Conexion_a_BD.Conectar();
            DataTable tabladedatos = Conexion_a_BD.consultaTable("Select * from fracc ");
            Dtgdatos.DataSource = tabladedatos;
            Conexion_a_BD.Desconectar();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public void llenamunicipios()
        {
            try{
            Conexion_a_BD. Conectar();
            DataTable tabladedatos = Conexion_a_BD.consultaTable("Select Clave as Id, Nombre as Municipio from municipios ");
            Dtgdatos.DataSource = tabladedatos;
            Conexion_a_BD.Desconectar();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public void llenasectores()
        {
            try{
            Conexion_a_BD. Conectar();
            DataTable tabladedatos =Conexion_a_BD.consultaTable("Select clavesec as Id, descripcion as Sector from sectores ");
            Dtgdatos.DataSource = tabladedatos;
            Conexion_a_BD.Desconectar();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void buttonItem20_Click(object sender, EventArgs e)
        {
            llenasectores();
        }

        private void buttonItem12_Click(object sender, EventArgs e)
        {
            llenamunicipios();
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            llenacomunidades();
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            llenacolonias();
        }

        private void btnVerCalles_Click(object sender, EventArgs e)
        {
            llenacalles();
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            llenaregiones();
        }

        private void btnagregarcalle_Click(object sender, EventArgs e)
        {
            llenacalles();
            Frmcalles fcalle = new Frmcalles(this);
            fcalle.ShowDialog();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            llenacolonias();
            Frmcol fcol = new Frmcol(this);
            fcol.ShowDialog();
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            llenacomunidades();
            Frmcmndd fcom = new Frmcmndd(this);
            fcom.ShowDialog();
        }

        private void btnagremunicipios_Click(object sender, EventArgs e)
        {
            llenamunicipios();
            Frmmuni fm = new Frmmuni(this);
            fm.ShowDialog();
        }

        private void btnagrregiones_Click(object sender, EventArgs e)
        {
            llenaregiones();
            frmregiones fr= new frmregiones(this);
            fr.Show();
        }

        private void buttonItem17_Click(object sender, EventArgs e)
        {
            llenasectores();
            Frmsector fs = new Frmsector(this);
            fs.ShowDialog();
        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {
            try
            {
                String idsec = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[0].Value.ToString());
                String sec = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[1].Value.ToString());
                Frmsector ff = new Frmsector(this);
                ff.Txtidsector.Text = idsec;
                ff.Txtnombre.Text = sec;
                ff.Txtidsector.ReadOnly = true;
                ff.Modo = "Actualizar";
                ff.Show();


            }
            catch (Exception ex1)
            {
                MessageBox.Show("No has seleccionado ninguna fila");
            }
        }

        private void btneditmunicipios_Click(object sender, EventArgs e)
        {
            try
            {
                String idmuni = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[0].Value.ToString());
                String muni = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[1].Value.ToString());
                Frmmuni ff = new Frmmuni(this);
                ff.Txtidmunicipio.Text = idmuni;
                ff.Txtnombre.Text = muni;
                ff.Txtidmunicipio.ReadOnly = true;
                ff.Modo = "Actualizar";
                ff.Show();


            }
            catch (Exception ex1)
            {
                MessageBox.Show("No has seleccionado ninguna fila");
            }
        }

        private void btneditcomunidades_Click(object sender, EventArgs e)
        {
            try
            {
                String idcomunidad = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[0].Value.ToString());
                String comunidad = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[1].Value.ToString());
                Frmcmndd fc = new Frmcmndd(this);
                fc.Txtidcomunidad.Text = idcomunidad;
                fc.Txtnombre.Text = comunidad;
                fc.Txtidcomunidad.ReadOnly = true;
                fc.Modo = "Actualizar";
                fc.Show();


            }
            catch (Exception ex1)
            {
                MessageBox.Show("No has seleccionado ninguna fila");
            }
        }

        private void btneditcolonias_Click(object sender, EventArgs e)
        {
            try
            {
                String idcolonia = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[0].Value.ToString());
                String colonia = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[1].Value.ToString());
                Frmcol fc = new Frmcol(this);
                fc.txtidcolonia.Text = idcolonia;
                fc.txtnombre.Text = colonia;
                fc.txtidcolonia.ReadOnly = true;
                fc.Modo = "Actualizar";
                fc.Show();


            }
            catch (Exception ex1)
            {
                MessageBox.Show("No has seleccionado ninguna fila");
            }
        }

        private void BTNeditregiones_Click(object sender, EventArgs e)
        {
            try
         {
            String idregion = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[0].Value.ToString());
            String region = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[1].Value.ToString());
            frmregiones fc = new frmregiones(this);
            fc.Txtidregion.Text = idregion;
            fc.Txtnombre.Text = region;
            fc.Txtidregion.ReadOnly = true;
            fc.Modo = "Actualizar";
            fc.Show();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("No has seleccionado ninguna fila");
            }
        }

        private void btnborrarcalle_Click(object sender, EventArgs e)
        {
            try
            {
                String idcalle = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[0].Value.ToString());
                //Conexion_a_BD Conexion_a_BD = new Conexion_a_BD();
                Conexion_a_BD.Conectar();
                DialogResult dialogResult = MessageBox.Show("¿Estas Seguro?", "Cuidado!!!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Conexion_a_BD.Ejecutar("DELETE FROM calles where Id_calle='" + idcalle + "'");
                    llenacalles();
                }
                Conexion_a_BD.Desconectar();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("No has seleccionado ninguna fila");
            }
        }

        private void btnborrarcolonia_Click(object sender, EventArgs e)
        {
            try
            {
                String idcolonia = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[0].Value.ToString());
                //Conexion_a_BD Conexion_a_BD = new Conexion_a_BD();
                Conexion_a_BD.Conectar();
                DialogResult dialogResult = MessageBox.Show("¿Estas Seguro?", "Cuidado!!!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Conexion_a_BD.Ejecutar("DELETE FROM colonia where Id_colonia='" + idcolonia + "'");
                    llenacolonias();
                }
            }
            catch (Exception ex1)
            {
                MessageBox.Show("No has seleccionado ninguna fila");
            }
        }

        private void btnborracomunidades_Click(object sender, EventArgs e)
        {
            try
            {
                String idcomunidad = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[0].Value.ToString());
                //Conexion_a_BD Conexion_a_BD = new Conexion_a_BD();
                Conexion_a_BD.Conectar();
                DialogResult dialogResult = MessageBox.Show("¿Estas Seguro?", "Cuidado!!!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                   Conexion_a_BD.Ejecutar("DELETE FROM comunidades where Id_comunidad='" + idcomunidad + "'");
                    llenacomunidades();
                }
                Conexion_a_BD.Desconectar();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("No has seleccionado ninguna fila");
            }
        }

        private void btnborramunicipio_Click(object sender, EventArgs e)
        {
            try
            {
                String idmuni = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[0].Value.ToString());
                //Conexion_a_BD Conexion_a_BD = new Conexion_a_BD();
                Conexion_a_BD.Conectar();
                DialogResult dialogResult = MessageBox.Show("¿Estas Seguro?", "Cuidado!!!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                   Conexion_a_BD.Ejecutar("DELETE FROM municipios where clave='" + idmuni + "'");
                    llenamunicipios();
                }
                Conexion_a_BD.Desconectar();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("No has seleccionado ninguna fila");
            }
        }

        private void btnborrarsectores_Click(object sender, EventArgs e)
        {
            try
            {
                String idsec = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[0].Value.ToString());
                //Conexion_a_BD Conexion_a_BD = new Conexion_a_BD();
                Conexion_a_BD.Conectar();
                DialogResult dialogResult = MessageBox.Show("¿Estas Seguro?", "Cuidado!!!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Conexion_a_BD.Ejecutar("DELETE FROM sectores where clavesec='" + idsec + "'");
                    llenasectores();
                }
                Conexion_a_BD.Desconectar();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("No has seleccionado ninguna fila");
            }
        }

        private void btnborrarregion_Click(object sender, EventArgs e)
        {
            try
            {
                String idsec = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[0].Value.ToString());
                //Conexion_a_BD Conexion_a_BD = new Conexion_a_BD();
                Conexion_a_BD.Conectar();
                DialogResult dialogResult = MessageBox.Show("¿Estas Seguro?", "Cuidado!!!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Conexion_a_BD.Ejecutar("DELETE FROM region where id_region='" + idsec + "'");
                    llenaregiones();
                }
                Conexion_a_BD.Desconectar();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("No has seleccionado ninguna fila");
            }
        }

        private void btnllenagiros_Click(object sender, EventArgs e)
        {

            llenagiros();
        }

        public void llenagiros()
        {
            try
            {
                Conexion_a_BD.Conectar();
                DataTable tabladedatos = Conexion_a_BD.consultaTable("Select codgir as Id, Descripcion  from giro ");
                Dtgdatos.DataSource = tabladedatos;
                Conexion_a_BD.Desconectar();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btneditgiros_Click(object sender, EventArgs e)
        {
            try
            {
                String codgir = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[0].Value.ToString());
                String descripcion = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[1].Value.ToString());
                frmgiro fc = new frmgiro(this);
                fc.txtidgiro.Text = codgir;
                fc.txtnombre.Text = descripcion;
                fc.txtidgiro.ReadOnly = true;
                fc.Modo = "Actualizar";
                fc.Show();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("No has seleccionado ninguna fila");
            }
        }

        private void btnelimgiros_Click(object sender, EventArgs e)
        {
            try
            {
                String idsec = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[0].Value.ToString());
                //Conexion_a_BD Conexion_a_BD = new Conexion_a_BD();
                Conexion_a_BD.Conectar();
                DialogResult dialogResult = MessageBox.Show("¿Estas Seguro?", "Cuidado!!!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Conexion_a_BD.Ejecutar("DELETE FROM giro where codgir='" + idsec + "'");
                    llenagiros();
                }
                Conexion_a_BD.Desconectar();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("No has seleccionado ninguna fila");
            }
        }

        private void btnllenapredio_Click(object sender, EventArgs e)
        {
            llenaestadopredio();
        }

        public void llenaestadopredio()
        {
            try
            {
                Conexion_a_BD.Conectar();
                DataTable tabladedatos = Conexion_a_BD.consultaTable("Select idestado_predio as Id, Descripcion  from estado_predio ");
                Dtgdatos.DataSource = tabladedatos;
                Conexion_a_BD.Desconectar();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnagrestpredio_Click(object sender, EventArgs e)
        {
            llenaestadopredio();
            frmestadopredio fcol = new frmestadopredio(this);
            fcol.ShowDialog();
        }

        private void btneditestpredio_Click(object sender, EventArgs e)
        {
            try
            {
                String id = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[0].Value.ToString());
                String descripcion = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[1].Value.ToString());
                frmestadopredio fc = new frmestadopredio(this);
                fc.txtidestpredio.Text = id;
                fc.txtnombre.Text = descripcion;
                fc.txtidestpredio.ReadOnly = true;
                fc.Modo = "Actualizar";
                fc.Show();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("No has seleccionado ninguna fila");
            }
        }

        private void btnelimestpredio_Click(object sender, EventArgs e)
        {
            try
            {
                String idsec = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[0].Value.ToString());
                //Conexion_a_BD Conexion_a_BD = new Conexion_a_BD();
                Conexion_a_BD.Conectar();
                DialogResult dialogResult = MessageBox.Show("¿Estas Seguro?", "Cuidado!!!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Conexion_a_BD.Ejecutar("DELETE FROM estado_predio where idestado_predio=" + idsec + "");
                    llenaestadopredio();
                }
                Conexion_a_BD.Desconectar();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("No has seleccionado ninguna fila");
            }
        }

        private void btnediteconomico_Click(object sender, EventArgs e)
        {
            try
            {
                String id = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[0].Value.ToString());
                String descripcion = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[1].Value.ToString());
                frmnivelsocioe fc = new frmnivelsocioe(this);
                fc.txtid.Text = id;
                fc.txtnombre.Text = descripcion;
                fc.txtid.ReadOnly = true;
                fc.Modo = "Actualizar";
                fc.Show();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("No has seleccionado ninguna fila");
            }
        }

        private void btnllenaeconomico_Click(object sender, EventArgs e)
        {
            llenanivelsocioe();
        }

        public void llenanivelsocioe()
        {
            try
            {
                Conexion_a_BD.Conectar();
                DataTable tabladedatos = Conexion_a_BD.consultaTable("Select clave as Id, Descripcion  from nivelsocioe ");
                Dtgdatos.DataSource = tabladedatos;
                Conexion_a_BD.Desconectar();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btneliminareconomico_Click(object sender, EventArgs e)
        {
            try
            {
                String idsec = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[0].Value.ToString());
                //Conexion_a_BD Conexion_a_BD = new Conexion_a_BD();
                Conexion_a_BD.Conectar();
                DialogResult dialogResult = MessageBox.Show("¿Estas Seguro?", "Cuidado!!!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Conexion_a_BD.Ejecutar("DELETE FROM nivelsocioe where clave=" + idsec + "");
                    llenanivelsocioe();
                }
                Conexion_a_BD.Desconectar();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("No has seleccionado ninguna fila");
            }
        }

        private void btnveroficinas_Click(object sender, EventArgs e)
        {
            llenaoficinas();
        }

        public void llenaoficinas()
        {
            try
            {
                Conexion_a_BD.Conectar();
                DataTable tabladedatos = Conexion_a_BD.consultaTable("Select COD_OFI as Id, Nombre as Descripcion  from oficinas order by cod_ofi ");
                Dtgdatos.DataSource = tabladedatos;
                Conexion_a_BD.Desconectar();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnagroficina_Click(object sender, EventArgs e)
        {
            llenaoficinas();
            frmoficinas frm = new frmoficinas(this);
            frm.Show();            
        }

        private void btnborraoficcinas_Click(object sender, EventArgs e)
        {
            try
            {
                String idsec = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[0].Value.ToString());
                //Conexion_a_BD Conexion_a_BD = new Conexion_a_BD();
                Conexion_a_BD.Conectar();
                if (Conexion_a_BD.obtenercampo("select ccodofi from RECIBOMAESTRO where ccodofi='" + idsec + "' limit 1") != "")
                {
                    MessageBox.Show("No puedo eliminar la oficina hay pagos registrados en ella");
                    Conexion_a_BD.Desconectar();
                    return;
                }

                DialogResult dialogResult = MessageBox.Show("¿Estas Seguro?", "Cuidado!!!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Conexion_a_BD.Ejecutar("DELETE FROM oficinas where cod_ofi='" + idsec + "'");
                    llenaoficinas();
                }
                Conexion_a_BD.Desconectar();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("No has seleccionado ninguna fila");
            }
        }

        private void btneditoficina_Click(object sender, EventArgs e)
        {
            try
            {
                String id = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[0].Value.ToString());
                String descripcion = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[1].Value.ToString());
                frmoficinas fc = new frmoficinas(this);
                fc.txtidoficinas.Text = id;
                fc.txtnombre.Text = descripcion;
                fc.txtidoficinas.ReadOnly = true;
                fc.Modo = "Actualizar";
                fc.Show();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("No has seleccionado ninguna fila");
            }
        }

        private void btnllenacaja_Click(object sender, EventArgs e)
        {
            llenacajas();

        }


        public void llenacajas()
    {
            try
            {
                Conexion_a_BD.Conectar();
                DataTable tabladedatos = Conexion_a_BD.consultaTable("select id_caja,descripcion, Oficinas.nombre as Oficinas from cajas,oficinas where cajas.cod_ofi=oficinas.COD_OFI;");
                Dtgdatos.DataSource = tabladedatos;
                Conexion_a_BD.Desconectar();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        
    }

        private void brnagrcaja_Click(object sender, EventArgs e)
        {
            llenacajas();
            frmcaja frm = new frmcaja(this);
            frm.Show();            
        }

        private void btnborrarcaja_Click(object sender, EventArgs e)
        {
            try
            {
               

                String idsec = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[0].Value.ToString());
                //Conexion_a_BD Conexion_a_BD = new Conexion_a_BD();
                Conexion_a_BD.Conectar();
            
                if (Conexion_a_BD.obtenercampo("select caja from recibomaestro where caja='" + idsec + "' limit 1 ") != "")
                {
                    MessageBox.Show("No puedo eliminar caja hay pagos registrados en ella");
                    Conexion_a_BD.Desconectar();
                    return;
                }
                DialogResult dialogResult = MessageBox.Show("¿Estas Seguro?", "Cuidado!!!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Conexion_a_BD.Ejecutar("DELETE FROM cajas where id_caja='" + idsec + "'");
                    llenacajas();
                }
                Conexion_a_BD.Desconectar();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("No has seleccionado ninguna fila");
            }
        }

        private void btneditarcaja_Click(object sender, EventArgs e)
        {
            try
            {
                String id = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[0].Value.ToString());
                String descripcion = (Dtgdatos.Rows[Dtgdatos.CurrentRow.Index].Cells[1].Value.ToString());
                frmcaja fc = new frmcaja(this);
                fc.txtIdCaja.Text = id;
                fc.txtDescripcion.Text = descripcion;
                fc.txtIdCaja.ReadOnly = true;
                fc.Modo = "Actualizar";
                fc.Show();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("No has seleccionado ninguna fila");
            }
        }

        private void btnveroficinas_Click_1(object sender, EventArgs e)
        {
            llenaoficinas();
        }

        private void btnagrgiros_Click(object sender, EventArgs e)
        {
            llenagiros();
            frmgiro frm = new frmgiro(this);
            frm.Show();
        }

        private void btnagreconomico_Click(object sender, EventArgs e)
        {
            llenanivelsocioe();
            frmnivelsocioe frm = new frmnivelsocioe(this);
            frm.Show();
        }
       

      


        
    }
}
