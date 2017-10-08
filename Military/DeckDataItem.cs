using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    [System.Serializable]
    public class DeckDataItem : ScriptableObject
    {


        public Vector2 DeckDestination;
        public string DeckName;
        public string DeckLocation;
        public string DeckStatus;
        public DeckFactory.DeckEra DeckTimeEra;
        public DeckFactory.DeckType DeckType;
        public Vector2 DeckCurrentWorldLocation;
        public Texture2D DeckIcon;
        public Texture2D DisplayDeckNameCountryFlag;


        public int DeckUnits;
        public int DeckMaxUnits;
        public DeckFactory.DeckRank UnitDeckRank;
        public Texture2D UnitDeckRankIcon;
        /// <summary>
        /// The max number of deployment points you can include in this deck
        /// </summary>
        public int MaxDeploymentScore;
        [SerializeField]
        public int CurrentDeploymentScore;

        [SerializeField]
        public List<DoV_Vehicle> VehiclesInDeck;
        public Contact DeckCommander;
    }
}