using AnperoFrontend.Models;
using AnperoFrontend.WebService;
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
        [BunderHtml]
        [BuildCommonHtml]
        public ActionResult Index(int id)
        {
            WebService.AnperoService sv = new WebService.AnperoService();
            WebService.ProductItem item = sv.GetProductDetail(StoreID, TokenKey, id);
            WebService.SearchResult relateProduct = sv.SearchProduct(StoreID, TokenKey, "", item.ParentId.ToString(), "", 0, 999999, 1, 5, "", SearchOrder.TimeDesc, 0);
            ViewData["relateProduct"] = relateProduct;
            ViewData["prDetail"] = item;
            ViewBag.Title = item.PrName;
            SetupCommonProduct();
            return View();
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
            ViewBag.page = Anpero.Paging.setUpPagedV2(page, 14, rs == null ? 0 : rs.ResultCount, 10, "?page=");

            ViewBag.isParent = "1";
            if (rs != null && rs.Item.Length > 0)
            {
                ViewBag.Title = rs.Item[0].ParentCatName;
            }
            SetupCommonProduct();
            SetUpSeo(1, id);
            return View("Category");
        }
        [BuildCommonHtml]
        [BunderHtml]
        public ActionResult Category(int id)
        {
            string pageQuery = Request.QueryString["page"];
            int page = 1;
            if (!string.IsNullOrEmpty(pageQuery))
            {
                page = Convert.ToInt32(pageQuery);
            }
            WebService.AnperoService sv = new WebService.AnperoService();
            WebService.SearchResult rs   = sv.GetProductByCategory(StoreID, TokenKey, id,  page, 14,0);
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
        [BunderHtml]
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
            if(rs!=null)
            {
                ViewBag.page = Anpero.Paging.setUpPagedV2(page, 14, rs.ResultCount, 10, "?page=");
            }
            ViewBag.Title = "Tìm kiếm sản phẩm";
            SetupCommonProduct();

            return View("Category", model);
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
                rs = sv.SearchProduct(StoreID, TokenKey,"0", parentCat, model.GroupId, model.PriceFrom, model.PriceTo, model.Page, model.PageSize, model.KeyWord, model.SortBy, 0);

            }
            else
            {
                rs = sv.SearchProduct(StoreID, TokenKey, model.Category.ToString(), "0", model.GroupId, model.PriceFrom, model.PriceTo, model.Page, model.PageSize, model.KeyWord, model.SortBy, 0);
            }

            ViewData["productList"] = rs;
            if (rs != null)
            {
                ViewBag.page = Anpero.Paging.setUpPagedV2(model.Page,model.PageSize, rs.ResultCount, 10, "?page=");
            }
            return PartialView("SearchAjax");
        }
        [BuildCommonHtml]
        public ActionResult Checkout()
        {
            AnperoService ws = new AnperoService();            
            PaymentConfig[] pa = ws.GetPaymentAPIConfig(StoreID,TokenKey);            
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