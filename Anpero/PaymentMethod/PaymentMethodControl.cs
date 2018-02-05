using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anpero.PaymentMethod
{
   public static class PaymentMethodControl
    {
       public static List<PaymentMethod> GetPaymentMethodList()
        {
            List<PaymentMethod> li = new List<PaymentMethod>();
            li.Add(new PaymentMethod("Thanh toán tại cửa hàng","Miễn phí",0,0));
            li.Add(new PaymentMethod("Thanh toán khi nhận hàng", "Phí bưu điện", 1,10000));
            li.Add(new PaymentMethod("Thanh toán Online", "0.1 %", 2, 10000));
            //public static int PaymentNganLuong = 3;
            li.Add(new PaymentMethod("Chuyển khoản", "Miễn phí", 4, 0));
         
            return li;
        }
    }
}
