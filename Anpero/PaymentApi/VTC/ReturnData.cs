using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anpero.PaymentApi.VTC
{
    public class ReturnData
    {
        string data, signature;

        public string Data { get => data; set => data = value; }
        public string Signature { get => signature; set => signature = value; }
    }
}
