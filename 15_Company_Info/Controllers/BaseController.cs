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
        public Anpero.ICacheService cacheService = new Anpero.CacheService();
       
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
                BestsaleProduct = sv.SearchProduct(StoreID, TokenKey, "", "", "", 0, 1999999990, 1, 6, "", SearchOrder.TimeDesc, 2,string.Empty);
               
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
            Anpero.ICacheService cacheService = new Anpero.CacheService();
            Webconfig config =  new Webconfig();
            WebService.Ads[] Slide = null;
            WebService.Ads[] AdsSlide = null;
            WebService.SearchArticleResults FeatureArticle = new WebService.SearchArticleResults();
            int shortCacheTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["shortCacheTime"]);
            if (!cacheService.TryGet("commonInfo", out config))
            {
                config = service.GetCommonConfig(CommonConfig.StoreID, CommonConfig.TokenKey);
                cacheService.AddOrUpdate("commonInfo", config, new TimeSpan(0, 6, 0));
            }
            if (!cacheService.TryGet("Slide", out Slide))
            {
                Slide = service.GetRandomAdsSlide(CommonConfig.StoreID, CommonConfig.TokenKey, PageContent.Slide, 1);                
                cacheService.AddOrUpdate("Slide", Slide, new TimeSpan(0, 6, 0));
            }
            if (!cacheService.TryGet("AdsSlide", out AdsSlide))
            {
                AdsSlide = service.GetAdsSlide(CommonConfig.StoreID, CommonConfig.TokenKey, PageContent.Ads1);
                cacheService.AddOrUpdate("AdsSlide", AdsSlide, new TimeSpan(0, 6, 0));
            }
            if (!cacheService.TryGet("FeatureArticle", out AdsSlide))
            {
                FeatureArticle = service.SearchArticle(CommonConfig.StoreID, CommonConfig.TokenKey, 0, 1, 5, 2);
                cacheService.AddOrUpdate("AdsSlide", FeatureArticle, new TimeSpan(0, 6, 0));
            }


            filterContext.Controller.ViewData["slide"] = Slide;
            filterContext.Controller.ViewData["FeatureArticle"] = FeatureArticle;
            filterContext.Controller.ViewData["AdsSlide"] = AdsSlide;
            filterContext.Controller.ViewData["commonInfo"] = config;
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