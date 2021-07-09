using Anpero;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;


namespace AnperoFrontend.Controllers
{
    public class BaseController : Controller
    {
        //if cloud frontend just change
        //public static int webinFo = Cloud.GetWebInfoByDomain("domainName");
        //public static string TokenKey = webinFo.TokenKey;
        //public static string StoreID = webinFo.StoreID;

        public static int StoreID = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["storeID"]);
        public static string TokenKey = System.Configuration.ConfigurationManager.AppSettings["storeTokenKey"];
        public static int shortCacheTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["shortCacheTime"]);

        public static string SaleProductCache = "saleProduct";
        public static string BestSaleProductCache = "BestsaleProduct";
        public static string TopArticleCache = "topArticleCache";
        public static string CommonInfoCache = "commonInfo";
        public static string NewestProductCache = "newestProduct";
        public static string SlideCache = "Slide";
        public static string Ads1Cache = "Ads1";
        public static string Ads2Cache = "Ads2";
        public static string Ads3Cache = "Ads3";
    }
    public class BuildCommonHtml : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            int shortCacheTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["shortCacheTime"]);

            int StoreID = CommonConfig.StoreID;
            string TokenKey = CommonConfig.TokenKey;

            //WebService.ProductItem[] saleProduct;
            WebService.SearchResult bestSaleProduct;
            //WebService.SearchArticleResults topArticle;
            WebService.Webconfig webConfig;

            WebService.AnperoService sv = new WebService.AnperoService();

            ICacheService cache = new CacheService();

            //if (!cache.TryGet(BaseController.SaleProductCache, out saleProduct))
            //{
            //    saleProduct = sv.GetSaleProduct(StoreID, TokenKey);
            //    cache.AddOrUpdate(BaseController.SaleProductCache, saleProduct, DateTime.Now.AddMinutes(shortCacheTime));
            //}

            if (!cache.TryGet(BaseController.BestSaleProductCache, out bestSaleProduct))
            {
                bestSaleProduct = sv.SearchProductFullData(StoreID, TokenKey, "0", "0", "0", 0, 99999999, 1, 7, "", SearchOrder.TimeDesc, 1, true);
                cache.AddOrUpdate(BaseController.BestSaleProductCache, bestSaleProduct, DateTime.Now.AddMinutes(shortCacheTime));
            }

            //if (!cache.TryGet(BaseController.TopArticleCache, out topArticle))
            //{
            //    topArticle = sv.SearchArticle(StoreID, TokenKey, 0, 1, 4, 2);
            //    cache.AddOrUpdate(BaseController.TopArticleCache, topArticle, DateTime.Now.AddMinutes(shortCacheTime));
            //}

            if (!cache.TryGet(BaseController.CommonInfoCache, out webConfig))
            {
                webConfig = sv.GetCommonConfig(CommonConfig.StoreID, CommonConfig.TokenKey);
                cache.AddOrUpdate(BaseController.CommonInfoCache, webConfig, DateTime.Now.AddMinutes(shortCacheTime));
            }

            //filterContext.Controller.ViewData["saleProduct"] = saleProduct;
            filterContext.Controller.ViewData["BestsaleProduct"] = bestSaleProduct;
            //filterContext.Controller.ViewData["FeatureArticle"] = topArticle;
            filterContext.Controller.ViewData["commonInfo"] = webConfig;
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