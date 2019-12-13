using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anpero.PaymentApi.VTC
{
    public class RequestParam
    {


        public double amount { get; set; }
        /// <summary>
        /// (không bắt buộc) Địa chỉ khách hàng (Số nhà, đường phố …)
        /// </summary>
        public string bill_to_address { get; set; }
        /// <summary>
        /// (không bắt buộc) Thành phố
        /// </summary>
        public string bill_to_address_city { get; set; }
        /// <summary>
        ///(không bắt buộc) Email khách hàng
        /// </summary>
        public string bill_to_email { get; set; }
        /// <summary>
        /// (không bắt buộc)	Tên (Ex: Hùng)
        /// </summary>
        public string bill_to_forename { get; set; }
        /// <summary>
        /// (không bắt buộc) Số điện thoại khách hàng
        /// </summary>
        public string bill_to_phone { get; set; }
        /// <summary>
        /// 	(không bắt buộc) Họ (Ex: Nguyễn Văn)
        /// </summary>
        public string bill_to_surname { get; set; }
        /// <summary>
        /// (bắt buộc)Loại tiền tệ muốn thanh toán: - VND  - USD
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// (không bắt buộc) Ngôn ngữ sẽ hiển thị trên site VTC. Nếu không truyền mặc định là tiếng Việt:  vi: Việt Nam en: English
        /// </summary>
        public string language { get; set; }
        /// <summary>
        /// Loại thanh toán. Truyền các giá trị sau: VTCPay: Thanh toán bằng số dư Pay DomesticBank: Chỉ thanh toán bằng ngân hàng nội địa InternationalCard: Chỉ thanh toán bằng thẻ quốc tế Trường hợp muốn thanh toán bằng ngân hàng cụ thể, truyền giá trị Mã ngân hàng được liệt kê trong phần phụ lục
        /// </summary>
        public string payment_type { get; set; }
        /// <summary>
        /// (bắt buộc) Tài khoản nhận tiền của đối tác khi giao dịch thành công
        /// </summary>
        public string receiver_account { get; set; }
        /// <summary>
        /// (không bắt buộc) Mã tham chiếu của đối tác tích hợp. Mã này phải duy nhất và dùng làm cơ sở hai bên đối soát, kiểm tra
        /// </summary>
        public string reference_number { get; set; }
        /// <summary>
        /// (không bắt buộc) sale
        /// </summary>
        public string transaction_type { get; set; }
        /// <summary>
        /// (không bắt buộc)Url của Merchant mà VTC sẽ redirect khách hàng sau khi kết thúc giao dịch. Nếu không truyền thì sẽ lấy url khi đăng ký tạo website
        /// </summary>
        public string url_return { get; set; }
        /// <summary>
        ///(bắt buộc) Chữ ký, SHA (256). Text để tạo chữ ký bao gồm các tham số truyền trên Url và SecretKey. Các trường sắp xếp theo trật tự alphabe ngăn nhau bởi ký tự “|”, Ví dụ: Trường hợp request có năm tham số amount, currency, receiver_account, reference_number, website_id thì: plaintext = string.Format("{0}|{1}|{2}|{3}|{4}|{5}", amount, currency, receiver_account, reference_number, website_id, Security_Key);
        /// </summary>

      
        public int website_id { get; set; }
        public string signature { get; set; }
        public  RequestParam(){
            
            currency = Currencys.VND;
        }
    }
    public static class Currencys
    {
        public const string VND = "vnd";
        public const string USD = "usd";
    }
}
