using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anpero.PaymentApi.VTC
{
    public class RequestParam
    {
        double amount;
        int website_id;
        string bill_to_address, bill_to_address_city, bill_to_email, bill_to_forename, bill_to_phone, bill_to_surname, currency, language, payment_type, receiver_account, reference_number, transaction_type, url_return, signature;
        /// <summary>
        /// (không bắt buộc) Địa chỉ khách hàng (Số nhà, đường phố …)
        /// </summary>
        public string Bill_to_address { get => bill_to_address; set => bill_to_address = value; }
        /// <summary>
        /// (không bắt buộc) Thành phố
        /// </summary>
        public string Bill_to_address_city { get => bill_to_address_city; set => bill_to_address_city = value; }
        /// <summary>
        ///(không bắt buộc) Email khách hàng
        /// </summary>
        public string Bill_to_email { get => bill_to_email; set => bill_to_email = value; }
        /// <summary>
        /// (không bắt buộc)	Tên (Ex: Hùng)
        /// </summary>
        public string Bill_to_forename { get => bill_to_forename; set => bill_to_forename = value; }
        /// <summary>
        /// (không bắt buộc) Số điện thoại khách hàng
        /// </summary>
        public string Bill_to_phone { get => bill_to_phone; set => bill_to_phone = value; }
        /// <summary>
        /// 	(không bắt buộc) Họ (Ex: Nguyễn Văn)
        /// </summary>
        public string Bill_to_surname { get => bill_to_surname; set => bill_to_surname = value; }
        /// <summary>
        /// (bắt buộc)Loại tiền tệ muốn thanh toán: - VND  - USD
        /// </summary>
        public string Currency { get => currency; set => currency = value; }
        /// <summary>
        /// (không bắt buộc) Ngôn ngữ sẽ hiển thị trên site VTC. Nếu không truyền mặc định là tiếng Việt:  vi: Việt Nam en: English
        /// </summary>
        public string Language { get => language; set => language = value; }
        /// <summary>
        /// Loại thanh toán. Truyền các giá trị sau: VTCPay: Thanh toán bằng số dư Pay DomesticBank: Chỉ thanh toán bằng ngân hàng nội địa InternationalCard: Chỉ thanh toán bằng thẻ quốc tế Trường hợp muốn thanh toán bằng ngân hàng cụ thể, truyền giá trị Mã ngân hàng được liệt kê trong phần phụ lục
        /// </summary>
        public string Payment_type { get => payment_type; set => payment_type = value; }
        /// <summary>
        /// Tài khoản nhận tiền của đối tác khi giao dịch thành công
        /// </summary>
        public string Receiver_account { get => receiver_account; set => receiver_account = value; }
        /// <summary>
        /// (không bắt buộc) Mã tham chiếu của đối tác tích hợp. Mã này phải duy nhất và dùng làm cơ sở hai bên đối soát, kiểm tra
        /// </summary>
        public string Reference_number { get => reference_number; set => reference_number = value; }
        /// <summary>
        /// (không bắt buộc) sale
        /// </summary>
        public string Transaction_type { get => transaction_type; set => transaction_type = value; }
        /// <summary>
        /// (không bắt buộc)Url của Merchant mà VTC sẽ redirect khách hàng sau khi kết thúc giao dịch. Nếu không truyền thì sẽ lấy url khi đăng ký tạo website
        /// </summary>
        public string Url_return { get => url_return; set => url_return = value; }
        /// <summary>
        ///(bắt buộc) Chữ ký, SHA (256). Text để tạo chữ ký bao gồm các tham số truyền trên Url và SecretKey. Các trường sắp xếp theo trật tự alphabe ngăn nhau bởi ký tự “|”, Ví dụ: Trường hợp request có năm tham số amount, currency, receiver_account, reference_number, website_id thì: plaintext = string.Format("{0}|{1}|{2}|{3}|{4}|{5}", amount, currency, receiver_account, reference_number, website_id, Security_Key);
        /// </summary>
        public string Signature { get => signature; set => signature = value; }
        public double Amount { get => amount; set => amount = value; }
        public int Website_id { get => website_id; set => website_id = value; }
        public  RequestParam(){
            Language="VI";
            Currency = Currencys.VND;
        }
    }
    public static class Currencys
    {
        public const string VND = "VND";
        public const string USD = "USD";
    }
}
