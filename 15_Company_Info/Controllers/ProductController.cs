using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnperoFrontend.Controllers
{
    public class ProductController : BaseController
    {

        // GET: Product
        [BuildCommonHtml]
        public ActionResult Index(int id)
        {
            WebService.AnperoService sv = new WebService.AnperoService();
            WebService.ProductItem item = sv.GetProductDetail(StoreID, TokenKey, id);
            WebService.SearchResult relateProduct = sv.SearchProduct(StoreID, TokenKey, item.CatID.ToString(), "", "", 0, 999999, 1, 5, "", SearchOrder.TimeDesc, 0, string.Empty);
            ViewData["relateProduct"] = relateProduct;
            ViewBag.Title = item.PrName;
            SetupCommonProduct();
            return View(item);
        }
        [BuildCommonHtml]
        public ActionResult Category(int id)
        {
            string pageQuery = Request.QueryString["page"];
            int page = 1;
            if (!string.IsNullOrEmpty(pageQuery))
            {
                page = Convert.ToInt32(pageQuery);
            }
            WebService.AnperoService sv = new WebService.AnperoService();
            WebService.SearchResult rs   = sv.GetProductByCategory(StoreID, TokenKey, id,page, 14, 0);
            ViewData["productList"] = rs;
            ViewBag.page =Anpero.Paging.setUpPagedV2(page, 14, rs.ResultCount, 10, "?page=");
            if(rs!=null && rs.Item.Length > 0)
            {
                ViewBag.Title = rs.Item[0].CatName;
            }            
            SetupCommonProduct();
            return View();
        }
        [BuildCommonHtml]
        public ActionResult CategoryList()
        {  
            return View();
        }
        [BuildCommonHtml]
        public ActionResult ParentCategory(int id)
        {
            string pageQuery = Request.QueryString["page"];
            int page = 1;
            if (!string.IsNullOrEmpty(pageQuery))
            {
                page = Convert.ToInt32(pageQuery);
            }
            WebService.AnperoService sv = new WebService.AnperoService();
            WebService.SearchResult rs = sv.GetProductByParentCategory(StoreID, TokenKey, id, page, 14, 0);
            ViewData["productList"] = rs;
            ViewBag.page = Anpero.Paging.setUpPagedV2(page, 14, rs.ResultCount, 10, "?page=");
            ViewBag.isParent = "1";
            if (rs != null && rs.Item.Length > 0)
            {
                ViewBag.Title = rs.Item[0].ParentCatName;
            }
            SetupCommonProduct();
            return View("Category");
        }
        [BuildCommonHtml]
        public ActionResult Search(string category, string keyword)
        {
            string pageQuery = Request.QueryString["page"];
            WebService.SearchResult rs;
            int page = 1;
            if (!string.IsNullOrEmpty(pageQuery))
            {
                page = Convert.ToInt32(pageQuery);
            }
            WebService.AnperoService sv = new WebService.AnperoService();
            if (!string.IsNullOrEmpty(category) && category.Contains(@"c-"))
            {
                category = category.Replace(@"c-", string.Empty);
                rs = sv.SearchProduct(StoreID, TokenKey, "%", category, "", 0, 999999999, page, 14, keyword, SearchOrder.NameDesc, 0, string.Empty);

            }
            else
            {
                rs = sv.SearchProduct(StoreID, TokenKey, category, "", "", 0, 999999999, page, 14, keyword, SearchOrder.NameDesc, 0, string.Empty);
            }

            ViewData["productList"] = rs;
            if (rs != null)
            {
                ViewBag.page = Anpero.Paging.setUpPagedV2(page, 14, rs.ResultCount, 10, "?page=");
            }

            if (rs != null && rs.Item.Length > 0)
            {
                ViewBag.Title = rs.Item[0].CatName;
            }

            SetupCommonProduct();

            return View("Category");
        }
        [BuildCommonHtml]
        public ActionResult Checkout()
        {

            return View();
        }
    }
}