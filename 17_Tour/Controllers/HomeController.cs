using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
namespace AnperoFrontend.Controllers
{
    public class HomeController : BaseController
    {
        [BuildCommonHtml]
        //[OutputCache(Duration = 60, VaryByParam = "none")]
        public ActionResult Index()
        {
            Response.AppendHeader("Cache-Control", "max-age=1200,stale-while-revalidate=3600"); // HTTP 1.1.
            Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
            ViewData["hanhtrinh"] = service.GetProductByCategory(StoreID, TokenKey, 1082, 1, 14, 0);
            ViewData["khachmoi"] = service.GetProductByCategory(StoreID, TokenKey, 1088, 1, 14, 0);
            ViewData["thuvien"] = service.GetProductByCategory(StoreID, TokenKey, 1087, 1, 14, 0);
            ViewData["chiase"] = service.GetProductByCategory(StoreID, TokenKey, 1089, 1, 14, 0);
            GetNewestProduct();
            
            return View();
        }
        [BuildCommonHtml]
        public ActionResult IconList()
        {
            return View();
        }
      
        private void GetNewestProduct()
        {
            WebService.AnperoService service = new WebService.AnperoService();
             WebService.SearchResult searchResult = new WebService.SearchResult();            
            if (!cacheService.TryGet("topViewProduct", out searchResult))
            {
                searchResult = service.SearchProduct(StoreID, TokenKey, "", "", "", 1, 999999999, 1,5, "", SearchOrder.ViewTime, 0, string.Empty);
                if (searchResult != null)
                {
                    cacheService.AddOrUpdate("topViewProduct", searchResult, new TimeSpan(0, 10, 0));
                }
            }

            ViewData["topViewProduct"] = searchResult;
            //ViewData["saleProduct"] = saleProduct;
        }
        [BuildCommonHtml]
        public ActionResult Policy(int type)
        {
            try
            {
                WebService.AnperoService service = new WebService.AnperoService();
                ViewBag.HtmlContent = service.GetWebContent(StoreID, TokenKey, type);
                ViewBag.Title = Anpero.Constant.WebContentTitle.GetTitle(type);
            }
            catch (Exception)
            {
                ViewBag.HtmlContent ="Nội dung đang được cập nhật";
            }
            return View();
        }
        [BuildCommonHtml]
        public ActionResult Contact()
        {
            
            return View();
        }
        public string PolicyAjax(int type)
        {
            try
            {
                WebService.AnperoService service = new WebService.AnperoService();
                return service.GetWebContent(StoreID, TokenKey, type);
            }
            catch (Exception)
            {
                return "Nội dung đang được cập nhật";
            }


        }
    }
}