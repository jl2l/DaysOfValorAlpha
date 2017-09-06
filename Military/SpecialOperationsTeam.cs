using UnityEngine;
using System.Collections;
using Assets;
using System.Collections.Generic;

[System.Serializable]
public class SpecialOperationsTeam : ScriptableObject
{
    public class Gear
    {
        public string GearName;
        public KitValueType GearPerkType;
        [Range(-100.0f, 100.0f)]
        public float GearValue;

    }

    public class TeamKits
    {
        public string Name;
        public Weapon Gun;
        public KitType Kit;
        public float KitsKillSight;
        public float KitGunHitRate;
        public float KitHealthHP;
        public List<Gear> Gear; 
    }

    public enum KitValueType
    {
        Armor,
        GunAccurancy,
        KillSight
    }

    public enum KitType
    {
        Sniper,
        Assault,
        Medic,
        DMR,
        SAW,
        Grenadier,
        Nco,
        SquadLeader

    }
    public enum TeamSpecialization
    {
        DirectCombat,
        PoliceAction,
        CounterTerrorism,
        CombatDiving,
        Paratrooper,

    }

    public class Operator
    {
        public Contact Teammate;
        public TeamKits Kit;
    }

    public float UnitExp;
    public int UnitMissionsComplete;
    public float UnitHealth;
    public float UnitMorale;
    public int UnitSize;

    public Texture2D TeamFlag;
    public Texture2D Insigna;
    public string TeamName;
    public List<TeamSpecialization> Skill;

    public List<Operator> TeamSquad;
    public Contact TeamCommander;
}

