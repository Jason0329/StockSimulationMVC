﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Models
{
    public class MonthRevenueModel
    {
        //public double ID { get; set; }
        //public int Company { get; set; }
        //public string CompanyName { get; set; }
        //public DateTime Date { get; set; }
        //public DateTime AnnouncementDate_SALE { get; set; }
        //public double? Sale_Monthly { get; set; }
        //public double? Sale_MonthlyLastYear { get; set; }
        //public double? YoYPercentage_MonthlySale { get; set; }
        //public double? MoMPercentage_MonthlySale { get; set; }
        //public double? MonthsofMoMPercentage_MonthlySale { get; set; }
        //public double? Sale_Accumulated { get; set; }
        //public double? Sale_AccuLY { get; set; }
        //public double? YoYPercentage_AccSales { get; set; }
        //public double? HighestMonthlySales { get; set; }
        //public double? HighestMonthlySalesYM { get; set; }
        //public double? _MonthSalesHMonthSales_1_Percentage { get; set; }
        //public double? LowestMonthlySales { get; set; }
        //public double? LowestMonthlySalesYM { get; set; }
        //public double? _MonthSalesLMonthSales_1_Percentage { get; set; }
        //public double? HighestLowest_AllTime_ { get; set; }
        //public double? HighestLowest_Last12M_ { get; set; }
        //public double? HighestLowest_Month_ { get; set; }
        //public double? Sale_AccuLast12M { get; set; }
        //public double? Sale_AccuLY12M { get; set; }
        //public double? YoYPercentage_AccSalesL12M { get; set; }
        //public double? Sale_AccuLast3M { get; set; }
        //public double? Sale_AccuLY3M { get; set; }
        //public double? YoYPercentage_AccSalesL3M { get; set; }
        //public double? MoMPercentage_AccSalesL3M { get; set; }
        //public double? QoQPercentage_AccSalesL3M { get; set; }
        //public double? AnnouncementDate_Earning { get; set; }
        //public double? Pre_taxIncome_Month { get; set; }
        //public double? Pre_taxIncome_MonthLY { get; set; }
        //public double? YoYPercentage_MonthPre_taxIncome { get; set; }
        //public double? Pre_taxIncomeAccumulated { get; set; }
        //public double? Pre_taxIncomeAccu_LY { get; set; }
        //public double? YoYPercentage_AccPre_taxIncome { get; set; }
        //public double? NetIncome_Month { get; set; }
        //public double? NetInc_MonthLY { get; set; }
        //public double? YoYPercentage_MonthNetInc { get; set; }
        //public double? NetIncAccumulated { get; set; }
        //public double? NetIncAccu_LY { get; set; }
        //public double? YoYPercentage_AccNetInc { get; set; }
        //public double? ForcastedSale { get; set; }
        //public double? ForcastedSaleDate { get; set; }
        //public double? SaleToTargetPercentage { get; set; }
        //public double? ForecastedPre_taxIncome { get; set; }
        //public double? ForecastedNetInc { get; set; }
        //public double? ForcastEraningDate { get; set; }
        //public double? Pre_taxIncomeToTargetPercentage { get; set; }
        //public double? NetIncToTargetPercentage { get; set; }
        //public double? EarningSale_Month { get; set; }
        //public double? EarningSale_Accu { get; set; }
        //public double? NetIncSale_Month { get; set; }
        //public double? NetIncSale_Accu { get; set; }
        //public double? NetWorth { get; set; }
        //public double? ContingentLiability_ParentCompany { get; set; }
        //public double? ContingentLib_ParentCo_NetWorth { get; set; }
        //public double? LoanToOther_ParentCompany { get; set; }
        //public double? Loan_ParentCo_NetWorth { get; set; }
        //public double? OutstandingShares { get; set; }
        //public double? SalePerMonth { get; set; }
        //public double? SaleShare_Accu { get; set; }
        //public double? SaleShare_AccuL12M { get; set; }
        //public double? SaleShare_AccuL3M { get; set; }
        //public double? EPS_BefTax_Month { get; set; }
        //public double? EPS_BefTax__Accu { get; set; }
        //public double? EPS_BefT__PerM__W_ { get; set; }
        //public double? EPS_BefT__Accu__W_ { get; set; }
        //public double? EPS_AftT__PerMonth { get; set; }
        //public double? EPS_AftTax__Accu { get; set; }
        //public double? EPS_AftT__PerM__W_ { get; set; }
        //public double? EPS_AftT__Accu__W_ { get; set; }
        //public double? BPS { get; set; }
        //public double? OverdueRatePercentage { get; set; }
        //public double? ObservedLoan_Percentage_ { get; set; }
        //public double? TotalNPLPercentage { get; set; }
        //public double? OperatingProfit { get; set; }
        //public double? OperatingProfit_Month { get; set; }
        //public double? OperatingProfitMargin { get; set; }
        //public double? OperatingProfitMargin__Month { get; set; }
        //public double? ConsolidatedSale_Month { get; set; }
        //public double? ConsolidatedSale_MonthLY { get; set; }
        //public double? ConsolidatedYoYPercentage_MonthSale { get; set; }
        //public double? ConsolidatedMoMPercentage_MonthSale { get; set; }
        //public double? MonthsofConsolidatedMoMPercentage_MonthSale { get; set; }
        //public double? ConsolidatedSale_Accumulated { get; set; }
        //public double? ConsolidatedSale_AccuLY { get; set; }
        //public double? ConsolidatedYoYPercentage_AccSales { get; set; }
        //public double? ConsolidatedOperatingProfit { get; set; }
        //public double? ConsolidatedOperatingProfit_Month { get; set; }
        //public double? ConsolidatedOperatingProfitMargin { get; set; }
        //public double? ConsolidatedOperatingProfitMargin__Month { get; set; }
        //public double? ConsolidatedPre_taxIncome_Month { get; set; }
        //public double? ConsNetIncomeAttributabletoOwnersofParent_Month { get; set; }
        //public double? ConsolidatedPre_taxIncomeAccumulated { get; set; }
        //public double? ConsNetIncomeAttributabletoOwnersofParent_Accumulated { get; set; }
        //public double? ConsolidatedHighestLowest_AllTime_ { get; set; }
        //public double? ConsolidatedSales_YN_ { get; set; }
        //public double? Cons_FirstSale_Month { get; set; }
        //public double? Cons_FirstYoYPercentage_MonthSale { get; set; }
        //public double? Cons_FirstMoMPercentage_MonthSale { get; set; }
        //public double? Cons_FirstSale_Accumulated { get; set; }
        //public double? Cons_FirstYoYPercentage_AccSales { get; set; }
        //public double? ConsolidatedIncome_YN_ { get; set; }
        //public double? Cons_FirstPre_taxIncome_Month { get; set; }
        //public double? Cons_FirstNetIncome_Month { get; set; }
        //public double? Cons_FirstPre_taxIncomeAccumulated { get; set; }
        //public double? Cons_FirstNetIncAccumulated { get; set; }
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
