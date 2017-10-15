using StockSimulationMVC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Optimize
{
    public class OptimizeList
    {
        public List<TransactionList> OptimizeRecord;

        public OptimizeList()
        {
            OptimizeRecord = new List<TransactionList>();
        }
    }
}