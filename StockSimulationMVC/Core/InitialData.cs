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

        public static void Initial()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<GenericRepository<BasicFinancialDataModel>>().As<IRepository<BasicFinancialDataModel>>()
                .InstancePerLifetimeScope();
            builder.RegisterType<GenericRepository<MonthRevenueModel>>().As<IRepository<MonthRevenueModel>>()
               .InstancePerLifetimeScope();
            builder.RegisterType<GenericRepository<TechnologicalDataModel>>().As<IRepository<TechnologicalDataModel>>()
               .InstancePerLifetimeScope();

            var container = builder.Build();

            BasicFinancialDataModel tt = new BasicFinancialDataModel();

            InitialData_BasicFinancialData = container.Resolve<IRepository<BasicFinancialDataModel>>(new TypedParameter(typeof(DbContext), new DataObjectContext())).GetAll().ToList();
            InitialData_MonthRevenueData = container.Resolve<IRepository<MonthRevenueModel>>(new TypedParameter(typeof(DbContext), new DataObjectContext())).GetAll().ToList();
            InitialData_TechnologicalData = container.Resolve<IRepository<TechnologicalDataModel>>(new TypedParameter(typeof(DbContext), new DataObjectContext())).GetAllTech().ToList();

        }
    }
}