using UnityEngine;
using System.Collections;

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

    // Use this for initialization
    void Start()
    {
        GameBattleManager = FindObjectOfType<BattleManager>();
        GameCharacterManager = FindObjectOfType<CharacterManager>();
        GameDeckManager = FindObjectOfType<DeckManager>();
        GameIntelManager = FindObjectOfType<IntelManager>();
        GameMilitaryManager = FindObjectOfType<MilitaryManager>();
        GameResearchManager = FindObjectOfType<ResearchManager>();
        GameTradeManager = FindObjectOfType<TradeManager>();
        GameUnitManager = FindObjectOfType<UnitManager>();
        GameWorldManager = FindObjectOfType<WorldManager>();
        GameMapManager = FindObjectOfType<MapManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
