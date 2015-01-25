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

using DiResolver.Services;
using Microsoft.Practices.Unity;

namespace DiResolver.Bootstrapper
{
    /// <summary>
    /// Configuration Class for the Uniyt IoC Container
    /// </summary>
    public static class Configuration
    {        
        public static void RegisterTypes(IUnityContainer container)
        {
            RegisterByConvention(container);

            
            //add your custome container register hier..
            //eg Singelton: container.RegisterType<IHelloService, HelloService>(new HierarchicalLifetimeManager());
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
            container.RegisterTypes(AllClasses.FromLoadedAssemblies(),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.PerResolve);
        }
    }
}