namespace FAPI_Inventory_Import
{
    partial class Adams_Codes_Editor
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.dataGridViewAdamsCodes = new System.Windows.Forms.DataGridView();
            this.comboBoxAdamsCodes = new System.Windows.Forms.ComboBox();
            this.adamsValuesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.applicationSettingsDataSet18 = new FAPI_Inventory_Import.ApplicationSettingsDataSet18();
            this.adams_ValuesTableAdapter = new FAPI_Inventory_Import.ApplicationSettingsDataSet18TableAdapters.Adams_ValuesTableAdapter();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdamsCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adamsValuesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSet18)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(341, 13);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // dataGridViewAdamsCodes
            // 
            this.dataGridViewAdamsCodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAdamsCodes.Location = new System.Drawing.Point(28, 61);
            this.dataGridViewAdamsCodes.Name = "dataGridViewAdamsCodes";
            this.dataGridViewAdamsCodes.Size = new System.Drawing.Size(600, 400);
            this.dataGridViewAdamsCodes.TabIndex = 1;
            this.dataGridViewAdamsCodes.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewAdamsCodes_DefaultValuesNeeded);
            // 
            // comboBoxAdamsCodes
            // 
            this.comboBoxAdamsCodes.DataSource = this.adamsValuesBindingSource;
            this.comboBoxAdamsCodes.DisplayMember = "Data_Column_Name";
            this.comboBoxAdamsCodes.FormattingEnabled = true;
            this.comboBoxAdamsCodes.Location = new System.Drawing.Point(28, 13);
            this.comboBoxAdamsCodes.Name = "comboBoxAdamsCodes";
            this.comboBoxAdamsCodes.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAdamsCodes.TabIndex = 2;
            this.comboBoxAdamsCodes.ValueMember = "Data_Column_Name";
            this.comboBoxAdamsCodes.SelectedIndexChanged += new System.EventHandler(this.comboBoxAdamsCodes_SelectedIndexChanged);
            // 
            // adamsValuesBindingSource
            // 
            this.adamsValuesBindingSource.DataMember = "Adams_Values";
            this.adamsValuesBindingSource.DataSource = this.applicationSettingsDataSet18;
            // 
            // applicationSettingsDataSet18
            // 
            this.applicationSettingsDataSet18.DataSetName = "ApplicationSettingsDataSet18";
            this.applicationSettingsDataSet18.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // adams_ValuesTableAdapter
            // 
            this.adams_ValuesTableAdapter.ClearBeforeFill = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(535, 13);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // Adams_Codes_Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(658, 507);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.comboBoxAdamsCodes);
            this.Controls.Add(this.dataGridViewAdamsCodes);
            this.Controls.Add(this.buttonSave);
            this.Name = "Adams_Codes_Editor";
            this.Text = "Export Codes Editor";
            this.Load += new System.EventHandler(this.Adams_Codes_Editor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdamsCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adamsValuesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSet18)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.DataGridView dataGridViewAdamsCodes;
        private System.Windows.Forms.ComboBox comboBoxAdamsCodes;
        private ApplicationSettingsDataSet18 applicationSettingsDataSet18;
        private System.Windows.Forms.BindingSource adamsValuesBindingSource;
        private FAPI_Inventory_Import.ApplicationSettingsDataSet18TableAdapters.Adams_ValuesTableAdapter adams_ValuesTableAdapter;
        private System.Windows.Forms.Button buttonCancel;
    }
}