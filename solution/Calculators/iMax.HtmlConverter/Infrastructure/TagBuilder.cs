using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iMax.HtmlConverter.Infrastructure
{
    internal class TagBuilder
    {
        private string _tag;
        private string _cssClass;
        private StringBuilder _content;

        public TagBuilder(string tag)
            : this(tag, "")
        { }

        public TagBuilder(string tag, string cssClass)
        {
            _tag = tag;
            _cssClass = cssClass;
            _content = new StringBuilder();
        }

        public void AddCssClass(string cssClass)
        {
            _cssClass = cssClass;
        }

        private string CreateOpenTag()
        {
            string openTag;
            if (String.IsNullOrEmpty(_cssClass))
            {
                openTag = "<" + _tag + ">";
            }
            else
            {
                openTag = "<" + _tag + " class=\"" + _cssClass + "\">";
            }
            return openTag;
        }

        private string CreateCloseTag()
        {
            return "</" + _tag + ">";
        }

        public void InnerHtml(string content)
        {
            _content.Append(content);
        }

        public string Html
        {
            get
            {
                return CreateOpenTag() + _content.ToString() + CreateCloseTag();
            }
        }

        public override string ToString()
        {
            return this.Html;
        }
    }
}
