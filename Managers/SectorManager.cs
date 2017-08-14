using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

public class SectorManager : MonoBehaviour
{

    public enum Sectors
    {
        [Description("Aerospace")]
        Aerospace,
        Banking,
        ConsumerGoods,
        Defense,
        Energy,
        Manufacturing,
        Mining,
        Pharma,
        RealEstate,
        Health,
        Tourism,
        Telecom,
        Technology,
        Transport
    }
    public float GDPSpending;
    public List<CountrySectors> CountryMarketIndex;

    public List<CountrySectors> CountryMarketBaseIndex()
    {
        CountryMarketIndex = new List<CountrySectors>();
        //Create UK market

        var mineSub = new Dictionary<string, float>();
        mineSub.Add("Gold", 22f);
        mineSub.Add("Silver", 22f);
        mineSub.Add("Coper", 22f);
        mineSub.Add("Iron", 22f);
        mineSub.Add("Rare", 22f);

        var UkMarket = new CountrySectors
        {
            CountryName = "United Kingdom",
            Aerospace = 22f,
            Banking = 10f,
            ConsumerGoods = 15f,
            Defense = 25f,
            Energy = 35f,
            Manufacturing = 10f,
            Mining = 10f,
            MiningSubsectoryList = mineSub,
            Pharma = 5f,
            RealEstate = 24f,
            Health = 14f,
            Tourism = 15f,
            Telecom = 22f,
            Technology = 10f,
            Transport = 6f
        };
        //Create US market
        var UsMarket = new CountrySectors
        {
            CountryName = "United States of America",
            Aerospace = 20f,
            Banking = 10f,
            ConsumerGoods = 15f,
            Defense = 25f,
            Energy = 35f,
            Manufacturing = 10f,
            Mining = 10f,
            Pharma = 5f,
            RealEstate = 24f,
            Health = 14f,
            Tourism = 15f,
            Telecom = 22f,
            Technology = 10f,
            Transport = 6f
        };
        //Create China market
        var ChinaMarket = new CountrySectors
        {
            CountryName = "China",
            Aerospace = 14f,
            Banking = 10f,
            ConsumerGoods = 15f,
            Defense = 25f,
            Energy = 35f,
            Manufacturing = 10f,
            Mining = 10f,
            Pharma = 5f,
            RealEstate = 24f,
            Health = 14f,
            Tourism = 15f,
            Telecom = 22f,
            Technology = 10f,
            Transport = 6f
        };
        //Create Mexico intial share price
        var mexMarket = new CountrySectors
        {
            CountryName = "Mexico",
            Aerospace = 11f,
            Banking = 10f,
            ConsumerGoods = 15f,
            Defense = 25f,
            Energy = 35f,
            Manufacturing = 10f,
            Mining = 10f,
            Pharma = 5f,
            RealEstate = 24f,
            Health = 14f,
            Tourism = 15f,
            Telecom = 22f,
            Technology = 10f,
            Transport = 6f
        };

        CountryMarketIndex.Add(UsMarket);
        CountryMarketIndex.Add(UkMarket);
        CountryMarketIndex.Add(ChinaMarket);
        CountryMarketIndex.Add(mexMarket);

        return CountryMarketIndex;
    }
    public float CalculateNewSharePrice(float startPrice, float volatility, int day = 0)
    {
        var randomFloat = UnityEngine.Random.Range(0, 1f);
        var change_percent = 2 * volatility * (float)randomFloat;
        if (change_percent > volatility)
        {
            change_percent -= (2 * volatility);
        }

        var change_amount = startPrice * change_percent;

        var return_price = startPrice + change_amount;

        return return_price;
    }

    public CountrySectors GetCountrySectorByName(string country)
    {
        return CountryMarketIndex.FirstOrDefault(e => e.CountryName == country);
    }
    public CountrySectors GetCountrySectorByName(CountryToGlobalCountry.GenericCountry country)
    {
        return CountryMarketIndex.FirstOrDefault(e => e.CountryName == country.name);
    }

    public void Process()
    {


        string MarketOutput = string.Empty;
        float startingAeroPrice = 0;
        float startingBankingPrice = 0;
        //test for 180 days
        for (int i = 0; i < 15;)
        {

            float deltaChange = 0;
            float deltaChangeAero = 0;
            float deltaChangeBanking = 0;
            float deltaChangeConsumerGoods = 0;
            float deltaChangeDefense = 0;



            string Key = string.Format("\n\n Day {0} \n\n", i);

            MarketOutput += Key;
            foreach (var MarketSectors in CountryMarketBaseIndex())
            {
                //initall prices
                if (i == 0)
                {
                    startingAeroPrice = MarketSectors.Aerospace;
                    startingBankingPrice = MarketSectors.Banking;
                }



                deltaChange = MarketSectors.Aerospace;
                MarketSectors.Aerospace = CalculateNewSharePrice(MarketSectors.Aerospace, MarketSectors.AerospaceVolatility);
                deltaChangeAero = deltaChange - MarketSectors.Aerospace;
                var yearOverGainAeroPrice = startingAeroPrice - MarketSectors.Aerospace;

                deltaChange = MarketSectors.Banking;
                MarketSectors.Banking = CalculateNewSharePrice(MarketSectors.Banking, MarketSectors.BankingVolatility);
                deltaChangeBanking = deltaChange - MarketSectors.Banking;
                var yearOverBankingPrice = startingBankingPrice - MarketSectors.Aerospace;

                MarketSectors.ConsumerGoods = CalculateNewSharePrice(MarketSectors.ConsumerGoods, MarketSectors.ConsumerGoodsVolatility);
                MarketSectors.Defense = CalculateNewSharePrice(MarketSectors.Defense, MarketSectors.DefenseVolatility);
                MarketSectors.Energy = CalculateNewSharePrice(MarketSectors.Energy, MarketSectors.EnergyVolatility);
                MarketSectors.Health = CalculateNewSharePrice(MarketSectors.Health, MarketSectors.HealthVolatility);
                MarketSectors.Mining = CalculateNewSharePrice(MarketSectors.Mining, MarketSectors.MiningVolatility);
                MarketSectors.Pharma = CalculateNewSharePrice(MarketSectors.Pharma, MarketSectors.PharmaVolatility);
                MarketSectors.RealEstate = CalculateNewSharePrice(MarketSectors.RealEstate, MarketSectors.RealEstateVolatility);
                MarketSectors.Telecom = CalculateNewSharePrice(MarketSectors.Telecom, MarketSectors.TelecomVolatility);
                MarketSectors.Technology = CalculateNewSharePrice(MarketSectors.Technology, MarketSectors.TechnologyVolatility);
                MarketSectors.Tourism = CalculateNewSharePrice(MarketSectors.Tourism, MarketSectors.TourismVolatility);
                MarketSectors.Transport = CalculateNewSharePrice(MarketSectors.Transport, MarketSectors.TransportVolatility);

                MarketOutput += string.Format("Market: {0} \n", MarketSectors.CountryName);
                MarketOutput +=
                    string.Format(
                        "Output-- \n\n Aero {0} Daily Chg {1}  Gain {2} \n\n ## \n\n Banking {3} Daily Chg {4}  Start {5} \n\n\n",
                        MarketSectors.Aerospace, deltaChangeAero, yearOverGainAeroPrice, MarketSectors.Banking,
                        deltaChangeBanking, yearOverBankingPrice);

                //MarketSectors.ConsumerGoods, MarketSectors.Defense, MarketSectors.Energy,
                //        MarketSectors.Health,
                //        MarketSectors.Mining, MarketSectors.Pharma, MarketSectors.RealEstate,
                //        MarketSectors.Telecom,
                //        MarketSectors.Technology, MarketSectors.Tourism, MarketSectors.Transport

            }
            i++;


        }
    }
}

