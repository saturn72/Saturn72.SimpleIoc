using System;
public interface IRegistrar
    {
        void Register<TService>(Func<object> resolutionFunc);
    }
