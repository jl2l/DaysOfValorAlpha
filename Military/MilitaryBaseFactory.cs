using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using Assets;
using System.ComponentModel;

public class MilitaryBaseFactory
{
    [MenuItem("Tools/MyTool/Do It in C#")]
    static void DoIt()
    {
        EditorUtility.DisplayDialog("MyTool", "Do It in C# !", "OK", "");
    }
    /// <summary>
    /// What type of vehicles can refuel from the base
    /// </summary>
    public enum BaseType
    {
        [Description("Major Installation")]
        MajorInstallation, //unlimited decks can stay here
        [Description("Minor Installation")]
        MinorInstallation, //decks can stay here up to certain number
        [Description("Major Naval Base")]
        MajorNavalBase, //refuel ships here
        [Description("Major Installation")]
        MajorAirBase, //store aircraft here
        [Description("Major Installation")]
        MainOperatingBase, //all units
        [Description("Major Installation")]
        SupportBase, //supplies transfer from here to another base, and resupply reload here
        [Description("Major Installation")]
        CooperativeSecurityLocationBase, //joint base with allied country, if you lose alliance etc this goes away
        [Description("Major Installation")]
        ForwardOperatingBase, //this is a base in an allied country that can be used to launch attacks you must move decks to forward bases
        [Description("Major Installation")]
        ForwardSupportBase, //this is a base in a llied counry that can resupply others they cost more and resupply faster but have less overall supplies
        [Description("Major Installation")]
        CovertSupportBase, //this is a covert facility that can be used to launch intel and covert operations, it can be anywhere, but can be detect by hostile countries intelligence services
        [Description("Major Installation")]
        ElectronicSupportBase,//this is a covert facility designed to capture signals intelligences it can be anywhere but can also be discovered and disabled.
        [Description("Fire Support Bases have more slots for indirect fire weapons and less for barracks or logistics.")]
        FireSupportBase
    }

    public enum BaseIconType
    {
        Base,
        HQ,
        OP,
        Log,
        Sig,
        Covert,
        AlliedBase,
        AlliedHQ,
        AlliedOP,
        AlliedLog,
        AlliedSig,
        AlliedCovert,
        OpforBase,
        OpforHQ,
        OpforOP,
        OpforLog,
        OpforSig,
        OpforCovert,
        RebelBase,
        RebelHQ,
        RebelOP,
        RebelLog,
        RebelSig,
        RebelCovert,
    }
    public enum BaseDefenses
    {
        BarbWire,
        RazorWire,
        HescoSingle,
        HescoDouble,
        ConcreteHalf,
        ConcreteWall,
        ImprovisedBarricades,
        ChainLinkFence,
        AntiTankMines,
        AntiPersonelMines,
        TankObstacle,
        GroundSensor,
        ElectronicPassive,
        AutomatedDefense,
        GuardDogs
    }
    public enum BaseSpecialize
    {
        [Description("Indirect Artilley Support")]
        MortarArtillery, //all artillery weapons will be better mortars defense and artillery in offensive
        [Description("Indirect Missile Support")]
        Missilery, // all missiles defense and offesne will be better, reduce time for missile strikes
        [Description("Intelligence Gathering Site")]
        Intelligence,// the base can gather intellgience faster and lowers the timers for the intel and covert stuff
        [Description("Vehicle Maintenance Repair Depot ")]
        ArmoredRepair, // reairs tanks and armored vehicles faster
        [Description("Medical Care Facility ")]
        Medical, // heals units faster
        [Description("Aircraft Maintenance and Repair Depot")]
        AirRepair,
        [Description("Airbase Air Traffic Controller")]
        AirController, //increase the sortie rate
        [Description("Airbase Air Traffic Controller")]
        Barracks, //increase the sortie rate
        [Description("Airbase Air Traffic Controller")]
        AutoDefenses, //increase the sortie rate
        [Description("Airbase Air Traffic Controller")]
        FuelStorage, //increase the sortie rate
        [Description("Airbase Air Traffic Controller")]
        ChemicalWeaponsStorage, //increase the sortie rate
        [Description("Airbase Air Traffic Controller")]
        NucearWeaponsStorage, //increase the sortie rate
        [Description("Airbase Air Traffic Controller")]
        MissileSiloSite, //increase the sortie rate
        [Description("Airbase Air Traffic Controller")]
        FirebaseMLRS, //increase the sortie rate
        [Description("Airbase Air Traffic Controller")]
        HighGainSat, //increase the sortie rate
        [Description("Airbase Air Traffic Controller")]
        PowerGenerator, //increase the sortie rate
        [Description("Airbase Air Traffic Controller")]
        GuardTower, //increase the sortie rate
        [Description("Airbase Air Traffic Controller")]
        GroundRadar, //increase the sortie rate
        [Description("Airbase Air Traffic Controller")]
        BarracksTent, //increase the sortie rate
        [Description("Airbase Air Traffic Controller")]
        BaseWarfactory, //increase the sortie rate
        [Description("Airbase Air Traffic Controller")]
        AirSearchRadar, //increase the sortie rate
        [Description("Airbase Air Traffic Controller")]
        RadioTower, //increase the sortie rate
        [Description("Airbase Air Traffic Controller")]
        NonNATORadarTower, //increase the sortie rate
        [Description("Airbase Air Traffic Controller")]
        Helipad, //increase the sortie rate
        [Description("Shipping containers")]
        LogisticalStorage, //increase the sortie rate
        [Description("Shipping containers")]
        KillHouseTraining, //increase the sortie rate
        [Description("Shipping containers")]
        BaseDefenseHescoWalls, //increase the sortie rate
        [Description("Shipping containers")]
        BaseMGBunker,
        [Description("Shipping containers")]
        BaseIndirectFireBunker,
        [Description("Shipping containers")]
        ShootingRanging,
        [Description("Shipping containers")]
        SpecialOperationsCenter,
        [Description("Shipping containers")]
        PXStore,
        [Description("Shipping containers")]
        LaundryServices,
        [Description("Shipping containers")]
        WasteManagement,
        [Description("Shipping containers")]
        WaterDesalinator,
        [Description("Shipping containers")]
        PowerGeneratorWindTurbine,
        [Description("Shipping containers")]
        Airstrip,
        [Description("Shipping containers")]
        LargeAirstrip,
        [Description("Shipping containers")]
        MunitionsBunker,
        [Description("Shipping containers")]
        UndergroundMunitonsBunker,
        [Description("Shipping containers")]
        UndergroundFuelStorage

    }
    public WeaponsConfigFactory weaponConfigFactory = new WeaponsConfigFactory();

    public List<WeaponStationType> DefaultBaseWeapons()
    {
        var defaultBaseDefenses = new List<WeaponStationType>();
        defaultBaseDefenses.Add(weaponConfigFactory.CreateWeaponStationType(WeaponStationType.PointType.Fixed, new string[] { "M198 155mm", "MGM52 Lance" }, WeaponsConfigFactory.WeaponFactoryType.Ground));
        return defaultBaseDefenses;
    }


    public List<MilitaryBase> DefaultList(GameObject PlayerMilitaryBases)
    {

        return new List<MilitaryBase>()
        {
           CreateMilitaryBase(PlayerMilitaryBases),
           CreateMilitaryBase(PlayerMilitaryBases),
        };
    }
    public MilitaryBase CreateMilitaryBase(GameObject gameObject)
    {
        // var newBase = gameObject.AddComponent<MilitaryBase>();

        return new MilitaryBase();
    }

    public MilitaryBase GetBaseByName()
    {

        return new MilitaryBase();
    }

    public MilitaryBase GetBaseByProvinceName()
    {

        return new MilitaryBase();
    }

    public MilitaryBase GetBaseById()
    {

        return new MilitaryBase();
    }
}