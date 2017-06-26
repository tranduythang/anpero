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
            switch (op)
            {
                case "CreateOrder":
                    {
                        string captcha = context.Request["captcha"];
                        string name = context.Request["name"];
                        string email = context.Request["email"];
                        string phone = context.Request["phone"];
                        string address = context.Request["address"];
                        string ProductList = context.Request["ProductList"];
                        
                     
                        break;
                    }
                default:
                    break;
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