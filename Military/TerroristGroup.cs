﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets;

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
    public float LocalRecruitRate;
    [Range(0f, 100.0f)]
    public float LocalLegitmacy;
    public CountryRelationsFactory.CountryBias CountryGravance;

    public List<CountryToGlobalCountry.GenericProvince> Controls;
    WorldMapStrategyKit.Region RebelCommandHQ;

    public List<WorldMapStrategyKit.Region> ControlledRegions;
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


    public Contact MedicalCommitee;
    public bool AutoGeneratedHeadOfMedical;
    public Contact PolitcalCommitee;
    public bool AutoGeneratedHeadOfPolitcal;
    public Contact JudicalCommitee;
    public bool AutoGeneratedHeadOfJudical;
    public Contact MilitaryCommitee;
    public bool AutoGeneratedHeadOfMilitary;
    public Contact MediaCommitee;
    public bool AutoGeneratedHeadOfMedi;
    public Contact MediaSpokesperson;
    public bool AutoGeneratedHeadOfMediaSpokesperson;
    public Contact FinanceCommitee;
    public bool AutoGeneratedHeadOFinance;
    public Contact ForeignRelationsCommitee;
    public bool AutoGeneratedHeadOfForeignRelations;

    public void FactureProvince() { }
    public void ConductionOperations() { }
    public void SetTerroristGoals() { }
    public void RecruitPeople() { }
    public void GetFunding() { }
}
