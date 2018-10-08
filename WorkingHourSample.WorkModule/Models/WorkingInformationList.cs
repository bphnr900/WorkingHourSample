using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingHourSample.WorkModule.Models
{
    public class WorkingInformationList
    {
        public List<string[]> Info { get; set; }

        //必要なオブジェクト作成
        private static WorkingInformation Working = new WorkingInformation();

        //コンストラクタ
        public WorkingInformationList()
        {
            var data = Working.WorkTimes.ToList().GroupBy(x => x.Id);
            //過勤情報リスト格納用
            List<string[]> workingtable = new List<string[]>();
            foreach (var member in data)
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
            Info = workingtable;
        }
    }
}
