using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Calculators.Web.Infrastructure
{
    public class CalculatorDescription
    {
        private string calculatorName;
        public CalculatorDescription(string calculatorName)
        {
            this.calculatorName = calculatorName;
        }

        public string Description
        {
            get { return GetDescription(); }
        }

        protected virtual string GetDescription()
        {
            string path = HttpContext.Current.Server.MapPath("~/App_Data/Resources/" + calculatorName.ToLower() + ".xml");
            XmlDocument document = new XmlDocument();
            string description = "";
            try
            {
                document.Load(path);
                XmlNode node = document.SelectSingleNode("/calculator");
                description = node["description"].InnerText;
            }
            catch (System.IO.FileNotFoundException)
            {
                description = "File not found";
            }
            return description;
        }

    }
}