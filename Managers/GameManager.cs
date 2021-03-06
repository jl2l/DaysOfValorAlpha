﻿using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BattleManager GameBattleManager;
    public WorldManager GameWorldManager;
    public CountryManager GamePlayerCountryManager;
    public TradeManager GameTradeManager;
    public DeckManager GameDeckManager;
    public ResearchManager GameResearchManager;
    public MilitaryManager GameMilitaryManager;
    public CharacterManager GameCharacterManager;
    public IntelManager GameIntelManager;
    public UnitManager GameUnitManager;
    public MapManager GameMapManager;
    #region Game UI
    #endregion
    private static GameManager _instance;

    void Awake()
    {
        //if we don't have an [_instance] set yet
        if (!_instance)
            _instance = this;
        //otherwise, if we do, kill this thing
        else
            Destroy(this.gameObject);


        DontDestroyOnLoad(this.gameObject);

    }
    // Use this for initialization
    void Start()
    {
        GameWorldManager = FindObjectOfType<WorldManager>();
        GameMapManager = FindObjectOfType<MapManager>();
        GamePlayerCountryManager = GameMapManager.GamePlayerCountryManager;
        GameBattleManager = FindObjectOfType<BattleManager>();
        GameCharacterManager = FindObjectOfType<CharacterManager>();
        GameDeckManager = FindObjectOfType<DeckManager>();
        GameIntelManager = FindObjectOfType<IntelManager>();
        GameMilitaryManager = FindObjectOfType<MilitaryManager>();
        GameResearchManager = FindObjectOfType<ResearchManager>();
        GameTradeManager = FindObjectOfType<TradeManager>();
        GameUnitManager = FindObjectOfType<UnitManager>();
        //DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //Check for pause, and for switching between Garage and Map Agent States 
    }
}
