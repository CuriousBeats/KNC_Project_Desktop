using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNCDesktopApp
{
   public class ImageElement
    {
        public string Name { get; set; }
        public int Index {  get; set; }
        public Bitmap Image { get; set; }
        public string Path { get; set; }

        public bool IsNew { get; set; }

        public ImageElement(string Name, Bitmap Image, int Index, string Path, bool isNew)
        {
            this.Name = Name;
            this.Image = Image;
            this.Index = Index;
            this.Path = Path;
            this.IsNew = isNew;
        }
    }
}
