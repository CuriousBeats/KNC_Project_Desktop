using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNCDesktopApp
{
    public class Exhibit
    {
        public int Id { get; set; }

        public bool IsCurrent { get; set; }
        public string Title { get; set; }
        public string DateCreated { get; set; }
        public string Designer { get; set; }
        public List<String> Pdfs { get; set; }

        public Exhibit(int id, bool isCurrent, String title, string dateCreated, string designer, List<String> pdfs)
        {
            this.Id = id;
            this.IsCurrent = isCurrent;
            this.Title = title;
            this.DateCreated = dateCreated;
            this.Designer = designer;
            this.Pdfs = pdfs;
        }
    }

    public class ExhibitRoot
    {
        public List<Exhibit> Exhibits { get; set; }
    }
}