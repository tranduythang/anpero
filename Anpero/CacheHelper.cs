using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anpero
{
    public static class CacheHelper<T> where T : class
    {
        public static bool AddCache(string cacheKey, T objects, int cacheMinutes)
        {
            try
            {
                System.Web.HttpRuntime.Cache.Insert(cacheKey, objects, null, DateTime.Now.AddMinutes(cacheMinutes), TimeSpan.Zero);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static T GetCache(string cacheKey)
        {

            try
            {
                return (T)System.Web.HttpRuntime.Cache[cacheKey];
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static bool TryGetCache(string cacheKey,out T outPut)
        {

            try
            {
                if (System.Web.HttpRuntime.Cache[cacheKey] != null)
                {
                    outPut = (T)System.Web.HttpRuntime.Cache[cacheKey];
                    return true;
                }
                else
                {
                    outPut = null;
                    return false;
                }
                
            }
            catch (Exception)
            {
                outPut= null;
                return false;
            }
        }
        public static bool ClearCache(string cacheKey)
        {
            try
            {
                System.Web.HttpRuntime.Cache.Remove(cacheKey);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
        }
    }
}
