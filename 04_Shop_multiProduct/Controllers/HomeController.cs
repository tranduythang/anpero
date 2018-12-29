using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace AnperoFrontend.Controllers
{
    
    public class HomeController : BaseController
    {
       
        [BuildCommonHtml]
        [BunderHtml]
        public ActionResult Index()
        {             
            WebService.AnperoService service = new WebService.AnperoService();
            //ViewData["slide"] = service.GetAdsSlide(StoreID, TokenKey, PageContent.Slide);
            //ViewData["AdsSlide"] = service.GetAdsSlide(StoreID, TokenKey, PageContent.Ads1);
          
            GetNewestProduct();
            SetupCommonProduct();
            GetTopArticle();
            SetUpSlideAds();
            return View();
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
                ViewBag.HtmlContent = "Nội dung đang được cập nhật";
            }

            return View();
        }
        public string PolicyAjax(int type)
        {
            try
            {
                WebService.AnperoService service = new WebService.AnperoService();
                return  service.GetWebContent(StoreID, TokenKey, type);
               
            }
            catch (Exception)
            {
                return "Nội dung đang được cập nhật";
            }

            
        }
        private void SetUpSlideAds()
        {
           
            int shortCacheTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["shortCacheTime"]);
            WebService.AnperoService service = new WebService.AnperoService();

            WebService.Ads[] Slide = null;
            if (HttpRuntime.Cache["Slide"] != null)
            {
                ViewData["slide"] = (WebService.Ads[])HttpRuntime.Cache["Slide"];
            }
            else
            {
                Slide= service.GetAdsSlide(StoreID, TokenKey, PageContent.Slide);
                ViewData["slide"] = Slide;
                if (Slide != null)
                {
                    HttpRuntime.Cache.Insert("Slide", Slide, null, DateTime.Now.AddMinutes(shortCacheTime+3), TimeSpan.Zero);
                }
            }
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
            WebService.Ads[] Ads2 = null;
            WebService.Ads[] Ads3 = null;
            WebService.Ads[] Ads4 = null;
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
            if (HttpRuntime.Cache["Ads3"] != null)
            {
                ViewData["AdsSlide3"] = (WebService.Ads[])HttpRuntime.Cache["Ads3"];
            }
            else
            {
                Ads3 = service.GetAdsSlide(StoreID, TokenKey, PageContent.Ads3);
                ViewData["AdsSlide3"] = Ads3;
                if (Ads2 != null)
                {
                    HttpRuntime.Cache.Insert("Ads3", Ads3, null, DateTime.Now.AddMinutes(shortCacheTime + 1), TimeSpan.Zero);
                }
            }
            if (HttpRuntime.Cache["Ads4"] != null)
            {
                ViewData["AdsSlide4"] = (WebService.Ads[])HttpRuntime.Cache["Ads4"];
            }
            else
            {
                Ads4 = service.GetAdsSlide(StoreID, TokenKey, PageContent.Ads4);
                ViewData["AdsSlide4"] = Ads4;
                if (Ads2 != null)
                {
                    HttpRuntime.Cache.Insert("Ads4", Ads4, null, DateTime.Now.AddMinutes(shortCacheTime + 1), TimeSpan.Zero);
                }
            }
            //Response.Cache.SetExpires(DateTime.Now.AddMinutes(60));
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