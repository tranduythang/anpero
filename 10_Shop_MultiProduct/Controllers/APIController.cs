using Anpero.PaymentApi.NganLuong;
using Anpero.PaymentApi.VTC;
using AnperoFrontend.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace AnperoFrontend.Controllers
{
    public class APIController : BaseController
    {
        // GET: API
        [BuildCommonHtml]
        public ActionResult Index()
        {

            return View();
        }
        [BuildCommonHtml]
        public ActionResult NLCallback(String Token)
        {
            AnperoService ws = new AnperoService();
            PaymentConfig[] pc = ws.GetPaymentAPIConfig(StoreID, TokenKey);
            if (pc != null && pc.Length > 0)
            {
                for (int i = 0; i < pc.Length; i++)
                {
                    if (pc[i].Name.ToUpper() == "NL")
                    {
                        RequestCheckOrder info = new RequestCheckOrder();
                        //for test
                        //info.Merchant_id = "24338";
                        //info.Merchant_password = "12345612";
                        info.Merchant_id = pc[i].MerchantId;
                        info.Merchant_password = pc[i].MerchantPassword;
                        info.Token = Token;
                        APICheckoutV3 objNLChecout = new APICheckoutV3();
                        ResponseCheckOrder result = objNLChecout.GetTransactionDetail(info);

                        string rs = "Giao dịch Thành công, đơn hàng của quý khách đang được xử lý nhanh chóng";
                        rs += result.description;
                        rs += "<br>";
                        rs += "Số tiền thanh toán: " + result.paymentAmount;
                        rs += "<br>";
                        rs += "Mã giao dịch Ngân Lượng: " + result.transactionId;
                        rs += "<br>";
                        rs += "Mã đơn hàng: " + result.order_code;
                        rs += "<br>";
                        rs += "Tên người thanh toán: " + result.payerName;
                        //update and add cash book
                        ws.UpdateOrderStatus(StoreID, TokenKey, Convert.ToInt32(result.order_code), Convert.ToInt32(result.paymentAmount), "Ngân Lượng (Mã giao dịch Ngân Lượng " + result.transactionId + ")<br />" + rs);
                        ViewBag.Msg = rs;
                    }
                }
            }

            return View("Index");
        }
        [BuildCommonHtml]
        public ActionResult NLCancel(string Token)
        {
            ViewBag.Msg = "Giao dịch đã được hủy, cảm ơn quý khách đã sử dụng dịch vụ của chúng tôi";
            return View("Index");
        }

        public string GetVTCRedirectUrl(string orderId,double amount)
        {
            //AnperoService ws = new AnperoService();
            //int st = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["storeID"]);
            //string TokenKey = System.Configuration.ConfigurationManager.AppSettings["storeTokenKey"];
            //PaymentConfig[] pa = ws.GetPaymentAPIConfig(st, TokenKey);
            //if (pa != null && pa.Length > 0)
            //{
            //    for (int i = 0; i < pa.Length; i++)
            //    {
            //        if (pa[i].Isdefault && pa[i].PaymentCode.ToUpper() == "VTC")
            //        {
                        //var item = pa[i];
                        Anpero.PaymentApi.VTC.RequestParam param = new Anpero.PaymentApi.VTC.RequestParam();
                        param.website_id =Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["vtc_siteId"]);
                         param.amount = amount;

                        param.receiver_account = System.Configuration.ConfigurationManager.AppSettings["vtc_receiver_account"];
                        //param.url_return = Anpero.UrlHelper.GetRootLink() + "/API/VTCCallBack";
                        param.currency = System.Configuration.ConfigurationManager.AppSettings["vtc_payment_currency"];
            
                        //param.url_return = HttpUtility.UrlEncode(param.url_return);
                        param.reference_number = orderId;
                        string securityKey = string.Empty;
                        securityKey = param.amount.ToString();
                        securityKey += "|" + param.currency;
                        //securityKey += "|" + param.Language;
                        securityKey += "|" + param.receiver_account;
                        securityKey += "|" + param.reference_number;
                        //securityKey += "|" + param.url_return;
                        securityKey += "|" + param.website_id;
                        securityKey += "|" + System.Configuration.ConfigurationManager.AppSettings["vtc_MerchantPassword"];
                        param.signature = Anpero.HashHelper.ComputeSha256Hash(securityKey);

                        string url = Anpero.HttpRequesHelper<Anpero.PaymentApi.VTC.ReturnData>.GetUrlByParam("https://vtcpay.vn/bank-gateway/checkout.html", param);
            //for test
            //string url = Anpero.HttpRequesHelper<Anpero.PaymentApi.VTC.ReturnData>.GetUrlByParam("http://alpha1.vtcpay.vn/portalgateway/checkout.html", param);
            return url;

            //        }
            //    }
            //}

          
            
            
            
        }
        [BuildCommonHtml]
        public ActionResult VTCCallBack(ReturnData data)
        {
            var x = data;

            return View(data);
        }
    }
}