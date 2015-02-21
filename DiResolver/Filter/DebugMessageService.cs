using System;
using System.Globalization;

namespace DiResolver.Filter
{
    public class DebugMessageService : IDebugMessageService
    {
        public string Message { get { return DateTime.Now.ToString(CultureInfo.InvariantCulture); } }
    }
}