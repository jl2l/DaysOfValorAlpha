using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections.Generic;

public class ProvinceInfoPanel : MonoBehaviour
{
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

    public int TerrorIndex;
    public int CrimeIndex;
    public float provinceRuleOfLaw;
    public float provinceCulturalValue;
    public float provinceHumanSecurity;
    public float provinceEconomicDevelopment;

    public UICircle SanitationLevel;
    public float SantiationIndex;

    public UICircle WaterSupply;
    public float WaterSupplyIndex;

    public UICircle FoodSupply;
    public float FoodSUpplyIndex;

    public UICircle MedicalCare;
    public float MedicalCareIndex;

    public UICircle ElectricitySupply;
    public float ElectricitySupplyIndex;

    public UICircle InternetAccess;
    public float InternetAccessIndex;


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
