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
        List<string> Company;//還未初始化
        
        TransactionList Transaction_List;
        private IStrategy _strategy;
       

        public SimulationStart(IStrategy strategy )
        {
            Company = new List<string>();
            Company.Add("2330");
            //TechDataList = new TechnologicalDataListModel();
            Transaction_List = new TransactionList();
            _strategy = strategy;
            
            
        }
      
        public TransactionList Run()
        {
            //之後平行化處理看看
            for(int i=0; i< Company.Count; i++)
            {               
                SimulationVariable _SimulationVariable = new SimulationVariable();
                Transaction transaction = new Transaction() ;
                DataList DataList = new DataList(Company[i]);
                BasicFinancialReportListModel BasicFinancialReportData = new BasicFinancialReportListModel();

                //////////////////
                DataList.LineGraphData(ref DataList.TechData, "ClosePrice");
                DataList.AddLineGraphDictionary("MoveAverageValue", 5);
                DataList.AddLineGraphDictionary("MoveAverageValue", 10);
                DataList.AddLineGraphDictionary("MinValue", 1);
                DataList.AddLineGraphDictionary("MinValue", 10);

                BasicFinancialReportData.Initial(int.Parse(DataList.TechData[i].Company.Trim()));
                //////////////////



                for (int j =0; j < DataList.TechData.Count; j++)
                {
                    //////////////////
                    BasicFinancialReportData.InitialDate(DataList.TechData[j].Date);
                    //////////////////


                    if (_SimulationVariable.HasBuy)
                    {
                        _SimulationVariable.CountDays((double)DataList.TechData[j].ReturnOnInvestment);// put TechData Return on Investment
                    }

                    #region 看買賣條件
                    BuySell_Condition(ref _SimulationVariable,ref DataList, ref BasicFinancialReportData, j);
                    #endregion

                    if (_SimulationVariable.CanBuy && !_SimulationVariable.HasBuy)
                    {
                        transaction = new Transaction();
                        transaction.Buy(DataList.TechData[j].Company.ToString(), DataList.TechData[j].CompanyName,
                            DataList.TechData[j].ClosePrice, DataList.TechData[j].Date);

                        _SimulationVariable.HasBuy = true;
                        

                    }
                    
                    if (_SimulationVariable.HasBuy && !_SimulationVariable.CanBuy)
                    {
                        transaction.Sell(DataList.TechData[j].Company.ToString(), DataList.TechData[j].CompanyName,
                            DataList.TechData[j].ClosePrice, DataList.TechData[j].Date);

                        Transaction_List._TransactionList.Add(transaction);

                        _SimulationVariable.HasBuy = false;                       
                        _SimulationVariable.Initial();
                    }

                }
            }
            return Transaction_List;
        }

        private void BuySell_Condition(ref SimulationVariable simulationVariable, ref DataList dataList,ref BasicFinancialReportListModel BasicFinancialData, int j)
        {
            if (!simulationVariable.HasBuy && _strategy.BuyCondition(ref simulationVariable, ref dataList, ref BasicFinancialData, j))
            {
                simulationVariable.CanBuy = true;
            }

            if (simulationVariable.HasBuy && _strategy.SellCondition(ref simulationVariable, ref dataList, ref BasicFinancialData, j))
            {
                simulationVariable.CanBuy = false;
            }
            
        }
    }
}