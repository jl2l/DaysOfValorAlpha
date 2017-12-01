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
using UnityEngine.SceneManagement;
using UIWidgets;

public class MapManager : MonoBehaviour
{

    public enum MapSelected
    {
        None,
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

    enum MapMoveUNIT_TYPE
    {
        TANK = 1, //only over land
        SHIP = 2, //only over water
        AIRPLANE = 3 //over either
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
        DefconView,
        DetailCityMode,
        DetailedProvinceMode,
        NarrationMode,
        DeckView
    }

    public GameObject Sun;
    public WMSK wmslObj;
    public WorldMapGlobe wmGlobeObj;
    public Text DebugText;
    public Camera worldCamer;
    public GameObject viewport, fadePlane;
    public Text CurrentPlayerGameTimeText;

    Material fadeMaterial;
    float fadeStartTime;
    public MapDisplayMode GameLastMapDisplayMode;
    public MapDisplayMode GameMapDisplayMode;
    public MapSpeed GameMapSpeed;
    public MapSelected GameMapSelectedType;
    //time and map time
    public DateTime GameDisplayDate;
    public DateTime LocalTimeOfProince;
    public Text LocalTimeZone;
    public float ZoomChange;
    public Text LocalDisplayTime;
    public float timeOfDay = 0.0f; // in hours (0-23.99)
    public CameraController mapCameraController;
    private double HoverOverOffSetTime;


    //local map time and UI
    public Text WorldMapHintInfo;
    public Text WorldHoverOverInfo;
    public bool UpdateNewLocalTime;

    public GameManager GameManager;
    public WorldManager WorldManager;


    public WorldMapStrategyKit.Country HoverOverCountry;
    public WorldMapStrategyKit.City HoverOverCity;
    public WorldMapStrategyKit.Province HoverOverProvince;

    public WorldMapStrategyKit.Country SelectedWMSKCountry;
    public WorldMapStrategyKit.City SelectedWMSKCity;
    public WorldMapStrategyKit.Province SelectedWMSKProvince;

    public GenericCity SelectedCity;
    public GenericProvince SelectedProvince;
    public CountryManager SelectedCountryManager;
    public CountryManager GamePlayerCountryManager;

    public CountryInfoPanel GameCountryInfoPanel;
    public ProvinceInfoPanel GameProvinceInfoPanel;
    public CityInfoPanel GameCityInfoPanel;


    #region Map Animations
    GameObjectAnimator PlayerShip;
    List<GameObjectAnimator> SelectedObjects;
    public GameObject CountryPerkTemplate;
    #endregion

    public Helper helpers;

    public void SetAllColor(List<GameObject> obj, bool set, Color color)
    {
        for (int i = 0; i < obj.Count; i++)
        {
            try
            {
                obj[i].SetActive(set);
                obj[i].GetComponent<Image>().color = color;
            }
            catch (Exception FailOn)
            {

            }

        }
    }
    public void SetAll(List<GameObject> obj, bool set)
    {
        for (int i = 0; i < obj.Count; i++)
        {
            try
            {
                obj[i].SetActive(set);
            }
            catch (Exception FailOn)
            {

            }

        }
    }

    #region ENUMABLES

    #region UI / FX

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

        GameManager.GameMilitaryManager.GameMilitaryBaseInfoPanel.SetActive(true);
        string delimiter = ",";
        GameManager.GameMilitaryManager.GameMilitaryBaseSelectedInfo.text = string.Format("{0}, {1}", militaryBase.BaseData.BaseName, militaryBase.BaseData.BaseInProvinceName);
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

    IEnumerator ColorMilitaryAllies()
    {
        var gm = FindObjectOfType<GameManager>();

        var gov = gm.GameMapManager.GamePlayerCountryManager;
        if (gov != null && gov.CountryGovernment != null)
        {
            float shadingColor = 100f;
            var dealsWithMilitaryAllies = gov.CountryGovernment.CountryPoliticalDeals.Where(deal => deal.TypeOfDeal == Deal.DealType.Alliance).ToList();
            dealsWithMilitaryAllies.ForEach(coutry =>
            {
                Color color = ColorCell(shadingColor);

                coutry.PartyB.ForEach(ally =>
                {
                    wmslObj.ToggleCountrySurface(ally.CountryOfGovernment.name, true, Colors.Navy);
                });

            });
        }

        yield return new WaitForEndOfFrame();
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

    #region Tilt Map 
    IEnumerator SwitchFlatMapView()
    {
        DebugText.text = "TILT MAP MODE START";
        GamePlayerCountryManager = null;
        GameLastMapDisplayMode = GameMapDisplayMode;
        GameMapDisplayMode = MapDisplayMode.FlatMap;
        SetMapGeoview();
        //StartCoroutine(SetSideBar(SelectedCountryManager));
        // Before switching view mode, initiates fade to smooth transition effect
        Invoke("StartFade", 2f);

        // After 1 second of flight, switch to normal mode. You could also check current zoomLevel in the Update() method and change accordingly.
        Invoke("DisableViewport", 1f);


        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));

        DebugText.text = "TILT MAP MODE ON";
        yield return new WaitForEndOfFrame();
    }
    IEnumerator MapUpdateFlatMap()
    {
        GameLastMapDisplayMode = GameMapDisplayMode;
        GameMapDisplayMode = MapDisplayMode.FlatMap;
        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        DebugText.text = "TILT MAP MODE UPDATED..";
        yield return new WaitForEndOfFrame();
    }
    #endregion

    #region Tilt Map 
    IEnumerator SwitchToTiltMapView()
    {
        DebugText.text = "TILT MAP MODE START";
        GamePlayerCountryManager = null;
        GameLastMapDisplayMode = GameMapDisplayMode;
        GameMapDisplayMode = MapDisplayMode.TiltMap;
        SetMapGeoview();
        // Before switching view mode, initiates fade to smooth transition effect
        Invoke("StartFade", 2f);

        // After 2.5 seconds of flight, switch to viewport mode. You could also check current zoomLevel in the Update() method and change accordingly.
        Invoke("EnableViewport", 1f);

        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        DebugText.text = "TILT MAP MODE ON";
        yield return new WaitForEndOfFrame();
    }
    IEnumerator MapUpdateTiltMap()
    {
        GameLastMapDisplayMode = GameMapDisplayMode;
        GameMapDisplayMode = MapDisplayMode.TiltMap;
        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        DebugText.text = "TILT MAP MODE UPDATED..";
        yield return new WaitForEndOfFrame();
    }
    #endregion
    #region Diplomatic 
    IEnumerator SwitchToDiplomaticView()
    {
        DebugText.text = "DIPLOMATIC MODE START";
        GamePlayerCountryManager = null;
        GameLastMapDisplayMode = GameMapDisplayMode;
        GameMapDisplayMode = MapDisplayMode.DiplomaticView;


        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        DebugText.text = "DIPLOMATIC MODE ON";
        yield return new WaitForEndOfFrame();
    }
    IEnumerator MapUpdateDiplomaticRelations()
    {
        GameLastMapDisplayMode = GameMapDisplayMode;
        GameMapDisplayMode = MapDisplayMode.DiplomaticView;
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

        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        var decorsToFade = wmslObj.decorator.GetDecoratorGroup(0, false);
        decorsToFade.StartCoroutine(DoFade(3f));
        DebugText.text = "INTEL MODE ON";

        yield return new WaitForEndOfFrame();
    }
    IEnumerator MapUpdateIntelInfo()
    {
        GameLastMapDisplayMode = GameMapDisplayMode;
        GameMapDisplayMode = MapDisplayMode.IntelView;

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


        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));

        DebugText.text = "RESEARCH MODE ON";
        yield return new WaitForEndOfFrame();

    }
    IEnumerator MapUpdateResearchMap()
    {
        GameLastMapDisplayMode = GameMapDisplayMode;
        GameMapDisplayMode = MapDisplayMode.ResearchView;

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


        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));

        DebugText.text = "ECONMIC MODE ON";

        yield return new WaitForEndOfFrame();
    }
    IEnumerator MapUpdateEconomicMap()
    {
        GameLastMapDisplayMode = GameMapDisplayMode;
        GameMapDisplayMode = MapDisplayMode.EconomcView;

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


        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));

        DebugText.text = "TRADE MODE ON";

        yield return new WaitForEndOfFrame();
    }
    IEnumerator MapUpdateTradeInfo()
    {
        GameLastMapDisplayMode = GameMapDisplayMode;
        GameMapDisplayMode = MapDisplayMode.TradeView;

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


        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));

        DebugText.text = "MILITARY MODE ON";

        yield return new WaitForEndOfFrame();
    }
    IEnumerator MapUpdateMilitaryMap()
    {
        GameLastMapDisplayMode = GameMapDisplayMode;
        GameMapDisplayMode = MapDisplayMode.MilitaryView;

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
        GameMapDisplayMode = MapDisplayMode.DeckView;
        //GameDeckInfoPanel.SetActive(true);

        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        var decorsToFade = wmslObj.decorator.GetDecoratorGroup(0, false);
        decorsToFade.StartCoroutine(DoFade(3f));
        DebugText.text = "DECK MODE ON";

        yield return new WaitForEndOfFrame();
    }
    IEnumerator MapUpdateDeckMap()
    {
        GameLastMapDisplayMode = GameMapDisplayMode;
        GameMapDisplayMode = MapDisplayMode.DeckView;

        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        //GameDeckInfoPanel.SetActive(true);
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


        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        var decorsToFade = wmslObj.decorator.GetDecoratorGroup(0, false);
        decorsToFade.StartCoroutine(DoFade(3f));
        DebugText.text = "DEFAULT MODE ON";

        yield return new WaitForEndOfFrame();
    }
    IEnumerator MapUpdateDefaultMap()
    {
        GameLastMapDisplayMode = GameMapDisplayMode;
        GameMapDisplayMode = MapDisplayMode.FlatMap;

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
        SetDefcon();

        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        var decorsToFade = wmslObj.decorator.GetDecoratorGroup(0, false);
        decorsToFade.StartCoroutine(DoFade(3f));
        DebugText.text = "DEFCONE 1 MODE ON";

        yield return new WaitForEndOfFrame();
    }
    IEnumerator MapUpdateDefcon()
    {
        GameLastMapDisplayMode = GameMapDisplayMode;
        GameMapDisplayMode = MapDisplayMode.DefconView;

        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        DebugText.text = "DEFCON MODE UPDATED..";
        yield return new WaitForEndOfFrame();
    }
    #endregion;

    #region Defcon 
    IEnumerator SwitchToCountryGovernmentView()
    {
        DebugText.text = "Open Country Menu MODE START";
        GamePlayerCountryManager = null;
        GameLastMapDisplayMode = GameMapDisplayMode;
        GameMapDisplayMode = MapDisplayMode.InMenu;


        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        var decorsToFade = wmslObj.decorator.GetDecoratorGroup(0, false);
        decorsToFade.StartCoroutine(DoFade(3f));
        DebugText.text = "DEFCONE 1 MODE ON";

        yield return new WaitForEndOfFrame();
    }
    IEnumerator MapUpdateCountryGovernment()
    {
        GameLastMapDisplayMode = GameMapDisplayMode;
        GameMapDisplayMode = MapDisplayMode.InMenu;

        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        DebugText.text = "In Menu COuntry MODE UPDATED..";
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
        //GameGovernmentInfoPanel.SetActive(true);
        yield return new WaitForEndOfFrame();

    }
    IEnumerator SetSideBar(CountryManager countryManager)
    {
        var politicalGroupInPower = countryManager.CountryGovernment.PoliticalParties.FirstOrDefault(e => e.LawStatus == Assets.CountryRelationsFactory.CountryLegalStatus.InPower);

        yield return new WaitForEndOfFrame();
    }
    #endregion

    #endregion

    #region UNIT UPDATE START AWAKE
    public void Awake()
    {
        GameManager = FindObjectOfType<GameManager>();
        wmslObj = WMSK.instance;
        helpers = new Helper();

        SetPlayerCountryManager();

    }
    // Use this for initialization
    public void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
        helpers = new Helper();
        wmslObj = WMSK.instance;
        WorldManager = GameManager.GameWorldManager;
        //seed world for DEMO, this should load from Save File afterwards
        SetPlayerCountryManager();
        mapCameraController = FindObjectOfType<CameraController>();

        fadePlane = worldCamer.transform.Find("FadePlane").gameObject;
        fadeMaterial = fadePlane.GetComponent<Renderer>().sharedMaterial;
        viewport = GameObject.Find("Viewport");
        wmslObj.sun = Sun;


        //SET CLOCK
        GameDisplayDate = new DateTime(2017, 1, 1);
        GameMapDisplayMode = MapDisplayMode.NarrationMode;
        GameMapSpeed = MapSpeed.HourSecond;
        GameMapSelectedType = MapSelected.None;
        //START DIRECTOR GAME FOR Game MODE ie main game storyline start up
        //CUE FIRST SQUENCE
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

        if (Input.GetKeyDown(KeyCode.R) && GameMapSelectedType == MapSelected.AirTransport)
        {
            CancelFlightFollow();
        }

        UpdateMapTime();
        //ConfigMapState(GameMapDisplayMode);
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
            FindObjectOfType<GameManager>().GameResearchManager.UpdateResearchProgressForDay();
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
            if (GamePlayerCountryManager != null)
            {

                if (OldDays != GameDisplayDate.DayOfYear)
                {
                    GameCountryInfoPanel.CountryGovernmentInfoText.text = string.Format("{0} Government, {1} has been in power for {2} days.",
                                                 GamePlayerCountryManager.CountryGovernment.NameOfGovernment,
                                                 GamePlayerCountryManager.CountryGovernment.ContactOfHeadOfState.ContactName, OldDays);
                }

            }

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
            case MapDisplayMode.IntelView:
                break;
            case MapDisplayMode.TradeView:
                break;
            case MapDisplayMode.DefconView:
                break;
            case MapDisplayMode.DetailCityMode:
                break;
            case MapDisplayMode.DetailedProvinceMode:
                break;
            case MapDisplayMode.NarrationMode:
                break;
            case MapDisplayMode.DeckView:
                break;
        }        //MAX ZOOM LEVEL SWITCH TO EFFECTS MODE

        DebugText.text = string.Format("switch to mode {0}", GameMapDisplayMode.ToDescription());
    }

    public void SetPlayerCountryManager()
    {
        if (WorldManager != null)
        {
            //get the master player we need this to go forward
            GamePlayerCountryManager = WorldManager.WorldCountryManagement.FirstOrDefault(e => e.CountryGovernment.IsMasterPlayer);
            if (GamePlayerCountryManager != null)
            {
                GamePlayerCountryManager.ColorMasterPlayer();
            }
            else
            {
                SetPlayerCountryManager();
            }
        }


        //if(GamePlayerCountryManager != null)
        //StartCoroutine(GetCountryCIAData(GamePlayerCountryManager.CountryGovernment.MapLookUpName));
        //military map draws
        //DRAW MAP STUFF IE MITARY BASES SHIPS AIRCRAFT ETC THINGS CONTROLLED BY THE PLAYER
        StartCoroutine(GameManager.GameMilitaryManager.DrawPlayerBases());


        //Add this events to the map
        GameCityInfoPanel.gameObject.SetActive(false);
        wmslObj.OnCityEnter += (int cityIndex) =>
        {
            switch (GameMapDisplayMode)
            {
                case MapDisplayMode.FlatMap:
                case MapDisplayMode.TiltMap:
                case MapDisplayMode.DetailCityMode:
                    GameCityInfoPanel.CityIndex = cityIndex;
                    GameCityInfoPanel.SelectCity(cityIndex, SelectedCity);
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
                case MapDisplayMode.IntelView:
                    break;
                case MapDisplayMode.TradeView:
                    break;
                case MapDisplayMode.DefconView:
                    break;
                case MapDisplayMode.DetailedProvinceMode:
                    break;
                case MapDisplayMode.NarrationMode:
                    break;
                case MapDisplayMode.DeckView:
                    break;
                default:
                    break;
            }


            DebugText.text = "Entered city " + wmslObj.cities[cityIndex].name;
        };
        wmslObj.OnCityExit += (int cityIndex) =>
        {

            switch (GameMapDisplayMode)
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
                    break;
                case MapDisplayMode.MilitaryView:
                    break;
                case MapDisplayMode.EconomcView:
                    break;
                case MapDisplayMode.ResearchView:
                    break;
                case MapDisplayMode.IntelView:
                    break;
                case MapDisplayMode.TradeView:
                    break;
                case MapDisplayMode.DefconView:
                    break;
                case MapDisplayMode.DetailCityMode:
                    GameCityInfoPanel.gameObject.SetActive(true);
                    break;
                case MapDisplayMode.DetailedProvinceMode:
                    break;
                case MapDisplayMode.NarrationMode:
                    break;
                case MapDisplayMode.DeckView:
                    break;
                default:
                    SelectedCity = null;
                    SelectedWMSKCity = null;
                    GameCityInfoPanel.CityIndex = 0;
                    break;
            }
            Debug.Log("Exited city " + wmslObj.cities[cityIndex].name);
        };



        if (GameProvinceInfoPanel != null)
        {

            wmslObj.OnProvinceEnter += (int provinceIndex, int regionIndex) =>
            {
                switch (GameMapDisplayMode)
                {
                    case MapDisplayMode.FlatMap:
                    case MapDisplayMode.TiltMap:
                    case MapDisplayMode.DetailedProvinceMode:
                        GameProvinceInfoPanel.SelectProvince(provinceIndex, regionIndex, SelectedProvince);
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
                    case MapDisplayMode.IntelView:
                        break;
                    case MapDisplayMode.TradeView:
                        break;
                    case MapDisplayMode.DefconView:
                        break;
                    case MapDisplayMode.DetailCityMode:
                        break;
                    case MapDisplayMode.NarrationMode:
                        break;
                    case MapDisplayMode.DeckView:
                        break;
                    default:
                        break;
                }
            };

            wmslObj.OnProvinceExit += (int provinceIndex, int regionIndex) =>
            {
                switch (GameMapDisplayMode)
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
                        break;
                    case MapDisplayMode.MilitaryView:
                        break;
                    case MapDisplayMode.EconomcView:
                        break;
                    case MapDisplayMode.ResearchView:
                        break;
                    case MapDisplayMode.IntelView:
                        break;
                    case MapDisplayMode.TradeView:
                        break;
                    case MapDisplayMode.DefconView:
                        break;
                    case MapDisplayMode.DetailCityMode:
                        break;
                    case MapDisplayMode.DetailedProvinceMode:
                        break;
                    case MapDisplayMode.NarrationMode:
                        break;
                    case MapDisplayMode.DeckView:
                        break;
                }

                DebugText.text = "Exited province " + wmslObj.provinces[provinceIndex].name;
                GameMapDisplayMode = GameLastMapDisplayMode;
                GameProvinceInfoPanel.Hide();
            };

            wmslObj.OnProvinceClick += (int provinceIndex, int regionIndex, int buttonIndex) =>
            {
                //GameMapDisplayMode = GameLastMapDisplayMode;
                switch (GameMapDisplayMode)
                {
                    case MapDisplayMode.FlatMap:
                    case MapDisplayMode.TiltMap:
                        wmslObj.OnCityClick += (int cityIndex, int clickButton) =>
                        {
                            //sticky the city panel until exit of province or country
                            if (clickButton == 0)
                            {
                                var selectedCity = wmslObj.cities[cityIndex];
                                GameLastMapDisplayMode = GameMapDisplayMode;
                                GameMapDisplayMode = MapDisplayMode.DetailCityMode;
                                DebugText.text = "Clicked city " + wmslObj.cities[cityIndex].name;
                                GameCityInfoPanel.SelectCityOnClick(selectedCity);

                            }
                        };
                        if (buttonIndex == 0)
                        {
                            //sticky province until exit province or country
                            GameProvinceInfoPanel.SelectProvinceOnClick(provinceIndex, regionIndex, SelectedProvince);
                        }
                        if (buttonIndex == 1)
                        {
                            //wmslObj.FlyToCountry(countryIndex,);
                            wmslObj.SetZoomLevel(wmslObj.GetCountryRegionZoomExtents(regionIndex), 1.5f);
                            GameCountryInfoPanel.SelectOnCountry();
                        }
                        break;
                    case MapDisplayMode.InGarage:
                        break;
                    case MapDisplayMode.InMenu:
                        break;
                    case MapDisplayMode.DiplomaticView:
                        //GameDiplomaticInfoPanel.SetActive(true);
                        break;
                    case MapDisplayMode.MilitaryView:
                        //GameCountryMiilitaryInfoPanel.SetActive(true);
                        break;
                    case MapDisplayMode.EconomcView:
                        //GameEconomicInfoPanel.SetActive(true);
                        break;
                    case MapDisplayMode.ResearchView:
                        //GameResearchInfoPanel.SetActive(true);
                        break;
                    case MapDisplayMode.IntelView:
                        // GameIntelInfoPanel.SetActive(true);
                        break;
                    case MapDisplayMode.TradeView:
                        //GameTradeInfoPanel.SetActive(true);
                        break;
                    case MapDisplayMode.DefconView:
                        //GameDefconInfoPanel.SetActive(true);
                        break;
                    case MapDisplayMode.DetailCityMode:
                        break;
                    case MapDisplayMode.DetailedProvinceMode:
                        break;
                    case MapDisplayMode.NarrationMode:
                        break;
                    case MapDisplayMode.DeckView:
                        //GameDeckInfoPanel.SetActive(true);
                        break;
                    default:
                        break;
                }


            };

        }

        if (GameCountryInfoPanel != null)
        {


            wmslObj.OnCountryClick += (int countryIndex, int regionIndex, int buttonIndex) =>
            {
                wmslObj.showProvinces = true;
                switch (GameMapDisplayMode)
                {
                    case MapDisplayMode.FlatMap:
                        if (buttonIndex == 1)
                        {
                            wmslObj.SetZoomLevel(wmslObj.GetCountryRegionZoomExtents(regionIndex), 1.5f);
                            GameCountryInfoPanel.SelectOnCountry();
                        }
                        break;
                    case MapDisplayMode.TiltMap:
                        if (buttonIndex == 1)
                        {
                            wmslObj.SetZoomLevel(wmslObj.GetCountryRegionZoomExtents(regionIndex), 1.5f);
                            GameCountryInfoPanel.SelectOnCountry();
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
                    case MapDisplayMode.IntelView:
                        break;
                    case MapDisplayMode.TradeView:
                        break;
                    case MapDisplayMode.DefconView:
                        break;
                    case MapDisplayMode.DetailCityMode:
                        if (buttonIndex == 1)
                        {
                            wmslObj.SetZoomLevel(wmslObj.GetCountryRegionZoomExtents(regionIndex), 1.5f);
                            GameCountryInfoPanel.SelectOnCountry();
                        }
                        break;
                    case MapDisplayMode.DetailedProvinceMode:
                        if (buttonIndex == 1)
                        {
                            wmslObj.SetZoomLevel(wmslObj.GetCountryRegionZoomExtents(regionIndex), 1.5f);
                            GameCountryInfoPanel.SelectOnCountry();
                        }
                        break;
                    case MapDisplayMode.NarrationMode:
                        break;
                    case MapDisplayMode.DeckView:
                        break;
                    default:
                        break;
                }

            };
        }

        wmslObj.OnCountryExit += WmslObj_OnCountryExit;
        wmslObj.OnCountryHighlight += WmslObj_OnCountryHighlight;
    }

    private void WmslObj_OnCountryHighlight(int countryIndex, int regionIndex, ref bool allowHighlight)
    {
        wmslObj.showProvinces = true;
        wmslObj.showCities = false;
        wmslObj.showCitiesOverCountry = true;
        wmslObj.DrawCitiesOverCountry(countryIndex);
        GameCountryInfoPanel.countryIndex = countryIndex;
        GameCountryInfoPanel.SelectOnCountry();
    }

    private void WmslObj_OnCountryExit(int countryIndex, int regionIndex)
    {
        wmslObj.showProvinces = false;
        wmslObj.showCitiesOverCountry = false;
    }

    #region Toggles
    public void ToggleOffButtons()
    {
        var mapMenu = FindObjectOfType<MainButtonList>();
        SetAllColor(new List<GameObject>() { mapMenu.DeckEditor,
            mapMenu.MilitaryButton,
            mapMenu.DefconButton,
            mapMenu.DiplomacyButton,
            mapMenu.EconomicButton,
            mapMenu.IntelligenceButton,
            mapMenu.FlatMapButton,
            mapMenu.TiltMapButton,
            mapMenu.ResearchButton,
            mapMenu.TradeButton

        }, true, Colors.White);
    }
    public void ToggleFlatMapView()
    {

        ToggleOffButtons();
        var mapMenu = FindObjectOfType<MainButtonList>();
        mapMenu.FlatMapButton.SetActive(true);
        mapMenu.FlatMapButton.GetComponent<Image>().color = Colors.RedMunsell;
        if (GameMapDisplayMode == MapDisplayMode.FlatMap)
        {
            StartCoroutine("MapUpdateFlatMap");
        }
        else
        {
            StartCoroutine("SwitchFlatMapView");
        }
    }
    public void ToggleTitlMapView()
    {

        ToggleOffButtons();
        var mapMenu = FindObjectOfType<MainButtonList>();
        mapMenu.TiltMapButton.SetActive(true);
        mapMenu.TiltMapButton.GetComponent<Image>().color = Colors.RedMunsell;
        if (GameMapDisplayMode == MapDisplayMode.TiltMap)
        {
            StartCoroutine("MapUpdateTiltMap");
        }
        else
        {
            StartCoroutine("SwitchToTiltMapView");
        }
    }
    public void ToggleDiplomaticView()
    {

        ToggleOffButtons();
        var mapMenu = FindObjectOfType<MainButtonList>();
        mapMenu.DiplomacyButton.SetActive(true);
        mapMenu.DiplomacyButton.GetComponent<Image>().color = Colors.RedMunsell;
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

        ToggleOffButtons();
        var mapMenu = FindObjectOfType<MainButtonList>();
        mapMenu.ResearchButton.SetActive(true);
        mapMenu.ResearchButton.GetComponent<Image>().color = Colors.RedMunsell;
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

        ToggleOffButtons();
        var mapMenu = FindObjectOfType<MainButtonList>();
        mapMenu.IntelligenceButton.SetActive(true);
        mapMenu.IntelligenceButton.GetComponent<Image>().color = Colors.RedMunsell;
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

        ToggleOffButtons();
        var mapMenu = FindObjectOfType<MainButtonList>();
        mapMenu.TradeButton.SetActive(true);
        mapMenu.TradeButton.GetComponent<Image>().color = Colors.RedMunsell;
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

        ToggleOffButtons();
        var mapMenu = FindObjectOfType<MainButtonList>();
        mapMenu.MilitaryButton.SetActive(true);
        mapMenu.MilitaryButton.GetComponent<Image>().color = Colors.RedMunsell;
        //GameCountryMiilitaryInfoPanel.SetActive(true);
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

        ToggleOffButtons();
        var mapMenu = FindObjectOfType<MainButtonList>();
        mapMenu.EconomicButton.SetActive(true);
        mapMenu.EconomicButton.GetComponent<Image>().color = Colors.RedMunsell;
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

        ToggleOffButtons();
        var mapMenu = FindObjectOfType<MainButtonList>();
        mapMenu.DeckEditor.SetActive(true);
        mapMenu.DeckEditor.GetComponent<Image>().color = Colors.RedMunsell;
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

        ToggleOffButtons();
        var mapMenu = FindObjectOfType<MainButtonList>();
        mapMenu.DefconButton.SetActive(true);
        mapMenu.DefconButton.GetComponent<Image>().color = Colors.RedMunsell;
        if (GameMapDisplayMode == MapDisplayMode.DefconView)
        {
            StartCoroutine("MapUpdateDefcon");
        }
        else
        {
            StartCoroutine("SwitchToDefconView");
        }
    }
    public void ToggleCountryGovernmentView()
    {

        ToggleOffButtons();
        var mapMenu = FindObjectOfType<MainButtonList>();
        mapMenu.DefconButton.SetActive(true);
        mapMenu.DefconButton.GetComponent<Image>().color = Colors.RedMunsell;
        if (GameMapDisplayMode == MapDisplayMode.InMenu)
        {
            StartCoroutine("MapUpdateCountryGovernment");
        }
        else
        {
            StartCoroutine("SwitchToCountryGovernmentView");
        }
    }
    #endregion


    #region Military Movement
    //GameMilitaryOperationsInfoPanel

    public void CancelFlightFollow()
    {
        var flights = FindObjectOfType<GameObjectAnimator>().follow = false;
        GameMapSelectedType = MapSelected.None;

    }


    public void DeployTransport()
    {
        var menuInfo = GameManager.GameMilitaryManager.GameMilitaryOperationsInfoPanel.GetComponent<MilitaryOperationInfoPanel>();

        GameObjectAnimator airplane = new GameObjectAnimator();
        //first get the destinations and what we are transporting
        //then hide the menu
        //then create airplane and flight plan
        //then zoom into the plane taking off and display button to "deselect" the transport view
        //update the flight data
        //landing the flight and trigger end event

        // Destroy existing airplane
        // if (airplane != null) DestroyImmediate(airplane.gameObject);

        menuInfo.MilitaryTransportAirPanel.SetActive(false);
        // Location for airplane
        Vector2 position = wmslObj.GetCity("New York", "United States of America").unity2DLocation;

        // Create ship
        GameObject airplaneGO = Instantiate(Resources.Load<GameObject>("Airplane/Airplane"));
        airplaneGO.transform.localScale = WorldMapStrategyKit.Misc.Vector3one * 0.25f;
        airplane = airplaneGO.WMSK_MoveTo(position);
        airplane.type = (int)MapMoveUNIT_TYPE.AIRPLANE;              // this is completely optional, just used in the demo scene to differentiate this unit from other tanks and ships
        airplane.terrainCapability = TERRAIN_CAPABILITY.Any;  // ignores path-finding and can use a straight-line from start to destination
        airplane.pivotY = 0.5f; // model is not ground based (which has a pivoty = 0, the default value, so setting the pivot to 0.5 will center vertically the model)
        airplane.autoRotation = true;  // auto-head to destination when moving
        airplane.rotationSpeed = 0.25f;  // speed of the rotation of auto-head to destination
        airplane.follow = true;
        WorldMapHintInfo.gameObject.SetActive(true);
        WorldMapHintInfo.text = "Click E to stop  following the flight";
        GameMapSelectedType = MapSelected.AirTransport;
        // Go to airplane location and wait for launch
        wmslObj.FlyToLocation(position, 1.5f, 0.05f);
        StartCoroutine(StartFlight(airplane));

    }

    IEnumerator StartFlight(GameObjectAnimator airplane)
    {
        airplane.arcMultiplier = 5f;     // this is the arc for the plane trajectory
        airplane.easeType = EASE_TYPE.SmootherStep;    // make it an easy-in-out movement

        Vector2 destination = wmslObj.GetCity("Paris", "France").unity2DLocation;
        airplane.MoveTo(destination, 150f);
        airplane.OnMoveEnd += (GameObjectAnimator anim) =>
        {

            anim.follow = false;
            WorldMapHintInfo.gameObject.SetActive(false);
            WorldMapHintInfo.text = string.Empty;
            if (airplane != null) DestroyImmediate(airplane.gameObject);

        };    // once the movement has finished, stop following the unit

        yield return new WaitForEndOfFrame();
    }
    private AsyncOperation GetAirStrikeAsync = null;
    private AsyncOperation GetAirGarageAsync = null;
    private AsyncOperation GetDefaultMapAsync = null;
    IEnumerator StartAirstrike(GameObjectAnimator airplane)
    {
        airplane.arcMultiplier = 5f;     // this is the arc for the plane trajectory
        airplane.easeType = EASE_TYPE.SmootherStep;    // make it an easy-in-out movement

        Vector2 destination = wmslObj.GetCity("Paris", "France").unity2DLocation;
        airplane.MoveTo(destination, 10f);
        StartCoroutine("CoLoadNextScene");
        airplane.OnMoveEnd += (GameObjectAnimator anim) =>
        {


            anim.follow = false;
            WorldMapHintInfo.gameObject.SetActive(false);
            WorldMapHintInfo.text = string.Empty;

            if (airplane != null) DestroyImmediate(airplane.gameObject);

            if (GetAirStrikeAsync != null)
                if (GetAirStrikeAsync.progress >= 0.9f)
                {
                    //Scene loaded! Do fades then set allowSceneActivation to true when done to switch scenes.
                    GetAirStrikeAsync.allowSceneActivation = true;
                }

        };    // once the movement has finished, stop following the unit

        yield return new WaitForEndOfFrame();
    }

    IEnumerator CoLoadNextScene()
    {
        GetAirStrikeAsync = SceneManager.LoadSceneAsync(6);
        GetAirStrikeAsync.allowSceneActivation = false;
        yield return GetAirStrikeAsync;
    }



    public void DeployAirStrike()
    {
        var menuInfo = GameManager.GameMilitaryManager.GameMilitaryOperationsInfoPanel.GetComponent<MilitaryOperationInfoPanel>();

        GameObjectAnimator airplane = new GameObjectAnimator();
        //first get the destinations and what we are transporting
        //then hide the menu
        //then create airplane and flight plan
        //then zoom into the plane taking off and display button to "deselect" the transport view
        //update the flight data
        //landing the flight and trigger end event

        // Destroy existing airplane
        // if (airplane != null) DestroyImmediate(airplane.gameObject);

        menuInfo.MilitaryTransportAirPanel.SetActive(false);
        // Location for airplane
        Vector2 position = wmslObj.GetCity("New York", "United States of America").unity2DLocation;

        // Create ship
        GameObject airplaneGO = Instantiate(Resources.Load<GameObject>("Airplane/Airplane"));
        airplaneGO.transform.localScale = WorldMapStrategyKit.Misc.Vector3one * 0.25f;
        airplane = airplaneGO.WMSK_MoveTo(position);
        airplane.type = (int)MapMoveUNIT_TYPE.AIRPLANE;              // this is completely optional, just used in the demo scene to differentiate this unit from other tanks and ships
        airplane.terrainCapability = TERRAIN_CAPABILITY.Any;  // ignores path-finding and can use a straight-line from start to destination
        airplane.pivotY = 0.5f; // model is not ground based (which has a pivoty = 0, the default value, so setting the pivot to 0.5 will center vertically the model)
        airplane.autoRotation = true;  // auto-head to destination when moving
        airplane.rotationSpeed = 0.25f;  // speed of the rotation of auto-head to destination
        airplane.follow = true;
        WorldMapHintInfo.gameObject.SetActive(true);
        WorldMapHintInfo.text = "Click E to recall bombers";
        GameMapSelectedType = MapSelected.AirTransport;
        // Go to airplane location and wait for launch
        wmslObj.FlyToLocation(position, 1.5f, 0.05f);
        StartCoroutine(StartAirstrike(airplane));
    }
    public void OpenMap()
    {
        SceneManager.LoadScene(0);
    }
    public void OpenAirGarage()
    {
        //GameCountryMiilitaryInfoPanel.SetActive(false);
        SceneManager.LoadScene(3);
    }
    //move thegamemanger
    public void OpenSeaGarage()
    {
        // GameCountryMiilitaryInfoPanel.SetActive(false);
        SceneManager.LoadScene(5);
    }
    public void OpenLandGarage()
    {
        // GameCountryMiilitaryInfoPanel.SetActive(false);
        SceneManager.LoadScene(4);
    }

    public void SetColorMilitaryAllies()
    {
        StartCoroutine("ColorMilitaryAllies");
    }
    #endregion

    public void SetMapGeoview()
    {
        wmslObj.frontiersColor = Colors.Black;
        wmslObj.thickerFrontiers = false;
        wmslObj.showCountryNames = false;
        wmslObj.earthStyle = WorldMapStrategyKit.EARTH_STYLE.NaturalScenicPlus16K;
    }
    public void SetDefcon()
    {
        wmslObj.frontiersColor = Colors.Azure;
        wmslObj.thickerFrontiers = true;
        wmslObj.earthStyle = WorldMapStrategyKit.EARTH_STYLE.NaturalScenicPlusAlternate1;
        wmslObj.showCountryNames = true;
        wmslObj.countryLabelsColor = Colors.BananaYellow;
        wmslObj.countryLabelsSize = 0.15f;


    }

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
