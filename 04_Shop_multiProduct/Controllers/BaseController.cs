using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnperoFrontend.WebService;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using Anpero;

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
            ViewData["FeatureArticle"] = rs;
        }
        public void SetupCommonProduct()
        {
            WebService.ProductItem[] saleProduct;
            WebService.SearchResult BestsaleProduct;
            WebService.AnperoService sv = new WebService.AnperoService();
            if (HttpRuntime.Cache["saleProduct"] != null)
            {
                saleProduct = (WebService.ProductItem[])HttpRuntime.Cache["saleProduct"];
            }
            else
            {
                saleProduct = sv.GetSaleProduct(StoreID, TokenKey);
                if (saleProduct != null)
                {
                    HttpRuntime.Cache.Insert("saleProduct", saleProduct, null, DateTime.Now.AddMinutes(shortCacheTime), TimeSpan.Zero);
                }

            }
            ViewData["saleProduct"] = saleProduct;


            if (HttpRuntime.Cache["BestsaleProduct"] != null)
            {
                BestsaleProduct = (WebService.SearchResult)HttpRuntime.Cache["BestsaleProduct"];
            }
            else
            {
                BestsaleProduct = sv.SearchProduct(StoreID, TokenKey, "", "", "", 0, 99999999, 1, 5, "", SearchOrder.TimeDesc, 1);
                if (BestsaleProduct != null)
                {
                    HttpRuntime.Cache.Insert("BestsaleProduct", BestsaleProduct, null, DateTime.Now.AddMinutes(shortCacheTime), TimeSpan.Zero);
                }

            }
            ViewData["BestsaleProduct"] = BestsaleProduct;
        }
        private static Webconfig commontInfo = null;

        public static Webconfig CommontInfo
        {
            get
            {
                if (commontInfo != null)
                {
                    return commontInfo;
                }
                else if (HttpRuntime.Cache["commonInfo"] != null)
                {
                    commontInfo = (Webconfig)HttpRuntime.Cache["commonInfo"];
                    return commontInfo;
                }
                else
                {
                    WebService.AnperoService service = new WebService.AnperoService();
                    commontInfo = service.GetCommonConfig(CommonConfig.StoreID, CommonConfig.TokenKey);
                    if (commontInfo != null)
                    {
                        HttpRuntime.Cache.Insert("commonInfo", commontInfo, null, DateTime.Now.AddMinutes(shortCacheTime), TimeSpan.Zero);
                        return commontInfo;
                    }
                    else
                    {
                        return new Webconfig();
                    }
                }
            }

            set
            {
                commontInfo = value;
            }
        }
    }
    public class BuildCommonHtml : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            int shortCacheTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["shortCacheTime"]);
            WebService.AnperoService service = new WebService.AnperoService();
            if (HttpRuntime.Cache["commonInfo"] != null)
            {
                Webconfig rs = (Webconfig)HttpRuntime.Cache["commonInfo"];
                filterContext.Controller.ViewData["commonInfo"] = rs;
            }
            else
            {
                Webconfig rs = service.GetCommonConfig(CommonConfig.StoreID, CommonConfig.TokenKey);
                filterContext.Controller.ViewData["commonInfo"] = rs;
                if (rs != null)
                {
                    HttpRuntime.Cache.Insert("commonInfo", rs, null, DateTime.Now.AddMinutes(shortCacheTime), TimeSpan.Zero);
                }
            }

            WebService.Ads[] AdsSlide3 = null;
            if (HttpRuntime.Cache["AdsSlide3"] != null)
            {
                filterContext.Controller.ViewData["AdsSlide3"] = (WebService.Ads[])HttpRuntime.Cache["AdsSlide3"];
            }
            else
            {
                AdsSlide3 = service.GetAdsSlide(CommonConfig.StoreID, CommonConfig.TokenKey, PageContent.Ads3);
                filterContext.Controller.ViewData["AdsSlide3"] = AdsSlide3;
                if (AdsSlide3 != null)
                {
                    HttpRuntime.Cache.Insert("AdsSlide3", AdsSlide3, null, DateTime.Now.AddMinutes(shortCacheTime + 1), TimeSpan.Zero);
                }
            }


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

    }

}