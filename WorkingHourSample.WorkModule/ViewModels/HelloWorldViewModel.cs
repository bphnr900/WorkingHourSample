using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using WorkingHourSample.WorkModule.Models;

namespace WorkingHourSample.WorkModule.ViewModels
{
    class HelloWorldViewModel
    {
        [Dependency]
        public MessageProvider MessageProvider { get; set; }
    }
}
