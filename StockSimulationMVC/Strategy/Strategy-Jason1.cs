using StockSimulationMVC.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockSimulationMVC.Models;
using StockSimulationMVC.Simulation_SimulationStart;

namespace StockSimulationMVC.Strategy
{
    public class Strategy_Jason1 : IStrategy //2 3 3 0
    {
        int CountDropDays = 0;
        public double Acc = 5;
        public bool BuyCondition(ref SimulationVariable simulationVariable, ref DataList dataList, ref BasicFinancialReportListModel financialdata, int j)
        {
            if (!simulationVariable.HasBuy && dataList.TechData[j].ReturnOnInvestment < 0)
                CountDropDays++;
            else if(dataList.TechData[j].ReturnOnInvestment!=0 || simulationVariable.HasBuy)
                CountDropDays = 0;

            bool fin = financialdata.ComparerFinancial("QEarningPerShare", 1, 2);
            bool fin1 = financialdata.ComparerMonthlyRevenue("MoMPercentage_MonthlySale", 10,1,false);
            if (CountDropDays==2)//&& dataList.CoditionSatified("MoveAverageValue-1", "MoveAverageValue-10",j))//&& dataList.CoditionSatified("BollingerBandsDown-5", "MoveAverageValue-1", j) && financialdata.ComparerFinancial("QCashFlowPerShare",3,4))
                return true;

            return false;
        }

        public bool SellCondition(ref SimulationVariable simulationVariable, ref DataList dataList, ref BasicFinancialReportListModel financialdata, int j)
        {
            bool sim = simulationVariable.ConditionSatified(3, "HaveStockDayContainHoliday");
            simulationVariable.MoveStopLoss = 3;
            simulationVariable.MoveStopLossPercentage = 1;
            bool fin = financialdata.ComparerFinancial("QEarningPerShare", 0, 1 , false);
            if ( simulationVariable.Accumulation> Acc || simulationVariable.Accumulation < -Acc)//simulationVariable.ConditionSatifiedMoveStopLoss("MoveStopLossPercentage"))// || dataList.CoditionSatified("MinValue-1", "MinValue-10", j))
                return true;

            return false;
        }
    }
}