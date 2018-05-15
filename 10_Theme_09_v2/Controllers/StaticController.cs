﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnperoFrontend.Controllers
{
    public class StaticController : BaseController
    {
        // GET: Static
        [OutputCache(Duration = 300, VaryByParam = "none")]
        public String Css()
        {
            try
            {
                Response.AppendHeader("Cache-Control", "max-age=1200,stale-while-revalidate=3600"); // HTTP 1.1.
                Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
                Response.AppendHeader("Cache-Control", "public");
                WebService.AnperoService service = new WebService.AnperoService();
                string tr = service.GetWebContent(StoreID, TokenKey, 7);
                return service.GetWebContent(StoreID, TokenKey, 7);
            }
            catch (Exception)
            {
                return "";
            }

       

        }
    }
}