using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anpero.PaymentApi.VTC
{
    public  class PaymentControl
    {
        public static ReturnData PostData(RequestParam param)
        {
        // fortest http://alpha1.vtcpay.vn/portalgateway/checkout.html
        //Account: 0963465816
        //Password: Aa@123456
          return HttpRequesHelper<ReturnData>.Post("http://alpha1.vtcpay.vn/portalgateway/checkout.html", param);
        }
        public static string GetUrl (RequestParam param)
        {
            // fortest http://alpha1.vtcpay.vn/portalgateway/checkout.html
            //Account: 0963465816
            //Password: Aa@123456
            return HttpRequesHelper<string>.GetUrlByParam("http://alpha1.vtcpay.vn/portalgateway/checkout.html", param);
        }
    }
}
