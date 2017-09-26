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
            Property(m => m.ID);
            Property(m => m.Company);
            Property(m => m.CompanyName);
            Property(m => m.Date);
            Property(m => m.AnnouncementDate_SALE);
            Property(m => m.Sale_Monthly);
            Property(m => m.Sale_MonthlyLastYear);
            Property(m => m.YoYPercentage_MonthlySale);
            Property(m => m.MoMPercentage_MonthlySale);
            Property(m => m.MonthsofMoMPercentage_MonthlySale);
            Property(m => m.Sale_Accumulated);
            Property(m => m.Sale_AccuLY);
            Property(m => m.YoYPercentage_AccSales);
            Property(m => m.HighestMonthlySales);
            Property(m => m.HighestMonthlySalesYM);
            Property(m => m._MonthSalesHMonthSales_1_Percentage);
            Property(m => m.LowestMonthlySales);
            Property(m => m.LowestMonthlySalesYM);
            Property(m => m._MonthSalesLMonthSales_1_Percentage);
        }
    }
}