using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnperoFrontend.handler
{
    /// <summary>
    /// Summary description for ProductHandler
    /// </summary>
    public class ProductHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string rs = "";
            string op = context.Request["op"];
            string captcha = context.Request["captcha"];
            Boolean valid = true;
            if (String.IsNullOrEmpty(captcha))
            {
                valid = false;
                rs = "Vui lòng click vào ô kiểm tra";
            }
            if (valid)
            {
                int st = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["storeID"]);
                string TokenKey = System.Configuration.ConfigurationManager.AppSettings["storeTokenKey"];
                switch (op)
                {
                    case "CreateOrder":
                        {

                            string name = context.Request["name"];
                            string email = context.Request["email"];
                            string phone = context.Request["phone"];
                            string address = context.Request["address"];
                            string ProductList = context.Request["ProductList"];

                            int shipingFee = 0;
                            try
                            {
                                shipingFee = Convert.ToInt32(context.Request["shipingFee"]);
                            }
                            catch (Exception)
                            {
                            }
                            string detail = context.Request["detail"];
                            int paymentMethod = 0;
                            int shippingMethod = 0;
                            try
                            {
                                paymentMethod = Convert.ToInt32(context.Request["PayMentType"]);
                            }
                            catch (Exception)
                            {
                            }
                            try
                            {
                                shippingMethod = Convert.ToInt32(context.Request["shippingMethod"]);
                            }
                            catch (Exception)
                            {
                            }
                            WebService.AnperoService sv = new WebService.AnperoService();
                            int rs2 = sv.AddOrder(st, TokenKey, captcha, name, email, phone, address, ProductList, shipingFee,shippingMethod, paymentMethod, detail);
                            if (rs2 > 0)
                            {
                                rs = rs2.ToString();
                            }
                            if (rs2 == -1)
                            {
                                rs = "Số điện thoại không đúng định dạng";
                            }
                            if (rs2 == -2)
                            {
                                rs = "Vui lòng kick vào ô kiểm tra";
                            }
                            break;
                        }
                    case "sendContact":
                        {   
                            string name = context.Request["name"];
                            string email = context.Request["email"];
                            string phone = context.Request["phone"];
                            string address = context.Request["address"];
                            string detail = context.Request["message"];

                            WebService.AnperoService sv = new WebService.AnperoService();
                            rs= sv.addContact(st, TokenKey, name, email, phone, address, detail, HttpContext.Current.Request.UserHostAddress,captcha).ToString();
                            break;
                        }
                    default:
                        break;
                }
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