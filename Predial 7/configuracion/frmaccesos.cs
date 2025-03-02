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
    public partial class frmaccesos : Form
    {
        DataTable TBL_Consulta = new DataTable();
        public frmaccesos()
        {
            InitializeComponent();
        }

        private void frmaccesos_Load(object sender, EventArgs e)
        {

           LLENARGRID ();


        }

        public void LLENARGRID()
        {
             Conexion_a_BD.Conectar();
            TBL_Consulta = Conexion_a_BD.Consultasql("*", "LETRAS_P");
            Conexion_a_BD.Desconectar();
            var resultado = from myRow in TBL_Consulta.AsEnumerable() select myRow;
            advTree1.Nodes.Clear();
            try
            {
                DataView view = resultado.AsDataView();

                for (int i = 0; i <= view.Count - 1; i++)
                {
                    DevComponents.AdvTree.Node Nodo = new DevComponents.AdvTree.Node();
                    Seguridad seg = new Seguridad();
                    string user = view[i]["user"].ToString ();
                    Nodo.Cells[0].Text = seg.Desencriptar(user);
                    string nombre = view[i]["NOMBRE"].ToString();
                    Nodo.Cells.Add(new DevComponents.AdvTree.Cell());
                    Nodo.Cells[1].Text = seg.Desencriptar(nombre);
                    Nodo.Cells.Add(new DevComponents.AdvTree.Cell());
                    bool activo = Convert.ToBoolean (view[i]["status"].ToString ());
                    if (activo)
                    {
                        Nodo.Cells[2].Images.Image = Predial10.Properties.Resources.ok;
                    }
                    else
                    {
                        Nodo.Cells[2].Images.Image = Predial10.Properties.Resources.none16 ;
                    }

                    Nodo.Cells.Add(new DevComponents.AdvTree.Cell());
                    string id = view[i]["iduser"].ToString();
                    Nodo.Cells[3].Text = id;
                    
                    advTree1.Nodes.Add(Nodo);
                }

            }
            catch (Exception x)
            {
            }
    }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            frmusuario usu = new frmusuario();
            usu.ShowDialog();
            LLENARGRID();
        }

        private void btnvisualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string id = advTree1.SelectedNode.Cells[3].Text;
                frmusuario usu = new frmusuario();
                usu.Modo = "Editar";
                usu.idusuario = id;
                usu.ShowDialog();
                LLENARGRID();
            }
            catch (Exception err)
            {

            }
        }

        private void btninha_Click(object sender, EventArgs e)
        {
            try
            {
                string id = advTree1.SelectedNode.Cells[3].Text;
                Conexion_a_BD.Conectar();
                Conexion_a_BD.Ejecutar("update letras_p set status=0 where iduser=" + id);
                Conexion_a_BD.Desconectar();
                LLENARGRID();
            }
            catch (Exception err)
            {

            }
        }
    }
}
