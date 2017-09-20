using StockSimulationMVC.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Models
{
    public class DataList: LineGraph
    {
        public List<TechnologicalDataModel> TechData = new List<TechnologicalDataModel>();
        public List<TaiwanStockIndexModel> TaiwanIndex = new List<TaiwanStockIndexModel>();
        public List<BasicFinancialDataModel> FinancialData = new List<BasicFinancialDataModel>();
        
        public DataList(string Company)
        {
            var _TechData = from CompanyData in InitialData.InitialData_TechnologicalData
                            where CompanyData.Company.Contains(Company)
                            orderby CompanyData.Date ascending
                            select CompanyData;
            TechData = _TechData.ToList();
        }

        public DataList()
        {
            
        }
        public void Initial(//string startDate, string EndDate,
            string Company, bool IsOTC = false)
        {
            var _TechData = from CompanyData in InitialData.InitialData_TechnologicalData
                            where CompanyData.Company.CompareTo(Company) == 0
                            orderby CompanyData.Date ascending
                            select CompanyData;
            TechData = _TechData.ToList();

        }



        //

    }


}
