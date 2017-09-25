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
            WebService.SearchResult rs   = sv.SearchProduct(StoreID, TokenKey, id.ToString(), "", "", 0, 999999, page, 14, "", SearchOrder.TimeDesc, 0);
            ViewData["productList"] = rs;
            ViewBag.page =Anpero.Paging.setUpPagedV2(page, 14, rs.ResultCount, 10, "?page=");
            
            if (rs!=null && rs.Item.Length > 0)
            {
                ViewBag.Title = rs.Item[0].CatName;
            }
            
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
            
            ViewBag.isParent = "1";
            if (rs != null && rs.Item.Length > 0)
            {
                ViewBag.Title = rs.Item[0].ParentCatName;
            }
            SetupCommonProduct();
            SetUpSeo(1,id);
            return View("List");
        }
        [BuildCommonHtml]
        public ActionResult Search(string category, string keyword)
        {            
            string pageQuery = Request.QueryString["page"];
            int page = 1;
            if (!string.IsNullOrEmpty(pageQuery))
            {
                page = Convert.ToInt32(pageQuery);
            }
            WebService.AnperoService sv = new WebService.AnperoService();
            WebService.SearchResult rs = sv.SearchProduct(StoreID, TokenKey, category, "", "", 0, 999999999, page, 14, keyword, SearchOrder.NameDesc, 0);
            ViewData["productList"] = rs;
            ViewBag.page = Anpero.Paging.setUpPagedV2(page, 14, rs.ResultCount, 10, "?page=");            
            if (rs != null && rs.Item.Length > 0)
            {
                ViewBag.Title = rs.Item[0].CatName;
            }

            SetupCommonProduct();
            SetUpSeo(0,0);
            return View("List");
        }
        [BuildCommonHtml]
        public ActionResult Checkout()
        {

            return View();
        }
         private void SetUpSeo(int type,int categoryId)
        {
            AnperoFrontend.WebService.Webconfig commonInfo = (AnperoFrontend.WebService.Webconfig)HttpRuntime.Cache["commonInfo"];
            //Get Description and Keywords of Category production
            ViewBag.Description = string.Empty;
            ViewBag.Keywords = string.Empty;
            ViewBag.WebsiteUrl = string.Empty;
            ViewBag.ImageUrl = string.Empty;
            switch (type)
            {
                case 1:
                    foreach (var item in commonInfo.ProductCategoryList)
                    {
                        if(item.Id== categoryId)
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
                    ViewBag.Keywords ="Tìm kiếm "+ commonInfo.Name +"| " +commonInfo.Desc;
                    ViewBag.Description = "Tìm kiếm trên " + commonInfo.Name + "| " + commonInfo.Desc;
                    ViewBag.WebsiteUrl = Request.Url.AbsoluteUri;
                    ViewBag.ImageUrl = commonInfo.Logo;
                    break;
            }
        }
    }
}