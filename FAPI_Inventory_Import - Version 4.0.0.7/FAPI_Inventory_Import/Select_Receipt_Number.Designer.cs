namespace FAPI_Inventory_Import
{
    partial class Select_Receipt_Number
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Select_Receipt_Number));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxReceiptNumber = new System.Windows.Forms.ComboBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.buttonUse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(311, 168);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // comboBoxReceiptNumber
            // 
            this.comboBoxReceiptNumber.FormattingEnabled = true;
            this.comboBoxReceiptNumber.Location = new System.Drawing.Point(139, 117);
            this.comboBoxReceiptNumber.Name = "comboBoxReceiptNumber";
            this.comboBoxReceiptNumber.Size = new System.Drawing.Size(156, 21);
            this.comboBoxReceiptNumber.TabIndex = 2;
            this.comboBoxReceiptNumber.Text = "Select Receipt Number";
            this.comboBoxReceiptNumber.SelectedIndexChanged += new System.EventHandler(this.comboBoxReceiptNumber_SelectedIndexChanged);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDescription.Location = new System.Drawing.Point(56, 12);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.Size = new System.Drawing.Size(330, 87);
            this.textBoxDescription.TabIndex = 3;
            this.textBoxDescription.Text = "   To reuse an existing receipt number.   Select one from the list and click the " +
                "<Use Number> button.\r\nOtherwise click <Cancel> to create a new receipt number.";
            // 
            // buttonUse
            // 
            this.buttonUse.Location = new System.Drawing.Point(56, 168);
            this.buttonUse.Name = "buttonUse";
            this.buttonUse.Size = new System.Drawing.Size(75, 23);
            this.buttonUse.TabIndex = 4;
            this.buttonUse.Text = "Use Number";
            this.buttonUse.UseVisualStyleBackColor = true;
            this.buttonUse.Click += new System.EventHandler(this.buttonUse_Click);
            // 
            // Select_Receipt_Number
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(454, 237);
            this.ControlBox = false;
            this.Controls.Add(this.buttonUse);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.comboBoxReceiptNumber);
            this.Controls.Add(this.buttonCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Select_Receipt_Number";
            this.Text = "Select Receipt Number";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Select_Receipt_Number_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxReceiptNumber;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button buttonUse;
    }
}