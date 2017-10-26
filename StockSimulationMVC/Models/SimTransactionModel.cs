using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Models
{
    public class SimTransactionModel
    {
        public double ReturnofInvestment { get; set; }
        public double EndCapital { get; set; }
        public double InvestTimes { get; set; }
        public double AverageHoldDays { get; set; }
        public double AverageReturnofInvestment { get; set; }
        public int Win { get; set; }
        public int Loss { get; set; }
        public double WinRatio { get; set; }

    }
}