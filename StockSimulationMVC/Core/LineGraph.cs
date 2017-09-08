using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace StockSimulationMVC.Core
{
    public abstract class LineGraph
    {
        List<double> SelectedData;

        public LineGraph()
        {
            SelectedData = new List<double>();
        }

        public void SelectData<T>(ref List<T> Data , string SelectDataName)
        {
            for(int i=0; i<Data.Count; i++)
            {
                PropertyInfo DataProperty = Data[i].GetType().GetProperty(SelectDataName);
                SelectedData.Add((double)DataProperty.GetValue(Data[i]));
            }
        }

        public List<double> MoveAverageValue(int AverageDays)//移動平均數
        {
            double sum = 0;
            List<double> MoveAverageData = new List<double>();

            for(int i=0; i<AverageDays; i++)
            {
                MoveAverageData.Add(0);
            }

            for (int i = AverageDays; i < SelectedData.Count; i++)
            {

                for (int j = 0; j < AverageDays; j++)
                {
                    sum += SelectedData[i - j];
                }

                SelectedData[i] = sum / AverageDays;
                MoveAverageData.Add(sum);
                sum = 0;
            }

            return MoveAverageData;
        }
        public List<double> MaxValue(int MaxDays)//新高
        {
            double Max = 0;
            List<double> MaxData = new List<double>();

            for (int i = 0; i < MaxDays; i++)
            {
                MaxData.Add(0);
            }

            for (int i = MaxDays; i < SelectedData.Count; i++)
            {


                for (int j = 0; j < MaxDays; j++)
                {
                    if (SelectedData[i - j] > Max)
                        Max = SelectedData[i - j];
                }

                SelectedData.Add(Max);
                Max = 0;
            }
            return SelectedData;
        }

        void Initial_MinClosePrice(params int[] MinDays)//最低價
        {
            double Min = 10000;


            //for (int k = 0; k < MinDays.Length; k++)
            //{
            //    for (int i = MinDays[k]; i < TechData.Count; i++)
            //    {
            //        if (TechData[i].MinPrice == null)
            //        {
            //            TechData[i].MinPrice = new double[MinDays.Length];
            //        }

            //        for (int j = 0; j < MinDays[k]; j++)
            //        {
            //            if (TechData[i - j].ClosePrice < Min)
            //                Min = TechData[i - j].ClosePrice;
            //        }

            //        TechData[i].MinPrice[k] = Min;
            //        Min = 10000;
            //    }
            //}
        }
    }
}