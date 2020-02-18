using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnperoFrontend.Controllers
{
    public class ErrorController : BaseController
    {
        // GET: Error
        [BuildCommonHtml]
        public ActionResult Index()
        {
            return View();
        }
    }
}