using System;
using System.Collections.Generic;

namespace Saturn72.SimpleIoc
{
    public class IocManager : IRegistrar, IResolver
    {
        private readonly IDictionary<Type, Func<object>> _resolutionDictionary = new Dictionary<Type, Func<object>>();

        public TService Resolve<TService>()
        {
            return (TService) (_resolutionDictionary.ContainsKey(typeof(TService))
                ? _resolutionDictionary[typeof(TService)]()
                : null);
        }

        public void Register<TService>(Func<object> resolutionFunc)
        {
            _resolutionDictionary[typeof(TService)] = resolutionFunc;
        }

    }
}
