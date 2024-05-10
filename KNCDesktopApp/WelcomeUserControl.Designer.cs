namespace KNCDesktopApp
{
    partial class WelcomeUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeUserControl));
            Welcome_Label = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Welcome_Label
            // 
            Welcome_Label.AutoSize = true;
            Welcome_Label.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Welcome_Label.Location = new Point(162, 458);
            Welcome_Label.Name = "Welcome_Label";
            Welcome_Label.Size = new Size(1064, 196);
            Welcome_Label.TabIndex = 0;
            Welcome_Label.Text = resources.GetString("Welcome_Label.Text");
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(433, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(501, 271);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(331, 297);
            label1.Name = "label1";
            label1.Size = new Size(715, 140);
            label1.TabIndex = 2;
            label1.Text = "Welcome to the KNC Mobile App File Editor\r\n\r\nUse the tabs above to navigate throught the various options presented\r\n\r\nPlease note the following:";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // WelcomeUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 235, 225);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(Welcome_Label);
            Name = "WelcomeUserControl";
            Size = new Size(1367, 728);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Welcome_Label;
        private PictureBox pictureBox1;
        private Label label1;
    }
}
