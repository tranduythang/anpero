using AnperoFrontend.WebService;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
namespace AnperoFrontend.Controllers
{
    public class HomeController : BaseController
    {
        [BuildCommonHtml]
        public ActionResult Index()
        {
            GetNewestProduct();
            SetupCommonProduct();
            SetUpSlideAds();
            WebService.SearchResult featureleProduct;
            WebService.AnperoService sv = new WebService.AnperoService();
            Anpero.ICacheService cache = new Anpero.CacheService();
            if (!cache.TryGet("featureleProduct",out featureleProduct){
                featureleProduct = sv.SearchProduct(StoreID, TokenKey, "", "", "", 0, 1999999990, 1, 8, "", SearchOrder.TimeDesc, 2, string.Empty);
                if (featureleProduct != null)
                {
                    cache.AddOrUpdate("featureleProduct", featureleProduct, new TimeSpan(0, 10, 0));                    
                }
            }
            ViewData["featureleProduct"] = featureleProduct;
            return View();
        }
        private void SetUpSlideAds()
        {
           
            int shortCacheTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["shortCacheTime"]);
            WebService.AnperoService service = new WebService.AnperoService();


            //WebService.Ads[] Ads1 = null;
            //if (HttpRuntime.Cache["AdsSlide"] != null)
            //{
            //    ViewData["AdsSlide"] = (WebService.Ads[])HttpRuntime.Cache["AdsSlide"];
            //}
            //else
            //{
            //    Ads1 = service.GetAdsSlide(StoreID, TokenKey, PageContent.Ads1);
            //    ViewData["AdsSlide"] = Ads1;
            //    if (Ads1 != null)
            //    {
            //        HttpRuntime.Cache.Insert("AdsSlide", Ads1, null, DateTime.Now.AddMinutes(shortCacheTime + 2), TimeSpan.Zero);
            //    }
            //}
            WebService.Ads[] Ads2 = null;
            if (HttpRuntime.Cache["Ads2"] != null)
            {
                ViewData["AdsSlide2"] = (WebService.Ads[])HttpRuntime.Cache["Ads2"];
            }
            else
            {
                Ads2 = service.GetAdsSlide(StoreID, TokenKey, PageContent.Ads2);
                ViewData["AdsSlide2"] = Ads2;
                if (Ads2 != null)
                {
                    HttpRuntime.Cache.Insert("Ads2", Ads2, null, DateTime.Now.AddMinutes(shortCacheTime + 1), TimeSpan.Zero);
                }
            }
            Response.Cache.SetExpires(DateTime.Now.AddMinutes(60));
            Response.Cache.SetCacheability(HttpCacheability.Public);
        }
        private SearchResult GetCustomproduct(int id)
        {
            WebService.AnperoService service = new WebService.AnperoService();
            WebService.SearchResult searchResult = new WebService.SearchResult();
            int shortCacheTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["shortCacheTime"]);
            if (HttpRuntime.Cache["Customproduct" + id] != null)
            {
                searchResult = (WebService.SearchResult)HttpRuntime.Cache["Customproduct" + id];
            }
            else
            {
                searchResult = service.GetProductByCategory(StoreID, TokenKey, id, 1, 10, 0);
                if (searchResult != null)
                {
                    HttpRuntime.Cache.Insert("Customproduct"+id, searchResult, null, DateTime.Now.AddMinutes(shortCacheTime), TimeSpan.Zero);
                }
            }
            return searchResult;
        }
        private void GetNewestProduct()
        {
            WebService.AnperoService service = new WebService.AnperoService();
            WebService.SearchResult searchResult = new WebService.SearchResult();
            int shortCacheTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["shortCacheTime"]);
            if (HttpRuntime.Cache["newestProduct"] != null)
            {
                searchResult = (WebService.SearchResult)HttpRuntime.Cache["newestProduct"];
            }
            else
            {
                searchResult = service.SearchProduct(StoreID, TokenKey, "", "", "", 0, 1999999999, 1, 16, "", SearchOrder.TimeDesc, 0, string.Empty);
                if (searchResult != null)
                {
                    HttpRuntime.Cache.Insert("newestProduct", searchResult, null, DateTime.Now.AddMinutes(shortCacheTime), TimeSpan.Zero);
                }
            }
            ViewData["newestProduct"] = searchResult;
        }
    
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [BuildCommonHtml]
        public ActionResult Contact()
        {
            return View();
        }
    }
}