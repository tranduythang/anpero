using AnperoFrontend.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnperoFrontend.Controllers
{
    public class WarrantyController : BaseController
    {
     
        // GET: Warranty
        [BuildCommonHtml]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [BuildCommonHtml]
        public JsonResult Register(WebService.Contact contact,string seria,string capcha)
        {

            string msg = "";
            //contact.District = "";
            //contact.Province="";
            contact.StoreId = StoreID.ToString();
            int rs = service.RegisterSeria(contact, seria, capcha, StoreID, TokenKey,out msg);
            return Json(new {
                code = rs,
                msg = msg 
            });
        }
        [HttpGet]
        [BuildCommonHtml]
        public ActionResult Check(string seria,string idCard)
        {
            ViewBag.identiryId = idCard;
            ViewBag.seria = seria;
            return View();
        }
        [BuildCommonHtml]
        [HttpGet]
        public ActionResult Info(string seria,string idCard, string capcha)
        {

            string msg = "";
            AnperoClient client = new AnperoClient();
            client.AgenId = StoreID;
            client.Token = TokenKey;                
            var rs = service.GetWarrantyCardInfo(seria,idCard,capcha, client);
            //WebService.ProductItem item
            ViewBag.ProductItem = service.GetProductDetail(StoreID, TokenKey, rs.ProductId);

            return View(rs);
        }
    }
    //public class Contact
    //{   
    //    public string Phone { get; set; }
    //    public string Name { get; set; }
    //    public string Mail { get; set; }
    //    public string Address { get; set; }
    //    public int UserId { get; set; }        
    //    public string StoreId { get; set; }
    //    public int LocationId { get; set; }
    //    public string IdCard { get; set; }
    //}
}