using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace Anpero
{
    public static class Paging
    {
        public static String setupAjaxPage(int curentPage, int pageSite, int itemCount, int MaxPage, string funcName,string orderBy)
        {
            String pagedString = "";

            int totallPaed = itemCount / pageSite;
            if (itemCount % pageSite > 0)
            {
                totallPaed += 1;
            }
            // string path = HttpContext.Current.Request.Url.AbsolutePath;
            //TESTERS/Default6.aspx
            //nếu số tin lới hơn số tin trên trang mới hiển thị phân trang
            if (itemCount > pageSite)
            {
                pagedString = "<ul class='pagination'>";
                if (curentPage == 1)
                {
                    pagedString += @"<li class='active'><a href='#' tittle='Bạn đang ở trang đầu'>&laquo;</a></li>";
                }
                else
                {
                    pagedString += @"<li><a href='javascript:" + funcName + "(" + (curentPage - 1) + ",\""+orderBy+"\");'>&laquo;</a></li>";
                }

                if (curentPage <= totallPaed)
                {
                    //gioi han hien tai cua phan trang
                    int j = curentPage + MaxPage;
                    int k = MaxPage;
                    if (k <= totallPaed)
                    {
                        k = totallPaed;
                    }
                    if (j >= k)
                    {
                        j = totallPaed;
                    }
                    int currenttag;
                    if (curentPage == 1 || curentPage == 2 || curentPage == 3)
                    {
                        currenttag = 1;
                    }
                    else
                    {
                        currenttag = curentPage - 2;
                    }

                    for (int i = currenttag; i < j; i++)
                    {
                        if (i == curentPage)
                        {
                            pagedString += @"<li  class='active'><a href='javascript:void(0);' tittle='đang ở trang này'>" + (i) + "</a><li>";

                        }
                        else
                        {
                            pagedString += @"<li><a href='javascript:" + funcName + "(" + i + ",\""+orderBy+"\");'>" + i + "</a></li>";
                        }

                    }



                }

                if (curentPage == totallPaed)
                {
                    pagedString += @"<li  class='active'><a href='#' tittle='bạn đang ở trang cuôi'>&raquo;</a><li>";

                }
                else
                {
                    pagedString += @"<li><a href='javascript:" + funcName + "(" + totallPaed + ",\"" + orderBy + "\");'>" + totallPaed + @"</a></li>";                    
                    pagedString += @"<li><a href='javascript:" + funcName + "(" + (curentPage + 1) + ",\"" + orderBy + "\");'>&raquo;</a></li>";

                }
                pagedString += @"</ul>";
            }
            return pagedString;
        }
        public static String setUpPagedV2(int curentPage, int pageSite, int itemCount, int MaxPage, String query)
        {
            String pagedString = "";

            int totallPaed = itemCount / pageSite;
            if (itemCount % pageSite > 0)
            {
                totallPaed += 1;
            }
            //int totalPageSpit = 0;
            //if (totallPaed < pageSite)
            //{
            //    totalPageSpit = totallPaed / pageSite;
            //}

            //totallPaed = totallPaed - totalPageSpit;
            #region get link
            string CurentUrl = HttpContext.Current.Request.RawUrl.ToString();
            query = query.Replace(@"?", string.Empty).Replace(@"&", string.Empty);
            int legth = CurentUrl.LastIndexOf(@"?" + query);
            String pageaspx = CurentUrl;
            if (legth > 0)
            {
                pageaspx = CurentUrl.Substring(0, legth);
            }
            else
            {
                legth = CurentUrl.LastIndexOf(@"&" + query);
                if (legth > 0)
                {
                    pageaspx = CurentUrl.Substring(0, legth);
                }

            }

            #endregion

            query = pageaspx.Contains(@"?") ? "&" + query : "?" + query;
            // string path = HttpContext.Current.Request.Url.AbsolutePath;
            // // /TESTERS/Default6.aspx
            //nếu số tin lới hơn số tin trên trang mới hiển thị phân trang
            if (itemCount > pageSite)
            {
                pagedString = "<ul class='clearfix'>";
                if (curentPage == 1)
                {
                    pagedString += @"<li class='previous disabled pull-left'><a href='javascript:void(0);' title='Bạn đang ở trang đầu'>&laquo;</a></li>";
                }
                else
                {
                    pagedString += @"<li class='pull-left'><a href='" + pageaspx + query + (curentPage - 1) + "'>&laquo;</a></li>";
                }

                if (curentPage <= totallPaed)
                {
                    //gioi han hien tai cua phan trang
                    int j = curentPage + MaxPage;
                    int k = MaxPage;
                    if (k <= totallPaed)
                    {
                        k = totallPaed;
                    }
                    if (j >= k)
                    {
                        j = totallPaed;
                    }
                    int currenttag;
                    if (curentPage == 1 || curentPage == 2 || curentPage == 3)
                    {
                        currenttag = 1;
                    }
                    else
                    {
                        currenttag = curentPage - 2;
                    }

                    for (int i = currenttag; i < j; i++)
                    {
                        if (i == curentPage)
                        {
                            pagedString += @"<li class='active pull-left'><a href='javascript:void(0);' tittle='đang ở trang này'>" + (i) + "</a><li>";

                        }
                        else
                        {
                            pagedString += @"<li class='pull-left'><a href='" + pageaspx + query + i + "'>" + i + "</a></li>";
                        }

                    }
                }
                if (curentPage == totallPaed)
                {
                    pagedString += @"<li class='active pull-left'><a href='javascript:void(0);' tittle='bạn đang ở trang cuôi'>&raquo;</a><li>";
                }
                else
                {
                    pagedString += @"<li class='pull-left'><a href='" + pageaspx + query + totallPaed + @"'> . " + totallPaed + @"</a></li>";
                    pagedString += @"<li class='next pull-left'><a href='" + pageaspx + query + (curentPage + 1) + "'>&raquo;</a></li>";
                }
                pagedString += @"</ul>";
            }

            return pagedString;
        }
        /// <summary>
        /// trả về chuỗi html phân trang
        /// </summary>
        /// <param name="curentPage">Trang hiện tại</param>
        /// <param name="pageSite">Số tin trên trang</param>
        /// <param name="newsCount">Tổng số tin</param>
        /// <param name="MaxPage">Số phân trang tối đa, số trang tối đa trong menu phân trang</param>
        ///<param name="query">query có dạng  hoặc ?some=xxxx&page= hoặc ?page=</param>
        /// <returns>String</returns> 
        public static String setUpPagedV1(int curentPage, int pageSite, int itemCount, int MaxPage, String query)
        {
            String pagedString = "";
            if (itemCount >= 1000)
            {
                itemCount = 1000;
            }
            int totallPaed = itemCount / pageSite;
            string CurentUrl = HttpContext.Current.Request.RawUrl.ToString();

            int legth = CurentUrl.LastIndexOf(query);
            String pageaspx = CurentUrl;
            if (legth > 0)
            {
                pageaspx = CurentUrl.Substring(0, legth);
            }


            // string path = HttpContext.Current.Request.Url.AbsolutePath;
            // // /TESTERS/Default6.aspx
            //nếu số tin lới hơn số tin trên trang mới hiển thị phân trang
            if (itemCount > pageSite)
            {
                pagedString = "<ul class='pagination'>";
                if (curentPage == 1)
                {
                    pagedString += @"<li><a href='#' tittle='Bạn đang ở trang đầu'>&laquo;</a></li>";
                }
                else
                {
                    pagedString += @"<li><a href='" + pageaspx + query + (curentPage - 1) + "'>&laquo;</a></li>";
                }

                if (curentPage <= totallPaed)
                {
                    //gioi han hien tai cua phan trang
                    int j = curentPage + MaxPage;
                    int k = MaxPage;
                    if (k <= totallPaed)
                    {
                        k = totallPaed;
                    }
                    if (j >= k)
                    {
                        j = totallPaed;
                    }
                    int currenttag;
                    if (curentPage == 1 || curentPage == 2 || curentPage == 3)
                    {
                        currenttag = 1;
                    }
                    else
                    {
                        currenttag = curentPage - 2;
                    }
                    for (int i = currenttag; i < j; i++)
                    {
                        if (i == curentPage)
                        {
                            pagedString += @"<li class='active'><a href='javascript:void(0);' tittle='đang ở trang này'>" + (i) + "</a><li>";
                        }
                        else
                        {
                            pagedString += @"<li><a href='" + pageaspx + query + i + "'>" + i + "</a></li>";
                        }
                    }
                }

                if (curentPage == totallPaed)
                {
                    pagedString += @"<li class='active'><a href='#' tittle='bạn đang ở trang cuôi'>&raquo;</a><li>";
                }
                else
                {
                    pagedString += @"<li><a href='" + pageaspx + query + totallPaed + @"'> . " + totallPaed + @"</a></li>";
                    pagedString += @"<li><a href='" + pageaspx + query + (curentPage + 1) + "'>&raquo;</a></li>";
                }
                pagedString += @"</ul>";
            }
            return pagedString;
        }

    }
}
