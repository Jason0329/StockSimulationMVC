using Autofac;
using StockSimulationMVC.Interface;
using StockSimulationMVC.Models;
using StockSimulationMVC.ObjectContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace StockSimulationMVC
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();


            //builder.RegisterType<GenericRepository<BasicFinancialDataModel>>().As<IRepository<BasicFinancialDataModel>>()
            //    .InstancePerLifetimeScope();

            //var container = builder.Build();

            //BasicFinancialDataModel tt = new BasicFinancialDataModel();
            //tt.ID = 1;
            //tt.LongTermLiabilities = 324;
            //tt.OthersLiabilities = 51423;
            //tt.ProfitAfterTax = 325423;
            //tt.Date = DateTime.Now;
            //List<BasicFinancialDataModel> aa;
            //container.Resolve<IRepository<BasicFinancialDataModel>>(new TypedParameter(typeof(DbContext), new DataObjectContext())).Create(tt);

            //var builder = new ContainerBuilder();


            //builder.RegisterType<GenericRepository<TechnologicalDataModel>>().As<IRepository<TechnologicalDataModel>>()
            //    .InstancePerLifetimeScope();

            //var container = builder.Build();

            //TechnologicalDataModel tt = new TechnologicalDataModel();
            //tt.ID = 2;
            //tt.LowestPrice = 24.3;
            //tt.OpenPrice = 20.3;
            //tt.HighestPrice = 123.3;
            //tt.ClosePrice = 325.23;
            //tt.Company = 2330;
            //tt.Date = DateTime.Now;
            //tt.Volume = 9000;
            ////container.ResolveOptional<TechnologicalDataModel>(new TypedParameter(typeof(TechnologicalDataModel), new TechnologicalDataModel()));
            //container.Resolve<IRepository<TechnologicalDataModel>>(new TypedParameter(typeof(DbContext), new DataObjectContext())).Create(tt);

        }
    }
}
