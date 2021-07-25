using System;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;

namespace HangFireLegacy.HangFire
{
    public class HangFireContainerJobActivator : JobActivator
    {
        private readonly IServiceProvider _container;

        public HangFireContainerJobActivator(IServiceProvider container)
        {
            _container = container;
        }

        public override object ActivateJob(Type type)
        => _container.GetRequiredService(type);
    }
}
