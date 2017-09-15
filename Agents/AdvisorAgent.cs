using UnityEngine;
using System.Collections;
using Assets;

public class AdvisorAgent : Contact
{

    /// <summary>
    /// How much influence does this person have in the government and population at large
    /// </summary>
    public enum AdvisorType
    {
        Military,
        Science,
        Cultural,
        Economic,
        Political,
        Inteligence,
        Trade
    }

    public AdvisorType Advisor;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
