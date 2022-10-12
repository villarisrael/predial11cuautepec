namespace Predial10.caja
{
    partial class frmbuscausuario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtcatastral = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtnombre = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnbuscarnombre = new DevComponents.DotNetBar.ButtonX();
            this.btnbuscarcuenta = new DevComponents.DotNetBar.ButtonX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.dgridusuario = new DevComponents.DotNetBar.Controls.DataGridViewX();
            ((System.ComponentModel.ISupportInitialize)(this.dgridusuario)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Cuenta";
            // 
            // txtcatastral
            // 
            // 
            // 
            // 
            this.txtcatastral.Border.Class = "TextBoxBorder";
            this.txtcatastral.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtcatastral.Location = new System.Drawing.Point(66, 12);
            this.txtcatastral.Name = "txtcatastral";
            this.txtcatastral.Size = new System.Drawing.Size(100, 20);
            this.txtcatastral.TabIndex = 2;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(12, 41);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 4;
            this.labelX2.Text = "Nombre:";
            // 
            // txtnombre
            // 
            // 
            // 
            // 
            this.txtnombre.Border.Class = "TextBoxBorder";
            this.txtnombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtnombre.Location = new System.Drawing.Point(66, 41);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(400, 20);
            this.txtnombre.TabIndex = 5;
            this.txtnombre.TextChanged += new System.EventHandler(this.textBoxX2_TextChanged);
            // 
            // btnbuscarnombre
            // 
            this.btnbuscarnombre.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnbuscarnombre.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnbuscarnombre.Location = new System.Drawing.Point(485, 41);
            this.btnbuscarnombre.Name = "btnbuscarnombre";
            this.btnbuscarnombre.Size = new System.Drawing.Size(29, 23);
            this.btnbuscarnombre.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnbuscarnombre.TabIndex = 6;
            this.btnbuscarnombre.Text = "...";
            this.btnbuscarnombre.Click += new System.EventHandler(this.btnbuscarnombre_Click);
            // 
            // btnbuscarcuenta
            // 
            this.btnbuscarcuenta.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnbuscarcuenta.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnbuscarcuenta.Location = new System.Drawing.Point(184, 9);
            this.btnbuscarcuenta.Name = "btnbuscarcuenta";
            this.btnbuscarcuenta.Size = new System.Drawing.Size(29, 23);
            this.btnbuscarcuenta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnbuscarcuenta.TabIndex = 7;
            this.btnbuscarcuenta.Text = "...";
            this.btnbuscarcuenta.Click += new System.EventHandler(this.btnbuscarcuenta_Click);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(538, 41);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(232, 23);
            this.labelX3.TabIndex = 8;
            this.labelX3.Text = "Ingresa parte del nombre y presiona el botón";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(234, 9);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(232, 23);
            this.labelX4.TabIndex = 9;
            this.labelX4.Text = "Ingresa parte de la cuenta y presiona el botón";
            // 
            // dgridusuario
            // 
            this.dgridusuario.AllowUserToAddRows = false;
            this.dgridusuario.AllowUserToDeleteRows = false;
            this.dgridusuario.AllowUserToOrderColumns = true;
            this.dgridusuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgridusuario.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgridusuario.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgridusuario.Location = new System.Drawing.Point(3, 82);
            this.dgridusuario.Name = "dgridusuario";
            this.dgridusuario.ReadOnly = true;
            this.dgridusuario.Size = new System.Drawing.Size(767, 350);
            this.dgridusuario.TabIndex = 0;
            this.dgridusuario.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgridusuario_CellMouseDoubleClick);
            // 
            // frmbuscausuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 444);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.btnbuscarcuenta);
            this.Controls.Add(this.btnbuscarnombre);
            this.Controls.Add(this.txtnombre);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.txtcatastral);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.dgridusuario);
            this.Name = "frmbuscausuario";
            this.Text = "Buscar usuario";
            this.Load += new System.EventHandler(this.frmbuscausuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgridusuario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtcatastral;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtnombre;
        private DevComponents.DotNetBar.ButtonX btnbuscarnombre;
        private DevComponents.DotNetBar.ButtonX btnbuscarcuenta;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgridusuario;
    }
}