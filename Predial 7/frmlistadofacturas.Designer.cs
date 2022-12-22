namespace Predial10
{
    partial class frmlistadofacturas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmlistadofacturas));
            this.Panel2 = new System.Windows.Forms.Panel();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.LabelX2 = new DevComponents.DotNetBar.LabelX();
            this.lblencontradas = new DevComponents.DotNetBar.LabelX();
            this.txtCaja = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.LabelX1 = new DevComponents.DotNetBar.LabelX();
            this.superTabrecibos = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btncancelarrecibo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnreimprimir = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Maestro = new DevComponents.DotNetBar.SuperTabItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtfinal = new System.Windows.Forms.DateTimePicker();
            this.dtinicio = new System.Windows.Forms.DateTimePicker();
            this.btncargar = new DevComponents.DotNetBar.ButtonX();
            this.btncerrar = new DevComponents.DotNetBar.ButtonX();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabrecibos)).BeginInit();
            this.superTabrecibos.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.OrangeRed;
            this.Panel2.Controls.Add(this.PictureBox1);
            this.Panel2.Location = new System.Drawing.Point(453, 0);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(54, 43);
            this.Panel2.TabIndex = 52;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = global::Predial10.Properties.Resources.if_invoice_54323;
            this.PictureBox1.Location = new System.Drawing.Point(3, 3);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(33, 37);
            this.PictureBox1.TabIndex = 0;
            this.PictureBox1.TabStop = false;
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Controls.Add(this.LabelX2);
            this.Panel1.Controls.Add(this.lblencontradas);
            this.Panel1.Location = new System.Drawing.Point(442, 13);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(194, 58);
            this.Panel1.TabIndex = 51;
            // 
            // LabelX2
            // 
            this.LabelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX2.ForeColor = System.Drawing.Color.Gray;
            this.LabelX2.Location = new System.Drawing.Point(79, 3);
            this.LabelX2.Name = "LabelX2";
            this.LabelX2.Size = new System.Drawing.Size(112, 23);
            this.LabelX2.TabIndex = 37;
            this.LabelX2.Text = "Facturas Encontradas";
            // 
            // lblencontradas
            // 
            // 
            // 
            // 
            this.lblencontradas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblencontradas.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblencontradas.Location = new System.Drawing.Point(64, 27);
            this.lblencontradas.Name = "lblencontradas";
            this.lblencontradas.Size = new System.Drawing.Size(104, 23);
            this.lblencontradas.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.lblencontradas.TabIndex = 38;
            this.lblencontradas.Text = "0";
            this.lblencontradas.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtCaja
            // 
            // 
            // 
            // 
            this.txtCaja.Border.Class = "TextBoxBorder";
            this.txtCaja.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCaja.Location = new System.Drawing.Point(313, 12);
            this.txtCaja.Name = "txtCaja";
            this.txtCaja.PreventEnterBeep = true;
            this.txtCaja.Size = new System.Drawing.Size(100, 20);
            this.txtCaja.TabIndex = 50;
            // 
            // LabelX1
            // 
            // 
            // 
            // 
            this.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX1.Location = new System.Drawing.Point(270, 7);
            this.LabelX1.Name = "LabelX1";
            this.LabelX1.Size = new System.Drawing.Size(52, 23);
            this.LabelX1.TabIndex = 49;
            this.LabelX1.Text = "Caja";
            // 
            // superTabrecibos
            // 
            this.superTabrecibos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabrecibos.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabrecibos.ControlBox.MenuBox.Name = "";
            this.superTabrecibos.ControlBox.Name = "";
            this.superTabrecibos.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabrecibos.ControlBox.MenuBox,
            this.superTabrecibos.ControlBox.CloseBox});
            this.superTabrecibos.Controls.Add(this.superTabControlPanel1);
            this.superTabrecibos.Location = new System.Drawing.Point(4, 88);
            this.superTabrecibos.Name = "superTabrecibos";
            this.superTabrecibos.ReorderTabsEnabled = true;
            this.superTabrecibos.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.superTabrecibos.SelectedTabIndex = 0;
            this.superTabrecibos.Size = new System.Drawing.Size(853, 428);
            this.superTabrecibos.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superTabrecibos.TabIndex = 48;
            this.superTabrecibos.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Maestro});
            this.superTabrecibos.Text = "superTabControl1";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.toolStrip1);
            this.superTabControlPanel1.Controls.Add(this.dataGridView1);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(853, 403);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.Maestro;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btncancelarrecibo,
            this.toolStripSeparator1,
            this.btnreimprimir,
            this.ToolStripButton2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(853, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btncancelarrecibo
            // 
            this.btncancelarrecibo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btncancelarrecibo.Image = global::Predial10.Properties.Resources.cancel_invoice_2703075;
            this.btncancelarrecibo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btncancelarrecibo.Name = "btncancelarrecibo";
            this.btncancelarrecibo.Size = new System.Drawing.Size(23, 22);
            this.btncancelarrecibo.ToolTipText = "Cancelar Factura ante el SAT";
            this.btncancelarrecibo.Click += new System.EventHandler(this.btncancelarrecibo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnreimprimir
            // 
            this.btnreimprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnreimprimir.Image")));
            this.btnreimprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnreimprimir.Name = "btnreimprimir";
            this.btnreimprimir.Size = new System.Drawing.Size(85, 22);
            this.btnreimprimir.Text = "Genera pdf";
            this.btnreimprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnreimprimir.ToolTipText = "Genera el pdf de nuevo";
            this.btnreimprimir.Click += new System.EventHandler(this.btnreimprimir_Click);
            // 
            // ToolStripButton2
            // 
            this.ToolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton2.Image")));
            this.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton2.Name = "ToolStripButton2";
            this.ToolStripButton2.Size = new System.Drawing.Size(100, 22);
            this.ToolStripButton2.Text = "Generar todas";
            this.ToolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.ToolStripButton2.ToolTipText = "Genera el pdf de nuevo";
            this.ToolStripButton2.Click += new System.EventHandler(this.ToolStripButton2_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Cancelar SAT";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(844, 360);
            this.dataGridView1.TabIndex = 0;
            // 
            // Maestro
            // 
            this.Maestro.AttachedControl = this.superTabControlPanel1;
            this.Maestro.GlobalItem = false;
            this.Maestro.Name = "Maestro";
            this.Maestro.Text = "Facturas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "De";
            // 
            // dtfinal
            // 
            this.dtfinal.Location = new System.Drawing.Point(50, 38);
            this.dtfinal.Name = "dtfinal";
            this.dtfinal.Size = new System.Drawing.Size(200, 20);
            this.dtfinal.TabIndex = 44;
            // 
            // dtinicio
            // 
            this.dtinicio.Location = new System.Drawing.Point(50, 12);
            this.dtinicio.Name = "dtinicio";
            this.dtinicio.Size = new System.Drawing.Size(200, 20);
            this.dtinicio.TabIndex = 43;
            // 
            // btncargar
            // 
            this.btncargar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btncargar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btncargar.Image = ((System.Drawing.Image)(resources.GetObject("btncargar.Image")));
            this.btncargar.Location = new System.Drawing.Point(664, 20);
            this.btncargar.Name = "btncargar";
            this.btncargar.Size = new System.Drawing.Size(102, 37);
            this.btncargar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btncargar.TabIndex = 45;
            this.btncargar.Text = "Cargar";
            this.btncargar.Click += new System.EventHandler(this.btncargar_Click);
            // 
            // btncerrar
            // 
            this.btncerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btncerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btncerrar.Image = ((System.Drawing.Image)(resources.GetObject("btncerrar.Image")));
            this.btncerrar.Location = new System.Drawing.Point(772, 21);
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(89, 37);
            this.btncerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btncerrar.TabIndex = 53;
            this.btncerrar.Text = "Cerrar";
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // frmlistadofacturas
            // 
            this.ClientSize = new System.Drawing.Size(869, 528);
            this.Controls.Add(this.btncerrar);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.txtCaja);
            this.Controls.Add(this.LabelX1);
            this.Controls.Add(this.superTabrecibos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtfinal);
            this.Controls.Add(this.dtinicio);
            this.Controls.Add(this.btncargar);
            this.DoubleBuffered = true;
            this.Name = "frmlistadofacturas";
            this.Text = "Listado de facturas";
            this.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabrecibos)).EndInit();
            this.superTabrecibos.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.superTabControlPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Panel Panel1;
        internal DevComponents.DotNetBar.LabelX LabelX2;
        internal DevComponents.DotNetBar.LabelX lblencontradas;
        internal DevComponents.DotNetBar.Controls.TextBoxX txtCaja;
        internal DevComponents.DotNetBar.LabelX LabelX1;
        private DevComponents.DotNetBar.SuperTabControl superTabrecibos;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btncancelarrecibo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton btnreimprimir;
        internal System.Windows.Forms.ToolStripButton ToolStripButton2;
        private DevComponents.DotNetBar.SuperTabItem Maestro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtfinal;
        private System.Windows.Forms.DateTimePicker dtinicio;
        private DevComponents.DotNetBar.ButtonX btncargar;
        private DevComponents.DotNetBar.ButtonX btncerrar;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}