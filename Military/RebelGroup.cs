using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets;

[System.Serializable]
public class RebelGroup : TerroristGroup
{
    CountryAgent RebelCountryAgent;
    RebelCommanderAgent RebelCommander;
    List<SectorManager.CountryResource> CountryResourcesUnderControl;

    List<DeckDataItem> RebelDecks;
    CountryGovernment RebelGovernment;

    PoliticalParties RebelPoliticalParty;

    List<PoliticalParties> RebelFactions;
    List<DemographicGroups> RebelSupporters;

    public DiplomatAgent RebelDiplomatAgent;



    public void TransitionFromTerrorGroupToRebelGroup() { }
    public void TransitionFromRebelGroupToStateGovernment() { }
}
