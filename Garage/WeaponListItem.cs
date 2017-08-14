using UnityEngine;
using System.Collections;
using Assets;
using UnityEngine.UI;
using ListView;

public class WeaponListItem : AdvancedListItem
{
    public Weapon WeaponData;
    public StatsDisplayController StatsDiplayController;
    public Text UIName;
    public Text UIGroundRange;
    public Text UILowAirRanage;
    public Text UIHighAirRange;
    public Text WeaponUIName;
    public Text WeaponReliablity;
    public Text WeaponSpeed;
    public Text WeaponResistance;
    public Text WeaponRateOfFire;
    public Text IsNuclearWeapon;
    public Text WeaponAmmoName;
    public Text WeaponAP;
    public Text WeaponHE;
    public Text WeaponsRemaining;
    public Text MaxNumWeaponsRemaining;
    public Text WeaponType;
    public Text WeaponWarhead;
    public Text WeaponRepairCost;
    public Text WeaponRearmCost;
    public Text WeaponPurchaseCost;

    public Text WeaponDamageEst;

    public Text WeaponManufactureInfo;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
