// MvcKata DiResolver.Tests
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
using DiResolver.Business.Model.Utils;
using DiResolver.BusinessRuleEngine;
using DiResolver.BusinessRules;
using DiResolver.BusinessRules.Rules;
using DiResolver.BusinessRules.Utils;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace DiResolver.Tests.Bootstrapper
{
    [TestFixture]
    public class ContainerConfigRuleEngineTests : BaseConfig
    {

        [Test]
        public void Given_Unity_Register_With_RuleEngineSet_Exceptet_Resolve_TheRule_Result_from_PublicPriceRule()
        {
            _container.RegisterType<IBusinessRule<IBusinessResult>, VeteranPriceRule>("VeteranPriceRule", new InjectionConstructor((double)100, BusinessType.IsPublic));
            _container.RegisterType<IBusinessRule<IBusinessResult>, PublicPriceRule>("PublicPriceRule", new InjectionConstructor((double)100, BusinessType.IsPublic));
            _container.RegisterType<IBusinessRule<IBusinessResult>, CompanyPriceRule>("CompanyPriceRule", new InjectionConstructor((double)100, BusinessType.IsPublic));
            _container.RegisterType<ICollection<IBusinessRule<IBusinessResult>>, IBusinessRule<IBusinessResult>[]>("ruleSet");
            _container.RegisterType<IRuleEngine<IBusinessResult>, RuleEngine>("RuleEngine", new InjectionConstructor(new ResolvedParameter<ICollection<IBusinessRule<IBusinessResult>>>("ruleSet")));

            var ruleEngine = _container.Resolve<IRuleEngine<IBusinessResult>>("RuleEngine");

            IBusinessResult result = ruleEngine.Execute();                       

            Assert.AreEqual(result.Price, 90);
        }

        [Test]
        public void Given_Unity_Register_With_RuleEngineClientA_And_RuleEngineClientB_Exceptet_Resolve_PublicPriceRule()
        {
            _container.RegisterType<IBusinessRule<IBusinessResult>, VeteranPriceRule>("VeteranPriceRule", new InjectionConstructor((double)100, BusinessType.IsPublic));
            _container.RegisterType<IBusinessRule<IBusinessResult>, PublicPriceRule>("PublicPriceRule", new InjectionConstructor((double)100, BusinessType.IsPublic));
            _container.RegisterType<IBusinessRule<IBusinessResult>, CompanyPriceRule>("CompanyPriceRule", new InjectionConstructor((double)100, BusinessType.IsPublic));

            _container.RegisterType<IRuleEngine<IBusinessResult>, RuleEngine>("RuleEngineClientA", new InjectionConstructor(new Collection<IBusinessRule<IBusinessResult>>()
            {
                _container.Resolve<IBusinessRule<IBusinessResult>>("VeteranPriceRule"),
                _container.Resolve<IBusinessRule<IBusinessResult>>("PublicPriceRule")
            }));

            _container.RegisterType<IRuleEngine<IBusinessResult>, RuleEngine>("RuleEngineClientB", new InjectionConstructor(new Collection<IBusinessRule<IBusinessResult>>()
            {
                _container.Resolve<IBusinessRule<IBusinessResult>>("VeteranPriceRule"),
                _container.Resolve<IBusinessRule<IBusinessResult>>("PublicPriceRule"),
                _container.Resolve<IBusinessRule<IBusinessResult>>("CompanyPriceRule")
            }));

            var ruleEngineClientA = _container.Resolve<IRuleEngine<IBusinessResult>>("RuleEngineClientA");
            var ruleEngineClientB = _container.Resolve<IRuleEngine<IBusinessResult>>("RuleEngineClientB");

            var resultA = ruleEngineClientA.Execute();
            var resultB = ruleEngineClientB.Execute();

            Assert.AreEqual(resultA.Price, 90);
            Assert.AreEqual(resultB.Price, 90);
        }
    }
}