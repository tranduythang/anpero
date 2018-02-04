using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anpero.PaymentMethod
{
   public  class PaymentMethod
    {
        string paymentName,paymentDesciption;
        int paymentFee,paymentCode;
        public PaymentMethod(string _paymentName, string _paymentDesciption, int _paymentCode, int _paymentFee)
        {
            PaymentName = _paymentName;
            PaymentDesciption = _paymentDesciption;
            PaymentCode = _paymentCode;
            PaymentFee=_paymentFee;
        }
        public string PaymentDesciption
        {
            get { return paymentDesciption; }
            set { paymentDesciption = value; }
        }
        public string PaymentName
        {
            get { return paymentName; }
            set { paymentName = value; }
        }
        public int PaymentCode
        {
            get { return paymentCode; }
            set { paymentCode = value; }
        }
        public int PaymentFee
        {
            get { return paymentFee; }
            set { paymentFee = value; }
        }
    }
}
