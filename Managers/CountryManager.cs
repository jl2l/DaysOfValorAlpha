using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets;
using System;
using UnityEngine.Events;

public class CountryManager : MonoBehaviour
{
    public GameAgent countryAmbassdor;

    public List<DemographicGroups> CountryPopulationGroups;
    public List<PoliticalParties> CountryPoliticalParties;
    public List<CountryLaw> CountryLaws;
    private UnityAction CounterListener;
    public CountryGovernment CountryGovernment;
    public CountryAgent countryAIAgent;
    public CountryRelationsFactory countryFactory;
    public CountryBudget countryBudget;
    public List<Tuple<CountryToGlobalCountry.GenericCity, float>> CountryCityControlList;
    public List<Tuple<CountryToGlobalCountry.GenericProvince, float>> CountryProvinceControlList;
    public List<Tuple<CountryToGlobalCountry.GenericCountry, float>> CountryGovernmentAlliesIndex;
    public List<Tuple<CountryToGlobalCountry.GenericCountry, float>> CountryPopulationLikeIndex;
    public long CountryCash;
    //public long 

    //public CountryBudget countryBudget;

    public CountryManager()
    {

    }
    void OnEnable()
    {
        EventGenerator.StartListening("test", CounterListener);
    }

    void OnDisable()
    {
        EventGenerator.StopListening("test", CounterListener);
    }

    void SomeFunction()
    {
        Debug.Log("Some Function was called!");
    }
    
    void Awake()
    {
        CounterListener = new UnityAction(SomeFunction);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            if (CountryGovernment.IsMasterPlayer)
            {
                EventGenerator.TriggerEvent("test");
            }
          
        }
    }

    public void SetProvinceStats() { }
}
