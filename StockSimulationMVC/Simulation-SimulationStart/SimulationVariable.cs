using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace StockSimulationMVC.Simulation_SimulationStart
{
    public class SimulationVariable
    {
        public bool CanBuy { get; set; }
        public bool HasBuy { get; set; }
        public bool CanSell { get; set; }
        public bool HasSell { get; set; }
        public int HaveStockDay { get; set; }
        public double Accumulation { get; set; }
        public double AccumulationRise { get; set; }
        public double AccumulationDrop { get; set; }
        public bool PreSell { get; set; }
        public double startToCountDropAfterPreSell { get; set; }
        public int CountDropDay { get; set; }
        public int Circumstance { get; set; }
        public Guid Number;

        public SimulationVariable()
        {
            Number = Guid.NewGuid();
            Initial();
        }
        public void Initial()
        {
            CountDropDay = 0;
            CanBuy = false;
            CanSell = false;
            HasBuy = false;
            HasSell = true;
            PreSell = false;
            HaveStockDay = 0;
            Accumulation = 0;
            AccumulationDrop = 0;
            AccumulationRise = 0;
            startToCountDropAfterPreSell = 0;
        }

        public bool CoditionSatified(double CompareValue, string CompareProperty, bool IsbiggerOrEqual = true)
        {
            PropertyInfo property = this.GetType().GetProperty(CompareProperty);
            double Value = Convert.ToDouble( property.GetValue(this));
            double IsBiggerThanZero = Value - CompareValue;

            bool _IsConditionSatified = IsBiggerThanZero >= 0.0;

            return IsbiggerOrEqual ? _IsConditionSatified : !_IsConditionSatified;
        }

        public void CountDays(double UnrealizedGains)
        {
            HaveStockDay++;
            Accumulation += UnrealizedGains;

            if (UnrealizedGains > 0)
                AccumulationRise += UnrealizedGains;
            else if (UnrealizedGains < 0)
                AccumulationDrop += UnrealizedGains;
        }
    }
}