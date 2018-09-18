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
        [Dependency]
        public TableProvider TableProvider { get; set; }
    }
}
