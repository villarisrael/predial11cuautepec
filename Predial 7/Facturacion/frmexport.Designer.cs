﻿namespace Predial10.Facturacion
{
    partial class frmexport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmexport));
            this.txtarchivo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnfiledialog = new DevComponents.DotNetBar.ButtonX();
            this.btnaceptar = new DevComponents.DotNetBar.ButtonX();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // txtarchivo
            // 
            // 
            // 
            // 
            this.txtarchivo.Border.Class = "TextBoxBorder";
            this.txtarchivo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtarchivo.Location = new System.Drawing.Point(104, 34);
            this.txtarchivo.Name = "txtarchivo";
            this.txtarchivo.Size = new System.Drawing.Size(367, 20);
            this.txtarchivo.TabIndex = 0;
            // 
            // btnfiledialog
            // 
            this.btnfiledialog.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnfiledialog.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnfiledialog.Location = new System.Drawing.Point(490, 34);
            this.btnfiledialog.Name = "btnfiledialog";
            this.btnfiledialog.Size = new System.Drawing.Size(44, 23);
            this.btnfiledialog.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnfiledialog.TabIndex = 1;
            this.btnfiledialog.Text = "...";
            this.btnfiledialog.Click += new System.EventHandler(this.btnfiledialog_Click);
            // 
            // btnaceptar
            // 
            this.btnaceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnaceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnaceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnaceptar.Image")));
            this.btnaceptar.Location = new System.Drawing.Point(288, 84);
            this.btnaceptar.Name = "btnaceptar";
            this.btnaceptar.Size = new System.Drawing.Size(104, 37);
            this.btnaceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnaceptar.TabIndex = 2;
            this.btnaceptar.Text = "Aceptar";
            this.btnaceptar.Click += new System.EventHandler(this.btnaceptar_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(23, 34);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "Archivo";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Image = ((System.Drawing.Image)(resources.GetObject("buttonX1.Image")));
            this.buttonX1.Location = new System.Drawing.Point(399, 84);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(122, 37);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 4;
            this.buttonX1.Text = "Cancelar";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // frmexport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 122);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btnaceptar);
            this.Controls.Add(this.btnfiledialog);
            this.Controls.Add(this.txtarchivo);
            this.DoubleBuffered = true;
            this.Name = "frmexport";
            this.Text = "Escribir el archivo Xml";
            this.Load += new System.EventHandler(this.frmexport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtarchivo;
        private DevComponents.DotNetBar.ButtonX btnfiledialog;
        private DevComponents.DotNetBar.ButtonX btnaceptar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
    }
}