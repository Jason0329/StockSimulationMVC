using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Models
{
    public class BarginDataModel
    {
        public int ID { get; set; }
        public int Company { get; set; }
        public DateTime Date { get; set; }
        public double ForeignInvestorNetBuySell { get; set; }
        public double InvestmentTruthNetBuySell { get; set; }
        public double DealerNetBuySell { get; set; }
        public double ForeignInvestorAccumulateBuySell { get; set; }
        public double InvestmentTrustAccumulateBuySell { get; set; }
        public double DealerAccumulateBuySell { get; set; }
        public double AllAccumulateBuySell { get; set; }
        public double marginloan { get; set; }
        public double stockloan { get; set; }
        public double marginloanUseRatio { get; set; }
        public double stockloanUseRatio { get; set; }
        public double MarginStockRatio { get; set; }
    }
}