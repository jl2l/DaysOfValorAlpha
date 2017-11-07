using Assets;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

[System.Serializable]
public class DoV_Vehicle : ScriptableObject
{

    public DoV_Vehicle()
    {
        //todo get the properties of this
    }

#if UNITY_EDITOR
    [Separator] public Separator s1;
#endif

    public string IndefiniteArticle = "a";
    public string DisplayName;
    public string Description;
    public Texture2D ClassIcon;
    public Texture2D MapIcon;
    public GameObject Model;
    public GameObject LowPolyModel;
    public Texture2D MenuIcon;

#if UNITY_EDITOR
    [FloatField("Deployment Wight", 0.0f)]
#endif
    public float Space = 0.0f;


    public string DisplayNameFull
    { get { return IndefiniteArticle + " " + DisplayName; } }   // TIP: you could use System.Globalization -> TextInfo to convert this string to title case among other things


    public List<Armor> VehicleArmor;

    [SerializeField]
    public List<Sensor> VehicleSensors;

    [SerializeField]
    public List<WeaponConfig> VehicleWeapons;

    [SerializeField]
    public List<DoV_Vehicle> GroundVehicles; // if it carries tanks like a LHA
    public List<DoV_Vehicle> Aircraft; // if its a carrier or helo


#if UNITY_EDITOR
    [Separator] public Separator s4;
#endif
    public BaseAirType BaseAirType;
    public AircraftTypeStr AircraftType;
    public float FlightSpeed;
    [Tooltip("The max distance it can go and come back to attack a target for a Air strike.")]
    public float FlightCombatRadius;
    [Tooltip("The max ferry distance of this aircraft, so how far it can go to a another airbase without refueling.")]
    public float FlightTransportRange;
    [Tooltip("The sensor can target units itself, most strike fighters have this, tanks, but artillery doesnt bombers dont they are indirect")]
    public bool SelfDesignate;
    public bool IsStealth;
    public bool IsAirTransport;
    public bool IsAirfueling;
    public bool IsAirborneReArming;
    public bool HasInternalGun;

    public int GunAmmo;



    //one gallon of jet fuel should weigh 6.7 lbs
    [Tooltip("one gallon of jet fuel should weigh 6.7 lbs")]
    public int JetFuelGallons;

#if UNITY_EDITOR
    [Separator] public Separator s2;
#endif
    /// <summary>
    /// Does the unit have a turret
    /// </summary>
    [Tooltip("Tanks/IFV have turrets")]
    public bool HasTurret;
    public bool IsLandVehicle = true;
    public BaseGroundType BaseGroundType;
    public GroundVehicleType GroundVehicleType;


#if UNITY_EDITOR
    [Separator] public Separator sd;
#endif


    public int CrewNumber;
    public int OfficerNumber;
    /// <summary>
    /// Length Height Width are used to create a hit box
    /// </summary>
    public int Length;
    /// <summary>
    /// Length Height Width are used to create a hit box
    /// </summary>
    public int Height;
    /// <summary>
    /// Length Height Width are used to create a hit box
    /// </summary>
    public int Width;
    /// <summary>
    /// EmptyWeight is used to calculate the cargo total, and is used when transorting a ship without fueld or weapons
    /// </summary>
    public int EmptyWeight;
    public int LoadedWeight;
    public Powerplant Powerplant;
    public string ProgramName;
    public int TotalNumberBuilt;
    public Texture2D CountryOfOriginFlag;
    public string CountryOfOrigin;
    public int CountryOfOriginIndex;
    public string Name;
    /// <summary>
    /// how many soliders does the unit carry useful for IFV, APC, transport ships
    /// </summary>
    public int TroopCarryTotal;
    [Tooltip("Tanks/ turrets are stabilized")]
    public bool HasStablizer;

    /// <summary>
    /// what year it came out in uses for eras
    /// </summary>
    public string Year;
    /// <summary>
    /// Its overall military value ie low is less special
    /// </summary>
    [Tooltip("The strategic value of the unit, basic how many points you get for killing it")]
    public int Value;
    /// <summary>
    /// Its base factor for its HP, ie tans have high strength, units with heavy armor will have high strength
    /// </summary>
    [Tooltip("set the base HP for the unit, this will be divided between the Armor and thats how it lives onces all armor is gone it will be destroyed")]
    public int Strength;
    /// <summary>
    /// units ability to resist jamming the higher 1 the more likely you are to resisit, if you have low 0.20 you will get jammed
    /// </summary>
    [Tooltip("units ability to resist jamming the higher 1 the more likely you are to resisit, if you have low 0.20 you will get jammed")]
    [Range(0.0f, 1.0f)]
    public float Ecm;
    /// <summary>
    /// what generations it is
    /// </summary>
    [Tooltip("what generations it is")]
    public int Generation;
    /// <summary>
    /// How fast it burns through fuel rate would be to move at top speed
    /// </summary>
    [Tooltip("How fast it burns through fuel rate would be to move at top speed")]
    [Range(0.0f, 1.0f)]
    public float FuelRange;
    /// <summary>
    /// How much fuel points is can carry total
    /// </summary>
    public int FuelMax;
    /// <summary>
    /// how big it is fighter vs bomber 1 small drone or infantry - 10 is a aircraft carrier
    /// </summary>
    [Tooltip(" how big it is fighter vs bomber 1 small drone or infantry - 10 is a aircraft carrier")]
    public int Size;
    /// <summary>
    ///how unstablity the unit is 1 being very stable, for vehicles and ships stabiliy is good, for aircraft its bad, aircraft with lower 0 are more manurable
    /// </summary>
    [Tooltip("how unstablity the unit is 1 being very stable, for vehicles and ships stabiliy is good, for aircraft its bad, aircraft with lower 0 are more manurable")]
    [Range(0.0f, 1.0f)]
    public float Instability;
    /// <summary>
    /// How easily it can be detected 1 equals will always be detected
    /// </summary>
    [Tooltip("How easy it can be detect by radar 1 = always 0 = hidden ie F-22 0.022 rcs")]
    [Range(0.0f, 1.0f)]
    public float Rcs;
    /// <summary>
    /// How far ingame radius it can detect something
    /// </summary>

    public int DetectionRadius()
    {

        return VehicleSensors.Select(e => e.MaxRange).Max();
    }
    public int MinDetectionRadius()
    {
        return VehicleSensors.Select(e => e.MinRange).Min();
    }
    /// <summary>
    /// How well the vehicle is protected against FLIR 1 = visible to Flir / 0 = nothing 
    /// </summary>
    [Tooltip("how detectable it is to IR, 1 = visible 0 = hidden")]
    [Range(0.0f, 1.0f)]
    public float ThermalRating;
    /// <summary>
    /// how long once it detects something it can shoot at it in seconds
    /// </summary>
    [Tooltip("How long it takes the ship to fire at something once it detects it")]
    [Range(0.0f, 1.0f)]
    public float TargetTime;
    /// <summary>
    /// The diffculty of the object to be piloted in using the weapon modifier to the Weapons Relibility rate for Ships set to 0, vehicles or aircraft %
    /// </summary>
    [Tooltip("The exp of the ship in game")]
    public int PilotExp;
    /// <summary>
    /// How much it cost to deploy the unit in the battle
    /// </summary>
    [Tooltip("Host much deployment points to cost to use")]
    public long Cost;
    /// <summary>
    /// How many aircraft come in a unit ie 2 fighters or 1 bomber
    /// </summary>
    [Tooltip("The compose of the sub-unit, a Vehicle could have 12 tanks per subunit, or 1 ship, ")]
    public int UnitSize;
    /// <summary>
    /// Does the unit have a fire control system, increases the speed to target
    /// </summary>
    [Tooltip("Has a fire control system increases the bonus to targeting time")]
    public bool HasFCS;

#if UNITY_EDITOR
    [Separator] public Separator s27;
#endif
    public bool IsInfantry;
    public bool IsCapturing;
    [Tooltip("How many solider in a squad")]
    public int SquadSize;
    public InfType InfType;

#if UNITY_EDITOR
    [Separator] public Separator s3;
#endif

    [Tooltip("Is the unit a logisitcial unit ie can resupply other units")]
    public bool IsLogistical;

    [Tooltip("The amount of resupply points allows a ship to restock its weapons like the CIWS or refuel other vehicles")]
    public float Resupply;
    public float MaxResupply;
    public logisticType LogisticVehicleType;





#if UNITY_EDITOR
    [Separator] public Separator s5;
#endif
    public BaseSeaType BaseSeaType;
    public SeaObjectType SeacraftType;


    [Tooltip("Is the flagship of the navy")]
    public bool IsDeckFlagShip;

    [Tooltip("The ship class")]
    public string SeacraftTypeName;

    [Tooltip("the distance the ship can detect things underwater")]
    [Range(-1.0f, 100000.0f)]
    public float ShipSonarPreceptionRange;
    [Tooltip("the the gain is the rate that the noise level 60-120db if you have 60db you can detect anything right away, 120 will take longer ")]
    [Range(-120.0f, 180.0f)]
    public float ShipSonarArrayGain;
    [Tooltip("Noisy Submarine 140-120, Quiet Submarine 120-100, very quiet submarine 100-80, ultraquiet 80-40")]
    [Range(-100.0f, 200.0f)]
    public float ShipNoiseLevel;
    public bool IsShip;

    [Tooltip("The ship can shoot at submarines/sonar")]
    public bool IsASW;

    [Tooltip("The ship class")]
    public bool IsSSK; // is a desiel sub has a different sonar profile

    [Tooltip("is a submaine")]
    public bool IsSub;
    public bool IsCarrier;
    public bool IsTransport;
    public bool IsNuclearPower;
}

