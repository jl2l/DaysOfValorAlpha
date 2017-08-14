using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
    public class TerroristGroup : ScriptableObject
    {

    public TerroristLeaderAgent Leader;
    public string GroupName;
    public int GroupMembers;
    public long OperationBuget;
    public float OperationCost;
    public float ThreatLevel;
    public int ViolenceIndex;
    public int Cells;
    [Range(0f, 100.0f)]
    public float LocalLegitmacy;
    public List<CountryToGlobalCountry.GenericProvince> Controls;
    [Tooltip(" more relgious - more secular +")]
    [Range(-100f, 100.0f)]
    public float Idealogy;

    public bool IsActive;
    public bool IsLeaderDead;
    public bool IsStateGroup;
    public List<CountryToGlobalCountry.GenericCountry> Patrons;
    public bool UsesBombings;
    public bool UsesLoneWolfs;
    public bool UsesGunAttacks;
    public bool UsesKnifeAttacks;
    public bool UsesIEDAttacks;
    public bool UsesSucideAttacks;
    public bool HasChemicalWeapons;
    public bool HasBioWeapons;
    public bool HasNuclearMaterial;
    public bool HasNuclearBomb;

}
