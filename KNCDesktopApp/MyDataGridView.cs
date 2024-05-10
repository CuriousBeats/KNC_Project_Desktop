using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNCDesktopApp
{
    internal class MyDataGridView : DataGridView
    {
        public MyDataGridView()
        {
            InitializeAppearance();

        }

        public void InitializeAppearance()
        {
            this.AllowDrop = true;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.RowHeadersVisible = false;
            this.ScrollBars = ScrollBars.Vertical;
            this.Size = new Size(575, 622);
            this.Font = new Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point);
        }

    }
}
