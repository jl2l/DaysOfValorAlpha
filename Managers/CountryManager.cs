using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets;
using System;

public class CountryManager : MonoBehaviour
{
    public GameAgent countryAmbassdor;

    public List<DemographicGroups> CountryPopulationGroups;
    public List<PoliticalParties> CountryPoliticalParties;
    public List<CountryLaw> CountryLaws;

    public CountryGovernment CountryGovernment;
    public CountryAgent countryAIAgent;
    public CountryRelationsFactory countryFactory;
    public List<Tuple<CountryToGlobalCountry.GenericCity, float>> CountryCityControlList;
    public List<Tuple<CountryToGlobalCountry.GenericProvince, float>> CountryProvinceControlList;
    public List<Tuple<CountryToGlobalCountry.GenericCountry, float>> CountryGovernmentAlliesIndex;
    public List<Tuple<CountryToGlobalCountry.GenericCountry, float>> CountryPopulationLikeIndex;


    //public CountryBudget countryBudget;

    public CountryManager() {

    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetProvinceStats() { }
}
