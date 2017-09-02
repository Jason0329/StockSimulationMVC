using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Models
{
    public class TechnologicalDataModel
    {
        public int company { get; set; }
        public DateTime date { get; set; }
        public double OpenPrice { get; set; }
        public double HighestPrice { get; set; }
        public double LowestPrice { get; set; }
        public double ClosePrice { get; set; }
        public double ReturnOnInvestment { get; set; }
        public double Yield { get; set; }
        public double volume { get; set; }
    }
}