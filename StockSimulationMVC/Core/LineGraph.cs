using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace StockSimulationMVC.Core
{
    public class LineGraph
    {
        List<double> SelectedData;
        Dictionary<string, List<double>> LineGraphDictionarny;
        public delegate int aa();
        public aa tee;

        public LineGraph()
        {
            SelectedData = new List<double>();
            LineGraphDictionarny = new Dictionary<string, List<double>>();

            SelectedData.Add(12.2);
            SelectedData.Add(12.4);
            SelectedData.Add(12.1);
            SelectedData.Add(12.5);
            SelectedData.Add(12.0);
            SelectedData.Add(12.6);
        }

        public void LineGraphData<T>(ref List<T> Data, string SelectDataName)
        {
            SelectedData.Clear();

            for (int i = 0; i < Data.Count; i++)
            {
                PropertyInfo DataProperty = Data[i].GetType().GetProperty(SelectDataName);
                SelectedData.Add((double)DataProperty.GetValue(Data[i]));
            }
        }

        public bool CoditionSatified(string StrategyName1 , string StrategyName2 ,int DaysCounter, bool Isbigger=true)
        {
            bool _IsConditionSatified = LineGraphDictionarny[StrategyName1][DaysCounter] > LineGraphDictionarny[StrategyName2][DaysCounter];

            return Isbigger ? _IsConditionSatified : !_IsConditionSatified;
        }

        public void AddLineGraphDictionary(string StrategyName , int Days)
        {
            MethodInfo method = this.GetType().GetMethod(StrategyName);
            var Line = method.Invoke(this, new object[] { Days});
            LineGraphDictionarny.Add(StrategyName, (List < double >) Line);

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

                MoveAverageData.Add(sum / AverageDays);
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

                MaxData.Add(Max);
                Max = 0;
            }
            return MaxData;
        }
        public List<double> MinValue(int MinDays)//新低
        {
            double Min = int.MaxValue;
            List<double> MinData = new List<double>();

            for (int i = 0; i < MinDays; i++)
            {
                MinData.Add(0);
            }

            for (int i = MinDays; i < SelectedData.Count; i++)
            {

                for (int j = 0; j < MinDays; j++)
                {
                    if (SelectedData[i - j] < Min)
                        Min = SelectedData[i - j];
                }

                MinData.Add(Min);
                Min = int.MaxValue;
            }

            return MinData;
        }
        public List<double> Acculation(int AcculationDays)//多日累積
        {
            double Acc = 0;
            List<double> Accul = new List<double>();

            for (int i = 0; i < AcculationDays; i++)
            {
                Accul.Add(0);
            }

            for (int i = AcculationDays; i < SelectedData.Count; i++)
            {
                for (int j = 0; j < AcculationDays; j++)
                {
                    Acc += SelectedData[i - j];
                }

                Accul.Add(Acc);
                Acc = 0;
            }

            return Accul;
        }
    }
}