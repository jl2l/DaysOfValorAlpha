using System.Collections.Generic;
using UnityEngine;

public class CountrySectors : ScriptableObject
{
    public string MarketName;
    public float ProfitGenerated;
    public float TotalShares;
    public string CountryName;
    private float lowrate = 0.0012f;
    private float mildrate = 0.0012f;
    private float highrate = 0.0012f;
    private float veryrate = 0.0012f;
    private float crazyrate = 0.0012f;

    public float Banking;
   
    public float BankingVolatility;

    public CountryToGlobalCountry.countryInfrastructure Supports = CountryToGlobalCountry.countryInfrastructure.commerical;
    public float Technology;
    public Dictionary<string, float> TechnologySubsectoryList;
    public float TechnologyVolatility;
    public float Aerospace;
    public Dictionary<string, float> AerospaceSubsectoryList;
    public float AerospaceVolatility;
    public float Defense;
    public Dictionary<string, float> DefenseSubsectoryList;
    public float DefenseVolatility;

    public float Pharma;
    public Dictionary<string, float> PharmaSubsectoryList;
    public float PharmaVolatility;
    public float ConsumerGoods;
    public Dictionary<string, float> ConsumerGoodsSubsectoryList;
    public float ConsumerGoodsVolatility;

    public float RealEstate;
    public Dictionary<string, float> RealEstateSubsectoryList;
    public float RealEstateVolatility;

    public float Health;
    public Dictionary<string, float> HealthSubsectoryList;
    public float HealthVolatility;

    public float Manufacturing;
    public Dictionary<string, float> ManufacturingSubsectoryList;
    public float ManufacturingVolatility;

    public float Mining;
    public Dictionary<string, float> MiningSubsectoryList;
    public float MiningVolatility;

    public float Tourism;
    public Dictionary<string, float> TourismSubsectoryList;
    public float TourismVolatility;

    public float Telecom;
    public Dictionary<string, float> TelecomSubsectoryList;
    public float TelecomVolatility;

    public float Transport;
    public Dictionary<string, float> TransportSubsectoryList;
    public float TransportVolatility;
    public float Energy;
    public Dictionary<string, float> EnergySubsectoryList;
    public float EnergyVolatility;
}
