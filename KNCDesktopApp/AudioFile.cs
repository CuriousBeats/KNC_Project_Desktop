using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNCDesktopApp
{
    public class AudioFile
    {
        public string Path { get; set; }



        public AudioFile(string path)
        {
            this.Path = path;
        }
    }
}
