using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WorkingHourSample.WorkModule.Models
{
    class TableProvider
    {
        public List<Person> Member { get; } = temp();
        public List<WorkTime> WorkingInformation { get; } = GetInfo();
        public List<string[]> OverWorkInformation { get; } = GetOverWork();
        public List<string[]> List { get; } = WorkingInformationList.Info;
        public List<OverWorker> ExtractList { get; } = ExtractWorker();

        private static WorkingInformation Working = new WorkingInformation();
        private static WorkingInformationList WorkingInformationList = new WorkingInformationList();

        static List<Person> temp()
        {
            var people = new List<Person>(
                Enumerable.Range(1, 100).Select(i => new Person
                {
                    Name = "田中 太郎" + i,
                    Gender = i % 2 == 0 ? Gender.Men : Gender.Women,
                    Age = 20 + i % 50,
                    AuthMember = i % 5 == 0
                }));
            return people;
        }
        
        public static List<WorkTime> GetInfo()
        {
            var info = new List<WorkTime>();
            for(int i = 1; i <= 30; i++)
            {
                info.Add(new WorkTime { Id = 1, Name = "星宮いちご", Day = i, StartTime = ("08:30"), EndTime = ("17:30") });
                info.Add(new WorkTime { Id = 2, Name = "霧矢あおい", Day = i, StartTime = ("08:30"), EndTime = ("18:30") });
                info.Add(new WorkTime { Id = 3, Name = "紫吹蘭", Day = i, StartTime = ("08:30"), EndTime = ("19:30") });
                info.Add(new WorkTime { Id = 4, Name = "有栖川おとめ", Day = i, StartTime = ("08:30"), EndTime = ("18:00") });
                info.Add(new WorkTime { Id = 5, Name = "藤堂ユリカ", Day = i, StartTime = ("08:30"), EndTime = ("17:30") });
                info.Add(new WorkTime { Id = 6, Name = "北大路さくら", Day = i, StartTime = ("08:30"), EndTime = ("18:30") });
            }
            return info;
        }
        
        //過勤情報一覧
        public static List<string[]> GetOverWork()
        {
            var data = Working.WorkTimes.ToList().GroupBy(x => x.Id);
            //過勤情報リスト格納用
            List<string[]> workingtable = new List<string[]>();
            foreach(var member in data)
            {
                int i = 1;
                //過勤情報格納用
                string[] workinghour = new string[33];  //日数(31)+氏名+合計
                double total = 0;   //合計
                foreach (var day in member.OrderBy(x => x.Day))
                {
                    workinghour[0] = day.Name;  //毎回名前が入るのはおかしい
                    TimeSpan core = new TimeSpan(8, 0, 0);
                    TimeSpan rest = new TimeSpan(1, 0, 0);
                    DateTime start = DateTime.ParseExact(day.StartTime, "HH:mm", null);
                    DateTime end = DateTime.ParseExact(day.EndTime, "HH:mm", null);
                    TimeSpan overtime = end - start - core - rest;
                    total = total + overtime.TotalHours;

                    workinghour[i] = overtime.TotalHours.ToString();
                    i++;
                };
                workinghour[32] = total.ToString();
                workingtable.Add(workinghour);
            };
            return workingtable.ToList();
        }

        //過勤情報リストから35時間超過者を抽出
        private static List<OverWorker> ExtractWorker()
        {
            var data = WorkingInformationList.Info;
            var overworker = data.Where(x => double.Parse(x[32]) >= 35).Select(x =>
            {
                var name = x[0];
                var total = x[32];
                return new OverWorker { Name = name, Total = total };
            });
            return overworker.ToList();
        }
    }
}
