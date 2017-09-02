using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Interface
{
    interface IFinancialInstrument
    {
        string Name { get; set; }
        string Nubmer { get; set; }
        Decimal Price { get; set; }
        DateTime Date { get; set; }
        int Share { get; set; }
    }
}