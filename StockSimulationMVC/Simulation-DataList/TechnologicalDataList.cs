using StockSimulationMVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Simulation_DataList
{
    public class TechnologicalDataList
    {
        public Hashtable TechnologicalLineGragh;
        public List<TechnologicalDataModel> TechData;

        public TechnologicalDataList()
        {
            TechnologicalLineGragh = new Hashtable();
            TechData = new List<TechnologicalDataModel>();
        }

        void Initial()
        {

        }
    }
}