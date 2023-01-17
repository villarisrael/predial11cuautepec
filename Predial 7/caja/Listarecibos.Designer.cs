using System.Windows.Forms;
namespace Predial10.caja
{
    partial class Listarecibos
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Listarecibos));
            this.superTabrecibos = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btncancelarrecibo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idReciboMaestroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ubicacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iVADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.canceladoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccodofiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cajaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechainicialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descuentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catastralDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idformapagoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcDescuentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcdescuentorecargosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descuentorecargosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipodescuentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorfiscalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuariosisDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechafinalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Facturado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recibomaestroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.predialchicoDataSet = new Predial10.predialchicoDataSet();
            this.Maestro = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.advDetalles = new DevComponents.AdvTree.AdvTree();
            this.node1 = new DevComponents.AdvTree.Node();
            this.nodeConnector2 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            this.Esclavo = new DevComponents.DotNetBar.SuperTabItem();
            this.btnAceptar = new DevComponents.DotNetBar.ButtonX();
            this.cmbCajas = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbOficina = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.btncerrar = new DevComponents.DotNetBar.ButtonX();
            this.dtinicio = new System.Windows.Forms.DateTimePicker();
            this.dtfinal = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Lbltotal = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnrenumerar = new DevComponents.DotNetBar.ButtonX();
            this.iisumando = new DevComponents.Editors.IntegerInput();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.iifinal = new DevComponents.Editors.IntegerInput();
            this.iiinicio = new DevComponents.Editors.IntegerInput();
            this.recibomaestroTableAdapter = new Predial10.predialchicoDataSetTableAdapters.recibomaestroTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.superTabrecibos)).BeginInit();
            this.superTabrecibos.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recibomaestroBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.predialchicoDataSet)).BeginInit();
            this.superTabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advDetalles)).BeginInit();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iisumando)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iifinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iiinicio)).BeginInit();
            this.SuspendLayout();
            // 
            // superTabrecibos
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabrecibos.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabrecibos.ControlBox.MenuBox.Name = "";
            this.superTabrecibos.ControlBox.Name = "";
            this.superTabrecibos.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabrecibos.ControlBox.MenuBox,
            this.superTabrecibos.ControlBox.CloseBox});
            this.superTabrecibos.Controls.Add(this.superTabControlPanel1);
            this.superTabrecibos.Controls.Add(this.superTabControlPanel2);
            this.superTabrecibos.Location = new System.Drawing.Point(12, 64);
            this.superTabrecibos.Name = "superTabrecibos";
            this.superTabrecibos.ReorderTabsEnabled = true;
            this.superTabrecibos.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.superTabrecibos.SelectedTabIndex = 0;
            this.superTabrecibos.Size = new System.Drawing.Size(730, 370);
            this.superTabrecibos.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superTabrecibos.TabIndex = 0;
            this.superTabrecibos.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Maestro,
            this.Esclavo});
            this.superTabrecibos.Text = "superTabControl1";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.toolStrip1);
            this.superTabControlPanel1.Controls.Add(this.dataGridView1);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(730, 345);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.Maestro;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btncancelarrecibo,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripButton1,
            this.toolStripLabel2,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(730, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btncancelarrecibo
            // 
            this.btncancelarrecibo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btncancelarrecibo.Image = global::Predial10.Properties.Resources.disable;
            this.btncancelarrecibo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btncancelarrecibo.Name = "btncancelarrecibo";
            this.btncancelarrecibo.Size = new System.Drawing.Size(23, 22);
            this.btncancelarrecibo.Text = "toolStripButton1";
            this.btncancelarrecibo.ToolTipText = "Cancelar recibo";
            this.btncancelarrecibo.Click += new System.EventHandler(this.btncancelarrecibo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(212, 22);
            this.toolStripLabel1.Text = "Utiliza este con cuidado borra recibo->";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Predial10.Properties.Resources.DeleteRed;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Borra el recibo permanentemente";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(148, 22);
            this.toolStripLabel2.Text = "Marcar como facturado ->";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::Predial10.Properties.Resources.verify;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Marcar como facturado";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::Predial10.Properties.Resources.none16;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Desmarca el numero de factura";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Facturar";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idReciboMaestroDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.folioDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.direccion1DataGridViewTextBoxColumn,
            this.direccion2DataGridViewTextBoxColumn,
            this.ubicacionDataGridViewTextBoxColumn,
            this.subtotalDataGridViewTextBoxColumn,
            this.iVADataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn,
            this.serieDataGridViewTextBoxColumn,
            this.canceladoDataGridViewTextBoxColumn,
            this.ccodofiDataGridViewTextBoxColumn,
            this.cajaDataGridViewTextBoxColumn,
            this.fechainicialDataGridViewTextBoxColumn,
            this.descuentoDataGridViewTextBoxColumn,
            this.catastralDataGridViewTextBoxColumn,
            this.idformapagoDataGridViewTextBoxColumn,
            this.porcDescuentoDataGridViewTextBoxColumn,
            this.porcdescuentorecargosDataGridViewTextBoxColumn,
            this.descuentorecargosDataGridViewTextBoxColumn,
            this.tipodescuentoDataGridViewTextBoxColumn,
            this.valorfiscalDataGridViewTextBoxColumn,
            this.usuariosisDataGridViewTextBoxColumn,
            this.fechafinalDataGridViewTextBoxColumn,
            this.Facturado});
            this.dataGridView1.DataSource = this.recibomaestroBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(719, 308);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_UserDeletedRow);
            // 
            // idReciboMaestroDataGridViewTextBoxColumn
            // 
            this.idReciboMaestroDataGridViewTextBoxColumn.DataPropertyName = "idReciboMaestro";
            this.idReciboMaestroDataGridViewTextBoxColumn.HeaderText = "idReciboMaestro";
            this.idReciboMaestroDataGridViewTextBoxColumn.Name = "idReciboMaestroDataGridViewTextBoxColumn";
            this.idReciboMaestroDataGridViewTextBoxColumn.ReadOnly = true;
            this.idReciboMaestroDataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "fecha";
            this.fechaDataGridViewTextBoxColumn.HeaderText = "fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // folioDataGridViewTextBoxColumn
            // 
            this.folioDataGridViewTextBoxColumn.DataPropertyName = "folio";
            this.folioDataGridViewTextBoxColumn.HeaderText = "folio";
            this.folioDataGridViewTextBoxColumn.Name = "folioDataGridViewTextBoxColumn";
            this.folioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // direccion1DataGridViewTextBoxColumn
            // 
            this.direccion1DataGridViewTextBoxColumn.DataPropertyName = "Direccion1";
            this.direccion1DataGridViewTextBoxColumn.HeaderText = "Direccion1";
            this.direccion1DataGridViewTextBoxColumn.Name = "direccion1DataGridViewTextBoxColumn";
            this.direccion1DataGridViewTextBoxColumn.ReadOnly = true;
            this.direccion1DataGridViewTextBoxColumn.Visible = false;
            // 
            // direccion2DataGridViewTextBoxColumn
            // 
            this.direccion2DataGridViewTextBoxColumn.DataPropertyName = "Direccion2";
            this.direccion2DataGridViewTextBoxColumn.HeaderText = "Direccion2";
            this.direccion2DataGridViewTextBoxColumn.Name = "direccion2DataGridViewTextBoxColumn";
            this.direccion2DataGridViewTextBoxColumn.ReadOnly = true;
            this.direccion2DataGridViewTextBoxColumn.Visible = false;
            // 
            // ubicacionDataGridViewTextBoxColumn
            // 
            this.ubicacionDataGridViewTextBoxColumn.DataPropertyName = "Ubicacion";
            this.ubicacionDataGridViewTextBoxColumn.HeaderText = "Ubicacion";
            this.ubicacionDataGridViewTextBoxColumn.Name = "ubicacionDataGridViewTextBoxColumn";
            this.ubicacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // subtotalDataGridViewTextBoxColumn
            // 
            this.subtotalDataGridViewTextBoxColumn.DataPropertyName = "Subtotal";
            this.subtotalDataGridViewTextBoxColumn.HeaderText = "Subtotal";
            this.subtotalDataGridViewTextBoxColumn.Name = "subtotalDataGridViewTextBoxColumn";
            this.subtotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iVADataGridViewTextBoxColumn
            // 
            this.iVADataGridViewTextBoxColumn.DataPropertyName = "IVA";
            this.iVADataGridViewTextBoxColumn.HeaderText = "IVA";
            this.iVADataGridViewTextBoxColumn.Name = "iVADataGridViewTextBoxColumn";
            this.iVADataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // serieDataGridViewTextBoxColumn
            // 
            this.serieDataGridViewTextBoxColumn.DataPropertyName = "serie";
            this.serieDataGridViewTextBoxColumn.HeaderText = "serie";
            this.serieDataGridViewTextBoxColumn.Name = "serieDataGridViewTextBoxColumn";
            this.serieDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // canceladoDataGridViewTextBoxColumn
            // 
            this.canceladoDataGridViewTextBoxColumn.DataPropertyName = "Cancelado";
            this.canceladoDataGridViewTextBoxColumn.HeaderText = "Cancelado";
            this.canceladoDataGridViewTextBoxColumn.Name = "canceladoDataGridViewTextBoxColumn";
            this.canceladoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ccodofiDataGridViewTextBoxColumn
            // 
            this.ccodofiDataGridViewTextBoxColumn.DataPropertyName = "ccodofi";
            this.ccodofiDataGridViewTextBoxColumn.HeaderText = "ccodofi";
            this.ccodofiDataGridViewTextBoxColumn.Name = "ccodofiDataGridViewTextBoxColumn";
            this.ccodofiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cajaDataGridViewTextBoxColumn
            // 
            this.cajaDataGridViewTextBoxColumn.DataPropertyName = "caja";
            this.cajaDataGridViewTextBoxColumn.HeaderText = "caja";
            this.cajaDataGridViewTextBoxColumn.Name = "cajaDataGridViewTextBoxColumn";
            this.cajaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechainicialDataGridViewTextBoxColumn
            // 
            this.fechainicialDataGridViewTextBoxColumn.DataPropertyName = "fecha_inicial";
            this.fechainicialDataGridViewTextBoxColumn.HeaderText = "fecha_inicial";
            this.fechainicialDataGridViewTextBoxColumn.Name = "fechainicialDataGridViewTextBoxColumn";
            this.fechainicialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descuentoDataGridViewTextBoxColumn
            // 
            this.descuentoDataGridViewTextBoxColumn.DataPropertyName = "descuento";
            this.descuentoDataGridViewTextBoxColumn.HeaderText = "descuento";
            this.descuentoDataGridViewTextBoxColumn.Name = "descuentoDataGridViewTextBoxColumn";
            this.descuentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // catastralDataGridViewTextBoxColumn
            // 
            this.catastralDataGridViewTextBoxColumn.DataPropertyName = "catastral";
            this.catastralDataGridViewTextBoxColumn.HeaderText = "catastral";
            this.catastralDataGridViewTextBoxColumn.Name = "catastralDataGridViewTextBoxColumn";
            this.catastralDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idformapagoDataGridViewTextBoxColumn
            // 
            this.idformapagoDataGridViewTextBoxColumn.DataPropertyName = "idformapago";
            this.idformapagoDataGridViewTextBoxColumn.HeaderText = "idformapago";
            this.idformapagoDataGridViewTextBoxColumn.Name = "idformapagoDataGridViewTextBoxColumn";
            this.idformapagoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // porcDescuentoDataGridViewTextBoxColumn
            // 
            this.porcDescuentoDataGridViewTextBoxColumn.DataPropertyName = "PorcDescuento";
            this.porcDescuentoDataGridViewTextBoxColumn.HeaderText = "PorcDescuento";
            this.porcDescuentoDataGridViewTextBoxColumn.Name = "porcDescuentoDataGridViewTextBoxColumn";
            this.porcDescuentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // porcdescuentorecargosDataGridViewTextBoxColumn
            // 
            this.porcdescuentorecargosDataGridViewTextBoxColumn.DataPropertyName = "porcdescuentorecargos";
            this.porcdescuentorecargosDataGridViewTextBoxColumn.HeaderText = "porcdescuentorecargos";
            this.porcdescuentorecargosDataGridViewTextBoxColumn.Name = "porcdescuentorecargosDataGridViewTextBoxColumn";
            this.porcdescuentorecargosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descuentorecargosDataGridViewTextBoxColumn
            // 
            this.descuentorecargosDataGridViewTextBoxColumn.DataPropertyName = "descuentorecargos";
            this.descuentorecargosDataGridViewTextBoxColumn.HeaderText = "descuentorecargos";
            this.descuentorecargosDataGridViewTextBoxColumn.Name = "descuentorecargosDataGridViewTextBoxColumn";
            this.descuentorecargosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipodescuentoDataGridViewTextBoxColumn
            // 
            this.tipodescuentoDataGridViewTextBoxColumn.DataPropertyName = "tipodescuento";
            this.tipodescuentoDataGridViewTextBoxColumn.HeaderText = "tipodescuento";
            this.tipodescuentoDataGridViewTextBoxColumn.Name = "tipodescuentoDataGridViewTextBoxColumn";
            this.tipodescuentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorfiscalDataGridViewTextBoxColumn
            // 
            this.valorfiscalDataGridViewTextBoxColumn.DataPropertyName = "valorfiscal";
            this.valorfiscalDataGridViewTextBoxColumn.HeaderText = "valorfiscal";
            this.valorfiscalDataGridViewTextBoxColumn.Name = "valorfiscalDataGridViewTextBoxColumn";
            this.valorfiscalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuariosisDataGridViewTextBoxColumn
            // 
            this.usuariosisDataGridViewTextBoxColumn.DataPropertyName = "usuariosis";
            this.usuariosisDataGridViewTextBoxColumn.HeaderText = "usuariosis";
            this.usuariosisDataGridViewTextBoxColumn.Name = "usuariosisDataGridViewTextBoxColumn";
            this.usuariosisDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechafinalDataGridViewTextBoxColumn
            // 
            this.fechafinalDataGridViewTextBoxColumn.DataPropertyName = "fecha_final";
            this.fechafinalDataGridViewTextBoxColumn.HeaderText = "fecha_final";
            this.fechafinalDataGridViewTextBoxColumn.Name = "fechafinalDataGridViewTextBoxColumn";
            this.fechafinalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Facturado
            // 
            this.Facturado.DataPropertyName = "facturado";
            this.Facturado.HeaderText = "facturado";
            this.Facturado.Name = "Facturado";
            this.Facturado.ReadOnly = true;
            // 
            // recibomaestroBindingSource
            // 
            this.recibomaestroBindingSource.DataMember = "recibomaestro";
            this.recibomaestroBindingSource.DataSource = this.predialchicoDataSet;
            // 
            // predialchicoDataSet
            // 
            this.predialchicoDataSet.DataSetName = "predialchicoDataSet";
            this.predialchicoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Maestro
            // 
            this.Maestro.AttachedControl = this.superTabControlPanel1;
            this.Maestro.GlobalItem = false;
            this.Maestro.Name = "Maestro";
            this.Maestro.Text = "Maestro";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.advDetalles);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 25);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(730, 345);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.Esclavo;
            // 
            // advDetalles
            // 
            this.advDetalles.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advDetalles.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advDetalles.BackgroundStyle.Class = "TreeBorderKey";
            this.advDetalles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advDetalles.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.advDetalles.Location = new System.Drawing.Point(3, 3);
            this.advDetalles.Name = "advDetalles";
            this.advDetalles.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1});
            this.advDetalles.NodesConnector = this.nodeConnector2;
            this.advDetalles.NodeStyle = this.elementStyle2;
            this.advDetalles.PathSeparator = ";";
            this.advDetalles.Size = new System.Drawing.Size(724, 191);
            this.advDetalles.Styles.Add(this.elementStyle2);
            this.advDetalles.TabIndex = 0;
            this.advDetalles.Text = "advTree1";
            // 
            // node1
            // 
            this.node1.Expanded = true;
            this.node1.Name = "node1";
            this.node1.Text = "node1";
            // 
            // nodeConnector2
            // 
            this.nodeConnector2.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle2
            // 
            this.elementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle2.Name = "elementStyle2";
            this.elementStyle2.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // Esclavo
            // 
            this.Esclavo.AttachedControl = this.superTabControlPanel2;
            this.Esclavo.GlobalItem = false;
            this.Esclavo.Name = "Esclavo";
            this.Esclavo.Text = "Esclavo";
            this.Esclavo.Click += new System.EventHandler(this.Esclavo_click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(726, 12);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(102, 37);
            this.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceptar.TabIndex = 15;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // cmbCajas
            // 
            this.cmbCajas.DisplayMember = "Text";
            this.cmbCajas.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCajas.FormattingEnabled = true;
            this.cmbCajas.ItemHeight = 14;
            this.cmbCajas.Location = new System.Drawing.Point(80, 41);
            this.cmbCajas.Name = "cmbCajas";
            this.cmbCajas.Size = new System.Drawing.Size(333, 20);
            this.cmbCajas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbCajas.TabIndex = 1;
            // 
            // cmbOficina
            // 
            this.cmbOficina.DisplayMember = "Text";
            this.cmbOficina.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbOficina.FormattingEnabled = true;
            this.cmbOficina.ItemHeight = 14;
            this.cmbOficina.Location = new System.Drawing.Point(80, 12);
            this.cmbOficina.Name = "cmbOficina";
            this.cmbOficina.Size = new System.Drawing.Size(333, 20);
            this.cmbOficina.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbOficina.TabIndex = 0;
            this.cmbOficina.SelectedIndexChanged += new System.EventHandler(this.cmboficina_SelectedIndexChanged);
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(12, 35);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 12;
            this.labelX4.Text = "CAJA";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(12, 12);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 11;
            this.labelX3.Text = "OFICINA";
            // 
            // btncerrar
            // 
            this.btncerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btncerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btncerrar.Image = ((System.Drawing.Image)(resources.GetObject("btncerrar.Image")));
            this.btncerrar.Location = new System.Drawing.Point(834, 12);
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(89, 37);
            this.btncerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btncerrar.TabIndex = 16;
            this.btncerrar.Text = "Cerrar";
            // 
            // dtinicio
            // 
            this.dtinicio.Location = new System.Drawing.Point(506, 11);
            this.dtinicio.Name = "dtinicio";
            this.dtinicio.Size = new System.Drawing.Size(200, 20);
            this.dtinicio.TabIndex = 2;
            // 
            // dtfinal
            // 
            this.dtfinal.Location = new System.Drawing.Point(506, 37);
            this.dtfinal.Name = "dtfinal";
            this.dtfinal.Size = new System.Drawing.Size(200, 20);
            this.dtfinal.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(457, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "De";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(457, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(525, 447);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Total";
            // 
            // Lbltotal
            // 
            this.Lbltotal.AutoSize = true;
            this.Lbltotal.Location = new System.Drawing.Point(672, 447);
            this.Lbltotal.Name = "Lbltotal";
            this.Lbltotal.Size = new System.Drawing.Size(13, 13);
            this.Lbltotal.TabIndex = 22;
            this.Lbltotal.Text = "0";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnrenumerar);
            this.groupPanel1.Controls.Add(this.iisumando);
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Controls.Add(this.iifinal);
            this.groupPanel1.Controls.Add(this.iiinicio);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(749, 67);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(168, 158);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 23;
            this.groupPanel1.Text = "ReEnumera";
            // 
            // btnrenumerar
            // 
            this.btnrenumerar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnrenumerar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnrenumerar.Image = ((System.Drawing.Image)(resources.GetObject("btnrenumerar.Image")));
            this.btnrenumerar.Location = new System.Drawing.Point(35, 97);
            this.btnrenumerar.Name = "btnrenumerar";
            this.btnrenumerar.Size = new System.Drawing.Size(102, 37);
            this.btnrenumerar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnrenumerar.TabIndex = 16;
            this.btnrenumerar.Text = "Reenumerar";
            this.btnrenumerar.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // iisumando
            // 
            // 
            // 
            // 
            this.iisumando.BackgroundStyle.Class = "DateTimeInputBackground";
            this.iisumando.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.iisumando.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.iisumando.Location = new System.Drawing.Point(57, 66);
            this.iisumando.Name = "iisumando";
            this.iisumando.ShowUpDown = true;
            this.iisumando.Size = new System.Drawing.Size(80, 20);
            this.iisumando.TabIndex = 5;
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(4, 63);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(52, 23);
            this.labelX5.TabIndex = 4;
            this.labelX5.Text = "Sumando";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(3, 34);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(52, 23);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "Al";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(4, 5);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(52, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "Del";
            // 
            // iifinal
            // 
            // 
            // 
            // 
            this.iifinal.BackgroundStyle.Class = "DateTimeInputBackground";
            this.iifinal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.iifinal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.iifinal.Location = new System.Drawing.Point(57, 38);
            this.iifinal.Name = "iifinal";
            this.iifinal.ShowUpDown = true;
            this.iifinal.Size = new System.Drawing.Size(80, 20);
            this.iifinal.TabIndex = 1;
            // 
            // iiinicio
            // 
            // 
            // 
            // 
            this.iiinicio.BackgroundStyle.Class = "DateTimeInputBackground";
            this.iiinicio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.iiinicio.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.iiinicio.Location = new System.Drawing.Point(57, 9);
            this.iiinicio.Name = "iiinicio";
            this.iiinicio.ShowUpDown = true;
            this.iiinicio.Size = new System.Drawing.Size(80, 20);
            this.iiinicio.TabIndex = 0;
            // 
            // recibomaestroTableAdapter
            // 
            this.recibomaestroTableAdapter.ClearBeforeFill = true;
            // 
            // Listarecibos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 507);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.Lbltotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtfinal);
            this.Controls.Add(this.dtinicio);
            this.Controls.Add(this.btncerrar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cmbCajas);
            this.Controls.Add(this.cmbOficina);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.superTabrecibos);
            this.Name = "Listarecibos";
            this.Text = "Lista de recibos";
            this.Load += new System.EventHandler(this.Listarecibos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.superTabrecibos)).EndInit();
            this.superTabrecibos.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.superTabControlPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recibomaestroBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.predialchicoDataSet)).EndInit();
            this.superTabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advDetalles)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iisumando)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iifinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iiinicio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.SuperTabControl superTabrecibos;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem Maestro;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem Esclavo;
        private DevComponents.DotNetBar.ButtonX btnAceptar;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbCajas;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbOficina;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX btncerrar;
        private System.Windows.Forms.DateTimePicker dtinicio;
        private System.Windows.Forms.DateTimePicker dtfinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Lbltotal;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btncancelarrecibo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource recibomaestroBindingSource;
        private predialchicoDataSet predialchicoDataSet;
        private predialchicoDataSetTableAdapters.recibomaestroTableAdapter recibomaestroTableAdapter;
        private DevComponents.AdvTree.AdvTree advDetalles;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.NodeConnector nodeConnector2;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripButton toolStripButton1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.Editors.IntegerInput iifinal;
        private DevComponents.Editors.IntegerInput iiinicio;
        private DevComponents.DotNetBar.ButtonX btnrenumerar;
        private DevComponents.Editors.IntegerInput iisumando;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private ToolStripLabel toolStripLabel2;
        private ToolStripButton toolStripButton2;
        private DataGridViewTextBoxColumn idReciboMaestroDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn folioDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn direccion1DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn direccion2DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ubicacionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn subtotalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn iVADataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn serieDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn canceladoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ccodofiDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cajaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechainicialDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descuentoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn catastralDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idformapagoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn porcDescuentoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn porcdescuentorecargosDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descuentorecargosDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tipodescuentoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valorfiscalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn usuariosisDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechafinalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Facturado;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
    }
}