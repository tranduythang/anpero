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
        public ActionResult Index()
        {

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
            return View();
        }
    }
}