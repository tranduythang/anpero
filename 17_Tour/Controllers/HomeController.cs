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
            GetNewestProduct();
            SetUpSlideAds();
            return View();
        }
        [BuildCommonHtml]
        public ActionResult IconList()
        {
            return View();
        }
        private void SetUpSlideAds()
        {
           
            int shortCacheTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["shortCacheTime"]);
            WebService.AnperoService service = new WebService.AnperoService();

            WebService.Ads[] Slide = null;
            WebService.Ads[] ads1 = null;
            WebService.Ads[] Ads2 = null;
            WebService.Ads[] Ads3 = null;
            WebService.Ads[] Ads4 = null;
            
            if (!base.cacheService.TryGet("Slide",out Slide))          
            {
                Slide = service.GetAdsSlide(StoreID, TokenKey, PageContent.Slide);                
                cacheService.AddOrUpdate("Slide", Slide,new TimeSpan(0,0,10,0,0));
            }

            if (!base.cacheService.TryGet("ads1", out ads1))
            {
                ads1 = service.GetAdsSlide(StoreID, TokenKey, PageContent.Ads1);              
                cacheService.AddOrUpdate("ads1", ads1, new TimeSpan(0, 0, 10, 0, 0));
            }
            if (!base.cacheService.TryGet("Ads2", out Ads2))
            {
                Ads2 = service.GetAdsSlide(StoreID, TokenKey, PageContent.Ads2);
                cacheService.AddOrUpdate("Ads2", Ads2, new TimeSpan(0, 0, 10, 0, 0));
            }
            if (!base.cacheService.TryGet("Ads3", out Ads3))
            {
                Ads3 = service.GetAdsSlide(StoreID, TokenKey, PageContent.Ads3);
                cacheService.AddOrUpdate("Ads3", Ads3, new TimeSpan(0, 0, 10, 0, 0));
            }
            if (!base.cacheService.TryGet("Ads4", out Ads4))
            {
                Ads4 = service.GetAdsSlide(StoreID, TokenKey, PageContent.Ads4);
                cacheService.AddOrUpdate("Ads4", Ads4, new TimeSpan(0, 0, 10, 0, 0));
            }
            
            //WebService.Ads[] ads3 = null;
            //if (HttpRuntime.Cache["ads3"] != null)
            //{
            //    ViewData["ads3"] = (WebService.Ads[])HttpRuntime.Cache["ads3"];
            //}
            //else
            //{
            //    ads3 = service.GetAdsSlide(StoreID, TokenKey, PageContent.Ads3);
            //    ViewData["ads3"] = ads3;
            //    if (Slide != null)
            //    {
            //        HttpRuntime.Cache.Insert("Ads2", ads3, null, DateTime.Now.AddMinutes(shortCacheTime + 3), TimeSpan.Zero);
            //    }
            //}
            ViewData["slide"] = Slide;
            ViewData["ads1"] = ads1;
            ViewData["ads2"] = Ads2;
            ViewData["ads3"] = Ads3;
            ViewData["ads4"] = Ads4;
           

            Response.Cache.SetCacheability(HttpCacheability.Public);
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