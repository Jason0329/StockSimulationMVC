using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Models
{
    public class MonthRevenueModel
    {
        public int ID { get; set; }
        public int Company { get; set; }
        public DateTime Date { get; set; }
        public double MonthRevenue { get; set; }
        public double MonthRiseRatioInSameMonth { get; set; }
        public double MonthRevenueRiseRatio { get; set; }
    }
}
