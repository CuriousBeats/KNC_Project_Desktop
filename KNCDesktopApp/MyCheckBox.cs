using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNCDesktopApp
{
    internal class MyCheckBox : CheckBox
    {
        public MyCheckBox()
        {
            InitializeAppearance();
        }

        public void InitializeAppearance()
        {
            // Set the custom font size, color, and style
            this.Font = new Font("Arial", 9, FontStyle.Bold);

            // Set the text color
            this.ForeColor = Color.Black;

            // You can also set other properties to customize your check box further
            // For example, changing the background color:
            //this.BackColor = Color.Silver;

            // And any other styling or behavior properties you wish to standardize
        }


    }
}
