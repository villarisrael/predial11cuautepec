using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Predial10.configuracion
{
    public partial class frmconfigurar : DevComponents.DotNetBar.Office2007Form
    {
        public frmconfigurar()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'predialchicoDataSet.formatorecibo' table. You can move, or remove it, as needed.
            this.formatoreciboTableAdapter.Fill(this.predialchicoDataSet.formatorecibo);
           
            

            txtcadena.Text = Predial10.Properties.Settings.Default.predialchicoConnectionString ;
            IIlininicial.Value = Predial10.Properties.Settings.Default.linea_inicial_de_detalle_de_recibo;
            txtletra.Text = Predial10.Properties.Settings.Default.letra_detalle_recibo;
            Ditamano.Value = Predial10.Properties.Settings.Default.tamano_letra_detalle_recibo;
            iicolconcep.Value = Predial10.Properties.Settings.Default.columna_de_concepto;
            IIimporte.Value = Predial10.Properties.Settings.Default.columna_de_importe;
            iiavance.Value = Predial10.Properties.Settings.Default.avance_de_linea_detalle_recibo;

        }

        private void labelX13_Click(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                fontDialog1.ShowDialog();
                txtletra.Text = fontDialog1.Font.Name;
                Ditamano.Value = fontDialog1.Font.Size;
            }
            catch ( Exception )
            {
                MessageBox.Show("Tu tipo de letra no es valida, selecciona otra");
            }
            
        }

        private void btngrabar_Click(object sender, EventArgs e)
        {
            try
            {
                // Predial10.Properties.Settings.Default.cobroexpressConnectionString =  txtcadena.Text ;
                Predial10.Properties.Settings.Default.linea_inicial_de_detalle_de_recibo = IIlininicial.Value;
                Predial10.Properties.Settings.Default.letra_detalle_recibo = txtletra.Text;
                float tem;
                float.TryParse(Ditamano.Value.ToString(), out tem);
                Predial10.Properties.Settings.Default.tamano_letra_detalle_recibo = tem;
                Predial10.Properties.Settings.Default.columna_de_concepto = iicolconcep.Value;
                Predial10.Properties.Settings.Default.columna_de_importe = IIimporte.Value;
                Predial10.Properties.Settings.Default.avance_de_linea_detalle_recibo = iiavance.Value;
                //Predial10.Properties.Settings.Default.cobroexpressConnectionString = txtcadena.Text ;
                //  this.empresaTableAdapter.Update(cobroexpressDataSet.empresa);
                this.formatoreciboTableAdapter.Adapter.Update(predialchicoDataSet.formatorecibo);

                Predial10.Properties.Settings.Default.Save();
            }
            catch ( Exception ERR)
            {
                MessageBox.Show(ERR.Message);
            }
        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        
    }
      
}