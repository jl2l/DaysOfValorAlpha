using UnityEngine;
using System.Collections;
using Assets;
using System.Collections.Generic;

[System.Serializable]
public class CountryLaw : ScriptableObject
{
    public string LawName;
    [TextArea(15, 20)]
    public string LawDescription;
    public CountryRelationsFactory.CountryLegalStatus LawStatus;
    public int LawCost;
    public List<LawEffect> LawEffects;
    public float LawEffectValue;

    public UprisingEvent LawUprisingEvent;
    public CulturalEvent CultralEvent;
    public NewsEvent NewsEvent;
    public DiplomaticEvent LawDiplomaticEvent;
    public enum LawEffect
    {
        IncreaseRuleOfLaw,
        IncreaseHumanSecurity,
        IncreaseEconomicDevelop,
        IncreaseCultureValue,
        DecreaseRuleOfLaw,
        DecreaseHumanSecurity,
        DecreaseEconomicDevelop,
        DecreaseCultureValue,
        IncreaseInternational,
        DecreaseInternational,
        PopulationWealth,
        PopulationHealth,
        Business,
        Trade,
        Tourism,
        Consumption,
        Mirgation,
        MoneyTransfers

    }

    public CountryBudget.CountryIncome LawEffectsBudget;
    public SectorManager.CountryResource LawOnResource;
    public PoliticalParties LawBanningParty;
    public DemographicGroups LawBanGroup;
}
