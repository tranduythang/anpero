using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace AnperoFrontend.Controllers
{
    public class SeoController : BaseController
    {
            //routes.MapRoute(
            //  name: "robot",
            //   url: "robots.txt",
            //   defaults: new { controller = "Seo", action = "RobotsText" }
            //);
            //routes.MapRoute(
            //    name: "siteMapRouter",
            //    url: "sitemap.xml",
            //    defaults: new { controller = "Seo", action = "SitemapXml" }
            //);

        //<system.webServer>
        //  <handlers>
        //      <add name = "SitemapXml" path="sitemap.xml" verb="GET" type="System.Web.Handlers.TransferRequestHandler" preCondition="integratedMode,runtimeVersionv4.0" />
        //      <add name = "robots" path="robots.txt" verb="GET" type="System.Web.Handlers.TransferRequestHandler" preCondition="integratedMode,runtimeVersionv4.0" />
        //  </handlers>
        //</system.webServer>
        // GET: Seo
        [OutputCache(Duration = 86400)]
        public ContentResult RobotsText()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("user-agent: *");
            stringBuilder.AppendLine("Allow: /");
            stringBuilder.Append("sitemap: ");
            stringBuilder.AppendLine(this.Url.RouteUrl("siteMapRouter", null, this.Request.Url.Scheme).TrimEnd('/'));
            return this.Content(stringBuilder.ToString(), "text/plain", Encoding.UTF8);
        }
        [OutputCache(Duration = 86400)]
        public ActionResult SitemapXml()
        {
            
            //string baseUrl =Request.Url.Authority;

            string baseUrl = Request.Url.Scheme + "://" + Request.Url.Host;
            var sitemapNodes = GetSitemapNodes(baseUrl);
            string xml = GetSitemapDocument(sitemapNodes);
            return this.Content(xml, System.Net.Mime.MediaTypeNames.Text.Xml, Encoding.UTF8);
        }
     
        public IReadOnlyCollection<SitemapNode> GetSitemapNodes(string baseUrl)
        {
            AnperoFrontend.WebService.Webconfig commontData = new AnperoFrontend.WebService.Webconfig();
            List<SitemapNode> nodes = new List<SitemapNode>();
            if (HttpRuntime.Cache["commonInfo"] != null)
            {
                commontData= (AnperoFrontend.WebService.Webconfig)HttpRuntime.Cache["commonInfo"];
            }
            else
            {
                WebService.AnperoService service = new WebService.AnperoService();
                commontData = service.GetCommonConfig(CommonConfig.StoreID, CommonConfig.TokenKey);
                if (commontData != null)
                {
                    HttpRuntime.Cache.Insert("commonInfo", commontData, null, DateTime.Now.AddMinutes(shortCacheTime), TimeSpan.Zero);
                }
            }
            nodes.Add(new SitemapNode()
                {
                    Url = baseUrl,
                    Priority = 1
                });
            if(commontData.ProductCategoryList!=null && commontData.ProductCategoryList.Length > 0)
            {
                foreach (var item in commontData.ProductCategoryList)
                {
                    nodes.Add(new SitemapNode()
                    {
                        Url = baseUrl + "/" + Anpero.StringHelpper.GetParentCategoryLink(item.Name,item.Id),
                        Priority = 1
                    });
                    if (item.ChildCategory != null && item.ChildCategory.Length > 0)
                    {
                        foreach (var childItem in item.ChildCategory)
                        {
                            nodes.Add(new SitemapNode()
                            {
                                Url = baseUrl+"/"+ Anpero.StringHelpper.GetCategoryLink(childItem.Name, childItem.Id),
                                Priority = 1
                            });
                        }
                    }
                }
            }
            if (commontData.ProductGroupList != null && commontData.ProductGroupList.Length > 0)
            {
                foreach (var item in commontData.ProductGroupList)
                {
                    nodes.Add(new SitemapNode()
                    {
                        Url = baseUrl + "/" + Anpero.StringHelpper.GetProductGroupLink(item.Name, item.Id),
                        Priority = 1
                    });
                    
                }
            }
            if (commontData.ProductProperties != null && commontData.ProductProperties.Length > 0)
            {
                foreach (var item in commontData.ProductProperties)
                {
                    nodes.Add(new SitemapNode()
                    {
                        Url = baseUrl + "/search?property=" + item.Id,
                        Priority = 0.9
                    });

                }
            }
            return nodes;
        }
        public string GetSitemapDocument(IEnumerable<SitemapNode> sitemapNodes)
        {
            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement root = new XElement(xmlns + "urlset");

            foreach (SitemapNode sitemapNode in sitemapNodes)
            {
                XElement urlElement = new XElement(
                    xmlns + "url",
                    new XElement(xmlns + "loc", Uri.EscapeUriString(sitemapNode.Url)),
                    sitemapNode.LastModified == null ? null : new XElement(
                        xmlns + "lastmod",
                        sitemapNode.LastModified.Value.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz")),
                    sitemapNode.Frequency == null ? null : new XElement(
                        xmlns + "changefreq",
                        sitemapNode.Frequency.Value.ToString().ToLowerInvariant()),
                    sitemapNode.Priority == null ? null : new XElement(
                        xmlns + "priority",
                        sitemapNode.Priority.Value.ToString("F1", System.Globalization.CultureInfo.InvariantCulture)));
                root.Add(urlElement);
            }

            XDocument document = new XDocument(root);
            return document.ToString();
        }
       
    }
    public class SitemapNode
    {
        public SitemapFrequency? Frequency { get; set; }
        public DateTime? LastModified { get; set; }
        public double? Priority { get; set; }
        public string Url { get; set; }
    }
    public enum SitemapFrequency
    {
        Never,
        Yearly,
        Monthly,
        Weekly,
        Daily,
        Hourly,
        Always
    }


}