using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KNCDesktopApp
{
    public partial class Loading : Form
    {
        public Label lblMessage;
        public Loading()
        {
            InitializeComponent();
            this.lblMessage = new Label();
            this.lblMessage.Text = "Syncing Google Drive, please wait...\nThis May Take a minute or two";
            this.lblMessage.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblMessage.SetBounds(60, 130, 580, 50);

            this.ClientSize = new System.Drawing.Size(600, 300);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.TopMost = true;


        }
    }
}
