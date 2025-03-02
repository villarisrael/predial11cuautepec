﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using Predial10.Resources.CODE;

namespace Predial10
{
    public partial class Contratos : DevComponents.DotNetBar.Office2007Form
    {
        public String Modo;
        public string cuenta = "";
        string Identificacion = "";

        public Contratos(string _cuenta="" )
        {
            InitializeComponent();
            if (_cuenta == "")
            {
                Modo = "Insertar";
            }
        }

               
        private void Contratos_Load(object sender, EventArgs e)
        {
            Conexion_a_BD.Conectar();           
            cmbTarifas.ValueMember = "idTarifas";
            cmbTarifas.DisplayMember = "Descripcion";
            cmbTarifas.DataSource = Conexion_a_BD.Consultasql ("idTarifas, Descripcion", "tarifas", "Descripcion");
            Conexion_a_BD.Desconectar();

            Conexion_a_BD.Conectar();
            cmbEstadoPredio.ValueMember = "Descripcion";
            cmbEstadoPredio.DisplayMember = "Descripcion";
            cmbEstadoPredio.DataSource = Conexion_a_BD.Consultasql(" Descripcion", "estado_predio", "Descripcion");
            Conexion_a_BD.Desconectar();

            Conexion_a_BD.Conectar();
            cmbMunicipio.ValueMember = "clave";
            cmbMunicipio.DisplayMember = "nombre";
            cmbMunicipio.DataSource = Conexion_a_BD.Consultasql("clave, nombre", "municipios", "nombre");
            Conexion_a_BD.Desconectar();

            Conexion_a_BD.Conectar();
            cmbComunidad.ValueMember = "Id_comunidad";
            cmbComunidad.DisplayMember = "Comunidad";
            cmbComunidad.DataSource = Conexion_a_BD.Consultasql("Id_comunidad ,Comunidad", "comunidades", "Comunidad");
            Conexion_a_BD.Desconectar();

            Conexion_a_BD.Conectar();
            cmbColonia.ValueMember = "id_colonia";
            cmbColonia.DisplayMember = "Colonia";
            cmbColonia.DataSource = Conexion_a_BD.Consultasql(" id_colonia, Colonia", "Colonia", "Colonia");
            Conexion_a_BD.Desconectar();

            Conexion_a_BD.Conectar();
            cmbSector.ValueMember = "claveSec";
            cmbSector.DisplayMember = "descripcion";
            cmbSector.DataSource = Conexion_a_BD.Consultasql("claveSec,descripcion", "Sectores", "descripcion");
            Conexion_a_BD.Desconectar();

            Conexion_a_BD.Conectar();
            cmbGiro.ValueMember = "codgir";
            cmbGiro.DisplayMember = "Descripcion";
            cmbGiro.DataSource = Conexion_a_BD.Consultasql("codgir,Descripcion", "giro","Descripcion");
            Conexion_a_BD.Desconectar();

            Conexion_a_BD.Conectar();
            cmbTipoUs.ValueMember = "ID_TIPO_USUARIO";
            cmbTipoUs.DisplayMember = "Descripcion";
            cmbTipoUs.DataSource = Conexion_a_BD.Consultasql("ID_TIPO_USUARIO, Descripcion", "tipos_usuarios", "Descripcion");
            Conexion_a_BD.Desconectar();

            Conexion_a_BD.Conectar();
            cmbNivelSE.ValueMember = "clave";
            cmbNivelSE.DisplayMember = "Descripcion";
            cmbNivelSE.DataSource = Conexion_a_BD.Consultasql("clave, Descripcion","nivelsocioe","Descripcion");
            Conexion_a_BD.Desconectar();

            Conexion_a_BD.Conectar();
            cmbCalle.ValueMember = "ID_CALLE";
            cmbCalle.DisplayMember = "NOMBRE";
            cmbCalle.DataSource = Conexion_a_BD.Consultasql("ID_CALLE, NOMBRE", "calles", "NOMBRE");
            Conexion_a_BD.Desconectar();

            Conexion_a_BD.Conectar();
            cmbEntreCalle1.ValueMember = "ID_CALLE";
            cmbEntreCalle1.DisplayMember = "NOMBRE";
            cmbEntreCalle1.DataSource = Conexion_a_BD.Consultasql("ID_CALLE, NOMBRE", "calles", "NOMBRE");
            Conexion_a_BD.Desconectar();

            Conexion_a_BD.Conectar();
            cmbEntreCalle2.ValueMember = "ID_CALLE";
            cmbEntreCalle2.DisplayMember = "NOMBRE";
            cmbEntreCalle2.DataSource = Conexion_a_BD.Consultasql("ID_CALLE, NOMBRE", "calles", "NOMBRE");
            Conexion_a_BD.Desconectar();

            Conexion_a_BD.Conectar();
            cmbEntreCalle3.ValueMember = "ID_CALLE";
            cmbEntreCalle3.DisplayMember = "NOMBRE";
            cmbEntreCalle3.DataSource = Conexion_a_BD.Consultasql("ID_CALLE, NOMBRE", "calles", "NOMBRE");
            Conexion_a_BD.Desconectar();

            Conexion_a_BD.Conectar();
            cmbEntreCalle4.ValueMember = "ID_CALLE";
            cmbEntreCalle4.DisplayMember = "NOMBRE";
            cmbEntreCalle4.DataSource = Conexion_a_BD.Consultasql("ID_CALLE, NOMBRE", "calles", "NOMBRE");
            Conexion_a_BD.Desconectar();

            if (Modo == "Insertar")
            {
                dtFecha.Value = DateTime.Now;
                dtFechaActa.Value = DateTime.Now;
            }

            if ((Modo == "Visualizar") || (Modo == "Modificar"))
            {
                cargardatos(cuenta);
            }

            if ((Modo == "Visualizar") )
            {
              rbgrabar.  Visible = false;
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    

        private void chkGestionCobranza_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGestionCobranza.Checked == true)
            {
                chkGestionCobranza.Tag = "1";
            }
            else
            {
                chkGestionCobranza.Tag = "0";
            }
        }

        private void chkServAgua_CheckedChanged(object sender, EventArgs e)
        {
            if (chkServAgua.Checked == true)
            {
                chkServAgua.Tag = "1";
            }
            else
            {
                chkServAgua.Tag = "0";
            }
        }

        private void rdbUbicacionPeriodo_CheckedChanged(object sender, EventArgs e)
        {
            rdbUbicacionPeriodo.Tag = "1";
            rdbDomAudiencia.Tag = "0";
            rdbDomFiscal.Tag = "0";

        }

        private void rdbDomAudiencia_CheckedChanged(object sender, EventArgs e)
        {
            rdbUbicacionPeriodo.Tag = "0";
            rdbDomAudiencia.Tag = "1";
            rdbDomFiscal.Tag = "0";

        }

        private void rdbDomFiscal_CheckedChanged(object sender, EventArgs e)
        {
            rdbUbicacionPeriodo.Tag = "0";
            rdbDomAudiencia.Tag = "0";
            rdbDomFiscal.Tag = "1";

        }


        private void cargardatos(string _cuenta)
        {
            Conexion_a_BD.Conectar();
            DataTable tabla;
            //Modifique la consulta para que busque por clave predial en lugar de cuenta
            tabla = Conexion_a_BD.Consultasql("*", " usuario where clave_predial ='" + _cuenta  +"'", "clave_predial");
            Conexion_a_BD.Desconectar();
            string TipoIdentificacion, DirUbi, DirAu, DirFis, Gis, GestionCobranza, ServicioAgua;
           
            var results = from myRow in tabla.AsEnumerable()
                         
                          select myRow;
            DataView view = results.AsDataView();

            txtClaveCatstral.Text = view[0]["clave_predial"].ToString();
            //txtCuenta.Text = view[0]["CUENTA"].ToString();
            cmbMunicipio.SelectedValue = view[0]["NMunicipio"].ToString();
            cmbComunidad.SelectedValue=view[0]["id_comunidad"].ToString();
            dtFecha.Text = view[0]["fechaalta"].ToString();            
            txtTitular.Text =  view[0]["NOMBRE"].ToString ();
            txtSolicitado.Text = view[0]["solicitadopor"].ToString();
            txtTelefono.Text=view[0]["telefono"].ToString();
            txtParentesco.Text = view[0]["parentesco"].ToString();            
            TipoIdentificacion=view[0]["TipoIdentificacion"].ToString();

            if (TipoIdentificacion == "IFE")
            {
                rdbIFE.Checked = true;
 
            }
            else if (TipoIdentificacion == "Cartilla Militar")
            {
                rdbCartilla.Checked = true;
            }
            else if (TipoIdentificacion == "Pasaporte")
            {
                rdbPasaporte.Checked = true;
            }
            else if (TipoIdentificacion == "Licencia de Manejo")
            {
                rdbLicManejo.Checked = true;
            }
            try
            {
                txtIdentificacion.Text = view[0]["seiden"].ToString();
                txtRFC.Text = view[0]["rfc"].ToString();
                txtdomicilio.Text = view[0]["Domicilio"].ToString();
                cmbCalle.SelectedValue = view[0]["id_calle"].ToString();
                cmbColonia.SelectedValue = view[0]["id_colonia"].ToString();
                txtNumExt.Text = view[0]["numext"].ToString();
                txtNumInt.Text = view[0]["numint"].ToString();
                txtCP.Text = view[0]["cp"].ToString();
                cmbSector.SelectedValue = view[0]["sector"].ToString();
                txtManzana.Text = view[0]["manzana"].ToString();
                txtLote.Text = view[0]["lote"].ToString();
                txtValorFiscal.Text = view[0]["Valor_Fiscal_P"].ToString();
            }
            catch (Exception ex)
            {

            }

            Gis=view[0]["RegGis"].ToString();
            if (Gis == "True")
            {
                lblGis.ForeColor = System.Drawing.Color.Green;
            }
            else if (Gis == "False")
            {
                lblGis.ForeColor = System.Drawing.Color.Red;
            }


            GestionCobranza = view[0]["Gestion_cobranza_P"].ToString();
            ServicioAgua = view[0]["Servicio_Agua_P"].ToString();

            if (GestionCobranza == "1")
            {
                chkGestionCobranza.Checked = true;
 
            }
            else if (GestionCobranza == "0")
            {
                chkGestionCobranza.Checked = false;
            }

            if (ServicioAgua == "1")
            {
                chkServAgua.Checked = true;
            }
            else if (ServicioAgua == "0")
            {
                chkServAgua.Checked = false;
            }         

            cmbTipoUs.SelectedValue = view[0]["ID_TIPO_USUARIO"].ToString();
            cmbGiro.SelectedValue = view[0]["cod_gir"].ToString();
            cmbEstadoPredio.SelectedValue = view[0]["estadopredio"].ToString();
            cmbTarifas.SelectedValue = view[0]["id_Tarifa_P"].ToString();
            cmbNivelSE.SelectedValue = view[0]["NivelEconomico"].ToString();
            DirUbi=view[0]["DirUbi"].ToString();
            DirAu=view[0]["DirAu"].ToString();
            DirFis=view[0]["DirFis"].ToString();

            if (DirUbi=="1")
            {
                rdbUbicacionPeriodo.Checked=true;
            }
            else
                if (DirAu == "1")
            {
               rdbDomAudiencia.Checked = true;
            }
            else
                if (DirFis == "1")
            {
                rdbDomFiscal.Checked = true;
            }
            
            txtReferencias.Text = view[0]["referencias"].ToString();
            try
            {
                cmbEntreCalle1.SelectedValue = view[0]["Entrecalle1"].ToString();
                cmbEntreCalle2.SelectedValue = view[0]["Entrecalle2"].ToString();
                cmbEntreCalle3.SelectedValue = view[0]["Entrecalle3"].ToString();
                cmbEntreCalle4.SelectedValue = view[0]["Entrecalle4"].ToString();
                txtClaveUbicacion.Text = view[0]["Ubicacion"].ToString();
                txtdomicilio.Text = view[0]["Domicilio"].ToString();
                txtObservaciones.Text = view[0]["OBSERVACION"].ToString();
                txtEscrituraNo.Text = view[0]["EscrituraNo"].ToString();
                dtFechaActa.Text = view[0]["FechaActa"].ToString();
                txtNotario.Text = view[0]["NotarioNo"].ToString();
                txtRepresentante.Text = view[0]["Representantelegal"].ToString();
                txtDomAudiencia1.Text = view[0]["DomicilioAudiencia"].ToString();
                txtDomAudiencia2.Text = view[0]["DomicilioAudiencia1"].ToString();
                txtDomAudiencia3.Text = view[0]["DomicilioAudiencia2"].ToString();
                txtPassword.Text = view[0]["password"].ToString();
                txtPregSecret.Text = view[0]["pregsect"].ToString();
                txtRespSecret.Text = view[0]["ressect"].ToString();
                txtEmail.Text = view[0]["email"].ToString();
                txtCopropietario1.Text = view[0]["Copropietario_1_P"].ToString();
                txtCopropietario2.Text = view[0]["Copropietario_2_P"].ToString();
                txtCopropietario3.Text = view[0]["Copropietario_3_P"].ToString();
                txtCopropietario4.Text = view[0]["Copropietario_4_P"].ToString();
                txtCopropietario5.Text = view[0]["Copropietario_5_P"].ToString();
                txtCopropietario6.Text = view[0]["Copropietario_6_P"].ToString();
                txtCopropietario7.Text = view[0]["Copropietario_7_P"].ToString();
                txtCopropietario8.Text = view[0]["Copropietario_8_P"].ToString();
                txtCopropietario9.Text = view[0]["Copropietario_9_P"].ToString();
                txtCopropietario10.Text = view[0]["Copropietario_10_P"].ToString();
                double superficie = 0;
                double.TryParse(view[0]["superficie"].ToString(), out superficie);
                DIsuperficie.Value = superficie ;
                double superficiec=0;
                double.TryParse(view[0]["superficiec"].ToString(), out superficiec);
                DIConstruida.Value = superficiec ;
                dtUFP.Text = view[0]["UltimoPagoP"].ToString();
            }
            catch(Exception err)
            {

            }
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (txtClaveCatstral.Text == "" || txtTitular.Text == "" || txtValorFiscal.Text=="")
            {
                MessageBox.Show("Debes llenar los campos marcados en rojo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    Conexion_a_BD.Conectar();
                    StringBuilder cadena = new StringBuilder();

                    if (Modo == "Insertar")
                    {
                        cadena.Append("INSERT INTO USUARIO SET ");
                        //cadena.Append(" CUENTA ='" + txtCuenta.Text + "',");
                    }
                    if (Modo == "Modificar")
                    {
                        cadena.Append("UPDATE USUARIO SET ");
                    }

                    cadena.Append("id_comunidad = '" + cmbComunidad.SelectedValue + "',");
                    cadena.Append("NOMBRE ='" + txtTitular.Text + "',");
                    cadena.Append("id_colonia ='" + cmbColonia.SelectedValue + "',");
                    cadena.Append("Domicilio ='" + txtdomicilio.Text  + "',");
                    cadena.Append("id_calle ='" + cmbCalle.SelectedValue + "',");
                    cadena.Append("numext='" + txtNumExt.Text + "',");
                    cadena.Append("numint='" + txtNumInt.Text + "',");
                    cadena.Append("cod_gir='" + cmbGiro.SelectedValue + "',");
                    cadena.Append("estadopredio='" + cmbEstadoPredio.SelectedValue + "',");
                    cadena.Append("CP='" + txtCP.Text + "',");
                    cadena.Append("rfc='" + txtRFC.Text + "',");
                    cadena.Append("solicitadopor='" + txtSolicitado.Text + "',");
                    cadena.Append("parentesco='" + txtParentesco.Text + "',");
                    cadena.Append("seiden='" + txtIdentificacion.Text + "',");
                    cadena.Append("NMunicipio='" + cmbMunicipio.SelectedValue + "',");
                    cadena.Append("fechaalta='" + Convert.ToDateTime(dtFecha.Text).ToString("yyyy-MM-dd") + "',");
                    cadena.Append("ID_TIPO_USUARIO='" + cmbTipoUs.SelectedValue + "',");
                    cadena.Append("sector='" + cmbSector.SelectedValue + "',");
                    cadena.Append("manzana='" + txtManzana.Text + "',");
                    cadena.Append("telefono='" + txtTelefono.Text + "',");
                    cadena.Append("lote='" + txtLote.Text + "',");
                    cadena.Append("Ubicacion='" + txtClaveUbicacion.Text + "',");
                    cadena.Append("clave_predial = '" + txtClaveCatstral.Text + "',");
                    cadena.Append("Entrecalle1= '" + cmbEntreCalle1.SelectedValue + "',");
                    cadena.Append("Entrecalle2='" + cmbEntreCalle2.SelectedValue + "',");
                    cadena.Append("Entrecalle3='" + cmbEntreCalle3.SelectedValue + "',");
                    cadena.Append("Entrecalle4='" + cmbEntreCalle4.SelectedValue + "',");                   
                    cadena.Append("OBSERVACION='" + txtObservaciones.Text + "',");
                    cadena.Append("NivelEconomico='" + cmbNivelSE.SelectedValue + "',");
                    cadena.Append("EscrituraNo='" + txtEscrituraNo.Text + "',");
                    cadena.Append("FechaActa='" + Convert.ToDateTime(dtFechaActa.Text).ToString("yyyy-MM-dd") + "',");
                    cadena.Append("NotarioNo='" + txtNotario.Text + "',");
                    cadena.Append("Representantelegal='" + txtRepresentante.Text + "',");
                    cadena.Append("DomicilioAudiencia ='" + txtDomAudiencia1.Text + "',");
                    cadena.Append("DomicilioAudiencia1='" + txtDomAudiencia2.Text + "',");
                    cadena.Append("DomicilioAudiencia2='" + txtDomAudiencia3.Text + "',");
                    cadena.Append("password='" + txtPassword.Text + "',");
                    cadena.Append("pregsect='" + txtPregSecret.Text + "',");
                    cadena.Append("ressect='" + txtRespSecret.Text + "',");
                    cadena.Append("email='" + txtEmail.Text + "',");
                    cadena.Append("referencias='" + txtReferencias.Text + "',");
                    cadena.Append("DirUbi='" + rdbUbicacionPeriodo.Tag + "',");
                    cadena.Append("DirAu='" + rdbDomAudiencia.Tag + "',");
                    cadena.Append("DirFis='" + rdbDomFiscal.Tag + "',");
                    cadena.Append("Gestion_cobranza_P ='" + chkGestionCobranza.Tag + "',");
                    cadena.Append("Servicio_Agua_P='" + chkServAgua.Tag + "',");
                    cadena.Append("Copropietario_1_P= '" + txtCopropietario1.Text + "',");
                    cadena.Append("Copropietario_2_P='" + txtCopropietario2.Text + "',");
                    cadena.Append("Copropietario_3_P='" + txtCopropietario3.Text + "',");
                    cadena.Append("Copropietario_4_P='" + txtCopropietario4.Text + "',");
                    cadena.Append("Copropietario_5_P='" + txtCopropietario5.Text + "',");
                    cadena.Append("Copropietario_6_P='" + txtCopropietario6.Text + "',");
                    cadena.Append("Copropietario_7_P='" + txtCopropietario7.Text + "',");
                    cadena.Append("Copropietario_8_P='" + txtCopropietario8.Text + "',");
                    cadena.Append("Copropietario_9_P='" + txtCopropietario9.Text + "',");
                    cadena.Append("Copropietario_10_P='" + txtCopropietario10.Text + "',");
                    cadena.Append("id_Tarifa_P='" + cmbTarifas.SelectedValue + "',");
                    cadena.Append("Estado_P='ACTIVO',");
                    cadena.Append("Valor_Fiscal_P='" + txtValorFiscal.Text + "',");
                    cadena.Append("NombrePredio_P='" + txtdomicilio.Text + "',");
                    cadena.Append("UltimoPagoP='" + Convert.ToDateTime(dtUFP.Text).ToString("yyyy-MM-dd") + "',");
                    cadena.Append("TipoIdentificacion='" + Identificacion + "',");
                    cadena.Append("Superficie=" + DIsuperficie.Value + ",");
                    cadena.Append("Superficiec=" + DIConstruida.Value);
                  
                    if (Modo == "Modificar")
                    {
                        //cadena.Append("WHERE CUENTA='" + txtCuenta.Text + "'");                        
                        cadena.Append(" WHERE clave_predial = '" + txtClaveCatstral.Text + "'");
                    }

                    
                    Conexion_a_BD.insertar(cadena.ToString());


                    Conexion_a_BD.Desconectar();
                    MessageBox.Show("Registro guardado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                    Conexion_a_BD.Desconectar();
                }
            }
        }

        private void rdbIFE_CheckedChanged(object sender, EventArgs e)
        {
            Identificacion = "IFE";
        }

        private void rdbCartilla_CheckedChanged(object sender, EventArgs e)
        {
            Identificacion = "Cartilla Militar";
        }

        private void rdbPasaporte_CheckedChanged(object sender, EventArgs e)
        {
            Identificacion = "Pasaporte";
        }

        private void rdbLicManejo_CheckedChanged(object sender, EventArgs e)
        {
            Identificacion = "Licencia de Manejo";
        }       
               
    }
}
