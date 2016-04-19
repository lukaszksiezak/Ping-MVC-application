using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StateControl.Models;
using Newtonsoft.Json.Linq;
using System.Web.Hosting;

namespace StateControl.Controllers
{
    public class HomeController : Controller
    {
        private SiteFactory siteFactory = new SiteFactory();

        public ActionResult Index()
        {
            return View(siteFactory.SitesList);
        }

        [HttpPost]
        public JsonResult UpdateStatus(string site)
        {
            JObject jObject = JObject.Parse(site);
            JToken jUser = jObject["site"];

            var id = jObject["IdName"].ToString();
            var siteToRefresh = (from s in siteFactory.SitesList where s.IdName.Equals(id) select s).SingleOrDefault();
            siteToRefresh.UpdateSiteStatus();

            return Json(siteToRefresh);
        }
    }
}
