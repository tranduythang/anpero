using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anpero
{
    class UrlHelper
    {
        public static string GetRootUrlReferrer()
        {
            try
            {
                Uri myReferrer = System.Web.HttpContext.Current.Request.UrlReferrer;
                //  Uri myReferrer= System.Web.HttpContext.Current.Request.Url;
                string actual = myReferrer.PathAndQuery.ToString();
                String[] spitActual = actual.Split('/');
                return spitActual[0] + @"//" + spitActual[2];
            }
            catch (Exception)
            {

                return string.Empty;
            }

        }
    }
}
