using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingHourSample.WorkModule.Models
{
    public class WorkTime : Worker
    {
        public int Day { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
