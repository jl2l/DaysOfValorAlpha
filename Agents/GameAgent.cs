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
        DoubleAgent,
        Political,
        StateLeader,
        Scentist
    }





    public AgentOfType GameAgentType;

    // Use this for initialization of behaviors
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
            case AgentOfType.DoubleAgent:
                break;
            case AgentOfType.StateLeader:
                break;
            case AgentOfType.Political:
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
            case AgentOfType.DoubleAgent:
                break;
            case AgentOfType.Political:
                break;
            case AgentOfType.StateLeader:
                break;
        }
    }
}