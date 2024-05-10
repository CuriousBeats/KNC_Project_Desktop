using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNCDesktopApp
{
    public class TrailStop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
        public string Audio {  get; set; }
        public bool Is_Audio { get; set; }

        public TrailStop(int id, string name, string description, List<string> images, string audio, bool is_audio)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Images = images;
            this.Audio = audio;
            this.Is_Audio = is_audio;
        }
    }

    public class TrailStopRoot
    {
        public List<TrailStop> trailStops { get; set; }
    }
}
