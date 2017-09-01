using UnityEngine;
using System.Collections;
using Assets;
using System.Collections.Generic;
using System.ComponentModel;

[System.Serializable]
public class StrategicWeapon : ScriptableObject
{
    public WarheadType WarheadType;
    public WeaponPerks WeaponPerks;
    public WeaponRangeClass WeaponRange;
    public WMDType WMDtype;
    public PlatformBase Platform;

    public string WeaponName;
    public string WeaponDescription;

    public bool IsDirtyBomb;
    public bool IsBioWeapon;
    public bool IsChemicalWeapon;
    public bool HasEMP;
    public bool IsMIRV;
    public bool IsCruiseMissile;
    public bool IsHypersonic;
    public bool IsStrategicBomber;

    public int Decoys;
    public int Warheads;
    public int MaxWarheads;

    public long MaxRange;
    public float DeliveryTime;
    public float AvgSpeed;

    public int EffectDuration;
    public float BlastRadius;
    public List<DoV_Vehicle> DeliveryVehicle;
    public List<Weapon> StrategicWeapons;
}