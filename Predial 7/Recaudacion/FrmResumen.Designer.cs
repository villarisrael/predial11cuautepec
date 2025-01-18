
namespace Predial10.Recaudacion
{
    partial class FrmResumen
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
            this.btngenerarreporte = new DevComponents.DotNetBar.ButtonX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.reflectionLabel1 = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.fechafin = new DevComponents.Editors.DateTimeAdv.MonthCalendarAdv();
            this.fechaini = new DevComponents.Editors.DateTimeAdv.MonthCalendarAdv();
            this.SuspendLayout();
            // 
            // btngenerarreporte
            // 
            this.btngenerarreporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btngenerarreporte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btngenerarreporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btngenerarreporte.Location = new System.Drawing.Point(6, 186);
            this.btngenerarreporte.Name = "btngenerarreporte";
            this.btngenerarreporte.Size = new System.Drawing.Size(786, 26);
            this.btngenerarreporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btngenerarreporte.TabIndex = 17;
            this.btngenerarreporte.Text = "Generar Reporte";
            this.btngenerarreporte.Click += new System.EventHandler(this.btngenerarreporte_Click);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(391, 61);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(170, 31);
            this.labelX2.TabIndex = 16;
            this.labelX2.Text = "FECHA FINAL";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(13, 65);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(170, 31);
            this.labelX1.TabIndex = 15;
            this.labelX1.Text = "FECHA INICIO";
            // 
            // reflectionLabel1
            // 
            // 
            // 
            // 
            this.reflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.reflectionLabel1.Location = new System.Drawing.Point(12, 21);
            this.reflectionLabel1.Name = "reflectionLabel1";
            this.reflectionLabel1.Size = new System.Drawing.Size(171, 38);
            this.reflectionLabel1.TabIndex = 14;
            this.reflectionLabel1.Text = "<b><font size=\"+6\"><i></i><font color=\"#B02B2C\">Rango a imprimir</font></font></b" +
    ">";
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
            this.fechafin.Location = new System.Drawing.Point(590, 33);
            this.fechafin.Name = "fechafin";
            // 
            // 
            // 
            this.fechafin.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.fechafin.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.fechafin.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.fechafin.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fechafin.Size = new System.Drawing.Size(170, 131);
            this.fechafin.TabIndex = 13;
            this.fechafin.Text = "monthCalendarAdv2";
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
            this.fechaini.Location = new System.Drawing.Point(201, 33);
            this.fechaini.Name = "fechaini";
            // 
            // 
            // 
            this.fechaini.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.fechaini.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.fechaini.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.fechaini.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fechaini.Size = new System.Drawing.Size(170, 131);
            this.fechaini.TabIndex = 12;
            this.fechaini.Text = "monthCalendarAdv1";
            // 
            // FrmResumen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 238);
            this.Controls.Add(this.btngenerarreporte);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.reflectionLabel1);
            this.Controls.Add(this.fechafin);
            this.Controls.Add(this.fechaini);
            this.DoubleBuffered = true;
            this.Name = "FrmResumen";
            this.Text = "Resumen de Ingresos x Dia";
            this.Load += new System.EventHandler(this.FrmResumen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btngenerarreporte;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ReflectionLabel reflectionLabel1;
        private DevComponents.Editors.DateTimeAdv.MonthCalendarAdv fechafin;
        private DevComponents.Editors.DateTimeAdv.MonthCalendarAdv fechaini;
    }
}