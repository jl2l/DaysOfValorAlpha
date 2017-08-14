using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityInfoPanel : MonoBehaviour {


    
    public Text CityNameText;
    public Text CityProvinceText;
    public Text CityPopulationText;
    public Text CityStatusText;
    public Text CityIncomeText;
    public RawImage CityControllingFlag;

    public int TerrorIndex;
    public int CrimeIndex;
    public int EconomicIndex;
    public int PropertyConstruction;
    public int ResearchIndex;
    public int TradeIndex;

    public bool IsInPanic;
    public bool IsTerrorAttack;
    public bool IsNaturalDisater;
    public bool IsUnderQuarintine;
    public bool IsUnderStateOfEmergency;
    public bool IsUnderMarshalLaw;
    public bool IsUnderNoFlyZone;
    public bool IsUnderRebelControl;
    public bool IsBlackoutPowerLost;
    public bool IsStreetRiots;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
