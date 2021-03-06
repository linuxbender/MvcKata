﻿// MvcKata DiResolver
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
using System.Linq;
using System.Web.Mvc;
using DiResolver.Pages;
using Microsoft.Practices.Unity;

namespace DiResolver.Bootstrapper
{
    public class UnityViewActivator : IViewPageActivator
    {
        private readonly IUnityContainer _container;

        public UnityViewActivator(IUnityContainer container)
        {
            _container = container;
        }

        public object Create(ControllerContext controllerContext, Type type)
        {
            try
            {
                if (type.GetInterfaces().Contains(typeof(INavigationProvider)))
                {
                    var service = _container.Resolve(type) as INavigationProvider;
                    if (service != null)
                    {
                        service.NavigationList = GetNavigationList();
                    }

                    return service;
                }

                return _container.Resolve(type);
            }
            catch (Exception)
            {
                //ToDo: Log Exception - Type not found for the view injection
                return null;
            }
        }

        private IEnumerable<INavigationItem> GetNavigationList()
        {
            foreach (var item in _container.ResolveAll<INavigationItem>())
            {
               yield return item;
            }
        }
    }
}

