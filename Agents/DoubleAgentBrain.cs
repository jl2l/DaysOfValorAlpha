using UnityEngine;
using System.Collections;
using Accord.MachineLearning;
using System.Data;
using System.Collections.Generic;
using Accord.MachineLearning.DecisionTrees;

public class DoubleAgentBrain : MonoBehaviour
{
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

    public DecisionTree CountrySelfInterest;
    public List<DataTable> dataTables = new List<DataTable>();
    public DecisionVariable[] attributes =
     {
        new DecisionVariable("Outlook", 3), // 3 possible values (Sunny, overcast, rain)
        new DecisionVariable("Temperature", 3), // 3 possible values (Hot, mild, cool)  
        new DecisionVariable("Humidity",    2), // 2 possible values (High, normal)    
        new DecisionVariable("Wind",        2)  // 2 possible values (Weak, strong) 
      };

    public void SetBrain()
    {


    }
}
