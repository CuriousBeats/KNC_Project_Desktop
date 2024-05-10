using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNCDesktopApp
{
    public class Trail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Length { get; set; }
        public bool Is_Loop { get; set; }
        public string Difficulty { get; set; }
        public string Description { get; set; }

        public List<string> Images { get; set; }

        public Trail(int id, string name, string address, string length, bool isLoop, string difficulty, string description, List<string> images)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Length = length;
            this.Is_Loop = isLoop;
            this.Difficulty = difficulty;
            this.Description = description;
            this.Images = images;
        }
    }

    public class TrailRoot
    {
        public List<Trail> Trails { get; set; }
    }
}
