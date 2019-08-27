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
            WebService.Ads[] Ads3 = null;
            //slide home back-ground
            if (!base.cache.TryGet(PageContent.Slide, out Slide))
            {
                Slide = service.GetAdsSlide(StoreID, TokenKey, PageContent.Slide);
                cache.AddOrUpdate(PageContent.Slide, Slide, new TimeSpan(0, shortCacheTime, 0));
            }
            if (!base.cache.TryGet(PageContent.Ads3, out Ads3))
            {
                Ads3 = service.GetAdsSlide(StoreID, TokenKey, PageContent.Ads3);
                cache.AddOrUpdate(PageContent.Ads3, Ads3, new TimeSpan(0, shortCacheTime, 0));
            }
            ViewData["slide"] = Slide;
            ViewData["Ads3"] = Ads3;
            


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
                searchResult = service.SearchProduct(StoreID, TokenKey, "", "", "", 1, 999999999, 1, 4, "", SearchOrder.TimeDesc, 0, string.Empty);
                if (searchResult != null)
                {
                    HttpRuntime.Cache.Insert("newestProduct", searchResult, null, DateTime.Now.AddMinutes(shortCacheTime), TimeSpan.Zero);
                }
               
            }
           
            ViewData["newestProduct"] = searchResult;
                        
            WebService.SearchResult searchResult2 = new WebService.SearchResult();
            
            if (HttpRuntime.Cache["customProduct"] != null)
            {
                searchResult = (WebService.SearchResult)HttpRuntime.Cache["customProduct"];
            }
            else
            {
                searchResult = service.GetProductByParentCategory(StoreID, TokenKey, 178, 1, 8, 0);
                if (searchResult != null)
                {
                    HttpRuntime.Cache.Insert("customProduct", searchResult, null, DateTime.Now.AddMinutes(shortCacheTime), TimeSpan.Zero);
                }

            }

            ViewData["customProduct"] = searchResult;

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