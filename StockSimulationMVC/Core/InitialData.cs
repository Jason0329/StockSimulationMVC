using Autofac;
using StockSimulationMVC.Interface;
using StockSimulationMVC.Models;
using StockSimulationMVC.ObjectContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Core
{
    public static class InitialData
    {
        public static List<BasicFinancialDataModel> InitialData_BasicFinancialData;
        public static List<MonthRevenueModel> InitialData_MonthRevenueData;
        public static List<TechnologicalDataModel> InitialData_TechnologicalData;
        public static List<CompanyModel> InitialData_CompanyData;

        public static void Initial()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<GenericRepository<BasicFinancialDataModel>>().As<IRepository<BasicFinancialDataModel>>()
                .InstancePerLifetimeScope();
            builder.RegisterType<GenericRepository<MonthRevenueModel>>().As<IRepository<MonthRevenueModel>>()
               .InstancePerLifetimeScope();
            builder.RegisterType<GenericRepository<TechnologicalDataModel>>().As<IRepository<TechnologicalDataModel>>()
               .InstancePerLifetimeScope();
            builder.RegisterType<GenericRepository<CompanyModel>>().As<IRepository<CompanyModel>>()
               .InstancePerLifetimeScope();

            var container = builder.Build();

            BasicFinancialDataModel tt = new BasicFinancialDataModel();

            InitialData_BasicFinancialData = container.Resolve<IRepository<BasicFinancialDataModel>>(new TypedParameter(typeof(DbContext), new DataObjectContext())).GetAllBasic().ToList();
            InitialData_MonthRevenueData = container.Resolve<IRepository<MonthRevenueModel>>(new TypedParameter(typeof(DbContext), new DataObjectContext())).GetAllMonthRevenue().ToList();
            InitialData_TechnologicalData = container.Resolve<IRepository<TechnologicalDataModel>>(new TypedParameter(typeof(DbContext), new DataObjectContext())).GetAllTech().ToList();
            InitialData_CompanyData = container.Resolve<IRepository<CompanyModel>>(new TypedParameter(typeof(DbContext), new DataObjectContext())).GetAll().ToList();


            //var ss = from data in InitialData_BasicFinancialData where data.Date.Year == 2017 && data.Date.Month > 3 select data;
            //List<BasicFinancialDataModel> dd = ss.ToList();

            //string record = "";
            //for (int i = 0; i < dd.Count; i++)
            //{
            //    GenericRepository<CompanyModel> coo = new GenericRepository<CompanyModel>(new DataObjectContext());
            //    CompanyModel co = new CompanyModel();





            //    co.ID = dd[i].Company;
            //    co.Company = dd[i].Company;
            //    co.CompanyName = dd[i].CompanyName;



            //    try
            //    {
            //        GenericRepository<CompanyModel> Add_Repository = new GenericRepository<CompanyModel>(new DataObjectContext());
            //        Add_Repository.Create(co);
            //        //container.Resolve<IRepository<CompanyModel>>(new TypedParameter(typeof(DbContext), new DataObjectContext())).Create(co);
            //    }
            //    catch (Exception ee)
            //    {
            //    }

            //}
        }
    }
}
