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
        public JsonResult Register(WebService.Contact contact,string seria,string capcha)
        {

            string msg = "";
            contact.District = "";
            contact.Province="";
            int rs = service.RegisterSeria(contact, seria, capcha, StoreID, TokenKey,out msg);
            return Json(new {
                resultCode = rs,
                msg = msg 
            });
        }
        [BuildCommonHtml]
        public ActionResult Info(string seria,string idCard)
        {

            string msg = "";
            AnperoClient client = new AnperoClient();
            client.AgenId = StoreID;
            client.Token = TokenKey;                
            var rs = service.GetWarrantyCardInfo(seria,idCard, client);
            //WebService.ProductItem item
            ViewBag.ProductItem = service.GetProductDetail(StoreID, TokenKey, rs.ProductId);

            AnperoFrontend.WebService.Location[] LocationList = service.GetLocation(0);
            if (LocationList.Where(x => x.Id == rs.UserAddressId).Count() > 0)
            {
                ViewBag.ParentLocationName = LocationList.Where(x => x.Id == rs.UserAddressId).FirstOrDefault().Name;
            }
            else
            {
                foreach (var item in LocationList)
                {
                    
                }
            }
            

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