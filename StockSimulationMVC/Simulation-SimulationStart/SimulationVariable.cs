using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Simulation_SimulationStart
{
    public class SimulationVariable
    {
        public bool CanBuy = false;
        public bool HasBuy = false;
        public bool CanSell = false;
        public bool HasSell = false;
        public int HaveStockDay = 0;
        public double Accumulation = 0;
        public double AccumulationRise = 0;
        public double AccumulationDrop = 0;
        public bool PreSell = false;
        public double startToCountDropAfterPreSell = 0;
        public int CountDropDay = 0;
        public int Circumstance = 0;
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