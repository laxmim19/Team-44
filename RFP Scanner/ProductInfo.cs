using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace RFP_Scanner
{
    public partial class ProductInfo : UserControl
    {
        public ProductInfo()
        {
            InitializeComponent();
            CustomStyle();
        }

        private void CustomStyle()
        {
            // 
            // lblProdName
            // 
            this.lblProdName.AutoSize = true;
            this.lblProdName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdName.ForeColor = Color.FromArgb(50, 50, 50); // Darker text color
            this.lblProdName.Location = new System.Drawing.Point(10, 5);
            this.lblProdName.Name = "lblProdName";
            //this.lblProdName.Size = new System.Drawing.Size(120, 28);
            this.lblProdName.TabIndex = 0;
            this.lblProdName.Text = "Product 1";

            // 
            // chkProd
            // 
            this.chkProd.AutoSize = true;
            this.chkProd.Checked = true;
            this.chkProd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkProd.ForeColor = Color.FromArgb(0, 120, 215); // Light blue color
            this.chkProd.Location = new System.Drawing.Point(180, 10);
            this.chkProd.Name = "chkProd";
            this.chkProd.Size = new System.Drawing.Size(20, 20);
            this.chkProd.TabIndex = 1;
            this.chkProd.UseVisualStyleBackColor = true;

            // Custom checkbox hover effect (optional)
            this.chkProd.MouseEnter += (s, e) => this.chkProd.BackColor = Color.LightGray;
            this.chkProd.MouseLeave += (s, e) => this.chkProd.BackColor = Color.Transparent;
            this.chkProd.Enabled = false;

            // 
            // ProductInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 10F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;  // Automatically adjust size based on contents
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            
            this.BackColor = Color.FromArgb(245, 245, 245); // Light gray background for modern look
            this.Controls.Add(this.chkProd);
            this.Controls.Add(this.lblProdName);
            this.Name = "ProductInfo";
            this.Width = 180;
            
            //this.Size = new System.Drawing.Size(180, 20);
            this.Padding = new Padding(2);
            this.BorderStyle = BorderStyle.None;
            AdjustCheckBoxPosition();

        }
        private void AdjustCheckBoxPosition()
        {
            // Measure the size of the label's text
            Size textSize = TextRenderer.MeasureText(lblProdName.Text, lblProdName.Font);

            // Adjust the position of the checkbox based on the label's width
            //chkProd.Location = new Point(lblProdName.Location.X + textSize.Width + 10, lblProdName.Location.Y + (lblProdName.Height / 2 - chkProd.Height / 2));

            // Adjust the UserControl's height based on the larger of the two elements
            int newHeight = Math.Max(textSize.Height, chkProd.Height) + 10;  // Add padding
            this.Height = newHeight;
        }
        public string ProductName
        {
            get { return lblProdName.Text; }
            set { lblProdName.Text = value; }
        }
        public bool IsChecked
        {
            get { return chkProd.Checked; }
            set { chkProd.Checked = value; }
        }
        public event EventHandler CheckBoxCheckedChanged
        {
            add { chkProd.CheckedChanged += value; }
            remove { chkProd.CheckedChanged -= value; }
        }
    }
}
