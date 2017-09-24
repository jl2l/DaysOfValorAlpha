using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets;
using WorldMapStrategyKit;
using System.Linq;

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
        public string NavalGroupNam;
        public List<DoV_Vehicle> Ships;

        public Vector2 HomePortLocation;

        [ContextMenuItem("Set World Map", "SetMap")]
        public string HomePortName;
        public long HomePortCityIndex;

        public Vector2 ForeignPortLocation;
        public string ForeignPortName;
        public long ForeignPortCityIndex;

        public bool IsSpecialOperations;

        public GeneralAgent NavalCommander;

        public void SetMap()
        {
            var localMap = WMSK.instance;

            var city = localMap.cities.FirstOrDefault(e => e.name == HomePortName);
            var foreginport = localMap.cities.FirstOrDefault(e => e.name == ForeignPortName);
            if (city != null)
            {
                HomePortLocation = city.unity2DLocation;
                HomePortCityIndex = city.uniqueId;

            }
            if (foreginport != null)
            {
                ForeignPortLocation = foreginport.unity2DLocation;
                ForeignPortCityIndex = foreginport.uniqueId;
            }
        }
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
    public List<SpecialOperationsTeam> CountrySpecialOperations;
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
    public int ConscriptionAge;
    [Tooltip("In months")]
    public int ConscriptionLength;
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
