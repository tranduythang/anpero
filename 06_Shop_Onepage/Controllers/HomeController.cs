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
           // ViewData["slide"] = service.GetAdsSlide(StoreID, TokenKey, PageContent.Slide);
            //ViewData["AdsSlide"] = service.GetAdsSlide(StoreID, TokenKey, PageContent.Ads1);
            //ViewData["AdsSlide2"] = service.GetAdsSlide(StoreID, TokenKey, PageContent.Ads2);
            ViewBag.pageName = "home";
            //GetNewestProduct();
            //SetupCommonProduct();
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
                ViewBag.HtmlContent ="Nội dung đang được cập nhật";                
            }
          
            return View();
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
                ViewData["slide1"] = (WebService.Ads[])HttpRuntime.Cache["slide1"];
            }
            else
            {
                Ads1 = service.GetAdsSlide(StoreID, TokenKey, PageContent.Ads1);
                ViewData["slide1"] = Ads1;
                if (Ads1 != null)
                {
                    HttpRuntime.Cache.Insert("slide1", Ads1, null, DateTime.Now.AddMinutes(shortCacheTime + 2), TimeSpan.Zero);
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