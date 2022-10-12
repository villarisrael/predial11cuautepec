namespace Catalogo2
{
    partial class Frmfrac
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
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.Btncancelar = new DevComponents.DotNetBar.ButtonX();
            this.Btnaceptar = new DevComponents.DotNetBar.ButtonX();
            this.Txtnombre = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.Txtidfrac = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.Btncancelar);
            this.groupPanel1.Controls.Add(this.Btnaceptar);
          //  this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(129, 134);
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
            this.groupPanel1.TabIndex = 26;
            this.groupPanel1.Text = "Opciones";
            // 
            // Btncancelar
            // 
            this.Btncancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Btncancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
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
            this.Btnaceptar.Location = new System.Drawing.Point(23, 35);
            this.Btnaceptar.Name = "Btnaceptar";
            this.Btnaceptar.Size = new System.Drawing.Size(75, 33);
            this.Btnaceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Btnaceptar.TabIndex = 4;
            this.Btnaceptar.Text = "Aceptar";
            this.Btnaceptar.Click += new System.EventHandler(this.Btnaceptar_Click);
            // 
            // Txtnombre
            // 
            // 
            // 
            // 
            this.Txtnombre.Border.Class = "TextBoxBorder";
            this.Txtnombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Txtnombre.Location = new System.Drawing.Point(188, 71);
            this.Txtnombre.MaxLength = 250;
            this.Txtnombre.Name = "Txtnombre";
            this.Txtnombre.PreventEnterBeep = true;
            this.Txtnombre.Size = new System.Drawing.Size(240, 20);
            this.Txtnombre.TabIndex = 25;
            this.Txtnombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txtnombre_KeyDown);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(31, 71);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(155, 23);
            this.labelX1.TabIndex = 24;
            this.labelX1.Text = "Nombre de Fraccionamiento";
            // 
            // Txtidfrac
            // 
            // 
            // 
            // 
            this.Txtidfrac.Border.Class = "TextBoxBorder";
            this.Txtidfrac.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Txtidfrac.Location = new System.Drawing.Point(144, 16);
            this.Txtidfrac.MaxLength = 3;
            this.Txtidfrac.Name = "Txtidfrac";
            this.Txtidfrac.PreventEnterBeep = true;
            this.Txtidfrac.Size = new System.Drawing.Size(100, 20);
            this.Txtidfrac.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "ID Fraccionamiento";
            // 
            // Frmfrac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 256);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.Txtnombre);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.Txtidfrac);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "Frmfrac";
            this.Text = "Frmfrac";
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX Btncancelar;
        private DevComponents.DotNetBar.ButtonX Btnaceptar;
        public DevComponents.DotNetBar.Controls.TextBoxX Txtnombre;
        private DevComponents.DotNetBar.LabelX labelX1;
        public DevComponents.DotNetBar.Controls.TextBoxX Txtidfrac;
        private System.Windows.Forms.Label label1;
    }
}