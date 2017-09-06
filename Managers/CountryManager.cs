using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets;
using System;
using UnityEngine.Events;
using System.Linq;

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
    public CountryMilitary countryMilitary;
    public List<CountryToGlobalCountry.GenericCity> CountryCityControlList;
    public List<CountryToGlobalCountry.GenericProvince> CountryProvinceControlList;
    public List<CountryToGlobalCountry.GenericCountry> CountryGovernmentAlliesIndex;
    public List<float> CountryPopulationLikeAcrossProvincesIndex;
    public List<RebelGroup> GovernmentRebelGroups;
    public List<TerroristGroup> GovernmentTerroristGroups;
    public long CountryCash;

    public CharacterManager countryCharacterGenerator;
    //public long 

    //public CountryBudget countryBudget;

    public CountryManager()
    {

    }
    void OnEnable()
    {
        EventGenerator.StartListening("CheckForSubgroups", CounterListener);
    }

    void OnDisable()
    {
        EventGenerator.StopListening("CheckForSubgroups", CounterListener);
    }

    public TerroristLeaderAgent CreateNewTerroristLeader(CountryToGlobalCountry.GenericProvince provinceHomeland)
    {
        var baseContact = countryCharacterGenerator.CreateCharacter(ContactGenerator.ContactType.terroristleader, CountryGovernment.MapLookUpName, provinceHomeland.name);

        var newLeader = new TerroristLeaderAgent()
        {

        };
        return newLeader;
    }
    public TerroristGroup CreateTerroristGroup(CountryToGlobalCountry.GenericProvince provinceHomeland)
    {

        var newLeader = CreateNewTerroristLeader(provinceHomeland);

        var newGroup = new TerroristGroup()
        {

        };

        return newGroup;
    }


    public RebelCommanderAgent CreateNewRebelLeader(CountryToGlobalCountry.GenericProvince provinceHomeland)
    {
        var baseContact = countryCharacterGenerator.CreateCharacter(ContactGenerator.ContactType.terroristleader, CountryGovernment.MapLookUpName, provinceHomeland.name);

        var newLeader = new RebelCommanderAgent()
        {

        };
        return newLeader;
    }
    public RebelGroup CreateRebelGroup(CountryToGlobalCountry.GenericProvince provinceHomeland)
    {

        var newLeader = CreateNewRebelLeader(provinceHomeland);

        var newGroup = new RebelGroup()
        {

        };

        return newGroup;
    }
    private void CreateSubGroup(Tuple<CountryToGlobalCountry.GenericProvince, float> province, CountryGovernment countryGovernment)
    {

       
        throw new NotImplementedException();
    }
   



    public int GetCityCrimeAverageIndexAcrossEmpire(List<CountryToGlobalCountry.GenericCity> CountryCityControlList)
    {
        return (int)CountryCityControlList.Average(e => e.CityCrimeIndex);
        //var
       //return this.GetCityCrimeAverageIndexAcrossEmpire.WeightedAverage(x => x.Value, x => x.Length);
    }

    public void CheckForNewSubgroup()
    {
        Debug.Log("Some Function was called!");
        var locaNewTerrorGroups = GovernmentTerroristGroups;
        var locaNewRebelGroups = GovernmentRebelGroups;

        CountryProvinceControlList.ForEach(province =>
        {
            //the first province to start the rebelltion!!!

            //if (province.Item1.ProvinceRebelControl == 100f)
            //{
            //    //the governmentis no longer in total countrol
            //    CountryGovernment.IsInTotalControlOfCountry = false;


            //    CreateSubGroup(province, CountryGovernment);
            //}
            //or quality of life in the province sucks so much they have no choice but to fight
            if (province.provinceEconomicDevelopment == 0)
            {

            }
            if (province.provinceHumanSecurity == 0)
            {

            }
            if (province.provinceRuleOfLaw == 0)
            {

            }
            if (province.provinceCulturalValue == 0)
            {

            }

            if (province.IsUprising && province.UprisingStarted && CountryGovernment.IsInTotalControlOfCountry)
            {
                //need to figure out which parties are forming rebel groups and who is becomeing a terrorist group
                //the politcal parties was made illegal or outlawed
                //MilitaryGovernmentTrustLevel
                //GovernmentMilitaryTrustLevel
                //PoliticalStablity
                //PoliticalCorruption
                //PopulationTrustLevel
                if (CountryPoliticalParties.Any(party =>
                {
                    if (party.LawStatus == CountryRelationsFactory.CountryLegalStatus.Illegal ||
             party.LawStatus == CountryRelationsFactory.CountryLegalStatus.Outlawed)
                    {
                        province.StartUpRisingEvent(province, party);
                    }
                    return false;
                }))
                {
                    //the poolitcal parties were made illegal now form a rebel group from them.
                }

                //if the demographics groups are afriad or angry enough to fight back
                if(CountryPopulationGroups.Any(group => {
                    if(group.Anger > 1f)
                    {
                        province.StartUpRisingEvent(province, group);
                    }
                    if (group.Fear > 1f)
                    {
                        province.StartUpRisingEvent(province, group);
                    }
                    return false;
                }))
                {
                   

                }

                

            }


        });

        if (locaNewTerrorGroups.Count() > GovernmentTerroristGroups.Count())
        {
            //CreateTerroristGroup(checkProvince);
        }

    }

   

    void Awake()
    {
        CounterListener = new UnityAction(CheckForNewSubgroup);
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
