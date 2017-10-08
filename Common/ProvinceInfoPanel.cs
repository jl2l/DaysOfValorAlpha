using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections.Generic;
using UIWidgets;

public class ProvinceInfoPanel : MonoBehaviour
{

    public GameObject ProvinceAccordion;
    public Text ProvinceNameText;
    public Text ProvinceCountryText;
    public Text PopulationText;
    //this is the intel blurb
    public Text ProvinceStatusText;
    //this is economic info blurb
    public Text ProvinceIncomeText;

    public Text ProvinceNoIntel;
    public Text ProvinceNoDipomaticOffice;
    public Text ProvinceNoBusinesses;
    public Text ProvinceNoSpyNetwork;
    public Text ProvinceNoRebelGroups;
    public Text ProvinceNoActiveTerrorGroups;
    public RawImage ProvinceControllingFlag;


    public Slider ProvinceHumanSecurity;
    public Slider ProvinceRuleOfLaw;
    public Slider ProvinceEconomicActivity;
    public Slider ProvinceCulturalValue;
    public RangeSliderFloat RebelControl;


    public int TerrorIndex;
    public int CrimeIndex;
    public float provinceRuleOfLaw;
    public float provinceCulturalValue;
    public float provinceHumanSecurity;
    public float provinceEconomicDevelopment;

    public UICircle SanitationLevel;
    public float SantiationIndex;
    public Text SanitationText;
    public UICircle WaterSupply;
    public float WaterSupplyIndex;
    public Text WaterSupplyIndexText;
    public UICircle FoodSupply;
    public float FoodSUpplyIndex;
    public Text FoodSUpplyIndexText;
    public UICircle MedicalCare;
    public float MedicalCareIndex;
    public Text MedicalCareIndexText;
    public UICircle ElectricitySupply;
    public float ElectricitySupplyIndex;
    public Text ElectricitySupplyText;
    public UICircle InternetAccess;
    public float InternetAccessIndex;
    public Text InternetAccessText;

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

    public Text CityTotal;
    public Text ProvinceMilitary;
    public Text ProvinceInfastructure;

    List<RawImage> InfrastructureList;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
