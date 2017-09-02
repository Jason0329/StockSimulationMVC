using StockSimulationMVC.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Models
{
    public class BuyModel : IFinancialInstrument
    {
        public string Name { get; set; }
        public string Nubmer { get; set; }
        public decimal Price { get; set; }
        public int Share { get; set; }
        public DateTime Date { get; set; }

     
    }
}