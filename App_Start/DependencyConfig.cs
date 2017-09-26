using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using OliveAR.Services;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace OliveAR
{
    public class DependencyConfig
    {
        private static Container _container;

        public static Container GetContainer()
        {
            return _container;
        }

        public static void Initialize()
        {
            _container = new Container();
            _container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            AutoMap(_container, Assembly.GetExecutingAssembly());
            _container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            _container.RegisterMvcIntegratedFilterProvider();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(_container));
            //_container.Register<IQuizService, QuizService>(Lifestyle.Scoped);

            _container.Verify();
        }

        private static void AutoMap(Container container, params Assembly[] assemblies)
        {
            container.ResolveUnregisteredType += (s, e) => {
                if (e.UnregisteredServiceType.IsInterface && !e.Handled)
                {
                    var concreteTypes = (
                        from assembly in assemblies
                        from type in assembly.GetTypes()
                        where !type.IsAbstract && !type.IsGenericType
                        where e.UnregisteredServiceType.IsAssignableFrom(type)
                        select type)
                        .ToArray();

                    if (concreteTypes.Length == 1)
                    {
                        e.Register(Lifestyle.Transient.CreateRegistration(concreteTypes[0], container));
                    }
                }
            };
        }
    }
}