using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Utilities.Caching;

namespace AnperoFrontend.Controllers
{
    public class HomeController : BaseController
    {
        [BuildCommonHtml]
        public ActionResult Index()
        {
            Response.AppendHeader("Cache-Control", "max-age=1200,stale-while-revalidate=3600"); // HTTP 1.1.
            Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.

            GetNewestProduct();
            SetUpSlideAds();

            return View();
        }
        private void SetUpSlideAds()
        {
            int shortCacheTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["shortCacheTime"]);
            WebService.AnperoService service = new WebService.AnperoService();

            WebService.Ads[] Slide;
            WebService.Ads[] ads1;
            WebService.Ads[] ads2;
            WebService.Ads[] ads3;

            ICacheService cache = new CacheService();

            if (!cache.TryGet(SlideCache, out Slide))
            {
                Slide = service.GetAdsSlide(StoreID, TokenKey, PageContent.Slide);
                cache.AddOrUpdate(SlideCache, Slide, DateTime.Now.AddMinutes(shortCacheTime));
            }

            ViewData["slide"] = Slide;

            if (!cache.TryGet(Ads1Cache, out ads1))
            {
                ads1 = service.GetAdsSlide(StoreID, TokenKey, PageContent.Ads1);
                cache.AddOrUpdate(Ads1Cache, ads1, DateTime.Now.AddMinutes(shortCacheTime));
            }
            ViewData["ads1"] = ads1;

            if (!cache.TryGet(Ads2Cache, out ads2))
            {
                ads1 = service.GetAdsSlide(StoreID, TokenKey, PageContent.Ads2);
                cache.AddOrUpdate(Ads2Cache, ads2, DateTime.Now.AddMinutes(shortCacheTime));
            }
            ViewData["ads2"] = ads2;

            if (!cache.TryGet(Ads3Cache, out ads3))
            {
                ads3 = service.GetAdsSlide(StoreID, TokenKey, PageContent.Ads3);
                cache.AddOrUpdate(Ads3Cache, ads3, DateTime.Now.AddMinutes(shortCacheTime));
            }
            ViewData["ads3"] = ads3;
            
            Response.Cache.SetCacheability(HttpCacheability.Public);
        }
        private void GetNewestProduct()
        {
            WebService.AnperoService service = new WebService.AnperoService();
            WebService.SearchResult searchResult = new WebService.SearchResult();
            int shortCacheTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["shortCacheTime"]);

            ICacheService cache = new CacheService();

            if (!cache.TryGet(NewestProductCache, out searchResult))
            {
                searchResult = service.SearchProduct(StoreID, TokenKey, "", "", "", 1, 999999999, 1, 7, "", SearchOrder.TimeDesc, 0,string.Empty);
                cache.AddOrUpdate(NewestProductCache, searchResult, DateTime.Now.AddMinutes(shortCacheTime));
            }
           
            ViewData["newestProduct"] = searchResult;
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