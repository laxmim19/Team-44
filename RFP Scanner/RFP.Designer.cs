using System.Drawing;
using System.Windows.Forms;

namespace RFP_Scanner
{
    partial class RFP
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
            this.uploadbtn = new System.Windows.Forms.Button();
            this.lblScanInProgress = new System.Windows.Forms.Label();
            this.btnFindProducts = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.customProgressBar = new CustomProgressBar();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uploadbtn
            // 
            this.uploadbtn.Location = new System.Drawing.Point(26, 427);
            this.uploadbtn.Name = "uploadbtn";
            this.uploadbtn.Size = new System.Drawing.Size(119, 32);
            this.uploadbtn.TabIndex = 0;
            this.uploadbtn.Text = "Upload RFP";
            this.uploadbtn.UseVisualStyleBackColor = true;
            this.uploadbtn.Click += new System.EventHandler(this.btnUploadPDF_Click);
            // 
            // lblScanInProgress
            // 
            this.lblScanInProgress.AutoSize = true;
            this.lblScanInProgress.Location = new System.Drawing.Point(186, 0);
            this.lblScanInProgress.Name = "lblScanInProgress";
            this.lblScanInProgress.Size = new System.Drawing.Size(109, 16);
            this.lblScanInProgress.TabIndex = 3;
            this.lblScanInProgress.Text = "Scan in Progress";
            // 
            // btnFindProducts
            // 
            this.btnFindProducts.Location = new System.Drawing.Point(215, 427);
            this.btnFindProducts.Name = "btnFindProducts";
            this.btnFindProducts.Size = new System.Drawing.Size(119, 32);
            this.btnFindProducts.TabIndex = 0;
            this.btnFindProducts.Text = "Find Products";
            this.btnFindProducts.UseVisualStyleBackColor = true;
            this.btnFindProducts.Click += new System.EventHandler(this.btnFindProducts_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(407, 427);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(25, 16);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "OK";
            this.lblStatus.TextChanged += new System.EventHandler(this.lblStatus_TextChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.customProgressBar);
            this.flowLayoutPanel1.Controls.Add(this.lblScanInProgress);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(119, 88);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(302, 278);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox1.Location = new System.Drawing.Point(163, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(202, 23);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "PRODUCTS AVAILABLE";
            // 
            // customProgressBar
            // 
            this.customProgressBar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.customProgressBar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.customProgressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.customProgressBar.Location = new System.Drawing.Point(3, 3);
            this.customProgressBar.Name = "customProgressBar";
            this.customProgressBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.customProgressBar.Size = new System.Drawing.Size(177, 30);
            this.customProgressBar.TabIndex = 8;
            // 
            // RFP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(548, 523);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnFindProducts);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.uploadbtn);
            this.Name = "RFP";
            this.Text = "RFP Scanner";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uploadbtn;
        private System.Windows.Forms.Label lblScanInProgress;
        private System.Windows.Forms.Button btnFindProducts;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private CustomProgressBar customProgressBar;
        private TextBox textBox1;
    }
}

