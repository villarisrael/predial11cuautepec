namespace Predial10.Catalogos
{
    partial class frmcaja
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
            this.cmbMulticaja = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.Si = new DevComponents.Editors.ComboItem();
            this.No = new DevComponents.Editors.ComboItem();
            this.cmbTipoCaja = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.Local = new DevComponents.Editors.ComboItem();
            this.Remota = new DevComponents.Editors.ComboItem();
            this.txtDescripcion = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cmbActivo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.Activo = new DevComponents.Editors.ComboItem();
            this.Desactivado = new DevComponents.Editors.ComboItem();
            this.cmbOficina = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtSerie = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtIdCaja = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.Btncancelar = new DevComponents.DotNetBar.ButtonX();
            this.Btnaceptar = new DevComponents.DotNetBar.ButtonX();
            this.txtFolio = new DevComponents.Editors.IntegerInput();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFolio)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbMulticaja
            // 
            this.cmbMulticaja.DisplayMember = "Text";
            this.cmbMulticaja.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMulticaja.FormattingEnabled = true;
            this.cmbMulticaja.ItemHeight = 14;
            this.cmbMulticaja.Items.AddRange(new object[] {
            this.Si,
            this.No});
            this.cmbMulticaja.Location = new System.Drawing.Point(604, 51);
            this.cmbMulticaja.Name = "cmbMulticaja";
            this.cmbMulticaja.Size = new System.Drawing.Size(121, 20);
            this.cmbMulticaja.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbMulticaja.TabIndex = 34;
            this.cmbMulticaja.Visible = false;
            // 
            // Si
            // 
            this.Si.Text = "Si";
            // 
            // No
            // 
            this.No.Text = "No";
            // 
            // cmbTipoCaja
            // 
            this.cmbTipoCaja.DisplayMember = "Text";
            this.cmbTipoCaja.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTipoCaja.FormattingEnabled = true;
            this.cmbTipoCaja.ItemHeight = 14;
            this.cmbTipoCaja.Items.AddRange(new object[] {
            this.Local,
            this.Remota});
            this.cmbTipoCaja.Location = new System.Drawing.Point(129, 109);
            this.cmbTipoCaja.Name = "cmbTipoCaja";
            this.cmbTipoCaja.Size = new System.Drawing.Size(194, 20);
            this.cmbTipoCaja.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbTipoCaja.TabIndex = 6;
            // 
            // Local
            // 
            this.Local.Text = "Local";
            // 
            // Remota
            // 
            this.Remota.Text = "Remota";
            // 
            // txtDescripcion
            // 
            // 
            // 
            // 
            this.txtDescripcion.Border.Class = "TextBoxBorder";
            this.txtDescripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDescripcion.Location = new System.Drawing.Point(129, 83);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(453, 20);
            this.txtDescripcion.TabIndex = 5;
            // 
            // cmbActivo
            // 
            this.cmbActivo.DisplayMember = "Text";
            this.cmbActivo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbActivo.FormattingEnabled = true;
            this.cmbActivo.ItemHeight = 14;
            this.cmbActivo.Items.AddRange(new object[] {
            this.Desactivado,
            this.Activo});
            this.cmbActivo.Location = new System.Drawing.Point(297, 53);
            this.cmbActivo.Name = "cmbActivo";
            this.cmbActivo.Size = new System.Drawing.Size(122, 20);
            this.cmbActivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbActivo.TabIndex = 4;
            this.cmbActivo.SelectedIndexChanged += new System.EventHandler(this.cmbActivo_SelectedIndexChanged);
            // 
            // Activo
            // 
            this.Activo.Text = "Activo";
            // 
            // Desactivado
            // 
            this.Desactivado.Text = "Desactivado";
            // 
            // cmbOficina
            // 
            this.cmbOficina.DisplayMember = "Text";
            this.cmbOficina.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbOficina.FormattingEnabled = true;
            this.cmbOficina.ItemHeight = 14;
            this.cmbOficina.Location = new System.Drawing.Point(93, 53);
            this.cmbOficina.Name = "cmbOficina";
            this.cmbOficina.Size = new System.Drawing.Size(151, 20);
            this.cmbOficina.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbOficina.TabIndex = 3;
            // 
            // txtSerie
            // 
            // 
            // 
            // 
            this.txtSerie.Border.Class = "TextBoxBorder";
            this.txtSerie.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerie.Location = new System.Drawing.Point(256, 24);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(100, 20);
            this.txtSerie.TabIndex = 1;
            // 
            // txtIdCaja
            // 
            // 
            // 
            // 
            this.txtIdCaja.Border.Class = "TextBoxBorder";
            this.txtIdCaja.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtIdCaja.Location = new System.Drawing.Point(93, 24);
            this.txtIdCaja.MaxLength = 3;
            this.txtIdCaja.Name = "txtIdCaja";
            this.txtIdCaja.Size = new System.Drawing.Size(84, 20);
            this.txtIdCaja.TabIndex = 0;
            // 
            // labelX13
            // 
            this.labelX13.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.Class = "";
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Location = new System.Drawing.Point(36, 109);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(75, 23);
            this.labelX13.TabIndex = 26;
            this.labelX13.Text = "Tipo de Caja:";
            // 
            // labelX11
            // 
            this.labelX11.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.Class = "";
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Location = new System.Drawing.Point(560, 49);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(60, 23);
            this.labelX11.TabIndex = 25;
            this.labelX11.Text = "Multicaja:";
            this.labelX11.Visible = false;
            // 
            // labelX10
            // 
            this.labelX10.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.Class = "";
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(36, 83);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(69, 23);
            this.labelX10.TabIndex = 24;
            this.labelX10.Text = "Descripción:";
            // 
            // labelX9
            // 
            this.labelX9.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.Class = "";
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(250, 50);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(41, 23);
            this.labelX9.TabIndex = 23;
            this.labelX9.Text = "Estado:";
            // 
            // labelX8
            // 
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.Class = "";
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(425, 25);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(47, 23);
            this.labelX8.TabIndex = 22;
            this.labelX8.Text = "Folio:";
            // 
            // labelX7
            // 
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.Class = "";
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(39, 53);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(44, 23);
            this.labelX7.TabIndex = 21;
            this.labelX7.Text = "Oficina:";
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(209, 24);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(35, 23);
            this.labelX6.TabIndex = 20;
            this.labelX6.Text = "Serie:";
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(39, 24);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(47, 23);
            this.labelX5.TabIndex = 19;
            this.labelX5.Text = "Id Caja:";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.Btncancelar);
            this.groupPanel1.Controls.Add(this.Btnaceptar);
            this.groupPanel1.Location = new System.Drawing.Point(489, 118);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(200, 107);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.Class = "";
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.Class = "";
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.Class = "";
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 35;
            this.groupPanel1.Text = "Opciones";
            // 
            // Btncancelar
            // 
            this.Btncancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Btncancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Btncancelar.Image = global::Predial10.Properties.Resources.none16;
            this.Btncancelar.Location = new System.Drawing.Point(104, 35);
            this.Btncancelar.Name = "Btncancelar";
            this.Btncancelar.Size = new System.Drawing.Size(75, 33);
            this.Btncancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Btncancelar.TabIndex = 1;
            this.Btncancelar.Text = "Cancelar";
            this.Btncancelar.Click += new System.EventHandler(this.Btncancelar_Click);
            // 
            // Btnaceptar
            // 
            this.Btnaceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Btnaceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Btnaceptar.Image = global::Predial10.Properties.Resources.ok;
            this.Btnaceptar.Location = new System.Drawing.Point(23, 35);
            this.Btnaceptar.Name = "Btnaceptar";
            this.Btnaceptar.Size = new System.Drawing.Size(75, 33);
            this.Btnaceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Btnaceptar.TabIndex = 0;
            this.Btnaceptar.Text = "Aceptar";
            this.Btnaceptar.Click += new System.EventHandler(this.Btnaceptar_Click);
            // 
            // txtFolio
            // 
            // 
            // 
            // 
            this.txtFolio.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtFolio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFolio.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtFolio.Location = new System.Drawing.Point(467, 24);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.ShowUpDown = true;
            this.txtFolio.Size = new System.Drawing.Size(80, 20);
            this.txtFolio.TabIndex = 2;
            // 
            // frmcaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 237);
            this.Controls.Add(this.txtFolio);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.cmbMulticaja);
            this.Controls.Add(this.cmbTipoCaja);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.cmbActivo);
            this.Controls.Add(this.cmbOficina);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.txtIdCaja);
            this.Controls.Add(this.labelX13);
            this.Controls.Add(this.labelX11);
            this.Controls.Add(this.labelX10);
            this.Controls.Add(this.labelX9);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX5);
            this.DoubleBuffered = true;
            this.Name = "frmcaja";
            this.Text = "Cajas";
            this.Load += new System.EventHandler(this.frmcaja_Load);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFolio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbMulticaja;
        private DevComponents.Editors.ComboItem Si;
        private DevComponents.Editors.ComboItem No;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbTipoCaja;
        private DevComponents.Editors.ComboItem Local;
        private DevComponents.Editors.ComboItem Remota;
        public DevComponents.DotNetBar.Controls.TextBoxX txtDescripcion;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbActivo;
        private DevComponents.Editors.ComboItem Activo;
        private DevComponents.Editors.ComboItem Desactivado;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbOficina;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSerie;
        public DevComponents.DotNetBar.Controls.TextBoxX txtIdCaja;
        private DevComponents.DotNetBar.LabelX labelX13;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX Btncancelar;
        private DevComponents.DotNetBar.ButtonX Btnaceptar;
        private DevComponents.Editors.IntegerInput txtFolio;
    }
}