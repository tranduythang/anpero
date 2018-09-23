using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anpero.Constant
{
    public static class WebContentType
    {
        public const int About = 1;
        public const int ShippingPolicy = 2;
        public const int WarrantyPolicy = 3;
        public const int ProductReturnPolicy = 4;
        public const int PrivacyPolicy = 5;
        public const int Payment = 6;

    }
    public static class WebContentTitle
    {
        public const string About = "Về chúng tôi";
        public const string ShippingPolicy = "Chính sách vận chuyển";
        public const string WarrantyPolicy = "Chính sách bảo hành";
        public const string ProductReturnPolicy = "Chính sách đổi trả";
        public const string PrivacyPolicy = "Chính sách bảo mật";
        public const string Payment = "Hướng dẫn thanh toán";
        public static string GetTitle(int contentId)
        {
            switch (contentId)
            {
                case WebContentType.About:
                    return WebContentTitle.About;

                case WebContentType.ShippingPolicy:
                    return WebContentTitle.ShippingPolicy;

                case WebContentType.WarrantyPolicy:
                    return WebContentTitle.WarrantyPolicy;

                case WebContentType.ProductReturnPolicy:
                    return WebContentTitle.ProductReturnPolicy;

                case WebContentType.PrivacyPolicy:
                    return WebContentTitle.PrivacyPolicy;

                case WebContentType.Payment:
                    return WebContentTitle.Payment;

                default:
                    return "";
            }

        }
    }
    public static class PageContent
    {
        public static string Slide = "slide";
        public static string Ads1 = "ads1";
        public static string Ads2 = "ads2";
        public static string Ads3 = "ads3";

    }
}
