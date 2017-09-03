using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Models
{
    public class BasicFinancialReportListModel
    {
        public List<BasicFinancialDataModel> DataList = new List<BasicFinancialDataModel>();
        public List<MonthRevenueModel> RevenueList = new List<MonthRevenueModel>();
        public int RevenueInt = -1;
        public int BasicFinancialInt = -1;

        #region Initial 
                //public void Initial(string startDate, string EndDate, int company, bool IsOTC = false)
                //{
                //    DataList.Clear();
                //    RevenueList.Clear();
                //    List<string[]> temp = new List<string[]>();
                //    string command = "";

                //    #region 看使否為上櫃股是資料
                //    if (IsOTC)
                //    {
                //        command = @"SELECT [company],[Column1],[Column16],[Column17],[Column18],[Column19],[Column76],[Column77],[Column95],[Column101],[Column75],[Column65],[Column15]
                //                        FROM [OverTheCounter].[dbo].[standard_analysis] where company =" + company + @"and [Column1] between '" + startDate + @"' and 
                //                        '" + EndDate + "' order by Column1";
                //    }
                //    else
                //    {
                //        command = @"SELECT [company],[Column1],[Column16],[Column17],[Column18],[Column19],[Column76],[Column77],[Column95],[Column101],[Column75],[Column65],[Column15]
                //                        FROM [StockDatabase].[dbo].[standard_analysis] where company =" + company + @"and [Column1] between '" + startDate + @"' and 
                //                        '" + EndDate + "' order by Column1";
                //    }

                //    gd.GetData(command, ref temp);

                //    for (int i = 0; i < temp.Count; i++)
                //    {
                //        DataList.Add(new BasicData(temp[i]));
                //    }


                //    if (IsOTC)
                //    {
                //        command = @"SELECT [company],[Column1],[Column2],[Column4],[Column5] FROM  [OverTheCounter].[dbo].[_monthRevenue] where company=" + company +
                //            @" and [Column1] between '" + startDate + @"' and  '" + EndDate + @"' order by [Column1]";

                //    }
                //    else
                //    {
                //        command = @"SELECT [company],[Column1],[Column2],[Column4],[Column5] FROM [StockDatabase].[dbo].[_monthRevenue] where company=" + company +
                //            @" and [Column1] between '" + startDate + @"' and  '" + EndDate + @"' order by [Column1]";
                //    }
                //    #endregion

                //    temp = new List<string[]>();

                //    gd.GetData(command, ref temp);

                //    for (int i = 0; i < temp.Count; i++)
                //    {
                //        RevenueList.Add(new MonthRevenue(temp[i]));
                //    }
                //}
        #endregion

        #region 每季財報
        public void InitialDate(DateTime dt)
        {
            BasicFinancialInt = 0;

            #region 第一季
            if (dt.Year >= 2008 && dt.Year <= 2012 && dt.Month > 4 && dt.Month < 9)
            {
                for (int i = 0; i < DataList.Count; i++)
                {
                    if (DataList[i].Date.Year == dt.Year && DataList[i].Date.Month == 3)
                    {
                        BasicFinancialInt = i;
                        break;
                    }

                }
            }
            else if (dt.Year > 2012 && (dt.Month > 4 && dt.Month < 8 || dt.Month == 8 && dt.Day <= 15))
            {
                for (int i = 0; i < DataList.Count; i++)
                {
                    if (DataList[i].Date.Year == dt.Year && DataList[i].Date.Month == 3)
                    {
                        BasicFinancialInt = i;
                        break;
                    }
                }
            }


            #endregion
            #region 第二季
            if (dt.Year <= 2012 && dt.Year >= 2008 && dt.Month > 8 && dt.Month < 11)
            {
                for (int i = 0; i < DataList.Count; i++)
                {
                    if (DataList[i].Date.Year == dt.Year && DataList[i].Date.Month == 6)
                    {
                        BasicFinancialInt = i;
                        break;
                    }
                }
            }
            else if (dt.Year > 2012 && (dt.Month > 8 && dt.Month < 11 ||
                (dt.Month == 8 && dt.Day > 15)
                || (dt.Month == 11 && dt.Day <= 15)))
            {
                for (int i = 0; i < DataList.Count; i++)
                {
                    if (DataList[i].Date.Year == dt.Year && DataList[i].Date.Month == 6)
                    {
                        BasicFinancialInt = i;
                        break;
                    }
                }
            }
            else if (dt.Year <= 2007 && dt.Year >= 2002 || (dt.Year == 2008 && dt.Month < 6))
            {
                if (dt.Month > 8)
                {
                    for (int i = 0; i < DataList.Count; i++)
                    {
                        if (DataList[i].Date.Year == dt.Year && DataList[i].Date.Month == 6)
                        {
                            BasicFinancialInt = i;
                            break;
                        }
                    }
                }
                else if (dt.Month <= 3)
                {
                    for (int i = 0; i < DataList.Count; i++)
                    {
                        if (DataList[i].Date.Year == dt.Year - 1 && DataList[i].Date.Month == 6)
                        {
                            BasicFinancialInt = i;
                            break;
                        }
                    }
                }
            }
            #endregion
            #region 第三季
            if (dt.Month < 4 || dt.Month == 12 || dt.Month == 11)
            {

                if (dt.Year > 2012 && ((dt.Month == 11 && dt.Day >= 15) || dt.Month == 12 || dt.Month < 4))
                {
                    for (int i = 0; i < DataList.Count; i++)
                    {
                        if (DataList[i].Date.Year == dt.Year && DataList[i].Date.Month == 9)
                        {
                            BasicFinancialInt = i;
                            break;
                        }
                        else if (dt.Month <= 3)
                        {
                            if (DataList[i].Date.Year == dt.Year - 1 && DataList[i].Date.Month == 9)
                            {
                                BasicFinancialInt = i;
                                break;
                            }
                        }
                    }
                }
                else if (dt.Year <= 2012 && dt.Year >= 2008)
                {
                    for (int i = 0; i < DataList.Count; i++)
                    {
                        if (dt.Month >= 11)
                        {
                            if (DataList[i].Date.Year == dt.Year && DataList[i].Date.Month == 9)
                            {
                                BasicFinancialInt = i;
                                break;
                            }
                        }
                        else if (dt.Month <= 3)
                        {
                            if (DataList[i].Date.Year == dt.Year - 1 && DataList[i].Date.Month == 9)
                            {
                                BasicFinancialInt = i;
                                break;
                            }
                        }
                    }
                }

            }
            #endregion
            #region 第四季
            if (dt.Year <= 2012 && dt.Year >= 2008)
            {
                if (dt.Month == 4)
                {
                    for (int i = 0; i < DataList.Count; i++)
                    {
                        if (DataList[i].Date.Year == dt.Year - 1 && DataList[i].Date.Month == 12)
                        {
                            BasicFinancialInt = i;
                            break;
                        }
                    }
                }
            }
            else if (dt.Year > 2012)
            {
                if (dt.Month == 4 || (dt.Month == 5 && dt.Day < 15))
                {
                    for (int i = 0; i < DataList.Count; i++)
                    {
                        if (DataList[i].Date.Year == dt.Year - 1 && DataList[i].Date.Month == 12)
                        {
                            BasicFinancialInt = i;
                            break;
                        }
                    }
                }
            }
            else if (dt.Year <= 2007 && dt.Year >= 2002)
            {
                if (dt.Month >= 4)
                {
                    for (int i = 0; i < DataList.Count; i++)
                    {
                        if (DataList[i].Date.Year == dt.Year - 1 && DataList[i].Date.Month == 12)
                        {
                            BasicFinancialInt = i;
                            break;
                        }
                    }
                }
                else if (dt.Month <= 8)
                {
                    for (int i = 0; i < DataList.Count; i++)
                    {
                        if (DataList[i].Date.Year == dt.Year && DataList[i].Date.Month == 12)
                        {
                            BasicFinancialInt = i;
                            break;
                        }
                    }
                }
            }
            else if (dt.Year <= 2001)
            {
                if (dt.Month < 4)
                {
                    for (int i = 0; i < DataList.Count; i++)
                    {
                        if (DataList[i].Date.Year == dt.Year - 1 && DataList[i].Date.Month == 12)
                        {
                            BasicFinancialInt = i;
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < DataList.Count; i++)
                    {
                        if (DataList[i].Date.Year == dt.Year && DataList[i].Date.Month == 12)
                        {
                            BasicFinancialInt = i;
                            break;
                        }
                    }
                }
            }
            #endregion
            #region 每月營收
            InitialRevenue(dt);
            #endregion

            //Console.WriteLine(DataList[BasicFinancialInt].Date.Year+" "+DataList[BasicFinancialInt].Date.Month);
            //Console.WriteLine(RevenueList[RevenueInt].Date);
        }
        #endregion

        #region 每月營收
        void InitialRevenue(DateTime dt)
        {
            RevenueInt = 0;
            if (dt.Day >= 10)
            {


                for (int i = 0; i < RevenueList.Count; i++)
                {
                    if (RevenueList[i].Date.Month.CompareTo(dt.Month - 1) == 0
                        && RevenueList[i].Date.Year.CompareTo(dt.Year) == 0
                        && (dt.Month != 1))
                    {
                        RevenueInt = i;
                        break;
                    }
                    else if (dt.Month == 1 && RevenueList[i].Date.Year.CompareTo(dt.Year - 1) == 0
                        && (RevenueList[i].Date.Month.CompareTo(12) == 0))
                    {
                        RevenueInt = i;
                        break;
                    }
                }

            }
            else if (dt.Day < 10)
            {
                if (dt.Month != 1)
                    InitialRevenue(new DateTime(dt.Year, dt.Month - 1, 15));
                else
                    InitialRevenue(new DateTime(dt.Year - 1, 12, 15));
            }
        }
        #endregion
    }
}