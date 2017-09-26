using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Models
{
    public class MonthRevenueModel
    {
        public double ID { get; set; }
        public int Company { get; set; }
        public string CompanyName { get; set; }
        public DateTime Date { get; set; }
        public DateTime AnnouncementDate_SALE { get; set; }
        public double? Sale_Monthly { get; set; }
        public double? Sale_MonthlyLastYear { get; set; }
        public double? YoYPercentage_MonthlySale { get; set; }
        public double? MoMPercentage_MonthlySale { get; set; }
        public double? MonthsofMoMPercentage_MonthlySale { get; set; }
        public double? Sale_Accumulated { get; set; }
        public double? Sale_AccuLY { get; set; }
        public double? YoYPercentage_AccSales { get; set; }
        public double? HighestMonthlySales { get; set; }
        public double? HighestMonthlySalesYM { get; set; }
        public double? _MonthSalesHMonthSales_1_Percentage { get; set; }
        public double? LowestMonthlySales { get; set; }
        public double? LowestMonthlySalesYM { get; set; }
        public double? _MonthSalesLMonthSales_1_Percentage { get; set; }

    }
}
