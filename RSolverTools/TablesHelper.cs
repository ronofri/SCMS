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

        public Dictionary<string, bool> Flags { get; set; }

        public TablesHelper(List<POC> source, string user)
        {
            if (user == "All")
            {
                ListAll(source);
            }

            else 
            {
                initializePOC();
                ListFilter(source);
                FlagFilter(user);
            } 
        }

        public void initializePOC()
        {
            Flags = new Dictionary<string, bool>();
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
            POCs = new Dictionary<string, List<POC>>();
            List<POC> incomplete = new List<POC>();
            POCs.Add("1", incomplete);
            List<POC> sent = new List<POC>();
            POCs.Add("2", sent);
            List<POC> cancelled = new List<POC>();
            POCs.Add("100", cancelled);
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

        public void ListAll(List<POC> source)
        {
            Flags = new Dictionary<string, bool>();
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

            POCs = new Dictionary<string, List<POC>>();
            List<POC> all = source;

            POCs.Add("0", all);
        }

        public void FlagFilter(string query)
        {
            switch (query)
            {
                case "GM":
                    Flags["Customer Address"] = false;
                    break;
            }
        }
    }
}