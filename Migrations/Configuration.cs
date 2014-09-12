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
                
                new Customer { Name = "ME Chile", Address = "Chile" },
                new Customer { Name = "ME Hong Kong", Address = "China" },
                new Customer { Name = "ME USA", Address = "USA" }
                
            };
            customers.ForEach(c => context.Customer.AddOrUpdate(cust => cust.Name, c));
            context.SaveChanges();

            var ports = new List<DestinationPort>
            {
                    new DestinationPort {Name = "Valparaiso", Address = "Chile"},
                    new DestinationPort {Name = "Antofagasta", Address = "Chile"}
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

            //var users = new List<UserProfile>
            //{
            //    new UserProfile { UserName = "jselman" },
            //    new UserProfile { UserName = "jgonzalez" },
            //    new UserProfile {  UserName="fmunoz"},
            //    new UserProfile {  UserName="zhenyuxu"}
            //};
            //users.ForEach(u => context.UserProfile.AddOrUpdate(up => up.UserName, u));
            //context.SaveChanges();

            var roles = new List<Role>
            {
                new Role { RoleName="GM"},
                new Role { RoleName= "SCM" },
                new Role { RoleName="LongTen"},
                new Role { RoleName="Admin"}
            };

            roles.ForEach(r => context.Role.AddOrUpdate(role => role.RoleName, r));
            context.SaveChanges();

            var bl = new BL();
            context.BL.Add(bl);

            var docs = new List<Document>
            {
                new Document { Name="Invoice"},
                new Document { Name= "Packing List"},
                new Document { Name="Origin Certificate"}
            };

            docs.ForEach(d => context.Document.AddOrUpdate(doc => doc.Name, d));
            context.SaveChanges();
        }
    }
}