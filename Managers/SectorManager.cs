using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System;

public class SectorManager : MonoBehaviour
{
//    Typical analyses find that tariffs tend to benefit domestic producers and government at the expense of consumers, and that the net welfare effects of a tariff on the importing country are negative.Normative judgements often follow from these findings, namely that it may be disadvantageous for a country to artificially shield an industry from world markets and that it might be better to allow a collapse to take place.Opposition to all tariff aims to reduce tariffs and to avoid countries discriminating between differing countries when applying tariffs.The diagrams to the right show the costs and benefits of imposing a tariff on a good in the domestic economy.

//When incorporating free international trade into the model we use a supply curve denoted as {\displaystyle P_ { tariff }
//}
//P_{tariff} (diagram 1) or {\displaystyle P_ { w }} P_{w} (diagram 2). This curve represents the assumption that the international supply of the good or service is perfectly elastic and that the world can produce at a near infinite quantity of the good.Before the tariff, there is a quantity demanded of Qc1 (diagram 1) or D(diagram 2). The difference between quantity demanded and quantity supplied(between D and S on diagram 2, respectively) was filled by importing from abroad.This is shown on diagram 1 as Quantity of Imports (without tariff). After the imposition of a tariff, domestic price rises, but foreign export prices fall due to the difference in tax incidence on the consumers (at home) and producers (abroad).


//The new price level at Home is Ptariff or Pt, which is higher than the world price.More of the good is now produced at Home – it now makes Qs2(diagram 1) or S* (diagram 2) of the good.Due to the higher price, only Qc2 or D* of the good is demanded by Home.The difference between the quantity supplied and the quantity demanded is still filled by importing from abroad.However, the imposition of the tariff reduces the quantity of imports from D − S to D* − S* (diagram 2). This is also shown in diagram 1 as Quantity of Imports(with tariff).

//Domestic producers enjoy a gain in their surplus.Producer surplus, defined as the difference between what the producers were willing to receive by selling a good and the actual price of the good, expands from the region below Pw to the region below Pt.Therefore, the domestic producers gain an amount shown by the area A.

//Domestic consumers face a higher price, reducing their welfare.Consumer surplus is the area between the price line and the demand curve. Therefore, the consumer surplus shrinks from the area above Pw to the area above Pt, i.e.it shrinks by the areas A, B, C and D.This includes the gained producer surplus, the deadweight loss, and the tax revenue.

//The government gains from the taxes. It charges an amount Pt − Pt* of tariff for every good imported.Since D* − S* goods are imported, the government gains an area of C and E.However, there is a deadweight loss of the triangles B and D, or in diagram 1, the triangles labeled Societal Loss.Deadweight loss is also called efficiency loss. This cost is incurred because tariffs reduce the incentives for the society to consume and produce.

//The net loss to the society due to the tariff would be given by the total costs of the tariff minus its benefits to the society. Therefore, the net welfare loss due to the tariff is equal to:

//Consumer Loss − Government Revenue − Producer Gain
//or graphically, this gain is given by the areas shown by:

//{\displaystyle(A + B + C + D) - (C + E) - A = B + D - E}
//(A+B+C+D)-(C+E)-A=B+D-E
//That is, tariffs are beneficial to the society if the area given by the rectangle E is greater than the deadweight loss.Rectangle E is called the terms of trade gain.

//The model above is completely accurate only in the extreme case where no consumer belongs to the producers group and the cost of the product is a fraction of their wages.If the opposite extreme is taken, assuming that all consumers come from the producers' group, consumers' only purchasing power comes from the wages earned in production, and the product costs their whole wage, the graph looks radically different.Without tariffs, only those producers/consumers able to produce the product at the world price will have the money to purchase it at that price.
    #region Resource Types

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
        Transport,
        Agriculture
    }

    public List<KeyValuePair<Sectors, string>> SubSectors;

    public enum ResourceType
    {
        BioticRenewable,
        BioticNonRenewable,
        AbioticRenewable,
        AbioticNonRenewable,
    }
    public enum ResourceDevelopment
    {
        PotentialResources,
        ActualResources,
        ReserveResources,
        FutureTechResources
    }
    public enum ResourcesCategory
    {
        RawMaterials,
        
        EnergyGeneration,
        FoodAndArgiculture,
        IndustrialMaterials,
        FinishedGoods,
        Services
    }
  
    public enum Resources
    {
        [Description("Rare Earth Metals")]
        REM,
        GoldOre,
        IronOre,
        CopperOre,
        SilverOre,
        CobaltOre,
        [Description("Rare Earth Metals")]
        Zinc,
        [Description("Rare Earth Metals")]
        Tin,
        [Description("Rare Earth Metals")]
        Platinum,
        [Description("Rare Earth Metals")]
        Palladium,
        [Description("Rare Earth Metals")]
        CrudeOil,
        [Description("Rare Earth Metals")]
        PetroleumExtaction,
        [Description("Rare Earth Metals")]
        Gasoline,
        [Description("Rare Earth Metals")]
        HeatingOil,
        [Description("Rare Earth Metals")]
        NaturalGas,
        [Description("Rare Earth Metals")]
        OilShale,
        [Description("Rare Earth Metals")]
        Kerosene,
        [Description("Rare Earth Metals")]
        CarbonEmissions,
        [Description("Rare Earth Metals")]
        Fishing,
        [Description("Rare Earth Metals")]
        Lumber,
        [Description("Rare Earth Metals")]
        Corn,
        [Description("Rare Earth Metals")]
        Wheat,
        [Description("Rare Earth Metals")]
        Oats,
        [Description("Rare Earth Metals")]
        Rice,
        [Description("Rare Earth Metals")]
        Soybean,
        [Description("Rare Earth Metals")]
        GrainOil,
        [Description("Rare Earth Metals")]
        Cocoa,
        [Description("Rare Earth Metals")]
        Coffee,
        [Description("Rare Earth Metals")]
        Sugar,
        [Description("Rare Earth Metals")]
        OrangeJuice,
        [Description("Rare Earth Metals")]
        Cotton,
        [Description("Rare Earth Metals")]
        Rubber,
        [Description("Rare Earth Metals")]
        CornOil,
        [Description("Rare Earth Metals")]
        LiveCattle,
        [Description("Meat in production")]
        FeederCattle,
        [Description("FinishedGoods")]
        FeederHogs,
        [Description("FinishedGoods")]
        Chicken,
        [Description("FinishedGoods")]
        Fruits,
        [Description("FinishedGoods")]
        Vegetables,
        [Description("FinishedGoods")]
        Dairy,
        [Description("FinishedGoods")]
        Tobacco,
        [Description("FinishedGoods")]
        HoneyBeeProducts,
        [Description("FinishedGoods")]
        FoodStuffs,
        [Description("FinishedGoods")]
        Food,
        [Description("IndustrialMaterials")]
        Cement,
        [Description("IndustrialMaterials")]
        Steel,
        [Description("IndustrialMaterials")]
        Aluminum,
        [Description("Meat in production")]
        HeavyManchinary,
        [Description("Meat in production")]
        IndustrialMagnets,
        [Description("Meat in production")]
        IndustrialMilitaryGoods,
        [Description("Meat in production")]
        IndustrialLasers,
        [Description("Meat in production")]
        IndustrialComponets,
        [Description("Meat in production")]
        IndustrialMotors,
        [Description("Meat in production")]
        IndustrialGreenMotors,
        [Description("IndustrialMaterials")]
        IndustrialGenerators,
        [Description("IndustrialMaterials")]
        IndustrialGreenGenerators,
        [Description("IndustrialMaterials")]
        IndustrialChemicals,
        [Description("IndustrialMaterials")]
        IndustrialMachinary,
        [Description("IndustrialMaterials")]
        Industrial3DMachinary,
        [Description("IndustrialMaterials")]
        IndustrialNanomaterials,
        [Description("IndustrialMaterials")]
        IndustrialGlass,
        [Description("IndustrialMaterials")]
        IndustrialDiamonds,
        [Description("IndustrialMaterials")]
        IndustrialPlastics,
        [Description("IndustrialMaterials")]
        IndustrialGreenPlastics,
        [Description("IndustrialMaterials")]
        Pharmaceuticals,
        [Description("FinishedGoods")]
        EllictDrugs,
        [Description("FinishedGoods")]
        ConsumerElectronics,
        [Description("FinishedGoods")]
        ConsumerAppliances,
        [Description("FinishedGoods")]
        ComsumerCars,
        [Description("FinishedGoods")]
        ComsumerTrucks,
        [Description("FinishedGoods")]
        ComsumerDiamonds,
        [Description("FinishedGoods")]
        ComsumerAutonousCarsAndTrucks,
        [Description("FinishedGoods")]
        CommericalAircraft,
        [Description("FinishedGoods")]
        AircraftEngines,
        [Description("FinishedGoods")]
        RocketEngines,
        [Description("FinishedGoods")]
        Satillites,
        [Description("FinishedGoods")]
        MissileComponents,
        [Description("FinishedGoods")]
        DualUseMaterials,
        [Description("FinishedGoods")]
        ExoticMaterials,
        [Description("FinishedGoods")]
        Furniture,
        [Description("FinishedGoods")]
        AircraftComponents,
        [Description("FinishedGoods")]
        CarParts,
        [Description("FinishedGoods")]
        CarEngines,
        [Description("FinishedGoods")]
        ClothingTexiles,
        [Description("FinishedGoods")]
        LuxuryProducts,
        [Description("FinishedGoods")]
        ComsumerHealthProducts,
        [Description("FinishedGoods")]
        ComsumerDrones,
        [Description("Service")]
        ServicesFinancial,
        [Description("Service")]
        ServiceHealthCare,
        [Description("Service")]
        ServiceInformationTech,
        [Description("Service")]
        ServiceLaw,
        [Description("Service")]
        ServiceInsurance,
        [Description("Service")]
        ServicePublic,
        [Description("Service")]
        ServiceTourism,
        [Description("Service")]
        ServiceEntertainment
    }
    public class CountryResource : ScriptableObject
    {
        public string ResourceName;
        [ContextMenuItem("Get Description", "GetResourceDescription")]
        public string ResourceDescription;
        private void GetResourceDescription()
        {

            ResourceDescription = Resource.ToDescription();
        }
        public float Production;
        public float Consumption;
        public float Trade;
        public float Available;
        public bool SectorLegalStatus;
        public float SectorTaxRate;
        public float TariffRate;
        public Resources Resource;
        public ResourcesCategory ResourceCategory;
        public Sectors ResourceSector;
        public ResourceDevelopment ResourceDevelop;
        public ResourceType Type;

       
    }
    #endregion

    public List<CountryResource> GamePlayerCoutryResourceList;
    public float GDPSpending;
    public List<CountrySectors> CountryMarketIndex;
    public List<CountryResource> CountryResourceMarketList;
    public Tuple<CountryResource, float, float> SectorShare;
    public List<Tuple<CountryResource, float, float>> WorldResourceIndex;

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

