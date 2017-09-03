using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Models
{
    public class BarginRewardDataModel
    {
        public int ID { get; set; }
        public int Company { get; set; }
        public DateTime Date { get; set; }
        public double ForeignInvestorNetBuySell { get; set; }
        public double InvestmentTrustNetBuySell { get; set; }
        public double DealerNetBuySell { get; set; }
        public double ForeignInvestorBuySellDay { get; set; }
        public double InvestmentTrustBuySellDay { get; set; }
        public double DealerBuySellDay { get; set; }
        public double AllBuySellDay { get; set; }
        public double ForeignInvestorReward { get; set; }
        public double InvestmentTrustReward { get; set; }
        public double DealerReward { get; set; }
        public double AllReward { get; set; }
    }
}