using UnityEngine;
using System.Collections;
using Accord.MachineLearning;

public class GameAgent : MonoBehaviour
{
    public enum AgentOfType
    {

        Advisor,
        Combatant,
        Diplomat,
        General,
        Intel,
        Rebel,
        Terrorist,
        Compromised,

    }


    //this will consume all the events that happen to a agent, it will group them into groups which will have a limit in terms of the events once they go over a certain thre
    //threshold the behavior will change;

    GaussianMixtureModel GameAgentEscalationThreshold;
    RANSAC<GaussianMixtureModel> GameAgentHistoricThreshold;

    //RANSAC is used to filter out variables we dont care about from Agent interactions
    public RANSAC<GeneralAgent> GameGeneralAgent;
    public RANSAC<AdvisorAgent> GameAdvisorAgent;
    public RANSAC<DiplomatAgent> GameDiplomatAgent;
    public RANSAC<IntelAgent> GameIntelAgent;
    public RANSAC<RebelCommanderAgent> GameRebelCommanderAgent;
    public RANSAC<TerroristLeaderAgent> GameTerroristLeaderAgent;


    public AgentOfType GameAgentType;

    // Use this for initialization
    void Start()
    {
        switch (GameAgentType)
        {
            case AgentOfType.Advisor:
                break;
            case AgentOfType.Combatant:
                break;
            case AgentOfType.Diplomat:
                break;
            case AgentOfType.General:
                break;
            case AgentOfType.Intel:
                break;
            case AgentOfType.Rebel:
                break;
            case AgentOfType.Terrorist:
                break;
            case AgentOfType.Compromised:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

        switch (GameAgentType)
        {
            case AgentOfType.Advisor:
                break;
            case AgentOfType.Combatant:
                break;
            case AgentOfType.Diplomat:
                break;
            case AgentOfType.General:
                break;
            case AgentOfType.Intel:
                break;
            case AgentOfType.Rebel:
                break;
            case AgentOfType.Terrorist:
                break;
            case AgentOfType.Compromised:
                break;
        }
    }
}