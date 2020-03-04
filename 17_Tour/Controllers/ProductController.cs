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
        public ActionResult Index(int id,string type="")
        {
            
            WebService.ProductItem item = service.GetProductDetail(StoreID, TokenKey, id);
            WebService.SearchResult relateProduct = service.SearchProduct(StoreID, TokenKey, item.CatID.ToString(), "0", "0", 0, int.MaxValue, 1, 5, "", SearchOrder.TimeDesc, 0, string.Empty);
            ViewData["relateProduct"] = relateProduct;
            ViewData["prDetail"] = item;
            ViewBag.Title = item.PrName;
            if (type == "")
            {
                return View();
            }
            else
            {
                return View("thuvien");
            }
            
        }

        public ActionResult SearchAjax(WebService.SearchModel model)
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
            sv.SearchProducts(StoreID, TokenKey, model);
            //rs = sv.SearchProduct(StoreID, TokenKey, model);
            //}
            ViewData["productList"] = rs;
            if (rs != null)
            {
                ViewBag.page = Anpero.Paging.setupAjaxPage(model.Page, model.PageSize, rs.ResultCount, 10, "Search.Products", model.SortBy);
            }
            return PartialView("SearchAjax");
        }

        [BuildCommonHtml]
        public ActionResult Sales()
        {

            string pageQuery = Request.QueryString["page"];
            int page = 1;
            if (!string.IsNullOrEmpty(pageQuery))
            {
                page = Convert.ToInt32(pageQuery);
            }
            
            WebService.SearchResult rs = new WebService.SearchResult();
            WebService.ProductItem[] prList = service.GetSaleProduct(StoreID, TokenKey);
            rs.Item = prList;
            rs.ResultCount = prList== null?0: prList.Count();            
            ViewData["productList"] = rs;            
            ViewBag.pageName = "Sản phẩm khuyến mại";
            if (rs != null && rs.Item.Length > 0)
            {
                ViewBag.Title = "Sản phẩm khuyến mại";
                ViewBag.isParent = "0";
            }
            
            return View("List");
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
            ViewBag.page = Anpero.Paging.setUpPagedV2(page, 16, rs.ResultCount, 10, "?page=");
            ViewBag.pageName = "Category";
            if (rs != null && rs.Item.Length > 0)
            {
                ViewBag.Title = rs.Item[0].CatName;
                ViewBag.isParent = string.IsNullOrEmpty(rs.Item[0].ParentCatName) ? "0" : "1";
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
            ViewBag.page = Anpero.Paging.setUpPagedV2(page, 16, rs == null ? 0 : rs.ResultCount, 10, "?page=");

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
            ViewBag.category = id.ToString();
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
            ViewBag.page = Anpero.Paging.setUpPagedV2(page, 16, rs.ResultCount, 10, "?page=");



            if (rs != null && rs.Item.Length > 0)
            {

                ViewBag.isParent = (rs.Item[0].ParentId == id || rs.Item[0].ParentId == 0) ? "1" : "0";
            }
            else
            {
                ViewBag.isParent = "1";
            }


            SetUpSeo(1, id);
            return View("List");
        }
        [BuildCommonHtml]
        public ActionResult Search(Anpero.Model.SearchModel model)
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
            WebService.SearchResult rs = sv.SearchProduct(StoreID, TokenKey, model.Category, "", model.Brands, 0, int.MaxValue, page, 14, model.KeyWord, model.SortBy, 0, property);
            ViewData["productList"] = rs;

            ViewBag.pageName = "Search";
            ViewBag.page = Anpero.Paging.setUpPagedV2(page, 16, rs.ResultCount, 10, "?page=");

            if (!string.IsNullOrEmpty(model.KeyWord))
            {
                title += model.KeyWord;
            }
            ViewBag.property = model.Property;
            ViewBag.category = model.Category;
            
            

            ViewBag.brands = model.Brands;
            ViewBag.Title = title;
            SetUpSeo(0, 0);
            return View("List");
        }
        private string GetCategoryNameForSeo()
        {
            
            return "";
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
        public PartialViewResult GetByCategory(int id, string type = "feature")
        {
            AnperoService sv = new WebService.AnperoService();
            SearchResult relateProduct = new SearchResult();
            switch (type)
            {
                case "sale":
                    var rs = sv.GetSaleProduct(StoreID, TokenKey);
                    if (id > 0)
                    {
                        rs = rs.Where(x => x.CatID == id || x.ParentId == id).ToArray();
                    }
                    relateProduct.Item = rs.Take(6).ToArray();
                    break;
                default:
                    relateProduct = sv.SearchProduct(StoreID, TokenKey, id.ToString(), "0", "0", 0, int.MaxValue, 1, 6, "", SearchOrder.TimeDesc, 2,"");
                  
                    relateProduct.Item= relateProduct.Item.Skip(1).ToArray();
                    break;

            }

            if (type == "sale")
            {
                return PartialView("GetByCategory2", relateProduct);
            }
            return PartialView(relateProduct);
        }
    }
}