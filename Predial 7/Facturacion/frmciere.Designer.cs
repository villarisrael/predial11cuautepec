﻿namespace Predial10.Facturacion
{
    partial class frmcierre
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
            this.reflectionLabel1 = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.progressBarX1 = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.btnhacer = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.lblusuarios = new DevComponents.DotNetBar.LabelX();
            this.btncerrar = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // reflectionLabel1
            // 
            // 
            // 
            // 
            this.reflectionLabel1.BackgroundStyle.Class = "";
            this.reflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.reflectionLabel1.Location = new System.Drawing.Point(22, 13);
            this.reflectionLabel1.Name = "reflectionLabel1";
            this.reflectionLabel1.Size = new System.Drawing.Size(249, 42);
            this.reflectionLabel1.TabIndex = 0;
            this.reflectionLabel1.Text = "<b><font size=\"+6\"><i>Cierre de </i><font color=\"#B02B2C\"> Facturacion</font></fo" +
                "nt></b>";
            // 
            // progressBarX1
            // 
            // 
            // 
            // 
            this.progressBarX1.BackgroundStyle.Class = "";
            this.progressBarX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressBarX1.Location = new System.Drawing.Point(22, 62);
            this.progressBarX1.Name = "progressBarX1";
            this.progressBarX1.Size = new System.Drawing.Size(373, 23);
            this.progressBarX1.TabIndex = 1;
            this.progressBarX1.Text = "progressBarX1";
            // 
            // btnhacer
            // 
            this.btnhacer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnhacer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnhacer.Location = new System.Drawing.Point(229, 91);
            this.btnhacer.Name = "btnhacer";
            this.btnhacer.Size = new System.Drawing.Size(75, 23);
            this.btnhacer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnhacer.TabIndex = 2;
            this.btnhacer.Text = "Comenzar";
            this.btnhacer.Click += new System.EventHandler(this.btnhacer_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(253, 33);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(51, 23);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "Usuarios";
            // 
            // lblusuarios
            // 
            // 
            // 
            // 
            this.lblusuarios.BackgroundStyle.Class = "";
            this.lblusuarios.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblusuarios.Location = new System.Drawing.Point(320, 38);
            this.lblusuarios.Name = "lblusuarios";
            this.lblusuarios.Size = new System.Drawing.Size(51, 13);
            this.lblusuarios.TabIndex = 4;
            this.lblusuarios.Text = "0";
            this.lblusuarios.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btncerrar
            // 
            this.btncerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btncerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btncerrar.Location = new System.Drawing.Point(320, 91);
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(75, 23);
            this.btncerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btncerrar.TabIndex = 5;
            this.btncerrar.Text = "Cerrar";
            this.btncerrar.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // frmcierre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 130);
            this.Controls.Add(this.btncerrar);
            this.Controls.Add(this.lblusuarios);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btnhacer);
            this.Controls.Add(this.progressBarX1);
            this.Controls.Add(this.reflectionLabel1);
            this.Name = "frmcierre";
            this.Text = "Calculo de aduedos a la fecha";
            this.Load += new System.EventHandler(this.frmcierre_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ReflectionLabel reflectionLabel1;
        private DevComponents.DotNetBar.Controls.ProgressBarX progressBarX1;
        private DevComponents.DotNetBar.ButtonX btnhacer;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX lblusuarios;
        private DevComponents.DotNetBar.ButtonX btncerrar;

    }
}