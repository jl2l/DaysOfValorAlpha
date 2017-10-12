using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using WorldMapStrategyKit;

namespace Assets
{
    public class DeckFactory
    {
        public enum DeckRank
        {
            Rank0,
            Rank1,
            Rank2,
            Rank3,
            Rank4,
            Rank5
        }
        public enum DeckType
        {
            Universal,
            AirOnly,
            SeaOnly,
            Rebels,
            PeaceKeepers,
        }
        public enum DeckSpecialType
        {
            [Description("None")]
            None = 0,
            [Description("Air Wing")]
            Air = 1,
            [Description("Air Assault")]
            AirAssault = 2,
            [Description("Mechanized Armor")]
            Motor = 3,
            [Description("Heavy Armor")]
            Armor = 4,
            [Description("Mechanized Infantry")]
            Mech = 5,
            [Description("Intelligence Support")]
            Support = 6,
            [Description("Special Forces")]
            SpecialForces = 7,
            [Description("Naval Infantry")]
            Naval = 8,
            [Description("Marines")]
            Marines = 9,
            [Description("Peace Keepers")]
            Peacekeeper = 10,
            [Description("Paratroopers")]
            Paratroopers = 11,
            [Description("Rebel Force")]
            Rebels = 12
        }
        public enum DeckEra
        {
            [Description("Pre 1980")]
            Pre1980 = 0,
            [Description("Pre 1991")]
            Pre1991 = 1,
            [Description("Pre 2001")]
            Pre2001 = 2,
            [Description("Pre2020")]
            Pre2020 = 3,
            [Description("Post 2025+")]
            Post2025 = 4
        }
        public enum DeckUnitType
        {
            [Description("Logsitical")]
            Log = 0,
            Special = 1,
            Inf = 2,
            Rec = 3,
            Tank = 4,
            Artillery = 5,
            Air = 6,
            Hel = 7,
            Sea = 8,
            Rebel = 9,
            Unmmaned = 10
        }
        public static WMSK map = WMSK.instance;
        public ForcesFactory ForcesFactory;

        public Sprite DeckIconImage(DeckRank rank, DeckManager deckManager)
        {

            var deckIcon = new Texture2D(32, 32);
            switch (rank)
            {
                case DeckRank.Rank1:

                    return Sprite.Create(deckManager.Rank1Icon, new Rect(0.0f, 0.0f, deckManager.Rank1Icon.width, deckManager.Rank1Icon.height), new Vector2(0.5f, 0.5f), 100.0f);

                case DeckRank.Rank2:
                    return Sprite.Create(deckManager.Rank2Icon, new Rect(0.0f, 0.0f, deckManager.Rank1Icon.width, deckManager.Rank1Icon.height), new Vector2(0.5f, 0.5f), 100.0f);
                case DeckRank.Rank3:
                    return Sprite.Create(deckManager.Rank3Icon, new Rect(0.0f, 0.0f, deckManager.Rank1Icon.width, deckManager.Rank1Icon.height), new Vector2(0.5f, 0.5f), 100.0f);
                case DeckRank.Rank4:
                    return Sprite.Create(deckManager.Rank4Icon, new Rect(0.0f, 0.0f, deckManager.Rank1Icon.width, deckManager.Rank1Icon.height), new Vector2(0.5f, 0.5f), 100.0f);
                case DeckRank.Rank5:
                    return Sprite.Create(deckManager.Rank5Icon, new Rect(0.0f, 0.0f, deckManager.Rank1Icon.width, deckManager.Rank1Icon.height), new Vector2(0.5f, 0.5f), 100.0f);
            }
            return Sprite.Create(deckManager.DefaultDeckIcon, new Rect(0.0f, 0.0f, deckManager.Rank1Icon.width, deckManager.Rank1Icon.height), new Vector2(0.5f, 0.5f), 100.0f);
        }



        public DeckDataItem NewDeckItem(string Name, DeckEra era, DeckType type, string DeckLocationName, string DeckLocationContinent, string DeckType, string deckFlag)
        {
            return new DeckDataItem()
            {
                CurrentDeploymentScore = 0,
                DeckDestination = new Vector2(),
                DeckName = Name,
                DeckTimeEra = era,
                DeckType = type,
                DeckCurrentWorldLocation = map.GetProvince(DeckLocationName, DeckLocationContinent).center,
                //DeckIcon = DeckType,
                //DisplayDeckNameCountryFlag = deckFlag,
                UnitDeckRank = DeckRank.Rank0,
                //UnitDeckRankIcon = DeckIconName(DeckRank.Rank0),
                MaxDeploymentScore = 0
            };
        }

        //public List<DeckDataItem> PlaceholderDeck(ForcesFactory ForcesFactory)
        //{

        //    var deck = new List<DeckDataItem>();
        //    var deckIcon = Resources.Load<Texture2D>("deckicon");
        //    var stubCountryLocation = map.GetProvince("New York", "United States of America");
        //    var stubLocation = new CountryToGlobalCountry.GenericProvince(stubCountryLocation.name);
        //    var stubCity = map.GetCity("Norfolk", "United States of America");
        //    UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);
        //    var defaultValue = UnityEngine.Random.Range(0, 100);

        //    var sampleUnits = ForcesFactory.BuildUSTanks();
        //    var sampleNavalUnits = ForcesFactory.BuildUSShipStub();

        //    deck.Add(new DeckDataItem()
        //    {
        //        CurrentDeploymentScore = 0,
        //        DeckDestination = new Vector2(),
        //        DeckName = "75th Ranger SOF",
        //        DeckTimeEra = DeckEra.Pre2001,
        //        DeckType = DeckType.Universal,
        //        DeckLocaledProvince = stubLocation,
        //        DeckCurrentWorldLocation = stubCity.unity2DLocation,
        //        //DeckIcon = "inf",
        //        //DisplayDeckNameCountryFlag = "US",
        //        DeckFuel = UnityEngine.Random.Range(0, 100),
        //        DeckAmmo = UnityEngine.Random.Range(0, 100),
        //        DeckHealth = UnityEngine.Random.Range(0, 100),
        //        UnitDeckRank = DeckRank.Rank1,
        //        //UnitDeckRankIcon = DeckIconName(DeckRank.Rank1),
        //        VehiclesInDeck = sampleUnits.Cast<DoV_Vehicle>().ToList(),
        //        MaxDeploymentScore = 60,
        //        UnitSummaryArtillerySum = 5,
        //        UnitSummaryHeloSum = 2,
        //        UnitSummaryInfantrySum = 30,
        //        UnitSummaryJetsSum = 0,
        //        UnitSummaryLogSum = 10,
        //        UnitSummaryRebelsSum = 0,
        //        UnitSummaryReconSum = 20,
        //        UnitSummaryShipsSubsSum = 0,
        //        UnitSummarySpecialOpsSum = 20,
        //        UnitSummaryTanksSum = 20,
        //        UnitSummaryUnmannedSum = 10,


        //    });
        //    deck.Add(new DeckDataItem()
        //    {
        //        CurrentDeploymentScore = 0,
        //        DeckDestination = new Vector2(),
        //        DeckName = "125th Ranger SOF",
        //        DeckTimeEra = DeckEra.Pre2001,
        //        DeckType = DeckSpecialType.AirAssault,
        //        DeckLocaledProvince = stubLocation,
        //        DeckCurrentWorldLocation = stubCity.unity2DLocation,
        //        DeckIcon = "inf",
        //        DisplayDeckNameCountryFlag = "US",
        //        DeckFuel = UnityEngine.Random.Range(0, 100),
        //        DeckAmmo = UnityEngine.Random.Range(0, 100),
        //        DeckHealth = UnityEngine.Random.Range(0, 100),
        //        UnitDeckRank = DeckRank.Rank1,
        //        UnitDeckRankIcon = DeckIconName(DeckRank.Rank1),
        //        VehiclesInDeck = sampleUnits.Cast<DoV_Vehicle>().ToList(),
        //        MaxDeploymentScore = 60,
        //        UnitSummaryArtillerySum = 5,
        //        UnitSummaryHeloSum = 2,
        //        UnitSummaryInfantrySum = 30,
        //        UnitSummaryJetsSum = 0,
        //        UnitSummaryLogSum = 10,
        //        UnitSummaryRebelsSum = 0,
        //        UnitSummaryReconSum = 20,
        //        UnitSummaryShipsSubsSum = 0,
        //        UnitSummarySpecialOpsSum = 20,
        //        UnitSummaryTanksSum = 20,
        //        UnitSummaryUnmannedSum = 10,
        //    });
        //    deck.Add(new DeckDataItem()
        //    {
        //        CurrentDeploymentScore = 0,
        //        DeckDestination = new Vector2(),
        //        DeckName = "101st Airborne",
        //        DeckTimeEra = DeckEra.Pre2001,
        //        DeckType = DeckSpecialType.Paratroopers,
        //        DeckLocaledProvince = stubLocation,
        //        DeckCurrentWorldLocation = stubCity.unity2DLocation,
        //        DeckIcon = "para",
        //        DisplayDeckNameCountryFlag = "US",
        //        DeckFuel = UnityEngine.Random.Range(0, 100),
        //        DeckAmmo = UnityEngine.Random.Range(0, 100),
        //        DeckHealth = UnityEngine.Random.Range(0, 100),
        //        UnitDeckRank = DeckRank.Rank1,
        //        UnitDeckRankIcon = DeckIconName(DeckRank.Rank1),
        //        VehiclesInDeck = sampleUnits.Cast<DoV_Vehicle>().ToList(),
        //        MaxDeploymentScore = 60,
        //        UnitSummaryArtillerySum = 5,
        //        UnitSummaryHeloSum = 2,
        //        UnitSummaryInfantrySum = 30,
        //        UnitSummaryJetsSum = 0,
        //        UnitSummaryLogSum = 10,
        //        UnitSummaryRebelsSum = 0,
        //        UnitSummaryReconSum = 20,
        //        UnitSummaryShipsSubsSum = 0,
        //        UnitSummarySpecialOpsSum = 20,
        //        UnitSummaryTanksSum = 20,
        //        UnitSummaryUnmannedSum = 10,
        //    });
        //    deck.Add(new DeckDataItem()
        //    {
        //        CurrentDeploymentScore = 0,
        //        DeckDestination = new Vector2(),
        //        DeckName = "10th BCT",
        //        DeckTimeEra = DeckEra.Pre2001,
        //        DeckType = DeckSpecialType.Motor,
        //        DeckLocaledProvince = stubLocation,
        //        DeckCurrentWorldLocation = stubCity.unity2DLocation,
        //        DeckIcon = "mech",
        //        DisplayDeckNameCountryFlag = "US",
        //        DeckFuel = UnityEngine.Random.Range(0, 100),
        //        DeckAmmo = UnityEngine.Random.Range(0, 100),
        //        DeckHealth = UnityEngine.Random.Range(0, 100),
        //        UnitDeckRank = DeckRank.Rank1,
        //        UnitDeckRankIcon = DeckIconName(DeckRank.Rank1),
        //        VehiclesInDeck = sampleUnits.Cast<DoV_Vehicle>().ToList(),
        //        MaxDeploymentScore = 60,
        //        UnitSummaryArtillerySum = 5,
        //        UnitSummaryHeloSum = 2,
        //        UnitSummaryInfantrySum = 30,
        //        UnitSummaryJetsSum = 0,
        //        UnitSummaryLogSum = 10,
        //        UnitSummaryRebelsSum = 0,
        //        UnitSummaryReconSum = 20,
        //        UnitSummaryShipsSubsSum = 0,
        //        UnitSummarySpecialOpsSum = 20,
        //        UnitSummaryTanksSum = 20,
        //        UnitSummaryUnmannedSum = 10,
        //    });
        //    deck.Add(new DeckDataItem()
        //    {
        //        CurrentDeploymentScore = 0,
        //        DeckDestination = new Vector2(),
        //        DeckName = "Wasp Expeditionary Strike Group",
        //        DeckTimeEra = DeckEra.Pre2001,
        //        DeckType = DeckSpecialType.Naval,
        //        DeckLocaledProvince = stubLocation,
        //        DeckCurrentWorldLocation = stubCity.unity2DLocation,
        //        DeckIcon = "ship",
        //        DisplayDeckNameCountryFlag = "US",
        //        DeckFuel = UnityEngine.Random.Range(0, 100),
        //        DeckAmmo = UnityEngine.Random.Range(0, 100),
        //        DeckHealth = UnityEngine.Random.Range(0, 100),
        //        UnitDeckRank = DeckRank.Rank2,
        //        UnitDeckRankIcon = DeckIconName(DeckRank.Rank2),
        //        VehiclesInDeck = sampleNavalUnits.Cast<DoV_Vehicle>().Where(e => e.ModelName == "US_wasp").ToList(),
        //        MaxDeploymentScore = 60,
        //        UnitSummaryArtillerySum = 5,
        //        UnitSummaryHeloSum = 2,
        //        UnitSummaryInfantrySum = 30,
        //        UnitSummaryJetsSum = 0,
        //        UnitSummaryLogSum = 10,
        //        UnitSummaryRebelsSum = 0,
        //        UnitSummaryReconSum = 20,
        //        UnitSummaryShipsSubsSum = 0,
        //        UnitSummarySpecialOpsSum = 20,
        //        UnitSummaryTanksSum = 20,
        //        UnitSummaryUnmannedSum = 10,
        //    });
        //    deck.Add(new DeckDataItem()
        //    {
        //        CurrentDeploymentScore = 0,
        //        DeckDestination = new Vector2(),
        //        DeckName = "Carrier Strike Group One",
        //        DeckTimeEra = DeckEra.Pre2001,
        //        DeckType = DeckSpecialType.Naval,
        //        DeckLocaledProvince = stubLocation,
        //        DeckCurrentWorldLocation = stubCity.unity2DLocation,
        //        DeckIcon = "ship",
        //        DisplayDeckNameCountryFlag = "US",
        //        DeckFuel = 20,
        //        DeckAmmo = 50,
        //        DeckHealth = 80,
        //        UnitDeckRank = DeckRank.Rank3,
        //        UnitDeckRankIcon = DeckIconName(DeckRank.Rank3),
        //        VehiclesInDeck = sampleNavalUnits.Cast<DoV_Vehicle>().ToList(),
        //        MaxDeploymentScore = 60,
        //        UnitSummaryArtillerySum = 5,
        //        UnitSummaryHeloSum = 2,
        //        UnitSummaryInfantrySum = 30,
        //        UnitSummaryJetsSum = 0,
        //        UnitSummaryLogSum = 10,
        //        UnitSummaryRebelsSum = 0,
        //        UnitSummaryReconSum = 20,
        //        UnitSummaryShipsSubsSum = 0,
        //        UnitSummarySpecialOpsSum = 20,
        //        UnitSummaryTanksSum = 20,
        //        UnitSummaryUnmannedSum = 10,
        //    });
        //    return deck;
        //}
    }
}
