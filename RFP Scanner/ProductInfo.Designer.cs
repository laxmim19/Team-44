namespace RFP_Scanner
{
    partial class ProductInfo
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

        // Example property to get/set text in the TextBox
        

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblProdName = new System.Windows.Forms.Label();
            this.chkProd = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblProdName
            // 
            this.lblProdName.AutoSize = true;
            this.lblProdName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdName.Location = new System.Drawing.Point(3, 3);
            this.lblProdName.Name = "lblProdName";
            this.lblProdName.Size = new System.Drawing.Size(95, 25);
            this.lblProdName.TabIndex = 0;
            this.lblProdName.Text = "Product 1";
            // 
            // chkProd
            // 
            this.chkProd.AutoSize = true;
            this.chkProd.Checked = true;
            this.chkProd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkProd.Location = new System.Drawing.Point(103, 11);
            this.chkProd.Name = "chkProd";
            this.chkProd.Size = new System.Drawing.Size(18, 17);
            this.chkProd.TabIndex = 1;
            this.chkProd.UseVisualStyleBackColor = true;
            // 
            // ProductInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.chkProd);
            this.Controls.Add(this.lblProdName);
            this.Name = "ProductInfo";
            this.Size = new System.Drawing.Size(124, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProdName;
        private System.Windows.Forms.CheckBox chkProd;
    }
}
