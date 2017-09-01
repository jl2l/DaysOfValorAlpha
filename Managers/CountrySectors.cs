using System.Collections.Generic;
using UnityEngine;

public class CountrySectors : ScriptableObject
{

    [ContextMenuItem("Fil From World Map", "AdjustMarkets")]
    public string MarketName;

    private void AdjustMarkets()
    {
        TotalShares = TotalBankingShares +
            TotalAerospaceShares +
            TotalConsumerGoodsShares +
            TotalDefenseShares +
            TotalEnergyShares +
            TotalHealthShares +
            TotalManufacturingShares +
            TotalMiningShares +
            TotalPharmaShares +
            TotalRealEstateShares +
            TotalTechnologyShares +
            TotalTourismShares +
            TotalTransportShares;

        TelecomVolatility = rate(TelecomRates);
        AgricultureVolatility = rate(AgricultureRates);
        AerospaceVolatility = rate(AerospaceRates);
        BankingVolatility = rate(BankingRates);
        ConsumerGoodsVolatility = rate(ConsumerGoodsRates);
        DefenseVolatility = rate(ConsumerGoodsRates);
        PharmaVolatility = rate(ConsumerGoodsRates);
        RealEstateVolatility = rate(ConsumerGoodsRates);
        HealthVolatility = rate(ConsumerGoodsRates);
        ManufacturingVolatility = rate(ConsumerGoodsRates);
        MiningVolatility = rate(ConsumerGoodsRates);
        TourismVolatility = rate(ConsumerGoodsRates);
        TransportVolatility = rate(ConsumerGoodsRates);
        TelecomVolatility = rate(TelecomRates);
        EnergyVolatility = rate(EnergyRates);

    }

    public long TransactionVolumne;

    public float BailoutFund;
    public float ProfitGenerated;
    public float TotalShares;
    public string CountryName;
    public enum marketRates
    {
        crash,
        slowfall,
        flat,
        low,
        mid,
        high,
        very,
        crazy
    }

    public float rate(marketRates rate)
    {
        switch (rate)
        {
            case marketRates.crash:
                return 0.0012f;
            case marketRates.slowfall:
                return 0.0012f;
            case marketRates.low:
                return 0.0012f;
            case marketRates.mid:
                return 0.0012f;
            case marketRates.high:
                return 0.0012f;
            case marketRates.very:
                return 0.0012f;
            case marketRates.crazy:
                return 0.0012f;
            case marketRates.flat:
                return 0.0012f;
            default:
                return 0.0012f;
        }
    }
    private float lowrate = 0.0012f;
    private float mildrate = 0.0012f;
    private float highrate = 0.0012f;
    private float veryrate = 0.0012f;
    private float crazyrate = 0.0012f;
#if UNITY_EDITOR
    [Separator] public Separator s22;
#endif

    public float Agriculture;
    public float AgriculturePublicFund;
    public marketRates AgricultureRates;
    public float TotalAgricultureShares;
    public Dictionary<string, float> AgricultureSubsectoryList;
    public float AgricultureVolatility;
    public SectorManager.MarketFreedom AgricultureSectorFreedom;
#if UNITY_EDITOR
    [Separator] public Separator s1;
#endif
    [Tooltip("the value of the banking share")]
    public float Banking;
    public float BankingPublicFund;
    [Tooltip("the total volumn of shares traded")]
    public float TotalBankingShares;
    public marketRates BankingRates;
    [Tooltip("the rate that the shares appericate in value maket money")]
    public float BankingVolatility;
    public SectorManager.MarketFreedom BankingSectorFreedom;
#if UNITY_EDITOR
    [Separator] public Separator s355;
#endif
    public float Insurance;
    public float InurancePublicFund;
    public marketRates InuranceRates;
    public float TotalInuranceShares;
    public Dictionary<string, float> InsuranceSubsectoryList;
    public float InsuranceVolatility;
    public SectorManager.MarketFreedom InsuranceSectorFreedom;

#if UNITY_EDITOR
    [Separator] public Separator s2;
#endif
    public float Technology;
    public float TechnologyPublicFund;
    public marketRates TechnologyRates;
    public float TotalTechnologyShares;
    public Dictionary<string, float> TechnologySubsectoryList;
    public float TechnologyVolatility;
    public SectorManager.MarketFreedom TechnologySectorFreedom;


#if UNITY_EDITOR
    [Separator] public Separator s3;
#endif
    public float Aerospace;
    public float AerospacePublicFund;
    public marketRates AerospaceRates;
    public float TotalAerospaceShares;
    public Dictionary<string, float> AerospaceSubsectoryList;
    public float AerospaceVolatility;
    public SectorManager.MarketFreedom AerospaceSectorFreedom;

#if UNITY_EDITOR
    [Separator] public Separator s41;
#endif
    public float Defense;
    public float DefensePublicFund;
    public marketRates DefenseRates;
    public float TotalDefenseShares;
    public Dictionary<string, float> DefenseSubsectoryList;
    public float DefenseVolatility;
    public SectorManager.MarketFreedom DefenseSectorFreedom;

#if UNITY_EDITOR
    [Separator] public Separator s5;
#endif
    public float Pharma;
    public float PharmaPublicFund;
    public marketRates PharmaRates;
    public float TotalPharmaShares;
    public Dictionary<string, float> PharmaSubsectoryList;
    public float PharmaVolatility;
    public SectorManager.MarketFreedom PharmaSectorFreedom;

#if UNITY_EDITOR
    [Separator] public Separator s16;
#endif
    public float ConsumerGoods;
    public float ConsumerGoodsPublicFund;
    public marketRates ConsumerGoodsRates;
    public float TotalConsumerGoodsShares;
    public Dictionary<string, float> ConsumerGoodsSubsectoryList;
    public float ConsumerGoodsVolatility;
    public SectorManager.MarketFreedom ConsumerGoodsSectorFreedom;

#if UNITY_EDITOR
    [Separator] public Separator s71;
#endif
    public float RealEstate;
    public float RealEstatePublicFund;
    public marketRates RealEstateRates;
    public float TotalRealEstateShares;
    public Dictionary<string, float> RealEstateSubsectoryList;
    public float RealEstateVolatility;
    public SectorManager.MarketFreedom RealEstateSectorFreedom;

#if UNITY_EDITOR
    [Separator] public Separator s81;
#endif
    public float Health;
    public float HealthPublicFund;
    public marketRates HealthRates;
    public float TotalHealthShares;
    public Dictionary<string, float> HealthSubsectoryList;
    public float HealthVolatility;
    public SectorManager.MarketFreedom HealthSectorFreedom;

#if UNITY_EDITOR
    [Separator] public Separator s19;
#endif
    public float Manufacturing;
    public float ManufacturingPublicFund;
    public marketRates ManufacturingRates;
    public float TotalManufacturingShares;
    public Dictionary<string, float> ManufacturingSubsectoryList;
    public float ManufacturingVolatility;
    public SectorManager.MarketFreedom ManufacturingSectorFreedom;
#if UNITY_EDITOR
    [Separator] public Separator s21;
#endif
    public float Mining;
    public float MiningPublicFund;
    public marketRates MiningRates;
    public float TotalMiningShares;
    public Dictionary<string, float> MiningSubsectoryList;
    public float MiningVolatility;
    public SectorManager.MarketFreedom MiningSectorFreedom;
#if UNITY_EDITOR
    [Separator] public Separator s133;
#endif
    public float Tourism;
    public float TourismPublicFund;
    public marketRates TourismRates;
    public float TotalTourismShares;
    public Dictionary<string, float> TourismSubsectoryList;
    public float TourismVolatility;
    public SectorManager.MarketFreedom TourismSectorFreedom;
#if UNITY_EDITOR
    [Separator] public Separator s24;
#endif
    public float Telecom;
    public float TelecomPublicFund;
    public marketRates TelecomRates;
    public float TotalTelecomShares;
    public Dictionary<string, float> TelecomSubsectoryList;
    public float TelecomVolatility;
    public SectorManager.MarketFreedom TelecomSectorFreedom;
#if UNITY_EDITOR
    [Separator] public Separator s25;
#endif
    public float Transport;
    public float TransportPublicFund;
    public marketRates TransportRates;
    public float TotalTransportShares;
    public Dictionary<string, float> TransportSubsectoryList;
    public float TransportVolatility;
    public SectorManager.MarketFreedom TransportSectorFreedom;
#if UNITY_EDITOR
    [Separator] public Separator s26;
#endif
    public float Energy;
    public float EnergyPublicFund;
    public marketRates EnergyRates;
    public float TotalEnergyShares;
    public Dictionary<string, float> EnergySubsectoryList;
    public float EnergyVolatility;
    public SectorManager.MarketFreedom EnergySectorFreedom;
}
