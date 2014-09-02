using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCMS.DAL;

using System.Data;
using System.Data.Entity;
using SCMS.ViewModels.GM_Inbox;
using SCMS.Models;
using System.Web.Script.Serialization;

namespace SCMS.Controllers
{
    public class GM_SearchController : Controller
    {
        private DataBaseContext db = new DataBaseContext();
        //
        // GET: /GM_Search/

        public ActionResult SearchPOC()
        {
            QueryObject all = new QueryObject();
            ListPOCViewModel VM = new ListPOCViewModel(search(all), "All");

            return View(VM);
        }

        public PartialViewResult AjaxSearchPOC(string jsonQuery)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var query = serializer.Deserialize<QueryObject>(jsonQuery);

            //result = result.Where(p => p.Customer.Name.Contains(filter));

            ListPOCViewModel VM = new ListPOCViewModel(search(query), "All");

            return this.PartialView(VM);
        }

        public List<POC> search(QueryObject query) 
        {
            var POCs = db.POC.Include(x => x.Product).Include(x => x.Customer).Include(x => x.DestinationPort);

            var result = POCs;



            if (query.customer) 
            {
                result = result.Where(p => p.Customer.Name.Contains(query.query));
            }

            if (query.status) 
            {
 
            }

            return result.ToList<POC>();
        }

    }

    public class QueryObject
    {
        public QueryObject() 
        {
            query = "";
        }

        public string query { get; set; }

        public bool ballType { get; set; }

        public bool destinationPort { get; set; }

        public bool customer { get; set; }

        public bool status { get; set; }

        public DateTime? creationDate { get; set; }
    }
}
