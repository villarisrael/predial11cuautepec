﻿namespace Predial10.Recaudacion
{
    partial class frmrecaudacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmrecaudacion));
            this.fechaini = new DevComponents.Editors.DateTimeAdv.MonthCalendarAdv();
            this.fechafin = new DevComponents.Editors.DateTimeAdv.MonthCalendarAdv();
            this.reflectionLabel1 = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cmboficina = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbcaja = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btncerrar = new DevComponents.DotNetBar.ButtonX();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            this.chkExportExcel = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // fechaini
            // 
            this.fechaini.AutoSize = true;
            // 
            // 
            // 
            this.fechaini.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.fechaini.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fechaini.BackgroundStyle.BorderBottomWidth = 1;
            this.fechaini.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.fechaini.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fechaini.BackgroundStyle.BorderLeftWidth = 1;
            this.fechaini.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fechaini.BackgroundStyle.BorderRightWidth = 1;
            this.fechaini.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fechaini.BackgroundStyle.BorderTopWidth = 1;
            this.fechaini.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.fechaini.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fechaini.ContainerControlProcessDialogKey = true;
            this.fechaini.DisplayMonth = new System.DateTime(2013, 3, 1, 0, 0, 0, 0);
            this.fechaini.Location = new System.Drawing.Point(22, 96);
            this.fechaini.Name = "fechaini";
            // 
            // 
            // 
            this.fechaini.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.fechaini.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.fechaini.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.fechaini.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fechaini.Size = new System.Drawing.Size(170, 131);
            this.fechaini.TabIndex = 0;
            this.fechaini.Text = "monthCalendarAdv1";
            // 
            // fechafin
            // 
            this.fechafin.AutoSize = true;
            // 
            // 
            // 
            this.fechafin.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.fechafin.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fechafin.BackgroundStyle.BorderBottomWidth = 1;
            this.fechafin.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.fechafin.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fechafin.BackgroundStyle.BorderLeftWidth = 1;
            this.fechafin.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fechafin.BackgroundStyle.BorderRightWidth = 1;
            this.fechafin.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.fechafin.BackgroundStyle.BorderTopWidth = 1;
            this.fechafin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.fechafin.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fechafin.ContainerControlProcessDialogKey = true;
            this.fechafin.DisplayMonth = new System.DateTime(2013, 3, 1, 0, 0, 0, 0);
            this.fechafin.Location = new System.Drawing.Point(266, 96);
            this.fechafin.Name = "fechafin";
            // 
            // 
            // 
            this.fechafin.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.fechafin.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.fechafin.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.fechafin.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fechafin.Size = new System.Drawing.Size(170, 131);
            this.fechafin.TabIndex = 1;
            this.fechafin.Text = "monthCalendarAdv2";
            // 
            // reflectionLabel1
            // 
            // 
            // 
            // 
            this.reflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.reflectionLabel1.Location = new System.Drawing.Point(158, 12);
            this.reflectionLabel1.Name = "reflectionLabel1";
            this.reflectionLabel1.Size = new System.Drawing.Size(171, 38);
            this.reflectionLabel1.TabIndex = 2;
            this.reflectionLabel1.Text = "<b><font size=\"+6\"><i></i><font color=\"#B02B2C\">Rango a imprimir</font></font></b" +
    ">";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(22, 56);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(170, 31);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "FECHA INICIO";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(266, 56);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(170, 31);
            this.labelX2.TabIndex = 4;
            this.labelX2.Text = "FECHA FINAL";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(22, 312);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = "OFICINA";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(22, 342);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "CAJA";
            // 
            // cmboficina
            // 
            this.cmboficina.DisplayMember = "Text";
            this.cmboficina.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmboficina.FormattingEnabled = true;
            this.cmboficina.ItemHeight = 14;
            this.cmboficina.Location = new System.Drawing.Point(103, 313);
            this.cmboficina.Name = "cmboficina";
            this.cmboficina.Size = new System.Drawing.Size(333, 20);
            this.cmboficina.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmboficina.TabIndex = 7;
            this.cmboficina.SelectedIndexChanged += new System.EventHandler(this.cmboficina_SelectedIndexChanged);
            // 
            // cmbcaja
            // 
            this.cmbcaja.DisplayMember = "Text";
            this.cmbcaja.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbcaja.FormattingEnabled = true;
            this.cmbcaja.ItemHeight = 14;
            this.cmbcaja.Location = new System.Drawing.Point(103, 345);
            this.cmbcaja.Name = "cmbcaja";
            this.cmbcaja.Size = new System.Drawing.Size(333, 20);
            this.cmbcaja.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbcaja.TabIndex = 8;
            // 
            // btncerrar
            // 
            this.btncerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btncerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btncerrar.Image = ((System.Drawing.Image)(resources.GetObject("btncerrar.Image")));
            this.btncerrar.Location = new System.Drawing.Point(347, 385);
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(89, 37);
            this.btncerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btncerrar.TabIndex = 10;
            this.btncerrar.Text = "Cerrar";
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(239, 385);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(102, 37);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btncAceptar_Click);
            // 
            // chkExportExcel
            // 
            this.chkExportExcel.AutoSize = true;
            this.chkExportExcel.Location = new System.Drawing.Point(22, 254);
            this.chkExportExcel.Name = "chkExportExcel";
            this.chkExportExcel.Size = new System.Drawing.Size(103, 17);
            this.chkExportExcel.TabIndex = 11;
            this.chkExportExcel.Text = "Exportar a Excel";
            this.chkExportExcel.UseVisualStyleBackColor = true;
            // 
            // frmrecaudacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 438);
            this.Controls.Add(this.chkExportExcel);
            this.Controls.Add(this.btncerrar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cmbcaja);
            this.Controls.Add(this.cmboficina);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.reflectionLabel1);
            this.Controls.Add(this.fechafin);
            this.Controls.Add(this.fechaini);
            this.DoubleBuffered = true;
            this.Name = "frmrecaudacion";
            this.Text = "Reporte de recaudacion";
            this.Load += new System.EventHandler(this.frmrecaudacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.Editors.DateTimeAdv.MonthCalendarAdv fechaini;
        private DevComponents.Editors.DateTimeAdv.MonthCalendarAdv fechafin;
        private DevComponents.DotNetBar.Controls.ReflectionLabel reflectionLabel1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmboficina;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbcaja;
        private DevComponents.DotNetBar.ButtonX btnAceptar;
        private DevComponents.DotNetBar.ButtonX btncerrar;
        private System.Windows.Forms.CheckBox chkExportExcel;
    }
}