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

            var allPOC = db.POC.Include(x => x.Product).Include(x => x.Customer).Include(x => x.DestinationPort);

            if (query.searchByPOC)
            {
                int id = 0;
                int.TryParse(query.query, out id);

                return allPOC.Where(poc => poc.POCID == id).ToList<POC>();
            }


            List<POC> POCs = allPOC.ToList<POC>();
            List<POC> result = new List<POC>();

            foreach (POC POC in POCs)
            {
                if (POC.Customer.Name.Contains(query.query)
                    || POC.Customer.Address.Contains(query.query)
                    || POC.DestinationPort.Name.Contains(query.query)
                    || POC.DestinationPort.Address.Contains(query.query)) 
                {
                    bool addPOC = true;

                    if(query.productType != 0)
                    {
                        if (POC.Product.ProductID != query.productType)
                        {
                            addPOC = false;
                        }
                    }

                    if (query.statusPOC != 0)
                    {
                        if (POC.Status != query.statusPOC)
                        {
                            addPOC = false;
                        }
                    }

                    if (query.month != 0 || query.year != 0)
                    {
                        //DateTime filterDate = new DateTime();
                        //filterDate.Month = 
                        //if (POC.Status != query.statusPOC)
                        //{
                        //    addPOC = false;
                        //}
                    }

                    if (addPOC) 
                    {
                        result.Add(POC);
                    }
                }

            }

            return result;
        }

    }

    public class QueryObject
    {
        public QueryObject() 
        {
            query = "";
        }

        public string query { get; set; }

        public bool searchByPOC { get; set; }

        public int productType { get; set; }

        public int statusPOC { get; set; }

        public int month { get; set; }

        public int year { get; set; }
    }
}
