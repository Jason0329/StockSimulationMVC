using StockSimulationMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.ObjectContext
{
    public class FinancialDataModelMapping : EntityTypeConfiguration<BasicFinancialDataModel>
    {
        public FinancialDataModelMapping()
        {
            ToTable("FinancialData");
            Property(m => m.ID).IsRequired();
            Property(m => m.Company);
            Property(m => m.Date);
            Property(m => m.CurrentLiabilities);
            Property(m => m.LongTermLiabilities);
            Property(m => m.OthersLiabilities);
            Property(m => m.AllLiabilities);
            Property(m => m.CashFromOperationActivity);
            Property(m => m.CashFromInvestingActivity);
            Property(m => m.ProfitAfterTaxRatio);
            Property(m => m.ROE);
            Property(m => m.ProfitAfterTax);
            Property(m => m.EPS);
            Property(m => m.Asset);
        }
    }
}