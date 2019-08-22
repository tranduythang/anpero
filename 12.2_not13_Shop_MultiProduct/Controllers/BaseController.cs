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

        public static int StoreID = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["storeID"]);
        public static string TokenKey = System.Configuration.ConfigurationManager.AppSettings["storeTokenKey"];
        public static int shortCacheTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["shortCacheTime"]);
   
      

    }
    public class BuildCommonHtml : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            int shortCacheTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["shortCacheTime"]);
            SetupCommonData(filterContext);
            if (HttpRuntime.Cache["commonInfo"] != null)
            {
                filterContext.Controller.ViewData["commonInfo"] = HttpRuntime.Cache["commonInfo"];
            }
            else
            {
                WebService.AnperoService service = new WebService.AnperoService();
                var rs = service.GetCommonConfig(CommonConfig.StoreID, CommonConfig.TokenKey);
                filterContext.Controller.ViewData["commonInfo"] = rs;
                if (rs != null)
                {
                    HttpRuntime.Cache.Insert("commonInfo", rs, null, DateTime.Now.AddMinutes(shortCacheTime), TimeSpan.Zero);
                }
            }
          
            
            
        }
        Utilities.Caching.ICacheService cache = new Utilities.Caching.CacheService();
        public void SetupCommonData(ActionExecutedContext filterContext)
        {
            int shortCacheTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["shortCacheTime"]);
            int StoreID = CommonConfig.StoreID;
            string TokenKey = CommonConfig.TokenKey;
            WebService.ProductItem[] saleProduct;
            WebService.SearchResult BestsaleProduct;
            WebService.AnperoService sv = new WebService.AnperoService();
           
            if(!cache.TryGet("saleProduct",out saleProduct))
            {
                saleProduct = sv.GetSaleProduct(StoreID, TokenKey);
                if (saleProduct != null)
                {
                    cache.AddOrUpdate("saleProduct", saleProduct, new TimeSpan(0,shortCacheTime,0));                    
                }
            }
            
                
            
            filterContext.Controller.ViewData["saleProduct"] = saleProduct;
            if (HttpRuntime.Cache["BestsaleProduct"] != null)
            {
                BestsaleProduct = (WebService.SearchResult)HttpRuntime.Cache["BestsaleProduct"];
            }
            else
            {
                BestsaleProduct = sv.SearchProductFullData(StoreID, TokenKey, "0", "0", "0", 0, 99999999, 1, 7, "", SearchOrder.TimeDesc, 1, true);
                if (BestsaleProduct != null)
                {
                    HttpRuntime.Cache.Insert("BestsaleProduct", BestsaleProduct, null, DateTime.Now.AddMinutes(shortCacheTime), TimeSpan.Zero);
                }

            }
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
            if (HttpRuntime.Cache["TopArticle"] != null)
            {
                rs = (WebService.SearchArticleResults)HttpRuntime.Cache["TopArticle"];
            }
            else
            {
                rs = service.SearchArticle(StoreID, TokenKey, 0, 1, 4, 2);
                if (rs != null)
                {
                    HttpRuntime.Cache.Insert("TopArticle", rs, null, DateTime.Now.AddMinutes(shortCacheTime), TimeSpan.Zero);
                }

            }
            filterContext.Controller.ViewData["FeatureArticle"] = rs;
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