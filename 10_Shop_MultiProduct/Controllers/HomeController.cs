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
        [BuildCommonHtml]
        public ActionResult VTC()
        {
            Response.AppendHeader("Cache-Control", "max-age=1200,stale-while-revalidate=3600"); // HTTP 1.1.
            Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.


            Anpero.PaymentApi.VTC.RequestParam param = new Anpero.PaymentApi.VTC.RequestParam();

        //amount | 
        //bill_to_address | 
        //bill_to_email | 
        //bill_to_forename | 
        //bill_to_phone | 
        //bill_to_surname | 
        //currency | 
        //language | 
        //payment_type | 
        //receiver_account | 
        //reference_number | 
        //website_id | 
        //SecurityCode
        https://vtcpay.vn/bank-gateway/checkout.html?Receiver_account=0906006580&Amount=1000000&Website_id=8032&Signature=5a04442622aaa9514563f61231a0e98f4918d8b3b881f987fc60299dd127a6f4
            param.Website_id = 8032;
            param.Amount = 100000;
            param.Bill_to_address = "Bill_to_address";
            param.Bill_to_phone = "0906006580";
            param.Receiver_account = "0906006580";
            
            
            param.Reference_number = "OD2";
            string securityKey = string.Empty;
            securityKey = param.Amount.ToString();
            securityKey += "|" + param.Bill_to_address;
            securityKey += "|" + param.Bill_to_phone;

            securityKey += "|"+ param.Currency;
            //securityKey += "|" + param.Language;
            securityKey += "|" + param.Receiver_account;
            securityKey += "|" + param.Reference_number;
            securityKey += "|" + param.Website_id;
            securityKey += "|" + @"FSfgasdfafsadf&^&TR&(asdf654654654654654";
        
            param.Signature = Anpero.HashHelper.ComputeSha256Hash(securityKey);

            //ReturnData x3;
            //string x1;
            //try
            //{
            //     x1 = Anpero.HttpRequesHelper<Anpero.PaymentApi.VTC.ReturnData>.HttpPost("https://vtcpay.vn/bank-gateway/checkout.html", param,true);

            //}
            //catch (Exception ex)
            //{
            //}
            //try
            //{

            //     x3 = Anpero.HttpRequesHelper<Anpero.PaymentApi.VTC.ReturnData>.Get("https://vtcpay.vn/bank-gateway/checkout.html", param);
            //}
            //catch (Exception ex)
            //{
            //}

            string url = Anpero.HttpRequesHelper<Anpero.PaymentApi.VTC.ReturnData>.GetUrlByParam("https://vtcpay.vn/bank-gateway/checkout.html", param);
            Response.Redirect(url);
            WebService.AnperoService service = new WebService.AnperoService();
            //GetNewestProduct();
            SetUpSlideAds();
            return View();
        }
        [BuildCommonHtml]
        public ActionResult VTCCallBack(ReturnData data)
        {
            var x = data;
            
            return View(data);
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