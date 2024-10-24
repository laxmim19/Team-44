using System;
using System.Drawing;
using System.Windows.Forms;

public class CustomProgressBar : ProgressBar
{
    public Color ProgressColor { get; set; } = Color.FromArgb(0, 120, 215); // Blue progress color
    public Color BackgroundColor { get; set; } = Color.FromArgb(240, 240, 240); // Light gray background color
    public Color BorderColor { get; set; } = Color.FromArgb(180, 180, 180); // Gray border color

    public CustomProgressBar()
    {
        this.SetStyle(ControlStyles.UserPaint, true);
        this.ForeColor = ProgressColor;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Rectangle rect = this.ClientRectangle;

        // Fill background
        e.Graphics.FillRectangle(new SolidBrush(BackgroundColor), rect);

        // Calculate progress bar size
        int progressWidth = (int)(rect.Width * ((double)this.Value / this.Maximum));

        // Draw progress
        if (progressWidth > 0)
        {
            e.Graphics.FillRectangle(new SolidBrush(ProgressColor), 0, 0, progressWidth, rect.Height);
        }

        // Draw border
        using (Pen pen = new Pen(BorderColor))
        {
            e.Graphics.DrawRectangle(pen, 0, 0, rect.Width - 1, rect.Height - 1);
        }
    }
}
