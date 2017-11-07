using UnityEngine;
using System.Collections;
using System.Reflection;
using System.Linq;
using System;
using WorldMapStrategyKit;
using System.Collections.Generic;
using System.ComponentModel;

public class CountryToGlobalCountry
{
    [Serializable]
    public class GenericCountry
    {
        public int index;
        public string name;
        public string regionName;
        public Vector2 location;
        public Vector2 captialLocation;
        public Texture2D flagowner;
        public List<GenericProvince> listofGenericProvinces;
    }


    public enum DevelopmentTier
    {
        Any,
        Underdeveloped,
        Developed,
        HighlyDeveloped,
        Advanced
    }

    public enum MapLevelType
    {

        City,
        Province,
        State,
        World,
        Local
    }

    /// <summary>
    /// Generate a city type based of the population or something other stats
    /// </summary>
    /// <param name="city"></param>
    /// <param name="province"></param>
    /// <param name="gov"></param>
    /// <param name="map"></param>
    /// <returns></returns>
    public CityType GetCityType(City city, Province province, CountryGovernment gov, WMSK map)
    {
        if (city.cityClass == CITY_CLASS.REGION_CAPITAL)
        {
            return CityType.RegionalCaptial;
        }
        else if (city.cityClass == CITY_CLASS.COUNTRY_CAPITAL)
        {
            return CityType.GovernmentCaptial;
        }
        //over 10 million
        if (city.population > 10000001)
        {
            return CityType.MegaCity;
        }
        else if (city.population <= 3000001 && city.population >= 9999999)
        {
            //between 10 million and 3 million
            return CityType.Metropolis;
        }

        if (city.population <= 999999 && city.population >= 2999999)
        {
            //between 3 million and 1 million
            return CityType.LargeCity;
        }
        else if (city.population <= 300001 && city.population >= 999999)
        {

            //between 1 million and 300k
            return CityType.City;
        }

        if (city.population <= 299999 && city.population >= 100001)
        {
            //between 300k and 100k
            return CityType.SmallCity;
        }
        else if (city.population <= 99999 && city.population >= 20001)
        {
            //100k to 20k
            return CityType.Town;
        }
        else if (city.population >= 20000 && city.population >= 1001)
        {
            //from 20k to 1k
            if (gov.CustomRegionName == "Western European" || gov.CustomRegionName == "Eastern European")
            {
                return CityType.SmallTownEuropean;
            }
            if (gov.CustomRegionName == "Eastern Asia")
            {
                return CityType.SmallTownAsia;
            }
            if (gov.CustomRegionName == "Western Asia" || gov.CustomRegionName == "North Africa")
            {
                return CityType.SmallTownMiddleEastern;
            }
            if (gov.CustomRegionName == "Africa" || gov.CustomRegionName == "West Africa")
            {
                return CityType.SmallTownAfrica;
            }

            return CityType.SmallTown;

        }

        if (city.population >= 1000 && city.population >= 501)
        {
            //1k or less
            return CityType.Village;
        }
        else if (city.population <= 151 && city.population >= 500)
        {
            return CityType.SmallVillage;
        }

        if (city.population < 150)
        {
            //150 or less
            return CityType.Hamlet;
        }
        return CityType.Remote;
    }


    public List<Tuple<SectorManager.Sectors, long>> GenerateRandomSectors(CountryGovernment government)
    {
        var randomSectors = new List<Tuple<SectorManager.Sectors, long>>();

        if (government.AgricultureRate > 0.25f)
        {
            randomSectors.Add(new Tuple<SectorManager.Sectors, long>(SectorManager.Sectors.Agriculture, 500));
        }

        if (government.ServicesRate > 0.25f)
        {
            randomSectors.Add(new Tuple<SectorManager.Sectors, long>(SectorManager.Sectors.Banking, 500));
            randomSectors.Add(new Tuple<SectorManager.Sectors, long>(SectorManager.Sectors.Health, 500));
            randomSectors.Add(new Tuple<SectorManager.Sectors, long>(SectorManager.Sectors.Technology, 500));

        }
        if (government.IndustryRate > 0.25f)
        {
            randomSectors.Add(new Tuple<SectorManager.Sectors, long>(SectorManager.Sectors.Manufacturing, 500));
            randomSectors.Add(new Tuple<SectorManager.Sectors, long>(SectorManager.Sectors.Mining, 500));
            randomSectors.Add(new Tuple<SectorManager.Sectors, long>(SectorManager.Sectors.Telecom, 500));
            randomSectors.Add(new Tuple<SectorManager.Sectors, long>(SectorManager.Sectors.ConsumerGoods, 500));
        }

        return randomSectors;
    }

    public List<GenericCountryInfrastructure> RandomList()
    {
        var randomList = new List<GenericCountryInfrastructure>();
        //var news = GenericCountryInfrastructure;
        //andomList.Add(.airport);

        return randomList;
    }
    public long SetMarketRate(SectorManager.MarketFreedom marketFreedom, CountryGovernment cityInGovernment, long budgetValue)
    {
        switch (marketFreedom)
        {
            case SectorManager.MarketFreedom.NoMarket:
            case SectorManager.MarketFreedom.FreeInternationalMarket:
            case SectorManager.MarketFreedom.FreeRegionMarket:
            case SectorManager.MarketFreedom.EmergingMarket:
            case SectorManager.MarketFreedom.GovernmentRegulatedMarket:
            case SectorManager.MarketFreedom.PublicPrivateControlled:
            case SectorManager.MarketFreedom.StateControlled:
            case SectorManager.MarketFreedom.IllegalMonopoly:
            case SectorManager.MarketFreedom.Monopoly:
            default:
                return budgetValue;
        }
    }

    /// <summary>
    /// this gets the budget funding for a market sector, basic the money the government uses a subity for the industry, the government backstops profit losses and min income from the 
    /// sector based on the public funding, ie they are there own customer so Aerospace Public Funding is 500M, the Industry generates 1.5B in profits, the first 500M isn't actually profit
    /// so it wont be counte as income, the 1B will be taxed and produce income for the state, the benefit of Public is to gurantee against lose, if the 500M and the industrial collapses
    /// and loses 1.5B dollars the government absorbs the first 500M of the lost so it is only 1B dollars now if the states Public budget is 500M and they industry only does 300M in profit
    /// then there is no negative impact and the funding is reallocated into the next quarters budget as a surplus
    /// </summary>
    /// <param name="sector"></param>
    /// <param name="marketFreedom"></param>
    /// <param name="cityInGovernment"></param>
    /// <param name="budget"></param>
    /// <returns></returns>
    public long SetSectorPublicBudget(SectorManager.Sectors sector, SectorManager.MarketFreedom marketFreedom, CountryGovernment cityInGovernment, CountryBudget budget)
    {
        switch (sector)
        {
            case SectorManager.Sectors.Aerospace:
                SetMarketRate(marketFreedom, cityInGovernment, budget.CountryExpenses.Aerospace);
                break;
            case SectorManager.Sectors.Banking:
                SetMarketRate(marketFreedom, cityInGovernment, budget.CountryFixedExpenses.DebtPayment);
                break;
            case SectorManager.Sectors.Insurance:
                SetMarketRate(marketFreedom, cityInGovernment, budget.CountryFixedExpenses.DebtPayment);
                break;
            case SectorManager.Sectors.ConsumerGoods:
                SetMarketRate(marketFreedom, cityInGovernment, budget.CountryExpenses.Commerce);
                break;
            case SectorManager.Sectors.Defense:
                SetMarketRate(marketFreedom, cityInGovernment, budget.CountryFixedExpenses.SecurityMilitary);
                break;
            case SectorManager.Sectors.Energy:
                SetMarketRate(marketFreedom, cityInGovernment, budget.CountryExpenses.Energy);
                break;
            case SectorManager.Sectors.Manufacturing:
                SetMarketRate(marketFreedom, cityInGovernment, budget.CountryFixedExpenses.UnitProduction);
                break;
            case SectorManager.Sectors.Mining:
                SetMarketRate(marketFreedom, cityInGovernment, budget.CountryExpenses.InfrastructureConstruction);
                break;
            case SectorManager.Sectors.Pharma:
                SetMarketRate(marketFreedom, cityInGovernment, budget.CountryExpenses.HealthCare);
                break;
            case SectorManager.Sectors.RealEstate:
                SetMarketRate(marketFreedom, cityInGovernment, budget.CountryFixedExpenses.UnitProduction);
                break;
            case SectorManager.Sectors.Health:
                SetMarketRate(marketFreedom, cityInGovernment, budget.CountryExpenses.HealthCare);
                break;
            case SectorManager.Sectors.Tourism:
                SetMarketRate(marketFreedom, cityInGovernment, budget.CountryExpenses.Tourism);
                break;
            case SectorManager.Sectors.Telecom:
                SetMarketRate(marketFreedom, cityInGovernment, budget.CountryExpenses.Telecom);
                break;
            case SectorManager.Sectors.Technology:
                SetMarketRate(marketFreedom, cityInGovernment, budget.CountryExpenses.Research);
                break;
            case SectorManager.Sectors.Transport:
                SetMarketRate(marketFreedom, cityInGovernment, budget.CountryFixedExpenses.InfrastructureMainance);
                break;
            case SectorManager.Sectors.Agriculture:
                SetMarketRate(marketFreedom, cityInGovernment, budget.CountryExpenses.Agriculture);
                break;
            default:
                return 0;
        }
        return 0;
    }

    public float DetermineWaterSupply(int popluation, CountryGovernment cityInGovernment, GenericProvince province)
    {
        return 0;
    }

    /// <summary>
    /// draft v1 of teror index
    /// </summary>
    /// <param name="population"></param>
    /// <param name="cityType"></param>
    /// <param name="cityInGovernment"></param>
    /// <param name="province"></param>
    /// <param name="cityData"></param>
    /// <returns></returns>
    public int DetermineBaseTerrorIndex(int population, CityType cityType, CountryGovernment cityInGovernment, GenericProvince province, CityData cityData = null)
    {
        float baseTerrorIndex = 0;
        switch (cityType)
        {
            case CityType.Remote:
            case CityType.Hamlet:
                baseTerrorIndex = 0;
                break;
            case CityType.SmallVillage:
            case CityType.Village:
            case CityType.SmallTown:
            case CityType.SmallTownEuropean:
            case CityType.SmallTownAmericas:
            case CityType.SmallTownAsia:
                baseTerrorIndex = 0;
                break;
            case CityType.SmallTownAfrica:
                baseTerrorIndex = 2;
                break;
            case CityType.SmallTownMiddleEastern:
                baseTerrorIndex = 2;
                break;
            case CityType.Town:
                baseTerrorIndex = 0;
                break;
            case CityType.SmallCity:
            case CityType.City:
            case CityType.LargeCity:
                baseTerrorIndex = 2;
                break;
            case CityType.Metropolis:
            case CityType.RegionalCaptial:
            case CityType.GovernmentCaptial:
            case CityType.MegaCity:
                baseTerrorIndex = 5;
                break;
            default:
                break;
        }

        if (cityData)
        {
            IEnumerable<InfrastructureEffect> attributes = cityData.cityInfrastructure.SelectMany(x => x.Effect).Where(x => x.Effect == EffectOnStateProvinceOrCity.CityTerrorLevel);
            baseTerrorIndex += (int)attributes.Sum(g => g.EffectRate);
        }
        else
        {

            //are there any rebel groups?
            if (province.LocalRebelGroups != null && province.LocalRebelGroups.Any())
            {
                //if the rebels control more then 50% of province the terror level is going to be way high
                if (province.ProvinceRebelControl > 50f)
                {
                    //are there training camps?
                    baseTerrorIndex += province.RebelCamps ? 50f : 0f;
                }
                else
                {
                    //for each rebel group in the province increases terror level 5%
                    baseTerrorIndex += (province.LocalRebelGroups.Count() * 0.02f);
                }
            }
            //are there any terrorist groups?
            if (province.LocalTerroristGroups != null && province.LocalTerroristGroups.Any())
            {
                //are there training camps?
                baseTerrorIndex += province.TerroristCamps ? 50f : 0f;
                //for each terror group in the province increases terror level 5%
                baseTerrorIndex += (province.LocalTerroristGroups.Count() * 0.02f);
            }

            //PopulationTrustLevel level low population doesnt trust the government allows for
            if (cityInGovernment.PopulationTrustLevel <= 5f)
            {
                baseTerrorIndex += 2f;
            }

            //is government a IsRebelGroup or TerrorGroup then it it be very high
            if (cityInGovernment.IsRebelGroup || cityInGovernment.IsTerroristGroup)
            {
                baseTerrorIndex += 12f;
            }

            //high GNI and HDI
            if (cityInGovernment.HDI > 0.5f)
            {
                baseTerrorIndex += 0.5f;
            }
            if (cityInGovernment.Gini > 0.5f)
            {
                baseTerrorIndex += 0.25f;
            }

            //ubranization
            if (cityInGovernment.UrbanizationRate > 0.4f)
            {
                if (cityInGovernment.UrbanizationRate > 0.6f)
                {
                    if (cityInGovernment.UrbanizationRate > 0.7f)
                    {
                        baseTerrorIndex += 0.25f;
                    }
                    baseTerrorIndex += 0.25f;
                }
                baseTerrorIndex += 0.25f;
            }

            //OpenBorderImmigration
            if (cityInGovernment.OpenBorderEmmigration)
            {
                baseTerrorIndex += 0.25f;

            }

            //whats the SoftPowerScore lows this index
            if (cityInGovernment.SoftPowerScore > 30)
            {
                baseTerrorIndex -= 10f;

            }

            //CountryFreedomIndex CountryFlaws
            switch (cityInGovernment.CountryFreedomIndex)
            {
                case Assets.CountryRelationsFactory.CountryFreedomIndex.FullDemocracy:
                    baseTerrorIndex -= 20f;
                    break;
                case Assets.CountryRelationsFactory.CountryFreedomIndex.FlawedDemocracy:
                    baseTerrorIndex -= 15f;
                    break;
                case Assets.CountryRelationsFactory.CountryFreedomIndex.HybridRegime:
                    baseTerrorIndex -= 1f;
                    break;
                case Assets.CountryRelationsFactory.CountryFreedomIndex.Authoritarian:
                    baseTerrorIndex += 5f;
                    break;
            }

            if (cityInGovernment.CountryFlaws.Any(flaw =>
             (flaw == Assets.CountryRelationsFactory.CountryFlawSkill.Terrorism) ||
             (flaw == Assets.CountryRelationsFactory.CountryFlawSkill.NarcoState) ||
             (flaw == Assets.CountryRelationsFactory.CountryFlawSkill.HighCrime) ||
             (flaw == Assets.CountryRelationsFactory.CountryFlawSkill.LocalRebels))
                )
            {
                baseTerrorIndex += 5f;
            }
            //CountrPerks
            if (cityInGovernment.CountrPerks.Any(perk =>
                 (perk == Assets.CountryRelationsFactory.CountryPerkSkill.CounterTerrorismExperts) ||
                 (perk == Assets.CountryRelationsFactory.CountryPerkSkill.PunchAboveWeight) ||
                 (perk == Assets.CountryRelationsFactory.CountryPerkSkill.Superpower)
                 ))
            {
                baseTerrorIndex -= 5f;
            }
            //GovernmnetBias

            switch (cityInGovernment.GovernmnetBias)
            {
                case Assets.CountryRelationsFactory.CountryBias.westerndemocracy:
                case Assets.CountryRelationsFactory.CountryBias.europeandemocracy:
                case Assets.CountryRelationsFactory.CountryBias.europeansocialdemocracy:
                    baseTerrorIndex -= 10f;
                    break;
                case Assets.CountryRelationsFactory.CountryBias.formersoviet:
                case Assets.CountryRelationsFactory.CountryBias.formersovietAuthoratian:
                case Assets.CountryRelationsFactory.CountryBias.formereuro:
                case Assets.CountryRelationsFactory.CountryBias.formercommonwealth:
                    baseTerrorIndex -= 5f;
                    break;
                case Assets.CountryRelationsFactory.CountryBias.africanstable:
                    baseTerrorIndex += 2f;
                    break;
                case Assets.CountryRelationsFactory.CountryBias.africaninstable:
                    baseTerrorIndex += 5f;
                    break;
                case Assets.CountryRelationsFactory.CountryBias.notchinaAsian:
                    baseTerrorIndex += 3f;
                    break;
                case Assets.CountryRelationsFactory.CountryBias.chinaAndAllies:
                case Assets.CountryRelationsFactory.CountryBias.russiaAndAllies:
                case Assets.CountryRelationsFactory.CountryBias.islamStable:
                    baseTerrorIndex += 5f;
                    break;
                case Assets.CountryRelationsFactory.CountryBias.islamInstable:
                    baseTerrorIndex += 15f;
                    break;
                case Assets.CountryRelationsFactory.CountryBias.southamericandemocracy:
                    baseTerrorIndex += 2f;
                    break;
                case Assets.CountryRelationsFactory.CountryBias.southamericansocialist:
                    baseTerrorIndex += 5f;
                    break;
                case Assets.CountryRelationsFactory.CountryBias.superpower:
                    baseTerrorIndex += 5f;
                    break;
                case Assets.CountryRelationsFactory.CountryBias.regionalpower:
                    baseTerrorIndex += 5f;
                    break;
                case Assets.CountryRelationsFactory.CountryBias.citystateisland:
                    baseTerrorIndex -= 15f;
                    break;
                case Assets.CountryRelationsFactory.CountryBias.civilwar:
                    baseTerrorIndex += 5f;
                    break;
                default:
                    break;
            }
            switch (cityInGovernment.GovernmentType)
            {
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.AbsoluteMonarchy:
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.Anarchy:
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.Authoritarian:
                    baseTerrorIndex += 5f;
                    break;
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.NonGoverningOverseas:
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.Ecclesiastical:
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.Commonwealth:
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.Communist:
                    baseTerrorIndex -= 15f;
                    break;
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.ParliamentaryConstitutionalMonarchy:
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.Socialism:
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.Confederacy:
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.Constitutional:
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.ConstitutionalDemocracy:
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.ConstitutionalMonarchy:
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.Democracy:
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.DemocraticRepublic:
                    baseTerrorIndex -= 5f;
                    break;
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.PresidentialAuthoritarian:
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.Theocracy:
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.AuthoritarianDemocracy:
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.Totalitarian:
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.Sultanate:
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.Oligarchy:
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.Dictatorship:
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic:
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.Monarchy:
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.Emirate:
                    baseTerrorIndex += 5f;
                    break;
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.Republic:
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.Federal:
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.FederalRepublic:
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.ParliamentaryDemocracy:
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.ParliamentaryGovernment:
                    baseTerrorIndex -= 10f;
                    break;
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.MilitaryJunta:
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.Presidential:
                    break;
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.SpecialAdministrativeRegion:
                case Assets.CountryRelationsFactory.CountryGovernmentTypes.NoGovernmentInPower:
                    baseTerrorIndex += 30f;
                    break;
            }
            //is government in control?
            baseTerrorIndex += cityInGovernment.IsInTotalControlOfCountry ? -0.5f : 0;
        }

        return (int)baseTerrorIndex;
    }

    public float DetermineBaseCrimeRate(long population, CityType cityType, CountryGovernment cityInGovernment, Province province)
    {

        var baseCrimeRate = 0.03f;
        //base rates
        //0.25% crime the highest starting rate
        //0.20% hight then if the GINDI and HDI are inverted
        ///    DrugProblems = 0,
        ////LandLocked,
        ////    ClimateVunerable,
        ////    ClimateHeat,
        ////    ClimateFlooding,
        ////    Overpopulated,
        ////    Underpopulated,
        ////    HeavyNationalDebt,
        ////    DemographicTensions,
        ////    PoliticalTensions,
        ////    CountryResourceDependant,
        ////    Overconsumption,
        ////    AgingPopulation,
        ////    LowInformationVoters,
        ////    WaterVunerable,
        //cityInGovernment.HDI
        // 23.2 victimizations per 1,000 persons 


        if (cityInGovernment.CountryFlaws.Any(e => (e == Assets.CountryRelationsFactory.CountryFlawSkill.DrugProblems || e == Assets.CountryRelationsFactory.CountryFlawSkill.HighCrime)))
        {
            baseCrimeRate += 0.05f;
        }
        //human develip sucks then there more crime
        if (cityInGovernment.HDI > 0.05f)
        {
            baseCrimeRate += 0.05f;
            if (cityInGovernment.HDI > 0.02f)
            {
                baseCrimeRate += 0.05f;
            }

        }
        switch (cityType)
        {
            case CityType.Remote:
            case CityType.Hamlet:
            case CityType.SmallVillage:
            case CityType.Village:
                baseCrimeRate += ((population / 1000) / 1.4f) / 1000;
                break;
            case CityType.SmallTown:
            case CityType.SmallTownEuropean:
            case CityType.SmallTownAmericas:
            case CityType.SmallTownAsia:
                baseCrimeRate += ((population / 1000) / 1f) / 1000;
                break;
            case CityType.SmallTownAfrica:
            case CityType.SmallTownMiddleEastern:
                baseCrimeRate += ((population / 1000) / 3f) / 1000;
                break;
            case CityType.Town:
                baseCrimeRate += ((population / 1000) / 6f) / 1000;
                break;
            case CityType.SmallCity:
            case CityType.City:
                baseCrimeRate += ((population / 1000) / 9f) / 1000;
                break;
            case CityType.LargeCity:
            case CityType.Metropolis:
            case CityType.RegionalCaptial:
            case CityType.GovernmentCaptial:
            case CityType.MegaCity:
                baseCrimeRate += ((population / 1000) / 12f) / 1000;
                break;
        }
        return baseCrimeRate;
    }


    public float DeterminePropertyValue(long population, CityType cityType, CountryGovernment cityInGovernment, Province province)
    {
        return 100;
    }

    [Serializable]
    public class GenericCity
    {
        public int index;
        public string name;
        public string provinceName;
        public long population;
        public Vector2 location;
        public bool isCapital;
        public int CityTerrorLevel;
        public int CityCrimeIndex;
        public int CityEconomicIndex;
        public int CityPropertyValue;
        public int CityResearchIndex;
        public int CityTradeValue;
        [Range(-100.0f, 100.0f)]
        public float CityControl;
        [Range(-100.0f, 100.0f)]
        public float CityRebelControl;
        public bool IsInPanic;
        public bool IsTerrorAttack;
        public bool IsNaturalDisater;
        public bool IsUnderQuarintine;
        public bool IsUnderStateOfEmergency;
        public bool IsUnderMarshalLaw;
        public bool IsUnderNoFlyZone;
        public bool IsUnderRebelControl;
        public bool IsBlackoutPowerLost;
        public bool IsStreetRiots;
        public Texture2D flagowner = null;
        public Texture2D CityTypeIcon;
        public CityType CityType;
        public DevelopmentTier CityDevelopmentTier;
        public List<Tuple<SectorManager.Sectors, long>> ProductionSectors;
        public List<GenericCountryInfrastructure> cityInfrastructure;
        public bool isRegionalCaptial;
    }

    /// <summary>
    /// int FilesProcessed = 42;
    //int TotalFilesToProcess = 153;
    // int TotalProgress = FilesProcessed * 100 / TotalFilesToProcess;
    /// </summary>
    /// <param name="city"></param>
    /// <param name="cityInGovernment"></param>
    /// <param name="province"></param>
    /// <returns></returns>
    public GenericCity RandomGenericCity(City city, CountryGovernment cityInGovernment, Province province, WMSK map)
    {
        var type = GetCityType(city, province, cityInGovernment, map);

        int totalCrimeIndex = (int)((double)DetermineBaseCrimeRate(city.population, type, cityInGovernment, province) * 100);
        int totalCityEconmicIndex = 100; //determined by the resources and trade deals infrastcutre which increases this activity
        int totalCityPropertyValue = (int)(double)DeterminePropertyValue(city.population, type, cityInGovernment, province); ; //determined by the populations ubraization rate, and resources
        int totalCityRebelControl = 0; //determine by the rule of law and the crime rate
        int totalCityResearchIndex = 100; //determined by the province infrastructure and city infrasture and 
        //cal based on infrasturue or size
        int totalCityTerrorLevel = 0;

        //(int)((double)DetermineBaseTerrorIndex(city.population, type, cityInGovernment, province) * 100);
        int totalCityTradeValue = 100;
        var sec = GenerateRandomSectors(cityInGovernment);

        var iscap = (city.cityClass == CITY_CLASS.COUNTRY_CAPITAL);
        var isregioncap = (city.cityClass == CITY_CLASS.REGION_CAPITAL);

        return new GenericCity()
        {
            index = city.uniqueId,
            CityControl = 100,
            CityCrimeIndex = totalCrimeIndex,
            CityEconomicIndex = totalCityEconmicIndex,
            cityInfrastructure = RandomList(),
            CityPropertyValue = totalCityPropertyValue,
            CityRebelControl = totalCityRebelControl,
            CityResearchIndex = totalCityResearchIndex,
            CityTerrorLevel = totalCityTerrorLevel,
            CityTradeValue = totalCityTradeValue,
            isCapital = iscap,
            isRegionalCaptial = isregioncap,
            location = city.unity2DLocation,
            name = city.name,
            CityType = type,
            population = city.population,
            ProductionSectors = sec,
            provinceName = province.name
        };
    }

    public GenericCity GenericCityFromData(CityData data = null)
    {
        if (data == null)
        {

            return new GenericCity();
        }
        else
        {
            return new GenericCity()
            {
                index = data.index,
                CityControl = data.CityControl,
                CityCrimeIndex = data.CityCrimeIndex,
                CityEconomicIndex = data.CityEconomicIndex,
                CityPropertyValue = data.CityPropertyValue,
                CityRebelControl = data.CityRebelControl,
                CityResearchIndex = data.CityResearchIndex,
                CityTerrorLevel = data.CityTerrorLevel,
                CityTradeValue = data.CityTradeValue,
                isCapital = data.isCapital,
                location = data.location,
                name = data.name,
                CityType = data.CityType,
                population = data.population,
                ProductionSectors = data.ProductionSectors,
                provinceName = data.provinceName
            };
        }

    }


    public GenericProvince RandomProvince(IEnumerable<City> provinceCities, Province province, CountryGovernment gov)
    {
        var provincePopulation = provinceCities.Select(e => e.population).Sum();
        var ruralPopulation = (int)(provincePopulation * (gov.UrbanPopulationRate - 100f) / 100);

        provincePopulation = provincePopulation + ruralPopulation;
        var listOfCities = new List<GenericCity>();
        provinceCities.ToList().ForEach(city => { listOfCities.Add(RandomGenericCity(city, gov, province, WMSK.instance)); });
        return new GenericProvince(province.name)
        {
            ProvinceCities = listOfCities,
            countryIndex = gov.CountryOfGovernment.index,
            ElectricitySupplyIndex = gov.HDI * 100,
            flagowner = gov.CountryFlag,
            FoodSUpplyIndex = 100,
            index = province.uniqueId,
            InternetAccessIndex = 100,
            IsUprising = false,
            LocalRebelGroups = new List<RebelGroup>(),
            LocalTerroristGroups = new List<TerroristGroup>(),
            location = province.center,
            MedicalCareIndex = 100,
            name = province.name,
            population = provincePopulation,
            ProductionSectors = null,
            ProvinceControl = 100,
            provinceCulturalValue = 100,
            ProvinceDeomgraphicGroups = gov.DemographicGroups.Select(e => e.Population).ToList(),
            provinceEconomicDevelopment = 100,
            provinceHumanSecurity = 100,
            ProvincePoliticalParties = gov.PoliticalParties.Select(e => e.PowerPercent).ToList(),
            ProvinceRebelControl = 0,
            provinceInfrastructure = new List<GenericCountryInfrastructure>(),
            provinceRuleOfLaw = 100,
            provinceTaxRate = 6f,
            RebelCamps = false,
            SantiationIndex = 100,
            TerroristCamps = false,
            UprisingStarted = false,
            UprsiningEnded = true,
            WaterSupplyIndex = 100,
            urbanRate = gov.UrbanizationRate


        };
    }

    public enum EffectOnStateProvinceOrCity
    {
        CityTerrorLevel,
        CityCrimeIndex,
        CityEconomicIndex,
        CityPropertyValue,
        CityResearchIndex,
        CityTradeValue,
        urbanRate,
        provinceTaxRate,
        provinceRuleOfLaw,
        provinceCulturalValue,
        provinceHumanSecurity,
        provinceEconomicDevelopment,
        SantiationIndex,
        WaterSupplyIndex,
        FoodSUpplyIndex,
        MedicalCareIndex,
        ElectricitySupplyIndex,
        InternetAccessIndex,
        NaturalDisasterBuffer,
        NationalSecurity,
        RebelIndex
    }

    [Serializable]
    public class InfrastructureEffect
    {
        public EffectOnStateProvinceOrCity Effect;
        [Range(-100.0f, 100.0f)]
        public float EffectRate;

    }



    [Serializable]
    public class GenericCountryInfrastructure : ScriptableObject
    {
        public int index;
        public string DisplayName;
        public string DisplayDescription;
        public MapLevelType mapType;
        public countryInfrastructure type;
        public bool IsCritical;
        public bool IsOnline;
        public bool IsDamaged;
        public bool IsDestroyed;
        public bool IsUnderConstruction;
        public bool IsUnderRepair;
        public bool IsStateControlled;
        public long FundingCost;
        public long ConstructionCost;
        public int ConstructionTimeInDays;
        public DevelopmentTier RequiredDevelopmentTier;
        public Vector2 location;
        public Texture2D icon;
        public Texture2D marker;
        public GameObject model;
        public List<SectorManager.CountryResource> ProducesResource;
        public List<SectorManager.CountryResource> ConsumesResource;
        public Assets.CountryRelationsFactory.CountryMinstries responsibleMinstry;
        public List<InfrastructureEffect> Effect;

    }


    public enum countryInfrastructure
    {
        [Description("Chemical Manfacturing site")]
        chemical,
        /// <summary>
        /// Entertainment and Media (e.g., motion picture studios, broadcast media).
        //        Gaming (e.g., casinos).
        //Lodging(e.g., hotels, motels, conference centers).
        //Outdoor Events(e.g., theme and amusement parks, fairs, campgrounds, parades).
        //Public Assembly(e.g., arenas, stadiums, aquariums, zoos, museums, convention centers).
        //Real Estate(e.g., office and apartment buildings, condominiums, mixed use facilities, self-storage).
        //Retail(e.g., retail centers and districts, shopping malls).
        //Sports Leagues(e.g., professional sports leagues and federations).
        /// </summary>
        commerical,
        communications,
        criticalmanufacturing,
        dams,
        defense,
        emergency,
        police,
        foodArgo,
        governmentSites,
        healthcareSites,
        dataCenters,
        researchAndDevelop,
        nuclearSites,
        transportation,
        waterSystem,
        subway,
        railways,
        airport,
        seaport,
        oilproduction,
        powerstation,
        officeComplexes,
        schools,
        unveristy,
        gamingCasino,
        hotelTourist,
        conventionCenter,
        amusementPark,
        nationalPark,
        stadium,
        largestadium,
        zooOrAquarium,
        shoppingMall,
        factory,
        local,
        education,
        terror,
        rebel,
        nationalsecurity,
        cityServices


    }
    public enum countryPropery
    {

        FreezeAssets,
        TravelBan,
        Inspections,
        Dumping,
        Subsides,
        EnforceLincenses,
        CommericalBan
    }
    public enum provinceProperty
    {
        ruleoflaw,
        humansecurity,
        culturalvalue,
        economicActivity,
        internet,
        electrcity,
        medical,
        food,
        water,
        sanitation,
        MartialLaw,
        StateOfEmergency,
        Quarantine

    }
    [Serializable]
    public class GenericProvince
    {
        public GenericProvince(string provinceName)
        {


            var localMap = WMSK.instance;

            name = provinceName;


        }
        public int index;
        public string name;
        public int countryIndex;
        public long population;
        [Range(0f, 100.0f)]
        public float urbanRate;
        [Range(0f, 100.0f)]
        public float provinceTaxRate = 5f;
        [Range(0f, 100.0f)]
        public float provinceRuleOfLaw;
        [Range(0f, 100.0f)]
        public float provinceCulturalValue;
        [Range(0f, 100.0f)]
        public float provinceHumanSecurity;
        [Range(0f, 100.0f)]
        public float provinceEconomicDevelopment;
        [Range(0f, 100.0f)]
        public float SantiationIndex;
        [Range(0f, 100.0f)]
        public float WaterSupplyIndex;
        [Range(0f, 100.0f)]
        public float FoodSUpplyIndex;
        [Range(0f, 100.0f)]
        public float MedicalCareIndex;
        [Range(0f, 100.0f)]
        public float ElectricitySupplyIndex;
        [Range(0f, 100.0f)]
        public float InternetAccessIndex;

        public Vector2 location;
        [Range(-100.0f, 100.0f)]
        public float ProvinceControl;
        [Range(-100.0f, 100.0f)]
        public float ProvinceRebelControl;
        public Tuple<SectorManager.Sectors, long> ProductionSectors;
        public Tuple<SectorManager.Resources, long> ProvinceResources;
        public Vector2 regionCaptialLocation;
        public Texture2D flagowner;
        public List<GenericCountryInfrastructure> provinceInfrastructure;
        public List<RebelGroup> LocalRebelGroups;
        public bool RebelCamps;
        public List<TerroristGroup> LocalTerroristGroups;
        public bool TerroristCamps;
        public List<GenericCity> ProvinceCities;
        [Range(0.0f, 100.0f)]
        public List<float> ProvincePoliticalParties;
        [Range(0.0f, 100.0f)]
        public List<float> ProvinceDeomgraphicGroups;


        public bool IsUprising;
        public bool UprisingStarted;
        public bool UprsiningEnded;
        public UprisingEvent StartUpRisingEvent(GenericProvince uprisingProvince, PoliticalParties partyToNewUprisingGroup)
        {
            return new UprisingEvent();
        }
        public UprisingEvent StartUpRisingEvent(GenericProvince uprisingProvince, DemographicGroups partyToNewUprisingGroup)
        {
            return new UprisingEvent();
        }
    }

    public WPM.WorldMapGlobe _WPM = WPM.WorldMapGlobe.instance;
    public WorldMapStrategyKit.WMSK _WMSK = WorldMapStrategyKit.WMSK.instance;


    public WorldMapStrategyKit.Country GenericToMapCountry(WPM.Country country)
    {
        return _WMSK.GetCountry(_WMSK.GetCountryIndex(country.name));
    }

    public WPM.Country GenericToMapCountry(GenericCountry country)
    {
        return _WPM.GetCountry(_WMSK.GetCountryIndex(country.name));
    }

    public WorldMapStrategyKit.Country ToCountry(WPM.Country country)
    {
        CopyAtoB(country, Country, string.Empty, new BindingFlags());
        return Country;
    }
    public WPM.Country ToGlobalCountry(WorldMapStrategyKit.Country country)
    {
        CopyAtoB(country, GlobalCountry, string.Empty, new BindingFlags());
        return GlobalCountry;
    }


    public GenericCountry GetGenericFromCountry(WorldMapStrategyKit.Country country)
    {
        return new GenericCountry()
        {
            name = country.name,
            index = country.uniqueId,
            regionName = country.continent
        };
    }
    private WorldMapStrategyKit.Country Country;
    private WPM.Country GlobalCountry;

    public void CopyAtoB(WPM.Country target, WorldMapStrategyKit.Country source, string excludedProperties, BindingFlags memberAccess)
    {
        string[] excluded = null;
        if (!string.IsNullOrEmpty(excludedProperties))
            excluded = excludedProperties.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);

        MemberInfo[] miT = target.GetType().GetMembers(memberAccess);
        foreach (MemberInfo Field in miT)
        {
            string name = Field.Name;

            // Skip over any property exceptions
            if (!string.IsNullOrEmpty(excludedProperties) &&
                excluded.Contains(name))
                continue;

            if (Field.MemberType == MemberTypes.Field)
            {
                FieldInfo SourceField = source.GetType().GetField(name);
                if (SourceField == null)
                    continue;

                object SourceValue = SourceField.GetValue(source);
                ((FieldInfo)Field).SetValue(target, SourceValue);
            }
            else if (Field.MemberType == MemberTypes.Property)
            {
                PropertyInfo piTarget = Field as PropertyInfo;
                PropertyInfo SourceField = source.GetType().GetProperty(name, memberAccess);
                if (SourceField == null)
                    continue;

                if (piTarget.CanWrite && SourceField.CanRead)
                {
                    object SourceValue = SourceField.GetValue(source, null);
                    piTarget.SetValue(target, SourceValue, null);
                }
            }
        }

    }
    public void CopyAtoB(WorldMapStrategyKit.Country source, WPM.Country target, string excludedProperties, BindingFlags memberAccess)
    {
        string[] excluded = null;
        if (!string.IsNullOrEmpty(excludedProperties))
            excluded = excludedProperties.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);

        MemberInfo[] miT = target.GetType().GetMembers(memberAccess);
        foreach (MemberInfo Field in miT)
        {
            string name = Field.Name;

            // Skip over any property exceptions
            if (!string.IsNullOrEmpty(excludedProperties) &&
                excluded.Contains(name))
                continue;

            if (Field.MemberType == MemberTypes.Field)
            {
                FieldInfo SourceField = source.GetType().GetField(name);
                if (SourceField == null)
                    continue;

                object SourceValue = SourceField.GetValue(source);
                ((FieldInfo)Field).SetValue(target, SourceValue);
            }
            else if (Field.MemberType == MemberTypes.Property)
            {
                PropertyInfo piTarget = Field as PropertyInfo;
                PropertyInfo SourceField = source.GetType().GetProperty(name, memberAccess);
                if (SourceField == null)
                    continue;

                if (piTarget.CanWrite && SourceField.CanRead)
                {
                    object SourceValue = SourceField.GetValue(source, null);
                    piTarget.SetValue(target, SourceValue, null);
                }
            }
        }

    }
}
