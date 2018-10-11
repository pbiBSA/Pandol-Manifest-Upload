namespace FAPI_Inventory_Import
{
    partial class Translation_Validation_Table_Editor
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
            this.labelField = new System.Windows.Forms.Label();
            this.comboBoxFieldSelect = new System.Windows.Forms.ComboBox();
            this.translationValidationTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.applicationSettingsDataSet15 = new FAPI_Inventory_Import.ApplicationSettingsDataSet15();
            this.translation_Validation_TableTableAdapter = new FAPI_Inventory_Import.ApplicationSettingsDataSet15TableAdapters.Translation_Validation_TableTableAdapter();
            this.dataGridViewtranslationValidationTable = new System.Windows.Forms.DataGridView();
            this.buttonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.translationValidationTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSet15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewtranslationValidationTable)).BeginInit();
            this.SuspendLayout();
            // 
            // labelField
            // 
            this.labelField.AutoSize = true;
            this.labelField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelField.Location = new System.Drawing.Point(13, 13);
            this.labelField.Name = "labelField";
            this.labelField.Size = new System.Drawing.Size(50, 17);
            this.labelField.TabIndex = 0;
            this.labelField.Text = "Field:  ";
            // 
            // comboBoxFieldSelect
            // 
            this.comboBoxFieldSelect.DataSource = this.translationValidationTableBindingSource;
            this.comboBoxFieldSelect.DisplayMember = "Data_Column_Name";
            this.comboBoxFieldSelect.FormattingEnabled = true;
            this.comboBoxFieldSelect.Location = new System.Drawing.Point(69, 13);
            this.comboBoxFieldSelect.Name = "comboBoxFieldSelect";
            this.comboBoxFieldSelect.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFieldSelect.TabIndex = 1;
            this.comboBoxFieldSelect.ValueMember = "Data_Column_Name";
            this.comboBoxFieldSelect.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // translationValidationTableBindingSource
            // 
            this.translationValidationTableBindingSource.DataMember = "Translation_Validation_Table";
            this.translationValidationTableBindingSource.DataSource = this.applicationSettingsDataSet15;
            // 
            // applicationSettingsDataSet15
            // 
            this.applicationSettingsDataSet15.DataSetName = "ApplicationSettingsDataSet15";
            this.applicationSettingsDataSet15.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // translation_Validation_TableTableAdapter
            // 
            this.translation_Validation_TableTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewtranslationValidationTable
            // 
            this.dataGridViewtranslationValidationTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewtranslationValidationTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewtranslationValidationTable.Location = new System.Drawing.Point(16, 50);
            this.dataGridViewtranslationValidationTable.Name = "dataGridViewtranslationValidationTable";
            this.dataGridViewtranslationValidationTable.Size = new System.Drawing.Size(530, 600);
            this.dataGridViewtranslationValidationTable.TabIndex = 2;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(439, 13);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // Translation_Validation_Table_Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 662);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.dataGridViewtranslationValidationTable);
            this.Controls.Add(this.comboBoxFieldSelect);
            this.Controls.Add(this.labelField);
            this.Name = "Translation_Validation_Table_Editor";
            this.Text = "Translation-Validation Table Editor";
            this.Load += new System.EventHandler(this.Translation_Validation_Table_Editor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.translationValidationTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationSettingsDataSet15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewtranslationValidationTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelField;
        private System.Windows.Forms.ComboBox comboBoxFieldSelect;
        private ApplicationSettingsDataSet15 applicationSettingsDataSet15;
        private System.Windows.Forms.BindingSource translationValidationTableBindingSource;
        private FAPI_Inventory_Import.ApplicationSettingsDataSet15TableAdapters.Translation_Validation_TableTableAdapter translation_Validation_TableTableAdapter;
        private System.Windows.Forms.DataGridView dataGridViewtranslationValidationTable;
        private System.Windows.Forms.Button buttonSave;
    }
}