
namespace Predial10.CancelacrFacturas_V4
{
    partial class CancelarFacturas_v4
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
            this.lblFolioFiscal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelarFactura = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.cmbMotivosCancelacion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFolioFiscal = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblFolioFiscal
            // 
            this.lblFolioFiscal.AutoSize = true;
            this.lblFolioFiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolioFiscal.Location = new System.Drawing.Point(68, 103);
            this.lblFolioFiscal.Name = "lblFolioFiscal";
            this.lblFolioFiscal.Size = new System.Drawing.Size(89, 16);
            this.lblFolioFiscal.TabIndex = 0;
            this.lblFolioFiscal.Text = "Folio Fiscal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(189, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "CANCELAR FACTURA CFDI 4.0";
            // 
            // btnCancelarFactura
            // 
            this.btnCancelarFactura.Location = new System.Drawing.Point(386, 168);
            this.btnCancelarFactura.Name = "btnCancelarFactura";
            this.btnCancelarFactura.Size = new System.Drawing.Size(104, 23);
            this.btnCancelarFactura.TabIndex = 3;
            this.btnCancelarFactura.Text = "Cancelar Factura";
            this.btnCancelarFactura.UseVisualStyleBackColor = true;
            this.btnCancelarFactura.Click += new System.EventHandler(this.btnCancelarFactura_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(521, 168);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // cmbMotivosCancelacion
            // 
            this.cmbMotivosCancelacion.FormattingEnabled = true;
            this.cmbMotivosCancelacion.Location = new System.Drawing.Point(173, 55);
            this.cmbMotivosCancelacion.Name = "cmbMotivosCancelacion";
            this.cmbMotivosCancelacion.Size = new System.Drawing.Size(404, 21);
            this.cmbMotivosCancelacion.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Motivo Cancelación";
            // 
            // txtFolioFiscal
            // 
            this.txtFolioFiscal.Location = new System.Drawing.Point(173, 103);
            this.txtFolioFiscal.Name = "txtFolioFiscal";
            this.txtFolioFiscal.Size = new System.Drawing.Size(404, 20);
            this.txtFolioFiscal.TabIndex = 7;
            // 
            // CancelarFacturas_v4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 221);
            this.Controls.Add(this.txtFolioFiscal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbMotivosCancelacion);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelarFactura);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFolioFiscal);
            this.Name = "CancelarFacturas_v4";
            this.Text = "CancelarFacturas_v4";
            this.Load += new System.EventHandler(this.CancelarFacturas_v4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFolioFiscal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelarFactura;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ComboBox cmbMotivosCancelacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFolioFiscal;
    }
}