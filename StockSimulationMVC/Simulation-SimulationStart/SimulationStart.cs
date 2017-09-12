﻿using StockSimulationMVC.Core;
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
        TechnologicalDataListModel TechDataList = new TechnologicalDataListModel();
        TransactionList Transaction_List;
        public SimulationStart()
        {
            Company = new List<int>();
            TechDataList = new TechnologicalDataListModel();
            Transaction_List = new TransactionList();
        }

        
        int Run()
        {
            //之後平行化處理看看
            for(int i=0; i< Company.Count; i++)
            {
                Initial_CompanyData(Company[i]);
                SimulationVariable _SimulationVariable = new SimulationVariable();
                Transaction transaction = new Transaction() ;

                for (int j =0; j < TechDataList.TechData.Count; j++)
                {
                    if (_SimulationVariable.HasBuy)
                    {
                        _SimulationVariable.CountDays(TechDataList.TechData[j].ReturnOnInvestment);// put TechData Return on Investment
                    }

                    #region 看買賣條件
                    ///BuySell_ConditionForRise();
                    #endregion

                    if (_SimulationVariable.CanBuy && !_SimulationVariable.HasBuy)
                    {
                        transaction = new Transaction();
                        transaction.Buy(TechDataList.TechData[j].Company.ToString(), TechDataList.TechData[j].CompanyName,
                            TechDataList.TechData[j].ClosePrice, TechDataList.TechData[j].Date);

                        _SimulationVariable.HasBuy = true;

                    }

                    if (_SimulationVariable.CanSell && !_SimulationVariable.HasSell)
                    {
                        transaction.Sell(TechDataList.TechData[j].Company.ToString(), TechDataList.TechData[j].CompanyName,
                            TechDataList.TechData[j].ClosePrice, TechDataList.TechData[j].Date);

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