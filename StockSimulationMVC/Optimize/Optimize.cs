using StockSimulationMVC.Core;
using StockSimulationMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Service
{
    public class Optimize
    {

        public TransactionList OptimizeCompany(TransactionList AllCompanyTransaction)
        {
            List<int> Company;
            Company = new List<int>();
            var CoData = from _company in InitialData.InitialData_CompanyData
                         select _company.Company;
            Company = (List<int>)CoData.ToList();

            TransactionList transactionlist = new TransactionList();
            TransactionList ReturnTransactionList = new TransactionList();

            for (int i=0; i<Company.Count; i++)
            {
                var Data = from data in AllCompanyTransaction._TransactionList
                           where data.BuyDetail.Nubmer==Company.ToString()
                           select data;
                
                transactionlist._TransactionList = (List<Transaction>)Data;
                transactionlist.TransactionStatisticResult();

                if(transactionlist._TransactionList.Count>3 && transactionlist.WinRatio>60)
                    ReturnTransactionList.AddTransactionList(transactionlist._TransactionList);
            }


            return ReturnTransactionList;
        }
    }
}