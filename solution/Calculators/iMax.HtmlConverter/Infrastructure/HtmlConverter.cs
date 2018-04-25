using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iMax.HtmlConverter.Infrastructure;

namespace iMax.HtmlConverter
{
    public class HtmlConverter : IHtmlConverter
    {
        public string ConvertToHtml(object convertValue, string cssClass = "")
        {
            string resultHtml = "";
            if (convertValue is object[,])
            {
                resultHtml = CreateTable(convertValue as object[,], cssClass);
            }
            else if (convertValue is IDictionary<object, object>)
            {
                resultHtml = CreateTable(convertValue as IDictionary<object, object>, cssClass);
            }
            else
            {
                resultHtml = CreateParagraph(convertValue, cssClass);
            }

            return resultHtml;
        }

        public static string CreateTable(object[,] value, string cssClass = "")
        {
            TagBuilder table = new TagBuilder("table", cssClass);

            for (int i = 0; i < value.GetLength(0); i++)
            {
                TagBuilder tagRow = new TagBuilder("tr");
                for (int j = 0; j < value.GetLength(1); j++)
                {
                    TagBuilder tagColumn = new TagBuilder("td");
                    tagColumn.InnerHtml(value[i, j].ToString());
                    tagRow.InnerHtml(tagColumn.Html);
                }
                table.InnerHtml(tagRow.Html);
            }
            return table.Html;
        }

        public static string CreateTable(IDictionary<object, object> value, string cssClass = "")
        {
            TagBuilder table = new TagBuilder("table", cssClass);
            foreach (var item in value)
            {
                TagBuilder tagRow = new TagBuilder("tr");

                TagBuilder tagColumn = new TagBuilder("td");
                tagColumn.InnerHtml(item.Key.ToString());
                tagRow.InnerHtml(tagColumn.Html);

                tagColumn = new TagBuilder("td");
                tagColumn.InnerHtml(item.Value.ToString());
                tagRow.InnerHtml(tagColumn.Html);

                table.InnerHtml(tagRow.Html);
            }
            return table.Html;
        }

        public static string CreateParagraph(object value, string cssClass = "")
        {
            TagBuilder paragraph = new TagBuilder("p", cssClass);
            paragraph.InnerHtml(value.ToString().Replace("\r\n", "<br/>"));
            return paragraph.Html;
        }
    }
}
