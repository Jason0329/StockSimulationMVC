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
        public bool BuyCondition(ref SimulationVariable simulationVariable, ref DataList dataList, int j)
        {
            if (dataList.CoditionSatified("MoveAverageValue-5", "MoveAverageValue-10",j))
                return true;

            return false;
        }

        public bool SellCondition(ref SimulationVariable simulationVariable, ref DataList dataList, int j)
        {

            if (dataList.CoditionSatified("MinValue-1", "MinValue-10", j))
                return true;

            return false;
        }
    }
}