using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Interface
{
    interface IStrategy
    {
        bool BuyCondition();
        bool SellCondition();
    }
}