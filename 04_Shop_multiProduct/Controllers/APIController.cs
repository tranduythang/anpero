using Anpero.PaymentApi.NganLuong;
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
            AnperoService ws = new AnperoService();
            
            ViewBag.Msg = "";
            return View();
        }
        [BuildCommonHtml]
        public ActionResult NLCallback(String Token)
        {
            AnperoService ws = new AnperoService();
            PaymentConfig[] pc=  ws.GetPaymentAPIConfig(StoreID, TokenKey);
            if(pc!=null && pc.Length > 0)
            {
                for (int i = 0; i <pc.Length; i++)
                {
                    if (pc[i].MerchantId.ToUpper() == "NL")
                    {
                        RequestCheckOrder info = new RequestCheckOrder();
                        //for test
                        //info.Merchant_id = "24338";
                        //info.Merchant_password = "12345612";
                        info.Merchant_id = pc[i].MerchantId;// "52084";
                        info.Merchant_password = pc[i].MerchantPassword;// "3c0ba9b81b28cbfa3d675d59fc5ccc41";
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
                        ws.UpdateOrderStatus(StoreID, TokenKey, Convert.ToInt32(result.order_code), Convert.ToInt32(result.paymentAmount), "Ngân Lượng (Mã giao dịch Ngân Lượng " + result.transactionId + ")");
                        ViewBag.Msg = rs;
                    }
                }
            }
            
            return View("Index");
        }
        [BuildCommonHtml]
        public ActionResult NLCancel(string Token)
        {
            RequestCheckOrder info = new RequestCheckOrder();            
            AnperoService ws = new AnperoService();
            PaymentConfig[] pc = ws.GetPaymentAPIConfig(StoreID, TokenKey);
            if (pc != null && pc.Length > 0)
            {
                for (int i = 0; i < pc.Length; i++)
                {
                    if (pc[i].MerchantId.ToUpper() == "NL")
                    {
                        info.Merchant_id = pc[i].MerchantId;// "52084";
                        info.Merchant_password = pc[i].MerchantPassword;// "52084";
                        info.Token = Token;
                        APICheckoutV3 objNLChecout = new APICheckoutV3();
                        ResponseCheckOrder result = objNLChecout.GetTransactionDetail(info);
                        ViewBag.Msg = "Giao dịch đã được hủy, cảm ơn quý khách đã sử dụng dịch vụ của chúng tôi";
                    }
                }
            }
                      
            return View("Index");            
        }
        
    }
}