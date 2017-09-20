using StockSimulationMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.ObjectContext
{
    public class TechnologicalDataModelMapping : EntityTypeConfiguration<TechnologicalDataModel>
    {
        public TechnologicalDataModelMapping()
        {
            ToTable("TechnologicalData");

            Property(m => m.ID).IsRequired();
            Property(m => m.Company);
            Property(m => m.Date);
            Property(m => m.OpenPrice);
            Property(m => m.ClosePrice);
            Property(m => m.HighestPrice);
            Property(m => m.LowestPrice);

            Property(m => m.Volume);
            Property(m => m.TurnoverValue);
            Property(m => m.ReturnOnInvestment);
            Property(m => m.Turnover);
            Property(m => m.NumberofSharesOutstanding);
            Property(m => m.MarketValue);
            Property(m => m.LastBuyPrice);
            Property(m => m.LastSellPrice);
            Property(m => m.ReturnOnInvestment_Ln);
            Property(m => m.MarketValueRatio);
            Property(m => m.TurnoverValueRatio);
            Property(m => m.DealVolume);
            Property(m => m.PriceEarningsRatio_TSE);
            Property(m => m.PriceEarningsRatio_TEJ);
            Property(m => m.PriceBookRatio_TSE);
            Property(m => m.PriceBookRatio_TEJ);
            Property(m => m.PriceSalesRatio_TEJ);
            Property(m => m.ShareYieldRate);
            Property(m => m.CashYieldRate);

        }
    }
}