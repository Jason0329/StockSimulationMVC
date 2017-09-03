using StockSimulationMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.ObjectContext
{
    public class BarginRewardDataMapping : EntityTypeConfiguration<BarginRewardDataModel>
    {

        public BarginRewardDataMapping()
        {
            ToTable("BarginRewardData");
            Property(m => m.ID).IsRequired();
            Property(m => m.Company);
            Property(m => m.Date);
            Property(m => m.ForeignInvestorNetBuySell);
            Property(m => m.InvestmentTrustNetBuySell);
            Property(m => m.DealerNetBuySell);
            Property(m => m.ForeignInvestorBuySellDay);
            Property(m => m.InvestmentTrustBuySellDay);
            Property(m => m.DealerBuySellDay);
            Property(m => m.AllBuySellDay);
            Property(m => m.ForeignInvestorReward);
            Property(m => m.InvestmentTrustReward);
            Property(m => m.DealerReward);
            Property(m => m.AllReward);
        }
    }
}