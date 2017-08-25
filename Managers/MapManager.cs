using UnityEngine;
using System.Collections;
using WorldMapStrategyKit;
using WPM;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static CountryToGlobalCountry;
using UnityEngine.EventSystems;
using Newtonsoft.Json;

public class MapManager : MonoBehaviour
{

    public enum MapSelected
    {

        Country,
        Province,
        City,
        MilitaryBase,
        NavalFleet,
        FOB,
        OP,
        LOGBase,
        OilPlatform,
        CargoShip,
        AirTransport,
        PassengerPlane
    }


    public enum MapSpeed
    {
        HourSecond, //default
        DaySecond, //
        DayMin,
        MonthMin,
        YearMin,
    }

    public enum MapDisplayMode
    {
        FlatMap,
        TiltMap,
        InGarage,
        InMenu,
        DiplomaticView,
        MilitaryView,
        EconomcView,
        ResearchView,
        IntelView,
        TradeView,
        DefconView

    }

    public GameObject Sun;
    public WMSK wmslObj;
    public WorldMapGlobe wmGlobeObj;
    public Text DebugText;
    public Camera globeCamera;
    public Camera worldCamer;
    public GameObject viewport, fadePlane;
    public Text CurrentPlayerGameTimeText;

    Material fadeMaterial;
    float fadeStartTime;
    public MapDisplayMode GameLastMapDisplayMode;
    public MapDisplayMode GameMapDisplayMode;
    public MapSpeed GameMapSpeed;
    public List<MapSelected> GameMapSelectedTypes;
    public DateTime GameDisplayDate;
    public DateTime LocalTimeOfProince;
    public Text LocalTimeZone;
    public float ZoomChange;
    public Text LocalDisplayTime;
    public float timeOfDay = 0.0f; // in hours (0-23.99)
    public CameraController mapCameraController;
    private double HoverOverOffSetTime;


    public Text WorldHoverOverInfo;
    public GameObject GameButtonCountryInfo;
    public GameObject GameButtonCountryVassal;
    public GameObject GameButtonCountryLaws;
    public GameObject GameButtonCountryPol;
    public GameObject GameButtonCountryDemoGroups;
    public GameObject GameButtonCountryMilitary;
    public GameObject GameButtonCountryIntel;
    public GameObject GameButtonCountryTrade;
    public GameObject GameButtonCountryResearch;
    public bool UpdateNewLocalTime { get; private set; }


    #region UI Country Government Info

    public Text UICountryName;
    public Text UICountryFounded;
    public Text UICountryCommon;
    public Text UICountryGovernmentName;
    public Text UICountryHeadOfState;
    public Text UICountryHeadOfMilitary;
    public Text UICountryHeadOfEconomic;
    public Text UICountryAmbassdor;
    public Text UICountryStationHead;

    public GameObject GameGovernmentInfoPanel;
    public GameObject GameCityInfoPanel;
    public GameObject GameCountryInfoPanel;
    public GameObject GameProvinceInfoPanel;
    public GameObject GameCountryMiilitaryInfoPanel;
    public GameObject GameEconomicInfoPanel;
    public GameObject GameMilitaryBaseInfoPanel;
    public GameObject GameDiplomaticInfoPanel;
    public GameObject GameIntelInfoPanel;
    public GameObject GameDeckInfoPanel;
    public GameObject GameShipInfoPanel;
    public GameObject GameResearchInfoPanel;
    public GameObject GameDefconInfoPanel;
    public GameObject GameInfrastructureInfoPanel;
    #endregion
    #region UI Country Relations

    public Slider PlayerPopulationTrustLevel;
    public Slider CountryPopulationTrustLevel;
    public Slider MilitaryToGovernmentTrustLevel;
    public Slider GovernmentToMilitaryTrustLevel;
    public Slider PoliticalStability;
    public Slider PoliticalCorruption;
    public Slider GovernmentIdeologyIndex;
    public Toggle FreezeAssets;
    public Toggle TraveBan;
    public Toggle Inspections;
    public Toggle Dumping;
    public Toggle Subsides;
    public Toggle EnforceLicenses;
    public Toggle CommericalBan;

    #endregion

    public GameManager GameManager;
    public WorldManager WorldManager;
    public WorldMapStrategyKit.Country SelectedCountry;
    public WorldMapStrategyKit.Country HoverOverCountry;
    public GenericCity SelectedCity;
    public GenericProvince SelectedProvince;
    public CountryManager SelectedCountryManager;
    public CountryManager GamePlayerCountryManager;

    public Text GamePlayerCountryText;
    GameObjectAnimator tank;
    List<GameObjectAnimator> SelectedObjects;
    public GameObject CountryPerkTemplate;
    public Helper helpers;
    #region ENUMABLES

    #region UI / FX
    IEnumerator DrawPlayerShips()
    {
        int BaseId = 0;
        foreach (var navalGroup in GameManager.GameMilitaryManager.PlayerMilitary.CountryMilitaryNavy)
        {

            foreach (var navyShip in navalGroup.Ships)
            {
                // Instantiate the sprite, face it to up and position it into the map
                // GameObject star = Instantiate(Resources.Load<Texture2D>(militaryBase.BaseIcon.name));
                GameObject marker = Instantiate(navyShip.Model, GameManager.GameMilitaryManager.GamePlayerMilitaryBaseContainer.transform);

                GameObject mapIcon = new GameObject(string.Format("{0}_ship_{1}", navyShip.MapIcon.name, navyShip.Name));
                mapIcon.AddComponent<SpriteRenderer>().sprite = Sprite.Create(navyShip.MapIcon, new Rect(0.0f, 0.0f, navyShip.MapIcon.width, navyShip.MapIcon.height), new Vector2(0.5f, 0.5f), 100.0f);

                var gameShip = marker.AddComponent<ShipGameObject>();

                wmslObj.AddMarker2DSprite(mapIcon, gameShip.ShipLocation, 0.002f);
                marker.transform.localRotation = Quaternion.Euler(90, 0, 0);
                marker.transform.localScale = WorldMapStrategyKit.Misc.Vector3one * 0.01f;
                marker.WMSK_MoveTo(gameShip.ShipLocation.x, gameShip.ShipLocation.y);
                wmslObj.AddMarker3DObject(marker, gameShip.ShipLocation, 0.05f);
                marker.transform.SetParent(GameManager.GameMilitaryManager.GamePlayerMilitaryBaseContainer.transform);
                BaseId++;
            }

        }


        yield return new WaitForEndOfFrame();
    }
    public IEnumerator DrawPlayerBases()
    {
        int BaseId = 0;
        foreach (var militaryBase in GameManager.GameMilitaryManager.PlayerMilitaryBases)
        {
            // Instantiate the sprite, face it to up and position it into the map
            // GameObject star = Instantiate(Resources.Load<Texture2D>(militaryBase.BaseIcon.name));
            GameObject marker = Instantiate(militaryBase.BaseMarker, GameManager.GameMilitaryManager.GamePlayerMilitaryBaseContainer.transform);

            GameObject mapIcon = new GameObject(string.Format(militaryBase.BaseIcon.name + "_base"));
            mapIcon.AddComponent<SpriteRenderer>().sprite = Sprite.Create(militaryBase.BaseIcon, new Rect(0.0f, 0.0f, militaryBase.BaseIcon.width, militaryBase.BaseIcon.height), new Vector2(0.5f, 0.5f), 100.0f);

            var gameBase = marker.AddComponent<GameMilitaryBase>();

            gameBase.BaseData = militaryBase;

            gameBase.GameBaseMaxSize = 10;
            gameBase.GameBaseStrength = 1000;
            gameBase.GameBaseSupplyLevel = 5000;
            gameBase.GameMaxBaseDecksAP = 50;
            gameBase.BaseUniqueId = BaseId;
            gameBase.MilitaryCountryBattleFlag = militaryBase.MilitaryCountryBattleFlag;


            wmslObj.AddMarker2DSprite(mapIcon, militaryBase.BaseLocation, 0.002f);
            marker.transform.localRotation = Quaternion.Euler(90, 0, 0);
            marker.transform.localScale = WorldMapStrategyKit.Misc.Vector3one * 0.01f;
            marker.WMSK_MoveTo(militaryBase.BaseLocation.x, militaryBase.BaseLocation.y);
            wmslObj.AddMarker3DObject(marker, militaryBase.BaseLocation, 0.05f);
            marker.transform.SetParent(GameManager.GameMilitaryManager.GamePlayerMilitaryBaseContainer.transform);
            BaseId++;
        }

        yield return new WaitForEndOfFrame();
    }
    public IEnumerator MapZoomSet()
    {

        //wmslObj.showCities = false;
        // wmslObj.showProvinces = false;
        if (wmslObj.lastKnownZoomLevel <= 0.5f)
        {
            ShowMiniMap();

        }
        else
        {
            HideMiniMap();
        }


        yield return new WaitForEndOfFrame();

    }
    IEnumerator OnHoverOverMilitaryBase(GameMilitaryBase militaryBase)
    {

        GameMilitaryBaseInfoPanel.SetActive(true);
        string delimiter = ",";
        GameManager.GameMilitaryManager.GameMilitaryBaseSelectedInfo.text = string.Format("{0}, {1}", militaryBase.BaseData.BaseName, militaryBase.BaseData.BaseInProvinceName.name);
        GameManager.GameMilitaryManager.GameBaseMaxSize.value = militaryBase.GameBaseMaxSize;
        GameManager.GameMilitaryManager.GameBaseMaxSizeText.text = militaryBase.GameBaseMaxSize.ToString();
        GameManager.GameMilitaryManager.GameBaseStrength.value = militaryBase.GameBaseStrength;
        GameManager.GameMilitaryManager.GameBaseStrengthText.text = militaryBase.GameBaseStrength.ToString();
        GameManager.GameMilitaryManager.GameBaseSupplyLevel.value = militaryBase.GameBaseSupplyLevel;
        GameManager.GameMilitaryManager.GameBaseSupplyLevelText.text = militaryBase.GameBaseSupplyLevel.ToString();
        GameManager.GameMilitaryManager.GameMaxBaseDecksAP.value = militaryBase.GameMaxBaseDecksAP;
        GameManager.GameMilitaryManager.GameMaxBaseDecksAPText.text = militaryBase.GameMaxBaseDecksAP.ToString();
        GameManager.GameMilitaryManager.BaseIcon.texture = militaryBase.BaseData.BaseIcon;
        GameManager.GameMilitaryManager.BaseCountryFlag.texture = militaryBase.BaseData.MilitaryCountryBattleFlag;

        GameManager.GameMilitaryManager.BaseIconType.text = militaryBase.BaseData.GameBasetype.ToDescription();
        GameManager.GameMilitaryManager.BaseSpecialize.text = string.Join(" - ", militaryBase.BaseData.GameBaseSkills.Select(s => s.ToDescription()).ToArray());
        yield return new WaitForEndOfFrame();
    }
    IEnumerator DoFade(float duration = 1.5f, string startAfter = "")
    {
        float t = 0;
        yield return new WaitForSeconds(duration);
        if (startAfter.Length > 0)
            StartCoroutine(startAfter);
        do
        {
            t = (Time.time - fadeStartTime) / duration;
            float alpha = 1.0f - Mathf.Clamp01(Mathf.Abs(t * 1.1f - 0.5f) * 2f);  // changes alpha from 0 to 1 and then to 0 again
            fadeMaterial.color = new Color(0f, 0f, 0f, alpha);
            yield return new WaitForEndOfFrame();
        } while (t < 1f);

        fadePlane.SetActive(false);

    }

    IEnumerator ColorForEachCountry(MapDisplayMode mapMode)
    {
        try
        {
            WorldManager.WorldCountryManagement.ForEach(countryMngr =>
            {
                if (countryMngr.CountryGovernment.IsMasterPlayer)
                {
                    return;
                }
                float shadingColor = 0;
                switch (mapMode)
                {
                    case MapDisplayMode.FlatMap:
                        break;
                    case MapDisplayMode.TiltMap:
                        break;
                    case MapDisplayMode.InGarage:
                        break;
                    case MapDisplayMode.InMenu:
                        break;
                    case MapDisplayMode.DiplomaticView:
                        shadingColor = countryMngr.CountryGovernment.PlayerTrustLevel;
                        break;
                    case MapDisplayMode.MilitaryView:
                        break;
                    case MapDisplayMode.EconomcView:
                        break;
                    case MapDisplayMode.ResearchView:
                        break;
                    case MapDisplayMode.IntelView:
                        break;
                    case MapDisplayMode.DefconView:
                        break;
                }
                Color color = ColorCell(shadingColor);
                wmslObj.ToggleCountrySurface(countryMngr.CountryGovernment.CountryOfGovernment.name, true, color);
            });
        }
        catch (Exception d)
        {
            var f = d;
        }
        yield return new WaitForEndOfFrame();
    }

    #region Diplomatic 
    IEnumerator SwitchToDiplomaticView()
    {
        DebugText.text = "DIPLOMATIC MODE START";
        GamePlayerCountryManager = null;
        GameLastMapDisplayMode = GameMapDisplayMode;
        GameMapDisplayMode = MapDisplayMode.DiplomaticView;

        GamePlayerCountryManager = WorldManager.CountryPlayerManagerGameObject.transform.GetChild(0).GetComponent<CountryManager>();
        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        var decorsToFade = wmslObj.decorator.GetDecoratorGroup(0, false);
        decorsToFade.StartCoroutine(DoFade(3f));
        DebugText.text = "DIPLOMATIC MODE ON";
        yield return new WaitForEndOfFrame();
    }
    IEnumerator MapUpdateDiplomaticRelations()
    {

        GamePlayerCountryManager = WorldManager.CountryPlayerManagerGameObject.transform.GetChild(0).GetComponent<CountryManager>();
        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        DebugText.text = "DIPLOMATIC MODE UPDATED..";
        yield return new WaitForEndOfFrame();
    }
    #endregion
    #region Intel 
    IEnumerator SwitchToIntelView()
    {

        DebugText.text = "INTEL MODE START";
        GamePlayerCountryManager = null;
        GameLastMapDisplayMode = GameMapDisplayMode;
        GameMapDisplayMode = MapDisplayMode.IntelView;

        GamePlayerCountryManager = WorldManager.CountryPlayerManagerGameObject.transform.GetChild(0).GetComponent<CountryManager>();
        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        var decorsToFade = wmslObj.decorator.GetDecoratorGroup(0, false);
        decorsToFade.StartCoroutine(DoFade(3f));
        DebugText.text = "INTEL MODE ON";

        yield return new WaitForEndOfFrame();
    }
    IEnumerator MapUpdateIntelInfo()
    {

        GamePlayerCountryManager = WorldManager.CountryPlayerManagerGameObject.transform.GetChild(0).GetComponent<CountryManager>();
        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        DebugText.text = "INTEL MODE UPDATED..";
        yield return new WaitForEndOfFrame();
    }
    #endregion
    #region Research 
    IEnumerator SwitchToResearchView()
    {


        DebugText.text = "RESEARCH MODE START";
        GamePlayerCountryManager = null;
        GameLastMapDisplayMode = GameMapDisplayMode;
        GameMapDisplayMode = MapDisplayMode.ResearchView;

        GamePlayerCountryManager = WorldManager.CountryPlayerManagerGameObject.transform.GetChild(0).GetComponent<CountryManager>();
        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        var decorsToFade = wmslObj.decorator.GetDecoratorGroup(0, false);
        decorsToFade.StartCoroutine(DoFade(3f));
        DebugText.text = "RESEARCH MODE ON";
        yield return new WaitForEndOfFrame();

    }
    IEnumerator MapUpdateResearchMap()
    {

        GamePlayerCountryManager = WorldManager.CountryPlayerManagerGameObject.transform.GetChild(0).GetComponent<CountryManager>();
        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        DebugText.text = "RESEARCH MODE UPDATED..";
        yield return new WaitForEndOfFrame();
    }
    #endregion
    #region Econmic 

    IEnumerator SwitchToEconomicView()
    {
        DebugText.text = "ECONMIC MODE START";
        GamePlayerCountryManager = null;
        GameLastMapDisplayMode = GameMapDisplayMode;
        GameMapDisplayMode = MapDisplayMode.EconomcView;

        GamePlayerCountryManager = WorldManager.CountryPlayerManagerGameObject.transform.GetChild(0).GetComponent<CountryManager>();
        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        var decorsToFade = wmslObj.decorator.GetDecoratorGroup(0, false);
        decorsToFade.StartCoroutine(DoFade(3f));
        DebugText.text = "ECONMIC MODE ON";

        yield return new WaitForEndOfFrame();
    }
    IEnumerator MapUpdateEconomicMap()
    {

        GamePlayerCountryManager = WorldManager.CountryPlayerManagerGameObject.transform.GetChild(0).GetComponent<CountryManager>();
        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        DebugText.text = "ECONMIC MODE UPDATED..";
        yield return new WaitForEndOfFrame();
    }
    #endregion
    #region Trade

    IEnumerator SwitchToTradeView()
    {
        DebugText.text = "TRADE MODE START";
        GamePlayerCountryManager = null;
        GameLastMapDisplayMode = GameMapDisplayMode;
        GameMapDisplayMode = MapDisplayMode.TradeView;

        GamePlayerCountryManager = WorldManager.CountryPlayerManagerGameObject.transform.GetChild(0).GetComponent<CountryManager>();
        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        var decorsToFade = wmslObj.decorator.GetDecoratorGroup(0, false);
        decorsToFade.StartCoroutine(DoFade(3f));
        DebugText.text = "TRADE MODE ON";

        yield return new WaitForEndOfFrame();
    }
    IEnumerator MapUpdateTradeInfo()
    {

        GamePlayerCountryManager = WorldManager.CountryPlayerManagerGameObject.transform.GetChild(0).GetComponent<CountryManager>();
        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        DebugText.text = "TRADE MODE UPDATED..";
        yield return new WaitForEndOfFrame();
    }
    #endregion
    #region Military 
    IEnumerator SwitchToMilitaryView()
    {
        DebugText.text = "MILITARY MODE START";
        GamePlayerCountryManager = null;
        GameLastMapDisplayMode = GameMapDisplayMode;
        GameMapDisplayMode = MapDisplayMode.MilitaryView;

        GamePlayerCountryManager = WorldManager.CountryPlayerManagerGameObject.transform.GetChild(0).GetComponent<CountryManager>();
        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        var decorsToFade = wmslObj.decorator.GetDecoratorGroup(0, false);
        decorsToFade.StartCoroutine(DoFade(3f));
        DebugText.text = "MILITARY MODE ON";

        yield return new WaitForEndOfFrame();
    }
    IEnumerator MapUpdateMilitaryMap()
    {

        GamePlayerCountryManager = WorldManager.CountryPlayerManagerGameObject.transform.GetChild(0).GetComponent<CountryManager>();
        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        DebugText.text = "MILITARY MODE UPDATED..";
        yield return new WaitForEndOfFrame();
    }
    #endregion
    #region Deck 
    IEnumerator SwitchToDeckView()
    {
        DebugText.text = "DECK MODE START";
        GamePlayerCountryManager = null;
        GameLastMapDisplayMode = GameMapDisplayMode;
        GameMapDisplayMode = MapDisplayMode.InGarage;
        GameDeckInfoPanel.SetActive(true);
        GamePlayerCountryManager = WorldManager.CountryPlayerManagerGameObject.transform.GetChild(0).GetComponent<CountryManager>();
        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        var decorsToFade = wmslObj.decorator.GetDecoratorGroup(0, false);
        decorsToFade.StartCoroutine(DoFade(3f));
        DebugText.text = "DECK MODE ON";

        yield return new WaitForEndOfFrame();
    }
    IEnumerator MapUpdateDeckMap()
    {

        GamePlayerCountryManager = WorldManager.CountryPlayerManagerGameObject.transform.GetChild(0).GetComponent<CountryManager>();
        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        GameDeckInfoPanel.SetActive(true);
        DebugText.text = "DECK MODE UPDATED..";
        yield return new WaitForEndOfFrame();
    }
    #endregion
    #region Default 
    IEnumerator SwitchToDefaultView()
    {
        DebugText.text = "DEFAULT MODE START";
        GamePlayerCountryManager = null;
        GameLastMapDisplayMode = GameMapDisplayMode;
        GameMapDisplayMode = MapDisplayMode.FlatMap;

        GamePlayerCountryManager = WorldManager.CountryPlayerManagerGameObject.transform.GetChild(0).GetComponent<CountryManager>();
        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        var decorsToFade = wmslObj.decorator.GetDecoratorGroup(0, false);
        decorsToFade.StartCoroutine(DoFade(3f));
        DebugText.text = "DEFAULT MODE ON";

        yield return new WaitForEndOfFrame();
    }
    IEnumerator MapUpdateDefaultMap()
    {

        GamePlayerCountryManager = WorldManager.CountryPlayerManagerGameObject.transform.GetChild(0).GetComponent<CountryManager>();
        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        DebugText.text = "DEFAULT MODE UPDATED..";
        yield return new WaitForEndOfFrame();
    }
    #endregion;

    #region Defcon 
    IEnumerator SwitchToDefconView()
    {
        DebugText.text = "SET DEFCON1 MODE START";
        GamePlayerCountryManager = null;
        GameLastMapDisplayMode = GameMapDisplayMode;
        GameMapDisplayMode = MapDisplayMode.DefconView;

        GamePlayerCountryManager = WorldManager.CountryPlayerManagerGameObject.transform.GetChild(0).GetComponent<CountryManager>();
        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        var decorsToFade = wmslObj.decorator.GetDecoratorGroup(0, false);
        decorsToFade.StartCoroutine(DoFade(3f));
        DebugText.text = "DEFCONE 1 MODE ON";

        yield return new WaitForEndOfFrame();
    }
    IEnumerator MapUpdateDefcon()
    {

        GamePlayerCountryManager = WorldManager.CountryPlayerManagerGameObject.transform.GetChild(0).GetComponent<CountryManager>();
        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        DebugText.text = "DEFCON MODE UPDATED..";
        yield return new WaitForEndOfFrame();
    }
    #endregion;
    #endregion

    #region DATA UI

    IEnumerator GetProvinceStats()
    {
        WorldMapStrategyKit.Province country = wmslObj.provinceHighlighted;

        yield return new WaitForEndOfFrame();
    }
    public IEnumerator SetAllProvinceStats()
    {
        WorldMapStrategyKit.Country country = wmslObj.countryHighlighted;

        for (int p = 0; p < country.provinces.Length; p++)
        {
            Color color = new Color(UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f));
            int provinceIndex = wmslObj.GetProvinceIndex(country.provinces[p]);
            wmslObj.ToggleProvinceSurface(provinceIndex, true, color);
        }


        yield return new WaitForEndOfFrame();
    }
    IEnumerator GetCountryCIAData(string countryName)
    {

        var ciaInfoHelper = new Helper();

        var ciaInfo = ciaInfoHelper.GetCIAInfo(countryName);

        yield return new WaitForEndOfFrame();
    }
    IEnumerator SetCountryInfoBar()
    {
        GameGovernmentInfoPanel.SetActive(true);
        yield return new WaitForEndOfFrame();

    }
    IEnumerator SetSideBar(CountryManager countryManager)
    {
        var politicalGroupInPower = countryManager.CountryGovernment.PoliticalParties.FirstOrDefault(e => e.LawStatus == Assets.CountryRelationsFactory.CountryLegalStatus.InPower);
        GameMilitaryBaseInfoPanel.SetActive(false);

        UICountryName.text = countryManager.CountryGovernment.LocalNameOfGovernment;
        UICountryCommon.text = countryManager.CountryGovernment.TitleOfPopulation;

        UICountryFounded.text = string.Format("Found: {0}",
            countryManager.CountryGovernment.FoundingYear);

        UICountryGovernmentName.text = string.Format("{0} ({1})",
            countryManager.CountryGovernment.NameOfGovernment,
            countryManager.CountryGovernment.GovernmentAbbreviation);

        UICountryHeadOfState.text = string.Format("{0} ({1} {2})",
            countryManager.CountryGovernment.TitleOfHeadOfState,
            countryManager.CountryGovernment.ContactOfHeadOfState.ContactName,
            politicalGroupInPower.PartySymbol);

        UICountryHeadOfMilitary.text = string.Format("{0} ({1} {2})",
            countryManager.CountryGovernment.TitleOfHeadOfState,
            countryManager.CountryGovernment.ContactOfHeadOfState.ContactName);


        UICountryHeadOfEconomic.text = string.Format("{0} ({1} {2})",
                countryManager.CountryGovernment.TitleOfHeadOfState,
                countryManager.CountryGovernment.ContactOfHeadOfState.ContactName);

        UICountryAmbassdor.text = string.Format("{0} ({1} {2})",
                countryManager.CountryGovernment.TitleOfHeadOfState,
                countryManager.CountryGovernment.ContactOfHeadOfState.ContactName);

        UICountryStationHead.text = string.Format("{0} ({1} {2})",
                countryManager.CountryGovernment.TitleOfHeadOfState,
                countryManager.CountryGovernment.ContactOfHeadOfState.ContactName);


        PlayerPopulationTrustLevel.value = countryManager.CountryGovernment.PlayerPopulationTrustLevel;
        CountryPopulationTrustLevel.value = countryManager.CountryGovernment.PopulationTrustLevel;
        MilitaryToGovernmentTrustLevel.value = countryManager.CountryGovernment.MilitaryGovernmentTrustLevel;
        GovernmentToMilitaryTrustLevel.value = countryManager.CountryGovernment.GovernmentMilitaryTrustLevel;
        PoliticalStability.value = countryManager.CountryGovernment.PoliticalStablity;
        PoliticalCorruption.value = countryManager.CountryGovernment.PoliticalCorruption;
        GovernmentIdeologyIndex.value = countryManager.CountryGovernment.GovernmentIdeologyIndex;



        yield return new WaitForEndOfFrame();
    }
    #endregion

    #endregion

    #region UNIT UPDATE START AWAKE
    public void Awake()
    {
        wmslObj = WMSK.instance;
        //wmGlobeObj = WorldMapGlobe.instance;
        SetPlayerCountryManager();

    }
    // Use this for initialization
    public void Start()
    {
        GameMapDisplayMode = MapDisplayMode.FlatMap;
        GameMapSpeed = MapSpeed.HourSecond;

        helpers = new Helper();
        wmslObj = WMSK.instance;
        //wmGlobeObj = WorldMapGlobe.instance;
        // Get the material of the fade plane
        fadePlane = worldCamer.transform.Find("FadePlane").gameObject;
        fadeMaterial = fadePlane.GetComponent<Renderer>().sharedMaterial;
        viewport = GameObject.Find("Viewport");
        wmslObj.sun = Sun;
        GameManager = FindObjectOfType<GameManager>();
        WorldManager = GameManager.GameWorldManager;
        mapCameraController = FindObjectOfType<CameraController>();
        SetPlayerCountryManager();
        // Get a reference to the viewport gameobject (we'll enable/disable it when changing modes)
        SetCamera((int)MapDisplayMode.FlatMap);

        //Set the game start time based on the settings ie you playing 2017 or 1986

        GameDisplayDate = new DateTime(2017, 1, 1);
    }
    public void OnGUI()
    {

        // Check whether a country or city is selected, then show a label with the entity name and its neighbours (new in V4.1!)
        if (wmslObj.countryHighlighted != null || wmslObj.cityHighlighted != null || wmslObj.provinceHighlighted != null)
        {
            if (wmslObj.cityHighlighted != null)
            {
                if (!wmslObj.cityHighlighted.name.Equals(wmslObj.cityHighlighted.province))
                { // show city name + province & country name
                    WorldHoverOverInfo.text = "City: " + wmslObj.cityHighlighted.name + " (" + wmslObj.cityHighlighted.province + ", " + wmslObj.countries[wmslObj.cityHighlighted.countryIndex].name + ")";
                }
                else
                {   // show city name + country name (city is a capital with same name as province)
                    WorldHoverOverInfo.text = "City: " + wmslObj.cityHighlighted.name + " (" + wmslObj.countries[wmslObj.cityHighlighted.countryIndex].name + ")";
                }
            }
            else if (wmslObj.provinceHighlighted != null)
            {
                WorldHoverOverInfo.text = wmslObj.provinceHighlighted.name + ", " + wmslObj.countryHighlighted.name;
                List<WorldMapStrategyKit.Province> neighbours = wmslObj.ProvinceNeighboursOfCurrentRegion();
                if (neighbours.Count > 0)
                    WorldHoverOverInfo.text += "\n" + Helpers.EntityListToString(neighbours);
            }
            else
            {
                WorldHoverOverInfo.text = "";
            }
        }
    }
    public void Update()
    {
        ZoomChange = wmslObj.lastKnownZoomLevel;
        if (WorldHoverOverInfo != null)
        {
            WorldHoverOverInfo.text = GetMapOverInfo();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Color rectangleFillColor = new Color(1f, 1f, 1f, 0.38f);
            Color rectangleLineColor = Color.green;
            wmslObj.RectangleSelectionInitiate(rectangleSelectionCallback, rectangleFillColor, rectangleLineColor);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            ClearCurrentSelection();
        }

        UpdateMapTime();
        ConfigMapState(GameMapDisplayMode);
    }

    #endregion

    public void UpdateMapTime()
    {

        //TODO speed up time here
        timeOfDay += ChangeMapSpeed((int)GameMapSpeed);
        var currentHour = Math.Round(timeOfDay, 0);
        var OldLocalTime = LocalTimeOfProince = GameDisplayDate;
        var OldMonth = GameDisplayDate.Month;
        var OldYear = GameDisplayDate.Year;
        var OldDays = GameDisplayDate.DayOfYear;

        if (currentHour >= 24)
        {
            timeOfDay = 0;
            GameDisplayDate = GameDisplayDate.AddDays(1);

            if (OldMonth != GameDisplayDate.Month)
            {
                //WorldManager.CountryPlayerManagerGameObject.GetComponent<CountryManager>().countryBudget.ProcessBudgetMonth();
            }
            if (OldYear != GameDisplayDate.Year)
            {
               // WorldManager.CountryPlayerManagerGameObject.GetComponent<CountryManager>().countryBudget.ProcessYearBudgetRenew();
            }
            //WorldManager.CountryPlayerManagerGameObject.GetComponent<CountryManager>().countryBudget.ProcessBudgetDay();
            //WorldManager.CountryPlayerManagerGameObject.GetComponent<SectorManager>().Process();
        }

        wmslObj.timeOfDay = timeOfDay;
        //else { GameDisplayDate = GameDisplayDate.AddHours(1); }

        if (CurrentPlayerGameTimeText)
        {
            CurrentPlayerGameTimeText.text = string.Format("{0}, ZULU {1}:00", GameDisplayDate.ToLongDateString(), currentHour);
            GamePlayerCountryText.text = string.Format("{0} Government, {1} has been in power for {2} days.", GamePlayerCountryManager.CountryGovernment.NameOfGovernment, GamePlayerCountryManager.CountryGovernment.ContactOfHeadOfState.ContactName, OldDays);
        }
        //regionInfo.ti
        var dTIme = LocalTimeOfProince.AddHours(currentHour + HoverOverOffSetTime);
        var NewLocalTime = dTIme.TimeOfDay;


        if (LocalDisplayTime)
        {
            //TODO ADD Local time zone
            //if (HoverOverCountry != null)
            //{
            //    var regionInfo = helpers.GetTimeZoneInfo(WorldHoverOverInfo.text);
            //    if (regionInfo == null)
            //        regionInfo = helpers.GetTimeZoneInfo(SelectedCountry.name);
            //    if (HoverOverOffSetTime != regionInfo.GmtOffset)
            //    {

            //        if (OldLocalTime != dTIme) { UpdateNewLocalTime = true; } else { UpdateNewLocalTime = false; }

            //        if (UpdateNewLocalTime)
            //        {
            //            var uncoming = "Dawn";
            //            TimeSpan DawnTimeSpan = TimeSpan.FromHours(6);
            //            TimeSpan DuskTimeSpan = TimeSpan.FromHours(16);
            //            TimeSpan ts = NewLocalTime;
            //            var ts2 = ts.Add(DawnTimeSpan); //time until dawn
            //            var ts3 = ts.Add(DuskTimeSpan); // time until dusk
            //            if (ts.Duration() > ts3) { uncoming = "Dusk"; }
            //            LocalDisplayTime.text = string.Format("Local: {0}:{1}, \n{2} \n <color=orange>[{4} in {3} hours]</color>", dTIme.Hour, (NewLocalTime.Minutes > 30) ? "30" : "00", GameDisplayDate.ToShortDateString(), ts2, uncoming);
            //        }

            //    }
            //}



        }

    }
    public float ChangeMapSpeed(int Speed)
    {
        switch ((MapSpeed)Speed)
        {
            case MapSpeed.HourSecond:
                return 0.01f;
            case MapSpeed.DaySecond:
                return 0.01f;
            case MapSpeed.DayMin:
                return 0.01f;
            case MapSpeed.MonthMin:
                return 0.01f;
            case MapSpeed.YearMin:
                return 0.01f;
            default:
                return 0.01f;
        }
    }
    public void rectangleSelectionCallback(Rect rect, bool finishRectangleSelection)
    {
        if (finishRectangleSelection)
        {
            SelectedObjects = wmslObj.VGOGet(rect);
            foreach (GameObjectAnimator go in SelectedObjects)
            {
                var militaryBase = go.GetComponent<GameMilitaryBase>();

                if (militaryBase != null)
                {

                    HoverOverMilitaryBase(militaryBase);
                }
                go.GetComponentInChildren<Renderer>().material.color = Color.blue;
            }
        }
    }

    public void ClearCurrentSelection()
    {
        foreach (GameObjectAnimator go in SelectedObjects)
        {
            go.GetComponentInChildren<Renderer>().material.color = Color.clear;
        }

    }

    public void HoverOverMilitaryBase(GameMilitaryBase militaryBase)
    {

        StartCoroutine(OnHoverOverMilitaryBase(militaryBase));
    }

    public void OnHoverOverMilitaryShip() { }

    public void OnClickCountryInfoButton()
    {


        StartCoroutine("SetCountryInfoBar");
    }

    public void ConfigMapState(MapDisplayMode GameMapDisplayMode)
    {

        switch (GameMapDisplayMode)
        {
            case MapDisplayMode.FlatMap:
            case MapDisplayMode.TiltMap:
                if (ZoomChange != wmslObj.lastKnownZoomLevel)
                {
                    MapZoomSet();
                }

                break;
            case MapDisplayMode.InGarage:
                break;
            case MapDisplayMode.InMenu:
                break;
            case MapDisplayMode.DiplomaticView:
                break;
            case MapDisplayMode.MilitaryView:
                break;
            case MapDisplayMode.EconomcView:
                break;
            case MapDisplayMode.ResearchView:
                break;
        }        //MAX ZOOM LEVEL SWITCH TO EFFECTS MODE


    }

    void SetPlayerCountryManager()
    {

        if (WorldManager != null)
        {

            GamePlayerCountryManager = WorldManager.WorldCountryManagement.FirstOrDefault(e => e.CountryGovernment.IsMasterPlayer);

            if (GamePlayerCountryManager != null)
            {
                WorldMapStrategyKit.CountryDecorator decorator = new WorldMapStrategyKit.CountryDecorator();
                decorator.isColorized = true;
                decorator.texture = Resources.Load<Texture2D>("DoV/UI/background_gradient");
                ColorUtility.TryParseHtmlString("#494560D6", out decorator.fillColor);
                wmslObj.decorator.SetCountryDecorator(0, GamePlayerCountryManager.CountryGovernment.MapLookUpName, decorator);
                GamePlayerCountryText.text = GamePlayerCountryManager.CountryGovernment.NameOfGovernment;
            }
        }


        //if(GamePlayerCountryManager != null)
        //StartCoroutine(GetCountryCIAData(GamePlayerCountryManager.CountryGovernment.MapLookUpName));



        StartCoroutine("DrawPlayerBases");

        wmslObj.OnCityEnter += (int cityIndex) =>
        {

            SelectCity(cityIndex, SelectedCity);

            Debug.Log("Entered city " + wmslObj.cities[cityIndex].name);
        };

        wmslObj.OnCityExit += (int cityIndex) =>
        {
            ResetMenus();
            //  Debug.Log("Exited city " + wmslObj.cities[cityIndex].name);
        };

        wmslObj.OnCityClick += (int cityIndex, int buttonIndex) =>
        {
            //
            if (buttonIndex == 0)
            {
                var selectedCity = wmslObj.cities[cityIndex];
                Debug.Log("Clicked city " + wmslObj.cities[cityIndex].name);
                SelectCityOnClick(selectedCity);

            }
        };

        wmslObj.OnProvinceEnter += (int provinceIndex, int regionIndex) =>
        {
            SelectProvince(provinceIndex, regionIndex, SelectedProvince);
        };

        wmslObj.OnProvinceExit += (int provinceIndex, int regionIndex) =>
        {
            //Debug.Log("Exited province " + wmslObj.provinces[provinceIndex].name);

            ResetMenus();
        };

        wmslObj.OnProvinceClick += (int provinceIndex, int regionIndex, int buttonIndex) =>
        {
            if (buttonIndex == 0)
            {
                //wmslObj.SetZoomLevel(wmslObj.GetCountryRegionZoomExtents(regionIndex), 1.5f);
                //SelectOnCountry();
            }
            if (buttonIndex == 1)
            {
                //wmslObj.FlyToCountry(countryIndex,);
                wmslObj.SetZoomLevel(wmslObj.GetCountryRegionZoomExtents(regionIndex), 1.5f);
                SelectOnCountry();
            }
        };

        wmslObj.OnCountryClick += (int countryIndex, int regionIndex, int buttonIndex) =>
        {

            wmslObj.showProvinces = true;
         




        };

        wmslObj.OnCountryExit += WmslObj_OnCountryExit;
        wmslObj.OnCountryHighlight += WmslObj_OnCountryHighlight;
    }

    private void WmslObj_OnCountryHighlight(int countryIndex, int regionIndex, ref bool allowHighlight)
    {
        wmslObj.showProvinces = true;
        wmslObj.showCities = false;
        wmslObj.showCitiesOverCountry = true;
        wmslObj.DrawCitiesOverCountry(countryIndex);
    }

    private void WmslObj_OnCountryExit(int countryIndex, int regionIndex)
    {
        wmslObj.showProvinces = false;
        wmslObj.showCitiesOverCountry = false;
        //if(GameCountryInfoPanel != null)
        //GameCountryInfoPanel.GetComponent<FadeObjectInOut>().FadeOut();
        ResetMenus();
    }


    public void SetPanelsByModeOnClick()
    {
        switch (GameMapDisplayMode)
        {
            case MapDisplayMode.FlatMap:

                // Before switching view mode, initiates fade to smooth transition effect
                Invoke("StartFade", 1.8f);

                // After 2.5 seconds of flight, switch to viewport mode. You could also check current zoomLevel in the Update() method and change accordingly.
                Invoke("EnableViewport", 2.5f);
                // StartCoroutine(SetSideBar(SelectedCountryManager));
                GameCountryInfoPanel.SetActive(true);
                GameCountryInfoPanel.GetComponent<FadeObjectInOut>().FadeIn();
                break;
            case MapDisplayMode.TiltMap:
                //StartCoroutine(SetSideBar(SelectedCountryManager));
                // Before switching view mode, initiates fade to smooth transition effect
                Invoke("StartFade", 0.4f);

                // After 1 second of flight, switch to normal mode. You could also check current zoomLevel in the Update() method and change accordingly.
                Invoke("DisableViewport", 1f);
                GameCountryInfoPanel.SetActive(true);
                GameCountryInfoPanel.GetComponent<FadeObjectInOut>().FadeIn();
                break;
            case MapDisplayMode.InGarage:
                GameDeckInfoPanel.SetActive(true);
                break;
            case MapDisplayMode.InMenu:
                break;
            case MapDisplayMode.DiplomaticView:
                GameDiplomaticInfoPanel.SetActive(true);
                break;
            case MapDisplayMode.MilitaryView:
                GameMilitaryBaseInfoPanel.SetActive(true);
                break;
            case MapDisplayMode.EconomcView:
                GameEconomicInfoPanel.SetActive(true);
                break;
            case MapDisplayMode.ResearchView:
                GameResearchInfoPanel.SetActive(true);
                break;
            case MapDisplayMode.IntelView:
                GameIntelInfoPanel.SetActive(true);
                break;
            case MapDisplayMode.DefconView:
                GameDefconInfoPanel.SetActive(true);
                break;
        }
    }

    public void SetCamera(int MaxCameraIndex = 0)
    {

        wmslObj = WMSK.instance;
        //globeCamera.gameObject.SetActive(false);
        worldCamer.gameObject.SetActive(true);
        //wmGlobeObj.Hide();
        ZoomChange = wmslObj.GetZoomLevel();
        GameMapDisplayMode = (MapDisplayMode)MaxCameraIndex;
        ResetMenus();
        SetPanelsByModeOnClick();

    }

    public void SelectCityOnClick(WorldMapStrategyKit.City selectedCity)
    {
        var s = selectedCity.attrib["data"].str;


        //first does this city our city then show the player city data which is live
        //if its not the players then it might be another world governments WorldCountryManagement find it in here
        //if its not in there then get the historic data from either the  WorldManager.WorldCityData or auto generate it and add it to the list of world cities that 
        //you can click on a city and spawn the data for it into the memory


      

        if (s == null)
        {
            var data = JsonUtility.FromJson<CityData>(s);
            data = WorldManager.WorldCityData.FirstOrDefault(e => e.index == selectedCity.uniqueId  && e.name == selectedCity.name);
            var cityPanelInfo = FindObjectOfType<CityInfoPanel>();
            cityPanelInfo.CrimeIndex = data.CityCrimeIndex;
            cityPanelInfo.EconomicIndex = data.CityEconomicIndex;
            cityPanelInfo.PropertyConstruction = data.CityPropertyValue;
            cityPanelInfo.ResearchIndex = data.CityResearchIndex;
            cityPanelInfo.TerrorIndex = data.CityTerrorLevel;
            cityPanelInfo.TradeIndex = data.CityTradeValue;
            cityPanelInfo.CityStatusText.text = "";
            cityPanelInfo.CityProvinceText.text = data.provinceName;
            cityPanelInfo.CityPopulationText.text = string.Format("{0:n0}", data.population);
            cityPanelInfo.CityNameText.text = data.name;
            cityPanelInfo.CityIncomeText.text = string.Format("{0:n0}M PER Day", data.population);
            cityPanelInfo.CityControllingFlag.texture = data.CityOwnerFlag;
        }

        //var f = data.
        //WorldManager.CityStatus(SelectedCountryManager.CountryGovernment,)
    }
    public void SelectCity(int cityIndex, GenericCity SelectedCity)
    {
        var cityName = wmslObj.GetCityHierarchyName(cityIndex);

        var cityInfoPanel = GameCityInfoPanel.GetComponent<CityInfoPanel>();

        var cityInfo = wmslObj.cities[cityIndex];

        var countrygovernment = WorldManager.WorldCountryManagement.FirstOrDefault(country => country.CountryGovernment.CountryOfGovernment.index == cityInfo.countryIndex);
        if(countrygovernment != null)
        {
            var countryCities = countrygovernment.CountryCityControlList.FirstOrDefault(city => city.Item1.index == cityInfo.uniqueId);


            if (countryCities != null)
            {

            }
        }
        

        SelectedCity.index = cityInfo.uniqueId;
        SelectedCity.location = cityInfo.unity2DLocation;
        cityInfoPanel.CityNameText.text = SelectedCity.name = cityInfo.name;
        cityInfoPanel.CityProvinceText.text = SelectedCity.provinceName = cityInfo.province;
        SelectedCity.population = cityInfo.population;
        cityInfoPanel.CityPopulationText.text = string.Format("{0:n0}", cityInfo.population);
        GameCityInfoPanel.SetActive(true);
        GameCityInfoPanel.GetComponent<FadeObjectInOut>().FadeIn();
    }

    public void SelectProvince(int provinceIndex, int regionIndex, GenericProvince SelectedProvince)
    {

        //  wmslObj.getpr
        GameProvinceInfoPanel.SetActive(true);
        if (SelectedProvince != null && SelectedCountryManager != null)
        {
            SelectedProvince = SelectedCountryManager.CountryGovernment.ControlsProvincesNames.FirstOrDefault(e => e.index == provinceIndex && e.countryIndex == regionIndex);
            //Player controls this province
            //wmslObj.FlyToProvince(provinceIndex, 3f, ZoomChange);
        }
        else
        {
            var selectedProvince = wmslObj.provinces[provinceIndex];
            var newProvince = new CountryToGlobalCountry.GenericProvince(selectedProvince.name);
            newProvince.index = selectedProvince.uniqueId;
            newProvince.countryIndex = regionIndex;
            newProvince.location.x = selectedProvince.center.x;
            newProvince.location.y = selectedProvince.center.y;
            SelectedProvince = newProvince;
        }

        SetPanelsByModeOnClick();

    }


    public void SelectOnCountry()
    {
        //AND HAS EMBASY OPEN TODO
        if (wmslObj.countryHighlighted != null)
        {
            ResetMenus();
            SelectedCountryManager = WorldManager.WorldCountryManagement.FirstOrDefault(e => e.CountryGovernment.CountryOfGovernment.name == wmslObj.countryHighlighted.name);
            if (SelectedCountryManager != null)
            {
                DebugText.text = string.Format("SELET {0}, {1}", SelectedCountryManager.name, SelectedCountryManager.CountryGovernment.MapLookUpName);

                wmslObj.FlyToCountry(SelectedCountryManager.CountryGovernment.MapLookUpName, 1f, ZoomChange);
            }
            else
            {
                DebugText.text = string.Format("Missing Government {0}", wmslObj.countryHighlighted.name);
                wmslObj.FlyToCountry(wmslObj.countryHighlighted.name, 1f, ZoomChange);
            }

            SetPanelsByModeOnClick();
        }
        else
        {
            // relations
            DebugText.text = "NO RELATIONS OPEN EMBASSY";
        }

    }


    public void ResetMenus()
    {
        GameGovernmentInfoPanel.SetActive(false);
        GameCityInfoPanel.SetActive(false);
        GameProvinceInfoPanel.SetActive(false);
        GameIntelInfoPanel.SetActive(false);
        GameDiplomaticInfoPanel.SetActive(false);
        GameCountryInfoPanel.SetActive(false);
        GameResearchInfoPanel.SetActive(false);
        GameShipInfoPanel.SetActive(false);
        GameEconomicInfoPanel.SetActive(false);
        GameMilitaryBaseInfoPanel.SetActive(false);
        GameShipInfoPanel.SetActive(false);
        GameDeckInfoPanel.SetActive(false);
        GameDefconInfoPanel.SetActive(false);
        GameInfrastructureInfoPanel.SetActive(false);
    }

    #region Toggles
    public void ToggleDiplomaticView()
    {
        ResetMenus();
        if (GameMapDisplayMode == MapDisplayMode.DiplomaticView)
        {
            StartCoroutine("MapUpdateDiplomaticRelations");
        }
        else
        {
            StartCoroutine("SwitchToDiplomaticView");
        }
    }
    public void ToggleResearchView()
    {
        ResetMenus();
        if (GameMapDisplayMode == MapDisplayMode.DiplomaticView)
        {
            StartCoroutine("MapUpdateResearchMap");
        }
        else
        {
            StartCoroutine("SwitchToResearchView");
        }
    }

    public void ToggleIntelView()
    {
        ResetMenus();
        if (GameMapDisplayMode == MapDisplayMode.IntelView)
        {
            StartCoroutine("MapUpdateIntelInfo");
        }
        else
        {
            StartCoroutine("SwitchToIntelView");
        }
    }

    public void ToggleTradeView()
    {
        ResetMenus();
        if (GameMapDisplayMode == MapDisplayMode.TradeView)
        {
            StartCoroutine("MapUpdateTradeInfo");
        }
        else
        {
            StartCoroutine("SwitchToTradeView");
        }
    }

    public void ToggleMilitaryView()
    {
        ResetMenus();
        if (GameMapDisplayMode == MapDisplayMode.MilitaryView)
        {
            StartCoroutine("MapUpdateMilitaryMap");
        }
        else
        {
            StartCoroutine("SwitchToMilitaryView");
        }
    }

    public void ToggleEconomicView()
    {
        ResetMenus();
        if (GameMapDisplayMode == MapDisplayMode.EconomcView)
        {
            StartCoroutine("MapUpdateEconomicMap");
        }
        else
        {
            StartCoroutine("SwitchToEconomicView");
        }
    }
    public void ToggleDeckView()
    {
        ResetMenus();
        if (GameMapDisplayMode == MapDisplayMode.EconomcView)
        {
            StartCoroutine("MapUpdateDeckMap");
        }
        else
        {
            StartCoroutine("SwitchToDeckView");
        }
    }
    public void ToggleDefconView()
    {
        ResetMenus();
        if (GameMapDisplayMode == MapDisplayMode.EconomcView)
        {
            StartCoroutine("MapUpdateDefcon");
        }
        else
        {
            StartCoroutine("SwitchToDefconView");
        }
    }

    #endregion


    public void EnableViewport()
    {
        viewport.SetActive(true);
        wmslObj.fitWindowHeight = false;
        wmslObj.fitWindowWidth = false;
        wmslObj.wrapHorizontally = true;
        wmslObj.renderViewport = viewport;  // <---- switch to viewport mode
        // The camera is free in viewport mode, so we move it in front of the viewport and look at it
        Camera.main.transform.position = viewport.transform.position - Vector3.forward * 100f;
        Camera.main.transform.LookAt(viewport.transform);

    }

    public void DisableViewport()
    {

        viewport.SetActive(false);
        wmslObj.renderViewport = null;  // <--- switch to normal map view
        wmslObj.wrapHorizontally = false;
        wmslObj.fitWindowHeight = true;
        wmslObj.fitWindowWidth = true;
        // Before switching view mode, initiates fade to smooth transition effect
        Invoke("StartFade", 0.4f);
        if (wmslObj.countryLastClicked != -1)
        {
            var localPostion = wmslObj.GetCountry(wmslObj.countryLastClicked);
            wmslObj.FlyToLocation(localPostion.center, 1f, ZoomChange);
        }

    }


    public void StartFade(string afterEvent)
    {
        fadeStartTime = Time.time;
        fadePlane.SetActive(true);
        StartCoroutine(DoFade(0.5f, afterEvent));
    }
    public Color ColorCell(float value)
    {
        var red = value < 50f ? 255f : Mathf.Round(256f - (value - 50f) * 5.12f);
        var green = value > 50f ? 255f : Mathf.Round((value) * 5.12f);
        return new Color(red, green, 0, 1);

    }

    public string GetMapOverInfo()
    {
        string text = string.Empty;
        HoverOverCountry = null;
        // Check whether a country or city is selected, then show a label with the entity name and its neighbours (new in V4.1!)
        if (wmslObj.countryHighlighted != null || wmslObj.cityHighlighted != null || wmslObj.provinceHighlighted != null)
        {
            HoverOverCountry = wmslObj.countryHighlighted;

            if (wmslObj.cityHighlighted != null)
            {
                if (!wmslObj.cityHighlighted.name.Equals(wmslObj.cityHighlighted.province))
                { // show city name + province & country name
                    return text = "City: " + wmslObj.cityHighlighted.name + " (" + wmslObj.cityHighlighted.province + ", " + wmslObj.countries[wmslObj.cityHighlighted.countryIndex].name + ")";
                }
                else
                {   // show city name + country name (city is a capital with same name as province)
                    return text = "City: " + wmslObj.cityHighlighted.name + " (" + wmslObj.countries[wmslObj.cityHighlighted.countryIndex].name + ")";
                }
            }
            else if (wmslObj.provinceHighlighted != null)
            {
                text = wmslObj.provinceHighlighted.name + ", " + wmslObj.countryHighlighted.name;
                List<WorldMapStrategyKit.Province> neighbours = wmslObj.ProvinceNeighboursOfCurrentRegion();
                if (neighbours.Count > 0)
                    return text += "\n" + Helpers.EntityListToString(neighbours);
            }
            return text = wmslObj.countryHighlighted.name;
        }
        else
        {
            return text = "";
        }

    }

    public void HideMiniMap()
    {
        WMSKMiniMap.Hide();
    }
    public void ShowMiniMap()
    {

        float left = 0.8f;
        float top = 0.8f;
        float width = 0.2f;
        float height = 0.2f;
        Vector4 normalizedScreenRect = new Vector4(left, top, width, height);
        WMSKMiniMap minimap = WMSKMiniMap.Show(normalizedScreenRect);
        minimap.duration = 2f;
        minimap.zoomLevel = 0.1f;
    }
    //void ColorizeFrance()
    //{
    //    WorldMapStrategyKit.Country country = map.GetCountry("France");
    //    for (int p = 0; p < country.provinces.Length; p++)
    //    {
    //        Color color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    //        int provinceIndex = map.GetProvinceIndex(country.provinces[p]);
    //        map.ToggleProvinceSurface(provinceIndex, true, color);
    //    }
    //}

    //void ShowBorderPoints()
    //{
    //    int cadizIndex = map.GetProvinceIndex("Spain", "Cádiz");
    //    int sevilleIndex = map.GetProvinceIndex("Spain", "Sevilla");
    //    List<Vector2> points = map.GetProvinceBorderPoints(cadizIndex, sevilleIndex);
    //    points.ForEach((point) => AddBallAtPosition(point));
    //    if (points.Count > 0) map.FlyToLocation(points[0], 2, 0.01f);
    //}

    //void AddBallAtPosition(Vector2 pos)
    //{
    //    GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    //    ball.GetComponent<Renderer>().sharedMaterial.color = Color.yellow;
    //    map.AddMarker3DObject(ball, pos, 0.03f);
    //}



}
