using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNCDesktopApp
{
    internal class MyTextBox : TextBox
    {
        public MyTextBox()
        {
            InitializeAppearance();
        }

        public void InitializeAppearance()
        {
            // Set the custom font name and size
            this.Font = new Font("Arial", 10);

            // You can also set other properties to customize your text box further
            // For example, setting the background color:
            this.BackColor = Color.White;

            // Setting the foreground color:
            this.ForeColor = Color.Black;

            // And any other properties you wish to standardize across all MyTextBox instances
        }

    }
}
