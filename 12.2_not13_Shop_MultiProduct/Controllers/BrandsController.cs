using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnperoFrontend.Controllers
{
    [BuildCommonHtml]
    public class BrandsController :  BaseController
    {
        // GET: Bbrands
        public ActionResult Index()
        {
            return View();
        }
    }
}