using StockSimulationMVC.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockSimulationMVC.Models;
using StockSimulationMVC.Simulation_SimulationStart;

namespace StockSimulationMVC.Strategy
{
    public class Strategy_MoveLine : IStrategy
    {
        public double Acc = 5;

        //double IStrategy.Acc { get { return Acc; } set => this.Acc = Acc; }

        public bool BuyCondition(ref SimulationVariable simulationVariable, ref DataList dataList, ref BasicFinancialReportListModel financialdata, int j)
        {
            if (dataList.CoditionSatified("MoveAverageValue-1", "MoveAverageValue-20", j))//&& dataList.CoditionSatified("MoveAverageValue-1", "MoveAverageValue-10",j))//&& dataList.CoditionSatified("BollingerBandsDown-5", "MoveAverageValue-1", j) && financialdata.ComparerFinancial("QCashFlowPerShare",3,4))
                return true;
            return false;
        }

        public bool SellCondition(ref SimulationVariable simulationVariable, ref DataList dataList, ref BasicFinancialReportListModel financialdata, int j)
        {
            if (simulationVariable.Accumulation > Acc || simulationVariable.Accumulation < -Acc)//simulationVariable.ConditionSatifiedMoveStopLoss("MoveStopLossPercentage"))// || dataList.CoditionSatified("MinValue-1", "MinValue-10", j))
                return true;
            return false;
        }
    }
}