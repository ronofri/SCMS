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
            ListPOCViewModel VM = new ListPOCViewModel(searchAll(all), "All");

            List<Product> products = db.Product.ToList();

            List<string> listStatus = new List<string> {"Incomplete","Sent","Cancelled"};

            List<string> months = new List<string> { "January", "February", "March",
                                                     "April", "May", "June", "July", 
                                                     "August", "September", "October", "November", "December" };
            List<int> years = new List<int>();

            for (int i = 1969; i < 2031; i++) 
            {
                years.Add(i);
            }

            VM.Products = products;

            VM.listStatus = listStatus;

            VM.months = months;

            VM.years = years;

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

        public List<POC> searchAll(QueryObject query)
        {

            var allPOC = db.POC.Include(x => x.Product).Include(x => x.Customer).Include(x => x.DestinationPort);

            return allPOC.ToList<POC>();
        }  

        public List<POC> search(QueryObject query) 
        {

            var allPOC = db.POC.Include(x => x.Product).Include(x => x.Customer).Include(x => x.DestinationPort);
            query.query = query.query.ToLower();
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
                bool customerContains = false;
                bool portContains = false;

                if (POC.Customer == null && POC.DestinationPort == null) 
                {
                     continue;  
                }

                if(POC.Customer != null)
                {
                    if (POC.Customer.Name.ToLower().Contains(query.query) || POC.Customer.Address.ToLower().Contains(query.query))
                        customerContains = true;
                }

                if(POC.DestinationPort != null)
                {
                    if (POC.DestinationPort.Name.ToLower().Contains(query.query) || POC.DestinationPort.Address.ToLower().Contains(query.query))
                        portContains = true;
                }

                if (customerContains || portContains)
                {
                    bool addPOC = true;

                    if(query.productType != 0)
                    {
                        if (POC.Product != null)
                        {
                            if (POC.Product.ProductID != query.productType)
                            {
                                addPOC = false;
                            }
                        }

                        else 
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
                        int month = 1;
                        int day = 1;
                        int year = DateTime.Now.Year;

                        if(query.month != 0)
                        {
                            month = query.month;
                        }

                        if (query.year != 0)
                        {
                            year = query.year;
                        }

                        DateTime filterDate = new DateTime(year, month, day);
                        
                        if (POC.CreationDate < filterDate)
                        {
                            addPOC = false;
                        }
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
