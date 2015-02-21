// MvcKata DiResolver
// 
// The MIT License (MIT)
// 
// Copyright (c) 2015 daniel glenn
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software 
// and associated documentation files (the "Software"), to deal in the Software without restriction, 
// including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
// and/or sell copies of the Software, and to permit persons to whom the Software is 
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies 
// or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT 
// LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY 
// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING 
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace DiResolver.Bootstrapper
{
    /// <summary>
    /// Configuration Class for the Uniyt IoC Container
    /// </summary>
    public static class ContainerConfiguration
    {        
        /// <summary>
        /// Order is important, overwriting - from top to bottom.
        /// 1. the convention based approach
        /// 2. your code based approach will overwrite your convention
        /// 3. web.config approach will anytime win
        /// </summary>
        /// <param name="container">IUnityContainer</param>
        public static void RegisterTypes(IUnityContainer container)
        {
            //Set Default RegisterType
            RegisterByConvention(container);

            //UnityViewActivator
            container.RegisterType<IViewPageActivator, UnityViewActivator>();
            
            //add your custome container register hier..

            //eg Singelton: container.RegisterType<IHelloService, HelloService>(new HierarchicalLifetimeManager());
            //eg Singelton: container.RegisterInstance<IPersonService>(new PersonService(),new HierarchicalLifetimeManager());

            //container.RegisterType<IStorePrice, StorePrice>("BasicStore",new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<AuditProvider>());
            //container.RegisterType<IStorePrice, DiscountTwentyPercent>(new InjectionConstructor(new ResolvedParameter<IStorePrice>("BasicStore")));

            // Read RegisterType from configuration
            container.LoadConfiguration();
        }

        /// <summary>
        /// RegisterByConfiguration based on Interface name and class name
        /// eg.: RegisterType with Interface: IHelloService and Class: HelloService>;
        /// 
        /// The MVC FactoryController resolve per request a new instance from the Unity container.
        /// If you like to use the hierarchical lifetime manger, then you need to overwrite 
        /// the MVC build in FactoryController or write a new http module to resolve per Request
        /// </summary>
        /// <param name="container">IUnityContainer</param>
        private static void RegisterByConvention(IUnityContainer container)
        {
            container.AddNewExtension<Interception>();

            container.RegisterTypes(AllClasses.FromLoadedAssemblies(),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.PerResolve);
        }
    }
}