using StockSimulationMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.ObjectContext
{
    public class CompanyModelMapping : EntityTypeConfiguration<CompanyModel>
    {
        public CompanyModelMapping()
        {
            ToTable("Company");
            Property(m => m.ID);
            Property(m => m.Company);
            Property(m => m.CompanyName);
        }
    }
}