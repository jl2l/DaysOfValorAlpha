using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityInfoPanel : MonoBehaviour
{


    public GameObject CityAccordion;
    public Text CityNameText;
    public Text CityProvinceText;
    public Text CityPopulationText;
    public Text CityStateText;
    public Text CityHoverOverStat;
    public Text CityBudgetText;
    public Text CityExpensesText;
    public Text CityRebelControl;

    public RawImage CityControllingFlag;
    public RawImage CityTypeIcon;

    public GameObject CitySectorChart;
    public GameObject CityStatsInfoPanel;
    public GameObject CitySelectedPanel;
    public GameObject CityInfrastructurePanel;

    public Text CityNoIntel;
    public Text CityNoStatInfo;
    public Text CityNoProductionInfo;
    public Text CityNoLocalNewsInfo;
    public Text CityNoRumorInfo;
    public Text CityIntelReport;
    public Text CityLocalNews;
    public Text CityProductionReport;
    public Text CityRumorReport;


    public Slider CityCrimeIndex;
    public Slider CityTerrorIndex;
    public Slider CityEconomicIndex;
    public Slider CityPropertyConstruction;
    public Slider CityResearchIndex;
    public Slider CityTradeIndex;



    public int TerrorIndex;
    public int CrimeIndex;
    public int EconomicIndex;
    public int PropertyConstruction;
    public int ResearchIndex;
    public int TradeIndex;

    public bool IsInPanic;
    public bool IsTerrorAttack;
    public bool IsNaturalDisater;
    public bool IsUnderQuarintine;
    public bool IsUnderStateOfEmergency;
    public bool IsUnderMarshalLaw;
    public bool IsUnderNoFlyZone;
    public bool IsUnderRebelControl;
    public bool IsBlackoutPowerLost;
    public bool IsInternetBlackOut;
    public bool IsStreetRiots;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
