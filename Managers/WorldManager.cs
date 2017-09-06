using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Assets;
using System.Linq;
using WorldMapStrategyKit;

public class WorldManager : MonoBehaviour
{

    /// <summary>
    /// The events of the world this is generated everyday
    /// </summary>
    List<WorldEvent> WorldEvents;
    public CountryRelationsFactory countryFactory;
    /// <summary>
    /// The list of events that happened in the players country
    /// </summary>
    public List<Tuple<CountryManager, WorldEvent>> CountryEventsList;
    public List<CountryManager> WorldCountryManagement;
    public List<CountryGovernment> WorldGovernments;
    public List<CityData> WorldCityData;
    private MapManager GameMapManager;
    public Sprite CapitalIcon;
    public Sprite MilitaryBaseIcon;
    public Sprite FOBIcon;
    public Sprite OPIcon;
    public Sprite Infrastructure;
    public Texture2D CityDefaultIcon;
    public Texture2D CityTownIcon;
    public Texture2D CityVillageIcon;

    public List<CountryToGlobalCountry.GenericCountryInfrastructure> WorldInfrastructureList;
    public GameObject CountryAIManagerGameObject;
    public GameObject CountryHumanManagerGameObject;
    public GameObject CountryPlayerManagerGameObject;
    // Use this for initialization
    void Start()
    {
        GameMapManager = FindObjectOfType<MapManager>();
        if (WorldGovernments.Count == 0)
        {
            countryFactory = new CountryRelationsFactory();
            WorldGovernments = countryFactory.CreateOldWorldOrder();
            //World governments needs to get injected into WorldCountryManagent


        }
        StartCoroutine(IntializeWorld(WorldGovernments));
        //WMSK.instance.SetCountriesAttributes(jsonCountries);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<CountryToGlobalCountry.GenericProvince> InitalizeControlProvinceList(List<CountryToGlobalCountry.GenericProvince> provinces)
    {
        var list = new List<CountryToGlobalCountry.GenericProvince>();

        provinces.ForEach(prov =>
        {
            prov.ProvinceControl = 100f;
            list.Add(prov);
        });
        return list;
    }

    public List<CountryToGlobalCountry.GenericCity> InitalizeControlCityList(List<CountryToGlobalCountry.GenericCity> cities) {
        var list = new List<CountryToGlobalCountry.GenericCity>();

        cities.ForEach(city =>
        {
            city.CityControl = 100f;
            list.Add(city);
        });
        return list;
    }

    public void InitalizeRefrenceCity(string cityName, CountryToGlobalCountry.GenericCity cityData ) { }

    public void InitalizeUnknowCity(string cityName, CountryToGlobalCountry.GenericCity cityData) { }
    public void GenerateNewCity(string cityName, CountryToGlobalCountry.GenericCity cityData) { }
    
    IEnumerator IntializeWorld(List<CountryGovernment> WorldGovernments)
    {
        WorldGovernments.ForEach(gov =>
        {
            var naming = "GovernmentOf_{0}";
            var namingAgent = "AgentOfGovernmentOf_{0}";
            var namingAmbassodr = "GameAgentAmbassdorOf_{0}";
            var newCountry = new GameObject(string.Format(naming, gov.CountryOfGovernment.name));
            var newCountryAmbassdor = new GameObject(string.Format(namingAmbassodr, gov.CountryOfGovernment.name));
            var newCountryAgent = new GameObject(string.Format(namingAgent, gov.CountryOfGovernment.name));

            var newCountryManagerSetup = newCountry.AddComponent<CountryManager>();
            newCountryManagerSetup.CountryGovernment = gov;
            newCountryManagerSetup.CountryLaws = gov.Laws;
            newCountryManagerSetup.CountryPoliticalParties = gov.PoliticalParties;
            newCountryManagerSetup.CountryPopulationGroups = gov.DemographicGroups;
            newCountryManagerSetup.countryMilitary = gov.Military;
            newCountryManagerSetup.CountryCityControlList = InitalizeControlCityList(gov.ControlsCitiesNames);
            newCountryManagerSetup.CountryProvinceControlList = InitalizeControlProvinceList(gov.ControlsProvincesNames);
            newCountryManagerSetup.CountryGovernment.CountryFounding = new DateTime(newCountryManagerSetup.CountryGovernment.FoundingYear, newCountryManagerSetup.CountryGovernment.FoundingMonth, newCountryManagerSetup.CountryGovernment.FoundingDay);

            var newCountryAgentConfig = newCountryAgent.AddComponent<CountryAgent>();
            var newCountryAmbassdorAgent = newCountryAmbassdor.AddComponent<GameAgent>();
            newCountryAmbassdorAgent.GameAgentType = GameAgent.AgentOfType.Diplomat;
            newCountryManagerSetup.countryAIAgent = newCountryAgentConfig;
            newCountryManagerSetup.countryAmbassdor = newCountryAmbassdorAgent;

            newCountryManagerSetup.countryBudget = gov.Budget;
           var newCountrySectoryManager =  newCountry.AddComponent<SectorManager>();
            newCountrySectoryManager.GamePlayerCoutryResourceList = gov.CountryResources;

            var countryPropertries = GameMapManager.wmslObj.GetCountry(gov.CountryOfGovernment.index);
            countryPropertries.attrib.Absorb(gov.CaptialName);


            //GameMapManager.wmslObj.AddMarker2DSprite()
            countryPropertries.attrib.Absorb(gov.ContactOfHeadOfState.ContactName);
            var citiesInCountry = GameMapManager.wmslObj.cities.Where(e => e.countryIndex == gov.CountryOfGovernment.index);
           //TODO THIS MIGHT GET REPLACED WITH THE GENERIC DATA INSTEAD
            if (gov.IsMasterPlayer || gov.IsHumanPlayer)
            {

                citiesInCountry.ToList().ForEach(city => {

                    //1721336815
                    var dataCity = WorldCityData.FirstOrDefault(cityData => cityData.index == city.uniqueId);
                    if (city.uniqueId == 1721336815 || city.name == "New York") {
                        var f = city.population;
                    }
                    if (dataCity != null) {
                        city.attrib["data"] = JsonUtility.ToJson(dataCity);
                    } else {
                        city.attrib["data"] = JsonUtility.ToJson(city);
                    }
                    
              
                });
                if (gov.IsHumanPlayer)
                {
                    newCountryAgentConfig.transform.SetParent(newCountry.transform);
                    newCountryAgent.transform.SetParent(newCountry.transform);
                    newCountryAmbassdor.transform.SetParent(newCountry.transform);

                    newCountry.transform.SetParent(CountryHumanManagerGameObject.transform);
                }
                if (gov.IsMasterPlayer)
                {
                    newCountryAgentConfig.transform.SetParent(newCountry.transform);
                    newCountryAgent.transform.SetParent(newCountry.transform);
                    newCountryAmbassdor.transform.SetParent(newCountry.transform);
                    newCountrySectoryManager.transform.SetParent(newCountry.transform);
                    newCountry.transform.SetParent(CountryPlayerManagerGameObject.transform);
                }
            }

            if (gov.IsAIPlayer)
            {
                citiesInCountry.ToList().ForEach(city => {
                    // city.
                });
                newCountryAgentConfig.transform.SetParent(newCountry.transform);
                newCountryAgent.transform.SetParent(newCountry.transform);
                newCountryAmbassdor.transform.SetParent(newCountry.transform);

                newCountry.transform.SetParent(CountryAIManagerGameObject.transform);
            }
         
            WorldCountryManagement.Add(newCountryManagerSetup);
            //Destroy(newCountryAgent);

        });

        yield return new WaitForEndOfFrame();
    }

    public void GeneratTheDaysNews() { }

    public void BalanceWorld() { }
    public void InitializeWorld() { }
    public void GetCountryEventHistoryByCountry() { }
    public void CreateEvent() { }
    public void GetLatestEventsForCountry() { }

    /// <summary>
    /// Check the Development index of the city and then should the type of cities
    /// </summary>
    /// <returns></returns>
    public bool IsCitySlum()
    {
        return false;
    }

    public Color CityStatus(CountryGovernment countryGovernment, City mapCity)
    {
        var genericCity = countryGovernment.ControlsCitiesNames.FirstOrDefault(city => city.index == mapCity.uniqueId);


        //check the status of the city and determine if it meets these conditions
        //black is forign control and without any influence in a meaningful way
        //dark red is under active threat of terrorist attack, is under military threat or attack, is under rebel control
        //red is under your control but either in riots or rebel control and danger of being lost
        //orange is under quartine or state of emergency, has the effect of creatin chaos and production stops
        //yellow is can be a blackout or single isolated infrastructure failing or something minor that isn't going to effect much
        //lightyellow is city 
        //white is a city with no change from the previous time you looked at it
        //green is a city with plus change either in production or money generation
        var lastData = mapCity.attrib["data"];

      

        if (genericCity.IsTerrorAttack || genericCity.CityTerrorLevel > 95)
        {
            return Colors.DarkRed;
        }

        if(genericCity.CityTerrorLevel >= 94 && genericCity.CityTerrorLevel <= 90)
        {
            return Colors.RustyRed;
        }

        if (genericCity.CityTerrorLevel >= 94 && genericCity.CityTerrorLevel <= 90)
        {
            return Colors.Lava;
        }
        if (genericCity.CityTerrorLevel >= 89 && genericCity.CityTerrorLevel <= 85)
        {
            return Colors.Lava;
        }
        if (genericCity.CityTerrorLevel >= 84 && genericCity.CityTerrorLevel <= 70)
        {
            return Colors.Lava;
        }
        if (genericCity.CityTerrorLevel >= 69 && genericCity.CityTerrorLevel <= 60)
        {
            return Colors.Lava;
        }
        if (genericCity.CityTerrorLevel >= 59 && genericCity.CityTerrorLevel <= 50)
        {
            return Colors.Lava;
        }

        if (genericCity.IsStreetRiots)
        {
            return Colors.InternationalOrangeEngineering;
        }

        if (genericCity.IsBlackoutPowerLost)
        {
            return Colors.Sinopia;
        }
        if (genericCity.IsInPanic)
        {
            return Colors.Sinopia;
        }
        if (genericCity.IsNaturalDisater)
        {
            return Colors.Sinopia;
        }
        if (genericCity.IsTerrorAttack)
        {
            return Colors.Sinopia;
        }
        if (genericCity.IsUnderMarshalLaw)
        {
            return Colors.Sinopia;
        }
        if (genericCity.IsUnderNoFlyZone)
        {
            return Colors.Sinopia;
        }
        if (genericCity.IsUnderQuarintine)
        {
            return Colors.Sinopia;
        }
        if (genericCity.IsUnderRebelControl)
        {
            return Colors.Sinopia;
        }
        if (genericCity.IsUnderStateOfEmergency)
        {
            return Colors.Sinopia;
        }
        if (genericCity.IsUnderRebelControl)
        {
            return Colors.Sinopia;
        }

        return Color.white;
    }
}
