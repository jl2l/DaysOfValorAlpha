
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using UnityEngine;
using WorldMapStrategyKit;
using static CountryToGlobalCountry;
using WorldGlobe = WPM;

#pragma warning disable 0168 // variable declared but not used.
#pragma warning disable 0219 // variable assigned but not used.
#pragma warning disable 0414 // private field assigned but not used.
namespace Assets
{
    public class CountryRelationsFactory
    {

        public WMSK map = WMSK.instance;

        public List<Country> BaseCountryList()
        {
            return map.countries.ToList();
        }


        public enum CountryLegalStatus
        {
            Legal,
            Illegal,
            Unlimited,
            SomeRestrictions,
            Restricted,
            Permitted,
            NotPermitted,
            InPower,
            Outlawed,
        }

        public string[] G20ListStrings =
        {
            "Argentina", "Australia", "Brazil", "Canada", "China", "France", "Germany",
            "India", "Indonesia", "Italy", "Japan", "South Korea", "Mexico", "Russia", "Saudi Arabia", "South Africa",
            "Turkey", "United Kingdom", "United States of America"
        };

        private WorldGlobe.WorldMapGlobe globe;

        public List<Country> BaseG20Countries()
        {
            return G20ListStrings.Select(cname => map.GetCountry(cname)).ToList();
        }


        public Dictionary<Country, int> DiplomaticRelationsListDefault()
        {
            return map.countries.ToDictionary(country => country, country => 50);
        }

        //public JsonDataCountry.CountryGovernment DefaultCountryGovernment()
        //{
        //    return DefaultTime().FirstOrDefault(e => e.NameOfGovernment == "United States of America");
        //}

        //public CountryMilitaryForce DefaultCountryMilitaryForce()
        //{
        //    return CountryMilitaryFactory.BuildMockForce(DefaultCountryGovernment());
        //}

        public enum CountryMinstries {
           Military,
        State,
        Internal,
        Trade,
        Justice,
        Research,
        Intel,
        Culture,
        Education,
        Energy,
        Health,
        Environment,
        Agriculture,
        StatePolice,
        StateSecertService,
        Population,
                             
    }  
        [SerializeField]
        public enum CountrySpokeLanguage
        {
            Chinese,
            English,
            Spainish,
            Hindi,
            Arabic,
            Malay,
            French,
            Russian,
            Japanese,
            Bengali,
            Portuguese,
            German,
            Punjabi,
            Korean

        }

        [SerializeField]
        public enum CountryPerkSkill
        {
            Superpower = 0,
            RegionalPower = 1,
            EconomicJuggernaught = 2,
            RegionalSpolier = 3,
            NeutrialPower = 4,
            SafeHaven = 5,
            CulturalNexus = 6,
            OldWorldPower = 7,
            PopulationBoom = 8,
            InventorInovator = 9,
            AbundantNaturalResources

        }
        [SerializeField]
        public enum CountryFlawSkill
        {
            DrugProblems = 0,
            LandLocked,
            ClimateVunerable,
            ClimateHeat,
            ClimateFlooding,
            Overpopulated,
            Underpopulated,
            HeavyNationalDebt,

        }
        [SerializeField]
        public enum BudgetSize
        {
            trillion = 0,
            billion = 1,
            million = 2,
            unknown = 4
        }

        public List<DiplomaticEvent> CreateDefaultHistoryWithPlayer(string countryName, string playerName)
        {
            var tempHistory = new List<DiplomaticEvent>();

            return tempHistory;
        }
        public List<DiplomaticEvent> CreateHistoryWithPlayer(string countryName, string playerName)
        {
            var tempHistory = new List<DiplomaticEvent>();
            try
            {

                var tempEvent = new DiplomaticEvent();

                //tempEvent.DiplomaticEventDescription = "Allied During World War 2";
                //tempEvent.DiplomaticEventName = "World War 2";
                //tempEvent.EventPolitcalCapitalCost = 30;
                //tempEvent.GainLost = true;
                //tempEvent.EventType = DiplomaticEvent.DiplomaticEventType.HistoryItem;
                //tempEvent.HostCountry = map.GetCountry(countryName);
                //tempEvent.OfferCountry = map.GetCountry(playerName);

                tempHistory.Add(tempEvent);

                var tempEvent2 = new DiplomaticEvent();

                //tempEvent2.DiplomaticEventDescription = "Allied During Vietnam";
                //tempEvent2.DiplomaticEventName = "Vietnam War";
                //tempEvent2.EventPolitcalCapitalCost = 10;
                //tempEvent2.GainLost = true;
                //tempEvent2.EventType = DiplomaticEvent.DiplomaticEventType.HistoryItem;
                //tempEvent2.HostCountry = map.GetCountry(countryName);
                //tempEvent2.OfferCountry = map.GetCountry(playerName);

                tempHistory.Add(tempEvent2);

            }
            catch (Exception i)
            {

                var g = countryName;
            }




            return tempHistory;
        }

        [SerializeField]
        /// </summary>
        public enum CountryGovernmentTypes
        {
            [Description("a form of government where the monarch rules unhindered, i.e., without any laws, constitution, or legally organized oposition.")]
            AbsoluteMonarchy = 0,
            [Description("a condition of lawlessness or political disorder brought about by the absence of governmental authority.")]
            Anarchy = 1,
            [Description("a form of government in which state authority is imposed onto many aspects of citizens' lives.")]
            Authoritarian = 2,
            [Description("a nation, state, or other political entity founded on law and united by a compact of the people for the common good.")]
            Commonwealth = 3,
            [Description("a system of government in which the state plans and controls the economy and a single - often authoritarian - party holds power; state controls are imposed with the elimination of private ownership of property or capital while claiming to make progress toward a higher social order in which all goods are equally shared by the people")]
            Communist = 4,
            [Description(" a union by compact or treaty between states, provinces, or territories, that creates a central government with limited powers; the constituent entities retain supreme authority over all matters except those delegated to the central government.")]
            Confederacy = 5,
            [Description("a government by or operating under an authoritative document (constitution) that sets forth the system of fundamental laws and principles that determines the nature, functions, and limits of that government.")]
            Constitutional = 6,
            [Description("a form of government in which the sovereign power of the people is spelled out in a governing constitution.")]
            ConstitutionalDemocracy = 7,
            [Description("a form of government in which the supreme power is retained by the people, but which is usually exercised indirectly through a system of representation and delegated authority periodically renewed.")]
            ConstitutionalMonarchy = 8,
            [Description("a state in which the supreme power rests in the body of citizens entitled to vote for officers and representatives responsible to them.")]
            Democracy = 9,
            [Description(" a form of government in which a ruler or small clique wield absolute power(not restricted by a constitution or laws).")]
            DemocraticRepublic = 10,
            [Description("a state in which the supreme power rests in the body of citizens entitled to vote for officers and representatives responsible to them.")]
            Dictatorship = 11,
            [Description("a government administrated by a church.")]
            Ecclesiastical = 12,
            [Description("similar to a monarchy or sultanate, but a government in which the supreme power is in the hands of an emir (the ruler of a Muslim state); the emir may be an absolute overlord or a sovereign with constitutionally limited authority.")]
            Emirate = 13,
            [Description("a form of government in which sovereign power is formally divided - usually by means of a constitution - between a central authority and a number of constituent regions(states, colonies, or provinces) so that each region retains some management of its internal affairs; differs from a confederacy in that the central government exerts influence directly upon both individuals as well as upon the regional units.")]
            Federal = 14,
            [Description("a state in which the powers of the central government are restricted and in which the component parts (states, colonies, or provinces) retain a degree of self-government; ultimate sovereign power rests with the voters who chose their governmental representatives.")]
            FederalRepublic = 15,
            [Description("a particular form of government adopted by some Muslim states; although such a state is, in theory, a theocracy, it remains a republic, but its laws are required to be compatible with the laws of Islam.")]
            IslamicRepublic = 16,
            [Description("a government in which the supreme power is lodged in the hands of a monarch who reigns over a state or territory, usually for life and by hereditary right; the monarch may be either a sole absolute ruler or a sovereign -such as a king, queen, or prince -with constitutionally limited authority.")]
            Monarchy = 17,
            [Description("a government in which control is exercised by a small group of individuals whose authority generally is based on wealth or power.")]
            Oligarchy = 18,
            [Description("a political system in which the legislature (parliament) selects the government - a prime minister, premier, or chancellor along with the cabinet ministers - according to party strength as expressed in elections; by this system, the government acquires a dual responsibility: to the people as well as to the parliament.")]
            ParliamentaryDemocracy = 19,
            [Description("a government in which members of an executive branch (the cabinet and its leader - a prime minister, premier, or chancellor) are nominated to their positions by a legislature or parliament, and are directly responsible to it; this type of government can be dissolved at will by the parliament (legislature) by means of a no confidence vote or the leader of the cabinet may dissolve the parliament if it can no longer function. ")]
            ParliamentaryGovernment = 20,
            [Description("Presidential - a system of government where the executive branch exists separately from a legislature (to which it is generally not accountable)")]
            Presidential = 21,
            [Description("a representative democracy in which the people's elected deputies (representatives), not the people themselves, vote on legislation.")]
            Republic = 22,
            [Description("a government in which the means of planning, producing, and distributing goods is controlled by a central government that theoretically seeks a more just and equitable distribution of property and labor; in actuality, most socialist governments have ended up being no more than dictatorships over workers by a ruling elite.")]
            Socialism = 23,
            [Description("similar to a monarchy, but a government in which the supreme power is in the hands of a sultan (the head of a Muslim state); the sultan may be an absolute ruler or a sovereign with constitutionally limited authority")]
            Sultanate = 24,
            [Description("a form of government in which a Deity is recognized as the supreme civil ruler, but the Deity's laws are interpreted by ecclesiastical authorities (bishops, mullahs, etc.); a government subject to religious authority.")]
            Theocracy = 25,
            [Description("a government that seeks to subordinate the individual to the state by controlling not only all political and economic matters, but also the attitudes, values, and beliefs of its population.")]
            Totalitarian = 26,
            [Description("a form of government in which state authority is imposed onto many aspects of citizens' lives, subvertly while maintaing the democractic processes.")]
            AuthoritarianDemocracy = 27,
        }

        [SerializeField]
        /// <summary>
        /// Country Bias will determine how the country allign themsevles, at the start of the game, the basic idea is this will determine the diplomat stanse at the begining
        /// </summary>
        /// 
        public enum CountryBias
        {
            westerndemocracy, // US UK Canda Australia
            europeandemocracy, // France  Germany
            europeansocialdemocracy, //Denmark Sweden
            formersoviet, //Poland
            formersovietAuthoratian, //DPRK Belarus
            formereuro, //India Aruba
            africanstable, //South Africa Ethopia Kenya
            africaninstable, //Chad Mali Somlia
            notchinaAsian, //Japan Korea 
            chinaAndAllies, // China Pakistan
            russiaAndAllies,
            islamStable,
            islamInstable,
            southamericandemocracy,
            southamericansocialist,
            superpower, //the US EU merging of the governments
            regionalpower,
            citystateisland, //singapore vacitcan 
            civilwar // the countries bias is up in the are due to a ongoing civil war, this can be inposed on a country and is for Syria Ukraine etc
        }


        public string GovernmentMNameBias(CountryBias countryBias, string branchType)
        {

            string MName = string.Empty;
            switch (countryBias)
            {

                default:
                    MName = "Minstry";
                    break;
            }

            return string.Format("{0} of {1}", countryBias, branchType);
        }

        public string GovernmentHeadOfMilitaryTitleNameBias(CountryBias countryBias, string countryName)
        {

            string MName = string.Empty;
            switch (countryBias)
            {
                case CountryBias.europeandemocracy:

                    MName = "Minstry of Defense";
                    break;
                default:
                    MName = "Depart of Defense";
                    break;
            }

            return string.Format("{0} of {1}", MName, countryName);
        }
        public string GovernmentHeadOfEconomicTitleNameBias(CountryBias countryBias, string countryName)
        {

            string MName = string.Empty;
            switch (countryBias)
            {
                case CountryBias.europeandemocracy:

                    MName = "Minstry of Finiance";
                    break;
                default:
                    MName = "Depart of Treasury";
                    break;
            }

            return string.Format("{0} of {1}", MName, countryName);
        }
        public string GovernmentHeadOfPopulationTitleNameBias(CountryBias countryBias, string countryName)
        {

            string MName = string.Empty;
            switch (countryBias)
            {
                case CountryBias.europeandemocracy:

                    MName = "Minstry of Justice";
                    break;
                default:
                    MName = "Depart of Justice";
                    break;
            }

            return string.Format("{0} of {1}", MName, countryName);
        }
        public string GovernmentHeadOfStateTitleNameBias(CountryBias countryBias, string countryName)
        {

            string MName = string.Empty;
            switch (countryBias)
            {
                case CountryBias.europeandemocracy:

                    MName = "Prime Minister";
                    break;
                default:
                    MName = "President";
                    break;
            }

            return string.Format("{0} of {1}", MName, countryName);
        }



        //public CountryGovernment BuildGovernment(JsonCountryCIAModel.CountryCiaDbObject jsonCIAUnit = null, Tuple<CountryRelationsFactory.CountryBias, string, string[], CountryRelationsFactory.CountryGovernmentTypes> governmentBias = null, bool BuildMilitary = false)
        //{
        //    CharacterGeneratorManager cgm = new CharacterGeneratorManager();
        //    GlobalWarGameDbContext gwDb = new GlobalWarGameDbContext();
        //    GlobalWarGameMilitaryDBData gwMilitaryDBb = new GlobalWarGameMilitaryDBData();
        //    globe = WorldGlobe.WorldMapGlobe.instance;
        //    var ContactOfMilitary = new Contacts();
        //    var ContactOfEconomic = new Contacts();
        //    var ContactOfAmbassdor = new Contacts();
        //    var ContactOHeadOfState = new Contacts();
        //    var TitleOfLeader = string.Empty;
        //    var TitleOfMilitaryLeader = string.Empty;
        //    var TitleOfEconomicLeader = string.Empty;
        //    var TitleOfPopulationLeader = string.Empty;
        //    var CountryName = jsonCIAUnit.CountryName = jsonCIAUnit.Government.GovernmentShortName;
        //    var biasLevel = 0;

        //    var sumMilitaryPowerIndex = 0;
        //    var sumEconomicPowerIndex = 0;
        //    var sumPoliticalStabilityIndex = 0;
        //    var sumTechLevel = 0;
        //    var sumSoftPowerLevel = 0;

        //    Country countryMapData = null;
        //    try
        //    {

        //        //Military
        //        /// military power is a base of military budget
        //        /// miitary man power how many people total and available for military service
        //        /// Combat RDT&E institutions quality of forces
        //        /// Defense industrial base ability to make hardware without other countries
        //        /// military infrastructure number of bases and military access
        //        /// inventory and support how many tanks bombers etc
        //        /// 1 to 100 35 points are from budget is more then 1 billion dollars it 10 
        //        /// 
        //        //var countryMilitaryData = gwMilitaryDBb.GetMilitaryData(CountryName);




        //        var countryBias = (CountryBias)governmentBias.Item1;
        //        TitleOfLeader = GovernmentHeadOfStateTitleNameBias(countryBias, CountryName);
        //        TitleOfMilitaryLeader = GovernmentHeadOfMilitaryTitleNameBias(countryBias, CountryName);
        //        //    TitleOfEconomicLeader = GovernmentHeadOfEconomicTitleNameBias(countryBias, CountryName);
        //        //    TitleOfPopulationLeader = GovernmentHeadOfPopulationTitleNameBias(countryBias, CountryName);
        //        //    biasLevel = SetIntialTrustLevels(bias, CountryName);


        //        var Gini = jsonCIAUnit.Economy.DistributionoffamilyincomeGiniindex;


        //        var LEI = (double.Parse(jsonCIAUnit.PeopleandSociety.Lifeexpectancyatbirth.Split(' ')[0]) - 20) / (85 - 20);//76.59 years

        //        var EDI = (double.Parse(jsonCIAUnit.PeopleandSociety.SchoolLifeExpectancy.Split(' ')[0]) / 18);//14 years
        //                                                                                                       //$13,900 (2014 est.) ++ $13,400 (2013 est.) ++ $13,000 (2012 est.)

        //        var gdppp = jsonCIAUnit.Economy.GDPpurchasingpowerparity;


        //        var WDI = (Math.Log(gdppp / 75000)) / (Math.Log(gdppp / 100));
        //        //
        //        var HDI = LEI * EDI * WDI;
        //    }
        //    catch (Exception i)
        //    {
        //        var g = i;
        //    }





        //    //={\frac {\ln({\textrm {GNIpc}})-\ln(100)}{\ln(75,000)-\ln(100)}}
        //    ///. Life Expectancy Index (LEI) {\displaystyle ={\frac {{\textrm {LE}}-20}{85-20}}} ={\frac {{\textrm {LE}}-20}{85-20}}

        //    //LEI is 1 when Life expectancy at birth is 85 and 0 when Life expectancy at birth is 20.

        //    var gov1 = new JsonDataCountry.CountryGovernment
        //    {
        //        IsInTotalControlOfCountry = true,
        //        CountryHistory = new List<Tuple<Country, DiplomaticEvent>>(), //this is where the AI stores its moves
        //        NameOfGovernment = CountryName,
        //        HasEmbassy = false,
        //        EmbassyOpen = false,
        //        NameOfHeadOfMilitary = ContactOfMilitary.ContacName,
        //        ContactOfHeadOfMilitary = ContactOfMilitary,
        //        NameOfHeadOfEconomic = ContactOfEconomic.ContacName,
        //        ContactOfHeadOfEconomic = ContactOfEconomic,
        //        NameOfAmbassdor = ContactOfAmbassdor.ContacName,
        //        ContactOfAmbassdor = ContactOfAmbassdor,
        //        NameOfHeadOfState = ContactOHeadOfState.ContacName,
        //        ContactOfHeadOfState = ContactOHeadOfState,
        //        TitleOfHeadOfState = TitleOfLeader,
        //        TitleOfEconomic = TitleOfEconomicLeader,
        //        TitleOfMilitary = TitleOfMilitaryLeader,
        //        TitleOfPopulation = TitleOfPopulationLeader,
        //        GovernmentHistoryWithPlayer = CreateDefaultHistoryWithPlayer(CountryName, string.Empty),
        //        CountryOfGovernment = countryMapData,
        //        GovernmentTrustLevel = biasLevel,
        //        PlayerPopulationTrustLevel = 60,
        //        PlayerTrustLevel = 60,
        //        PopulationTrustLevel = 60,
        //        MilitaryGovernmentTrustLevel = 90,
        //        MilitaryPowerScore = sumMilitaryPowerIndex,
        //        MilitaryConscription = false,
        //        TechLevel = 70,
        //        Gini = 0.9,
        //        HDI = 0.86,
        //        IsTerroristGroup = false,
        //        langaugeSpokenIndex = 1,
        //        ControlsProvincesNames = new List<string>(),
        //        ControlCountriesNames = new List<string>()
        //    };
        //    return gov1;
        //}

        public List<CountryGovernment> CreateOldWorldOrder()
        {
            var worldgovernments = new List<CountryGovernment>();

            return worldgovernments;
        }


        public CountryGovernment BuildNewNonPlayerGovernment(string CountryName, bool OverWrite)
        {
            ContactGenerator cgm = new ContactGenerator();
            GlobalWarGameDbContext gwDb = new GlobalWarGameDbContext();

            var bias = gwDb.GetCountryBiasDetailsByName(CountryName);
            var countryMapData = map.GetCountry(CountryName);
            var genericCountry = new GenericCountry();
            genericCountry.index = countryMapData.mainRegionIndex;
            genericCountry.name = countryMapData.name;
            genericCountry.regionName = countryMapData.continent;

            var ContactOfMilitary = cgm.GenerateContact(genericCountry.name, genericCountry.regionName, ContactGenerator.ContactGameGroup.military);
            var ContactOfEconomic = cgm.GenerateContact(genericCountry.name, genericCountry.regionName, ContactGenerator.ContactGameGroup.economic);
            var ContactOfAmbassdor = cgm.GenerateContact(genericCountry.name, genericCountry.regionName, ContactGenerator.ContactGameGroup.diplomacy);
            var ContactOHeadOfState = cgm.GenerateContact(genericCountry.name, genericCountry.regionName, ContactGenerator.ContactGameGroup.diplomacy);


            var TitleOfLeader = GovernmentHeadOfStateTitleNameBias(bias.Item1, CountryName);
            var TitleOfMilitaryLeader = GovernmentHeadOfMilitaryTitleNameBias(bias.Item1, CountryName);
            var TitleOfEconomicLeader = GovernmentHeadOfEconomicTitleNameBias(bias.Item1, CountryName);
            var TitleOfPopulationLeader = GovernmentHeadOfPopulationTitleNameBias(bias.Item1, CountryName);

            return new CountryGovernment
            {
                IsInTotalControlOfCountry = true,
                CountryHistory = new List<Tuple<CountryToGlobalCountry.GenericCountry, WorldEvent>>(), //this is where the AI stores its moves
                NameOfGovernment = CountryName,
                PlayerHasEmbassy = false,
                PlayerEmbassyOpen = false,
                ContactOfHeadOfMilitary = ContactOfMilitary,
                ContactOfHeadOfEconomic = ContactOfEconomic,
                ContactOfPlayerAmbassdor = ContactOfAmbassdor,
                ContactOfHeadOfState = ContactOHeadOfState,
                TitleOfHeadOfState = TitleOfLeader,
                TitleOfEconomic = TitleOfEconomicLeader,
                TitleOfMilitary = TitleOfMilitaryLeader,
                TitleOfPopulation = TitleOfPopulationLeader,
                GovernmentHistoryWithPlayer = CreateHistoryWithPlayer("Argentina", "United States of America"),
                //GovernmentTrustLevel = SetIntialTrustLevels(bias, CountryName),
                PlayerPopulationTrustLevel = 60,
                PlayerTrustLevel = 60,
                PopulationTrustLevel = 60,
                MilitaryGovernmentTrustLevel = 90,
                MilitaryPowerScore = 70,
                MilitaryConscription = false,
                TechLevel = 70,
                Gini = 0.9f,
                HDI = 0.86f,
                IsTerroristGroup = false,
                ControlsProvincesNames = new List<CountryToGlobalCountry.GenericProvince>(),
                ControlCountriesNames = new List<CountryToGlobalCountry.GenericCountry>()
            };
        }


        public Tuple<CountryRelationsFactory.CountryBias, string, string[], string[], CountryRelationsFactory.CountryGovernmentTypes> CountryHistoricBias(string countryName)
        {

           return StubCountryBiasList().Where(e => e.Item2 == countryName).FirstOrDefault();
        }


        //this is to seed the intially relations matrix countries will have there bias and then there current allies, rivials, and governments defaults
        public static List<Tuple<CountryRelationsFactory.CountryBias, string, string[], string[], CountryRelationsFactory.CountryGovernmentTypes>> StubCountryBiasList()
        {
            var rnd = new UnityEngine.Random();
            var internalRegionFirst = new List<Tuple<CountryRelationsFactory.CountryBias, string, string[], string[], CountryRelationsFactory.CountryGovernmentTypes>>();

            internalRegionFirst = new List<Tuple<CountryRelationsFactory.CountryBias, string, string[], string[], CountryRelationsFactory.CountryGovernmentTypes>>
            {
                new Tuple<CountryBias, string,  string[], string[],CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamInstable, "Afghanistan",new string[] {"China", "United States of America",  "Russia"},new string[] {"United States of America", "China", "India" }, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Albania",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "Algeria",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Angola",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formereuro, "Antigua and Barbuda",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericandemocracy, "Argentina",new string[] {"China", "United States of America",  "Russia"},new string[] {"Brazil", "United States of America", "China" }, CountryRelationsFactory.CountryGovernmentTypes.ConstitutionalDemocracy),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersovietAuthoratian, "Armenia",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formereuro, "Aruba",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formereuro, "Australia",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "Austria",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersovietAuthoratian, "Azerbaijan",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Andorra",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                 new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.superpower, "European Union",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                
                
                //B
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formereuro, "Bahamas",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamInstable, "Bahrain",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamInstable, "Bangladesh",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formereuro, "Barbados",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersovietAuthoratian, "Belarus",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                 new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Bermuda",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "Belgium",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericansocialist, "Belize",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Benin",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.chinaAndAllies, "Bhutan",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericansocialist, "Bolivia",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Bosnia and Herzegovina",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Botswana",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericandemocracy, "Brazil",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "Brunei",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Bulgaria",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Burkina Faso",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.chinaAndAllies, "Burma",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Burundi",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                //C
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Cayman Islands",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.chinaAndAllies, "Cambodia",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Cameroon",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.westerndemocracy, "Canada",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Cape Verde",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
               new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Cabo Verde",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Central African Republic",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Chad",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericandemocracy, "Chile",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.chinaAndAllies, "China",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericandemocracy, "Colombia",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formereuro, "Comoros",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericansocialist, "Costa Rica",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Democratic Republic of the  Congo",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "DRC",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Republic of the Congo",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Congo (Brazzaville)",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Cote d'Ivoire",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeansocialdemocracy, "Croatia",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericansocialist, "Cuba",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formereuro, "Curacao",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "Cyprus",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "Czech Republic",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                //D
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "Denmark",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "Djibouti",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formereuro, "Dominica",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericandemocracy, "Dominican Republic",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                //E
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formereuro, "East Timor",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericansocialist, "Ecuador",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "Egypt",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericansocialist, "El Salvador",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Equatorial Guinea",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Eritrea",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Estonia",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Ethiopia",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Fiji",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                 new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Falkland Islands",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),


                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeansocialdemocracy, "Finland",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "France",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Gabon",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Gambia",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Georgia",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Ghana",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                 new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.westerndemocracy, "Germany",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "Greece",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formereuro, "Grenada",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                     new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formereuro, "Greenland",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamInstable, "Gaza Strip",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericansocialist, "Guatemala",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Guinea",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Guinea-Bissau",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericandemocracy, "Guyana",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericandemocracy, "Haiti",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Holy See",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericansocialist, "Honduras",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "Hungary",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "Iceland",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.regionalpower, "India",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "Indonesia",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "Iran",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"},  CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamInstable, "Iraq",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"},  CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "Ireland",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Israel",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "Italy",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formereuro, "Jamaica",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.notchinaAsian, "Japan",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "Jordan",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Kazakhstan",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Kenya",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.chinaAndAllies, "North Korea",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.notchinaAsian, "South Korea",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "Kosovo",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "Kuwait",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Kyrgyzstan",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.chinaAndAllies, "Laos",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Latvia",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamInstable, "Lebanon",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Lesotho",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Liberia",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamInstable, "Libya",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Liechtenstein",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Lithuania",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Luxembourg",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                //M
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Macau",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Macedonia",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Madagascar",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Malawi",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "Malaysia",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Maldives",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.civilwar, "Mali",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Malta",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Mauritania",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Mauritius",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericandemocracy, "Mexico",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Micronesia",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Moldova",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Monaco",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.chinaAndAllies, "Mongolia",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "Montenegro",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "Morocco",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Mozambique",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Namibia",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Nauru",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.notchinaAsian, "Nepal",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeansocialdemocracy, "Netherlands",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.westerndemocracy, "New Zealand",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericansocialist, "Nicaragua",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Niger",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.civilwar, "Nigeria",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeansocialdemocracy, "Norway",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "Oman",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamInstable, "Pakistan",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Palau",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericansocialist, "Panama",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Papua New Guinea",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Palestine",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericandemocracy, "Paraguay",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericansocialist, "Peru",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.notchinaAsian, "Philippines",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Poland",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "Portugal",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "Qatar",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Romania",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.russiaAndAllies, "Russia",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Rwanda",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Saint Kitts and Nevis",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Saint Kitts and Nevins",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Saint Lucia",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Saint Vincent and the Grenadines",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Samoa",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "San Marino",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Sao Tome and Principe",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                 new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamInstable, "Saudi Arabia",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Senegal",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Serbia",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Seychelles",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Sierra Leone",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Singapore",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                   new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Saint Maarten",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Saint Martin",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Slovakia",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersoviet, "Slovenia",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                   new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Saint Helena",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                   new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Spratly Islands",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Solomon Islands",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.civilwar, "Somalia",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "South Africa",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "South Sudan",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeansocialdemocracy, "Spain",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Sri Lanka",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "Sudan",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericandemocracy, "Suriname",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Swaziland",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeansocialdemocracy, "Sweden",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "Switzerland",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.civilwar, "Syria",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Taiwan",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersovietAuthoratian, "Tajikistan",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Tanzania",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.notchinaAsian, "Thailand",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Timor-Leste",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Togo",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Tonga",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Trinidad and Tobago",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Turks and Caicos Islands",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamInstable, "Tunisia",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "Turkey",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersovietAuthoratian, "Turkmenistan",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Tuvalu",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africanstable, "Uganda",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.civilwar, "Ukraine",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.islamStable, "United Arab Emirates",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.europeandemocracy, "United Kingdom",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.superpower, "United States of America",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericandemocracy, "Uruguay",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.formersovietAuthoratian, "Uzbekistan",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                   new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Western Sahara",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.citystateisland, "Vanuatu",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.southamericansocialist, "Venezuela",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.notchinaAsian, "Vietnam",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.civilwar, "Yemen",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                  new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Zambia",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),

                new Tuple<CountryRelationsFactory.CountryBias, string, string[],string[],CountryRelationsFactory.CountryGovernmentTypes>(CountryRelationsFactory.CountryBias.africaninstable, "Zimbabwe",new string[] {"China", "United States of America",  "Russia"},new string[] {"China", "United States of America",  "Russia"}, CountryRelationsFactory.CountryGovernmentTypes.IslamicRepublic),
                };
            return internalRegionFirst;
        }
    }
}
