using UnityEngine;
using System.Collections;
using Assets;
using System.Collections.Generic;
using WorldMapStrategyKit;

[System.Serializable]
public class MilitaryBase : ScriptableObject
{

    public float BaseLong;
    public float BaseLat;
    [ContextMenuItem("GetBase Info", "GetFromMap")]

    public Vector2 BaseLocation;

    public Vector2 BaseProvinceLocation;
    public long BaseInProvinceIndex;
    public string BaseInProvinceName;
#if UNITY_EDITOR
    [Separator] public Separator s4;
#endif
    public long BaseInCountryIndex;

    public string BaseInCountryName;

    public string BaseInRegionName;
    
    public int BaseOwnerCountryIndex;

    private void GetFromMap()
    {
        var localMap = WMSK.instance;
       
      
        localMap.calc.fromLatDec = BaseLong;   // 40.71 decimal degrees north
        localMap.calc.fromLonDec = BaseLat;  // 74.00 decimal degrees to the west
        localMap.calc.fromUnit = UNIT_TYPE.DecimalDegrees;
        localMap.calc.Convert();
        var planeLocation = localMap.calc.toPlaneLocation;
        var provinceIndex = 0;
        var provinceRegionIndex = 0;

        var regionProvince = localMap.GetProvinceRegion(planeLocation);
       //localMap.GetProvinceRegionIndex(planeLocation, out provinceIndex, out provinceRegionIndex);
        BaseLocation = planeLocation;
        BaseProvinceLocation = regionProvince.center;

        BaseInProvinceIndex = regionProvince.entity.uniqueId;
        BaseInProvinceName = regionProvince.entity.name;
        BaseOwnerCountryIndex = localMap.GetCountryIndex(regionProvince.center);
        var c  = localMap.GetCountry(BaseOwnerCountryIndex);
        BaseInCountryName = c.name;
        BaseInCountryIndex = c.uniqueId;
        BaseInRegionName = c.continent;

    }
#if UNITY_EDITOR
    [Separator] public Separator s5;
#endif

    [Tooltip("The operational budget of the base comes from the MilitaryBudgetOperations")]
    public long BaseOperationalBudget;
    [Tooltip("The cost of operating the base per day, this pays soldiers, buys food, water and power, if a power has its own power this is reduced")]
    [Range(-100.0f, 100.0f)]
    public float BaseOperationDrainRate;
    [Tooltip("The total number of people on the base, this is the health of the base, if this number reaches zero the base is removed from the map")]
    public int BaseStrength;
    [Tooltip("The total number of aircraft which can be used to conduct airstikes")]
    public int BaseAircraftInOperation;
    [Tooltip("The total number of vehicles(air/land/sea) being repaired, depending on type of vehicle it will take X days to repair aircraft")]
    public int BaseVehicleRepair;
    [Range(0.0f, 100.0f)]
    public float BaseVehicleRepairRate;
    [Tooltip("The current number of missiles in storage on the base, this includes Surface to Surface and SAMs")]
    public int BaseMissileCurrentInventory;
    [Tooltip("The max number of missiles in storage on the base, this includes Surface to Surface and SAMs")]
    public int BaseMissileMaxInventory;
    [Tooltip("The total amount of ammo in tons availble to be used, when a base is being attacked the munitions will drain as the base repels attack. conducing military operations from the base also drains this")]
    public int BaseMuntionsTons;
    [Tooltip("The likelness the weapon will hit its target ")]
    public int BaseMuntionsMax;

    [Tooltip("The current amount of bombs in tons available for air strikes, each airstrike drains some of this ")]
    public int BaseAicraftMuntionsTons;
    [Tooltip("The total amount of bombs in tons available for air strikes, each airstrike drains some of this ")]
    public int BaseAircraftMuntionsMax;

    [Tooltip("The total number of RP available to base builder")]
    public int BaseResourcePoints;

#if UNITY_EDITOR
    [Separator] public Separator s6;
#endif
    public string BaseName;
    public GeneralAgent BaseCommander;
    public Texture2D BaseIcon;
    public Texture2D MilitaryCountryBattleFlag;
    public GameObject BaseMarker;
#if UNITY_EDITOR
    [Separator] public Separator s8;
#endif

    public MilitaryBaseFactory.BaseType GameBasetype;
    public List<MilitaryBaseFactory.BaseSpecialize> GameBaseSkills;
    public List<WeaponConfig> GameBaseWeapons;
    public List<MilitaryBaseFactory.BaseDefenses> GameBaseDefenses;
    public List<DeckDataItem> GameBaseDeck;
    public List<DoV_Vehicle> BaseAircraft;
    public List<StrategicWeapon> BaseStrategicWeapons;
#if UNITY_EDITOR
    [Separator] public Separator s9;
#endif


}
