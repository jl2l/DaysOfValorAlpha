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

    public CityType GetCityType(City city)
    {
        if (city.population > 1000000)
        {
            return CityType.MegaCity;
        }
        else if (city.population > 500000)
        {
            return CityType.LargeCity;
        }
        else if (city.population > 500000)
        {
            return CityType.LargeCity;
        }
        else if (city.population > 500000)
        {
            return CityType.LargeCity;
        }
        else if (city.population > 500000)
        {
            return CityType.LargeCity;
        }
        else if (city.population > 500000)
        {
            return CityType.LargeCity;
        }
        else if (city.population > 500000)
        {
            return CityType.LargeCity;
        }
        else if (city.population > 500000)
        {
            return CityType.LargeCity;
        }
        else if (city.population > 500000)
        {
            return CityType.LargeCity;
        }
        else if (city.population > 500000)
        {
            return CityType.LargeCity;
        }
        return CityType.City;
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

    public List<countryInfrastructure> RandomList()
    {
        var randomList = new List<countryInfrastructure>();
        randomList.Add(countryInfrastructure.airport);

        return randomList;
    }
    public float DetermineBaseCrimeRate(int popluation, CountryGovernment cityInGovernment)
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

        return baseCrimeRate;
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
    public GenericCity RandomGenericCity(City city, CountryGovernment cityInGovernment, GenericProvince province)
    {

        int totalCrimeIndex = (int)((double)DetermineBaseCrimeRate(city.population, cityInGovernment) * 100);
        int totalCityEconmicIndex = (int)((double)DetermineBaseCrimeRate(city.population, cityInGovernment) * 100);
        int totalCityInfrastructure = (int)((double)DetermineBaseCrimeRate(city.population, cityInGovernment) * 100);
        int totalCityPropertyValue = (int)((double)DetermineBaseCrimeRate(city.population, cityInGovernment) * 100);
        int totalCityRebelControl = (int)((double)DetermineBaseCrimeRate(city.population, cityInGovernment) * 100);
        int totalCityResearchIndex = (int)((double)DetermineBaseCrimeRate(city.population, cityInGovernment) * 100);
        int totalCityTerrorLevel = (int)((double)DetermineBaseCrimeRate(city.population, cityInGovernment) * 100);
        int totalCityTradeValue = (int)((double)DetermineBaseCrimeRate(city.population, cityInGovernment) * 100);
        var sec = GenerateRandomSectors(cityInGovernment);
        var type = GetCityType(city);
        var iscap = (cityInGovernment.CaptialName == city.name);


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
                cityInfrastructure = data.cityInfrastructure,
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
        public CityType CityType;
        public List<Tuple<SectorManager.Sectors, long>> ProductionSectors;
        public List<countryInfrastructure> cityInfrastructure;
    }

    [Serializable]
    public class GenericCountryInfrastructure : ScriptableObject
    {
        public int index;
        public string DisplayName;
        public countryInfrastructure type;
        public bool IsCritical;
        public float FundingCost;
        public Vector2 location;
        public Texture2D flagowner;
        public Assets.CountryRelationsFactory.CountryMinstries responsibleMinstry;
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
        public float provinceTaxRate = 5f;

        public float provinceRuleOfLaw;
        public float provinceCulturalValue;
        public float provinceHumanSecurity;
        public float provinceEconomicDevelopment;

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
        public List<TerroristGroup> LocalTerroristGroups;
        public List<GenericCity> ProvinceCities;
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
