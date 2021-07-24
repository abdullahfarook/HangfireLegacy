using System;
using Hangfire;
using Unity;

namespace HangFireLegacy.Helpers
{
    public class ContainerJobActivator : JobActivator
    {
        private readonly UnityContainer _container;

        public ContainerJobActivator(UnityContainer container)
        {
            _container = container;
        }

        public override object ActivateJob(Type type)
        {
            return _container.Resolve(type);
        }
    }
}
