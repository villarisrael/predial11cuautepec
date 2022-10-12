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
    public partial class frmregiones : DevComponents.DotNetBar.Office2007Form
    {
        Predial10.Catalogos.Catalogos frmmio;
        public String Modo = "Insertar";
        public frmregiones(Predial10.Catalogos.Catalogos _frmmio)
        {
            InitializeComponent();
            frmmio = _frmmio;
        }
        public frmregiones()
        {
            InitializeComponent();
           
        }

        private void Btnaceptar_Click(object sender, EventArgs e)
        {
            if (Txtidregion.Text == "")
            {
                MessageBox.Show("Debes ingresar un ID de region");
                Txtidregion.BackColor = Color.Yellow;
                Txtidregion.Focus();
                return;
            }
            if (Txtnombre.Text == "")
            {
                MessageBox.Show("Debes ingresar un nombre de region");
                Txtidregion.BackColor = Color.Yellow;
                Txtidregion.Focus();
                return;
            }
            //if (Txtidsector.TextLength < 3)
            //{
            //    MessageBox.Show("El ID de sector debe tener 3 letras");
            //    Txtidsector.BackColor = Color.Yellow;
            //    Txtidsector.Focus();
            //    return;
            //}

            try
            {
                Conexion_a_BD.Conectar();
                if (Modo == "Insertar")
                {
                    try
                    {
                        String cadena = "INSERT INTO REGION(id_region, region) values ('" + Txtidregion.Text + " ', '" + Txtnombre.Text + "')";
                        Conexion_a_BD.Ejecutar(cadena);
                    }
                    catch (Exception c)
                    {
                        if (c.Message.Contains("key"))
                        {
                            MessageBox.Show("El Id ya existe");
                            return;
                        }
                        MessageBox.Show("Error al Insertar " + c.Message);
                    }
                    
                }
                if (Modo == "Actualizar")
                {
                    Conexion_a_BD.Conectar();
                    String cadena = "UPDATE region SET region='" + Txtnombre.Text + "' WHERE id_region='" + Txtidregion.Text + "'";
                    Conexion_a_BD.Ejecutar(cadena);

                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            frmmio.llenaregiones();
            Close();
        }

        private void Btncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }



    }
}
