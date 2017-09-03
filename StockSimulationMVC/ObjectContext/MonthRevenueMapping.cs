using StockSimulationMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.ObjectContext
{
    public class MonthRevenueMapping : EntityTypeConfiguration<MonthRevenueModel>
    {
        public MonthRevenueMapping()
        {
            ToTable("MonthRevenue");
            Property(m => m.ID).IsRequired();
            Property(m => m.Company);
            Property(m => m.Date);
            Property(m => m.MonthRevenue);
            Property(m => m.MonthRiseRatioInSameMonth);
            Property(m => m.MonthRevenueRiseRatio);
           
        }
    }
}