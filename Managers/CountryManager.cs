using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets;
using System;
using UnityEngine.Events;
using System.Linq;
using WorldMapStrategyKit;

public class CountryManager : MonoBehaviour
{
    public GameAgent countryAmbassdor;
    public WMSK wmslObj;
    public List<DemographicGroups> CountryPopulationGroups;
    public List<PoliticalParties> CountryPoliticalParties;
    public List<CountryLaw> CountryLaws;
    public List<Deal> CountryDeals;
    private UnityAction CounterListener;
    private UnityAction UprisingListener;
    public CountryGovernment CountryGovernment;
    public CountryAgent countryAIAgent;
    public CountryRelationsFactory countryFactory;
    public CountryBudget countryBudget;
    public CountryMilitary countryMilitary;
    public List<CountrySectors> CountrySectors;
    public List<CountryToGlobalCountry.GenericCity> CountryCityControlList;
    public List<CountryToGlobalCountry.GenericProvince> CountryProvinceControlList;
    public List<CountryToGlobalCountry.GenericCountry> CountryGovernmentAlliesIndex;
    public List<float> CountryPopulationLikeAcrossProvincesIndex;
    public List<RebelGroup> GovernmentRebelGroups;
    public List<TerroristGroup> GovernmentTerroristGroups;
    public long CountryCash;

    public bool IsMasterPlayerManager;
    public CharacterManager countryCharacterGenerator;
    public WorldMapStrategyKit.Country WMSKCountry;


    public CountryManager()
    {

    }
    void OnEnable()
    {
        EventGenerator.StartListening("CheckForSubgroups", CounterListener);
        EventGenerator.StartListening("CheckForUprisings", UprisingListener);
    }

    void OnDisable()
    {
        EventGenerator.StopListening("CheckForSubgroups", CounterListener);
        EventGenerator.StopListening("CheckForUprisings", UprisingListener);
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

    public void CheckHistoryBias(CountryGovernment gov, float Value = 0)
    {
        switch (gov.GovernmnetBias)
        {
            case CountryRelationsFactory.CountryBias.westerndemocracy:
                break;
            case CountryRelationsFactory.CountryBias.europeandemocracy:
                break;
            case CountryRelationsFactory.CountryBias.europeansocialdemocracy:
                break;
            case CountryRelationsFactory.CountryBias.formersoviet:
                break;
            case CountryRelationsFactory.CountryBias.formersovietAuthoratian:
                break;
            case CountryRelationsFactory.CountryBias.formereuro:
                break;
            case CountryRelationsFactory.CountryBias.formercommonwealth:
                break;
            case CountryRelationsFactory.CountryBias.africanstable:
                break;
            case CountryRelationsFactory.CountryBias.africaninstable:
                break;
            case CountryRelationsFactory.CountryBias.notchinaAsian:
                break;
            case CountryRelationsFactory.CountryBias.chinaAndAllies:
                break;
            case CountryRelationsFactory.CountryBias.russiaAndAllies:
                break;
            case CountryRelationsFactory.CountryBias.islamStable:
                break;
            case CountryRelationsFactory.CountryBias.islamInstable:
                break;
            case CountryRelationsFactory.CountryBias.southamericandemocracy:
                break;
            case CountryRelationsFactory.CountryBias.southamericansocialist:
                break;
            case CountryRelationsFactory.CountryBias.superpower:
                break;
            case CountryRelationsFactory.CountryBias.regionalpower:
                break;
            case CountryRelationsFactory.CountryBias.citystateisland:
                break;
            case CountryRelationsFactory.CountryBias.civilwar:
                break;
            default:
                break;
        }
    }

    IEnumerator TriggerUprisingStart()
    {
        var map = FindObjectOfType<MapManager>();

        map.DebugText.text = string.Format("Uprising Staring in ", CountryGovernment.LocalNameOfGovernment);

        //decorsToFade.StartCoroutine(DoFade(3f));
        map.DebugText.text = "DEFCONE 1 MODE ON";

        yield return new WaitForEndOfFrame();
    }
    public void CheckForUprisings()
    {
        float likelyHoodOfUprising = 0;

        //lets see if the government did anything in the last day to caause a uprising event.
        var newUprising = CountryGovernment.GovernmentWorldHistory.FirstOrDefault(events => events.EventType == EventGenerator.WorldEventType.UprisingEvent);

        if (newUprising.IsUprisingEvent && !newUprising.HasEnded)
        {
            StartCoroutine("TriggerUprisingStart");
        }
        else
        {
            switch (CountryGovernment.CountryFreedomIndex)
            {
                case CountryRelationsFactory.CountryFreedomIndex.FullDemocracy:
                    CheckHistoryBias(CountryGovernment, likelyHoodOfUprising);
                    break;
                case CountryRelationsFactory.CountryFreedomIndex.FlawedDemocracy:
                    CheckHistoryBias(CountryGovernment, likelyHoodOfUprising);
                    break;
                case CountryRelationsFactory.CountryFreedomIndex.HybridRegime:
                    CheckHistoryBias(CountryGovernment, likelyHoodOfUprising);
                    break;
                case CountryRelationsFactory.CountryFreedomIndex.Authoritarian:
                    CheckHistoryBias(CountryGovernment, likelyHoodOfUprising);
                    break;
                default:
                    break;
            }
        }



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
                if (CountryPopulationGroups.Any(group =>
                {
                    if (group.Anger > 1f)
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
        CounterListener = new UnityAction(CheckForUprisings);
    }

    // Use this for initialization
    void Start()
    {
        wmslObj = WMSK.instance;
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

    public void ColorMasterPlayer()
    {
        StartCoroutine("ColorMasterPlayerCountry");
    }
    IEnumerator ColorMasterPlayerCountry()
    {
        WorldMapStrategyKit.CountryDecorator decorator = new WorldMapStrategyKit.CountryDecorator();
        decorator.isColorized = true;
        decorator.texture = Resources.Load<Texture2D>("DoV/UI/background_gradient");
        ColorUtility.TryParseHtmlString("#494560D6", out decorator.fillColor);
        wmslObj.decorator.SetCountryDecorator(0, CountryGovernment.MapLookUpName, decorator);

        yield return new WaitForEndOfFrame();
    }

}


