
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using WorldMapStrategyKit;

namespace Assets
{
    [System.Serializable]
    public class Weapon : ScriptableObject
    {
        [Header("Weapon Range Settings")]
        [SerializeField]
        public int WeaponRangeGround = 0;
        [SerializeField]
        public int WeaponRangeAirLow = 0;
        [SerializeField]
        public int WeaponRangeAirHigh = 0;
        public enum ThreatRanges
        {
            /// <summary>
            /// // under 1000m
            /// </summary>
            Tactical,
            /// <summary>
            ///  // under 5000m
            /// </summary>
            ShortRange,
            /// <summary>
            /// //under 10000m over 10km artilery 
            /// </summary>
            MediumRange,
            /// <summary>
            ///  // over 100km
            /// </summary>
            LongRange,
            /// <summary>
            /// // under 500km
            /// </summary>
            TheaterShortRange,
            /// <summary>
            ///  //under 1500km
            /// </summary>
            TheaterMediumRange,
            /// <summary>
            /// //under 35000km
            /// </summary>
            TheaterLongRange,
            /// <summary>
            /// //over 10000km
            /// </summary>
            Strategic,
            /// <summary>
            ///  // over 100000km
            /// </summary>
            Exo
        }

        [SerializeField]
        [Tooltip(" Tactical  under 1000m, ShortRange under 5000m, MediumRange under 10000m over 10km artilery, LongRange over 100km,TheaterShortRange under 500km,TheaterMediumRange under 1500km,TheaterLongRange under 35000km,Strategic over 10000km,Exo over 100000km")]
        public ThreatRanges ThreatRange;

        [SerializeField]
        /// <summary>
        /// Tech level of the device, 1 very low tech 5 being very high tech
        /// </summary>
        public int TechLevel;

        [SerializeField]
        /// <summary>
        /// The likelness the weapon will hit its target 
        /// </summary>
        [Tooltip("The likelness the weapon will hit its target ")]
        [Range(-100.0f, 100.0f)]
        public float WeaponReliablity;

        [SerializeField]
        /// <summary>
        /// Gets or sets the weapon speed in m/2.
        /// </summary>
        [Tooltip("The speed of the weapon in meters per second")]
        public float WeaponSpeed;

        [SerializeField]
        /// <summary>
        /// The weapons ability to resisit countermeasures
        /// </summary>
        [Tooltip("The ability of the weapon to resist countermeasures the score has to be higher then the score or the sensor trying to defeat it, weapons with 0 can't be resisted, ie a bullet, weapons with low resistance will fail to hit there targets if they encounter countermeasures")]
        [Range(-100.0f, 100.0f)]
        public float WeaponResistance;

        [SerializeField]
        /// <summary>
        /// How often it can fire
        /// </summary>
        public int WeaponRateOfFire;
        [SerializeField]
        public bool IsNuclearWeapon;
        [Tooltip("In kilotons effectives blast")]
        public int NuclearPayload;

        [Header("Weapon Display")]
        [SerializeField]
        public string WeaponName = string.Empty;
        
        public Texture2D WeaponIconName;
      
        public GameObject WeaponModel;

        [Header("Weapon Damage Type")]
        [SerializeField]
        public string WeaponAmmoName = string.Empty;
        [SerializeField]
        [Tooltip("How much damaged it does to armor and bunkers")]
        [Range(0, 50)]
        public int WeaponAP = 0;
        [SerializeField]
        [Tooltip("How much blast damage it does good against infantry and infrastructure")]
        [Range(0, 50)]
        public int WeaponHE = 0;
        [SerializeField]
        /// <summary>
        /// Gets or sets the total num ammmo for the weapon, if it a missile total is 1 if its a cannon its two number of shells
        /// TODO support different ammo types ie for tanks SABOT HEAT etc
        /// </summary>
        [Tooltip("Gets or sets the total num ammmo for the weapon, if it a missile total is 1 if its a cannon its X number of shells")]
        public int WeaponsRemaining;
        public int MaxNumWeaponsRemaining;

        [SerializeField]
        public GroundVehicleWeaponType GroundWeaponType;
        [SerializeField]
        public SeaWeaponType SeaWeaponType;
        [SerializeField]
        public AircraftWeaponType AirWeaponType;
        [SerializeField]
        public List<WeaponPerks> WeaponPerks;
        [SerializeField]
        /// <summary>
        ///  //the scale of the blast 1-10 10 being a nuclear blast
        ///  1 hand grenade
        ///  2 mortar small
        ///  3 mortar larger
        ///  4 autocannon
        ///  5 tank shell
        ///  6 artillery shell/hellifire missile
        ///  7 250lb JDAM
        ///  8 500lb JDAM/ harpoon missile
        ///  9 1000lb 
        /// </summary>
        /// 
        [Header("Warhead Settings")]
        [Tooltip("  1 hand grenade 2 mortar small 3 autocannon 4 mortar larger  5 tank shell  6 artillery shell/hellifire missile 7 250lb JDAM 8 500lb JDAM/ harpoon missile 9 1000lb 10 2000lb JDAM 11 MOAB 12 10kt Nuke 20 1 Megaton ")]
        public int WarheadSize;
        [SerializeField]
        public List<WarheadType> warheadType;
      
        [Header("Logistic Settings")]
        [SerializeField]
        [Tooltip("Teh cost of the system")]
        public int PurchaseCost;

        [Tooltip("How many logistic points it cost to repair if damaged")]
        public int RepairCost;

        [Tooltip("The cost in logsitic points to reload the weapon back to MaxWeapons")]
        public int RearmCost;

        [SerializeField]
        public string CountryOfOrigin;

        /// <summary>
        /// ((AP Power -Target Armour Value)/2)+1
        /// </summary>
        [SerializeField]
        public int WeaponDamageCal(int WarheadSize, int TargetArmorRating) { return ((WarheadSize - TargetArmorRating) / 2) + 1; }



        public RegionInfo ManufacturedCountryInfo() { return new RegionInfo(CountryOfOrigin); }

        
       
    }
}
