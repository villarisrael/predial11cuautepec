using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Predial10;

namespace Predial10.Facturacion
{
    public partial class frmexport : DevComponents.DotNetBar.Office2007Form
    {
        string Archivo = "Predial.xml";
        public frmexport()
        {
            InitializeComponent();
        }

        private void btnfiledialog_Click(object sender, EventArgs e)
        {
          

            saveFileDialog1.FileName = Archivo;
            saveFileDialog1.Filter = "*.xml|*.*";
            saveFileDialog1.Title = "Grabar el archivo Xml";
            saveFileDialog1.ShowDialog ();

            if (saveFileDialog1.FileName != "" )
            {
                Archivo = saveFileDialog1.FileName ;

            }
            txtarchivo.Text = Archivo;
                txtarchivo.Enabled = false;
           
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            DataSet1TableAdapters.vusuarioTableAdapter x = new DataSet1TableAdapters.vusuarioTableAdapter();
            DataSet1.vusuarioDataTable y = new DataSet1.vusuarioDataTable();
            try
            {

                x.Fill(y);
            }
            catch (Exception algo)
            {
            }
            y.WriteXml(Archivo);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmexport_Load(object sender, EventArgs e)
        {

        }
    }
}
