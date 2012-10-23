using System;
using System.Collections.Generic;
using Caliburn.Micro;
using RTC.ViewModels;

namespace RTC
{
    public sealed partial class App
    {
        private WinRTContainer _container;

        public App()
        {
            InitializeComponent();
        }

        protected override void Configure()
        {
            base.Configure();
            _container = new WinRTContainer(RootFrame);
            _container.RegisterWinRTServices();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override Type GetDefaultViewModel()
        {
            return typeof (HubViewModel);
        }
    }
}
