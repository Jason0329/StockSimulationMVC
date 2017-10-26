using StockSimulationMVC.Models;
using StockSimulationMVC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Simulation_Test
{
    public class SimulateTransaction
    {
        public double InitialCapital { get; set; }
        public double HoldCapital { get; set; }
        List<Transaction> AllTransaction { get; set; }
        List<Transaction> TransactionHold { get; set; }
        public List<SimTransactionModel> CapitalSimList { get; set; }
        public int BuyFreq { get; set; }

        public SimulateTransaction( ref List<Transaction> all_transaction, double initial_capital=1000000)
        {
            InitialCapital = initial_capital;
            HoldCapital = InitialCapital;
            AllTransaction = all_transaction;
            TransactionHold = new List<Transaction>();
            CapitalSimList = new List<SimTransactionModel>();
            BuyFreq = 0;
        }

        public void Run()
        {
            for (int i = 0; i < 20; i++)
            {
                CapitalSimList.Add(RunSimulate());
            }
        }

        SimTransactionModel RunSimulate()
        {
            DateTime dt = new DateTime(2000, 01, 01);
            Random random_buy = new Random(Guid.NewGuid().GetHashCode());
            TransactionHold = new List<Transaction>();
            AllTransaction.Sort();
            HoldCapital = InitialCapital;
            int InvestTime = 0;
            int Win = 0;
            int Loss = 0;

            for (; dt < DateTime.Now; dt = dt.AddDays(1))
            {

                foreach (var HoldStock in TransactionHold)
                {
                    if (dt.Date.CompareTo(HoldStock.SellDetail.Date) == 0)
                    {
                        HoldCapital += double.Parse(HoldStock.SellDetail.Price.ToString()) * 1000;
                        InvestTime++;

                        if (HoldStock.Result.RateOfReturn > 0.5m)
                            Win++;
                        else
                            Loss++;
                    }
                }

                foreach (var all_transaction in AllTransaction)
                {
                    int randombuynumber = random_buy.Next(1000000);

                    //if (dt.Date.CompareTo(all_transaction.BuyDetail.Date) > 0)
                    //    break;


                    if (dt.Date.CompareTo(all_transaction.BuyDetail.Date) == 0)// &&
                    {
                        if (randombuynumber % BuyFreq == 0)
                        {//&&
                            if (HoldCapital >= double.Parse(all_transaction.BuyDetail.Price.ToString()) * 1000)
                            {

                                HoldCapital -= double.Parse(all_transaction.BuyDetail.Price.ToString()) * 1000;
                                TransactionHold.Add(all_transaction);

                            }
                        }
                    }
                }
            }


            SimTransactionModel sim = new SimTransactionModel();
            sim.InvestTimes = InvestTime;
            sim.EndCapital = HoldCapital;
            sim.ReturnofInvestment = Math.Round((((HoldCapital - InitialCapital) / InitialCapital)) * 100, 2);
            sim.AverageReturnofInvestment = Math.Round((sim.ReturnofInvestment / sim.InvestTimes) , 4);
            sim.Win = Win;
            sim.Loss = Loss;
            sim.WinRatio = Math.Round(((double)Win / (double)(Win + Loss) * 100), 2);


            return sim;
        }


    }
}