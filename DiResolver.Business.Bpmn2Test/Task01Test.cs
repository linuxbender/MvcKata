// MvcKata DiResolver.Business.Bpmn2Test
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

using System.Activities;
using System.Collections.Generic;
using System.Linq;
using DiResolver.Business.Bpmn2;
using NUnit.Framework;

namespace DiResolver.Business.Bpmn2Test
{
    [TestFixture]
    public class Task01Test
    {
        [Test]
        public void Run_Task01_Expect_Hallo_Dani()
        {
            var list = new Dictionary<string, object>
            {
                {"MyName" , "Dani"}
            };
            
            var result = WorkflowInvoker.Invoke(new Demo01(),list);
            Assert.AreEqual(result.FirstOrDefault().Value.ToString(), "Hallo Dani");
        }

        [Test]
        public void Run_Task01_Expect_Hallo_Dani_()
        {

        }
    }
}