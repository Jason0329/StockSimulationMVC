using StockSimulationMVC.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockSimulationMVC.Models;
using StockSimulationMVC.Simulation_SimulationStart;

namespace StockSimulationMVC.Strategy
{
    public class Strategy_Jason1 : IStrategy
    {
        public bool BuyCondition(ref SimulationVariable simulationVariable, ref DataList dataList, ref BasicFinancialReportListModel financialdata, int j)
        {
            if (dataList.CoditionSatified("MoveAverageValue-5", "MoveAverageValue-10",j) && financialdata.ComparerFinancial("QCashFlowPerShare",3,4))
                return true;

            return false;
        }

        public bool SellCondition(ref SimulationVariable simulationVariable, ref DataList dataList, ref BasicFinancialReportListModel financialdata, int j)
        {
            bool sim = simulationVariable.CoditionSatified(20, "HaveStockDay");
            if (sim&& dataList.CoditionSatified("MinValue-1", "MinValue-10", j))
                return true;

            return false;
        }
    }
}