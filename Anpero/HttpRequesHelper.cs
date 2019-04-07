using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
//thang.td
namespace Anpero
{
    public class HttpRequesHelper<T>
    {
        private static readonly HttpClient client = new HttpClient();
        
        public static T Post(string url,object paramObject)
        {
            
            string json = "";            
            var content = new FormUrlEncodedContent(ObjectToDictionary(paramObject));
            var response = client.PostAsync(url, content).Result;
            json = response.Content.ReadAsStringAsync().Result;          
            if (json != "")
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                return default(T);
            }
        }
        /// <summary>
        /// using System.net.WebRequest
        /// </summary>
        /// <param name="postData">param=abg&param2=value</param>
        /// <returns></returns>
        public static String HttpPost(string url,object paramObject,bool usingSSL)
        {

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes(GetParamString(paramObject));

            // Prepare web request...
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            if (usingSSL)
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                       | SecurityProtocolType.Tls11
                       | SecurityProtocolType.Tls12
                       | SecurityProtocolType.Ssl3;
            }


            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = data.Length;
            Stream newStream = myRequest.GetRequestStream();
            // Send the data.

            newStream.Write(data, 0, data.Length);
            newStream.Close();

            HttpWebResponse response = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string output = reader.ReadToEnd();
            response.Close();
            return output;
        }
        public static string PostAndReturnJson(string url, object paramObject)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new FormUrlEncodedContent(ObjectToDictionary(paramObject));
            var response = client.PostAsync(url, content).Result;
            return response.Content.ReadAsStringAsync().Result;
            
        }
        public static T Get(string url, object paramObject)
        {
            string json = "";            
            var content = ObjectToDictionary(paramObject);
            var condition = "?";
            foreach (KeyValuePair<string, string> entry in content)
            {
                url += condition + entry.Key + "=" + entry.Value;
                condition = "&";
            }
            var response = client.GetAsync(url).Result;
            
            json = response.Content.ReadAsStringAsync().Result;
            try
            {
                if (json != "")
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {

                return default(T);
            }
          
        }
        public static string GetParamString( object paramObject)
        {
            var content = ObjectToDictionary(paramObject);
            string url = string.Empty;
            var condition = "?";
            foreach (KeyValuePair<string, string> entry in content)
            {
                if (!string.IsNullOrEmpty(entry.Value))
                {
                    url += condition + entry.Key + "=" + entry.Value;
                    condition = "&";
                }
            }
            return url;
        }
        public static string GetUrlByParam(string url, object paramObject)
        {
            var content = ObjectToDictionary(paramObject);
            var condition = "?";
            foreach (KeyValuePair<string, string> entry in content)
            {
                if (!string.IsNullOrEmpty(entry.Value))
                {
                    url += condition + entry.Key + "=" + entry.Value;
                    condition = "&";
                }
            }
            return url;
        }
        public static string GetAndReturnJson(string url, object paramObject)
        {
            var content = ObjectToDictionary(paramObject);
            var condition = "?";
            foreach (KeyValuePair<string, string> entry in content)
            {
                url += condition + entry.Key + "=" + entry.Value;
                condition = "&";
            }
            var response = client.GetAsync(url).Result;
            return response.Content.ReadAsStringAsync().Result;
            
        }
        public static Dictionary<string,string> ObjectToDictionary(object obj)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            if (obj != null)
            {
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    string propName = prop.Name;
                    var val = obj.GetType().GetProperty(propName).GetValue(obj, null);
                    if (val != null)
                    {
                        ret.Add(propName, val.ToString());
                    }
                    else
                    {
                        ret.Add(propName, "");
                    }
                }
            }
            return ret;
        }
    }
}
