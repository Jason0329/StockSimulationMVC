using StockSimulationMVC.Core;
using StockSimulationMVC.Service;
using StockSimulationMVC.Simulation_SimulationStart;
using StockSimulationMVC.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockSimulationMVC.Controllers
{
    public class StockRunController : Controller
    {
        // GET: StockRun
        public ActionResult Index()
        {
            InitialData.Initial();
            Strategy_Jason1 Strategy = new Strategy_Jason1();
            SimulationStart Start = new SimulationStart(Strategy);
            TransactionList Data =  Start.Run();
            return View(Data);
        }
    }
}