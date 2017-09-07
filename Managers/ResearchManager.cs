using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResearchManager : MonoBehaviour
{
    public enum ResearchSector
    {
      Aerospace,
      Energy,
      Military,
      DualUse,
      Commerical,
      Biotech,

    }

    public List<ResearchItem> GameResearchItems;
    public Dictionary<ResearchItem, bool> PlayerResearchUnlocks { get; set; }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
