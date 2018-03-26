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
            WebService.AnperoService service = new WebService.AnperoService();

            GetNewestProduct();
            SetupCommonProduct();
            GetTopArticle();
            SetUpSlideAds();
            return View();
        }
        private void SetUpSlideAds()
        {
           
            int shortCacheTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["shortCacheTime"]);
            WebService.AnperoService service = new WebService.AnperoService();

            WebService.Ads[] Slide = null;
            //slide home back-ground
            if (HttpRuntime.Cache["Slide"] != null)
            {
                ViewData["slide"] = (WebService.Ads[])HttpRuntime.Cache["Slide"];
            }
            else
            {             
                Slide = service.GetAdsSlide(StoreID, TokenKey, PageContent.Slide);
                ViewData["slide"] = Slide;
                if (Slide != null)
                {
                    HttpRuntime.Cache.Insert("Slide", Slide, null, DateTime.Now.AddMinutes(shortCacheTime+3), TimeSpan.Zero);
                }
            }
            //Slide home six img
            WebService.Ads[] Ads1 = null;
            if (HttpRuntime.Cache["AdsSlide"] != null)
            {
                ViewData["AdsSlide"] = (WebService.Ads[])HttpRuntime.Cache["AdsSlide"];
            }
            else
            {
                Ads1 = service.GetAdsSlide(StoreID, TokenKey, PageContent.Ads1);
                ViewData["AdsSlide"] = Ads1;
                if (Ads1 != null)
                {
                    HttpRuntime.Cache.Insert("AdsSlide", Ads1, null, DateTime.Now.AddMinutes(shortCacheTime + 2), TimeSpan.Zero);
                }
            }
            //img best-pro get one slide
            WebService.Ads[] Ads2 = null;
            if (HttpRuntime.Cache["AdsSlide2"] != null)
            {
                ViewData["AdsSlide2"] = (WebService.Ads[])HttpRuntime.Cache["Ads2"];
            }
            else
            {
                Ads2 = service.GetRandomAdsSlide(StoreID, TokenKey, PageContent.Ads2, 1);                    
                ViewData["AdsSlide2"] = Ads2;
                if (Ads2 != null)
                {
                    HttpRuntime.Cache.Insert("Ads2", Ads2, null, DateTime.Now.AddMinutes(shortCacheTime + 1), TimeSpan.Zero);
                }
            }
            //branch home
            //WebService.Ads[] Ads5 = null;
            //if (HttpRuntime.Cache["slide5"] != null)
            //{
            //    ViewData["slide5"] = (WebService.Ads[])HttpRuntime.Cache["slide5"];
            //}
            //else
            //{
            //    Ads5 = service.GetAdsSlide(StoreID, TokenKey, PageContent.Ads5);
            //    ViewData["slide5"] = Ads5;
            //    if (Ads5 != null)
            //    {
            //        HttpRuntime.Cache.Insert("slide5", Ads5, null, DateTime.Now.AddMinutes(shortCacheTime + 1), TimeSpan.Zero);
            //    }
            //}
            //customer comment home
            //WebService.Ads[] Ads6 = null;
            //if (HttpRuntime.Cache["slide6"] != null)
            //{
            //    ViewData["slide6"] = (WebService.Ads[])HttpRuntime.Cache["slide6"];
            //}
            //else
            //{
            //    Ads6 = service.GetAdsSlide(StoreID, TokenKey, PageContent.Ads6);
            //    ViewData["slide6"] = Ads6;
            //    if (Ads6 != null)
            //    {
            //        HttpRuntime.Cache.Insert("slide6", Ads6, null, DateTime.Now.AddMinutes(shortCacheTime + 1), TimeSpan.Zero);
            //    }
            //}
            Response.Cache.SetCacheability(HttpCacheability.Public);
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
                searchResult = service.SearchProduct(StoreID, TokenKey, "", "", "", 1, 999999999, 1, 4, "", SearchOrder.TimeDesc, 0);
                if (searchResult != null)
                {
                    HttpRuntime.Cache.Insert("newestProduct", searchResult, null, DateTime.Now.AddMinutes(shortCacheTime), TimeSpan.Zero);
                }
               
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
            SetupCommonProduct();
            return View();
        }
    }
}