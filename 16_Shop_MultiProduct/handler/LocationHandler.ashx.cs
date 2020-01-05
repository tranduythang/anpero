using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnperoFrontend.handler
{
    /// <summary>
    /// Summary description for LocationHandler
    /// </summary>
    public class LocationHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            WebService.Location[] LocationList = null;
            string LocationListHtml = "";
            WebService.AnperoService sv = new WebService.AnperoService();
            try
            {
                int ParentLocationId = Convert.ToInt32(context.Request["ParentLocationId"]);
                LocationList = sv.GetLocation(ParentLocationId);
                if (ParentLocationId == 0)
                {
                    LocationListHtml += "<option value='0'>Thành phố/Tỉnh</option>";
                }else
                {
                    LocationListHtml += "<option value='0'>Quận/Huyện</option>";
                }
            }
            catch (Exception)
            {
                LocationList = sv.GetLocation(0);
                throw;
            }
            if (LocationList != null && LocationList.Length > 0)
            {
                foreach (WebService.Location item in LocationList)
                {
                    LocationListHtml += "<option value='" + item.Id + "'>" + item.Name + "</option>";
                }
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write(LocationListHtml);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}