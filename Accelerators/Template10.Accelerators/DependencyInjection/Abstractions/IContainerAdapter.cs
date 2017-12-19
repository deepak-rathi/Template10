﻿namespace Template10.Services.DependencyInjection
{
    public interface IContainerAdapter
    {
        TInterface Resolve<TInterface>()
        where TInterface : class;
        void Register<TInterface, TClass>(string key)
           where TInterface : class
           where TClass : class, TInterface;
        TInterface Resolve<TInterface>(string key)
            where TInterface : class;
        void Register<TInterface, TClass>()
             where TInterface : class
             where TClass : class, TInterface;
        void RegisterInstance<TClass>(TClass instance)
            where TClass : class;
        void RegisterInstance<TInterface, TClass>(TClass instance)
            where TInterface : class
            where TClass : class, TInterface;
    }
}
