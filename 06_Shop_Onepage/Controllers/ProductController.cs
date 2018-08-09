using AnperoFrontend.Models;
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
            WebService.SearchResult rs = sv.GetProductByCategory(StoreID, TokenKey, id, page, 14, 0);
            ViewData["productList"] = rs;
            ViewBag.page = Anpero.Paging.setUpPagedV2(page, 14, rs.ResultCount, 10, "?page=");
            //GetTopArticle();
            SetupCommonProduct();
            SetUpSeo(2, id);
            return View("List");
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
            
            if (rs != null && rs.Item.Length > 0)
            {
                ViewBag.Title = rs.Item[0].ParentCatName;
            }
            SetupCommonProduct();
        
            GetTopArticle();
            SetUpSeo(1,id);
            return View("List");
        }
        [BuildCommonHtml]
        public ActionResult Search(SearchModel model)
        {
            model.StoreId = StoreID;
            model.PageSize = 14;
            string pageQuery = Request.QueryString["page"];
            WebService.SearchResult rs;
            int page = 1;
            if (!string.IsNullOrEmpty(pageQuery))
            {
                page = Convert.ToInt32(pageQuery);
            }
            WebService.AnperoService sv = new WebService.AnperoService();
            if (!string.IsNullOrEmpty(model.Category) && model.Category.Contains(@"c-"))
            {
                model.Category = model.Category.Replace(@"c-", string.Empty);
                rs = sv.SearchProduct(StoreID, TokenKey, "%", model.Category.ToString(), model.GroupId, model.PriceFrom, model.PriceTo, model.Page, model.PageSize, model.KeyWord, model.SortBy, 0);
            }
            else
            {
                rs = sv.SearchProduct(StoreID, TokenKey, model.Category.ToString(), "", model.GroupId, model.PriceFrom, model.PriceTo, model.Page, model.PageSize, model.KeyWord, model.SortBy, 0);
            }
            ViewData["productList"] = rs;
            if (rs != null)
            {
                ViewBag.page = Anpero.Paging.setUpPagedV2(page, 14, rs.ResultCount, 10, "?page=");
            }
            ViewBag.Title = "Tìm kiếm sản phẩm";
            SetupCommonProduct();

            return View("List", model);
        }
        [BuildCommonHtml]
        public ActionResult SearchAjax(SearchModel model)
        {
            model.StoreId = StoreID;
            string pageQuery = Request.QueryString["page"];
            WebService.SearchResult rs;
            int page = 1;
            if (!string.IsNullOrEmpty(pageQuery))
            {
                page = Convert.ToInt32(pageQuery);
            }
            WebService.AnperoService sv = new WebService.AnperoService();
            if (!string.IsNullOrEmpty(model.Category) && model.Category.Contains(@"c-"))
            {
                string parentCat = model.Category.Replace(@"c-", string.Empty);
                rs = sv.SearchProduct(StoreID, TokenKey, "0", parentCat, model.GroupId, model.PriceFrom, model.PriceTo, model.Page, model.PageSize, model.KeyWord, model.SortBy, 0);

            }
            else
            {
                rs = sv.SearchProduct(StoreID, TokenKey, model.Category.ToString(), "0", model.GroupId, model.PriceFrom, model.PriceTo, model.Page, model.PageSize, model.KeyWord, model.SortBy, 0);
            }

            ViewData["productList"] = rs;
            if (rs != null)
            {
                ViewBag.page = Anpero.Paging.setUpPagedV2(model.Page, model.PageSize, rs.ResultCount, 10, "?page=");
            }
            return PartialView("SearchAjax");
        }
        [BuildCommonHtml]
        public ActionResult Checkout()
        {

            return View();
        }
        private void SetUpSeo(int type, int categoryId)
        {
            AnperoFrontend.WebService.Webconfig commonInfo = (AnperoFrontend.WebService.Webconfig)HttpRuntime.Cache["commonInfo"];
            if (commonInfo != null)
            {
                switch (type)
                {
                    case 1:
                        foreach (var item in commonInfo.ProductCategoryList)
                        {
                            if (item.Id == categoryId)
                            {
                             
                                ViewBag.Keywords = item.Name;
                                ViewBag.Title = item.Name;
                                ViewBag.Description = item.Description;
                                break;
                            }
                        }
                        break;
                    case 2:
                        foreach (var item in commonInfo.ProductCategoryList)
                        {
                            foreach (var chidItem in item.ChildCategory)
                            {
                                if (chidItem.Id == categoryId)
                                {
                                    ViewBag.isChildend = "1";
                                    ViewBag.Keywords = chidItem.Name;
                                    ViewBag.ParentName = item.Name;
                                    ViewBag.ParentId = item.Id;
                                    ViewBag.Title = chidItem.Name;
                                    ViewBag.Description = chidItem.Description;
                                    break;
                                }
                            }

                        }
                        break;
                    default:
                        ViewBag.Keywords = "Tìm kiếm " + commonInfo.Name + "| " + commonInfo.Desc;
                        ViewBag.Description = "Tìm kiếm trên " + commonInfo.Name + "| " + commonInfo.Desc;
                        ViewBag.Title = "Tìm kiếm :" + commonInfo.Name;
                        break;
                }
            }
          
            //Get Description and Keywords of Category production
            ViewBag.Description = string.Empty;
            ViewBag.Keywords = string.Empty;
        }

    }
}