using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResearchManager : MonoBehaviour
{

    public enum ResearchPriority
    {
        Low,
        Normal,
        High,
        Critical
    }

    public enum ResearchSector
    {
        Aerospace,
        Cyber,
        Green,
        Manufacture,
        Materials,
        Military,
        Missile,
        Nuclear,
        Robotics,
        Space

    }


    //how many points per day they spend on research
    public int PlayerResearchPerDayCapacity;
    public float PlayerResearchTotal;

    //the increase or decrease per day in RP
    public float PlayerResearchDailyGain;
    public GameObject ResearchContainer;


    public List<CountryToGlobalCountry.GenericCountryInfrastructure> ResearchInfrastructure;


    public List<ResearchProjectInfo> CurrentResearch;

    public List<ResearchItem> GameAllPlayerKnownResearch;
    public Dictionary<ResearchAgent, bool> ResearchAgentState; //either researching or not


    /// <summary>
    /// the total number of research centers in the country able to do government research
    /// </summary>
    public List<ResearchAgent> ResearchersAgents;

    public void AddNewResearchToList(GameObject addTo, ResearchItem rs)
    {
        var researchItem = new GameObject(string.Format("{0}_Ingame", rs.ResearchName));
        var newData = researchItem.AddComponent<ResearchProjectInfo>();
        newData.ResearchItem.IsResearchKnownToPlayer = true;
        newData.ResearchItem = rs;
        newData.Set(this);
        researchItem.transform.SetParent(addTo.transform);
    }

    public void SetResearchFromCountry(List<ResearchItem> startingResearch, CountryGovernment gov)
    {
        GameAllPlayerKnownResearch = startingResearch;
        startingResearch.ForEach(rs =>
        {
            var researchItem = new GameObject(string.Format("{0}_{1}", rs.ResearchName, gov.MapLookUpName));
            var newData = researchItem.AddComponent<ResearchProjectInfo>();
            newData.ResearchItem = rs;
            newData.ResearchItem.IsResearchKnownToPlayer = true;
            newData.Set(this);
            researchItem.transform.SetParent(ResearchContainer.transform);
        });

        //FindObjectOfType<GraphRenderer>().DrawGraph();
        //ResearchContainer.transform 

    }

    public void UpdateResearchProgressForDay()
    {

    }


    public void AssignAgentToResearchItem()
    {

    }

    public ResearchAgent GenerateResearchAgent()
    {
        return new ResearchAgent();
    }

    // Use this for initialization
    void Start()
    {
        //get to total of the research points from infrastructure
        //get the agents

    }

    // Update is called once per frame
    void Update()
    {

    }
}
