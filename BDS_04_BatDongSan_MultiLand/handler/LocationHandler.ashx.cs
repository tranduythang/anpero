﻿using System;
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
                LocationList= sv.GetLocation(ParentLocationId);
            }
            catch (Exception)
            {
                LocationList = sv.GetLocation(0);
                throw;
            }
            foreach (WebService.Location item in LocationList)
            {
                LocationListHtml += "<option value='"+ item .Id+ "'>" + item.Name + "</option>";
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