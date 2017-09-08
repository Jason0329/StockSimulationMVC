using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Models
{
    public class TechnologicalDataListModel
    {
        public List<TechnologicalDataModel> TechData = new List<TechnologicalDataModel>();
        public List<TaiwanStockIndexModel> TaiwanIndex = new List<TaiwanStockIndexModel>();

        public void Initial(string startDate, string EndDate, int company, bool IsOTC = false)
        {
        }


    }
}