using Anpero.PaymentApi.VTC;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
namespace AnperoFrontend.Controllers
{
    public class test
    {
        public string Input { get; set; }
    }
    public class HomeController : BaseController
    {
        
        [BuildCommonHtml]
        
        public ActionResult Index()
        {
            Response.AppendHeader("Cache-Control", "max-age=1200,stale-while-revalidate=3600"); // HTTP 1.1.
            Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
         
            WebService.AnperoService service = new WebService.AnperoService();
           //GetNewestProduct();
            SetUpSlideAds();
            return View();
        }
        public ActionResult VTC()
        {
            Response.AppendHeader("Cache-Control", "max-age=1200,stale-while-revalidate=3600"); // HTTP 1.1.
            Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.


            Anpero.PaymentApi.VTC.RequestParam param = new Anpero.PaymentApi.VTC.RequestParam();
            param.Amount = 100000;
            string plaintext = string.Format("{0}|{1}|{2}|{3}|{4}|{5}", param.Amount, param.Currency, param.Receiver_account, param.Reference_number, param.Website_id, "FSfgasdfafsadf&^&TR&(asdf654654654654654");
            param.Signature = Anpero.HashHelper.ComputeSha256Hash(plaintext);
            param.Reference_number = Guid.NewGuid().ToString();
            param.Website_id = 8032;
            param.Receiver_account = "0906006580";
            param.Reference_number = Guid.NewGuid().ToString();
            string url = Anpero.HttpRequesHelper<Anpero.PaymentApi.VTC.ReturnData>.GetUrlByParam("https://vtcpay.vn/bank-gateway/checkout.html", param);
            Anpero.HttpRequesHelper<Anpero.PaymentApi.VTC.ReturnData>.Post("https://vtcpay.vn/bank-gateway/checkout.html", param);
            /// Response.Redirect(url);
            WebService.AnperoService service = new WebService.AnperoService();
            //GetNewestProduct();
            SetUpSlideAds();
            return View();
        }
        public ActionResult VTCCallBack(ReturnData data)
        {
            var x = data;
            Response.AppendHeader("Cache-Control", "max-age=1200,stale-while-revalidate=3600"); // HTTP 1.1.
            Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.


            Anpero.PaymentApi.VTC.RequestParam param = new Anpero.PaymentApi.VTC.RequestParam();
            param.Amount = 100000;
            string plaintext = string.Format("{0}|{1}|{2}|{3}|{4}|{5}", param.Amount, param.Currency, param.Receiver_account, param.Reference_number, param.Website_id, "FSfgasdfafsadf&^&TR&(asdf654654654654654");
            param.Signature = Anpero.HashHelper.ComputeSha256Hash(plaintext);
            param.Reference_number = Guid.NewGuid().ToString();
            param.Website_id = 8032;
            param.Receiver_account = "0906006580";
            param.Reference_number = Guid.NewGuid().ToString();
            param.Url_return =Anpero.UrlHelper.GetCurrentRootUrl()+ "/home/VTCCallBack";
            string url = Anpero.HttpRequesHelper<Anpero.PaymentApi.VTC.ReturnData>.GetUrlByParam("https://vtcpay.vn/bank-gateway/checkout.html", param);
            Anpero.HttpRequesHelper<Anpero.PaymentApi.VTC.ReturnData>.Post("https://vtcpay.vn/bank-gateway/checkout.html", param);
            Response.Redirect(url);
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
                Slide = service.GetAdsSlide(StoreID, TokenKey, PageContent.Slide);
                ViewData["slide"] = Slide;
                if (Slide != null)
                {
                    HttpRuntime.Cache.Insert("Slide", Slide, null, DateTime.Now.AddMinutes(shortCacheTime+3), TimeSpan.Zero);
                }
            }

            WebService.Ads[] ads1 = null;
            if (HttpRuntime.Cache["ads1"] != null)
            {
                ViewData["ads1"] = (WebService.Ads[])HttpRuntime.Cache["ads1"];
            }
            else
            {
                ads1 = service.GetAdsSlide(StoreID, TokenKey, PageContent.Ads1);
                ViewData["ads1"] = ads1;
                if (Slide != null)
                {
                    HttpRuntime.Cache.Insert("ads1", ads1, null, DateTime.Now.AddMinutes(shortCacheTime + 3), TimeSpan.Zero);
                }
            }
            //WebService.Ads[] Ads2 = null;
            //if (HttpRuntime.Cache["ads2"] != null)
            //{
            //    ViewData["ads2"] = (WebService.Ads[])HttpRuntime.Cache["ads2"];
            //}
            //else
            //{
            //    Ads2 = service.GetAdsSlide(StoreID, TokenKey, PageContent.Ads2);
            //    ViewData["Ads2"] = Ads2;
            //    if (Slide != null)
            //    {
            //        HttpRuntime.Cache.Insert("Ads2", Ads2, null, DateTime.Now.AddMinutes(shortCacheTime + 3), TimeSpan.Zero);
            //    }
            //}
            WebService.Ads[] ads3 = null;
            if (HttpRuntime.Cache["ads3"] != null)
            {
                ViewData["ads3"] = (WebService.Ads[])HttpRuntime.Cache["ads3"];
            }
            else
            {
                ads3 = service.GetAdsSlide(StoreID, TokenKey, PageContent.Ads3);
                ViewData["ads3"] = ads3;
                if (Slide != null)
                {
                    HttpRuntime.Cache.Insert("Ads2", ads3, null, DateTime.Now.AddMinutes(shortCacheTime + 3), TimeSpan.Zero);
                }
            }
            
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
                searchResult = service.SearchProduct(StoreID, TokenKey, "", "", "", 1, 999999999, 1, 7, "", SearchOrder.TimeDesc, 0);
                if (searchResult != null)
                {
                    HttpRuntime.Cache.Insert("newestProduct", searchResult, null, DateTime.Now.AddMinutes(shortCacheTime), TimeSpan.Zero);
                }
               
            }
           
            ViewData["newestProduct"] = searchResult;
                        
            //WebService.SearchResult searchResult2 = new WebService.SearchResult();
            
            //if (HttpRuntime.Cache["customProduct"] != null)
            //{
            //    searchResult = (WebService.SearchResult)HttpRuntime.Cache["customProduct"];
            //}
            //else
            //{
            //    searchResult = service.GetProductByParentCategory(StoreID, TokenKey, 178, 1, 8, 0);
            //    if (searchResult != null)
            //    {
            //        HttpRuntime.Cache.Insert("customProduct", searchResult, null, DateTime.Now.AddMinutes(shortCacheTime), TimeSpan.Zero);
            //    }

            //}

            //ViewData["customProduct"] = searchResult;

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
                ViewBag.HtmlContent ="";
            }
            return View();
        }
        [BuildCommonHtml]
        public ActionResult Contact()
        {
            
            return View();
        }
        public string PolicyAjax(int type)
        {
            try
            {
                WebService.AnperoService service = new WebService.AnperoService();
                return service.GetWebContent(StoreID, TokenKey, type);
            }
            catch (Exception)
            {
                return "";
            }


        }
    }
}