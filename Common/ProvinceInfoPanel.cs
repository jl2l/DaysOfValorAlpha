using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProvinceInfoPanel : MonoBehaviour
{
    public Text ProvinceNameText;
    public Text ProvinceCountryText;
    public Text PopulationText;
    public Text ProvinceStatusText;
    public Text ProvinceIncomeText;
    public RawImage ProvinceControllingFlag;

    public int TerrorIndex;
    public int CrimeIndex;
    public int EconomicIndex;
    public int PropertyConstruction;
    public int ResearchIndex;
    public int TradeIndex;


    public bool IsUnderQuarintine;
    public bool IsUnderStateOfEmergency;
    public bool IsUnderMarshalLaw;
    public bool IsUnderNoFlyZone;
    public bool IsUnderRebelControl;
    public bool IsBlackoutPowerLost;
    public bool IsStreetRiots;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
