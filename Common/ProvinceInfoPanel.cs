using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections.Generic;
using System.Linq;
using UIWidgets;
using WorldMapStrategyKit;

public class ProvinceInfoPanel : MonoBehaviour
{

    public CountryToGlobalCountry.GenericProvince GenericProvince;
    public WorldMapStrategyKit.Province GameMapProvince;
    public WMSK wmslObj;
    public MapManager GameMapManager;
    public int provinceIndex;
    private int _regionIndex;


    /// <summary>
    /// UI elements
    /// </summary>
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


    public Progressbar ProvinceHumanSecurity;
    public Progressbar ProvinceRuleOfLaw;
    public Progressbar ProvinceEconomicActivity;
    public Progressbar ProvinceCulturalValue;
    public RangeSliderFloat RebelControl;


    public int TerrorIndex;
    public int CrimeIndex;
    public int provinceRuleOfLaw;
    public int provinceCulturalValue;
    public int provinceHumanSecurity;
    public int provinceEconomicDevelopment;

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
        wmslObj = WMSK.instance;
        GameMapManager = FindObjectOfType<MapManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }




    public void SelectProvince(int provinceIndex, int regionIndex, CountryToGlobalCountry.GenericProvince SelectedProvince)
    {

        //  wmslObj.getpr
        // GameProvinceInfoPanel.SetActive(true);


        var cm = new CountryToGlobalCountry();

        gameObject.SetActive(true);
        var controlLevel = 100f;
        if (GameMapManager.SelectedCountryManager != null)
        {
            SelectedProvince = GameMapManager.SelectedCountryManager.CountryGovernment.ControlsProvincesNames.FirstOrDefault(e => e.index == provinceIndex && e.countryIndex == regionIndex);
            //Player controls this province
            //wmslObj.FlyToProvince(provinceIndex, 3f, ZoomChange);
            if (SelectedProvince == null)
            {
                var selectedProvince = wmslObj.provinces[provinceIndex];
                var newProvince = new CountryToGlobalCountry.GenericProvince(selectedProvince.name);
                newProvince.index = selectedProvince.uniqueId;
                newProvince.countryIndex = regionIndex;
                newProvince.location.x = selectedProvince.center.x;
                newProvince.location.y = selectedProvince.center.y;
                SelectedProvince = newProvince;
                GameMapManager.SelectedCountryManager.CountryGovernment.ControlsProvincesNames.Add(newProvince);
                ProvinceControllingFlag.texture = SelectedProvince.flagowner;
                // helpers.LoadFlagFromCountryName(selectedProvince.countryIndex);
            }
        }
        else
        {

            var selectedProvince = wmslObj.provinces[provinceIndex];
            //check if the player owns this or if it exists in the list of known provinces
            var gameManager = FindObjectOfType<GameManager>();
            var playerCountryManager = gameManager.GameWorldManager.CountryPlayerManagerGameObject.GetComponentInChildren<CountryManager>();
            ProvinceMilitary.text = GetTotalMilitaryInProvince(playerCountryManager, selectedProvince.uniqueId);
            if (playerCountryManager.CountryProvinceControlList.Count > 0)
            {
                SelectedProvince = playerCountryManager.CountryProvinceControlList.FirstOrDefault(e => e.index == selectedProvince.uniqueId);
                if (SelectedProvince != null)
                {
                    SelectedProvince.ProvinceCities = playerCountryManager.CountryCityControlList.Where(e => e.provinceName == selectedProvince.name).ToList();
                    controlLevel = playerCountryManager.CountryProvinceControlList.FirstOrDefault(e => e.index == selectedProvince.uniqueId).ProvinceControl;
                }
            }
            else if (gameManager.GameWorldManager.CountryAIManagerGameObject != null && SelectedProvince == null)
            {
                //check if the AI provinces exists
                var AICountryManagers = gameManager.GameWorldManager.CountryAIManagerGameObject.GetComponents<CountryManager>().ToList();
                if (SelectedProvince == null && AICountryManagers != null)
                {
                    SelectedProvince = AICountryManagers.FirstOrDefault(e =>
                    e.CountryGovernment.CountryOfGovernment.index == selectedProvince.countryIndex).CountryProvinceControlList.FirstOrDefault(prov =>
                    prov.index == selectedProvince.uniqueId);
                    controlLevel = AICountryManagers.FirstOrDefault(e =>
                    e.CountryGovernment.CountryOfGovernment.index == selectedProvince.countryIndex).CountryProvinceControlList.FirstOrDefault(prov =>
                    prov.index == selectedProvince.uniqueId).ProvinceControl;
                    SelectedProvince.ProvinceCities = AICountryManagers.FirstOrDefault(e =>
                     e.CountryGovernment.CountryOfGovernment.index == selectedProvince.countryIndex).CountryCityControlList.Where(prov =>
                     prov.index == selectedProvince.uniqueId).ToList();
                    ProvinceMilitary.text = GetTotalMilitaryInProvince(AICountryManagers.FirstOrDefault(e =>
                    e.CountryGovernment.CountryOfGovernment.index == selectedProvince.countryIndex), selectedProvince.uniqueId);
                }
            }

            if (SelectedProvince == null)
            {
                //it doesn't exit in the game yet so lets check from the seed data
                SelectedProvince = playerCountryManager.CountryGovernment.ControlsProvincesNames.FirstOrDefault(province => province.index == selectedProvince.uniqueId && province.countryIndex == selectedProvince.countryIndex);
                if (SelectedProvince == null)
                {
                    var listOfCities = wmslObj.cities.Where(e => e.countryIndex == selectedProvince.countryIndex && e.province == selectedProvince.name);
                    //it doesn't exist so add it to the world list temporary
                    var newProvince = cm.RandomProvince(listOfCities, selectedProvince, playerCountryManager.CountryGovernment);
                    newProvince.index = selectedProvince.uniqueId;
                    newProvince.countryIndex = selectedProvince.countryIndex;
                    newProvince.location.x = selectedProvince.center.x;
                    newProvince.location.y = selectedProvince.center.y;
                    newProvince.name = selectedProvince.name;
                    SelectedProvince = newProvince;

                    ProvinceNoIntel.gameObject.SetActive(true);
                    ProvinceNoSpyNetwork.gameObject.SetActive(true);
                    ProvinceNoActiveTerrorGroups.gameObject.SetActive(true);
                    ProvinceIncomeText.text = "Unknown.";
                    ProvinceInfastructure.text = "Unknown.";
                    ProvinceMilitary.text = "Unknown.";
                }
            }
        }

        if (SelectedProvince != null)
        {
            ProvinceNameText.text = SelectedProvince.name;
            ProvinceCountryText.text = wmslObj.GetCountry(SelectedProvince.countryIndex).name;
            ProvinceRuleOfLaw.Value = provinceRuleOfLaw = (int)SelectedProvince.provinceRuleOfLaw;
            ProvinceHumanSecurity.Value = provinceHumanSecurity = (int)SelectedProvince.provinceHumanSecurity;
            ProvinceEconomicActivity.Value = provinceEconomicDevelopment = (int)SelectedProvince.provinceEconomicDevelopment;
            ProvinceCulturalValue.Value = provinceCulturalValue = (int)SelectedProvince.provinceCulturalValue;
            CityTotal.text = GetTotalCities(SelectedProvince.ProvinceCities);
            PopulationText.text = string.Format("{0} people", SelectedProvince.population);
        }

        gameObject.SetActive(true);
        // provinceUI.PopulationText.text = string.Format("{0:n0}", SelectedProvince.population);
        // SetPanelsByModeOnClick();

    }

    private string GetTotalMilitaryInProvince(CountryManager countryInfo, long provinceIndex)
    {
        //Major Military Bases; 4 
        // Local Defense Forces: 3 BCTs
        //get a list of military bases in the province;
        //get a list of military units
        if (countryInfo.countryMilitary == null)
            return "Unkown";

        var listofBases = countryInfo.countryMilitary.MilitaryBases.Where(milbase => milbase.BaseInProvinceIndex == provinceIndex).ToList();
        var totalPeople = listofBases.Sum(e => e.BaseStrength);
        return string.Format("Major Airbases; {0} Major Naval Bases; {1} Major Military Bases: {2}; Minor Military {3}; Blacksites {4}; Total Military Personnel {5};",
            listofBases.Count(e => e.GameBasetype == MilitaryBaseFactory.BaseType.MajorAirBase),
            listofBases.Count(e => e.GameBasetype == MilitaryBaseFactory.BaseType.MajorNavalBase),
            listofBases.Count(e => e.GameBasetype == MilitaryBaseFactory.BaseType.MajorInstallation),
            listofBases.Count(e => (e.GameBasetype != MilitaryBaseFactory.BaseType.MajorAirBase) || (e.GameBasetype != MilitaryBaseFactory.BaseType.MajorNavalBase) || (e.GameBasetype != MilitaryBaseFactory.BaseType.MajorInstallation)),
            listofBases.Count(e => e.GameBasetype == MilitaryBaseFactory.BaseType.CovertSupportBase), totalPeople
            );
    }
    private string GetTotalCities(List<CountryToGlobalCountry.GenericCity> provinceCities)
    {

        var totalMegaCities = provinceCities.Count(e => (e.CityType == CityType.MegaCity) || (e.CityType == CityType.Metropolis) || (e.CityType == CityType.LargeCity || (e.CityType == CityType.City) || (e.CityType == CityType.SmallCity)));// 2
        var totalTowns = provinceCities.Count(e => (e.CityType == CityType.Town) || (e.CityType == CityType.SmallTown) || (e.CityType == CityType.SmallTownAmericas || (e.CityType == CityType.SmallTownEuropean) || (e.CityType == CityType.SmallTownMiddleEastern)));
        var totalVillages = provinceCities.Count(e => (e.CityType == CityType.Village) || (e.CityType == CityType.SmallVillage) || (e.CityType == CityType.Hamlet || (e.CityType == CityType.Remote)));

        //1 Major City (NEw York) 8 Smaller Sisyes
        return string.Format("{0} Cities; {1} Towns; {2} Villages;", totalMegaCities, totalTowns, totalVillages);


    }

    public IEnumerator SelectProvinceClick(int provindeIndex, int regionIndex, CountryToGlobalCountry.GenericProvince SelectedProvince)
    {
        GameMapManager.DebugText.text = "DIPLOMATIC MODE START";
        //GameMapSelectedType = MapSelected.Province;

        var slideBar = FindObjectOfType<Sidebar>();
        slideBar.Toggle();


        provinceIndex = provindeIndex;
        GenericProvince = SelectedProvince;
        _regionIndex = regionIndex;

        SelectProvince(provinceIndex, regionIndex, GenericProvince);
        yield return new WaitForEndOfFrame();
    }

    public void SelectProvinceOnClick(int provindeIndex, int regionIndex, CountryToGlobalCountry.GenericProvince SelectedProvince)
    {
        StartCoroutine(SelectProvinceClick(provindeIndex, regionIndex, SelectedProvince));
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
