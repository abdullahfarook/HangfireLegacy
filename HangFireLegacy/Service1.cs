using System;
using System.ServiceProcess;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Owin.Hosting;

namespace HangFireLegacy
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
            
        }

        protected override void OnStart(string[] args)
        {
            // for debugging purposes...ugh, shoudl ahv eused TopShelf ;-)
            //Thread.Sleep(20000);

            StartService();
            base.OnStart(args);
        }

        public void StartService()
        {
            var options = new StartOptions();
            options.Urls.Add("http://localhost:5000");
            options.Urls.Add("http://127.0.0.1:5000");

            // Needs Admin privileges
            //options.Urls.Add($"http://{Environment.MachineName}:9095");

            WebApp.Start<Startup>(options);
        }

        protected override void OnStop()
        {
            Stop();
            base.OnStop();
        }

        public void StopService()
        {

        }
    }
}
