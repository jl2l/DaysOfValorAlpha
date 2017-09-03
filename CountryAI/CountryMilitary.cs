using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets;

[System.Serializable]
public class CountryMilitary : ScriptableObject
{

    [System.Serializable]
    public class MilitaryInventory
    {
        public DoV_Vehicle Vehicle;
        public int Inventory;
    }

    [System.Serializable]
    public class NavalGroup
    {
        public List<DoV_Vehicle> Ships;
        public GeneralAgent NavalCommander;
    }

    public GameAgent.AgentOfType General;

    public CountryToGlobalCountry.GenericCountry CountryMilitaryOf;

    public List<DoV_Vehicle> DomesticProduction;

    public List<DoV_Vehicle> NavyShips;

    public List<MilitaryBase> MilitaryBases;

    public List<NavalGroup> CountryMilitaryNavy;


    public List<DeckDataItem> CountryMilitaryUnits;


    public List<MilitaryInventory> CountryMilitaryInventory;
    public List<StrategicWeapon> CountryStrategicForces;

    List<MilitaryAction> MilitaryActionList;
    public Texture2D MilitaryCountryBattleFlag;
    public int WarsWon;
    [Tooltip("Divided among the officer corps")]
    public long CollectMilitaryBattleExp;
    public long MilitaryIndustrialCapacity;

    public float MilitaryBudgetProcurement;
    public float MilitaryBudgetOperations;
    [Range(0.0f, 100.0f)]
    public float MilitaryBudgetSpendingRateOperations;

    public string MilitaryName;
    public bool HasNavy;
    public string NavyName;
    public bool HasAirForce;
    public string AirForceName;
    public bool HasArmy;
    public string ArmyName;
    public bool HasMarines;
    public string MarinesdName;
    public bool HasNationalGuard;
    public string NationalGuardName;
    public bool HasAirGuard;
    public string AirGuardName;
    public bool HasCoastGuard;
    public string CoastGuardName;

    public bool HasSpecialForces;
    public bool HasConscripts;
    [Range(0.0f, 100.0f)]
    public float Professionalism;
    [Range(0.0f, 100.0f)]
    public float RecruitmentRate;

    public long SpecialOperations;
    public long OfficerCorps;
    public long Manpower;
    public bool NuclearPower;
    public int NuclearWarhead;

}
