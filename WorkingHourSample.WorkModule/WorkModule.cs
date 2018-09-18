using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using WorkingHourSample.WorkModule.Models;
using WorkingHourSample.WorkModule.Views;
using Prism.Modularity;
using Prism.Regions;

namespace WorkingHourSample.WorkModule
{
    public class WorkModule : IModule
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        public void Initialize()
        {
            
            this.Container.RegisterType<MessageProvider>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<object, HelloWorldView>(nameof(HelloWorldView));
            this.RegionManager.RequestNavigate("MainRegion", nameof(HelloWorldView));

            this.Container.RegisterType<TableProvider>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<object, MemverView>(nameof(MemverView));
            this.RegionManager.RequestNavigate("MemberRegion", nameof(MemverView));
        }
    }
}
