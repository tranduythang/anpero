using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnperoFrontend.WebService;
namespace AnperoFrontend.Controllers
{
    public class ArticleController : BaseController
    {
        // GET: Article
        [BuildCommonHtml]
        public ActionResult Index(int id)
        {
            SetUpCommonArticle();
            AnperoService ws = new AnperoService();
            BlogItem rs= ws.GetArticleById(StoreID, TokenKey, id);
            ViewBag.Title = rs.Title;
            ViewBag.WebsiteUrl = Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host + Anpero.StringHelpper.GetArticleLink(rs.Title, rs.Id);
            ViewData["blogdeltail"] = rs;            
            GetTopArticle();
            return View();
        }

        [BuildCommonHtml]
        public ActionResult Category(int id)
        {
            int page = 1;
            if (Request.QueryString["page"] != null)
            {
                page = Convert.ToInt32(Request.QueryString["page"]);
            }
            AnperoService sv = new AnperoService();
            SearchArticleResults s = new SearchArticleResults();
            s=sv.SearchArticle(StoreID, TokenKey, id, page, 12, 0);
            ViewData["ArticleList"] = s;
            ViewBag.page = Anpero.Paging.setUpPagedV2(page, 14, s.ResultsCount, 11, "?page=");
            //seo
           
            if (id == 0)
            {
                ViewBag.CategoryName = "";
                ViewBag.Title = "Tin tức";
            }
            else
            {
                if (s.ItemList.Length > 0)
                {
                    ViewBag.Title = s.ItemList[0].CategoryName;
                    ViewBag.CategoryName = s.ItemList[0].CategoryName;
                }
               
            }
            ViewBag.Category = id;
            GetTopArticle();
            SetUpCommonArticle();
            return View();
        }
        private void SetUpCommonArticle()
        {
            List<WebService.BlogCategory> categoryList = null;
            WebService.AnperoService service = new WebService.AnperoService();           
            if (HttpRuntime.Cache["categoryMenuList"] != null)
            {
                categoryList=(List<WebService.BlogCategory>)HttpRuntime.Cache["categoryMenuList"];
                ViewData["categoryMenuList"] = categoryList;
            }
            else
            {
                categoryList = service.GetBlogCategory(StoreID, TokenKey).ToList();
                ViewData["categoryMenuList"] = categoryList;
                if (categoryList != null)
                {
                    HttpRuntime.Cache.Insert("categoryMenuList", categoryList, null, DateTime.Now.AddMinutes(shortCacheTime), TimeSpan.Zero);
                }
               
            }
            string categoryName="";
            if (categoryList != null)
            {
                for (int i = 0; i < categoryList.Count; i++)
                {
                    categoryName += ", " + categoryList[i].Name;
                }
            }
         
            ViewBag.Description = "Tin tức |"+ categoryName;
            ViewBag.Keywords = categoryName;
            ViewBag.WebsiteUrl = Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host + "/blog";
        }
        public void GetTopArticle()
        {
            WebService.SearchArticleResults rs = new WebService.SearchArticleResults();
            WebService.AnperoService service = new WebService.AnperoService();
            if (HttpRuntime.Cache["TopArticle"] != null)
            {
                rs = (WebService.SearchArticleResults)HttpRuntime.Cache["TopArticle"];
            }
            else
            {
                rs = service.SearchArticle(StoreID, TokenKey, 0, 1, 4, 2);
                if (rs != null)
                {
                    HttpRuntime.Cache.Insert("TopArticle", rs, null, DateTime.Now.AddMinutes(shortCacheTime), TimeSpan.Zero);
                }

            }
            ViewData["FeatureArticle"] = rs;
        }
    }
}