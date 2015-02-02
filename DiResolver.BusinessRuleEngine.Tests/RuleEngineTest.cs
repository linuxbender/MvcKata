// MvcKata DiResolver.BusinessRuleEngine.Tests
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

using System.Collections.Generic;
using System.Collections.ObjectModel;
using DiResolver.BusinessRules;
using DiResolver.BusinessRules.Rules;
using DiResolver.BusinessRules.Uitls;
using NUnit.Framework;

namespace DiResolver.BusinessRuleEngine.Tests
{
    [TestFixture]
    public class RuleEngineTest
    {

        [Test]
        public void Given_RuleEngine_add_PublicPriceRule_Exceptet_Resolve_TheRule_Result()
        {
            ICollection<IBusinessRule<IBusinessResult>> rules = new Collection<IBusinessRule<IBusinessResult>>();
            rules.Add(new PublicPriceRule(100));

            IRuleEngine<IBusinessResult> ruleEngine = new RuleEngine(rules);

            IBusinessResult result = ruleEngine.Execute();
            Assert.AreEqual(result.Price,90);
        } 
    }
}