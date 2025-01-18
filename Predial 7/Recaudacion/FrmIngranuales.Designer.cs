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
          
            this.cmnperiodo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkprimer
            // 
            // 
            // 
            // 
            this.chkprimer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkprimer.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkprimer.Location = new System.Drawing.Point(12, 64);
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
            this.chksegundo.Location = new System.Drawing.Point(162, 64);
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
            this.chktercero.Location = new System.Drawing.Point(302, 64);
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
            this.chkcuarto.Location = new System.Drawing.Point(446, 64);
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
            this.chkanual.Location = new System.Drawing.Point(603, 64);
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
            this.btnGenerar.Location = new System.Drawing.Point(12, 124);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(893, 37);
            this.btnGenerar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGenerar.TabIndex = 6;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // cmnperiodo
            // 
            this.cmnperiodo.FormattingEnabled = true;
            this.cmnperiodo.Location = new System.Drawing.Point(87, 17);
            this.cmnperiodo.Name = "cmnperiodo";
            this.cmnperiodo.Size = new System.Drawing.Size(121, 21);
            this.cmnperiodo.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Año";
            // 
            // FrmIngranuales
            // 
            this.ClientSize = new System.Drawing.Size(966, 215);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmnperiodo);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.chkanual);
            this.Controls.Add(this.chkcuarto);
            this.Controls.Add(this.chktercero);
            this.Controls.Add(this.chksegundo);
            this.Controls.Add(this.chkprimer);
            this.DoubleBuffered = true;
            this.Name = "FrmIngranuales";
            this.Text = "Ingresos Anuales";
            this.Load += new System.EventHandler(this.FrmIngranuales_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.CheckBoxX chkprimer;
        private DevComponents.DotNetBar.Controls.CheckBoxX chksegundo;
        private DevComponents.DotNetBar.Controls.CheckBoxX chktercero;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkcuarto;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkanual;
        private DevComponents.DotNetBar.ButtonX btnGenerar;
      
        private System.Windows.Forms.ComboBox cmnperiodo;
        private System.Windows.Forms.Label label1;
    }
}