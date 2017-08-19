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