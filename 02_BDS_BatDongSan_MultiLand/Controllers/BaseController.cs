using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnperoFrontend.WebService;
namespace AnperoFrontend.Controllers
{
    public class BaseController : Controller
    {

        public static int StoreID = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["storeID"]);
        public static string TokenKey = System.Configuration.ConfigurationManager.AppSettings["storeTokenKey"];
        public static int shortCacheTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["shortCacheTime"]);
        public void GetTopArticle()
        {
            WebService.SearchArticleResults rs = new WebService.SearchArticleResults();
            WebService.SearchArticleResults TopNewArticle = new WebService.SearchArticleResults();
            WebService.SearchArticleResults customArticle = new WebService.SearchArticleResults();
            
            WebService.AnperoService service = new WebService.AnperoService();
            if (HttpRuntime.Cache["TopArticle"] != null)
            {
                rs = (WebService.SearchArticleResults)HttpRuntime.Cache["TopArticle"];
            }
            else
            {
                rs = service.SearchArticle(StoreID, TokenKey, 0, 1, 5, 2);
                if (rs != null)
                {
                    HttpRuntime.Cache.Insert("TopArticle", rs, null, DateTime.Now.AddMinutes(shortCacheTime+6), TimeSpan.Zero);
                }

            }
            if (HttpRuntime.Cache["TopNewArticle"] != null)
            {
                TopNewArticle = (WebService.SearchArticleResults)HttpRuntime.Cache["TopNewArticle"];
            }
            else
            {
                TopNewArticle = service.SearchArticle(StoreID, TokenKey, 0, 0, 12, 0);
                if (TopNewArticle != null)
                {
                    HttpRuntime.Cache.Insert("TopNewArticle", TopNewArticle, null, DateTime.Now.AddMinutes(shortCacheTime+10), TimeSpan.Zero);
                }

            }

            if (HttpRuntime.Cache["customArticle"] != null)
            {
                customArticle = (WebService.SearchArticleResults)HttpRuntime.Cache["customArticle"];
            }
            else
            {
                customArticle = service.SearchArticle(StoreID, TokenKey, 110, 0, 5, 0);
                if (TopNewArticle != null)
                {
                    HttpRuntime.Cache.Insert("customArticle", customArticle, null, DateTime.Now.AddMinutes(shortCacheTime + 10), TimeSpan.Zero);
                }
            }
            ViewData["FeatureArticle"] = rs;
            ViewData["TopNewArticle"] = TopNewArticle;
            ViewData["customArticle"] = customArticle;            
        }
        public void SetupCommonProduct()
        {
          
            WebService.SearchResult BestsaleProduct;
            WebService.AnperoService sv = new WebService.AnperoService();
            if (HttpRuntime.Cache["BestsaleProduct"] != null)
            {
                BestsaleProduct = (WebService.SearchResult)HttpRuntime.Cache["BestsaleProduct"];
            }
            else
            {
                BestsaleProduct = sv.SearchProduct(StoreID, TokenKey, "", "", "", 0, 1999999990, 1, 6, "", SearchOrder.TimeDesc, 2);
               
                if (BestsaleProduct != null)
                {
                    HttpRuntime.Cache.Insert("BestsaleProduct", BestsaleProduct, null, DateTime.Now.AddMinutes(shortCacheTime), TimeSpan.Zero);
                }

            }
         
            ViewData["BestsaleProduct"] = BestsaleProduct;
        }

    }
    public class BuildCommonHtml : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            WebService.AnperoService service = new WebService.AnperoService();

            var rs = service.GetCommonConfig(CommonConfig.StoreID, CommonConfig.TokenKey);
            int shortCacheTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["shortCacheTime"]);
            if (HttpRuntime.Cache["commonInfo"] != null)
            {
                filterContext.Controller.ViewData["commonInfo"] = HttpRuntime.Cache["commonInfo"];
            }
            else
            {
                filterContext.Controller.ViewData["commonInfo"] = rs;
                if (rs != null)
                {
                    HttpRuntime.Cache.Insert("commonInfo", rs, null, DateTime.Now.AddMinutes(shortCacheTime), TimeSpan.Zero);
                }
            }
            WebService.Ads[] Slide = null;
            WebService.Ads[] AdsSlide = null;
            
            if (HttpRuntime.Cache["Slide"] != null)
            {
                filterContext.Controller.ViewData["slide"] = (WebService.Ads[])HttpRuntime.Cache["Slide"];
            }
            else
            {
                Slide = service.GetRandomAdsSlide(CommonConfig.StoreID, CommonConfig.TokenKey, PageContent.Slide, 1);

                filterContext.Controller.ViewData["slide"] = Slide;
                if (Slide != null)
                {
                    HttpRuntime.Cache.Insert("Slide", Slide, null, DateTime.Now.AddMinutes(shortCacheTime + 3), TimeSpan.Zero);
                }
            }
            if (HttpRuntime.Cache["AdsSlide"] != null)
            {
                filterContext.Controller.ViewData["AdsSlide"] = (WebService.Ads[])HttpRuntime.Cache["AdsSlide"];
            }
            else
            {
                AdsSlide = service.GetAdsSlide(CommonConfig.StoreID, CommonConfig.TokenKey, PageContent.Ads1);
                filterContext.Controller.ViewData["AdsSlide"] = AdsSlide;
                if (AdsSlide != null)
                {
                    HttpRuntime.Cache.Insert("AdsSlide", AdsSlide, null, DateTime.Now.AddMinutes(shortCacheTime + 1), TimeSpan.Zero);
                }
            }


        }
    }

    public partial class CommonConfig
    {
        public static int StoreID = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["storeID"]);
        public static string TokenKey = System.Configuration.ConfigurationManager.AppSettings["storeTokenKey"];
    }
    public static class SearchOrder
    {

        public static string PriceDesc = "pricedesc";
        public static string PricedAsc = "pricedasc";
        public static string TimeDesc = "timeDesc";
        public static string NameDesc = "nameDesc";
        public static string NameAsc = "nameAsc";
    }
    public static class PageContent
    {
        public static string Slide = "slide";
        public static string Ads1 = "ads1";
        public static string Ads2 = "ads2";
        public static string Ads3 = "ads3";

    }

}