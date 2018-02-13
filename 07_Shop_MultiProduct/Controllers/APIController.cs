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
            
            ViewBag.Msg = "s";
            return View();
        }
        [BuildCommonHtml]
        public ActionResult NLCallback(String Token)
        {   
            RequestCheckOrder info = new RequestCheckOrder();
            //for test
            //info.Merchant_id = "24338";
            //info.Merchant_password = "12345612";

            info.Merchant_id = "52084";
            info.Merchant_password = "3c0ba9b81b28cbfa3d675d59fc5ccc41";        
                
            info.Token = Token;
            APICheckoutV3 objNLChecout = new APICheckoutV3();
            ResponseCheckOrder result = objNLChecout.GetTransactionDetail(info);
            string rs = "Giao dịch Thành công, đơn hàng của quý khách đang được xử lý nhanh chóng";
            rs += result.description;
            rs += "<br>";
            rs +="Số tiền thanh toán: "+ result.paymentAmount;
            rs += "<br>";
            rs += "Mã giao dịch Ngân Lượng: " + result.transactionId;
            rs += "<br>";
            rs += "Mã đơn hàng: " + result.order_code;
            rs += "<br>";
            rs += "Tên người thanh toán: " + result.payerName;            
            AnperoService ws = new AnperoService();
            //update and add cash book
            ws.UpdateOrderStatus(StoreID, TokenKey, Convert.ToInt32(result.order_code), Convert.ToInt32(result.paymentAmount), "Ngân Lượng (Mã giao dịch" + result.transactionId + ")");            
            ViewBag.Msg = rs;
            return View("Index");
        }
        [BuildCommonHtml]
        public ActionResult NLCancel(string Token)
        {
            RequestCheckOrder info = new RequestCheckOrder();
            //for test
            //info.Merchant_id = "24338";
            //info.Merchant_password = "12345612";
            info.Merchant_id = "52084";
            info.Merchant_password = "3c0ba9b81b28cbfa3d675d59fc5ccc41";
            info.Token = Token;
            APICheckoutV3 objNLChecout = new APICheckoutV3();
            ResponseCheckOrder result = objNLChecout.GetTransactionDetail(info);
            ViewBag.Msg = "Giao dịch đã được hủy, cảm ơn quý khách đã sử dụng dịch vụ của chúng tôi";
            return View("Index");            
        }
        
    }
}