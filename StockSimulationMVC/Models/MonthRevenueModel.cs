using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Models
{
    public class MonthRevenueModel
    {
        public int company { get; set; }
        public DateTime date { get; set; }
        public double _MonthRevenue { get; set; }
        public double MonthRiseRatioInSameMonth { get; set; }
        public double MonthRevenueRiseRatio { get; set; }
    }
}
