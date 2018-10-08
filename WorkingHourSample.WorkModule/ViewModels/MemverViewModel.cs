using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using WorkingHourSample.WorkModule.Models;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace WorkingHourSample.WorkModule.ViewModels
{
    class MemverViewModel : BindableBase
    {
        public string Title { get; } = "過勤状況";
        public string UserId { get; } = "ログインID : " + GetUserId();

        [Dependency]
        public TableProvider TableProvider { get; set; }
        
        public ObservableCollection<Person> people { get; }



        private static string GetUserId()
        {
            return "A00001";
        }
    }
}
