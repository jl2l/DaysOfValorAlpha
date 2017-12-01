using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UIWidgets;
using UnityEngine;
using UnityEngine.UI;
using WorldMapStrategyKit;

public class CityInfoPanel : MonoBehaviour
{
    public MapManager GameMapManger;

    [SerializeField]
    public CityData CityStockData;

    [SerializeField]
    public WorldMapStrategyKit.City CityMapData;
    public Helper helpers;
    public int CityIndex;
    private int _cityIndex;

    public WMSK wmslObj;
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

    /// <summary>
    /// Base Index Values
    /// </summary>
    public int TerrorIndex;
    public int CrimeIndex;
    public int EconomicIndex;
    public int PropertyConstruction;
    public int ResearchIndex;
    public int TradeIndex;

    public bool IsInPanic;
    public GameObject CityPanicIcon;
    public bool IsTerrorAttack;
    public GameObject CityIsTerrorAttackIcon;
    public bool IsNaturalDisater;
    public GameObject CityIsNaturalDisaterIcon;
    public bool IsUnderQuarintine;
    public GameObject CityIsUnderQuarintineIcon;
    public bool IsUnderStateOfEmergency;
    public GameObject CityIsUnderStateOfEmergencyIcon;
    public bool IsUnderMarshalLaw;
    public GameObject CityIsUnderMarshalLawIcon;
    public bool IsUnderNoFlyZone;
    public GameObject CityIsUnderNoFlyZoneIcon;
    public bool IsUnderRebelControl;
    public GameObject CityIsUnderRebelControlIcon;
    public bool IsBlackoutPowerLost;
    public GameObject CityBlackoutPowerLostIcon;
    public bool IsInternetBlackOut;
    public GameObject CityInternetBlackOutIcon;
    public bool IsStreetRiots;
    public GameObject CityStreetRiotsIcon;
    public bool IsInCrimeWave;
    public GameObject CityCrimeWaveIcon;
    public bool IsInSerialKiller;
    public GameObject CitySerialKillerIcon;

    // Use this for initialization
    void Start()
    {
        wmslObj = WMSK.instance;
        CityIndex = _cityIndex;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectCityOnClick(WorldMapStrategyKit.City selectedCity)
    {
        var s = selectedCity.attrib["data"].str;


        //first does this city our city then show the player city data which is live
        //if its not the players then it might be another world governments WorldCountryManagement find it in here
        //if its not in there then get the historic data from either the  WorldManager.WorldCityData or auto generate it and add it to the list of world cities that 
        //you can click on a city and spawn the data for it into the memory
        var slideBar = FindObjectOfType<Sidebar>();
        slideBar.Toggle();

        if (s == null)
        {
            var data = JsonUtility.FromJson<CityData>(s);
            var cityPanelInfo = FindObjectOfType<CityInfoPanel>();
            cityPanelInfo.CrimeIndex = CityStockData.CityCrimeIndex;
            cityPanelInfo.EconomicIndex = CityStockData.CityEconomicIndex;
            cityPanelInfo.PropertyConstruction = CityStockData.CityPropertyValue;
            cityPanelInfo.ResearchIndex = CityStockData.CityResearchIndex;
            cityPanelInfo.TerrorIndex = CityStockData.CityTerrorLevel;
            cityPanelInfo.TradeIndex = CityStockData.CityTradeValue;
            cityPanelInfo.CityRumorReport.text = "";
            cityPanelInfo.CityProvinceText.text = data.provinceName;
            cityPanelInfo.CityPopulationText.text = string.Format("{0:n0}", data.population);
            cityPanelInfo.CityNameText.text = data.name;
            cityPanelInfo.CityProductionReport.text = string.Format("{0:n0}M PER Day", data.population);
            cityPanelInfo.CityControllingFlag.texture = data.CityOwnerFlag;
        }
        //GameMapSelectedType = MapSelected.City;
        //var f = data.
        //WorldManager.CityStatus(SelectedCountryManager.CountryGovernment,)
    }
    public void SelectCity(int cityIndex, CountryToGlobalCountry.GenericCity SelectedCity)
    {
        var cityName = wmslObj.GetCityHierarchyName(cityIndex);

        var cityInfoPanel = FindObjectOfType<CityInfoPanel>();

        var cityInfo = wmslObj.cities[cityIndex];

        //no relations or network
        cityInfoPanel.CityNoIntel.gameObject.SetActive(true);
        cityInfoPanel.CityNoLocalNewsInfo.gameObject.SetActive(true);
        cityInfoPanel.CityNoProductionInfo.gameObject.SetActive(true);
        cityInfoPanel.CityNoRumorInfo.gameObject.SetActive(true);
        cityInfoPanel.CityNoStatInfo.gameObject.SetActive(true);
        cityInfoPanel.CityStatsInfoPanel.SetActive(false);
        var mapFlag = helpers.LoadFlagFromCountryName(cityInfoPanel.CityStateText.text);
        //if its different selected from previous
        if (cityInfo.uniqueId != SelectedCity.index)
        {
            var countrygovernment = GameMapManger.SelectedCountryManager;
            if (countrygovernment != null)
            {
                var countryCities = countrygovernment.CountryCityControlList.FirstOrDefault(city => city.index == cityInfo.uniqueId);

                //if we have intel network etc

                if (countryCities != null)
                {
                    SelectedCity = countryCities;

                    cityInfoPanel.CityCrimeIndex.value = cityInfoPanel.CrimeIndex = SelectedCity.CityCrimeIndex;
                    cityInfoPanel.CityTerrorIndex.value = cityInfoPanel.TerrorIndex = SelectedCity.CityTerrorLevel;
                    cityInfoPanel.CityPropertyConstruction.value = cityInfoPanel.PropertyConstruction = SelectedCity.CityPropertyValue;
                    cityInfoPanel.CityEconomicIndex.value = cityInfoPanel.EconomicIndex = SelectedCity.CityEconomicIndex;
                    cityInfoPanel.CityTradeIndex.value = cityInfoPanel.TradeIndex = SelectedCity.CityTradeValue;
                    cityInfoPanel.CityResearchIndex.value = cityInfoPanel.ResearchIndex = SelectedCity.CityResearchIndex;

                    cityInfoPanel.CityStatsInfoPanel.SetActive(true);
                }
                mapFlag = countrygovernment.CountryGovernment.CountryFlag;
                //do we have intel network?
                // do we have media sharing?
                // do we have trade deal?
                // do we have back-channel deal?
                //
                cityInfoPanel.CityNoIntel.gameObject.SetActive(false);
                cityInfoPanel.CityNoLocalNewsInfo.gameObject.SetActive(false);
                cityInfoPanel.CityNoProductionInfo.gameObject.SetActive(false);
                cityInfoPanel.CityNoRumorInfo.gameObject.SetActive(false);
                cityInfoPanel.CityNoStatInfo.gameObject.SetActive(false);

                cityInfoPanel.CityIntelReport.gameObject.SetActive(true);
                cityInfoPanel.CityLocalNews.gameObject.SetActive(true);
                cityInfoPanel.CityProductionReport.gameObject.SetActive(true);
                cityInfoPanel.CityRumorReport.gameObject.SetActive(true);
            }
            else
            {

                SelectedCity.index = cityInfo.uniqueId;
                SelectedCity.location = cityInfo.unity2DLocation;
                SelectedCity.population = cityInfo.population;
                SelectedCity.name = cityInfo.name;
                SelectedCity.provinceName = cityInfo.province;

            }
        }

        //get it from wahtever slected city was before
        cityInfoPanel.CityNameText.text = string.Format("{0} {1}", SelectedCity.name, SelectedCity.isCapital ? "[Captial]" : string.Empty, SelectedCity.isCapital ? "[Province Captial]" : string.Empty);
        cityInfoPanel.CityProvinceText.text = SelectedCity.provinceName;
        cityInfoPanel.CityStateText.text = wmslObj.countryHighlighted.name;
        cityInfoPanel.CityPopulationText.text = string.Format("{0:n0}", SelectedCity.population);

        cityInfoPanel.CityControllingFlag.texture = mapFlag;
        // GameCityInfoPanel.SetActive(true);
        // GameCityInfoPanel.GetComponent<FadeObjectInOut>().FadeIn();
        gameObject.SetActive(true);
    }
}
