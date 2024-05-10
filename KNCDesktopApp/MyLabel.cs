using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNCDesktopApp
{
    internal class MyLabel : Label
    {
        public MyLabel()
        {
            InitializeAppearance();
        }

        public void InitializeAppearance()
        {
            // Set the custom font name and size
            this.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);

            // Set the font color
            this.ForeColor = Color.Black;

            // You can also set additional properties as needed
            // For example, setting alignment and padding:
            this.TextAlign = ContentAlignment.MiddleLeft;
            //this.Padding = new Padding(5);

            // And any other properties to standardize the look and feel
        }

    }
}
