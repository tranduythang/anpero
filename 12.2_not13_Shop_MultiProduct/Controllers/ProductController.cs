using AnperoFrontend.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnperoFrontend.Models;


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
            WebService.SearchResult relateProduct = sv.SearchProduct(StoreID, TokenKey, item.CatID.ToString(), "0", "0", 0, 999999, 1, 5, "", SearchOrder.TimeDesc, 0,string.Empty);
            ViewData["relateProduct"] = relateProduct;
            ViewData["prDetail"] = item;
            ViewBag.Title = item.PrName;
            
            return View();
        }
        
        public ActionResult SearchAjax(SearchModel model)
        {
            model.StoreId = StoreID;
            string pageQuery = Request.QueryString["page"];
            SearchResult rs = new SearchResult();
            int page = 1;
            if (!string.IsNullOrEmpty(pageQuery))
            {
                page = Convert.ToInt32(pageQuery);
            }
            WebService.AnperoService sv = new WebService.AnperoService();
            //if (!string.IsNullOrEmpty(model.ParentCategory) && model.ParentCategory!="0")
            //{
            //    rs = sv.GetProductByParentCategory(StoreID, TokenKey, Convert.ToInt32(model.ParentCategory), model.Page, model.PageSize, 0);
            //}
            //else if (!string.IsNullOrEmpty(model.Category) && model.Category != "0")
            //{
            //    rs = sv.GetProductByCategory(StoreID, TokenKey, Convert.ToInt32(model.Category), model.Page, model.PageSize, 0);
            //}
            //else
            //{
                rs = sv.SearchProduct(StoreID, TokenKey, model.Category.ToString(), model.ParentCategory, model.Brands, model.PriceFrom, model.PriceTo, model.Page, model.PageSize, model.KeyWord, model.SortBy, 0,string.Empty);
            //}
            ViewData["productList"] = rs;
            if (rs != null)
            {
                ViewBag.page = Anpero.Paging.setupAjaxPage(model.Page, model.PageSize, rs.ResultCount, 10, "Search.Products", model.SortBy);
            }
            return PartialView("SearchAjax");
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
            WebService.SearchResult rs   = sv.GetProductByCategory(StoreID, TokenKey, id, page, 14, 0);
            ViewData["productList"] = rs;
            ViewBag.page =Anpero.Paging.setUpPagedV2(page, 14, rs.ResultCount, 10, "?page=");
            ViewBag.pageName = "Category";
            if (rs!=null && rs.Item.Length > 0)
            {
                ViewBag.Title = rs.Item[0].CatName;
                ViewBag.isParent = string.IsNullOrEmpty(rs.Item[0].ParentCatName)?"0":"1";
            }
         

            SetUpSeo(2, id);
            return View("List");
        }
        [BuildCommonHtml]
        public ActionResult Group(int id)
        {
            Response.AppendHeader("Cache-Control", "max-age=1200,stale-while-revalidate=3600"); // HTTP 1.1.
            Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
            string pageQuery = Request.QueryString["page"];
            int page = 1;
            if (!string.IsNullOrEmpty(pageQuery))
            {
                page = Convert.ToInt32(pageQuery);
            }
            WebService.AnperoService sv = new WebService.AnperoService();
            WebService.SearchResult rs = sv.GetProductByGroup(StoreID, TokenKey, id, page, 14, 0);
            ViewData["productList"] = rs;
            ViewBag.page = Anpero.Paging.setUpPagedV2(page, 14, rs == null?0: rs.ResultCount, 10, "?page=");

            ViewBag.isParent = "1";
            ViewBag.pageName = "Group";
            if (rs != null && rs.Item.Length > 0)
            {
                ViewBag.Title = rs.Item[0].ParentCatName;
            }
            
            SetUpSeo(1, id);
            return View("List");
        }
        [BuildCommonHtml]
        public ActionResult ParentCategory(int id)
        {
            //Response.AppendHeader("Cache-Control", "max-age=1200,stale-while-revalidate=3600"); // HTTP 1.1.
            //Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
            string pageQuery = Request.QueryString["page"];
            int page = 1;
            if (!string.IsNullOrEmpty(pageQuery))
            {
                page = Convert.ToInt32(pageQuery);
            }
            WebService.AnperoService sv = new WebService.AnperoService();
            WebService.SearchResult rs = sv.GetProductByParentCategory(StoreID, TokenKey, id, page, 14, 0);
            ViewData["productList"] = rs;
            ViewBag.pageName = "ParentCategory";
            ViewBag.page = Anpero.Paging.setUpPagedV2(page, 14, rs.ResultCount, 10, "?page=");


            if (rs != null && rs.Item.Length > 0)
            {

                ViewBag.isParent = (rs.Item[0].ParentId == id|| rs.Item[0].ParentId==0) ? "1" : "0";
            }
            else
            {
                ViewBag.isParent = "1";
            }

            
            SetUpSeo(1,id);
            return View("List");
        }
        [BuildCommonHtml]
        public ActionResult Search(SearchModel model)
        {
            string title = "";
            string pageQuery = Request.QueryString["page"];
            string property = Request.QueryString["property"];
            int page = 1;
            if (!string.IsNullOrEmpty(pageQuery))
            {
                page = Convert.ToInt32(pageQuery);
            }
            WebService.AnperoService sv = new WebService.AnperoService();
            WebService.SearchResult rs = sv.SearchProduct(StoreID, TokenKey, model.Category, "", model.Brands, 0, 999999999, page, 14,model.KeyWord, model.SortBy, 0, property);
            ViewData["productList"] = rs;
            
            ViewBag.pageName = "Search";
            ViewBag.page = Anpero.Paging.setUpPagedV2(page, 14, rs.ResultCount, 10, "?page=");
            if (!string.IsNullOrEmpty(model.KeyWord))
            {
                title += model.KeyWord;
            }
            ViewBag.property = model.Property;
            ViewBag.category = model.Category;            
            ViewBag.brands = model.Brands;
            ViewBag.Title = title;
            SetUpSeo(0,0);
            return View("List");
        }
        [BuildCommonHtml]
        public ActionResult Checkout()
        {
            AnperoService ws = new AnperoService();
            PaymentConfig[] pa = ws.GetPaymentAPIConfig(StoreID, TokenKey);
            if (pa != null && pa.Length > 0)
            {
                for (int i = 0; i < pa.Length; i++)
                {
                    if (pa[i].Isdefault && pa[i].PaymentCode.ToUpper() == "NL")
                    {
                        ViewBag.PaymentType = "NL";
                    }
                }

            }
            return View();
        }
        private void SetUpSeo(int type, int categoryId)
        {

            AnperoFrontend.WebService.Webconfig commonInfo = null;
            if (HttpRuntime.Cache["commonInfo"] != null)
            {
                ViewData["commonInfo"] = HttpRuntime.Cache["commonInfo"];
                commonInfo = (AnperoFrontend.WebService.Webconfig)HttpRuntime.Cache["commonInfo"];
            }
            else
            {
                WebService.AnperoService service = new WebService.AnperoService();
                var rs = service.GetCommonConfig(CommonConfig.StoreID, CommonConfig.TokenKey);
                ViewData["commonInfo"] = rs;
                commonInfo = rs;
                if (rs != null)
                {
                    HttpRuntime.Cache.Insert("commonInfo", rs, null, DateTime.Now.AddMinutes(shortCacheTime), TimeSpan.Zero);
                }
            }

            //Get Description and Keywords of Category production
            ViewBag.Description = string.Empty;
            ViewBag.Keywords = string.Empty;
            ViewBag.WebsiteUrl = string.Empty;
            ViewBag.ImageUrl = string.Empty;
            if (commonInfo != null)
            {
                switch (type)
                {
                    case 1:
                        foreach (var item in commonInfo.ProductCategoryList)
                        {
                            if (item.Id == categoryId)
                            {
                                ViewBag.Keywords = item.Keywords;
                                ViewBag.Description = item.Description;
                                ViewBag.WebsiteUrl = Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host +
                                 Anpero.StringHelpper.GetParentCategoryLink(item.Name, item.Id);
                                ViewBag.ImageUrl = item.Images;
                                ViewBag.Title = item.Name;
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
                                    ViewBag.Keywords = item.Keywords;
                                    ViewBag.Description = item.Description;
                                    ViewBag.WebsiteUrl = Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host +
                                     Anpero.StringHelpper.GetCategoryLink(chidItem.Name, chidItem.Id);
                                    ViewBag.ImageUrl = item.Images;
                                    ViewBag.Title = item.Name;
                                    break;
                                }
                            }
                        }
                        break;
                    default:
                        ViewBag.Keywords = "Tìm kiếm " + commonInfo.Name + "| " + commonInfo.Desc;
                        ViewBag.Description = "Tìm kiếm trên " + commonInfo.Name + "| " + commonInfo.Desc;
                        ViewBag.WebsiteUrl = Request.Url.AbsoluteUri;
                        ViewBag.ImageUrl = commonInfo.Logo;
                        break;
                }

            }

        }
    }
}