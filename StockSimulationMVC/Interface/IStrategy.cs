using StockSimulationMVC.Models;
using StockSimulationMVC.Simulation_SimulationStart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Interface
{
    public interface IStrategy
    {
        bool BuyCondition(ref SimulationVariable simulationVariable, ref DataList dataList, int j);
        bool SellCondition(ref SimulationVariable simulationVariable, ref DataList dataList, int j);

    }
}