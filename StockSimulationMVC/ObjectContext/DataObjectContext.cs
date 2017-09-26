using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Objects;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using StockSimulationMVC.Models;

namespace StockSimulationMVC.ObjectContext
{
    public class DataObjectContext : DbContext
    {
        public DataObjectContext() : base("name=FinancialProductSimulation")
        {

            this.CreateDatabaseInstallationScript();
        }

        public string CreateDatabaseInstallationScript()
        {
            string command = ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();

            return command;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using Fluent API here
            modelBuilder.Entity<TechnologicalDataModel>().HasKey<string>(s => s.ID);
            //modelBuilder.Entity<MonthRevenueModel>().HasKey<int>(s => s.ID);
            modelBuilder.Entity<BasicFinancialDataModel>().HasKey<int>(s => s.ID);
            modelBuilder.Entity<BarginDataModel>().HasKey<int>(s => s.ID);

            //Database.SetInitializer<YourDbContext>(null);
            //modelBuilder.Configurations.Add(new TechnologicalDataModelMapping());


            base.OnModelCreating(modelBuilder);
        }
    }
}