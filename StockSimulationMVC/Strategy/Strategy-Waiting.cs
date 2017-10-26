using StockSimulationMVC.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockSimulationMVC.Models;
using StockSimulationMVC.Simulation_SimulationStart;

namespace StockSimulationMVC.Strategy
{
    public class Strategy_Waiting : IStrategy
    {
        public double Acc = 20;
        public bool BuyCondition(ref SimulationVariable simulationVariable, ref DataList dataList, ref BasicFinancialReportListModel financialdata, int j)
        {
            if (financialdata.RevenueInt - 2 < 0 || financialdata.BasicFinancialInt<=0 || financialdata.BasicFinancialInt - 12 <=0) return false;

            financialdata.InitialDate(dataList.TechData[j].Date);

            double? CFC_Yearly = 0;
            double? CFC_5Year = 0;
            double? QCashFlowFromOperatingAction = 0;
            double? QNetIncome = 0;
            int count = 0;

            for(int i=financialdata.BasicFinancialInt ; i> financialdata.BasicFinancialInt-12; i--)
            {
                QCashFlowFromOperatingAction += financialdata.FinancialDataList[i].QCashFlowFromOperatingAction;
                QNetIncome += financialdata.FinancialDataList[i].QNetIncome;

                if (count < 4)
                {
                    CFC_Yearly += financialdata.FinancialDataList[i].QCashFlowFromOperatingAction - financialdata.FinancialDataList[i].QCashFlowfromInvestmentAction;
                    count++;
                }
                    CFC_5Year += financialdata.FinancialDataList[i].QCashFlowFromOperatingAction - financialdata.FinancialDataList[i].QCashFlowfromInvestmentAction;
            }

            QCashFlowFromOperatingAction = QCashFlowFromOperatingAction / 3;
            QNetIncome = QNetIncome / 3;

            if (dataList.TechData[j].CashYieldRate >= 5 && financialdata.RevenueList[financialdata.RevenueInt].YoYPercentage_MonthlySale > 0 &&
                 financialdata.RevenueList[financialdata.RevenueInt - 1].YoYPercentage_MonthlySale > 0 &&
                 financialdata.RevenueList[financialdata.RevenueInt - 2].YoYPercentage_MonthlySale > 0 &&
                 financialdata.RevenueList[financialdata.RevenueInt - 1].YoYPercentage_MonthlySale + financialdata.RevenueList[financialdata.RevenueInt].YoYPercentage_MonthlySale >= 20 &&
                 financialdata.FinancialDataList[financialdata.BasicFinancialInt].QLong_TermLiabilities / financialdata.FinancialDataList[financialdata.BasicFinancialInt].QTotalLiabilities < 0.5 &&
                 financialdata.FinancialDataList[financialdata.BasicFinancialInt].QNetIncomePercentage>10&&
                 //financialdata.FinancialDataList[financialdata.BasicFinancialInt].QReturnonEquityPercentage_A >= 10 &&
                 //financialdata.FinancialDataList[financialdata.BasicFinancialInt].QCashFlowPerShare > 0 &&
                 //financialdata.FinancialDataList[financialdata.BasicFinancialInt].QNetIncomePercentage >= 10 &&
                 QCashFlowFromOperatingAction / QNetIncome >=0.5&&
                 financialdata.FinancialDataList[financialdata.BasicFinancialInt].QCashFlowFromOperatingAction / financialdata.FinancialDataList[financialdata.BasicFinancialInt].QNetIncome> 1&&

                  dataList.CoditionSatified("MoveAverageValue-1", "MoveAverageValue-60", j) &&
                  dataList.CoditionSatified("MoveAverageValue-60", "MoveAverageValue-1", j-1) &&

                 financialdata.ComparerFinancial("QReturnonEquityPercentage_A", 3, 4 ,Yearly:true) &&
                 financialdata.ComparerFinancial("QReturnonEquityPercentage_A", 10, 4 , true ,true) &&
                 financialdata.ComparerFinancial("QNetIncomePercentage", 10, 4)&&
                 financialdata.ComparerFinancial("QReturnonEquityPercentage_A", 3, 12, Yearly: true) &&
                 financialdata.ComparerFinancial("QNetIncomePercentage", 10, 12)

                 )//&& dataList.CoditionSatified("MoveAverageValue-1", "MoveAverageValue-10",j))//&& dataList.CoditionSatified("BollingerBandsDown-5", "MoveAverageValue-1", j) && financialdata.ComparerFinancial("QCashFlowPerShare",3,4))
                return true;
            return false;
        }
        public bool SellCondition(ref SimulationVariable simulationVariable, ref DataList dataList, ref BasicFinancialReportListModel financialdata, int j)
        {
            simulationVariable.MoveStopLossPercentage = Acc;
            if (simulationVariable.Accumulation > Acc || simulationVariable.Accumulation < -Acc
                // ||(financialdata.RevenueList[financialdata.RevenueInt ].YoYPercentage_MonthlySale<0&& financialdata.RevenueList[financialdata.RevenueInt - 1].YoYPercentage_MonthlySale<0)
                //|| financialdata.RevenueList[financialdata.RevenueInt ].YoYPercentage_MonthlySale<-10
                //|| dataList.CoditionSatified("MoveAverageValue-1", "MoveAverageValue-10", j,false)//&& dataList.CoditionSatified("BollingerBandsDown-5", "MoveAverageValue-1", j - 1,false)
                //|| simulationVariable.ConditionSatifiedMoveStopLoss("MoveStopLossPercentage")
                )//simulationVariable.ConditionSatifiedMoveStopLoss("MoveStopLossPercentage"))// || dataList.CoditionSatified("MinValue-1", "MinValue-10", j))
                return true;
            return false;
        }
    }
}