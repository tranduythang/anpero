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
            WebService.SearchResult relateProduct = sv.SearchProduct(StoreID, TokenKey, item.CatID.ToString(), "", "", 0, 999999, 1, 5, "", SearchOrder.TimeDesc, 0);
            ViewData["relateProduct"] = relateProduct;
            ViewData["prDetail"] = item;
            ViewBag.Title = item.PrName;
            SetupCommonProduct();
            return View();
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
        public ActionResult Search(string parentCat,string scat, int province,int district,int acr,int priceRank)
        {
            double pricefrom = 0;
            double friceTo = 5000000000;
            int acreageFrom = 0;
            int acreageTo = 999999;
            #region calc priceRank
            switch (priceRank)
            {
                case 1:
                     pricefrom = 3000000;
                    friceTo = 5000000;
                    break;
                case 2:
                    pricefrom = 5000000;
                    friceTo = 10000000;
                    break;
                case 3:
                    pricefrom = 10000000;
                    friceTo = 40000000;
                    break;
                case 4:
                    pricefrom = 40000000;
                    friceTo = 500000000;
                    break;
                case 5:
                    pricefrom = 500000000;
                    friceTo = 800000000;
                    break;
                case 6:
                    pricefrom = 1000000000;
                    friceTo = 2000000000;
                    break;
                case 7:
                    pricefrom = 1000000000;
                    friceTo = 2000000000;
                    break;
                case 8:
                    pricefrom = 3000000000;
                    friceTo = 5000000000;
                    break;
                case 9:
                    pricefrom = 5000000000;
                    friceTo = 7000000000;
                    break;
                case 10:
                    pricefrom = 7000000000;
                    friceTo = 10000000000;
                    break;
                case 11:
                    pricefrom = 10000000000;
                    friceTo = 20000000000;
                    break;
                case 12:
                    pricefrom = 20000000000;
                    friceTo = 30000000000;
                    break;
                default:
                    break;
            }
            #endregion calc priceRank
            #region calc acreage
            switch (acr)
            {
                case 1:                 
                     acreageTo = 30;
                    break;
                case 2:
                    acreageFrom = 30;
                    acreageTo = 50;
                    break;
                case 3:
                    acreageFrom = 50;
                    acreageTo = 80;
                    break;
                case 4:
                    acreageFrom = 80;
                    acreageTo = 100;
                    break;
                case 5:
                    acreageFrom = 100;
                    acreageTo = 150;
                    break;
                case 6:
                    acreageFrom = 150;
                    acreageTo = 200;
                    break;
                case 7:
                    acreageFrom = 200;
                    break;
                default:
                    break;
            }
            #endregion calc acreage
            string pageQuery = Request.QueryString["page"];
            int page = 1;
            if (!string.IsNullOrEmpty(pageQuery))
            {
                page = Convert.ToInt32(pageQuery);
            }
            WebService.AnperoService sv = new WebService.AnperoService();
            WebService.SearchResult rs = sv.SearchProductByLocation(StoreID, TokenKey, scat, parentCat, pricefrom, friceTo, page,12,province,district,"",acreageFrom, acreageTo);
            ViewData["productList"] = rs;
            ViewBag.page = Anpero.Paging.setUpPagedV2(page, 14, rs.ResultCount, 10, "?page=");
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