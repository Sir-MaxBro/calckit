using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iMax.HtmlConverter
{
    public interface IHtmlConverter
    {
        string ConvertToHtml(object convertValue, string cssClass = "");
    }
}
