// MvcKata DiResolver.Provider
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
using System.Diagnostics;
using Microsoft.Practices.Unity.InterceptionExtension;
using Newtonsoft.Json;

namespace DiResolver.Provider
{
    public class AuditProvider : IInterceptionBehavior
    {
        public int Order { get; set; }

        private void Log(string message)
        {
            Debug.WriteLine(message);
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            // Before invoking
            Log(String.Format(
              "[AUDIT IN] [{0}] [Demo User] [{1}] [{2}]",
              DateTime.Now, input.MethodBase, JsonConvert.SerializeObject(input.Inputs)));

            // Invoke
            var result = getNext()(input, getNext);

            // After invoking
            if (result.Exception != null)
            {
                Log(String.Format(
                  "[AUDIT EXCEPTION] [{0}] [Demo User] [{1}] [{2}]", DateTime.Now,
                  JsonConvert.SerializeObject(input), JsonConvert.SerializeObject(result)));
            }
            else
            {
                Log(String.Format(
                  "[AUDIT OUT] [{0}] [Demo User] [RETURN VALUE] [{1}]",
                  DateTime.Now, JsonConvert.SerializeObject(result.ReturnValue)));
            }
            return result;
        }


        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}