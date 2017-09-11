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

        public TransactionList()
        {
            _TransactionList = new List<Transaction>();
        }
    }
}