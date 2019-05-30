using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
namespace Anpero
{
    
    public class SMSApi
    {
        public SMSApi()
        {
            APIKey =  ConfigurationManager.AppSettings["SmsAPIKey"];
            SecretKey =  ConfigurationManager.AppSettings["SmsSecretKey"];
            SmsType =  ConfigurationManager.AppSettings["SmsType"];
            BranchName = ConfigurationManager.AppSettings["brandName"];


        }
        string smsType;
        String aPIKey;
        string secretKey;
        string branchName;
        public string BranchName
        {
            get
            {
                return branchName;
            }

            set
            {
                branchName = value;
            }
        }
        public string APIKey
        {
            get
            {
                return aPIKey;
            }

            set
            {
                aPIKey = value;
            }
        }

        public string SecretKey
        {
            get
            {
                return secretKey;
            }

            set
            {
                secretKey = value;
            }
        }

        public string SmsType
        {
            get
            {
                return smsType;
            }

            set
            {
                smsType = value;
            }
        }

        public string SendJson(string phone, string message)
        {
            // Create URL, method 1:
            string URL = "http://rest.esms.vn/MainService.svc/json/SendMultipleMessage_V4_get?Phone=" + phone + "&Content=" + message + "&ApiKey=" + APIKey + "&SecretKey=" + SecretKey + "&IsUnicode=0&SmsType=" + SmsType;
            string result = SendGetRequest(URL);
            JObject ojb = JObject.Parse(result);
            int CodeResult = (int)ojb["CodeResult"];//100 is successfull
            return (string)ojb["SMSID"];//id of SMS            
        }

        private string SendGetRequest(string RequestUrl)
        {
            Uri address = new Uri(RequestUrl);
            HttpWebRequest request;
            HttpWebResponse response = null;
            StreamReader reader;
            if (address == null) { throw new ArgumentNullException("address"); }
            try
            {
                request = WebRequest.Create(address) as HttpWebRequest;
                request.UserAgent = ".NET Sample";
                request.KeepAlive = false;
                request.Timeout = 15 * 1000;
                response = request.GetResponse() as HttpWebResponse;
                if (request.HaveResponse == true && response != null)
                {
                    reader = new StreamReader(response.GetResponseStream());
                    string result = reader.ReadToEnd();
                    result = result.Replace("</string>", "");
                    return result;
                }
            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                {
                    using (HttpWebResponse errorResponse = (HttpWebResponse)wex.Response)
                    {
                        Console.WriteLine(
                            "The server returned '{0}' with the status code {1} ({2:d}).",
                            errorResponse.StatusDescription, errorResponse.StatusCode,
                            errorResponse.StatusCode);
                    }
                }
            }
            finally
            {
                if (response != null) { response.Close(); }
            }
            return null;
        }

        //Send SMS with Alpha Sender
        public string SendBrandnameJson(string phone, string message, string brandname="")
        {
            if (string.IsNullOrEmpty(brandname))
            {
                brandname = BranchName;
            }
            
            //http://rest.esms.vn/MainService.svc/json/SendMultipleMessage_V4_get?Phone={Phone}&Content={Content}&BrandnameCode={BrandnameCode}&ApiKey={ApiKey}&SecretKey={SecretKey}&SmsType={SmsType}&SendDate={SendDate}&SandBox={SandBox}
            //url vi du
            // sử dụng cách 1:
            string URL = "http://rest.esms.vn/MainService.svc/json/SendMultipleMessage_V4_get?Phone=" + phone + "&Content=" + message + "&Brandname=" + brandname + "&ApiKey=" + APIKey + "&SecretKey=" + SecretKey + "&IsUnicode=0&SmsType=2";

            string result = SendGetRequest(URL);
            JObject ojb = JObject.Parse(result);
            int CodeResult = (int)ojb["CodeResult"];//trả về 100 là thành công
            int CountRegenerate = (int)ojb["CountRegenerate"];
            return (string)ojb["SMSID"];//id của tin nhắn            
        }

        //Get Account Balance - Lay so du tai khoan
        public long GetBalance()
        {
            string data = "http://rest.esms.vn/MainService.svc/json/GetBalance/" + APIKey + "/" + SecretKey + "";
            string result = SendGetRequest(data);
            JObject ojb = JObject.Parse(result);
            int CodeResult = (int)ojb["CodeResponse"];//trả về 100 là thành công
            int UserID = (int)ojb["UserID"];//id tài khoản
            return (long)ojb["Balance"];//tiền trong tài khoản            
        }

    }
}
