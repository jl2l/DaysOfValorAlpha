using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using WorldMapStrategyKit;
using System.Linq;

[System.Serializable]
public class CityData : ScriptableObject
{

    public int index;

    [ContextMenuItem("Fill From name", "FilFromName")]
    public string CityName;
    private void FilFromName()
    {
        var map = WMSK.instance;
        var fillCity = map.cities.FirstOrDefault(e => e.name.ToLower().Contains(CityName.ToLower()));
        index = fillCity.uniqueId;
        population = fillCity.population;
        provinceName = fillCity.province;
        isCapital = (fillCity.cityClass == CITY_CLASS.COUNTRY_CAPITAL);
        isRegionCapital = (fillCity.cityClass == CITY_CLASS.REGION_CAPITAL);
        location = fillCity.unity2DLocation;

    }
    public string provinceName;
    public long population;
    public Vector2 location;
    public bool isCapital;
    public bool isRegionCapital;
    [Tooltip("The likeless of a terror attack if these reachs 100 there will be a attack, it will reset after or could repeat")]
    [Range(-100.0f, 100.0f)]
    public int CityTerrorLevel;
    [Tooltip("The level of crime in the city, high crime reduces economic development, and allows rebel groups to form")]
    [Range(-100.0f, 100.0f)]
    public int CityCrimeIndex;
    [Tooltip("The level of economic activity in the city this translates into income for the state, the lower this the less money the city makes for the state")]
    [Range(-100.0f, 100.0f)]
    public int CityEconomicIndex;
    [Tooltip("The a indicator of development inside the city, the higher this value the more the city is expanded and growing both its population and capacity to make more stuff")]
    [Range(-100.0f, 100.0f)]
    public int CityPropertyValue;
    [Tooltip("The a index of research points cities are centers for research, this is the direct net score for research points")]
    [Range(-100.0f, 100.0f)]
    public int CityResearchIndex;
    [Tooltip("The ability of the city to make deals which the state will carry out with other countries")]
    [Range(-100.0f, 100.0f)]
    public int CityTradeValue;
    [Tooltip("The level of control the state has over the city")]
    [Range(0, 100)]
    public int CityControl;
    [Range(0, 100)]
    public int CityRebelControl;
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
    public CityType CityType;
    public Texture2D CityOwnerFlag;
    public Tuple<SectorManager.Sectors, long> ProductionSectors;
    public List<CountryToGlobalCountry.countryInfrastructure> cityInfrastructure;
}
