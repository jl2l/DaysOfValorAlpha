using UnityEngine;
using System.Collections;
using Assets;

[System.Serializable]
public class CountryLaw : ScriptableObject
{
    public string LawName;
    [TextArea(15, 20)]
    public string LawDescription;
    public CountryRelationsFactory.CountryLegalStatus LawStatus;
    public int LawCost;
    public LawEffect LawEffects;

    public enum LawEffect {
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

    }

    public CountryBudget LawEffectsBudget;
    public SectorManager.CountryResource LawOnResource;
    public PoliticalParties LawBanningParty;
    public DemographicGroups LawBanGroup;
}
