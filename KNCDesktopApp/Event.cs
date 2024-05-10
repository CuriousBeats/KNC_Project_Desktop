using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNCDesktopApp
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Location { get; set; }

        public List<string> Images {  get; set; }

        public Event(int id, string title, string day, string month,
            string year, string startTime, string endTime, string location, List<string> images)
        {
            this.Id = id;
            this.Title = title;
            this.Day = day;
            this.Month = month;
            this.Year = year;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Location = location;
            this.Images = images;
        }
    }

    public class EventsRoot
    {
        public List<Event> Events { get; set; }
    }

}