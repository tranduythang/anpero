using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnperoFrontend.WebService;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace AnperoFrontend.Controllers
{
    public class BaseController : Controller
    {
        //if cloud frontend just change
        //public static int webinFo = Cloud.GetWebInfoByDomain("domainName");
        //public static string TokenKey = webinFo.TokenKey;
        //public static string StoreID = webinFo.StoreID;
        Lazy<WebService.AnperoService> lazyService = new Lazy<AnperoService>();
        public static int StoreID = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["storeID"]);
        public static string TokenKey = System.Configuration.ConfigurationManager.AppSettings["storeTokenKey"];
        public static int shortCacheTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["shortCacheTime"]);
        public Anpero.ICacheService cacheService = new Anpero.CacheService();
        public WebService.AnperoService service { get { return lazyService.Value; } }
    }
    public class BuildCommonHtml : ActionFilterAttribute
    {
        public Anpero.ICacheService cacheService = new Anpero.CacheService();
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            int shortCacheTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["shortCacheTime"]);
            WebService.AnperoService service = new WebService.AnperoService();
            SetupCommonData(filterContext);
            if (HttpRuntime.Cache["commonInfo"] != null)
            {
                filterContext.Controller.ViewData["commonInfo"] = HttpRuntime.Cache["commonInfo"];
            }
            else
            {
               
                var rs = service.GetCommonConfig(CommonConfig.StoreID, CommonConfig.TokenKey);
                filterContext.Controller.ViewData["commonInfo"] = rs;
                if (rs != null)
                {
                    HttpRuntime.Cache.Insert("commonInfo", rs, null, DateTime.Now.AddMinutes(shortCacheTime), TimeSpan.Zero);
                }
            }
           

            SetUpSlideAds(filterContext);
        }
        private void SetUpSlideAds(ActionExecutedContext filterContext)
        {

            int shortCacheTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["shortCacheTime"]);
            WebService.AnperoService service = new WebService.AnperoService();

            WebService.Ads[] Slide = null;
            WebService.Ads[] ads1 = null;
            WebService.Ads[] Ads2 = null;
            WebService.Ads[] Ads3 = null;
            WebService.Ads[] Ads4 = null;

            if (!cacheService.TryGet("Slide", out Slide))
            {
                Slide = service.GetAdsSlide(CommonConfig.StoreID, CommonConfig.TokenKey, PageContent.Slide);
                cacheService.AddOrUpdate("Slide", Slide, new TimeSpan(0, 0, 10, 0, 0));
            }

            if (!cacheService.TryGet("ads1", out ads1))
            {
                ads1 = service.GetAdsSlide(CommonConfig.StoreID, CommonConfig.TokenKey, PageContent.Ads1);
                cacheService.AddOrUpdate("ads1", ads1, new TimeSpan(0, 0, 10, 0, 0));
            }
            if (!cacheService.TryGet("Ads2", out Ads2))
            {
                Ads2 = service.GetAdsSlide(CommonConfig.StoreID, CommonConfig.TokenKey, PageContent.Ads2);
                cacheService.AddOrUpdate("Ads2", Ads2, new TimeSpan(0, 0, 10, 0, 0));
            }
            if (!cacheService.TryGet("Ads3", out Ads3))
            {
                Ads3 = service.GetAdsSlide(CommonConfig.StoreID, CommonConfig.TokenKey, PageContent.Ads3);
                cacheService.AddOrUpdate("Ads3", Ads3, new TimeSpan(0, 0, 10, 0, 0));
            }
            if (!cacheService.TryGet("Ads4", out Ads4))
            {
                Ads4 = service.GetAdsSlide(CommonConfig.StoreID, CommonConfig.TokenKey, PageContent.Ads4);
                cacheService.AddOrUpdate("Ads4", Ads4, new TimeSpan(0, 0, 10, 0, 0));
            }
            WebService.Ads[] Ads5 = null;
            if (!cacheService.TryGet("Ads5", out Ads5))
            {
                Ads5 = service.GetAdsSlide(CommonConfig.StoreID, CommonConfig.TokenKey, PageContent.Ads5);
                cacheService.AddOrUpdate("Ads5", Ads5, new TimeSpan(0, 0, 10, 0, 0));
            }
            filterContext.Controller.ViewData["ads5"] = Ads5;
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
            filterContext.Controller.ViewData["slide"] = Slide;
            filterContext.Controller.ViewData["ads1"] = ads1;
            filterContext.Controller.ViewData["ads2"] = Ads2;
            filterContext.Controller.ViewData["ads3"] = Ads3;
            filterContext.Controller.ViewData["ads4"] = Ads4;


            //Response.Cache.SetCacheability(HttpCacheability.Public);
        }
        public void SetupCommonData(ActionExecutedContext filterContext)
        {
            int shortCacheTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["shortCacheTime"]);
            int StoreID = CommonConfig.StoreID;
            string TokenKey = CommonConfig.TokenKey;
            WebService.ProductItem[] saleProduct;
            WebService.SearchResult BestsaleProduct;
            WebService.AnperoService sv = new WebService.AnperoService();          
          
           
            if (!cacheService.TryGet("BestsaleProduct", out BestsaleProduct))
            {
                //BestsaleProduct = sv.SearchProductFullData(StoreID, TokenKey, "0", "0", "0", 0, 99999999, 1, 7, "", SearchOrder.TimeDesc,2, true);
                BestsaleProduct = sv.SearchProduct(StoreID, TokenKey, "", "","", 0, int.MaxValue, 1, 99, "", SearchOrder.TimeDesc, 2, "");
                if (BestsaleProduct != null)
                {
                    cacheService.AddOrUpdate("BestsaleProduct", BestsaleProduct, new TimeSpan(0, 10, 0));                 
                }
            }
            if (!cacheService.TryGet("SaleProduct", out saleProduct))
            {
                saleProduct = sv.GetSaleProduct(StoreID, TokenKey).Take(6).ToArray();

                if (saleProduct != null)
                {
                    cacheService.AddOrUpdate("SaleProduct", saleProduct, new TimeSpan(0, 99, 0));
                }
            }
            filterContext.Controller.ViewData["saleProduct"] = saleProduct;
            filterContext.Controller.ViewData["BestsaleProduct"] = BestsaleProduct;
            GetTopArticle(filterContext, shortCacheTime);
            //slide of list product page

        }
        public void GetTopArticle(ActionExecutedContext filterContext,int shortCacheTime)
        {
            int StoreID = CommonConfig.StoreID;
            string TokenKey = CommonConfig.TokenKey;
            WebService.SearchArticleResults rs = new WebService.SearchArticleResults();
            WebService.AnperoService service = new WebService.AnperoService();

            if (!cacheService.TryGet("TopArticle", out rs))
            {
                rs = service.SearchArticle(StoreID, TokenKey, 0, 1, 4, 1);

                if (rs != null)
                {
                    cacheService.AddOrUpdate("TopArticle", rs, new TimeSpan(0, 7, 0));
                }
            }          
            filterContext.Controller.ViewData["TopArticle"] = rs;
        }
   
    }
 
    public class BunderHtml : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var originalFilter = filterContext.HttpContext.Response.Filter;
            filterContext.HttpContext.Response.Filter = new KeywordStream(originalFilter);
        }

    }
    public class KeywordStream : MemoryStream
    {
        private readonly Stream responseStream;

        public KeywordStream(Stream stream)
        {
            responseStream = stream;
        }

        public override void Write(byte[] buffer,
        int offset, int count)
        {
            string html = Encoding.UTF8.GetString(buffer);
            html = Regex.Replace(html, @"\s*(<[^>]+>)\s*", "$1", RegexOptions.Singleline);
            //html = Regex.Replace(html, @"\s+", "$1", RegexOptions.Singleline);
            buffer = Encoding.UTF8.GetBytes(html);
            responseStream.Write(buffer, offset, buffer.Length);
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
        public static string ViewTime = "ViewTime";
    }
    public static class PageContent
    {
        public static string Slide = "slide";
        public static string Ads1 = "ads1";
        public static string Ads2 = "ads2";
        public static string Ads3 = "ads3";
        public static string Ads4 = "ads4";
        public static string Ads5 = "ads5";
        public static string Ads6 = "ads6";

    }
}