using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unitilities;

using Assets;
using System;
using WorldMapStrategyKit;
using UnityEngine.UI;
using UIWidgets;
using System.Linq;

public class MilitaryManager : MonoBehaviour
{
    public WMSK wmslObj;
    private GameManager GameManager;
    public Dictionary<DeckDataItem, Vector2> PlayersMilitaryDeployments;
    public List<StrategicWeapon> PlayerStrategicForces;
    public List<MilitaryBase> PlayerMilitaryBases;
    public MilitaryBaseFactory PlayerMilitaryBase;
    public List<DeckDataItem> PlayerMilitaryDecks;
    public List<MilitaryBase> NonPlayerMilitaryBases;
    public List<GameObjectAnimator> PlayerMilitaryShips;
    public List<GameObjectAnimator> PlayerMilitaryUnits;
    public GameObject GamePlayerMilitaryBaseContainer;
    public Text GameMilitaryBaseSelectedInfo;
    public Text BaseName;
    public Text BaseIconType;
    public Text BaseSpecialize;

    public RawImage BaseIcon;
    public RawImage BaseCountryFlag;
    public Slider GameBaseStrength;
    public Text GameBaseStrengthText;
    public Slider GameBaseMaxSize;
    public Text GameBaseMaxSizeText;
    public Slider GameMaxBaseDecksAP;
    public Text GameMaxBaseDecksAPText;
    public Slider GameBaseSupplyLevel;
    public Text GameBaseSupplyLevelText;

    public GameObject GameBaseDeckList;
    public GameObject GameBaseDefensesList;


    public GameObject GameMilitaryBaseInfoPanel;
    public GameObject GameMilitaryOperationsInfoPanel;
    public GameObject GameMilitaryInfoPanel;

    //GameObjectAnimator DropShipOnPosition(Vector2 position)
    //{

    //    Create ship
    //    GameObject shipGO = Instantiate(Resources.Load<GameObject>("Ship/VikingShip"));
    //    ship = shipGO.WMSK_MoveTo(position);
    //    ship.terrainCapability = TERRAIN_CAPABILITY.OnlyWater;
    //    ship.autoRotation = true;
    //    return ship;
    //}
    public Texture2D FriendlyHQ;
    public Texture2D FriendlyFOB;
    public Texture2D FriendlyBase;
    public Texture2D FriendlyOP;
    public Texture2D FreindlyLOG;
    public Texture2D EnemyHQ;
    public Texture2D EnemyFOB;
    public Texture2D EnemyBase;
    public Texture2D EnemyOP;
    public Texture2D EnemyLOG;

    public DeckManager GameDeckManager;
    // Use this for initialization
    void Start()
    {
        wmslObj = WMSK.instance;
        PlayerMilitaryBase = new MilitaryBaseFactory();
        GameManager = FindObjectOfType<GameManager>();

        SetNavalGroups(GameManager.GamePlayerCountryManager);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerable GetPlayerBases()
    {
        yield return new WaitForEndOfFrame();
        //PlayerMilitaryBases.Add()
    }

    public void CreateMilitaryBase()
    {
        var newBase = PlayerMilitaryBase.CreateMilitaryBase(GamePlayerMilitaryBaseContainer);
    }

    public void AddToMilitaryDeployment(Vector2 deploymentLocation, List<DeckDataItem> deplomentDeck, CountryGovernment governmentDeploying)
    {

        //GameActiveMilitaryList.Add(new Tuple<CountryGovernment, List<DeckDataItem>, Vector2>(governmentDeploying, deplomentDeck, deploymentLocation));

    }

    /// <summary>
    /// Send the battle data to the Commander AI Sim
    /// </summary>
    public void SetBattleDate() { }

    public void DectectTypeOfBattle() { }

    public void GetCommander()
    {

        //GameDeckManager.GetDeckCommander()
    }
    public void SetThreatLevel() { }
    public void SetCogConLevel() { }
    public void SetDefconLevel() { }
    public void GetMilitaryOptions() { }

    public IEnumerator DrawPlayerShips()
    {
        int BaseId = 0;
        //foreach (var navalGroup in GameManager.GameMilitaryManager.PlayerMilitary.CountryMilitaryNavy)
        //{

        //    foreach (var navyShip in navalGroup.Ships)
        //    {
        //        // Instantiate the sprite, face it to up and position it into the map
        //        // GameObject star = Instantiate(Resources.Load<Texture2D>(militaryBase.BaseIcon.name));
        //        GameObject marker = Instantiate(navyShip.Model, GameManager.GameMilitaryManager.GamePlayerMilitaryBaseContainer.transform);

        //        GameObject mapIcon = new GameObject(string.Format("{0}_ship_{1}", navyShip.MapIcon.name, navyShip.Name));
        //        mapIcon.AddComponent<SpriteRenderer>().sprite = Sprite.Create(navyShip.MapIcon, new Rect(0.0f, 0.0f, navyShip.MapIcon.width, navyShip.MapIcon.height), new Vector2(0.5f, 0.5f), 100.0f);

        //        var gameShip = marker.AddComponent<ShipGameObject>();

        //        wmslObj.AddMarker2DSprite(mapIcon, gameShip.ShipLocation, 0.002f);
        //        marker.transform.localRotation = Quaternion.Euler(90, 0, 0);
        //        marker.transform.localScale = WorldMapStrategyKit.Misc.Vector3one * 0.01f;
        //        marker.WMSK_MoveTo(gameShip.ShipLocation.x, gameShip.ShipLocation.y);
        //        wmslObj.AddMarker3DObject(marker, gameShip.ShipLocation, 0.05f);
        //        marker.transform.SetParent(GameManager.GameMilitaryManager.GamePlayerMilitaryBaseContainer.transform);
        //        BaseId++;
        //    }

        //}
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
    public IEnumerator SetNavalGroups(CountryManager GamePlayerCountryManager)
    {
        //this has the parts for the naval group
        var f = gameObject;
        var UIMilitaryInfoPanel = GameMilitaryInfoPanel.GetComponent<MilitaryInfoPanel>();
        UIMilitaryInfoPanel.NavalGroups.DataSource.Clear();

        GameManager.GamePlayerCountryManager.countryMilitary.CountryMilitaryNavy.ForEach(navalGroup =>
       {
           //a new tab/naval group
           var newItem = new AccordionItem();
           newItem.ToggleObject.GetComponent<Text>().text = navalGroup.NavalGroupNam;
           //the number of DDG in the group
           var newNavalGroup = Instantiate(UIMilitaryInfoPanel.NavalGroupSizeTemplate);
           //The container for all sizes
           var navalGroupSize = Instantiate(UIMilitaryInfoPanel.NavalGroupContent);
           //the list of ships go in here
           var navalGroupTemplate = Instantiate(UIMilitaryInfoPanel.NavalGroupItemTemplate);
           var newContainer = Instantiate(UIMilitaryInfoPanel.MilitaryNavyContainer);

           var listOfDistinceClasses = navalGroup.Ships.Distinct().Select(ship => ship.BaseSeaType);
           listOfDistinceClasses.ForEach(typeOf =>
           {
               var groupNavalTextList = newNavalGroup.GetComponentsInChildren<Text>();
               var totalOfThatType = navalGroup.Ships.Count(ship => ship.BaseSeaType == typeOf);
               groupNavalTextList[0].text = typeOf.ToDescription();
               groupNavalTextList[1].text = totalOfThatType.ToString();
           });
           newNavalGroup.transform.SetParent(navalGroupSize.transform);
           navalGroupSize.transform.SetParent(newItem.ContentObject.transform);
           UIMilitaryInfoPanel.NavalGroups.DataSource.Add(newItem);


       });
        StartCoroutine("DrawPlayerShips");
        yield return new WaitForEndOfFrame();
    }
}
