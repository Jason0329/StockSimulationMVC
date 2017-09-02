using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Models
{
    public class TaiwanStockIndexModel
    {
        public DateTime Date { get; set; }
        public double OpenPrice { get; set; }
        public double HighestPrice { get; set; }
        public double LowestPrice { get; set; }
        public double closePrice { get; set; }
        public double difOpenClosePrice { get; set; }
        public double difHighLowPrice { get; set; }
        public double difLastClosePrice { get; set; }

    }
}