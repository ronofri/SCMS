using SCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCMS.RSolverTools
{
    public class TablesHelper
    {
        public Dictionary<string, List<POC>> POCs {get;set;}

        public Dictionary<string, List<Shipment>> Shipments { get; set; }

        public Dictionary<string, List<BL>> BLs { get; set; }

        public Dictionary<string, bool> Flags { get; set; }

        public Dictionary<string, string> Title { get; set; }

        public string user { get; set; }

        public int Count { get; set; }

        public TablesHelper(List<POC> source, string user)
        {
            initialize(user);
            initializeFlags();
            Count = source.Count;
            if (user == "GM_Search")
            {
                ListAll(source);
            }
            else 
            {
                initializePOC();
                ListFilter(source);
                FlagFilter();
            } 
        }

        public TablesHelper(List<POC> source_poc, List<Shipment> source_shipment, List<BL> source_bl,string user)
        {
            initialize(user);
            initializeFlags();
            Count = source_poc.Count;
            if (user == "SCM_Search")
            {
                ListAll(source_poc);
            }
            else
            {
                initializePOC();
                ListFilter(source_poc);
                ListFilter(source_shipment);
                ListFilter(source_bl);
                FlagFilter();
            }
        }

        public void initialize(string user)
        {
            Title = new Dictionary<string, string>();
            Flags = new Dictionary<string, bool>();
            POCs = new Dictionary<string, List<POC>>();
            Shipments = new Dictionary<string, List<Shipment>>();
            BLs = new Dictionary<string, List<BL>>();
            this.user = user;
        }

        public void initializeFlags()
        {
            Flags.Add("PO Number", true);
            Flags.Add("PO Status", true);
            Flags.Add("Customer Name", true);
            Flags.Add("Customer Address", true);
            Flags.Add("Destination Port", true);
            Flags.Add("Incoterm", true);
            Flags.Add("Product Type", true);
            Flags.Add("Amount (Tons)", true);
            Flags.Add("Price Per Tons", true);
            Flags.Add("Creation Date", true);
        //    switch (this.user)
        //    {
        //        case "GM":
                    //Flags.Add("PO Number", true);
                    //Flags.Add("PO Status", true);
                    //Flags.Add("Customer Name", true);
                    //Flags.Add("Customer Address", true);
                    //Flags.Add("Destination Port", true);
                    //Flags.Add("Incoterm", true);
                    //Flags.Add("Product Type", true);
                    //Flags.Add("Amount (Tons)", true);
                    //Flags.Add("Price Per Tons", true);
                    //Flags.Add("Creation Date", true);
        //            break;
        //        case "SCM":
        //            Flags.Add("PO Number", true);
        //            Flags.Add("PO Status", true);
        //            Flags.Add("Customer Name", true);
        //            Flags.Add("Customer Address", true);
        //            Flags.Add("Destination Port", true);
        //            Flags.Add("Incoterm", true);
        //            Flags.Add("Product Type", true);
        //            Flags.Add("Amount (Tons)", true);
        //            Flags.Add("Price Per Tons", true);
        //            Flags.Add("Creation Date", true);
        //            break;
        //    }
        }

        public void initializePOC()
        {
            List<POC> incomplete = new List<POC>();
            POCs.Add("1", incomplete);
            Title.Add("1", "Recent Incomplete Customer PO's");
            List<POC> sent = new List<POC>();
            POCs.Add("2", sent);
            Title.Add("2", "Recent Sent Customer PO's");
            List<POC> cancelled = new List<POC>();
            POCs.Add("100", cancelled);
            Title.Add("100", "Recent Cancelled Customer PO's");
        }

        public void ListFilter(List<POC> source)
        {
            foreach (POC poc in source)
            {
                //Filter Action
                switch (poc.Status)
                {
                    case 1:
                        POCs["1"].Add(poc);
                        break;
                    case 2:
                        POCs["2"].Add(poc);
                        break;
                    case -1:
                        POCs["100"].Add(poc);
                        break;
                }
            }
        }

        public void ListFilter(List<Shipment> source)
        {
            foreach (Shipment pome in source)
            {
                //Filter Action
                switch (pome.Status)
                {
                    case 1:
                        Shipments["1"].Add(pome);
                        break;
                    case 2:
                        Shipments["2"].Add(pome);
                        break;
                    case -1:
                        Shipments["100"].Add(pome);
                        break;
                }
            }
        }

        public void ListFilter(List<BL> source)
        {
            foreach (BL bl in source)
            {
                //Filter Action
                switch (bl.Status)
                {
                    case 1:
                        BLs["1"].Add(bl);
                        break;
                    case 2:
                        BLs["2"].Add(bl);
                        break;
                    case -1:
                        BLs["100"].Add(bl);
                        break;
                }
            }
        }

        public void ListAll(List<POC> source)
        {
            List<POC> all = source;
            POCs.Add("0", all);
            Title.Add("0", "Result Customer PO's");
        }

        public void FlagFilter()
        {
            switch (this.user)
            {
                case "GM":
                    Flags["Customer Address"] = false;
                    break;
            }
        }
    }
}