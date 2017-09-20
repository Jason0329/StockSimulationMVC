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
            if (dataList.TechData[j].ClosePrice > dataList.TechData[j].OpenPrice)
                return true;

            return false;
        }

        public bool SellCondition(ref SimulationVariable simulationVariable, ref DataList dataList, int j)
        {

            if (dataList.TechData[j].ClosePrice < dataList.TechData[j].OpenPrice)
                return true;

            return false;
        }
    }
}