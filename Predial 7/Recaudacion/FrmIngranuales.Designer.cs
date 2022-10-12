namespace Predial10.Recaudacion
{
    partial class FrmIngranuales
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
            this.chkprimer = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chksegundo = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chktercero = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkcuarto = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkanual = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnGenerar = new DevComponents.DotNetBar.ButtonX();
            this.CrystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.ReporteAnuales1 = new Predial10.Recaudacion.ReporteAnuales();
            this.SuspendLayout();
            // 
            // chkprimer
            // 
            // 
            // 
            // 
            this.chkprimer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkprimer.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkprimer.Location = new System.Drawing.Point(12, 12);
            this.chkprimer.Name = "chkprimer";
            this.chkprimer.Size = new System.Drawing.Size(100, 23);
            this.chkprimer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkprimer.TabIndex = 0;
            this.chkprimer.Text = "Primer Trimestre";
            // 
            // chksegundo
            // 
            // 
            // 
            // 
            this.chksegundo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chksegundo.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chksegundo.Location = new System.Drawing.Point(162, 12);
            this.chksegundo.Name = "chksegundo";
            this.chksegundo.Size = new System.Drawing.Size(100, 23);
            this.chksegundo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chksegundo.TabIndex = 1;
            this.chksegundo.Text = "Segundo Trimestre";
            // 
            // chktercero
            // 
            // 
            // 
            // 
            this.chktercero.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chktercero.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chktercero.Location = new System.Drawing.Point(302, 12);
            this.chktercero.Name = "chktercero";
            this.chktercero.Size = new System.Drawing.Size(100, 23);
            this.chktercero.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chktercero.TabIndex = 2;
            this.chktercero.Text = "Tercer Trimestre";
            // 
            // chkcuarto
            // 
            // 
            // 
            // 
            this.chkcuarto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkcuarto.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkcuarto.Location = new System.Drawing.Point(446, 12);
            this.chkcuarto.Name = "chkcuarto";
            this.chkcuarto.Size = new System.Drawing.Size(100, 23);
            this.chkcuarto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkcuarto.TabIndex = 3;
            this.chkcuarto.Text = "Cuarto Trimestre";
            // 
            // chkanual
            // 
            // 
            // 
            // 
            this.chkanual.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkanual.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkanual.Checked = true;
            this.chkanual.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkanual.CheckValue = "Y";
            this.chkanual.Location = new System.Drawing.Point(603, 12);
            this.chkanual.Name = "chkanual";
            this.chkanual.Size = new System.Drawing.Size(100, 23);
            this.chkanual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkanual.TabIndex = 4;
            this.chkanual.Text = "Ingreso Anual";
            // 
            // btnGenerar
            // 
            this.btnGenerar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGenerar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGenerar.Location = new System.Drawing.Point(12, 42);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(893, 37);
            this.btnGenerar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGenerar.TabIndex = 6;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // CrystalReportViewer1
            // 
            this.CrystalReportViewer1.ActiveViewIndex = -1;
            this.CrystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrystalReportViewer1.Location = new System.Drawing.Point(12, 96);
            this.CrystalReportViewer1.Name = "CrystalReportViewer1";
            this.CrystalReportViewer1.ShowGroupTreeButton = false;
            this.CrystalReportViewer1.Size = new System.Drawing.Size(893, 399);
            this.CrystalReportViewer1.TabIndex = 7;
            this.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FrmIngranuales
            // 
            this.ClientSize = new System.Drawing.Size(915, 507);
            this.Controls.Add(this.CrystalReportViewer1);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.chkanual);
            this.Controls.Add(this.chkcuarto);
            this.Controls.Add(this.chktercero);
            this.Controls.Add(this.chksegundo);
            this.Controls.Add(this.chkprimer);
            this.DoubleBuffered = true;
            this.Name = "FrmIngranuales";
            this.Text = "Ingresos Anuales";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.CheckBoxX chkprimer;
        private DevComponents.DotNetBar.Controls.CheckBoxX chksegundo;
        private DevComponents.DotNetBar.Controls.CheckBoxX chktercero;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkcuarto;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkanual;
        private DevComponents.DotNetBar.ButtonX btnGenerar;

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrystalReportViewer1;
        private ReporteAnuales ReporteAnuales1;
       
    }
}