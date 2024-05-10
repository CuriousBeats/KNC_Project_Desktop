using KNCDesktopApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNCDesktopApp
{
    public class MyButton : Button
    {
        private Image originalBackground;
        private int borderRadius;

        public MyButton()
        {
            // Attach mouse events
            this.MouseEnter += MyButton_MouseEnter;
            this.MouseLeave += MyButton_MouseLeave;
            InitializeAppearance();
        }

        public void InitializeAppearance()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.White;
            this.BackgroundImage = Properties.Resources.blu_green;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.ForeColor = Color.White;
            // Store the original image to revert back on mouse leave
            originalBackground = this.BackgroundImage;
        }


        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            borderRadius = Math.Min(this.Height, this.Width) / 2;
            SetButtonRegion();
        }

        private void MyButton_MouseEnter(object sender, EventArgs e)
        {
            this.BackgroundImage = GenerateColorOverlayImage(Color.FromArgb(120, Color.Gray));
            this.Invalidate();
        }

        private void MyButton_MouseLeave(object sender, EventArgs e)
        {
            this.BackgroundImage = originalBackground;
            this.Invalidate();
        }

        private void SetButtonRegion()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
            path.AddArc(this.Width - borderRadius - 1, 0, borderRadius, borderRadius, 270, 90);
            path.AddArc(this.Width - borderRadius - 1, this.Height - borderRadius - 1, borderRadius, borderRadius, 0, 90);
            path.AddArc(0, this.Height - borderRadius - 1, borderRadius, borderRadius, 90, 90);
            path.CloseAllFigures();
            this.Region = new Region(path);
        }

        private Image GenerateColorOverlayImage(Color colorOverlay)
        {
            Bitmap overlayedImage = new Bitmap(this.Width, this.Height);
            using (Graphics gfx = Graphics.FromImage(overlayedImage))
            {
                if (this.BackgroundImage != null)
                {
                    gfx.DrawImage(this.BackgroundImage, new Rectangle(0, 0, this.Width, this.Height));
                }
                using (Brush overlayBrush = new SolidBrush(colorOverlay))
                {
                    gfx.FillRectangle(overlayBrush, 0, 0, this.Width, this.Height);
                }
            }
            return overlayedImage;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            using (Pen pen = new Pen(Color.Azure, 3))
            {
                GraphicsPath path = new GraphicsPath();
                path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
                path.AddArc(this.Width - borderRadius - 1, 0, borderRadius, borderRadius, 270, 90);
                path.AddArc(this.Width - borderRadius - 1, this.Height - borderRadius - 1, borderRadius, borderRadius, 0, 90);
                path.AddArc(0, this.Height - borderRadius - 1, borderRadius, borderRadius, 90, 90);
                path.CloseFigure();
                pevent.Graphics.DrawPath(pen, path);
            }
        }
    }
}
