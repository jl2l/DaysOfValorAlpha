using UnityEngine;
using System.Collections;
using Assets;

[System.Serializable]
public class PoliticalParties : ScriptableObject
{
    public string PartyName;
    /// <summary>
    /// ie (R) or (CDP) or (UKIP) etc
    /// </summary>
    public string PartySymbol;
    public float PowerPercent;
    public float Opinion;
    public CountryRelationsFactory.CountryLegalStatus LawStatus;
}