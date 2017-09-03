using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Models
{
    public class BasicFinancialDataModel
    {
        public int ID { get; set; }
        public int Company { get; set; }
        public DateTime Date { get; set; }
        public double CurrentLiabilities { get; set; }//流動負債
        public double LongTermLiabilities { get; set; }
        public double OthersLiabilities { get; set; }
        public double AllLiabilities { get; set; }
        public double CashFromOperationActivity { get; set; }
        public double CashFromInvestingActivity { get; set; }
        public double ProfitAfterTaxRatio { get; set; }
        public double ROE { get; set; }
        public double ProfitAfterTax { get; set; }
        public double EPS { get; set; }
        public double Asset { get; set; }
    }
}