namespace KNCDesktopApp
{
    partial class KNCDesktopApp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KNCDesktopApp));
            tabControl = new TabControl();
            WelcomeTab = new TabPage();
            EditAnnouncementsTab = new TabPage();
            EditEventsTab = new TabPage();
            EditTrailsTab = new TabPage();
            EditExhibitsTab = new TabPage();
            EditHelpTab = new TabPage();
            Tall_ImageList = new ImageList(components);
            Square_ImageList = new ImageList(components);
            tabControl.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(WelcomeTab);
            tabControl.Controls.Add(EditAnnouncementsTab);
            tabControl.Controls.Add(EditEventsTab);
            tabControl.Controls.Add(EditTrailsTab);
            tabControl.Controls.Add(EditExhibitsTab);
            tabControl.Controls.Add(EditHelpTab);
            tabControl.Dock = DockStyle.Fill;
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tabControl.HotTrack = true;
            tabControl.ItemSize = new Size(100, 30);
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.ShowToolTips = true;
            tabControl.Size = new Size(1377, 768);
            tabControl.TabIndex = 1;
            tabControl.DrawItem += tabControl_DrawItem;
            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
            // 
            // WelcomeTab
            // 
            WelcomeTab.Location = new Point(4, 34);
            WelcomeTab.Name = "WelcomeTab";
            WelcomeTab.Size = new Size(1369, 730);
            WelcomeTab.TabIndex = 5;
            WelcomeTab.Text = "Welcome";
            WelcomeTab.UseVisualStyleBackColor = true;
            // 
            // EditAnnouncementsTab
            // 
            EditAnnouncementsTab.Location = new Point(4, 34);
            EditAnnouncementsTab.Name = "EditAnnouncementsTab";
            EditAnnouncementsTab.Size = new Size(1369, 730);
            EditAnnouncementsTab.TabIndex = 7;
            EditAnnouncementsTab.Text = "Edit Announcements";
            EditAnnouncementsTab.UseVisualStyleBackColor = true;
            // 
            // EditEventsTab
            // 
            EditEventsTab.Location = new Point(4, 34);
            EditEventsTab.Name = "EditEventsTab";
            EditEventsTab.Size = new Size(1369, 730);
            EditEventsTab.TabIndex = 6;
            EditEventsTab.Text = "Edit Events";
            EditEventsTab.UseVisualStyleBackColor = true;
            // 
            // EditTrailsTab
            // 
            EditTrailsTab.Location = new Point(4, 34);
            EditTrailsTab.Name = "EditTrailsTab";
            EditTrailsTab.Padding = new Padding(3);
            EditTrailsTab.Size = new Size(1369, 730);
            EditTrailsTab.TabIndex = 1;
            EditTrailsTab.Text = "Edit Trails";
            EditTrailsTab.UseVisualStyleBackColor = true;
            // 
            // EditExhibitsTab
            // 
            EditExhibitsTab.Location = new Point(4, 34);
            EditExhibitsTab.Name = "EditExhibitsTab";
            EditExhibitsTab.Padding = new Padding(3);
            EditExhibitsTab.Size = new Size(1369, 730);
            EditExhibitsTab.TabIndex = 2;
            EditExhibitsTab.Text = "Edit Exhibits";
            EditExhibitsTab.UseVisualStyleBackColor = true;
            // 
            // EditHelpTab
            // 
            EditHelpTab.Location = new Point(4, 34);
            EditHelpTab.Name = "EditHelpTab";
            EditHelpTab.Padding = new Padding(3);
            EditHelpTab.Size = new Size(1369, 730);
            EditHelpTab.TabIndex = 4;
            EditHelpTab.Text = "Edit Help Info";
            EditHelpTab.UseVisualStyleBackColor = true;
            // 
            // Tall_ImageList
            // 
            Tall_ImageList.ColorDepth = ColorDepth.Depth16Bit;
            Tall_ImageList.ImageSize = new Size(139, 247);
            Tall_ImageList.TransparentColor = Color.Transparent;
            // 
            // Square_ImageList
            // 
            Square_ImageList.ColorDepth = ColorDepth.Depth16Bit;
            Square_ImageList.ImageSize = new Size(250, 250);
            Square_ImageList.TransparentColor = Color.Transparent;
            // 
            // KNCDesktopApp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1377, 768);
            Controls.Add(tabControl);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(1395, 815);
            MinimumSize = new Size(1395, 815);
            Name = "KNCDesktopApp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KNC Desktop App";
            TopMost = false;
            tabControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControl;
        private TabPage EditTrailsTab;
        private TabPage EditExhibitsTab;
        private TabPage EditHelpTab;
        private TabPage WelcomeTab;
        private TabPage EditEventsTab;
        private TabPage EditAnnouncementsTab;
        private ImageList Tall_ImageList;
        private ImageList Square_ImageList;
    }
}