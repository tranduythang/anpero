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
        public JsonResult Register(Contact contact,string seria,string capcha)
        {
                        
            string msg = "";
            int rs = service.RegisterSeria(contact.Phone, contact.Name, contact.Mail, contact.Address, contact.LocationId, contact.IdCard, seria, capcha, StoreID, TokenKey);
            return Json(new {
                resultCode = rs,
                msg = msg 
            });
        }
    }
    public class Contact
    {   
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }        
        public string StoreId { get; set; }
        public int LocationId { get; set; }
        public string IdCard { get; set; }
    }
}