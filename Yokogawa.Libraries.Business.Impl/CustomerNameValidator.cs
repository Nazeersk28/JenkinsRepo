using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yokogawa.Libraries.Business.Interfaces;

namespace Yokogawa.Libraries.Business.Impl
{
    public class CustomerNameValidator : ICustomerValidator<string>
    {
        public bool Validate(string tObject)
        {
            var badKeywords = new string[] { "bad", "worse", "worst", "not good" };
            var isSearchStringBadWord = badKeywords.Contains(tObject);

            return isSearchStringBadWord;
        }
    }
}
