using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Models
{
    public class TechnologicalDataModel
    {
        public int ID { get; set; }
        public int Company { get; set; }
        public string CompanyName { get; set; }
        public DateTime Date { get; set; }
        public Decimal OpenPrice { get; set; }
        public Decimal HighestPrice { get; set; }
        public Decimal LowestPrice { get; set; }
        public Decimal ClosePrice { get; set; }
        public double ReturnOnInvestment { get; set; }
        public double Yield { get; set; }
        public double Volume { get; set; }
    }
}