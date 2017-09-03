using StockSimulationMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.ObjectContext
{
    public class BarginDataMapping : EntityTypeConfiguration<BarginDataModel>  
    {
        public BarginDataMapping()
        {
            ToTable("BarginData");
            Property(m => m.ID).IsRequired();
            Property(m => m.Company);
            Property(m => m.Date);
            Property(m => m.ForeignInvestorNetBuySell);
            Property(m => m.InvestmentTruthNetBuySell);
            Property(m => m.DealerNetBuySell);
            Property(m => m.ForeignInvestorAccumulateBuySell);
            Property(m => m.InvestmentTrustAccumulateBuySell);
            Property(m => m.DealerAccumulateBuySell);
            Property(m => m.AllAccumulateBuySell);
            Property(m => m.marginloan);
            Property(m => m.stockloan);
            Property(m => m.marginloanUseRatio);
            Property(m => m.stockloanUseRatio);
            Property(m => m.MarginStockRatio);
        }
    }
}