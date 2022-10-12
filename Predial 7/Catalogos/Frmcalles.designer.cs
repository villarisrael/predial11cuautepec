namespace Predial10.Catalogos
{
    partial class Frmcalles
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtidcalle = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtnombre = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.Btncancelar = new DevComponents.DotNetBar.ButtonX();
            this.Btnaceptar = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Calle";
            // 
            // txtidcalle
            // 
            // 
            // 
            // 
            this.txtidcalle.Border.Class = "TextBoxBorder";
            this.txtidcalle.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtidcalle.Location = new System.Drawing.Point(145, 36);
            this.txtidcalle.MaxLength = 3;
            this.txtidcalle.Name = "txtidcalle";
            this.txtidcalle.PreventEnterBeep = true;
            this.txtidcalle.Size = new System.Drawing.Size(100, 20);
            this.txtidcalle.TabIndex = 1;
            this.txtidcalle.TextChanged += new System.EventHandler(this.txtidcalle_TextChanged);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(27, 86);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(100, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "Nombre de calle";
            this.labelX1.Click += new System.EventHandler(this.labelX1_Click);
            // 
            // txtnombre
            // 
            // 
            // 
            // 
            this.txtnombre.Border.Class = "TextBoxBorder";
            this.txtnombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtnombre.Location = new System.Drawing.Point(145, 86);
            this.txtnombre.MaxLength = 250;
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.PreventEnterBeep = true;
            this.txtnombre.Size = new System.Drawing.Size(210, 20);
            this.txtnombre.TabIndex = 3;
            this.txtnombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtnombre_KeyDown);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.Btncancelar);
            this.groupPanel1.Controls.Add(this.Btnaceptar);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(164, 112);
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
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 6;
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
            this.Btncancelar.TabIndex = 5;
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
            this.Btnaceptar.TabIndex = 4;
            this.Btnaceptar.Text = "Aceptar";
            this.Btnaceptar.Click += new System.EventHandler(this.Btnaceptar_Click);
            // 
            // Frmcalles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 231);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.txtnombre);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtidcalle);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "Frmcalles";
            this.Text = "Datos de Calle";
            this.Load += new System.EventHandler(this.Frmcalles_Load);
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public DevComponents.DotNetBar.Controls.TextBoxX txtidcalle;
        private DevComponents.DotNetBar.LabelX labelX1;
        public DevComponents.DotNetBar.Controls.TextBoxX txtnombre;
        private DevComponents.DotNetBar.ButtonX Btnaceptar;
        private DevComponents.DotNetBar.ButtonX Btncancelar;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
    }
}