using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calculators.Web.Helpers
{
    public static class StringHelper
    {
        public static string AddBr(this string value)
        {
            return value.Replace("\r\n", "<br><br>");
        }
    }
}