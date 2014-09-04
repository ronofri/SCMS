namespace SCMS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SCMS.Models;
    using System.Collections.Generic;

    public sealed class Configuration : DbMigrationsConfiguration<SCMS.DAL.DataBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SCMS.DAL.DataBaseContext context)
        {
            var incoterms = new List<Incoterm>
            {

                new Incoterm { Name = "CFR" },
                new Incoterm { Name = "CIF"},
                new Incoterm { Name = "CIP"},
                new Incoterm { Name = "CPT"},
                new Incoterm { Name = "DAF"},
                new Incoterm { Name = "DDP"},
                new Incoterm { Name = "DDU"},
                new Incoterm { Name = "DEQ"},
                new Incoterm { Name = "DES"},
                new Incoterm { Name = "EXW"},
                new Incoterm { Name = "FAS"},
                new Incoterm { Name = "FCA"},
                new Incoterm { Name = "FOB"}
            };
            incoterms.ForEach(i => context.Incoterm.AddOrUpdate(inco => inco.Name, i));
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            var customers = new List<Customer>
            {
                
                new Customer { Name = "Rsolver", Address = "Vitacura 4454" },
                new Customer { Name = "Chuquicamata", Address = "Calama" },
                new Customer { Name = "Pablo Escobar", Address = "Colombia" },
                new Customer { Name = "Spence", Address = "Antofagasta" },
                //new Customer { Name = "Cerro Colorado", Address = "Tarapacá" },
                new Customer { Name = "Minera Escondida", Address = "Antofagasta" },
                new Customer { Name = "El Teniente", Address = "Rancagua" },
                new Customer { Name = "Andina", Address = "Los Andes" }
                
            };
            customers.ForEach(c => context.Customer.AddOrUpdate(cust => cust.Name, c));
            context.SaveChanges();

            var ports = new List<DestinationPort>
            {
                    new DestinationPort {Name = "Valparaiso", Address = "Chile"}
            };
            ports.ForEach(p => context.DestinationPort.AddOrUpdate(port => port.Name, p));
            context.SaveChanges();

            var products = new List<Product>
            {

                new Product { Name = "3.5\"" },
                new Product { Name = "5.5\"" },
                new Product { Name = "7.5\"" }


            };
            products.ForEach(b => context.Product.AddOrUpdate(product => product.Name, b));
            context.SaveChanges();

            //var shipments = new List<Shipment>
            //{
            //    new Shipment { ShipmentNumber = 1, Amount = 156, EstimatedTimeDeparture = new DateTime(2014, 8, 29), EstimatedTimeArrival = new DateTime(2014, 9, 15) },
            //    new Shipment { ShipmentNumber = 2, Amount = 312, EstimatedTimeDeparture = new DateTime(2014, 9, 20), EstimatedTimeArrival = new DateTime(2014, 10, 18) },
            //    new Shipment { ShipmentNumber = 3, Amount = 390, EstimatedTimeDeparture = new DateTime(2014, 10, 10), EstimatedTimeArrival = new DateTime(2014, 10, 30) },
            //    new Shipment { ShipmentNumber = 4, Amount = 208, EstimatedTimeDeparture = new DateTime(2014, 11, 1), EstimatedTimeArrival = new DateTime(2014, 11, 25) },
            //    new Shipment { ShipmentNumber = 5, Amount = 156, EstimatedTimeDeparture = new DateTime(2014, 11, 3), EstimatedTimeArrival = new DateTime(2014, 11, 30) },
            //    new Shipment { ShipmentNumber = 6, Amount = 312, EstimatedTimeDeparture = new DateTime(2014, 11, 20), EstimatedTimeArrival = new DateTime(2014, 12, 5) },
            //    new Shipment { ShipmentNumber = 7, Amount = 156, EstimatedTimeDeparture = new DateTime(2014, 12, 1), EstimatedTimeArrival = new DateTime(2014, 12, 22) },
            //    new Shipment { ShipmentNumber = 8, Amount = 208, EstimatedTimeDeparture = new DateTime(2014, 12, 15), EstimatedTimeArrival = new DateTime(2015, 1, 10) },
            //    new Shipment { ShipmentNumber = 9, Amount = 260, EstimatedTimeDeparture = new DateTime(2015, 1, 10), EstimatedTimeArrival = new DateTime(2015, 1, 20) }
            //};
            //shipments.ForEach(s => context.Shipment.AddOrUpdate(shipment => shipment.ShipmentNumber, s));
            //context.SaveChanges();
        }
    }
}