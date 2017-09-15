using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unitilities;

using Assets;
using System;
using WorldMapStrategyKit;
using UnityEngine.UI;

public class MilitaryManager : MonoBehaviour
{
    public List<Tuple<CountryGovernment, List<DeckDataItem>, Vector2>> GameActiveMilitaryList;
    public List<Tuple<string, List<DeckDataItem>, Vector4>> PlayersMilitaryDeployments;
    public List<StrategicWeapon> PlayerStrategicForces;
    public List<MilitaryBase> PlayerMilitaryBases;
    public CountryMilitary PlayerMilitary;
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

        PlayerMilitaryBase = new MilitaryBaseFactory();
        GameDeckManager = FindObjectOfType<DeckManager>();
        GameDeckManager.PlayerDecks.ForEach(PlayerDeck =>
        {

        });
        PlayerMilitaryBases = PlayerMilitary.MilitaryBases;
        // PlayerMilitaryBases = PlayerMilitaryBase.DefaultList(GamePlayerMilitaryBaseContainer);
        //PlayerMilitaryList = new List<Tuple<List<DeckDataItem>, Vector2>>(GameDeckManager.PlayerDecks,)
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

        GameActiveMilitaryList.Add(new Tuple<CountryGovernment, List<DeckDataItem>, Vector2>(governmentDeploying, deplomentDeck, deploymentLocation));

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

}
