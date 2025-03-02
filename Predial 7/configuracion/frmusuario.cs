﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Predial10.Resources.CODE;

namespace Predial10.configuracion
{
    public partial class frmusuario : Form
    {
        DataTable TBL_Consulta = new DataTable();
        Predial10.Resources.CODE.Seguridad Encriptar = new Seguridad();
        string NombreEncriptado, UsuarioEncripatado, PasswordEncriptado;
        int Estado=1;

        public string Modo = "Agregar";
        public string idusuario = "0";

        public frmusuario()
        {
            InitializeComponent();
        }

        private void rbtActivo_CheckedChanged(object sender, EventArgs e)
        {
            Estado = 1;
        }

        private void rbtInactivo_CheckedChanged(object sender, EventArgs e)
        {
            Estado = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (txtPassword.Text == txtCPassword.Text)
            {
                NombreEncriptado = Encriptar.Encriptar(txtNombre.Text);
                UsuarioEncripatado = Encriptar.Encriptar(txtUsuario.Text);
                PasswordEncriptado = Encriptar.Encriptar(txtPassword.Text);

                try
                {
                    Conexion_a_BD.Conectar();
                    StringBuilder cadena = new StringBuilder();
                    if (Modo == "Agregar")
                    {
                        cadena.Append("INSERT INTO predialchico.letras_p SET ");
                    }
                    else
                    {
                        cadena.Append("UPDATE predialchico.letras_p SET ");
                    }
                    cadena.Append("Nombre= '" + NombreEncriptado + "',");
                    cadena.Append("User='" + UsuarioEncripatado + "',");
                    cadena.Append("Password='" + PasswordEncriptado + "',");                   
                    cadena.Append("Status='" + Estado + "'");
                    if (Modo == "Agregar")
                    {
                        cadena.Append(";");
                        Conexion_a_BD.insertar(cadena.ToString());
                    }
                    else
                    {
                        cadena.Append(" WHERE IDUSER=" + idusuario  );
                        Conexion_a_BD.insertar(cadena.ToString());

                    }

                    modificaarbol(idusuario);

                    Conexion_a_BD.Desconectar();
                    MessageBox.Show("Registro guardado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNombre.Text = "";
                    txtUsuario.Text = "";
                    txtPassword.Text = "";
                    txtCPassword.Text = "";
                    rbtActivo.Checked = true;
                    Close();
                    txtNombre.Focus();

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("La confirmación del password no es igual que el password, verifique nuevamente","Información",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void frmusuario_Load(object sender, EventArgs e)
        {
            llenalista();

            if (Modo == "Editar")
            {
                Conexion_a_BD.Conectar();
                TBL_Consulta = Conexion_a_BD.Consultasql("*", "LETRAS_P where iduser =" + idusuario );
                Conexion_a_BD.Desconectar();
                var resultado = from myRow in TBL_Consulta.AsEnumerable() select myRow;
              
                Seguridad seg = new Seguridad ();
                try
                {
                    DataView view = resultado.AsDataView();
                    txtNombre.Text =  seg.Desencriptar (view[0]["Nombre"].ToString ());
                    txtUsuario.Text = seg.Desencriptar(view[0]["user"].ToString());
                    txtPassword.Text = seg.Desencriptar(view[0]["password"].ToString());
                    txtCPassword.Text = seg.Desencriptar(view[0]["password"].ToString());
                    if ( Convert.ToBoolean( view[0]["Status"].ToString()))
                    {
                        rbtActivo.Checked = true;
                        rbtInactivo.Checked = false;
                    }
                    else
                    {
                        rbtActivo.Checked = false;
                        rbtInactivo.Checked = true;
                    }

                    llenadatos(idusuario);

                }
                catch (Exception err)
                {
                }
            }
        }


        public void llenalista()
        {
            advTree1.Nodes.Clear();
            Predial10.Principal Obtienemenu = new Predial10.Principal();
            for (int i = 0; i <= Obtienemenu.menu.Items.Count - 1; i++)
            {
                DevComponents.DotNetBar.RibbonTabItem tabuladores = new DevComponents.DotNetBar.RibbonTabItem();
                tabuladores = (DevComponents.DotNetBar.RibbonTabItem)Obtienemenu.menu.Items[i];
                for (int j = tabuladores.Panel.Controls.Count - 1; j >= 0; j--)
                {
                    DevComponents.DotNetBar.RibbonBar barras = new DevComponents.DotNetBar.RibbonBar();
                    barras = (DevComponents.DotNetBar.RibbonBar)tabuladores.Panel.Controls[j];

                    for (int k = barras.Items.Count; k >= 0; k--)
                    {

                        DevComponents.DotNetBar.ButtonItem boton = new DevComponents.DotNetBar.ButtonItem();
                        try
                        {
                            boton = (DevComponents.DotNetBar.ButtonItem)barras.Items[k];
                            DevComponents.AdvTree.Node nodo = new DevComponents.AdvTree.Node();
                            nodo.Cells[0].Text = boton.Tooltip;
                            nodo.Cells.Add(new DevComponents.AdvTree.Cell());
                            nodo.Cells[1].Text = "Acceder";
                            nodo.Cells[1].CheckBoxVisible = true;
                            nodo.Cells[1].Checked = true;
                            nodo.Image = boton.Image;
                            advTree1.Nodes.Add(nodo);

                        }
                        catch (Exception err)
                        {
                        }
                    }
                }
            }
        }

        public void modificaarbol(string _id)
        {
            Conexion_a_BD.Conectar();
            Conexion_a_BD.Ejecutar("Delete from arbol_p where id2=" + _id);
           

            for (int i = 0; i <= advTree1.Nodes.Count - 1; i++)
            {
                StringBuilder cadena = new StringBuilder();
                Seguridad seg = new Seguridad();

                cadena.Append("INSERT INTO Arbol_p SET id2= " + _id + " ");
                string campo =  seg.Encriptar (advTree1.Nodes[i].Cells[0].Text);
                string que;
                if (advTree1.Nodes[i].Cells[1].Checked)
                {
                    que = "1";
                }
                else
                {
                    que="0";
                }

                cadena.Append(", ido= '" + campo + "', idv=" + que);
                Conexion_a_BD.insertar(cadena.ToString());
            }

            Conexion_a_BD.Desconectar();
         

           
        }

        public void llenadatos(string _id)
        {
           Conexion_a_BD.Conectar();
                TBL_Consulta = Conexion_a_BD.Consultasql("*", "arbol_P where id2 =" + _id );
                Conexion_a_BD.Desconectar();
                var resultado = from myRow in TBL_Consulta.AsEnumerable() select myRow;
              
                Seguridad seg = new Seguridad ();
                try
                {
                    DataView view = resultado.AsDataView();

                    for (int i = 0; i<=view.Count - 1; i++)
                    {
                        string campo = seg.Desencriptar(view[i]["ido"].ToString());
                        string que = view[i]["idv"].ToString();

                        for (int j = 0; j <= advTree1.Nodes.Count - 1; j++)
                        {
                            
                            if (advTree1.Nodes[j].Cells[0].Text ==campo)
                            {
                                if (que == "1")
                                {
                                    advTree1.Nodes[j].Cells[1].Checked = true ;
                                }
                                else
                                {
                                    advTree1.Nodes[j].Cells[1].Checked = false;
                                }
                            }
                            
                        }
                    }
                    
                }
                catch (Exception err)
                {
                }
        }

    }
}
