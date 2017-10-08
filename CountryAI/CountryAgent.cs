using UnityEngine;
using System.Collections;
using Accord.MachineLearning;
using System.Data;
using Accord.MachineLearning.DecisionTrees;
using Accord.Statistics.Filters;
using Accord;
using Accord.Math;
using Accord.MachineLearning.DecisionTrees.Learning;
using System.Collections.Generic;
using System.ComponentModel;
using WorldMapStrategyKit;
using System;
using System.Linq;

public class CountryAgent : MonoBehaviour
{

    public enum CountryGoalPrimitive
    {
        ScieneGoal,
        TerritoryGoal,
        EconomicGoal,
        MilitaryGoal,
        LocalAgentGoal
    }
    public enum GoalPower
    {
        [Description("")]
        GeoPower,
        [Description("")]
        NaturalResourcesPower,
        [Description("")]
        PopulationPower,
        [Description("")]
        IndustrialDevelopedPower,
        [Description("")]
        NationalImage,
        [Description("")]
        PublicSupport,
        [Description("")]
        LeaderShip,
    }
    public class GoalPrimitive
    {
        CountryGoalPrimitive type;
        string GoalName;
        int GoalWeight;
        int GoalCost;
        bool GoalComplete;
        float GoalCompleteRemaining;
        string GoalTriggerName;
    }
    Helper localHelper;
    public GoalPrimitive Lastgoal;

    List<AgentBrain> LocalAgentsBrains;
    private GameManager lGm;
    string DebugOutput = "Im did nothing";

    int classCount = 2; // 2 possible output values for playing tennis: yes or no
                        // Use this for initialization
    void Awake()
    {
        lGm = FindObjectOfType<GameManager>();
        localHelper = new Helper();
        DeterminGoal();
        //data.Columns.Add("Day", "Outlook", "Temperature", "Humidity", "Wind", "PlayTennis");

        //data.Rows.Add("D1", "Sunny", "Hot", "High", "Weak", "No");
        //data.Rows.Add("D2", "Sunny", "Hot", "High", "Strong", "No");
        //data.Rows.Add("D3", "Overcast", "Hot", "High", "Weak", "Yes");
        //data.Rows.Add("D4", "Rain", "Mild", "High", "Weak", "Yes");
        //data.Rows.Add("D5", "Rain", "Cool", "Normal", "Weak", "Yes");
        //data.Rows.Add("D6", "Rain", "Cool", "Normal", "Strong", "No");
        //data.Rows.Add("D7", "Overcast", "Cool", "Normal", "Strong", "Yes");
        //data.Rows.Add("D8", "Sunny", "Mild", "High", "Weak", "No");
        //data.Rows.Add("D9", "Sunny", "Cool", "Normal", "Weak", "Yes");
        //data.Rows.Add("D10", "Rain", "Mild", "Normal", "Weak", "Yes");
        //data.Rows.Add("D11", "Sunny", "Mild", "Normal", "Strong", "Yes");
        //data.Rows.Add("D12", "Overcast", "Mild", "High", "Strong", "Yes");
        //data.Rows.Add("D13", "Overcast", "Hot", "Normal", "Weak", "Yes");
        //data.Rows.Add("D14", "Rain", "Mild", "High", "Strong", "No");

        //Codification codebook = new Codification(data);
        //DecisionTree tree = new DecisionTree(attributes, classCount);
        //// Create a new instance of the ID3 algorithm
        //ID3Learning id3learning = new ID3Learning(tree);

        //// Translate our training data into integer symbols using our codebook:
        //DataTable symbols = codebook.Apply(data); int[][] inputs = symbols.ToJagged<int>("Outlook", "Temperature", "Humidity", "Wind"); int[] outputs = symbols.ToJagged<int>("PlayTennis").GetColumn(0);

        //// Learn the training instances!
        //id3learning.Learn(inputs, outputs);

        //int[] query = codebook.Transform("Sunny", "Hot", "High", "Strong");

        //int output = tree.Decide(query);

        //string answer = codebook.Revert("PlayTennis", output); // answer will be "No".
    }

    public void DeterminGoal()
    {
        //WhereDoesMyPowerComeFrom();
    }

    public void DetermineGoalType() { }
    public void AssignLocalGameAgent() { }

    public float PopulationEducationLevel()
    {
        return 0;
    }
    public void CompareNeighbors(Country country, GoalPower compareGoal, CountryGoalPrimitive LastGoal, CountryGoalPrimitive CurrentGoal, out CountryGoalPrimitive NextCountryGoal)
    {
        var ImBiggerThenMyPeers = false;
        var countriesBigger = new List<Country>();
        NextCountryGoal = CountryGoalPrimitive.TerritoryGoal;
        switch (compareGoal)
        {
            case GoalPower.GeoPower:
                foreach (var countryIndex in country.neighbours)
                {
                    var compareCountry = lGm.GameMapManager.wmslObj.GetCountry(countryIndex);
                    if (compareCountry.regionsRect2DArea > country.regionsRect2DArea)
                    {
                        countriesBigger.Add(compareCountry);
                    }
                }
                // countriesBigger.Sort((country, compareCountry) => compareCountry.CompareTo(country));
                if (countriesBigger.Count == 0)
                {
                    DebugOutput += "I am a Regional or Superpower GEO Power";
                }
                else
                {
                    //determine the countrys that are bigger are 
                    foreach (var biggerCountries in countriesBigger)
                    {


                    }
                }
                NextCountryGoal = CountryGoalPrimitive.TerritoryGoal;

                break;
            case GoalPower.NaturalResourcesPower:
                break;
            case GoalPower.PopulationPower:
                break;
            case GoalPower.IndustrialDevelopedPower:
                break;
            case GoalPower.NationalImage:
                break;
            case GoalPower.PublicSupport:
                break;
            case GoalPower.LeaderShip:
                break;
        }




    }
    public void WhereDoesMyPowerComeFrom()
    {


        //does my power from from geo
        //how big is my country
        //"Geography": {
        //    "Location": {
        //        "text": "Northern Africa, bordering the Mediterranean Sea, between Morocco and Tunisia"
        //    },
        //"Geographic coordinates": {
        //        "text": "28 00 N, 3 00 E"
        //},
        //"Map references": {
        //        "text": "Africa"
        //},
        //"Area": {
        //        "total": {
        //            "text": "2,381,741 sq km"
        //        },

        //var localCountryManager = lGm.GameWorldManager.CountryPlayerManagerGameObject.GetComponent<CountryManager>();
        //var wmCountry = lGm.GameMapManager.wmslObj.GetCountry(localCountryManager.CountryGovernment.MapLookUpName);
        //  var getSizeKm = wmCountry.regionsRect2DArea;
        //if size is 

        //asse for each goal type
        foreach (var item in Enum.GetValues(typeof(GoalPower)).Cast<GoalPower>())
        {

        }
        //now rank my stuff

    }
    // Update is called once per frame
    void Update()
    {

    }
}
