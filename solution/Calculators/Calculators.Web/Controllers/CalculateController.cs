using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calculators.Web.Infrastructure;
using Calculators.Domain.Abstract;
using Newtonsoft.Json;
using System.IO;
using Calculators.Web.Models;
using Calculators.Web.Helpers;
using Calculators.Web.Logic.Navigations;
using Calculators.Web.Logic.Infrastructure;
using Calculators.Web.Logic.Factory;

namespace Calculators.Web.Controllers
{
    public class CalculateController : Controller
    {
        //
        // GET: /Calculate/
        public ActionResult CalculatorPage(string calculateName, string calculateTitle, string calculateCategory)
        {
            var calculator = CalculatorFactory.GetCalculate(calculateName);
            var similarCalculators = CalculatorNavigations.GetCalculatorOfCategory(calculateCategory);
            similarCalculators.Remove(calculateName);
            CalculatorDescription description = new CalculatorDescription(calculateName);
            CalculatorViewModel model = new CalculatorViewModel()
            {
                Description = description.Description.AddBr(),
                Calculator = calculator,
                SimilarCalculators = similarCalculators
            };

            ViewBag.Category = calculateCategory;
            ViewBag.CalculateTitle = calculateTitle;
            ViewBag.Title = calculateTitle;
            ViewBag.Description = calculateTitle;
            ViewBag.Keywords = calculateTitle;

            return View(model);
        }

        //
        // POST: /Calculate/json
        [HttpPost]
        public ActionResult Calculate(string jsonData)
        {
            CalculatorParser calcParser = new CalculatorParser(jsonData);

            string htmlResult = calcParser.GetCalculateHtmlValue();

            string viewContent = ConvertViewToString("CalculateResult", htmlResult);

            return Json(new { Html = viewContent });
        }

        [HttpPost]
        public JsonResult CalculateAsync(CalculatorViewModel calculator)
        {
            var result = calculator.Calculator.CalculatorName;
            return Json(new { Response = result, JsonRequestBehavior.AllowGet });
        }

        private string ConvertViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (StringWriter writer = new StringWriter())
            {
                ViewEngineResult vResult = ViewEngines.Engines.FindPartialView(this.ControllerContext, viewName);
                ViewContext vContext = new ViewContext(this.ControllerContext, vResult.View, ViewData,
                    new TempDataDictionary(), writer);
                vResult.View.Render(vContext, writer);
                return writer.ToString();
            }
        }
    }
}
