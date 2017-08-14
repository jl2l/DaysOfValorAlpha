using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResearchManager : MonoBehaviour
{
    public enum ResearchSector
    {
        CommericalTier1,
        CommericalTier2,
        CommericalTier3,
        EnergyGreen,
        EnergyNuclear,
        EnergyFuel,
        MilitaryLand,
        MilitarySea,
        MilitaryAir,
        ScienceBio,
        ScienceComputer,
        ScienceMeta
    }

    List<ResearchItem> ReseatchItems;
    public Dictionary<ResearchItem, bool> ResearchUnlocks { get; set; }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
