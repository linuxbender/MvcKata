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

using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;

namespace DiResolver.Bootstrapper
{
    public class WebApiResolver : IDependencyResolver
    {
       protected IUnityContainer Container;
       protected IBaseResolver Resolver;

       public WebApiResolver(IUnityContainer container, IBaseResolver resolver)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            Container = container;
            Resolver = resolver;
        }

        /// <summary>
        /// Dispose of the controller's dependencies
        /// </summary>
        public void Dispose()
        {
            Resolver.Dispose();
        }

        /// <summary>
        /// return null - is recommended if the resolver can find a type 
        /// </summary>
        /// <param name="serviceType">Type</param>
        /// <returns>resolved object from the container</returns>
        public object GetService(Type serviceType)
        {
            return Resolver.GetService(serviceType);
        }

        /// <summary>
        /// return empty object list - is 
        /// recommended if the resolver can find any type
        /// </summary>
        /// <param name="serviceType">Type</param>
        /// <returns>resolve object list from the container</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Resolver.GetServices(serviceType);
        }

        /// <summary>
        /// HttpConfiguration object has global scope. When web app create a controller,
        /// it calls this method. it will return a IDependencyScope - like a Child scope
        /// </summary>
        /// <returns>MvcResolver</returns>
        public IDependencyScope BeginScope()
        {
            var child = Container.CreateChildContainer();
            return new WebApiResolver(child, Resolver);
        }
    }
}