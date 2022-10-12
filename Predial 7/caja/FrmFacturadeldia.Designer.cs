namespace Predial10.caja
{
    partial class FrmFacturadeldia
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFacturadeldia));
            this.txtObservaciones = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtPais = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtDelegacion = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtEmail = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtRFC = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtCP = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtEstado = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPoblacion = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtColonia = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtNoInterior = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtNoExterior = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtCalle = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtNombre = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblPais = new DevComponents.DotNetBar.LabelX();
            this.lblDelegacion = new DevComponents.DotNetBar.LabelX();
            this.lblEmail = new DevComponents.DotNetBar.LabelX();
            this.lblRFC = new DevComponents.DotNetBar.LabelX();
            this.lblCP = new DevComponents.DotNetBar.LabelX();
            this.lblEstado = new DevComponents.DotNetBar.LabelX();
            this.lblPoblacion = new DevComponents.DotNetBar.LabelX();
            this.lblColonia = new DevComponents.DotNetBar.LabelX();
            this.lblNoInterior = new DevComponents.DotNetBar.LabelX();
            this.lblNoExterior = new DevComponents.DotNetBar.LabelX();
            this.lblCalle = new DevComponents.DotNetBar.LabelX();
            this.lblNombre = new DevComponents.DotNetBar.LabelX();
            this.DTGdetalles = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btncargar = new DevComponents.DotNetBar.ButtonX();
            this.DTPfechainicio = new System.Windows.Forms.DateTimePicker();
            this.DTPfechafinal = new System.Windows.Forms.DateTimePicker();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.btnGuardar = new DevComponents.DotNetBar.ButtonX();
            this.btnGenerar = new DevComponents.DotNetBar.ButtonX();
            this.lblsubtotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lbldescuento = new System.Windows.Forms.Label();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.CMBFORMADEPAGO = new System.Windows.Forms.ComboBox();
            this.fpagoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.predialchicoDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.predialchicoDataSet = new Predial10.predialchicoDataSet();
            this.fpagoTableAdapter = new Predial10.predialchicoDataSetTableAdapters.fpagoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DTGdetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpagoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.predialchicoDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.predialchicoDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // txtObservaciones
            // 
            // 
            // 
            // 
            this.txtObservaciones.Border.Class = "TextBoxBorder";
            this.txtObservaciones.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtObservaciones.Location = new System.Drawing.Point(111, 202);
            this.txtObservaciones.MaxLength = 250;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(676, 24);
            this.txtObservaciones.TabIndex = 62;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(25, 199);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(89, 23);
            this.labelX1.TabIndex = 61;
            this.labelX1.Text = "Observaciones:";
            // 
            // txtPais
            // 
            // 
            // 
            // 
            this.txtPais.Border.Class = "TextBoxBorder";
            this.txtPais.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPais.Location = new System.Drawing.Point(87, 174);
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(179, 20);
            this.txtPais.TabIndex = 58;
            this.txtPais.Text = "México";
            // 
            // txtDelegacion
            // 
            // 
            // 
            // 
            this.txtDelegacion.Border.Class = "TextBoxBorder";
            this.txtDelegacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDelegacion.Location = new System.Drawing.Point(342, 151);
            this.txtDelegacion.Name = "txtDelegacion";
            this.txtDelegacion.Size = new System.Drawing.Size(179, 20);
            this.txtDelegacion.TabIndex = 57;
            // 
            // txtEmail
            // 
            // 
            // 
            // 
            this.txtEmail.Border.Class = "TextBoxBorder";
            this.txtEmail.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEmail.Location = new System.Drawing.Point(87, 148);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(179, 20);
            this.txtEmail.TabIndex = 56;
            // 
            // txtRFC
            // 
            // 
            // 
            // 
            this.txtRFC.Border.Class = "TextBoxBorder";
            this.txtRFC.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRFC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRFC.ForeColor = System.Drawing.Color.DarkRed;
            this.txtRFC.Location = new System.Drawing.Point(527, 122);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.ReadOnly = true;
            this.txtRFC.Size = new System.Drawing.Size(162, 20);
            this.txtRFC.TabIndex = 55;
            this.txtRFC.Text = "XAXX010101000";
            // 
            // txtCP
            // 
            // 
            // 
            // 
            this.txtCP.Border.Class = "TextBoxBorder";
            this.txtCP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCP.Location = new System.Drawing.Point(375, 121);
            this.txtCP.Name = "txtCP";
            this.txtCP.Size = new System.Drawing.Size(100, 20);
            this.txtCP.TabIndex = 54;
            this.txtCP.Text = "43740";
            // 
            // txtEstado
            // 
            // 
            // 
            // 
            this.txtEstado.Border.Class = "TextBoxBorder";
            this.txtEstado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEstado.Location = new System.Drawing.Point(89, 122);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(199, 20);
            this.txtEstado.TabIndex = 53;
            this.txtEstado.Text = "HIDALGO";
            // 
            // txtPoblacion
            // 
            // 
            // 
            // 
            this.txtPoblacion.Border.Class = "TextBoxBorder";
            this.txtPoblacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPoblacion.Location = new System.Drawing.Point(490, 90);
            this.txtPoblacion.Name = "txtPoblacion";
            this.txtPoblacion.Size = new System.Drawing.Size(199, 20);
            this.txtPoblacion.TabIndex = 52;
            this.txtPoblacion.Text = "CUAUTEPEC";
            // 
            // txtColonia
            // 
            // 
            // 
            // 
            this.txtColonia.Border.Class = "TextBoxBorder";
            this.txtColonia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtColonia.Location = new System.Drawing.Point(87, 90);
            this.txtColonia.Name = "txtColonia";
            this.txtColonia.Size = new System.Drawing.Size(314, 20);
            this.txtColonia.TabIndex = 51;
            this.txtColonia.Text = "CENTRO";
            // 
            // txtNoInterior
            // 
            // 
            // 
            // 
            this.txtNoInterior.Border.Class = "TextBoxBorder";
            this.txtNoInterior.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNoInterior.Location = new System.Drawing.Point(645, 58);
            this.txtNoInterior.Name = "txtNoInterior";
            this.txtNoInterior.Size = new System.Drawing.Size(57, 20);
            this.txtNoInterior.TabIndex = 50;
            // 
            // txtNoExterior
            // 
            // 
            // 
            // 
            this.txtNoExterior.Border.Class = "TextBoxBorder";
            this.txtNoExterior.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNoExterior.Location = new System.Drawing.Point(490, 58);
            this.txtNoExterior.Name = "txtNoExterior";
            this.txtNoExterior.Size = new System.Drawing.Size(61, 20);
            this.txtNoExterior.TabIndex = 49;
            this.txtNoExterior.Text = "S/N";
            // 
            // txtCalle
            // 
            // 
            // 
            // 
            this.txtCalle.Border.Class = "TextBoxBorder";
            this.txtCalle.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCalle.Location = new System.Drawing.Point(87, 61);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(314, 20);
            this.txtCalle.TabIndex = 48;
            this.txtCalle.Text = "PALACIO MUNICIPAL";
            // 
            // txtNombre
            // 
            // 
            // 
            // 
            this.txtNombre.Border.Class = "TextBoxBorder";
            this.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNombre.Location = new System.Drawing.Point(87, 34);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(508, 20);
            this.txtNombre.TabIndex = 47;
            this.txtNombre.Text = "Publico en General";
            // 
            // lblPais
            // 
            // 
            // 
            // 
            this.lblPais.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPais.ForeColor = System.Drawing.Color.DarkRed;
            this.lblPais.Location = new System.Drawing.Point(25, 174);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(42, 23);
            this.lblPais.TabIndex = 45;
            this.lblPais.Text = "*Pais:";
            // 
            // lblDelegacion
            // 
            // 
            // 
            // 
            this.lblDelegacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDelegacion.Location = new System.Drawing.Point(278, 151);
            this.lblDelegacion.Name = "lblDelegacion";
            this.lblDelegacion.Size = new System.Drawing.Size(65, 23);
            this.lblDelegacion.TabIndex = 44;
            this.lblDelegacion.Text = "Delegación:";
            // 
            // lblEmail
            // 
            // 
            // 
            // 
            this.lblEmail.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblEmail.Location = new System.Drawing.Point(25, 148);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(56, 23);
            this.lblEmail.TabIndex = 43;
            this.lblEmail.Text = "e-mail:";
            // 
            // lblRFC
            // 
            // 
            // 
            // 
            this.lblRFC.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblRFC.ForeColor = System.Drawing.Color.DarkRed;
            this.lblRFC.Location = new System.Drawing.Point(487, 118);
            this.lblRFC.Name = "lblRFC";
            this.lblRFC.Size = new System.Drawing.Size(34, 23);
            this.lblRFC.TabIndex = 42;
            this.lblRFC.Text = "*RFC:";
            // 
            // lblCP
            // 
            // 
            // 
            // 
            this.lblCP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCP.ForeColor = System.Drawing.Color.DarkRed;
            this.lblCP.Location = new System.Drawing.Point(313, 121);
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(56, 23);
            this.lblCP.TabIndex = 41;
            this.lblCP.Text = "*CP:";
            // 
            // lblEstado
            // 
            // 
            // 
            // 
            this.lblEstado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblEstado.ForeColor = System.Drawing.Color.DarkRed;
            this.lblEstado.Location = new System.Drawing.Point(25, 119);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(75, 23);
            this.lblEstado.TabIndex = 40;
            this.lblEstado.Text = "Estado:";
            // 
            // lblPoblacion
            // 
            // 
            // 
            // 
            this.lblPoblacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPoblacion.ForeColor = System.Drawing.Color.DarkRed;
            this.lblPoblacion.Location = new System.Drawing.Point(428, 90);
            this.lblPoblacion.Name = "lblPoblacion";
            this.lblPoblacion.Size = new System.Drawing.Size(56, 23);
            this.lblPoblacion.TabIndex = 39;
            this.lblPoblacion.Text = "*Población:";
            // 
            // lblColonia
            // 
            // 
            // 
            // 
            this.lblColonia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblColonia.Location = new System.Drawing.Point(25, 90);
            this.lblColonia.Name = "lblColonia";
            this.lblColonia.Size = new System.Drawing.Size(75, 23);
            this.lblColonia.TabIndex = 38;
            this.lblColonia.Text = "Colonia:";
            // 
            // lblNoInterior
            // 
            // 
            // 
            // 
            this.lblNoInterior.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNoInterior.Location = new System.Drawing.Point(571, 59);
            this.lblNoInterior.Name = "lblNoInterior";
            this.lblNoInterior.Size = new System.Drawing.Size(68, 23);
            this.lblNoInterior.TabIndex = 37;
            this.lblNoInterior.Text = "No. Interior:";
            // 
            // lblNoExterior
            // 
            // 
            // 
            // 
            this.lblNoExterior.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNoExterior.Location = new System.Drawing.Point(419, 58);
            this.lblNoExterior.Name = "lblNoExterior";
            this.lblNoExterior.Size = new System.Drawing.Size(75, 23);
            this.lblNoExterior.TabIndex = 36;
            this.lblNoExterior.Text = "No. Exterior:";
            // 
            // lblCalle
            // 
            // 
            // 
            // 
            this.lblCalle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCalle.ForeColor = System.Drawing.Color.DarkRed;
            this.lblCalle.Location = new System.Drawing.Point(25, 61);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(75, 23);
            this.lblCalle.TabIndex = 35;
            this.lblCalle.Text = "*Calle:";
            // 
            // lblNombre
            // 
            // 
            // 
            // 
            this.lblNombre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNombre.ForeColor = System.Drawing.Color.DarkRed;
            this.lblNombre.Location = new System.Drawing.Point(25, 31);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(75, 23);
            this.lblNombre.TabIndex = 34;
            this.lblNombre.Text = "*Nombre:";
            // 
            // DTGdetalles
            // 
            this.DTGdetalles.AllowUserToAddRows = false;
            this.DTGdetalles.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DTGdetalles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DTGdetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DTGdetalles.DefaultCellStyle = dataGridViewCellStyle2;
            this.DTGdetalles.EnableHeadersVisualStyles = false;
            this.DTGdetalles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.DTGdetalles.Location = new System.Drawing.Point(25, 232);
            this.DTGdetalles.Name = "DTGdetalles";
            this.DTGdetalles.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DTGdetalles.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DTGdetalles.Size = new System.Drawing.Size(794, 161);
            this.DTGdetalles.TabIndex = 64;
            // 
            // btncargar
            // 
            this.btncargar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btncargar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btncargar.Location = new System.Drawing.Point(619, 5);
            this.btncargar.Name = "btncargar";
            this.btncargar.Size = new System.Drawing.Size(75, 23);
            this.btncargar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btncargar.TabIndex = 65;
            this.btncargar.Text = "Cargar";
            this.btncargar.Click += new System.EventHandler(this.btncargar_Click);
            // 
            // DTPfechainicio
            // 
            this.DTPfechainicio.Location = new System.Drawing.Point(89, 5);
            this.DTPfechainicio.Name = "DTPfechainicio";
            this.DTPfechainicio.Size = new System.Drawing.Size(200, 20);
            this.DTPfechainicio.TabIndex = 66;
            // 
            // DTPfechafinal
            // 
            this.DTPfechafinal.Location = new System.Drawing.Point(375, 5);
            this.DTPfechafinal.Name = "DTPfechafinal";
            this.DTPfechafinal.Size = new System.Drawing.Size(200, 20);
            this.DTPfechafinal.TabIndex = 67;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(25, 6);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(56, 23);
            this.labelX2.TabIndex = 68;
            this.labelX2.Text = "Periodo:";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(313, 2);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(56, 23);
            this.labelX3.TabIndex = 69;
            this.labelX3.Text = "Al:";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(25, 399);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(89, 23);
            this.labelX4.TabIndex = 70;
            this.labelX4.Text = "Subtotal:";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(312, 399);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(89, 23);
            this.labelX5.TabIndex = 71;
            this.labelX5.Text = "IVA:";
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(697, 399);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(32, 23);
            this.labelX6.TabIndex = 72;
            this.labelX6.Text = "Total:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(728, 426);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 37);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 63;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGuardar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(463, 426);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(99, 37);
            this.btnGuardar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGuardar.TabIndex = 60;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGenerar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGenerar.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerar.Image")));
            this.btnGenerar.Location = new System.Drawing.Point(593, 426);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(100, 37);
            this.btnGenerar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGenerar.TabIndex = 59;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // lblsubtotal
            // 
            this.lblsubtotal.AutoSize = true;
            this.lblsubtotal.Location = new System.Drawing.Point(84, 404);
            this.lblsubtotal.Name = "lblsubtotal";
            this.lblsubtotal.Size = new System.Drawing.Size(28, 13);
            this.lblsubtotal.TabIndex = 73;
            this.lblsubtotal.Text = "0.00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(356, 404);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 74;
            this.label1.Text = "0.00";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(768, 404);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(28, 13);
            this.lblTotal.TabIndex = 75;
            this.lblTotal.Text = "0.00";
            // 
            // lbldescuento
            // 
            this.lbldescuento.AutoSize = true;
            this.lbldescuento.Location = new System.Drawing.Point(616, 404);
            this.lbldescuento.Name = "lbldescuento";
            this.lbldescuento.Size = new System.Drawing.Size(28, 13);
            this.lbldescuento.TabIndex = 77;
            this.lbldescuento.Text = "0.00";
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(495, 399);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(56, 23);
            this.labelX7.TabIndex = 76;
            this.labelX7.Text = "Descuento:";
            this.labelX7.Click += new System.EventHandler(this.labelX7_Click);
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(272, 173);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(89, 23);
            this.labelX8.TabIndex = 79;
            this.labelX8.Text = "Forma de pago";
            // 
            // CMBFORMADEPAGO
            // 
            this.CMBFORMADEPAGO.DataSource = this.fpagoBindingSource;
            this.CMBFORMADEPAGO.DisplayMember = "CDESPAGO";
            this.CMBFORMADEPAGO.FormattingEnabled = true;
            this.CMBFORMADEPAGO.Location = new System.Drawing.Point(372, 174);
            this.CMBFORMADEPAGO.Name = "CMBFORMADEPAGO";
            this.CMBFORMADEPAGO.Size = new System.Drawing.Size(203, 21);
            this.CMBFORMADEPAGO.TabIndex = 80;
            this.CMBFORMADEPAGO.ValueMember = "CCODPAGO";
            this.CMBFORMADEPAGO.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // fpagoBindingSource
            // 
            this.fpagoBindingSource.DataMember = "fpago";
            this.fpagoBindingSource.DataSource = this.predialchicoDataSetBindingSource;
            // 
            // predialchicoDataSetBindingSource
            // 
            this.predialchicoDataSetBindingSource.DataSource = this.predialchicoDataSet;
            this.predialchicoDataSetBindingSource.Position = 0;
            // 
            // predialchicoDataSet
            // 
            this.predialchicoDataSet.DataSetName = "predialchicoDataSet";
            this.predialchicoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fpagoTableAdapter
            // 
            this.fpagoTableAdapter.ClearBeforeFill = true;
            // 
            // FrmFacturadeldia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 466);
            this.Controls.Add(this.CMBFORMADEPAGO);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.lbldescuento);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblsubtotal);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.DTPfechafinal);
            this.Controls.Add(this.DTPfechainicio);
            this.Controls.Add(this.btncargar);
            this.Controls.Add(this.DTGdetalles);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.txtPais);
            this.Controls.Add(this.txtDelegacion);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtRFC);
            this.Controls.Add(this.txtCP);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtPoblacion);
            this.Controls.Add(this.txtColonia);
            this.Controls.Add(this.txtNoInterior);
            this.Controls.Add(this.txtNoExterior);
            this.Controls.Add(this.txtCalle);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblPais);
            this.Controls.Add(this.lblDelegacion);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblRFC);
            this.Controls.Add(this.lblCP);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblPoblacion);
            this.Controls.Add(this.lblColonia);
            this.Controls.Add(this.lblNoInterior);
            this.Controls.Add(this.lblNoExterior);
            this.Controls.Add(this.lblCalle);
            this.Controls.Add(this.lblNombre);
            this.DoubleBuffered = true;
            this.Name = "FrmFacturadeldia";
            this.Text = "Factura por periodo";
            this.Load += new System.EventHandler(this.FrmFacturadeldia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DTGdetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpagoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.predialchicoDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.predialchicoDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnCancelar;
        private DevComponents.DotNetBar.Controls.TextBoxX txtObservaciones;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnGuardar;
        private DevComponents.DotNetBar.ButtonX btnGenerar;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPais;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDelegacion;
        private DevComponents.DotNetBar.Controls.TextBoxX txtEmail;
        private DevComponents.DotNetBar.Controls.TextBoxX txtRFC;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCP;
        private DevComponents.DotNetBar.Controls.TextBoxX txtEstado;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPoblacion;
        private DevComponents.DotNetBar.Controls.TextBoxX txtColonia;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNoInterior;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNoExterior;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCalle;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNombre;
        private DevComponents.DotNetBar.LabelX lblPais;
        private DevComponents.DotNetBar.LabelX lblDelegacion;
        private DevComponents.DotNetBar.LabelX lblEmail;
        private DevComponents.DotNetBar.LabelX lblRFC;
        private DevComponents.DotNetBar.LabelX lblCP;
        private DevComponents.DotNetBar.LabelX lblEstado;
        private DevComponents.DotNetBar.LabelX lblPoblacion;
        private DevComponents.DotNetBar.LabelX lblColonia;
        private DevComponents.DotNetBar.LabelX lblNoInterior;
        private DevComponents.DotNetBar.LabelX lblNoExterior;
        private DevComponents.DotNetBar.LabelX lblCalle;
        private DevComponents.DotNetBar.LabelX lblNombre;
        private DevComponents.DotNetBar.Controls.DataGridViewX DTGdetalles;
        private DevComponents.DotNetBar.ButtonX btncargar;
        private System.Windows.Forms.DateTimePicker DTPfechainicio;
        private System.Windows.Forms.DateTimePicker DTPfechafinal;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
        private System.Windows.Forms.Label lblsubtotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lbldescuento;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX8;
        private System.Windows.Forms.ComboBox CMBFORMADEPAGO;
        private System.Windows.Forms.BindingSource predialchicoDataSetBindingSource;
        private predialchicoDataSet predialchicoDataSet;
        private System.Windows.Forms.BindingSource fpagoBindingSource;
        private predialchicoDataSetTableAdapters.fpagoTableAdapter fpagoTableAdapter;
    }
}