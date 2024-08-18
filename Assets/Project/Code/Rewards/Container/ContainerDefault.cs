using System;
using System.Collections.Generic;

namespace Rewards.Container
{
    public class ContainerDefault : IContainer
    {
        private readonly Dictionary<Type, object> _instances = new(capacity: 10);

        public void Register<TContract>(TContract instance)
        {
            _instances.Add(GetType<TContract>(), instance);
        }

        public void Remove<TContract>()
        {
            _instances.Remove(GetType<TContract>());
        }

        public TContract Resolve<TContract>()
        {
            return (TContract)_instances[GetType<TContract>()];
        }

        private static Type GetType<TType>()
        {
            return typeof(TType);
        }
    }
}