namespace FAPI_Inventory_Import
{
    partial class StoneFruitList
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
            this.dataGridViewStoneFuitList = new System.Windows.Forms.DataGridView();
            this.commodityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stoneFuitCommoditiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pBIApplicationTablesDataSetStoneFruitList = new FAPI_Inventory_Import.PBIApplicationTablesDataSetStoneFruitList();
            this.buttonSave = new System.Windows.Forms.Button();
            this.stoneFuitCommoditiesTableAdapter = new FAPI_Inventory_Import.PBIApplicationTablesDataSetStoneFruitListTableAdapters.StoneFuitCommoditiesTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStoneFuitList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stoneFuitCommoditiesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBIApplicationTablesDataSetStoneFruitList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewStoneFuitList
            // 
            this.dataGridViewStoneFuitList.AllowUserToOrderColumns = true;
            this.dataGridViewStoneFuitList.AutoGenerateColumns = false;
            this.dataGridViewStoneFuitList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStoneFuitList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.commodityDataGridViewTextBoxColumn,
            this.iDDataGridViewTextBoxColumn});
            this.dataGridViewStoneFuitList.DataSource = this.stoneFuitCommoditiesBindingSource;
            this.dataGridViewStoneFuitList.Location = new System.Drawing.Point(67, 77);
            this.dataGridViewStoneFuitList.Name = "dataGridViewStoneFuitList";
            this.dataGridViewStoneFuitList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewStoneFuitList.Size = new System.Drawing.Size(220, 300);
            this.dataGridViewStoneFuitList.TabIndex = 0;
            // 
            // commodityDataGridViewTextBoxColumn
            // 
            this.commodityDataGridViewTextBoxColumn.DataPropertyName = "Commodity";
            this.commodityDataGridViewTextBoxColumn.HeaderText = "Commodity";
            this.commodityDataGridViewTextBoxColumn.Name = "commodityDataGridViewTextBoxColumn";
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stoneFuitCommoditiesBindingSource
            // 
            this.stoneFuitCommoditiesBindingSource.DataMember = "StoneFuitCommodities";
            this.stoneFuitCommoditiesBindingSource.DataSource = this.pBIApplicationTablesDataSetStoneFruitList;
            // 
            // pBIApplicationTablesDataSetStoneFruitList
            // 
            this.pBIApplicationTablesDataSetStoneFruitList.DataSetName = "PBIApplicationTablesDataSetStoneFruitList";
            this.pBIApplicationTablesDataSetStoneFruitList.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(37, 410);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(80, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save/Close";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // stoneFuitCommoditiesTableAdapter
            // 
            this.stoneFuitCommoditiesTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Add, Edit or Delete Commodity and click the <Save> button..";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(237, 410);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(124, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Do not edit ID!";
            // 
            // StoneFruitList
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(344, 512);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.dataGridViewStoneFuitList);
            this.Name = "StoneFruitList";
            this.Text = "Stone Fruit List Editor";
            this.Load += new System.EventHandler(this.StoneFruitList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStoneFuitList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stoneFuitCommoditiesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBIApplicationTablesDataSetStoneFruitList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewStoneFuitList;
        private System.Windows.Forms.Button buttonSave;
        private PBIApplicationTablesDataSetStoneFruitList pBIApplicationTablesDataSetStoneFruitList;
        private System.Windows.Forms.BindingSource stoneFuitCommoditiesBindingSource;
        private FAPI_Inventory_Import.PBIApplicationTablesDataSetStoneFruitListTableAdapters.StoneFuitCommoditiesTableAdapter stoneFuitCommoditiesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn commodityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label2;
    }
}