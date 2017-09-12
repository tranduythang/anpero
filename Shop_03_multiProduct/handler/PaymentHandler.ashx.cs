using Anpero.PaymentApi.NganLuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnperoFrontend.handler
{
    /// <summary>
    /// Summary description for PaymentHandler
    /// </summary>
    public class PaymentHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string rs = "0";
            try
            {
                string op = context.Request["op"].ToLower();
                string captcha = context.Request["captcha"];
                int price = Convert.ToInt32(context.Request["price"]);
                int orderId = Convert.ToInt32(context.Request["orderId"]);

                string name = context.Request["name"];
                string shipingFee = context.Request["shipingFee"];
                string email = context.Request["email"];
                string phone = context.Request["phone"];
                Boolean valid = true;
                if (price <= 0 || orderId <= 0)
                {
                    valid = false;
                    rs = "Tiền thanh toán không hợp lệ";
                }
                if (String.IsNullOrEmpty(captcha) && valid)
                {
                    valid = false;
                    rs = "Vui lòng click vào ô kiểm tra";
                }
                if (valid)
                {
                    switch (op)
                    {
                        case "nlcheckout":
                            string payment_method = context.Request["payment_method"];
                            string str_bankcode = context.Request["bankcode"];
                            string order_description = context.Request["detail"];
                            string DomainName = HttpContext.Current.Request.Url.Host;

                            Anpero.PaymentApi.NganLuong.RequestInfo info = new Anpero.PaymentApi.NganLuong.RequestInfo();
                            //info.Merchant_id = "52084";
                            //info.Merchant_password = "3c0ba9b81b28cbfa3d675d59fc5ccc41";
                            //info.Receiver_email = "hotro@anpero.com";
                            // for test
                            info.Merchant_id = "36680";
                            info.Merchant_password = "matkhauketnoi";
                            info.Receiver_email = "demo@nganluong.vn";
                            info.cur_code = "vnd";
                            info.bank_code = str_bankcode;

                            info.Order_code = orderId.ToString();
                            info.Total_amount = price.ToString();
                            info.fee_shipping = "0";
                            info.Discount_amount = "0";
                            info.order_description = order_description;
                            info.return_url = DomainName + "/payment/nl";
                            info.cancel_url = DomainName + "/payment/cancelnl";

                            info.Buyer_fullname = name;
                            info.Buyer_email = email;
                            info.Buyer_mobile = phone;

                            APICheckoutV3 objNLChecout = new APICheckoutV3();
                            ResponseInfo result = objNLChecout.GetUrlCheckout(info, payment_method);

                            if (result.Error_code == "00")
                            {
                                rs = result.Checkout_url;
                            }
                            else
                                rs = result.Description;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {


            }


            context.Response.ContentType = "text/plain";
            context.Response.Write(rs);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}