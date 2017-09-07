using UnityEngine;
using System.Collections;
using Assets;

[System.Serializable]
public class DemographicGroups : ScriptableObject
{
    public string GroupName;

   

    [Range(0.0f, 100.0f)]
    public float Population;

   
    public long  Numbers;

    [Range(-1.0f, 1.0f)]
    public float Happiness;

    [Range(-1.0f, 1.0f)]
    public float Anger;

    [Range(-1.0f, 1.0f)]
    public float Fear;
    public CountryRelationsFactory.CountryLegalStatus LawStatus;
}