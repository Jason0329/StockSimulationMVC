using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Models
{
    public class TechnologicalDataModel
    {
        public string ID { get; set; }
        public string Company { get; set; }
        public string CompanyName { get; set; }
        public DateTime Date { get; set; }
        public Decimal OpenPrice { get; set; }
        public Decimal HighestPrice { get; set; }
        public Decimal LowestPrice { get; set; }
        public Decimal ClosePrice { get; set; }
        public double? Volume { get; set; }
        public double? TurnoverValue { get; set; }//成交值
        public double? ReturnOnInvestment { get; set; }
        public double? Turnover { get; set; }//周轉率
        public double? NumberofSharesOutstanding { get; set; }
        public double? MarketValue { get; set; }
        public double? LastBuyPrice { get; set; }
        public double? LastSellPrice { get; set; }
        public double? ReturnOnInvestment_Ln { get; set; }
        public double? MarketValueRatio { get; set; }
        public double? TurnoverValueRatio { get; set; }
        public double? DealVolume { get; set; }
        public double? PriceEarningsRatio_TSE { get; set; }
        public double? PriceEarningsRatio_TEJ { get; set; }
        public double? PriceBookRatio_TSE { get; set; }
        public double? PriceBookRatio_TEJ { get; set; }
        public double? PriceSalesRatio_TEJ { get; set; }
        public double? ShareYieldRate { get; set; }
        public double? CashYieldRate { get; set; }
    }
}