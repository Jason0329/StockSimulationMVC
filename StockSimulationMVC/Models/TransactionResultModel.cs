using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Models
{
    public class TransactionResultModel
    {
        public Decimal Revenue { get; set; }
        public Decimal RateOfReturn { get; set; }
        public double HoldDays { get; set; }
    }
}