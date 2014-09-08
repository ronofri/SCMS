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

            roles.ForEach(m => context.Role.AddOrUpdate(m));
            context.SaveChanges();
        }
    }
}