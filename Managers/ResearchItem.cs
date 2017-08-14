using UnityEngine;
using System.Collections;
using Assets;
using System.Collections.Generic;

[System.Serializable]
public class ResearchItem : ScriptableObject
{
    public string ResearchName;
    public string ResearchDescription;
    public Texture2D ResearchIcon;
    public ResearchManager.ResearchSector ResearchSector;

    public List<Weapon> UnlockWeapons;
    public List<Sensor> UnlockSensors;
    
    public bool IsResearchKnownToPlayer;

    public float ResearchPoints;

    public ResearchItem ParentResearch;
    public List<ResearchItem> ChildrenResearch;
}