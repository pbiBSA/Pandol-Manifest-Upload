namespace FAPI_Inventory_Import
{
    partial class Warehouse_Editor
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
            this.dataGridViewWarehouseEditor = new System.Windows.Forms.DataGridView();
            this.buttonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarehouseEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewWarehouseEditor
            // 
            this.dataGridViewWarehouseEditor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWarehouseEditor.Location = new System.Drawing.Point(15, 75);
            this.dataGridViewWarehouseEditor.Name = "dataGridViewWarehouseEditor";
            this.dataGridViewWarehouseEditor.Size = new System.Drawing.Size(980, 500);
            this.dataGridViewWarehouseEditor.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(15, 25);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // Warehouse_Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 587);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.dataGridViewWarehouseEditor);
            this.Name = "Warehouse_Editor";
            this.Text = "Warehouse Editor";
            this.Load += new System.EventHandler(this.Warehouse_Editor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarehouseEditor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewWarehouseEditor;
        private System.Windows.Forms.Button buttonSave;
    }
}