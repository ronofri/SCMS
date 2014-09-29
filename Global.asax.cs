using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebMatrix.WebData;
using SCMS.DAL;
using System.Threading;

namespace SCMS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        protected void Application_Start()
        {
            

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AuthConfig.RegisterAuth();
            //WebSecurity.Register();

            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        protected void Application_BeginRequest()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }

        public class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                //Database.SetInitializer<DataBaseContext>(null);

                try
                {
                    using (var context = new DataBaseContext())
                    {
                        //if (!context.Database.Exists())
                        //{
                        //    // Create the SimpleMembership database without Entity Framework migration schema
                        //    ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        //}
                        context.UserProfile.Find(1);
                    }
                    //CAUTION: Posible error
                    if (!WebSecurity.Initialized)
                        WebSecurity.InitializeDatabaseConnection("SCMS.DAL.DataBaseContext", "UserProfile", "UserId", "UserName", autoCreateTables: false);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }
}