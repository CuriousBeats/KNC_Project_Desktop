using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNCDesktopApp
{
    internal class MyComboBox : ComboBox
    {
        public MyComboBox()
        {
            InitializeAppearance();
        }

        public void InitializeAppearance()
        {
            // Set custom font name and size
            this.Font = new Font("Arial", 10);

            // Set additional properties to customize your combo box
            // Example: setting the background and foreground colors
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;



            // You can also set other properties that should be standard across all instances
            this.DropDownStyle = ComboBoxStyle.DropDownList; // Disallows user typing, only selection
            this.IntegralHeight = false; // Allows partial items to be shown
        }


    }
}
