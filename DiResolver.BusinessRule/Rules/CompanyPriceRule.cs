﻿// MvcKata DiResolver.BusinessRules
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

using DiResolver.Business.Model.Utils;
using DiResolver.BusinessRules.Utils;

namespace DiResolver.BusinessRules.Rules
{
    public class CompanyPriceRule : IBusinessRule<IBusinessResult>
    {
        private readonly double _price;
        private readonly BusinessType _businessType;

        public CompanyPriceRule(double price, BusinessType businessType)
        {
            _price = price;
            _businessType = businessType;
        }

        public IBusinessResult Excecute()
        {
            if(_businessType.Equals(BusinessType.IsCompany))
            {
                var discount = _price * 0.3;
                return new BusinessResult(_price - discount);
            }
            return null;
        }
    }
}