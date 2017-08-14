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
    }

    [Serializable]
    public class GenericCity
    {

        public GenericCity(CityData data)
        {
            new GenericCity(data)
            {
                index = data.index,
                CityControl = data.CityControl,
                CityCrimeIndex = data.CityCrimeIndex,
                CityEconmicIndex = data.CityEconomicIndex,
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
        public int index;
        public string name;
        public string provinceName;
        public long population;
        public Vector2 location;
        public bool isCapital;
        public int CityTerrorLevel;
        public int CityCrimeIndex;
        public int CityEconmicIndex;
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
        public Texture2D flagowner;
        public CityType CityType;
        public Tuple<SectorManager.Sectors, long> ProductionSectors;
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


    public enum countryInfrastructure {
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
    public enum countryPropery {

        FreezeAssets,
        TravelBan,
        Inspections,
        Dumping,
        Subsides,
        EnforceLincenses,
        CommericalBan
    }
    public enum provinceProperty {
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
        public GenericProvince(string provinceName) {


            var localMap = WMSK.instance;

            name = provinceName;

            
        }
        public int index;
        public string name;
        public int countryIndex;
        public Vector2 location;
        [Range(-100.0f, 100.0f)]
        public float ProvinceControl;
        [Range(-100.0f, 100.0f)]
        public float ProvinceRebelControl;
        public Tuple<SectorManager.Sectors, long> ProductionSectors;
        public Vector2 regionCaptialLocation;
        public Texture2D flagowner;
        public List<GenericCountryInfrastructure> provinceInfrastructure;
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


    public GenericCountry GetGenericFromCountry(WorldMapStrategyKit.Country country) {
        return new GenericCountry() {
            name = country.name,
            index =country.uniqueId,
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
