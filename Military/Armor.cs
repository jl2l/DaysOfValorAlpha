using UnityEngine;
using System.Collections;
using Assets;
using System;

[Serializable]
public class Armor : ScriptableObject
{
    public string ArmorName;

    [Tooltip("Armor ratings there baseline multipliers ie plastic = 1, glass = 1 , aluminium = 2, iron = 3, steel = 5, titanium = 10, ceramic = 15, composite = 20, DU = 25 ")]
    public int ArmorRating; // Target Armour Value ((AP Power -Target Armour Value)/2)+1
    public ArmorType ArmorType;
    /// <summary>
    /// Armor ratings there baseline multipliers ie plastic = 1, glass = 1 , aluminium = 2, iron = 3, steel = 5, titanium = 10, ceramic = 15, composite = 20, DU = 25
    /// </summary>
    public int RHARating;
    public int CurrentArmorHP;
    public ArmorPosition Position;
    public bool IsSloped;
    public bool IsBoltOn;
    public bool HasSpallLiner;
    public bool IsSpaced;
    public bool IsSlat; //USE THESE IN GAME AS FLAG IF THEY BEEN USED OR NOT PER UNIT AS A BIT
    public bool IsElectricCharged; //one time defeats a incoming projectile afterwards it turns off and effect doesnt work
    public bool IsReactive; //one time defeats a incoming projectile afterwards it turns off and effect doesnt work
#if UNITY_EDITOR
    [Separator] public Separator APSSettings;
#endif
    public bool HasAPS;
    public int APSAmmo;

    [Range(0.0f, 100.0f)]
    public float APSRate;


    public APSType ApsType;
    public SensorSpectrum ApsSpectrum;
}
