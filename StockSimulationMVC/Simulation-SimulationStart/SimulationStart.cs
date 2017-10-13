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
        List<double> Company;//還未初始化
        
        TransactionList Transaction_List;
        private IStrategy _strategy;
       

        public SimulationStart(IStrategy strategy )
        {
            Company = new List<double>();
            var CoData = from _company in InitialData.InitialData_CompanyData
                         where _company.ID ==2330
                         select _company.ID;

            //foreach(var data in CoData)
            //{
            //    Company.Add(data)
            //}
            Company = (List<double>)CoData.ToList();

            //for(int i=0; i<InitialData.InitialData_TechnologicalData.Count; i++)
            //{
            //    try
            //    {
            //        int.Parse(InitialData.InitialData_TechnologicalData[i].Company);
            //        Company.Add(InitialData.InitialData_TechnologicalData[i].Company, InitialData.InitialData_TechnologicalData[i].Company);
            //    }
            //    catch (Exception ee){ }
            //}

            //Company.Add("3481");
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
                DataList DataList = new DataList(Company[i].ToString());
                BasicFinancialReportListModel BasicFinancialReportData = new BasicFinancialReportListModel();

                //////////////////
                DataList.LineGraphData(ref DataList.TechData, "ClosePrice");
                DataList.AddLineGraphDictionary("MoveAverageValue", 5);
                DataList.AddLineGraphDictionary("MoveAverageValue", 10);
                DataList.AddLineGraphDictionary("MinValue", 1);
                DataList.AddLineGraphDictionary("MinValue", 10);
                DataList.AddLineGraphDictionary("BollingerBandsDown", 5 , 1.5);
                DataList.AddLineGraphDictionary("MoveAverageValue", 1);

                if (DataList.TechData.Count == 0) continue;

                BasicFinancialReportData.Initial(int.Parse(DataList.TechData[0].Company.Trim()));
                //////////////////



                for (int j =0; j < DataList.TechData.Count; j++)
                {
                    //////////////////
                    BasicFinancialReportData.InitialDate(DataList.TechData[j].Date);
                    //////////////////


                    if (_SimulationVariable.HasBuy)
                    {
                        _SimulationVariable.CountDays(DataList.TechData[j]);// put TechData Return on Investment
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
                        _SimulationVariable.Buy = DataList.TechData[j];

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