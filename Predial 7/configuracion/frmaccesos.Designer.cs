namespace Predial10.configuracion
{
    partial class frmaccesos
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
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.advTree1 = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.columnHeader1 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader2 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader3 = new DevComponents.AdvTree.ColumnHeader();
            this.node1 = new DevComponents.AdvTree.Node();
            this.cell1 = new DevComponents.AdvTree.Cell();
            this.cell2 = new DevComponents.AdvTree.Cell();
            this.btnagregar = new DevComponents.DotNetBar.ButtonItem();
            this.btnvisualizar = new DevComponents.DotNetBar.ButtonItem();
            this.btninha = new DevComponents.DotNetBar.ButtonItem();
            this.columnHeader4 = new DevComponents.AdvTree.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).BeginInit();
            this.SuspendLayout();
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnagregar,
            this.btnvisualizar,
            this.btninha});
            this.bar2.Location = new System.Drawing.Point(2, 2);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(621, 25);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 1;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // advTree1
            // 
            this.advTree1.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree1.AllowDrop = true;
            this.advTree1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.advTree1.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTree1.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree1.Columns.Add(this.columnHeader1);
            this.advTree1.Columns.Add(this.columnHeader2);
            this.advTree1.Columns.Add(this.columnHeader3);
            this.advTree1.Columns.Add(this.columnHeader4);
            this.advTree1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.advTree1.Location = new System.Drawing.Point(2, 33);
            this.advTree1.Name = "advTree1";
            this.advTree1.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1});
            this.advTree1.NodesConnector = this.nodeConnector1;
            this.advTree1.NodeStyle = this.elementStyle1;
            this.advTree1.PathSeparator = ";";
            this.advTree1.Size = new System.Drawing.Size(616, 412);
            this.advTree1.Styles.Add(this.elementStyle1);
            this.advTree1.TabIndex = 2;
            this.advTree1.Text = "advTree1";
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle1
            // 
            this.elementStyle1.Class = "";
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Name = "columnHeader1";
            this.columnHeader1.Text = "Usuario";
            this.columnHeader1.Width.Absolute = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Name = "columnHeader2";
            this.columnHeader2.Text = "Nombre";
            this.columnHeader2.Width.Absolute = 300;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Name = "columnHeader3";
            this.columnHeader3.Text = "Activo";
            this.columnHeader3.Width.Absolute = 150;
            // 
            // node1
            // 
            this.node1.Cells.Add(this.cell1);
            this.node1.Cells.Add(this.cell2);
            this.node1.Expanded = true;
            this.node1.Image = global::Predial10.Properties.Resources.none16;
            this.node1.Name = "node1";
            this.node1.Text = "node1";
            // 
            // cell1
            // 
            this.cell1.Name = "cell1";
            this.cell1.StyleMouseOver = null;
            // 
            // cell2
            // 
            this.cell2.Name = "cell2";
            this.cell2.StyleMouseOver = null;
            // 
            // btnagregar
            // 
            this.btnagregar.Image = global::Predial10.Properties.Resources.ad16;
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Text = "buttonItem1";
            this.btnagregar.Tooltip = "Agregar usuario";
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // btnvisualizar
            // 
            this.btnvisualizar.Image = global::Predial10.Properties.Resources.gtk_edit;
            this.btnvisualizar.Name = "btnvisualizar";
            this.btnvisualizar.Text = "buttonItem2";
            this.btnvisualizar.Click += new System.EventHandler(this.btnvisualizar_Click);
            // 
            // btninha
            // 
            this.btninha.Image = global::Predial10.Properties.Resources.disable;
            this.btninha.Name = "btninha";
            this.btninha.Tooltip = "Botón inhabilitar";
            this.btninha.Click += new System.EventHandler(this.btninha_Click);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Name = "columnHeader4";
            this.columnHeader4.Text = "Column";
            this.columnHeader4.Visible = false;
            this.columnHeader4.Width.Absolute = 150;
            // 
            // frmaccesos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 448);
            this.Controls.Add(this.advTree1);
            this.Controls.Add(this.bar2);
            this.Name = "frmaccesos";
            this.Text = "Cuentas de usuarios";
            this.Load += new System.EventHandler(this.frmaccesos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.ButtonItem btnagregar;
        private DevComponents.DotNetBar.ButtonItem btnvisualizar;
        private DevComponents.AdvTree.AdvTree advTree1;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.AdvTree.ColumnHeader columnHeader1;
        private DevComponents.AdvTree.ColumnHeader columnHeader2;
        private DevComponents.AdvTree.ColumnHeader columnHeader3;
        private DevComponents.AdvTree.Cell cell1;
        private DevComponents.AdvTree.Cell cell2;
        private DevComponents.DotNetBar.ButtonItem btninha;
        private DevComponents.AdvTree.ColumnHeader columnHeader4;

    }
}