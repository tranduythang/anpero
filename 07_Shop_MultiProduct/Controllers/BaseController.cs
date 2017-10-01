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
            //WebService.Ads[] Slide = null;
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
            //slide of list product page
            //if (HttpRuntime.Cache["slide3"] != null)
            //{
            //    ViewData["slide3"] = (WebService.Ads[])HttpRuntime.Cache["slide3"];
            //}
            //else
            //{
            //    Slide = sv.GetAdsSlide(StoreID, TokenKey, PageContent.Ads3);
            //    ViewData["slide3"] = Slide;
            //    if (Slide != null)
            //    {
            //        HttpRuntime.Cache.Insert("slide3", Slide, null, DateTime.Now.AddMinutes(shortCacheTime + 6), TimeSpan.Zero);
            //    }
            //}
            ////slide of prodution menu
            //if (HttpRuntime.Cache["slide4"] != null)
            //{
            //    ViewData["slide4"] = (WebService.Ads[])HttpRuntime.Cache["slide4"];
            //}
            //else
            //{
            //    Slide = sv.GetAdsSlide(StoreID, TokenKey, PageContent.Ads4);
            //    ViewData["slide4"] = Slide;
            //    if (Slide != null)
            //    {
            //        HttpRuntime.Cache.Insert("slide4", Slide, null, DateTime.Now.AddMinutes(shortCacheTime + 6), TimeSpan.Zero);
            //    }
            //}
        }

    }
    public class BuildCommonHtml : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            int shortCacheTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["shortCacheTime"]);
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