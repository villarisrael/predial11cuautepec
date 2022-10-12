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
    public partial class frmconceptoscxc : DevComponents.DotNetBar.Office2007Form
    {
        Predial10.Catalogos.Catalogos frmmio;
        public String Modo = "Insertar";

        public frmconceptoscxc()
        {
            InitializeComponent();
        }
        public frmconceptoscxc(Predial10.Catalogos.Catalogos _frmmio)
        {
            InitializeComponent();
            frmmio = _frmmio;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void txtidcalle_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

    }
}
