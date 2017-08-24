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
    public List<Tuple<CountryToGlobalCountry.GenericCity, float>> CountryCityControlList;
    public List<Tuple<CountryToGlobalCountry.GenericProvince, float>> CountryProvinceControlList;
    public List<Tuple<CountryToGlobalCountry.GenericCountry, float>> CountryGovernmentAlliesIndex;
    public List<Tuple<CountryToGlobalCountry.GenericCountry, float>> CountryPopulationLikeIndex;
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

    private void CreateSubGroup(Tuple<CountryToGlobalCountry.GenericProvince, float> province, CountryGovernment countryGovernment)
    {

        //MilitaryGovernmentTrustLevel
        //GovernmentMilitaryTrustLevel
        //PoliticalStablity
        //PoliticalCorruption
        //PopulationTrustLevel
        throw new NotImplementedException();
    }
   



    public float GetCityCrimeAverageIndexAcrossEmpire(List<CountryToGlobalCountry.GenericCity> CountryCityControlList)
    {
        return 0;
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

            if (province.Item1.ProvinceRebelControl == 100f && CountryGovernment.IsInTotalControlOfCountry)
            {
                //the governmentis no longer in total countrol
                CountryGovernment.IsInTotalControlOfCountry = false;
               

                CreateSubGroup(province, CountryGovernment);
            }


            if (province.Item1.IsUprising && province.Item1.UprisingStarted)
            {
                if (CountryPoliticalParties.Any(party =>
                {
                    if (party.LawStatus == CountryRelationsFactory.CountryLegalStatus.Illegal ||
             party.LawStatus == CountryRelationsFactory.CountryLegalStatus.Outlawed)
                    {
                        province.Item1.StartUpRisingEvent(province.Item1, party);
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
