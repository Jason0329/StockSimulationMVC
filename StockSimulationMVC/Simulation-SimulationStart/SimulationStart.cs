using StockSimulationMVC.Core;
using StockSimulationMVC.Interface;
using StockSimulationMVC.Models;
using StockSimulationMVC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Simulation_SimulationStart
{
    public class SimulationStart
    {
        readonly int SimualationDays = 1000;
        List<int> Company;//還未初始化
        DataList DataList = new DataList();
        TransactionList Transaction_List;
        private IStrategy _strategy;

        public SimulationStart(IStrategy strategy )
        {
            Company = new List<int>();
            //TechDataList = new TechnologicalDataListModel();
            Transaction_List = new TransactionList();
            _strategy = strategy;
        }

        
        int Run()
        {
            //之後平行化處理看看
            for(int i=0; i< Company.Count; i++)
            {
                Initial_CompanyData(Company[i]);
                SimulationVariable _SimulationVariable = new SimulationVariable();
                Transaction transaction = new Transaction() ;

                for (int j =0; j < DataList.TechData.Count; j++)
                {
                    if (_SimulationVariable.HasBuy)
                    {
                        _SimulationVariable.CountDays(DataList.TechData[j].ReturnOnInvestment);// put TechData Return on Investment
                    }

                    #region 看買賣條件
                    //BuySell_Condition(ref SimulationVariable , j);
                    #endregion

                    if (_SimulationVariable.CanBuy && !_SimulationVariable.HasBuy)
                    {
                        transaction = new Transaction();
                        transaction.Buy(DataList.TechData[j].Company.ToString(), DataList.TechData[j].CompanyName,
                            DataList.TechData[j].ClosePrice, DataList.TechData[j].Date);

                        _SimulationVariable.HasBuy = true;

                    }
                    
                    if (_SimulationVariable.CanSell && !_SimulationVariable.HasSell)
                    {
                        transaction.Sell(DataList.TechData[j].Company.ToString(), DataList.TechData[j].CompanyName,
                            DataList.TechData[j].ClosePrice, DataList.TechData[j].Date);

                        Transaction_List._TransactionList.Add(transaction);

                        _SimulationVariable.HasBuy = false;
                        _SimulationVariable.Initial();
                    }

                }
            }
            return 0;
        }

        private void Initial_CompanyData(int v)
        {
            throw new NotImplementedException();
        }
    }
}