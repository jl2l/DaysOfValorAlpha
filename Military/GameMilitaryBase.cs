using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using WorldMapStrategyKit;
using Assets;
using System.Collections.Generic;

public class GameMilitaryBase : MonoBehaviour
{
   private MapManager GameMapManager;

    #region Location UI
    #endregion
    #region  UI
    public int BaseUniqueId;
    public MilitaryBase BaseData;
    public Texture2D MilitaryCountryBattleFlag;
    #endregion

    /// <summary>
    /// How strong is the base in terms of hp and power missile strikes and bombing reduce this, more fortifited bases are stronger
    /// </summary>
    public int GameBaseStrength;

    /// <summary>
    /// How many slots can it render
    /// </summary>
    public int GameBaseMaxSize;
    //public int CurrentHealth { get; set; }
    ///// <summary>
    ///// The max number of decks you can store at this base each deck will have a AP total the max can't exceed -1 unlimited
    ///// </summary>
    public int GameMaxBaseDecksAP;

    //public int BaseMaxSupplyLevel { get; set; }
    public int GameBaseSupplyLevel;
    //public List<BaseWarGameObject> BaseDeckDataList { get; internal set; }

    // Use this for initialization
    void Start()
    {
        GameMapManager = FindObjectOfType<MapManager>();
    }
    void Awake()
    {
        GameMapManager = FindObjectOfType<MapManager>();
    }
    Ray ray;
    RaycastHit hit;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            var baseOver = hit.collider.gameObject.GetComponent<GameMilitaryBase>();
            if (baseOver != null) {
                var f = "";
            }
        }
    }

    public void OnMouseEnter()
    {
        var f = "";
    }

    public void OnMouseOver()
    {
        
    }

    public void BaseRaid() { }
    public void ShowGarage() { }
    public void BaseCounterAttack() { }
    public void BaseMissileStrike() { }
    public void BaseAirStrike() { }
    public void BaseDroneStrike() { }
}
