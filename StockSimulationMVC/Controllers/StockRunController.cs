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
           
            Strategy_Jason1 Strategy = new Strategy_Jason1();
            SimulationStart Start = new SimulationStart(Strategy);
            TransactionList Data =  Start.Run();
            Data._TransactionList.Sort();
            Data.TransactionStatisticResult();
            return View(Data);
        }

        public ActionResult Optimize()
        {
            List<TransactionList> OptimizeList = new List<TransactionList>();
            Strategy_Jason1 Strategy = new Strategy_Jason1();
            

            for(int i=1; i<=20; i++)
            {
                Strategy.Acc = i;
                SimulationStart Start = new SimulationStart(Strategy);
                TransactionList Data = Start.Run();
                //Data._TransactionList.Sort();
                Data.TransactionStatisticResult();
                OptimizeList.Add(Data);
            }

            Session["ResultStore"] = OptimizeList;
           
            return View("~/Views/Optimize/OptimizeList.cshtml", OptimizeList);

        }

        public ActionResult Detail(int id)
        {
            List<TransactionList> OptimizeList = (List<TransactionList>)Session["ResultStore"];

            return View("~/Views/StockRun/Detail.cshtml",OptimizeList[id]);
        }
    }
}