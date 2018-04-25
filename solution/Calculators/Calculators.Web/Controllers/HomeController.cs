using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calculators.Web.Models;
using Calculators.Web.Logic.Navigations;
using iMax.HtmlConverter;

namespace Calculators.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var model = CalculatorNavigations.Navs;
            return View(model);
        }
    }
}
