using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Interface
{
    public interface IStrategy
    {
        bool BuyCondition();
        bool SellCondition();
    }
}