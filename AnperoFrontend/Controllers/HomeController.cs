using System;
using System.Collections.Generic;
using System.Linq;
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

            ViewData["slide"] = service.GetAdsSlide(StoreID, TokenKey, PageContent.Slide);
            ViewData["AdsSlide"] = service.GetAdsSlide(StoreID, TokenKey, PageContent.Ads1);

            GetNewestProduct();
            GetTopArticle();
            return View();
        }
        private void GetTopArticle()
        {
            WebService.SearchArticleResults rs = new WebService.SearchArticleResults();
            WebService.AnperoService service = new WebService.AnperoService();
            if (HttpRuntime.Cache["TopArticle"] != null)
            {
                rs = (WebService.SearchArticleResults)HttpRuntime.Cache["TopArticle"];
            }
            else
            {
                rs = service.SearchArticle(StoreID, TokenKey, 0, 1, 4, 1);
                HttpRuntime.Cache.Insert("TopArticle", rs, null, DateTime.Now.AddMinutes(shortCacheTime), TimeSpan.Zero);
            }
            ViewData["FeatureArticle"] = rs;
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
                HttpRuntime.Cache.Insert("newestProduct", searchResult, null, DateTime.Now.AddMinutes(shortCacheTime), TimeSpan.Zero);
            }
            ViewData["newestProduct"] = searchResult;

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}