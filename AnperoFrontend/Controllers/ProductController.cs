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
            WebService.SearchResult relateProduct = sv.SearchProduct(StoreID, TokenKey, item.CatID.ToString(), "", "", 0, 999999, 1, 5, "", SearchOrder.TimeDesc, 0);
            ViewData["relateProduct"] = relateProduct;
            ViewData["prDetail"] = item;
            ViewBag.Title = item.PrName;
            
            return View();
        }
    }
}