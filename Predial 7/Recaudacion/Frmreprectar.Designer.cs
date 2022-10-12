namespace Predial10.PadronUsuarios
{
    partial class Frmreprectar
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
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.reflectionLabel1 = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.fechafin = new DevComponents.Editors.DateTimeAdv.MonthCalendarAdv();
            this.fechaini = new DevComponents.Editors.DateTimeAdv.MonthCalendarAdv();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
         //   this.Rptingtar1 = new Predial10.Reportes.Rptingtar();
            this.btngenerarreporte = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(391, 52);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(170, 31);
            this.labelX2.TabIndex = 9;
            this.labelX2.Text = "FECHA FINAL";
            this.labelX2.Click += new System.EventHandler(this.labelX2_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(13, 56);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(170, 31);
            this.labelX1.TabIndex = 8;
            this.labelX1.Text = "FECHA INICIO";
            this.labelX1.Click += new System.EventHandler(this.labelX1_Click);
            // 
            // reflectionLabel1
            // 
            // 
            // 
            // 
            this.reflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.reflectionLabel1.Location = new System.Drawing.Point(12, 12);
            this.reflectionLabel1.Name = "reflectionLabel1";
            this.reflectionLabel1.Size = new System.Drawing.Size(171, 38);
            this.reflectionLabel1.TabIndex = 7;
            this.reflectionLabel1.Text = "<b><font size=\"+6\"><i></i><font color=\"#B02B2C\">Rango a imprimir</font></font></b" +
                ">";
            this.reflectionLabel1.Click += new System.EventHandler(this.reflectionLabel1_Click);
            // 
            // fechafin
            // 
            this.fechafin.AnnuallyMarkedDates = new System.DateTime[0];
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
            this.fechafin.Location = new System.Drawing.Point(590, 24);
            this.fechafin.MarkedDates = new System.DateTime[0];
            this.fechafin.MonthlyMarkedDates = new System.DateTime[0];
            this.fechafin.Name = "fechafin";
            // 
            // 
            // 
            this.fechafin.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.fechafin.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.fechafin.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.fechafin.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fechafin.Size = new System.Drawing.Size(170, 131);
            this.fechafin.TabIndex = 6;
            this.fechafin.Text = "monthCalendarAdv2";
            this.fechafin.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.fechafin.ItemClick += new System.EventHandler(this.fechafin_ItemClick);
            // 
            // fechaini
            // 
            this.fechaini.AnnuallyMarkedDates = new System.DateTime[0];
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
            this.fechaini.Location = new System.Drawing.Point(201, 24);
            this.fechaini.MarkedDates = new System.DateTime[0];
            this.fechaini.MonthlyMarkedDates = new System.DateTime[0];
            this.fechaini.Name = "fechaini";
            // 
            // 
            // 
            this.fechaini.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.fechaini.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.fechaini.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.fechaini.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.fechaini.Size = new System.Drawing.Size(170, 131);
            this.fechaini.TabIndex = 5;
            this.fechaini.Text = "monthCalendarAdv1";
            this.fechaini.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.fechaini.ItemClick += new System.EventHandler(this.fechaini_ItemClick);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(-10, 193);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowGroupTreeButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(798, 388);
            this.crystalReportViewer1.TabIndex = 10;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer1.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // btngenerarreporte
            // 
            this.btngenerarreporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btngenerarreporte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btngenerarreporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btngenerarreporte.Location = new System.Drawing.Point(2, 161);
            this.btngenerarreporte.Name = "btngenerarreporte";
            this.btngenerarreporte.Size = new System.Drawing.Size(786, 26);
            this.btngenerarreporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btngenerarreporte.TabIndex = 11;
            this.btngenerarreporte.Text = "Generar Reporte";
            this.btngenerarreporte.Click += new System.EventHandler(this.btngenerarreporte_Click);
            // 
            // Frmreprectar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 593);
            this.Controls.Add(this.btngenerarreporte);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.reflectionLabel1);
            this.Controls.Add(this.fechafin);
            this.Controls.Add(this.fechaini);
            this.DoubleBuffered = true;
            this.Name = "Frmreprectar";
            this.Text = "Reporte de recaudación por tarifa";
            this.Load += new System.EventHandler(this.Frmreprectar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ReflectionLabel reflectionLabel1;
        private DevComponents.Editors.DateTimeAdv.MonthCalendarAdv fechafin;
        private DevComponents.Editors.DateTimeAdv.MonthCalendarAdv fechaini;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private DevComponents.DotNetBar.ButtonX btngenerarreporte;
       // private Rptingtar Rptingtar1;

    }
}