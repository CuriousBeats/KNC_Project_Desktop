using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNCDesktopApp
{
    public class Announcement
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Subtitle1 { get; set; }

        public string Subtitle2 { get; set; }

        public string Description { get; set; }

        public List<String> Images { get; set; }    

        public Announcement(int ID, string Title, string Sub1, string Sub2, string Desc, List<string> images)
        {
            this.Id = ID;
            this.Title = Title;
            this.Subtitle1 = Sub1;
            this.Subtitle2 = Sub2;
            this.Description = Desc;
            this.Images = images;
        }
    }
   public class AnnouncementRoot
    {
        public List<Announcement> Announcements { get; set; }
    }
}
