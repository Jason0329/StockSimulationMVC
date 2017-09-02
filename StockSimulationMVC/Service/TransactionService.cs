using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockSimulationMVC.Models
{
    public class Transaction
    {
        BuyModel BuyInstrument;
        SellModel SellInstrument;
        TransactionResultModel BuySellResult;

        public BuyModel BuyDetail { get { return BuyInstrument; } }
        public SellModel SellDetail { get { return SellInstrument; } }

        public void Buy(string Number , string Name , Decimal Price , DateTime datetime , int share=1)
        {
            if (BuyInstrument == null)
            {
                BuyInstrument = new BuyModel();
                BuyInstrument.Name = Name;
                BuyInstrument.Nubmer = Number;
                BuyInstrument.Price = Price;
                BuyInstrument.Share = share;
                BuyInstrument.Date = datetime;
            }              
            else
                throw new Exception("Buy Instrument has object. Please check logic" + Number +":"+datetime);

            if (SellInstrument != null)
                CalculateResult();
        }

        public void Sell(string Number, string Name, Decimal Price, DateTime datetime, int share = 1)
        {
            if(SellInstrument==null)
            {
                SellInstrument = new SellModel();
                SellInstrument.Name = Name;
                SellInstrument.Nubmer = Number;
                SellInstrument.Price = Price;
                SellInstrument.Share = share;
                SellInstrument.Date = datetime;
            }
            else
                throw new Exception("Sell Instrument has object. Please check logic" + Number + ":" + datetime);

            if (BuyInstrument != null)
                CalculateResult();
        }

        void CalculateResult()
        {
            BuySellResult = new TransactionResultModel();
            BuySellResult.Revenue = SellInstrument.Price - BuyInstrument.Price;
            BuySellResult.RateOfReturn = (SellInstrument.Price - BuyInstrument.Price) / BuyInstrument.Price;
            BuySellResult.HoldDays = SellInstrument.Date.Subtract(  BuyInstrument.Date).TotalDays;
        }
    }
}