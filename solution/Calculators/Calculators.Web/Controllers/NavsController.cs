﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calculators.Web.Models;
using Calculators.Web.Logic.Navigations;

namespace Calculators.Web.Controllers
{
    public class NavsController : Controller
    {
        //
        // GET: /Navs/

        public PartialViewResult Navs()
        {
            var model = CalculatorNavigations.Navs;
            return PartialView(model);
        }
    }
}
