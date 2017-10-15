using StockSimulationMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Service
{
    public class TransactionList
    {
        public List<Transaction> _TransactionList;
        public double Win=0;
        public double Loss = 0;
        public double WinRatio = 0;
        public double AverageHoldDays = 0;

        public TransactionList()
        {
            _TransactionList = new List<Transaction>();
        }

        public void TransactionStatisticResult()
        {
            for(int i=0; i< _TransactionList.Count;i++)
            {
                if (_TransactionList[i].Result.RateOfReturn > 0)
                    Win++;
                else
                    Loss++;

                AverageHoldDays += Math.Round(_TransactionList[i].Result.HoldDays,2);
            }

            WinRatio = Win / (Win + Loss);
            AverageHoldDays = Math.Round(AverageHoldDays / _TransactionList.Count * 100, 2);
        }

        public void AddTransactionList(List<Transaction> transactiondata)
        {
            foreach(var transaction in transactiondata)
            {
                _TransactionList.Add(transaction);
            }
        }
    }
}