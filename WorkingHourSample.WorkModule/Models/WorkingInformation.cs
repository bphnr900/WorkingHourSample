using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingHourSample.WorkModule.Models
{
    public class WorkingInformation : Worker
    {
        //プロパティ
        public List<WorkTime> WorkTimes { get; set; }

        //コンストラクタ
        public WorkingInformation()
        {
            List<WorkTime> temp = new List<WorkTime>();
            for (int i = 1; i <= 30; i++)
            {
                temp.Add(new WorkTime { Id = 1, Name = "星宮いちご", Day = i, StartTime = ("08:30"), EndTime = ("17:30") });
                temp.Add(new WorkTime { Id = 2, Name = "霧矢あおい", Day = i, StartTime = ("08:30"), EndTime = ("18:30") });
                temp.Add(new WorkTime { Id = 3, Name = "紫吹蘭", Day = i, StartTime = ("08:30"), EndTime = ("19:30") });
                temp.Add(new WorkTime { Id = 4, Name = "有栖川おとめ", Day = i, StartTime = ("08:30"), EndTime = ("18:00") });
                temp.Add(new WorkTime { Id = 5, Name = "藤堂ユリカ", Day = i, StartTime = ("08:30"), EndTime = ("17:30") });
                temp.Add(new WorkTime { Id = 6, Name = "北大路さくら", Day = i, StartTime = ("08:30"), EndTime = ("18:30") });
            }
            this.WorkTimes = temp;
        }
    }
}
