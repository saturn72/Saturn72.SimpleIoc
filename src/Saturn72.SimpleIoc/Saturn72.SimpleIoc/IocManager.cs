using System;
using System.Collections.Generic;

namespace Saturn72.SimpleIoc
{
    public class IocManager : IRegistrar, IResolver
    {
        private IDictionary<Type, Func<object>> _resolutionDictionary;

        public TService Resolve<TService>()
        {
            return (TService) (ResolutionDictionary.ContainsKey(typeof(TService))
                ? ResolutionDictionary[typeof(TService)]()
                : null);
        }

        protected IDictionary<Type, Func<object>> ResolutionDictionary
        {
            get => _resolutionDictionary ?? (_resolutionDictionary = new Dictionary<Type, Func<object>>());
            set => _resolutionDictionary = value;
        }

        public void Register<TService>(Func<object> resolutionFunc)
        {
            ResolutionDictionary[typeof(TService)] = resolutionFunc;
        }
    }
}
