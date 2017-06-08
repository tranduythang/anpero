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
            WebService.ProductItem item = sv.GetProductDetai(StoreID, TokenKey, id);
            WebService.SearchResult relateProduct = sv.SearchProduct(StoreID, TokenKey, item.CatID.ToString(), "", "", 0, 999999, 1, 5, "", SearchOrder.TimeDesc, 0);
            WebService.ProductItem[] saleProduct;
            if (HttpRuntime.Cache["saleProduct"] != null)
            {
                saleProduct = (WebService.ProductItem[])HttpRuntime.Cache["saleProduct"];
            }
            else
            {
                saleProduct = sv.GetSaleProduct(StoreID, TokenKey);
                HttpRuntime.Cache.Insert("saleProduct", saleProduct, null, DateTime.Now.AddMinutes(shortCacheTime), TimeSpan.Zero);
            }
        
            ViewData["relateProduct"] = relateProduct;
            ViewData["prDetail"] = item;
            ViewData["saleProduct"] = saleProduct;
            ViewBag.Title = item.PrName;

            return View();
        }
    }
}