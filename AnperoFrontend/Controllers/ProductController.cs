using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnperoFrontend.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Product
        [BuildCommonHtml]
        public ActionResult Index(int id)
        {
          
            WebService.AnperoService sv = new WebService.AnperoService();
            WebService.ProductItem item= sv.GetProductDetai(StoreID,TokenKey,id);
            ViewData["prDetail"] = item;
            ViewBag.Title = item.PrName;
            
            return View();
        }
    }
}