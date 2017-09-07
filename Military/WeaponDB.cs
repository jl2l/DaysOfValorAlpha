using Assets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{



    [Serializable]
    public class HardPointType
    {

        public enum PointType
        {
            Internal = 0,
            External = 1,
            Wing = 2,
            WingTip = 3
        }


        public List<AircraftWeapon> ConfigWeapons;
        public PointType HardPointPylonType;
    }

    [Serializable]
    public partial class WeaponStationType
    {

        public enum PointType
        {
            Fixed = 0, // aircraft
            FullRotation = 1,//tank turret
            CrewServered = 2, //MLRS, EW, Infantry
            VerticaLanucher = 3 //VLS 
        }

        public List<Weapon> ConfigWeapons;
        public PointType WeaponsStationType;
    }


    [Serializable]
    public class Powerplant
    {
        public enum PowerPlantType
        {
            [Description("Turbine Engine")]
            turbine,
            diesel,
            turbofan,
            turboprop,
            electric,
            gasturbine,
            gasengine,
            jetengine,
            scramjet,
            hypersonic,
            magneticpiston,
            hybridengine,
            airbreathing,
            nuclear,
        }

        /// <summary>
        /// The amount of power the powerplant generates in Kw / Mw
        /// </summary>
        public float PowerGeneration;
        public string Name;
        public int NumberOf;
        public PowerPlantType TypeOfPower;
    }

    [Serializable]
    public class ObjectGeneralInfo
    {

        [SerializeField]
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
        public string CountryOfOrigin;
        public int CountryOfOriginIndex;
        public string Name;
        /// <summary>
        /// how many soliders does the unit carry useful for IFV, APC, transport ships
        /// </summary>
        public int TroopCarryTotal;

    }


    /// <summary>
    /// Wheneever a unit is used in company the cell it was used in is logged here
    /// </summary>
    [Serializable]
    public class OperationalHistory
    {
        public string CountryUsedIn;
        public DateTime DateDeployed;
        public string OperationalDescription;
    }

    /// <summary>
    /// This will store the military history of this unit however many battles its been in
    /// </summary>
    [Serializable]
    public class ObjectHistory
    {
        public List<OperationalHistory> OperationalHistory;
        public string DesignText;
    }


    public enum ObjectTypeCategory
    {
        airjet = 0,
        airpropeller = 1,
        helicopter = 2,
        tank = 3,
        vehicle = 4,
        trackvehicle = 5,
        ship = 6,
        boat = 7,
        submarine = 8
    }


    /// <summary>
    /// For the Battle AI this will determine the track type and how it behaves Air will track for other Air AirGround can see both Air and Ground etc
    /// </summary>

    public enum SensorSpectrum
    {
        Visible,
        Ir,
        Radar,
        Xray,
        UV,
        Gamma,
        Sound,
        Processor,
        Chemical,
        Lidar,
    }

    /// <summary>
    /// For the Battle AI this will determine the track type and how it behaves Air will track for other Air AirGround can see both Air and Ground etc
    /// </summary>

    public enum TrackMode
    {
        Air,
        Ground,
        AirGround,
        Undersea,
        Sea,
        SeaAirGround,
        UnderseaSeaAirGround
    }


    public enum AircraftSize
    {
        Tiny,
        Small,
        Medium,
        Large,
        VeryLarge
    }


    public enum VehicleSize
    {
        Tiny,
        Small,
        Medium,
        Large,
        VeryLarge
    }


    public enum ShipSize
    {
        Tiny,
        Small,
        Medium,
        Large,
        VeryLarge
    }


    public enum SensorType
    {
        AESAradar,
        PESAradar,
        SABRradar,
        MechScanRadar,
        PulseDopplerRadar,
        AirGroundAttackRadar,
        NavWeatherRadar,
        CITV,
        BallisticComputer,
        NightScope,
        IRScope,
        LaserRangeFinder,
        SAR,
        EOTS, //electronc optic target
        DAS, //missile warning F-35 360 allspect
        CMWS, //common missile warning less detection
        DEWS,// digital electronic warfare
        ASQ,
        CNI,  ///command and control
        FLIR,
        FLIR2G, // generation 2
        FLIR3G,
        FLIR4G,
        FLIR5G,
        GPSNAV,
        STARNAV,
        NVG2G,
        NVG3,
        NVG4G,
        IRNVG, //combined IR and NVG in one
        MMSARDR, //multi-mode SAR radar
        MMWRDR, //Multi-mode radar
        LongBow,
        SONAR,
        DIPSONAR,
        TowSonar,
        SonarBouy,
        MADPod, //Magentic Dectory ASW
        SNIPERXR, //targeting pod
        IRCM,
        IRCMPod,
        TADS,
        TADSLIDAR,
        TADSSAR,
        NAVPOD,
        TCNAV,//terrian following
        CHAFF,
        MALD,
        TOWDecoy,
        ECM,
        ECCM,
        RFWARN,
        Link16,
        MLDD,
        SPY1, //navay search radar
        SPY3, //advanced search radar
        SPG, //missile control radar
        AEGIS,
        LORAN,
        WakeDetector,
        TankGroundRadar,
        CounterArtilleryRadar,
        CounterMortarRadar,
        MineDetector,
        TorpedoDecoy,
        ISR,
        IRST,
        AWACS,
        SIGINT,
        XBandPhaseArrayRadar,
        MMJammer,
        AirSearchRadar,
        ChemicalDector
    }

    /// <summary>
    /// Generic for the Battle Management this will lower the memory for the AI so it has a common base class
    /// </summary>
    [Serializable]
    public class BaseWarGameObject : ScriptableObject
    {


        public List<Sensor> sensors;


        public List<Armor> armorslots;

        public int index;
        public int CreateState;
        public bool IsAlive;
        public string Name;
        public bool IsInService;

        public bool IsAmph;


        public float DeploymentCost;

        public DeckFactory.DeckUnitType UnitDeckType;

        public UnitCharacteristics UnitCharacteristics;
        public ObjectGeneralInfo ObjectGeneralInfo;

        public ObjectHistory ObjectHistory;
    }







    public enum APSType
    {
        none,
        RadarDecoy,
        RadarJam,
        IRDecoy,
        IRJam,
        LaserJam
    }
    public enum ArmorPosition
    {

        Front,
        Side,
        Rear,
        Top,
        Under,
        All,
        Anywhere
    }
    public enum ArmorType
    {
        None,
        Glass,
        Alunminium,
        Iron,
        Plastic,
        Steel,
        Titanium,
        Ceramic,
        Composite,
        DU,
        CarbonNano,
    }

    /// <summary>
    /// AIR BASED
    /// </summary>
    [Serializable]

    public class UnitCharacteristics
    {
        public int DeploymentCost;
        public bool HasStablizer;

        /// <summary>
        /// what year it came out in uses for eras
        /// </summary>
        public string Year;
        /// <summary>
        /// Its overall military value ie low is less special
        /// </summary>
        public int Value;
        /// <summary>
        /// Its base factor for its HP, ie tans have high strength, units with heavy armor will have high strength
        /// </summary>
        public int Strength;
        /// <summary>
        /// units ability to resist jamming the higher 1 the more likely you are to resisit, if you have low 0.20 you will get jammed
        /// </summary>
        public int Ecm;
        /// <summary>
        /// what generations it is
        /// </summary>
        public int Generation;
        /// <summary>
        /// How fast it burns through fuel rate would be to move at top speed
        /// </summary>
        public float FuelRange;
        /// <summary>
        /// How much fuel is can carry total
        /// </summary>
        public int FuelMax;
        /// <summary>
        /// how big it is fighter vs bomber 1 small drone or infantry - 10 is a aircraft carrier
        /// </summary>
        public int Size;
        /// <summary>
        ///how unstablity the unit is 1 being very stable, for vehicles and ships stabiliy is good, for aircraft its bad, aircraft with lower 0 are more manurable
        /// </summary>
        public float Instability;
        /// <summary>
        /// How easily it can be detected 1 equals will always be detected
        /// </summary>
        public float Rcs;
        /// <summary>
        /// How far ingame radius it can detect something
        /// </summary>
        public float DetectionRadius;
        /// <summary>
        /// How well the vehicle is protected against FLIR 1 = visible to Flir / 0 = nothing 
        /// </summary>
        public float ThermalRating;
        /// <summary>
        /// how long once it detects something it can shoot at it in seconds
        /// </summary>
        public int TargetTime;
        /// <summary>
        /// The diffculty of the object to be piloted in using the weapon modifier to the Weapons Relibility rate for Ships set to 0, vehicles or aircraft %
        /// </summary>
        public int PilotExp;
        /// <summary>
        /// How much it cost to deploy the unit in the battle
        /// </summary>
        public long Cost;
        /// <summary>
        /// How many aircraft come in a unit ie 2 fighters or 1 bomber
        /// </summary>
        public int UnitSize;
        /// <summary>
        /// Does the unit have a fire control system, increases the speed to target
        /// </summary>
        public bool HasFCS;

        /// <summary>
        /// Does the unit have a turret
        /// </summary>
        public bool HasTurret;
    }

    [Serializable]
    public class AircraftWeapon : Weapon
    {
        public AircraftWeaponType weaponType;

    }


    [Serializable]
    public enum HeloTypeStr
    {
        none,
        [Description("Attack Helicopter")]
        attack,
        transport,
        twinblade,
        jetcopter,
        scout,
        civilian,
        stealth,
        [Description("Gunship")]
        gunship,
        asw,
        csar,
        medevac,
        command,
        electronicwarfare,
    }


    [Serializable]
    public enum BaseAirType
    {
        None,
        Transport,
        Fighter,
        Bomber,
        Rotary,
        VTOL,
        Drone
    }
    [Serializable]
    public enum AircraftTypeStr
    {
        none,
        airsuperior,
        fighter,
        heavyfighter,
        interceptor,
        strike,
        bomber,
        strategicbomber,
        mediumbomber,
        tacticalbomber,
        interdictor,
        attack,
        gunship,
        electronicwarfare,
        martimepatrol,
        awacs,
        recon,
        experimental,
        tanker,
        transport,
        multirole,
    }

    [Serializable]
    public enum AircraftWeaponType
    {
        None = 0,
        AirToAirGun,
        AirToAirSemiActive,
        AirToAirBeamRadar,
        AirToAirRadar,
        AirToAirPassiveRadar, //AWACS killer
        AirToGround,
        AirToGroundRadar,
        AirToGroundPassiveRadar, //HARMs
        AirToGroundUnguideBomb,
        AirToGroundLaserGuidedBomb,
        AirToGroundGPSGuidedBomb,
        AirToGroundDualSeekerBomb,
        AirToGroundDecoyRadar,
        AirToGroundUnguideRocket,
        AirToGroundLaserGuidedMissile,
        AirToGroundGPSGuidedMissile,
        AirToGroundClusterBomb,
        AirToGroundCruiseMissile,
        AirToAirIRMissile,
        AirToAirElectroOpticalGuidedMissile,
        AirToGroundTvGuidedMissile,
        AirToGroundINSGuidedMissile,
        AirToGroundTriSeekerBomb,
        AirToGroundTriSeekerMissile
    }

    [Serializable]

    public class AircraftObject : BaseWarGameObject
    {

        public List<WeaponConfig> AircraftWeaponConfig;

        public AircraftTypeStr AircraftType;

        public HeloTypeStr HeloType;

        public List<AircraftWeapon> GetListWeapons()
        {
            return new List<AircraftWeapon>();
        }
    }

    [Serializable]

    public class GroundVehicleWeapon : Weapon
    {
        public GroundVehicleWeaponType weaponType;
    }

    [Serializable]

    public enum GroundVehicleWeaponType
    {
        None = 0,
        MG5_56mm,
        MG7_62mm,
        MG12_7mm,
        MG14_7mm,
        GPL20mm,
        GPL30mm,
        GPL40mm,
        C20mm,
        C23mm,
        C37mm,
        C40mm,
        C45mm,
        C57mm,
        C76mm,
        C90mm,
        C100mm,
        C105mm,
        C120mm,
        C140mm,
        C125mm,
        C152mm,
        C155mm,
        C156mm,
        C160mm,
        C204mm,
        M60mm,
        M81mm,
        M82mm,
        M120mm,
        GAU5,
        GAU7,
        GAU12,
        GAU20,
        GAU30,
        ATGMOptical,
        ATGMIR,
        ATGMRadar,
        ATGMLaser,
        ATGMGPS,
        ATGMMulti,
        Rocket57mm,
        Rocket70mm,
        Rocket80mm,
        Rocket122mm,
        Rocket288mm,
        Rocket300mm,
        SurfaceToSurfaceGPS,
        SurfaceToSurfaceINS,
        SurfaceToSurfaceIR,
        SurfaceToSurfaceLaser,
        SurfaceToSurfaceMuti,
        SurfaceToSurfaceOptic,
        SurfaceToAirRadar,
        SurfaceToAirIR,
        SurfaceToAirOptic,
        SurfaceToAirLaser,
    }

    [Serializable]

    public enum BaseGroundType
    {
        None,
        Log,
        X4,
        APC,
        TANK,
        Artillery,
        Misc

    }

    [Serializable]

    public enum GroundVehicleType
    {
        none,
        tank,
        MBT,
        lighttank,
        amphtank,
        vehicle,
        armorcar,
        mrap,
        ifv,
        apc,
        spagun,
        mlrs,
        transport,
        recon,
        technical,
        AAA,
        SAM,
        ewarfare,
    }

    [Serializable]

    public enum InfType
    {
        none,
        lightinfantry,
        shockinfantry,
        specialforces,
        specialforcesnaval,
        paratroopers,
        irregular,
        conscription
    }

    [Serializable]

    public enum logisticType
    {
        none,
        commander,
        xocommander,
        groundresupply,
        groundarmoredresupply,
        commanderair,
        resupplybase,

    }

    [Serializable]

    public enum UnmannedType
    {
        none,
        ground, //unarmed
        remotepilot,
        helo,
        suv,
        mav,
        groundheavy,
        selfdrivecar,
        unmannedfighter,
        unmannedbomber,
        unmannedcargo,
        unmannedtanker,
        unmannedsea,
        unmannedseaheavy,
        unmannedASW,
        unmannedISR,
        specialOps
    }
    [Serializable]

    public enum UnitType
    {
        aircarrier,
        helocarrier,
        vstolcarrier,
        supercarrier,
        subcarrier, //future 
        stealthcarrier, //future
        guidemisslecruiser,
        battlecrusier,
        helodestoryer,
        guidemissiledestoryer,
        airdefensedestoryer,
        multiroledestoryer,
        stealthdestoryer,
        aswdestoryer,
        patrolfrigate,
        airdefensefrigate,
        guidemissilefrigate,
        stealthfrigate,
        corvette,
        missilecorvette,
        stealthcorvette,
        cutter,
        patrolmissile,
        patrolgun,
        riverine,
        fastattackboat,
        minesweeper,
        minelayer,
        amphibiousassaultship,
        amphibiouslandingship,
        landingshiptank,
        hovercraft,
        oiler,// refuels ships
        attack,
        transport,
        twinblade,
        jetcopter,
        scout,
        civilian,
        stealth,
        gunship,
        asw,
        csar,
        medevac,
        command,
        electronicwarfare,
        martimepatrol,
        awacs,
        recon,
        experimental,
        tanker,
        multirole,
        airsuperior,
        fighter,
        heavyfighter,
        interceptorr,
        strike,
        bomber,
        strategicbomber,
        mediumbomber,
        tacticalbomber,
        interdictor,
        tank,
        MBT,
        lighttank,
        amphtank,
        vehicle,
        armorcar,
        ifv,
        apc,
        spagun,
        mlrs,
        technical,
        AAA,
        SAM,
        ewarfare,
        lightinfantry,
        shockinfantry,
        specialforces,
        specialforcesnaval,
        paratroopers,
        irregular,
        conscription,
        commander,
        xocommander,
        groundresupply,
        groundarmoredresupply,
        commanderair,
        resupplybase,
        ground, //unarmed
        remotepilot,
        helo,
        suv,
        mav,
        groundheavy,
        selfdrivecar,
        unmannedfighter,
        unmannedbomber,
        unmannedcargo,
        unmannedtanker,
        unmannedsea,
        unmannedseaheavy,
        unmannedASW,
        unmannedISR,
        specialOps
    }
    /// <summary>
    /// The main combat vehicles 
    /// </summary>
    [Serializable]

    public class GroundVehicleObject : BaseWarGameObject
    {
        public List<WeaponConfig> GroundVehicleWeaponConfig;

        public List<GroundVehicleWeapon> GetListWeapons()
        {
            return new List<GroundVehicleWeapon>();
        }

        public GroundVehicleType GroundVehicleType;
    }

    /// <summary>
    /// Dismounted Infantry come with a vehicle which can be air/sea or ground based they can capture grids and hold them
    /// </summary> 
    [Serializable]
    public class InfObject : BaseWarGameObject
    {
        public List<WeaponConfig> InfWeaponConfig;
        public List<GroundVehicleWeapon> GetListWeapons()
        {
            return new List<GroundVehicleWeapon>();
        }

        public bool IsCapturing;
        public InfType InfType;
    }

    /// <summary>
    /// Logistic can be both air or ground refuel tanker etc but what makes them different is they can resupply 
    /// </summary>
    [Serializable]

    public class LogisitcObject : BaseWarGameObject
    {
        public List<WeaponConfig> GroundVehicleWeaponConfig;
        public List<GroundVehicleWeapon> weapons;
        public float Resupply;
        public float MaxResupply;
        public logisticType GroundVehicleType;
    }

    /// <summary>
    /// Unmanned vehicles can be either air or ground but they don't have humans so you can risk them much more, but they are limited in there effectiveness
    /// </summary>
    [Serializable]

    public class UnmannedObject : BaseWarGameObject
    {
        public List<WeaponConfig> UnmannedVehicleWeaponConfig;
        public List<Weapon> weapons;
        public float UnmannedRanged;
        public UnmannedType UnmannedVehicleType;
    }


    /// <summary>
    /// SEA BASED 
    /// </summary>
    [Serializable]

    public class SeaObjectCharacteristics
    {
        public int Displacement;
        public float ShipScanRange;
        public float ShipPreception;
        public float ShipElectronicSignature;
        public float ShipIRSignature;
        public float ShipSonarRate;
        public float ShipRCS;
        public bool IsASW;
        public bool IsSSK; // is a desiel sub has a different sonar profile
        public bool IsSub;
        public bool IsCarrier;
        public bool IsTransport;
        public bool IsNuclearPower;
        public List<UnmannedObject> Unmannedvehicles; // like a fire scout
        public List<GroundVehicleObject> GroundVehicles; // if it carries tanks like a LHA
        public List<AircraftObject> Aircraft; // if its a carrier or helo
    }


    [Serializable]
    public class SeaObjectPerformance
    {
        /// <summary>
        /// The number of liters of fuel
        /// </summary>
        public int ShipFuel;
        /// <summary>
        /// The Max refuel when you refueld a ship it carries this much
        /// </summary>
        public int ShipMaxFuel;
        /// <summary>
        /// The number of liters of fuel for aircraft to use in carriers or helicopters used to refuel ships etc
        /// </summary>
        public int AircraftFuel;
        /// <summary>
        /// The Max refuel when you refueld a ship it carries this much
        /// </summary>
        public int AircraftMaxFuel;
        /// <summary>
        /// Used to calculate the ships moving speed in game
        /// </summary>
        public int MaxCruiseSpeed;
        /// <summary>
        /// Used to calucate the ships burn rate of fuel before it has to refuel
        /// </summary>
        public int MaxRangeWithoutRefuel;
        /// <summary>
        /// THe max range of its dectection equipment renders as a radius in game
        /// </summary>
        public int MaxDetectionRange;
    }

    [Serializable]
    public class SeaObjectWeaponConfig
    {
        public string Name;
        public float MaxWeaponsPayload;
        public float CrewSkill;
        public List<WeaponStationType> WeaponsStations;
    }

    [Serializable]

    public enum WarheadType
    {
        /// <summary>
        /// Does no damage can be used for placeholders
        /// </summary>
        Dummy,
        /// <summary>
        /// Dual purpose is effective against tanks and infantry
        /// </summary>
        DualPurpose,
        /// <summary>
        /// Effective against structures, caves
        /// </summary>
        Thermobaric,
        /// <summary>
        /// Explodes on contact for mines, and bombs
        /// </summary>
        Contact,
        /// <summary>
        /// Delayed useful for mines, sea mines etc
        /// </summary>
        Proxmity,
        /// <summary>
        /// Delayed artillery and bombs allows for deeper penerations
        /// </summary>
        Timed,
        /// <summary>
        ///  HE proviides a balance of lethality and weight
        /// </summary>
        HighExplosive,
        /// <summary>
        /// Lethal to humans without gear
        /// </summary>
        Chemical,
        /// <summary>
        /// Works slower the chemical but equally lethal
        /// </summary>
        BioWeapon,
        /// <summary>
        /// high blast wave and over-pressure
        /// </summary>
        Nuclear,
        Frag,
        Blast,
        Cansiter,
        Shaped,
        ArmorPenator,
        EFP,
        EMP,
        MircoWave,
        Jamer,
        SubmunitionAP,
        SubmunitionAT,
        Sabot,
        FMJ,
        API,
        SensorFuze,
        Airbust,
        TearGas
    }
    [Serializable]

    public enum WeaponPerks
    {
        HEAT,
        OPTIC,
        GPS,
        IR,
        HEDP,
        APFSDT, //sabot
        AIP, //incidenary
        RIFLED,
        HESH,
        SmoothBore,
        WireGuided,
        RocketAssist,
        Gatling,
        ActiveRadarGuided,
        SeaSkimmning,
        TerrianGuiding,
        INS,
        JamResisitant,
        WakeGuided,
        BeltFeed,
        Hypersonic,
        MIRV,
        LaserProof,
        HighAngleOfAttack,
        NonLethal,
        LaserGuided,
        DataLink
    }

    [Serializable]
    public class SeaObjectWeapon : Weapon
    {
        public SeaWeaponType weaponType;

    }

    [Serializable]

    public enum SeaWeaponType
    {
        None,
        Cal50,
        C20mm, //mount on CG47
        C25mm,
        C30mm,
        C40mm, //AWACS killer
        C45mm, //BOFO
        C76mm, //NATO/RUS
        C90mm, //HARMs
        C100mm, //RUS PRC
        C127mm, //Mk45
        C130mm,  //Russian 
        C155mm, //AGS
        C406mm, //16 inch on BB
        CIWS20m,
        CIWS30m,
        CIWSLaser,
        AntiShipMissileRadar,
        AntiShipSupersonicMissile,
        AntiShipSteathMissile,
        AntiAirMissileRadar,
        AntiAirMissileIR,
        AntiAirMissileLaser,
        LightWeightTorpedo324mmm,
        MediumWeightTorpedo533mm,
        HeavyWeightTorpedo650mm,
        UnderwaterRocket,
        SeafloorMine,
        SmartMine,
        UnguidedMine,
        CruiseMissile,
        Asroc,
        DepthCharge,
        CIWSMissle,
        AntiShipMissileGPS,
        AntiShipMissileIntertial,
        AntiShipMissileIR,
        AntiShipMissileMultiseeker,
        SLBM,
        SSL100Kw,
        SSL300Kw,
        SSL500Kw,
        SSL1Mw,
        SSL2Mw,
        /// <summary>
        /// 12 Rpm
        /// </summary>
        RailGun16Mj3Mw,
        RailGun32Mj6Mw,
        RailGun64Mj12Mw,
        RailGun128Mj24Mw,
        //particule beam
    }

    [Serializable]
    public enum BaseSeaType
    {
        None,
        Carrier,
        DDG,
        FFG,
        Corvette,
        Patrol,
        Mine,
        Amph,
        Sub
    }

    [Serializable]

    public enum SeaObjectType
    {
        none,
        aircarrier,
        helocarrier,
        vstolcarrier,
        supercarrier,
        subcarrier, //future 
        stealthcarrier, //future
        guidemisslecruiser,
        battlecrusier,
        helodestoryer,
        guidemissiledestoryer,
        airdefensedestoryer,
        multiroledestoryer,
        stealthdestoryer,
        aswdestoryer,
        patrolfrigate,
        airdefensefrigate,
        guidemissilefrigate,
        stealthfrigate,
        corvette,
        missilecorvette,
        stealthcorvette,
        cutter,
        patrolmissile,
        patrolgun,
        riverine,
        fastattackboat,
        minesweeper,
        minelayer,
        amphibiousassaultship,
        amphibiouslandingship,
        landingshiptank,
        hovercraft,
        oiler // refuels ships 
    }


    [Serializable]
    public class SeaObject : BaseWarGameObject
    {

        public SeaObjectCharacteristics SeacraftCharacteristics;

        public SeaObjectPerformance SeacraftPerformance;

        public List<SeaObjectWeaponConfig> SeacraftWeaponConfig;

        public List<SeaObjectWeapon> weapons;

        public SeaObjectType SeacraftType;

        public bool IsDeckFlagShip;


        public string SeacraftTypeName;


        public int SeacraftTypeId;

    }

    public enum DefconLevel
    {
        DEFCONZero = 0,
        DEFCONOne = 1,
        DEFCONTwo = 2,
        DEFCONThree = 3,
        DEFCONFour = 4,
        DEFCONFive = 5,
    }

    public enum COGCONLevel
    {
        [Description("Activate classified CONPLAN 3600 evacuating the President and those in the line of presidential succession. Activate classified CONPLAN 3502 deploying the military to enforce law and order within the Civilian Control Districts. Seize all private communication facilities and assume control over all civilian voice and data communications. Activate internet kill switch under SOP 303. Commandeer all U.S. domestic resources including food and water. Seize all domestic energy and transportation infrastructure. Deploy the national citizen conscription plan to fulfill any labor required for the purpose of national defense and reconstitution.")]
        COGCONZero = 0,
        [Description("Full deployment of designated leadership and continuity staffs to perform the organization’s essential functions from alternate facilities either as a result of, or in preparation for, a catastrophic emergency.")]
        COGCONOne = 1,
        [Description("Routine protective security measures appropriate to the business concerned.Deployment of 50-75% of Emergency Relocation Group continuity staff to alternate locations. Establish their ability to conduct operations and prepare to perform their organization’s essential functions in the event of a catastrophic emergency.")]
        COGCONTwo = 2,
        [Description("Federal agencies and departments Advance Relocation Teams “warm up” their alternate sites and capabilities, which include testing communications and IT systems. Ensure that alternate facilities are prepared to receive continuity staff. Track agency leaders and successors daily.")]
        COGCONThree = 3,
        [Description("Federal executive branch government employees at their normal work locations. Maintain alternate facility and conduct periodic continuity readiness exercises.")]
        COGCONFour = 4,
    }

    public enum ThreatResponse
    {
        [Description("Routine protective security measures appropriate to the business concerned.")]
        Normal,
        [Description("Additional and sustainable protective security measures reflecting the broad nature of the threat combined with specific business and geographical vulnerabilities and judgements on acceptable risk.")]
        Heightened,
        [Description("Maximum protective security measures to meet specific threats and to minimise vulnerability and risk. Critical may also be used if a nuclear attack is expected.")]
        Exceptional
    }
    public enum ThreatLevel
    {
        [Description("An attack is very unlikely.")]
        Low,
        [Description("An attack is possible, but not likely.")]
        Moderate,
        [Description("An attack is a strong possibility.")]
        Substantial,
        [Description("An attack is highly likely.")]
        Severe,
        [Description("An attack is expected imminently.")]
        Critical
    }

    public enum PlatformBase
    {
        LandSilo,
        LandRoadMobile,
        LandRailBase,
        Bomber,
        Fighter,
        Submarine,
        SeaBased,
        Space,
        Tactical
    }



    public enum WMDType
    {
        [Description("Sarin, VX")]
        nerveAgent,
        ricin,
        lewisiteBlister,
        mustardgas,
        Phosgene,
        BZ,
        biotoxin,
        infectiousAgent,
        bioWeapon,
        nanoWeapon,
        insectWarfare,
        nuclear,
        radition,
        emp,
        nuetron,
        ditybomb

    }


    public enum WeaponRangeClass
    {
        Tactical,
        FreeFall,
        CrusieMissile,
        SRBM,
        MRBM,
        IRBM,
        ICBM,
        SLBM,
        ASAT
    }

    public enum KitValueType
    {
        Armor,
        GunAccurancy,
        KillSight,
        Ammo,
        Grenade,
        Health
    }

    public enum KitType
    {
        Any,
        [Description("Scount Sniper")]
        Sniper,
        [Description("Assault Rifleman")]
        Assault,
        [Description("Combat Medic")]
        Medic,
        [Description("Designated Marksman")]
        DMR,
        [Description("Squad Automatic Rifleman")]
        SAW,
        [Description("Grenadier")]
        Grenadier,
        [Description("Sargent")]
        Nco,
        [Description("Squad Leader")]
        SquadLeader,
        [Description("Anti-Tank")]
        Antitank,
        [Description("Rifleman")]
        Rifleman,
        [Description("Rifleman")]
        EOD

    }
    public enum TeamSpecialization
    {
        DirectCombat,
        PoliceAction,
        CounterTerrorism,
        CombatDiving,
        MartimeBoardings,
        Paratrooper,
        ScoutSniper,
        CombatRescue,
        GuerrillaWarfare,
        CounterInsurgency,
        ForeignDefense,
        IntelligenceSurveliance,
        ColdWeatherCombat,
        WildernessSurvival,
        JungleWarfare,
        MountainWarfare,
        JTAC,
        Pathfinding,
        CombatEngineer,
        EOD,
        UnderwaterDemolition,
        UrbanWarfare,


    }

    [System.Serializable]
    public class Gear
    {
        public string GearName;
        public KitType GearKitType;
        public KitValueType GearPerkType;
        [Range(-100.0f, 100.0f)]
        public float GearValue;
        public int GearCount;

    }

    [System.Serializable]
    public class TeamKits
    {
        public string Name;
        public Weapon Gun;
        public KitType Kit;
        public float KitsKillSight;
        public float KitGunHitRate;
        public float KitHealthHP;
        public List<Gear> Gear;
    }
    [System.Serializable]
    public class Operator
    {
        public Contact Teammate;
        public TeamKits Kit;
        public string TeamSquadName;
        public ContactGenerator.ContactHealthStatus Status;
        public bool IsKIA;
        public bool IsMIA;
        public bool IsDeployed;
    }

}
