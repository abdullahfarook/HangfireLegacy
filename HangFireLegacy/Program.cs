using HangFireLegacy.Helpers;
using Topshelf;

namespace HangFireLegacy
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            Logger.InitiaLizeLogger();
            HostFactory.Run(x =>
            {
                x.Service<Service1>(s =>
                {
                    s.ConstructUsing(() => new Service1());
                    s.WhenStarted(tc => tc.StartService());
                    s.WhenStopped(tc => tc.StopService());
                });
                x.RunAsLocalSystem();

                x.SetDescription("This is a Queue Service for assigning pending chats to respective agents");
                x.SetDisplayName("Queue Service");
                x.SetServiceName("QueueService");
            });

        }
    }
}
