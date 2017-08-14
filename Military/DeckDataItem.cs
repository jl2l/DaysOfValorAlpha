using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    [System.Serializable]
    public class DeckDataItem : ScriptableObject
    {
        public DeckDataItem()
        {
        }

        [SerializeField]
        public int CurrentDeploymentScore;
        public Vector2 DeckDestination;
        public string DeckName;
        public DeckFactory.DeckEra DeckTimeEra;
        public DeckFactory.DeckType DeckType;
        public Vector2 DeckCurrentWorldLocation;
        public CountryToGlobalCountry.GenericProvince DeckLocaledProvince;
        public Texture2D DeckIcon;
        public Texture2D DisplayDeckNameCountryFlag;
        public int DeckFuel;
        public int DeckAmmo;
        public int DeckHealth;
        public DeckFactory.DeckRank UnitDeckRank;
        public Texture2D UnitDeckRankIcon;
        /// <summary>
        /// The max number of deployment points you can include in this deck
        /// </summary>
        public int MaxDeploymentScore;
        public int UnitSummaryArtillerySum;
        public int UnitSummaryHeloSum;
        public int UnitSummaryInfantrySum;
        public int UnitSummaryJetsSum;
        public int UnitSummaryLogSum;
        public int UnitSummaryRebelsSum;
        public int UnitSummaryReconSum;
        public int UnitSummaryShipsSubsSum;
        public int UnitSummarySpecialOpsSum;
        public int UnitSummaryTanksSum;
        public int UnitSummaryUnmannedSum;
        [SerializeField]
        public List<DoV_Vehicle> VehiclesInDeck;
        public Contact DeckCommander;
    }
}