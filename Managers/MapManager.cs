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
        DetailedProvinceMode

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
    public DateTime GameDisplayDate;
    public DateTime LocalTimeOfProince;
    public Text LocalTimeZone;
    public float ZoomChange;
    public Text LocalDisplayTime;
    public float timeOfDay = 0.0f; // in hours (0-23.99)
    public CameraController mapCameraController;
    private double HoverOverOffSetTime;


    public Text WorldMapHintInfo;
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
    public GameObject GameMilitaryOperationsInfoPanel;
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
        if (GameManager == null)
        {
            GameManager = FindObjectOfType<GameManager>();
        }
        if (GameManager.GameMilitaryManager == null)
        {
            yield return new WaitForEndOfFrame();
        }
        else
        {
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

        GamePlayerCountryManager = WorldManager.CountryPlayerManagerGameObject.transform.GetChild(0).GetComponent<CountryManager>();
        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        var decorsToFade = wmslObj.decorator.GetDecoratorGroup(0, false);
        decorsToFade.StartCoroutine(DoFade(3f));
        DebugText.text = "TILT MAP MODE ON";
        yield return new WaitForEndOfFrame();
    }
    IEnumerator MapUpdateFlatMap()
    {

        GamePlayerCountryManager = WorldManager.CountryPlayerManagerGameObject.transform.GetChild(0).GetComponent<CountryManager>();
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
        GamePlayerCountryManager = WorldManager.CountryPlayerManagerGameObject.transform.GetChild(0).GetComponent<CountryManager>();
        StartCoroutine(ColorForEachCountry(GameMapDisplayMode));
        var decorsToFade = wmslObj.decorator.GetDecoratorGroup(0, false);
        decorsToFade.StartCoroutine(DoFade(3f));
        DebugText.text = "TILT MAP MODE ON";
        yield return new WaitForEndOfFrame();
    }
    IEnumerator MapUpdateTiltMap()
    {

        GamePlayerCountryManager = WorldManager.CountryPlayerManagerGameObject.transform.GetChild(0).GetComponent<CountryManager>();
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
        SetDefcon();
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
        GameManager = FindObjectOfType<GameManager>();
        helpers = new Helper();
        wmslObj = WMSK.instance;

        WorldManager = GameManager.GameWorldManager;

        SetPlayerCountryManager();







        mapCameraController = FindObjectOfType<CameraController>();

        //wmGlobeObj = WorldMapGlobe.instance;
        // Get the material of the fade plane
        fadePlane = worldCamer.transform.Find("FadePlane").gameObject;
        fadeMaterial = fadePlane.GetComponent<Renderer>().sharedMaterial;
        viewport = GameObject.Find("Viewport");
        wmslObj.sun = Sun;







        //Set the game start time based on the settings ie you playing 2017 or 1986

        GameDisplayDate = new DateTime(2017, 1, 1);
        GameMapDisplayMode = MapDisplayMode.FlatMap;
        GameMapSpeed = MapSpeed.HourSecond;
        GameMapSelectedType = MapSelected.None;
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
            if (GamePlayerCountryManager != null)
            {

                if (OldDays != GameDisplayDate.DayOfYear)
                {
                    GamePlayerCountryText.text = string.Format("{0} Government, {1} has been in power for {2} days.",
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
                DebugText.text = "Country Player Manager Set" + GamePlayerCountryManager.CountryGovernment.NameOfGovernment;
            }
        }


        //if(GamePlayerCountryManager != null)
        //StartCoroutine(GetCountryCIAData(GamePlayerCountryManager.CountryGovernment.MapLookUpName));



        StartCoroutine("DrawPlayerBases");

        wmslObj.OnCityEnter += (int cityIndex) =>
        {

            SelectCity(cityIndex, SelectedCity);
            DebugText.text = "Entered city " + wmslObj.cities[cityIndex].name;
        };

        wmslObj.OnCityExit += (int cityIndex) =>
        {
            if (GameMapDisplayMode == MapDisplayMode.DetailCityMode)
            {
                SetAll(new List<GameObject>() { GameCityInfoPanel
        }, true);
            }
            else
            {
                SetAll(new List<GameObject>() { GameCityInfoPanel
        }, false);

            }

            //  Debug.Log("Exited city " + wmslObj.cities[cityIndex].name);
        };

        wmslObj.OnCityClick += (int cityIndex, int buttonIndex) =>
        {
            //sticky the city panel until exit of province or country
            if (buttonIndex == 0)
            {
                var selectedCity = wmslObj.cities[cityIndex];
                GameLastMapDisplayMode = GameMapDisplayMode;
                GameMapDisplayMode = MapDisplayMode.DetailCityMode;
                DebugText.text = "Clicked city " + wmslObj.cities[cityIndex].name;
                SelectCityOnClick(selectedCity);

            }
        };

        wmslObj.OnProvinceEnter += (int provinceIndex, int regionIndex) =>
        {
            SelectProvince(provinceIndex, regionIndex, SelectedProvince);
        };

        wmslObj.OnProvinceExit += (int provinceIndex, int regionIndex) =>
        {
            DebugText.text = "Exited province " + wmslObj.provinces[provinceIndex].name;
            GameMapDisplayMode = GameLastMapDisplayMode;
            if (GameMapDisplayMode == MapDisplayMode.DetailCityMode)
            {
                SetAll(new List<GameObject>() { GameCityInfoPanel
        }, true);
            }
            else
            {
                ResetMenus();
            }
         
            SetAll(new List<GameObject>() { GameCountryInfoPanel
        }, true);
        };

        wmslObj.OnProvinceClick += (int provinceIndex, int regionIndex, int buttonIndex) =>
        {
            GameMapDisplayMode = GameLastMapDisplayMode;
            if (buttonIndex == 0)
            {
                //sticky province until exit province or country
            }
            if (buttonIndex == 1)
            {
                //wmslObj.FlyToCountry(countryIndex,);
                wmslObj.SetZoomLevel(wmslObj.GetCountryRegionZoomExtents(regionIndex), 1.5f);
                SelectProvinceOnClick(provinceIndex);
                SelectOnCountry();
            }
        };

        wmslObj.OnCountryClick += (int countryIndex, int regionIndex, int buttonIndex) =>
        {

            wmslObj.showProvinces = true;

            if (buttonIndex == 1)
            {
                //sticky the country until you exit it
                //wmslObj.FlyToCountry(countryIndex,);
                wmslObj.SetZoomLevel(wmslObj.GetCountryRegionZoomExtents(regionIndex), 1.5f);
                SelectOnCountry();
            }



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
                break;
            case MapDisplayMode.TiltMap:
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

    public void SelectCityOnClick(WorldMapStrategyKit.City selectedCity)
    {
        var s = selectedCity.attrib["data"].str;


        //first does this city our city then show the player city data which is live
        //if its not the players then it might be another world governments WorldCountryManagement find it in here
        //if its not in there then get the historic data from either the  WorldManager.WorldCityData or auto generate it and add it to the list of world cities that 
        //you can click on a city and spawn the data for it into the memory


        var cityInfoPanel = GameCityInfoPanel.GetComponent<CityInfoPanel>();
        cityInfoPanel.CitySelectedPanel.SetActive(true);
        if (s == null)
        {
            var data = JsonUtility.FromJson<CityData>(s);
            data = WorldManager.WorldCityData.FirstOrDefault(e => e.index == selectedCity.uniqueId && e.name == selectedCity.name);
            var cityPanelInfo = FindObjectOfType<CityInfoPanel>();
            cityPanelInfo.CrimeIndex = data.CityCrimeIndex;
            cityPanelInfo.EconomicIndex = data.CityEconomicIndex;
            cityPanelInfo.PropertyConstruction = data.CityPropertyValue;
            cityPanelInfo.ResearchIndex = data.CityResearchIndex;
            cityPanelInfo.TerrorIndex = data.CityTerrorLevel;
            cityPanelInfo.TradeIndex = data.CityTradeValue;
            cityPanelInfo.CityRumorReport.text = "";
            cityPanelInfo.CityProvinceText.text = data.provinceName;
            cityPanelInfo.CityPopulationText.text = string.Format("{0:n0}", data.population);
            cityPanelInfo.CityNameText.text = data.name;
            cityPanelInfo.CityProductionReport.text = string.Format("{0:n0}M PER Day", data.population);
            cityPanelInfo.CityControllingFlag.texture = data.CityOwnerFlag;
        }
        GameMapSelectedType = MapSelected.City;
        //var f = data.
        //WorldManager.CityStatus(SelectedCountryManager.CountryGovernment,)
    }
    public void SelectCity(int cityIndex, GenericCity SelectedCity)
    {
        var cityName = wmslObj.GetCityHierarchyName(cityIndex);

        var cityInfoPanel = GameCityInfoPanel.GetComponent<CityInfoPanel>();

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
            var countrygovernment = WorldManager.WorldCountryManagement.FirstOrDefault(country => country.CountryGovernment.CountryOfGovernment.index == cityInfo.countryIndex);
            if (countrygovernment != null)
            {
                var countryCities = countrygovernment.CountryCityControlList.FirstOrDefault(city => city.Item1.index == cityInfo.uniqueId);

                //if we have intel network etc

                if (countryCities != null)
                {
                    SelectedCity = countryCities.Item1;

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
        cityInfoPanel.CityNameText.text = SelectedCity.name;
        cityInfoPanel.CityProvinceText.text = SelectedCity.provinceName;
        cityInfoPanel.CityStateText.text = wmslObj.countryHighlighted.name;
        cityInfoPanel.CityPopulationText.text = string.Format("{0:n0}", SelectedCity.population);

        cityInfoPanel.CityControllingFlag.texture = mapFlag;
        GameCityInfoPanel.SetActive(true);
        GameCityInfoPanel.GetComponent<FadeObjectInOut>().FadeIn();
    }


    public void SelectProvinceOnClick(int provindeIndex)
    {
        GameMapSelectedType = MapSelected.Province;
    }
    public void SelectProvince(int provinceIndex, int regionIndex, GenericProvince SelectedProvince)
    {

        //  wmslObj.getpr
        GameProvinceInfoPanel.SetActive(true);
        var provinceUI = GameProvinceInfoPanel.GetComponent<ProvinceInfoPanel>();
        if (SelectedProvince != null && SelectedCountryManager != null)
        {
            SelectedProvince = SelectedCountryManager.CountryGovernment.ControlsProvincesNames.FirstOrDefault(e => e.index == provinceIndex && e.countryIndex == regionIndex);
            //Player controls this province
            //wmslObj.FlyToProvince(provinceIndex, 3f, ZoomChange);
            if (SelectedCountryManager != null && SelectedProvince == null)
            {
                var selectedProvince = wmslObj.provinces[provinceIndex];
                var newProvince = new CountryToGlobalCountry.GenericProvince(selectedProvince.name);
                newProvince.index = selectedProvince.uniqueId;
                newProvince.countryIndex = regionIndex;
                newProvince.location.x = selectedProvince.center.x;
                newProvince.location.y = selectedProvince.center.y;
                SelectedProvince = newProvince;
                SelectedCountryManager.CountryGovernment.ControlsProvincesNames.Add(newProvince);
                provinceUI.ProvinceControllingFlag.texture = SelectedProvince.flagowner;
                // helpers.LoadFlagFromCountryName(selectedProvince.countryIndex);
            }
        }
        else
        {
            //it doesn't exist so add it to the world list
            var selectedProvince = wmslObj.provinces[provinceIndex];
            var newProvince = new CountryToGlobalCountry.GenericProvince(selectedProvince.name);
            newProvince.index = selectedProvince.uniqueId;
            newProvince.countryIndex = regionIndex;
            newProvince.location.x = selectedProvince.center.x;
            newProvince.location.y = selectedProvince.center.y;
            SelectedProvince = newProvince;


        }

        if(SelectedProvince!= null)
        {
            provinceUI.ProvinceNameText.text = SelectedProvince.name;
            provinceUI.ProvinceRuleOfLaw.value = provinceUI.provinceRuleOfLaw = SelectedProvince.provinceRuleOfLaw;
            provinceUI.ProvinceHumanSecurity.value = provinceUI.provinceHumanSecurity = SelectedProvince.provinceHumanSecurity;
            provinceUI.ProvinceEconomicActivity.value = provinceUI.provinceEconomicDevelopment = SelectedProvince.provinceEconomicDevelopment;
            provinceUI.ProvinceCulturalValue.value = provinceUI.provinceCulturalValue = SelectedProvince.provinceCulturalValue;

        }


        // provinceUI.PopulationText.text = string.Format("{0:n0}", SelectedProvince.population);
        SetPanelsByModeOnClick();

    }


    public void SelectOnCountry()
    {
        var countryInfoPanel = GameCountryInfoPanel.GetComponent<CountryInfoPanel>();
        //AND HAS EMBASY OPEN TODO
        if (wmslObj.countryHighlighted != null)
        {
            ResetMenus();


            SelectedCountryManager = WorldManager.WorldCountryManagement.FirstOrDefault(e => e.CountryGovernment.CountryOfGovernment.name == wmslObj.countryHighlighted.name);
            if (SelectedCountryManager != null)
            {
                DebugText.text = string.Format("SELET {0}, {1}", SelectedCountryManager.name, SelectedCountryManager.CountryGovernment.MapLookUpName);
                countryInfoPanel.CountryMoreDetailsPanel.SetActive(true);
                wmslObj.FlyToCountry(SelectedCountryManager.CountryGovernment.MapLookUpName, 1f, ZoomChange);
                DebugText.text = string.Format("elected Country Government {0}", wmslObj.countryHighlighted.name);
                countryInfoPanel.CountryName.text = wmslObj.countryHighlighted.name;
                countryInfoPanel.CountryNationals.text = SelectedCountryManager.CountryGovernment.TitleOfPopulation;
                countryInfoPanel.CountryFounding.text = SelectedCountryManager.CountryGovernment.FoundingYear.ToString();
                countryInfoPanel.CaptialName.text = SelectedCountryManager.CountryGovernment.CaptialName;
                GameMapSelectedType = MapSelected.Country;
            }
            else
            {
                DebugText.text = string.Format("Missing Government {0}", wmslObj.countryHighlighted.name);
                countryInfoPanel.CountryMoreDetailsPanel.SetActive(false);
                countryInfoPanel.CountryName.text = wmslObj.countryHighlighted.name;
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

        SetAll(new List<GameObject>() { GameCityInfoPanel,
            GameGovernmentInfoPanel,
            GameProvinceInfoPanel,
            GameIntelInfoPanel,
            GameDiplomaticInfoPanel,
            GameCountryInfoPanel,
            GameResearchInfoPanel,
            GameShipInfoPanel,
            GameEconomicInfoPanel,
            GameMilitaryBaseInfoPanel,
            GameShipInfoPanel,
            GameDeckInfoPanel,
            GameDefconInfoPanel,
            GameInfrastructureInfoPanel,
            GameMilitaryOperationsInfoPanel

        }, false);
    }

    #region Toggles
    public void ToggleFlatMapView()
    {
        ResetMenus();
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
        ResetMenus();
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
        if (GameMapDisplayMode == MapDisplayMode.DefconView)
        {
            StartCoroutine("MapUpdateDefcon");
        }
        else
        {
            StartCoroutine("SwitchToDefconView");
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
        var menuInfo = GameMilitaryOperationsInfoPanel.GetComponent<MilitaryOperationInfoPanel>();

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
        var menuInfo = GameMilitaryOperationsInfoPanel.GetComponent<MilitaryOperationInfoPanel>();

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
