using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{

    public class ForcesFactory
    {
        public List<GroundVehicleObject> MasterGroundUnitList = new List<GroundVehicleObject>();
        public List<GroundVehicleObject> MasterTanksList = new List<GroundVehicleObject>();
        public List<SeaObject> MasterShipList = new List<SeaObject>();
        public ForcesWeaponsFactory weaponFactory = new ForcesWeaponsFactory();
        public WeaponsConfigFactory weaponConfigFactory = new WeaponsConfigFactory();
        public ForcesSensorFactory sensorFactory = new ForcesSensorFactory();


        public int SetRHARating(ArmorType armorType)
        {
            var rha = 0;

            switch (armorType)
            {
                case ArmorType.None:
                    rha = 0;
                    break;
                case ArmorType.Plastic:
                    rha = 1;
                    break;
                case ArmorType.Glass:
                    rha = 1;
                    break;
                case ArmorType.Alunminium:
                    rha = 2;
                    break;
                case ArmorType.Iron:
                    rha = 3;
                    break;
                case ArmorType.Steel:
                    rha = 5;
                    break;
                case ArmorType.Titanium:
                    rha = 10;
                    break;
                case ArmorType.Ceramic:
                    rha = 15;
                    break;
                case ArmorType.Composite:
                    rha = 20;
                    break;
                case ArmorType.DU:
                    rha = 25;
                    break;
                case ArmorType.CarbonNano:
                    rha = 30;
                    break;
            }

            return rha;
        }

        public void StartFactoryContext()
        {
            weaponFactory = new ForcesWeaponsFactory();
            weaponConfigFactory = new WeaponsConfigFactory();
            sensorFactory = new ForcesSensorFactory();
            sensorFactory.InitalizeSensorList();
        }

        public List<SeaObject> BuildUSShipStub()
        {

            var weaponsList = weaponConfigFactory.GetSeaWeaponsConfigList();
            var s = sensorFactory.GetSensorsByName(new string[] { "AN/SPS-48E", }, this);
            return new List<SeaObject>() {
                   #region Ship LCS-2
                new SeaObject
                {
                    Name = "USS Freedom",
                         UnitDeckType = DeckFactory.DeckUnitType.Sea,
                },
                    #endregion
                new SeaObject
                {
                    Name = "USS Burke",
                         UnitDeckType = DeckFactory.DeckUnitType.Sea,
                },
                new SeaObject
                {
                    Name = "USS Tico",
                         UnitDeckType = DeckFactory.DeckUnitType.Sea,
                },

                #region USS Ford Class
                new SeaObject
                {
                    Name = "USS Ford",
                SeacraftType = SeaObjectType.amphibiouslandingship,
                UnitDeckType = DeckFactory.DeckUnitType.Sea,
                #region ARMOR
                armorslots = new List<Armor> {
                new Armor() {
                    Position = ArmorPosition.Front, APSAmmo = 3600, APSRate = 0.85f,  HasAPS = true, HasSpallLiner = true,
                    ArmorRating = 3,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                },
                new Armor() {
                    Position = ArmorPosition.Side,  APSAmmo = 3600, APSRate = 0.85f,  HasAPS = true, HasSpallLiner = true,
                    ArmorRating = 3,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                },new Armor() {
                    Position = ArmorPosition.Rear,  APSAmmo = 3600, APSRate = 0.85f,  HasAPS = true, HasSpallLiner = true,
                    ArmorRating = 3,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                },new Armor() {
                    Position = ArmorPosition.Top, APSAmmo = 3600, APSRate = 0.85f,  HasAPS = true, HasSpallLiner = true,
                    ArmorRating = 3,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                }},
                #endregion
                SeacraftWeaponConfig = new List<SeaObjectWeaponConfig>() {
                    weaponConfigFactory.ReturnSeaWeaponConfigBy("Uss Wasp") },
                #region Sensors
                sensors = s,
                #endregion
                IsInService = true,
                CreateState = 1,
                SeacraftCharacteristics = new SeaObjectCharacteristics
                {
                Aircraft = new List<AircraftObject>(),
                Displacement = 101600,
                IsASW = false,
                GroundVehicles = new List<GroundVehicleObject>(),
                IsCarrier = true,
                IsNuclearPower = true,
                IsSSK = false,
                IsSub = false,
                IsTransport = true,
                ShipElectronicSignature = 1f,
                ShipIRSignature = 1f,
                ShipPreception = 15f,
                ShipRCS = 1.5f,
                ShipScanRange = 100f,
                ShipSonarRate = 100f,
                Unmannedvehicles = new List<UnmannedObject>(),


                },
                SeacraftPerformance = new SeaObjectPerformance {
                    MaxCruiseSpeed = 41,
                    MaxDetectionRange = 0,
                    MaxRangeWithoutRefuel = 1760000,
                    ShipFuel = 7089436,
                    ShipMaxFuel = 7089436
                },
                IsAlive = false, //spawned in the game or not default off
                ObjectGeneralInfo = new ObjectGeneralInfo()
                {
                    CountryOfOrigin = "US",
                    CountryOfOriginIndex = 1,
                    CrewNumber = 983,
                    EmptyWeight = 0,
                    Height = 3,
                    Length = 10,
                    LoadedWeight = 0,
                    Name = "Ford Class",
                    OfficerNumber = 98,
                    TroopCarryTotal = 2000,
                    Powerplant = new Powerplant() { Name = "Geared Steam Turbines", NumberOf = 2, PowerGeneration = 70000, TypeOfPower = Powerplant.PowerPlantType.gasturbine },
                    ProgramName = "WASP Class",
                    TotalNumberBuilt = 8
                },
                ObjectHistory = new ObjectHistory(),
                UnitCharacteristics = new UnitCharacteristics()
                {
                    #region Characteristics
                    Cost = 1500000000000,
                    DetectionRadius = 0, //TODO this should calculate in sensors
                    Ecm = 6,
                    FuelMax = 7089436,
                    FuelRange = 60,
                    Generation = 3,
                    HasFCS = true,
                    HasTurret = false,
                    HasStablizer = true,
                    Instability = 1f,
                    PilotExp = 0,
                    Rcs = 1,
                    Size = 10,
                    UnitSize = 1,
                    TargetTime = 2,
                    ThermalRating = 1,
                    DeploymentCost = 1200,
                    Value = 8,
                    Year = "1986"
                    #endregion
                }
                },
                #endregion
                    #region Ship USS Wasp

                new SeaObject
                {
                    Name = "USS Wasp",
                SeacraftType = SeaObjectType.amphibiouslandingship,
                UnitDeckType = DeckFactory.DeckUnitType.Sea,
                #region ARMOR
                armorslots = new List<Armor> {
                new Armor() {
                    Position = ArmorPosition.Front, APSAmmo = 3600, APSRate = 0.85f,  HasAPS = true, HasSpallLiner = true,
                    ArmorRating = 3,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                },
                new Armor() {
                    Position = ArmorPosition.Side,  APSAmmo = 3600, APSRate = 0.85f,  HasAPS = true, HasSpallLiner = true,
                    ArmorRating = 3,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                },new Armor() {
                    Position = ArmorPosition.Rear,  APSAmmo = 3600, APSRate = 0.85f,  HasAPS = true, HasSpallLiner = true,
                    ArmorRating = 3,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                },new Armor() {
                    Position = ArmorPosition.Top, APSAmmo = 3600, APSRate = 0.85f,  HasAPS = true, HasSpallLiner = true,
                    ArmorRating = 3,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                }},
                #endregion
                SeacraftWeaponConfig = new List<SeaObjectWeaponConfig>() {
                    weaponConfigFactory.ReturnSeaWeaponConfigBy("Uss Wasp") },
                #region Sensors
                sensors = s,
                #endregion
                IsInService = true,
                CreateState = 1,
                SeacraftCharacteristics = new SeaObjectCharacteristics
                {
                Aircraft = new List<AircraftObject>(),
                Displacement = 101600,
                IsASW = false,
                GroundVehicles = new List<GroundVehicleObject>(),
                IsCarrier = true,
                IsNuclearPower = false,
                IsSSK = false,
                IsSub = false,
                IsTransport = true,
                ShipElectronicSignature = 1f,
                ShipIRSignature = 1f,
                ShipPreception = 15f,
                ShipRCS = 1.5f,
                ShipScanRange = 100f,
                ShipSonarRate = 100f,
                Unmannedvehicles = new List<UnmannedObject>(),


                },
                SeacraftPerformance = new SeaObjectPerformance {
                    MaxCruiseSpeed = 41,
                    MaxDetectionRange = 0,
                    MaxRangeWithoutRefuel = 1760000,
                    ShipFuel = 7089436,
                    ShipMaxFuel = 7089436
                },
                IsAlive = false, //spawned in the game or not default off
                ObjectGeneralInfo = new ObjectGeneralInfo()
                {
                    CountryOfOrigin = "US",
                    CountryOfOriginIndex = 1,
                    CrewNumber = 983,
                    EmptyWeight = 0,
                    Height = 3,
                    Length = 10,
                    LoadedWeight = 0,
                    Name = "Wasp Class",
                    OfficerNumber = 98,
                    TroopCarryTotal = 2000,
                    Powerplant = new Powerplant() { Name = "Geared Steam Turbines", NumberOf = 2, PowerGeneration = 70000, TypeOfPower = Powerplant.PowerPlantType.gasturbine },
                    ProgramName = "WASP Class",
                    TotalNumberBuilt = 8
                },
                ObjectHistory = new ObjectHistory(),
                UnitCharacteristics = new UnitCharacteristics()
                {
                    #region Characteristics
                    Cost = 1500000000000,
                    DetectionRadius = 0, //TODO this should calculate in sensors
                    Ecm = 6,
                    FuelMax = 7089436,
                    FuelRange = 60,
                    Generation = 3,
                    HasFCS = true,
                    HasTurret = false,
                    HasStablizer = true,
                    Instability = 1f,
                    PilotExp = 0,
                    Rcs = 1,
                    Size = 10,
                    UnitSize = 1,
                    TargetTime = 2,
                    ThermalRating = 1,
                    DeploymentCost = 1200,
                    Value = 8,
                    Year = "1986"
                    #endregion
                }
                #endregion
                }

        };
        }


        public List<GroundVehicleObject> BuildUSTanks()
        {
            var tanksList = new List<GroundVehicleObject>();
            var weaponsList = weaponConfigFactory.GetWeaponsConfigList();
            var se = sensorFactory.GetSensorsByName(new string[] { "Avanced Ballistic Computer", "CBRN Protection", "Intergrated Thermal Sight", "Laser Range Finder" }, this);

            #region Vehicle M1IP Abrams

            tanksList.Add(new GroundVehicleObject
            {
                GroundVehicleType = GroundVehicleType.MBT,
                #region ARMOR
                armorslots = new List<Armor> {
                new Armor() {
                    Position = ArmorPosition.Front, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 20,
                    ArmorType = ArmorType.Composite,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                },
                new Armor() {
                    Position = ArmorPosition.Side, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 18, //ggg
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = true
                },new Armor() {
                    Position = ArmorPosition.Rear, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 20,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false,  IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = false
                },new Armor() {
                    Position = ArmorPosition.Top, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 18,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                }},

                #endregion
                GroundVehicleWeaponConfig = new List<WeaponConfig>() {
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank Sabot"),
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank HEAT") },
                #region Sensors
                sensors = se,
                #endregion
                IsInService = true,
                Name = "M1IP Abrams",
                CreateState = 1,
                IsAlive = false, //spawned in the game or not default off
                ObjectGeneralInfo = new ObjectGeneralInfo()
                {
                    CountryOfOrigin = "US",
                    CountryOfOriginIndex = 1,
                    CrewNumber = 4,
                    EmptyWeight = 60,
                    Height = 3,
                    Length = 10,
                    LoadedWeight = 65,
                    Name = "M1 Abrams IP",
                    OfficerNumber = 1,
                    Powerplant = new Powerplant() { Name = "Gas Turbine", NumberOf = 1, PowerGeneration = 960, TypeOfPower = Powerplant.PowerPlantType.gasturbine },
                    ProgramName = "XM107",
                    TotalNumberBuilt = 10000
                },
                ObjectHistory = new ObjectHistory(),
                UnitCharacteristics = new UnitCharacteristics()
                {
                    #region Characteristics
                    Cost = 6000000,
                    DetectionRadius = 4000,
                    Ecm = 6,
                    FuelMax = 2000,
                    FuelRange = 60,
                    Generation = 3,
                    HasFCS = true,
                    HasTurret = true,
                    HasStablizer = true,
                    Instability = 0.95f,
                    PilotExp = 1,
                    Rcs = 1,
                    Size = 3,
                    UnitSize = 4,
                    TargetTime = 1,
                    ThermalRating = 1,
                    DeploymentCost = 120,
                    Value = 3,
                    Year = "1979"
                    #endregion
                },

            });
            #endregion
            Console.Write("M1 IP Abrams Bulit");
            #region Vehicle M1 Abrams
            tanksList.Add(new GroundVehicleObject
            {
                GroundVehicleType = GroundVehicleType.MBT,
                #region ARMOR
                armorslots = new List<Armor> {
                new Armor() {
                    Position = ArmorPosition.Front, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 15,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                },
                new Armor() {
                    Position = ArmorPosition.Side, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 12, //ggg
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = true
                },new Armor() {
                    Position = ArmorPosition.Rear, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 10,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false,  IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = false
                },new Armor() {
                    Position = ArmorPosition.Top, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 12,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                }},
                #endregion
                GroundVehicleWeaponConfig = new List<WeaponConfig>() {
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank Sabot M1A1"),
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank HEAT M1A1") },
                #region Sensors
                sensors = sensorFactory.GetSensorsByName(new string[] { "Avanced Ballistic Computer", "CBRN Protection", "Intergrated Thermal Sight", "Laser Range Finder", "GPS Navigation" }, this),
                #endregion
                IsInService = true,
                Name = "M1A1 Abrams",
                CreateState = 1,
                IsAlive = false, //spawned in the game or not default off
                ObjectGeneralInfo = new ObjectGeneralInfo()
                {
                    CountryOfOrigin = "US",
                    CountryOfOriginIndex = 1,
                    CrewNumber = 4,
                    EmptyWeight = 60,
                    Height = 3,
                    Length = 10,
                    LoadedWeight = 65,
                    Name = "M1 Abrams IP",
                    OfficerNumber = 1,
                    Powerplant = new Powerplant() { Name = "Gas Turbine", NumberOf = 1, PowerGeneration = 1120, TypeOfPower = Powerplant.PowerPlantType.gasturbine },
                    ProgramName = "XM107",
                    TotalNumberBuilt = 10000
                },
                ObjectHistory = new ObjectHistory(),
                UnitCharacteristics = new UnitCharacteristics()
                {
                    #region Characteristics
                    Cost = 6000000,
                    DetectionRadius = 4000,
                    Ecm = 6,
                    FuelMax = 2000,
                    FuelRange = 60,
                    Generation = 3,
                    HasFCS = true,
                    HasTurret = true,
                    HasStablizer = true,
                    Instability = 0.95f,
                    PilotExp = 1,
                    Rcs = 1,
                    Size = 3,
                    UnitSize = 4,
                    DeploymentCost = 120,
                    TargetTime = 1,
                    ThermalRating = 1,
                    Value = 3,
                    Year = "1979"
                    #endregion
                },

            });
            #endregion
            Console.Write("M1 Abrams Bulit");
            #region Vehicle M1HC Abrams
            tanksList.Add(new GroundVehicleObject
            {
                GroundVehicleType = GroundVehicleType.MBT,
                #region ARMOR
                armorslots = new List<Armor> {
                new Armor() {
                    Position = ArmorPosition.Front, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 15,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                },
                new Armor() {
                    Position = ArmorPosition.Side, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 12, //ggg
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = true
                },new Armor() {
                    Position = ArmorPosition.Rear, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 10,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false,  IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = false
                },new Armor() {
                    Position = ArmorPosition.Top, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 12,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                }},
                #endregion
                GroundVehicleWeaponConfig = new List<WeaponConfig>() {
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank Sabot M1A1"),
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank HEAT M1A1") },
                #region Sensors
                sensors = sensorFactory.GetSensorsByName(new string[] { "Avanced Ballistic Computer", "CBRN Protection", "Intergrated Thermal Sight", "Laser Range Finder", "GPS Navigation" }, this),
                #endregion
                IsInService = true,
                Name = "M1A1 Abrams",
                CreateState = 1,
                IsAlive = false, //spawned in the game or not default off
                ObjectGeneralInfo = new ObjectGeneralInfo()
                {
                    CountryOfOrigin = "US",
                    CountryOfOriginIndex = 1,
                    CrewNumber = 4,
                    EmptyWeight = 60,
                    Height = 3,
                    Length = 10,
                    LoadedWeight = 65,
                    Name = "M1 Abrams IP",
                    OfficerNumber = 1,
                    Powerplant = new Powerplant() { Name = "Gas Turbine", NumberOf = 1, PowerGeneration = 1120, TypeOfPower = Powerplant.PowerPlantType.gasturbine },
                    ProgramName = "XM107",
                    TotalNumberBuilt = 10000
                },
                ObjectHistory = new ObjectHistory(),
                UnitCharacteristics = new UnitCharacteristics()
                {
                    #region Characteristics
                    Cost = 6000000,
                    DetectionRadius = 4000,
                    Ecm = 6,
                    FuelMax = 2000,
                    FuelRange = 60,
                    Generation = 3,
                    HasFCS = true,
                    HasTurret = true,
                    HasStablizer = true,
                    Instability = 0.95f,
                    PilotExp = 1,
                    Rcs = 1,
                    Size = 3,
                    UnitSize = 4,
                    DeploymentCost = 120,
                    TargetTime = 1,
                    ThermalRating = 1,
                    Value = 3,
                    Year = "1979"
                    #endregion
                },

            });
            #endregion

            #region Vehicle M1HA Abrams
            tanksList.Add(new GroundVehicleObject
            {
                GroundVehicleType = GroundVehicleType.MBT,
                #region ARMOR
                armorslots = new List<Armor> {
                new Armor() {
                    Position = ArmorPosition.Front, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 15,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                },
                new Armor() {
                    Position = ArmorPosition.Side, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 12, //ggg
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = true
                },new Armor() {
                    Position = ArmorPosition.Rear, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 10,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false,  IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = false
                },new Armor() {
                    Position = ArmorPosition.Top, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 12,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                }},
                #endregion
                GroundVehicleWeaponConfig = new List<WeaponConfig>() {
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank Sabot M1A1"),
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank HEAT M1A1") },
                #region Sensors
                sensors = sensorFactory.GetSensorsByName(new string[] { "Avanced Ballistic Computer", "CBRN Protection", "Intergrated Thermal Sight", "Laser Range Finder", "GPS Navigation" }, this),
                #endregion
                IsInService = true,
                Name = "M1A1 Abrams",
                CreateState = 1,
                IsAlive = false, //spawned in the game or not default off
                ObjectGeneralInfo = new ObjectGeneralInfo()
                {
                    CountryOfOrigin = "US",
                    CountryOfOriginIndex = 1,
                    CrewNumber = 4,
                    EmptyWeight = 60,
                    Height = 3,
                    Length = 10,
                    LoadedWeight = 65,
                    Name = "M1 Abrams IP",
                    OfficerNumber = 1,
                    Powerplant = new Powerplant() { Name = "Gas Turbine", NumberOf = 1, PowerGeneration = 1120, TypeOfPower = Powerplant.PowerPlantType.gasturbine },
                    ProgramName = "XM107",
                    TotalNumberBuilt = 10000
                },
                ObjectHistory = new ObjectHistory(),
                UnitCharacteristics = new UnitCharacteristics()
                {
                    #region Characteristics
                    Cost = 6000000,
                    DetectionRadius = 4000,
                    Ecm = 6,
                    FuelMax = 2000,
                    FuelRange = 60,
                    Generation = 3,
                    HasFCS = true,
                    HasTurret = true,
                    HasStablizer = true,
                    Instability = 0.95f,
                    PilotExp = 1,
                    Rcs = 1,
                    Size = 3,
                    UnitSize = 4,
                    DeploymentCost = 120,
                    TargetTime = 1,
                    ThermalRating = 1,
                    Value = 3,
                    Year = "1979"
                    #endregion
                },

            });
            #endregion

            #region Vehicle M1A2 Abrams
            tanksList.Add(new GroundVehicleObject
            {
                GroundVehicleType = GroundVehicleType.MBT,
                #region ARMOR
                armorslots = new List<Armor> {
                new Armor() {
                    Position = ArmorPosition.Front, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 15,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                },
                new Armor() {
                    Position = ArmorPosition.Side, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 12, //ggg
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = true
                },new Armor() {
                    Position = ArmorPosition.Rear, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 10,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false,  IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = false
                },new Armor() {
                    Position = ArmorPosition.Top, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 12,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                }},
                #endregion
                GroundVehicleWeaponConfig = new List<WeaponConfig>() {
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank Sabot M1A2"),
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank HEAT M1A2") },
                #region Sensors
                sensors = sensorFactory.GetSensorsByName(new string[] { "Avanced Ballistic Computer", "CBRN Protection", "Intergrated Thermal Sight", "Laser Range Finder", "GPS Navigation", "Commander Thermal Viewer" }, this),
                #endregion
                IsInService = true,
                Name = "M1A2 Abrams",
                CreateState = 1,
                IsAlive = false, //spawned in the game or not default off
                ObjectGeneralInfo = new ObjectGeneralInfo()
                {
                    CountryOfOrigin = "US",
                    CountryOfOriginIndex = 1,
                    CrewNumber = 4,
                    EmptyWeight = 60,
                    Height = 3,
                    Length = 10,
                    LoadedWeight = 65,
                    Name = "M1A2 Abrams",
                    OfficerNumber = 1,
                    Powerplant = new Powerplant() { Name = "Gas Turbine", NumberOf = 1, PowerGeneration = 1120, TypeOfPower = Powerplant.PowerPlantType.gasturbine },
                    ProgramName = "XM107",
                    TotalNumberBuilt = 10000
                },
                ObjectHistory = new ObjectHistory(),
                UnitCharacteristics = new UnitCharacteristics()
                {
                    #region Characteristics
                    Cost = 6000000,
                    DetectionRadius = 4000,
                    Ecm = 6,
                    FuelMax = 2000,
                    FuelRange = 60,
                    Generation = 3,
                    HasFCS = true,
                    HasTurret = true,
                    HasStablizer = true,
                    Instability = 0.95f,
                    PilotExp = 1,
                    Rcs = 1,
                    Size = 3,
                    UnitSize = 4,
                    TargetTime = 1,
                    ThermalRating = 1,
                    DeploymentCost = 120,
                    Value = 3,
                    Year = "1979"
                    #endregion
                },

            });
            #endregion

            #region Vehicle M1A2 TUSK Abrams
            tanksList.Add(new GroundVehicleObject
            {
                GroundVehicleType = GroundVehicleType.MBT,
                #region ARMOR
                armorslots = new List<Armor> {
                new Armor() {
                    Position = ArmorPosition.Front, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 15,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                },
                new Armor() {
                    Position = ArmorPosition.Side, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 12, //ggg
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = true
                },new Armor() {
                    Position = ArmorPosition.Rear, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 10,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false,  IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = false
                },new Armor() {
                    Position = ArmorPosition.Top, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 12,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                }},
                #endregion
                GroundVehicleWeaponConfig = new List<WeaponConfig>() {
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank Sabot M1A2"),
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank HEAT M1A2") },
                #region Sensors
                sensors = sensorFactory.GetSensorsByName(new string[] { "Avanced Ballistic Computer", "CBRN Protection", "Intergrated Thermal Sight", "Laser Range Finder", "GPS Navigation", "Commander Thermal Viewer" }, this),
                #endregion
                IsInService = true,
                Name = "M1A2 TUSK Abrams",
                CreateState = 1,
                IsAlive = false, //spawned in the game or not default off
                ObjectGeneralInfo = new ObjectGeneralInfo()
                {
                    CountryOfOrigin = "US",
                    CountryOfOriginIndex = 1,
                    CrewNumber = 4,
                    EmptyWeight = 60,
                    Height = 3,
                    Length = 10,
                    LoadedWeight = 65,
                    Name = "M1A2 TUSK Abrams",
                    OfficerNumber = 1,
                    Powerplant = new Powerplant() { Name = "Gas Turbine", NumberOf = 1, PowerGeneration = 1120, TypeOfPower = Powerplant.PowerPlantType.gasturbine },
                    ProgramName = "XM107",
                    TotalNumberBuilt = 10000
                },
                ObjectHistory = new ObjectHistory(),
                UnitCharacteristics = new UnitCharacteristics()
                {
                    #region Characteristics
                    Cost = 6000000,
                    DetectionRadius = 4000,
                    Ecm = 6,
                    FuelMax = 2000,
                    FuelRange = 60,
                    Generation = 3,
                    HasFCS = true,
                    HasTurret = true,
                    HasStablizer = true,
                    Instability = 0.95f,
                    PilotExp = 1,
                    Rcs = 1,
                    Size = 3,
                    UnitSize = 4,
                    TargetTime = 1,
                    ThermalRating = 1,
                    DeploymentCost = 120,
                    Value = 3,
                    Year = "1979"
                    #endregion
                },

            });
            #endregion

            #region Vehicle M1A2 SEP Abrams
            tanksList.Add(new GroundVehicleObject
            {
                GroundVehicleType = GroundVehicleType.MBT,
                #region ARMOR
                armorslots = new List<Armor> {
                new Armor() {
                    Position = ArmorPosition.Front, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 15,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                },
                new Armor() {
                    Position = ArmorPosition.Side, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 12, //ggg
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = true
                },new Armor() {
                    Position = ArmorPosition.Rear, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 10,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false,  IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = false
                },new Armor() {
                    Position = ArmorPosition.Top, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 12,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                }},
                #endregion
                GroundVehicleWeaponConfig = new List<WeaponConfig>() {
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank Sabot M1A2"),
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank HEAT M1A2") },
                #region Sensors
                sensors = sensorFactory.GetSensorsByName(new string[] { "Avanced Ballistic Computer", "CBRN Protection", "Intergrated Thermal Sight", "Laser Range Finder", "GPS Navigation", "Commander Thermal Viewer" }, this),
                #endregion
                IsInService = true,
                Name = "M1A2 Abrams",
                CreateState = 1,
                IsAlive = false, //spawned in the game or not default off
                ObjectGeneralInfo = new ObjectGeneralInfo()
                {
                    CountryOfOrigin = "US",
                    CountryOfOriginIndex = 1,
                    CrewNumber = 4,
                    EmptyWeight = 60,
                    Height = 3,
                    Length = 10,
                    LoadedWeight = 65,
                    Name = "M1A2 Abrams",
                    OfficerNumber = 1,
                    Powerplant = new Powerplant() { Name = "Gas Turbine", NumberOf = 1, PowerGeneration = 1120, TypeOfPower = Powerplant.PowerPlantType.gasturbine },
                    ProgramName = "XM107",
                    TotalNumberBuilt = 10000
                },
                ObjectHistory = new ObjectHistory(),
                UnitCharacteristics = new UnitCharacteristics()
                {
                    #region Characteristics
                    Cost = 6000000,
                    DetectionRadius = 4000,
                    Ecm = 6,
                    FuelMax = 2000,
                    FuelRange = 60,
                    Generation = 3,
                    HasFCS = true,
                    HasTurret = true,
                    HasStablizer = true,
                    Instability = 0.95f,
                    PilotExp = 1,
                    Rcs = 1,
                    Size = 3,
                    UnitSize = 4,
                    TargetTime = 1,
                    ThermalRating = 1,
                    DeploymentCost = 120,
                    Value = 3,
                    Year = "1979"
                    #endregion
                },

            });
            #endregion

            #region Vehicle M1A3 Abrams
            tanksList.Add(new GroundVehicleObject
            {
                GroundVehicleType = GroundVehicleType.MBT,
                #region ARMOR
                armorslots = new List<Armor> {
                new Armor() {
                    Position = ArmorPosition.Front, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 15,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                },
                new Armor() {
                    Position = ArmorPosition.Side, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 12, //ggg
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = true
                },new Armor() {
                    Position = ArmorPosition.Rear, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 10,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false,  IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = false
                },new Armor() {
                    Position = ArmorPosition.Top, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 12,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                }},
                #endregion
                GroundVehicleWeaponConfig = new List<WeaponConfig>() {
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank Sabot M1A2"),
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank HEAT M1A2") },
                #region Sensors
                sensors = sensorFactory.GetSensorsByName(new string[] { "Avanced Ballistic Computer", "CBRN Protection", "Intergrated Thermal Sight", "Laser Range Finder", "GPS Navigation", "Commander Thermal Viewer" }, this),
                #endregion
                IsInService = true,
                Name = "M1A3 Abrams",
                CreateState = 1,
                IsAlive = false, //spawned in the game or not default off
                ObjectGeneralInfo = new ObjectGeneralInfo()
                {
                    CountryOfOrigin = "US",
                    CountryOfOriginIndex = 1,
                    CrewNumber = 4,
                    EmptyWeight = 60,
                    Height = 3,
                    Length = 10,
                    LoadedWeight = 65,
                    Name = "M1A3 Abrams",
                    OfficerNumber = 1,
                    Powerplant = new Powerplant() { Name = "Gas Turbine", NumberOf = 1, PowerGeneration = 1120, TypeOfPower = Powerplant.PowerPlantType.gasturbine },
                    ProgramName = "XM107",
                    TotalNumberBuilt = 10000
                },
                ObjectHistory = new ObjectHistory(),
                UnitCharacteristics = new UnitCharacteristics()
                {
                    #region Characteristics
                    Cost = 6000000,
                    DetectionRadius = 4000,
                    Ecm = 6,
                    FuelMax = 2000,
                    FuelRange = 60,
                    Generation = 3,
                    HasFCS = true,
                    HasTurret = true,
                    HasStablizer = true,
                    Instability = 0.95f,
                    PilotExp = 1,
                    Rcs = 1,
                    Size = 3,
                    UnitSize = 4,
                    TargetTime = 1,
                    ThermalRating = 1,
                    DeploymentCost = 120,
                    Value = 3,
                    Year = "1979"
                    #endregion
                },

            });
            #endregion

            #region Vehicle M1 TTB Abrams
            tanksList.Add(new GroundVehicleObject
            {
                GroundVehicleType = GroundVehicleType.MBT,
                #region ARMOR
                armorslots = new List<Armor> {
                new Armor() {
                    Position = ArmorPosition.Front, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 15,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                },
                new Armor() {
                    Position = ArmorPosition.Side, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 12, //ggg
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = true
                },new Armor() {
                    Position = ArmorPosition.Rear, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 10,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false,  IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = false
                },new Armor() {
                    Position = ArmorPosition.Top, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 12,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                }},
                #endregion
                GroundVehicleWeaponConfig = new List<WeaponConfig>() {
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank Sabot M1A2"),
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank HEAT M1A2") },
                #region Sensors
                sensors = sensorFactory.GetSensorsByName(new string[] { "Avanced Ballistic Computer", "CBRN Protection", "Intergrated Thermal Sight", "Laser Range Finder", "GPS Navigation", "Commander Thermal Viewer" }, this),
                #endregion
                IsInService = true,
                Name = "M1 TTB Abrams",
                CreateState = 1,
                IsAlive = false, //spawned in the game or not default off
                ObjectGeneralInfo = new ObjectGeneralInfo()
                {
                    CountryOfOrigin = "US",
                    CountryOfOriginIndex = 1,
                    CrewNumber = 4,
                    EmptyWeight = 60,
                    Height = 3,
                    Length = 10,
                    LoadedWeight = 65,
                    Name = "M1 TTB Abrams",
                    OfficerNumber = 1,
                    Powerplant = new Powerplant() { Name = "Gas Turbine", NumberOf = 1, PowerGeneration = 1120, TypeOfPower = Powerplant.PowerPlantType.gasturbine },
                    ProgramName = "XM107",
                    TotalNumberBuilt = 10000
                },
                ObjectHistory = new ObjectHistory(),
                UnitCharacteristics = new UnitCharacteristics()
                {
                    #region Characteristics
                    Cost = 6000000,
                    DetectionRadius = 4000,
                    Ecm = 6,
                    FuelMax = 2000,
                    FuelRange = 60,
                    Generation = 3,
                    HasFCS = true,
                    HasTurret = true,
                    HasStablizer = true,
                    Instability = 0.95f,
                    PilotExp = 1,
                    Rcs = 1,
                    Size = 3,
                    UnitSize = 4,
                    TargetTime = 1,
                    ThermalRating = 1,
                    DeploymentCost = 120,
                    Value = 3,
                    Year = "1979"
                    #endregion
                },

            });
            #endregion

            //TODO Add Model balance weapons skin animated low poly and a
            // v1
            #region Vehicle M60A1 Patton
            tanksList.Add(new GroundVehicleObject
            {
                GroundVehicleType = GroundVehicleType.MBT,
                #region ARMOR
                armorslots = new List<Armor> {
                new Armor() {
                    Position = ArmorPosition.Front, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 15,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                },
                new Armor() {
                    Position = ArmorPosition.Side, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 12, //ggg
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = true
                },new Armor() {
                    Position = ArmorPosition.Rear, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 10,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false,  IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = false
                },new Armor() {
                    Position = ArmorPosition.Top, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 12,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                }},
                #endregion
                GroundVehicleWeaponConfig = new List<WeaponConfig>() {
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank Sabot Patton"),
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank HEAT Patton") },
                #region Sensors
                sensors = sensorFactory.GetSensorsByName(new string[] { "Ballistic Computer", "CBRN Protection", }, this),
                #endregion
                IsInService = true,
                Name = "M60A1 Patton",
                CreateState = 1,
                IsAlive = false, //spawned in the game or not default off
                ObjectGeneralInfo = new ObjectGeneralInfo()
                {
                    CountryOfOrigin = "US",
                    CountryOfOriginIndex = 1,
                    CrewNumber = 4,
                    EmptyWeight = 47,
                    Height = 3,
                    Length = 7,
                    LoadedWeight = 49,
                    Name = "M60A1 Patton",
                    OfficerNumber = 1,
                    Powerplant = new Powerplant() { Name = "Continental AVDS-1790-2 V12, air-cooled Twin-turbo diesel engine", NumberOf = 1, PowerGeneration = 560, TypeOfPower = Powerplant.PowerPlantType.diesel },
                    ProgramName = "M48",
                    TotalNumberBuilt = 15000
                },
                ObjectHistory = new ObjectHistory(),
                UnitCharacteristics = new UnitCharacteristics()
                {
                    #region Characteristics
                    Cost = 1700000,
                    DetectionRadius = 2000,
                    Ecm = 6,
                    FuelMax = 1457,
                    FuelRange = 500,
                    Generation = 3,
                    HasFCS = true,
                    HasTurret = true,
                    HasStablizer = false,
                    Instability = 0.95f,
                    PilotExp = 1,
                    Rcs = 1,
                    Size = 3,
                    UnitSize = 4,
                    TargetTime = 3,
                    ThermalRating = 1,
                    DeploymentCost = 60,
                    Value = 3,
                    Year = "1960"
                    #endregion
                },

            });
            #endregion

            #region Vehicle M60A3 Patton
            tanksList.Add(new GroundVehicleObject
            {
                GroundVehicleType = GroundVehicleType.MBT,
                #region ARMOR
                armorslots = new List<Armor> {
                new Armor() {
                    Position = ArmorPosition.Front, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 16,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                },
                new Armor() {
                    Position = ArmorPosition.Side, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 15, //ggg
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = true
                },new Armor() {
                    Position = ArmorPosition.Rear, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 12,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false,  IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = false
                },new Armor() {
                    Position = ArmorPosition.Top, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 13,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                }},
                #endregion
                GroundVehicleWeaponConfig = new List<WeaponConfig>() {
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank Sabot Patton"),
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank HEAT Patton") },
                #region Sensors
                sensors = sensorFactory.GetSensorsByName(new string[] { "Ballistic Computer", "CBRN Protection", "IR Search Light", "Laser Range Finder" }, this),
                #endregion
                IsInService = true,
                Name = "M60A3 Patton",
                CreateState = 1,
                IsAlive = false, //spawned in the game or not default off
                ObjectGeneralInfo = new ObjectGeneralInfo()
                {
                    CountryOfOrigin = "US",
                    CountryOfOriginIndex = 1,
                    CrewNumber = 4,
                    EmptyWeight = 47,
                    Height = 3,
                    Length = 7,
                    LoadedWeight = 49,
                    Name = "M60A3 Patton",
                    OfficerNumber = 1,
                    Powerplant = new Powerplant() { Name = "Continental AVDS-1790-2 V12, air-cooled Twin-turbo diesel engine", NumberOf = 1, PowerGeneration = 750, TypeOfPower = Powerplant.PowerPlantType.diesel },
                    ProgramName = "M48",
                    TotalNumberBuilt = 15000
                },
                ObjectHistory = new ObjectHistory(),
                UnitCharacteristics = new UnitCharacteristics()
                {
                    #region Characteristics
                    Cost = 1700000,
                    DetectionRadius = 2000,
                    Ecm = 2,
                    FuelMax = 1457,
                    FuelRange = 500,
                    Generation = 3,
                    HasFCS = false,
                    HasTurret = true,
                    HasStablizer = true,
                    Instability = 0.95f,
                    PilotExp = 1,
                    Rcs = 1,
                    Size = 3,
                    UnitSize = 4,
                    TargetTime = 2,
                    ThermalRating = 1,
                    DeploymentCost = 70,
                    Value = 3,
                    Year = "1996"
                    #endregion
                },
            });

            #endregion

            #region Vehicle M60A3 SLEP Patton
            tanksList.Add(new GroundVehicleObject
            {
                GroundVehicleType = GroundVehicleType.MBT,
                #region ARMOR
                armorslots = new List<Armor> {
                new Armor() {
                    Position = ArmorPosition.Front, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 20,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = true, IsElectricCharged = false, IsReactive = true, IsSlat = true, IsSloped = true, IsSpaced = true
                },
                new Armor() {
                    Position = ArmorPosition.Side, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 20, //ggg
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = true, IsElectricCharged = false, IsReactive = true, IsSlat = true, IsSloped = false, IsSpaced = true
                },new Armor() {
                    Position = ArmorPosition.Rear, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 18,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = true, IsElectricCharged = false,  IsReactive = true, IsSlat = true, IsSloped = false, IsSpaced = true
                },new Armor() {
                    Position = ArmorPosition.Top, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 20,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = true, IsElectricCharged = false, IsReactive = true, IsSlat = true, IsSloped = true, IsSpaced = true
                }},
                #endregion
                GroundVehicleWeaponConfig = new List<WeaponConfig>() {
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank Sabot Patton 2"),
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank HEAT Patton 2") },
                #region Sensors
                sensors = sensorFactory.GetSensorsByName(new string[] { "Advanced Ballistic Computer", "CBRN Protection", "Intergrated Thermal Sight Gen IV", "Laser Range Finder Gen IV" }, this),
                #endregion
                IsInService = true,
                Name = "M60A3 SLEP Patton",
                CreateState = 1,
                IsAlive = false, //spawned in the game or not default off
                ObjectGeneralInfo = new ObjectGeneralInfo()
                {
                    CountryOfOrigin = "US",
                    CountryOfOriginIndex = 1,
                    CrewNumber = 4,
                    EmptyWeight = 47,
                    Height = 3,
                    Length = 7,
                    LoadedWeight = 49,
                    Name = "M60A3 SLEP Patton",
                    OfficerNumber = 1,
                    Powerplant = new Powerplant() { Name = "Continental AVDS-1790-2 V12, air-cooled Twin-turbo diesel engine", NumberOf = 1, PowerGeneration = 950, TypeOfPower = Powerplant.PowerPlantType.diesel },
                    ProgramName = "M60A3",
                    TotalNumberBuilt = 15000
                },
                ObjectHistory = new ObjectHistory(),
                UnitCharacteristics = new UnitCharacteristics()
                {
                    #region Characteristics
                    Cost = 1700000,
                    DetectionRadius = 2000,
                    Ecm = 2,
                    FuelMax = 1457,
                    FuelRange = 500,
                    Generation = 3,
                    HasFCS = true,
                    HasTurret = true,
                    HasStablizer = true,
                    Instability = 0.95f,
                    PilotExp = 1,
                    Rcs = 1,
                    Size = 3,
                    UnitSize = 4,
                    TargetTime = 1,
                    ThermalRating = 1,
                    DeploymentCost = 70,
                    Value = 3,
                    Year = "2000"
                    #endregion
                },
            });
            #endregion

            #region Vehicle M60A3 Sabra
            tanksList.Add(new GroundVehicleObject
            {
                GroundVehicleType = GroundVehicleType.MBT,
                #region ARMOR
                armorslots = new List<Armor> {
                new Armor() {
                    Position = ArmorPosition.Front, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 22,
                    ArmorType = ArmorType.Ceramic,
                    RHARating = SetRHARating(ArmorType.Ceramic),
                    IsBoltOn = true, IsElectricCharged = false, IsReactive = true, IsSlat = true, IsSloped = true, IsSpaced = true
                },
                new Armor() {
                    Position = ArmorPosition.Side, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 21, //ggg
                    ArmorType = ArmorType.Ceramic,
                    RHARating = SetRHARating(ArmorType.Ceramic),
                    IsBoltOn = true, IsElectricCharged = false, IsReactive = true, IsSlat = true, IsSloped = false, IsSpaced = true
                },new Armor() {
                    Position = ArmorPosition.Rear, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 20,
                    ArmorType = ArmorType.Ceramic,
                    RHARating = SetRHARating(ArmorType.Ceramic),
                    IsBoltOn = true, IsElectricCharged = false,  IsReactive = true, IsSlat = true, IsSloped = false, IsSpaced = true
                },new Armor() {
                    Position = ArmorPosition.Top, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 22,
                    ArmorType = ArmorType.Ceramic,
                    RHARating = SetRHARating(ArmorType.Ceramic),
                    IsBoltOn = true, IsElectricCharged = false, IsReactive = true, IsSlat = true, IsSloped = true, IsSpaced = true
                }},
                #endregion
                GroundVehicleWeaponConfig = new List<WeaponConfig>() {
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank Sabot Sabra"),
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank HEAT Sabra") },
                #region Sensors
                sensors = sensorFactory.GetSensorsByName(new string[] { "Avanced Ballistic Computer", "CBRN Protection", "Intergrated Thermal Sight", "GPS Navigation" }, this),
                #endregion
                IsInService = true,
                Name = "M60T Sabra",
                CreateState = 1,
                IsAlive = false, //spawned in the game or not default off
                ObjectGeneralInfo = new ObjectGeneralInfo()
                {
                    CountryOfOrigin = "IL",
                    CountryOfOriginIndex = 1,
                    CrewNumber = 4,
                    EmptyWeight = 60,
                    Height = 3,
                    Length = 10,
                    LoadedWeight = 65,
                    Name = "M60T Sabra",
                    OfficerNumber = 1,
                    Powerplant = new Powerplant() { Name = "Continental AVDS-1790-5A V12, air-cooled Twin-turbo diesel engine", NumberOf = 1, PowerGeneration = 1000, TypeOfPower = Powerplant.PowerPlantType.diesel },
                    ProgramName = "M60",
                    TotalNumberBuilt = 96
                },
                ObjectHistory = new ObjectHistory(),
                UnitCharacteristics = new UnitCharacteristics()
                {
                    #region Characteristics
                    Cost = 1700000,
                    DetectionRadius = 4000,
                    Ecm = 1,
                    FuelMax = 2200,
                    FuelRange = 650,
                    Generation = 4,
                    HasFCS = true,
                    HasTurret = true,
                    HasStablizer = true,
                    Instability = 1,
                    PilotExp = 1,
                    Rcs = 0.85f,
                    Size = 3,
                    UnitSize = 4,
                    TargetTime = 1,
                    ThermalRating = 0.75f,
                    DeploymentCost = 95,
                    Value = 3,
                    Year = "2000"
                    #endregion
                },

            });
            #endregion

            #region Vehicle M551 Sheridan 
            tanksList.Add(new GroundVehicleObject
            {
                GroundVehicleType = GroundVehicleType.lighttank,
                #region ARMOR
                armorslots = new List<Armor> {
                new Armor() {
                    Position = ArmorPosition.Front, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = false,
                    ArmorRating = 5,
                    ArmorType = ArmorType.Alunminium,
                    RHARating = SetRHARating(ArmorType.Alunminium),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = false
                },
                new Armor() {
                    Position = ArmorPosition.Side, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = false,
                    ArmorRating = 2,
                    ArmorType = ArmorType.Alunminium,
                    RHARating = SetRHARating(ArmorType.Alunminium),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = false
                },new Armor() {
                    Position = ArmorPosition.Rear, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = false,
                    ArmorRating = 2,
                    ArmorType = ArmorType.Alunminium,
                    RHARating = SetRHARating(ArmorType.Alunminium),
                    IsBoltOn = false, IsElectricCharged = false,  IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = false
                },new Armor() {
                    Position = ArmorPosition.Top, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = false,
                    ArmorRating = 2,
                    ArmorType = ArmorType.Alunminium,
                    RHARating = SetRHARating(ArmorType.Alunminium),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                }},
                #endregion
                GroundVehicleWeaponConfig = new List<WeaponConfig>() {
                    weaponConfigFactory.ReturnWeaponConfigBy("M551 Sheridan") },
                #region Sensors
                sensors = sensorFactory.GetSensorsByName(new string[] { "CBRN Protection" }, this),
                #endregion
                IsInService = true,
                Name = "M551 Sheridan",
                CreateState = 1,
                IsAlive = false, //spawned in the game or not default off
                ObjectGeneralInfo = new ObjectGeneralInfo()
                {
                    CountryOfOrigin = "US",
                    CountryOfOriginIndex = 1,
                    CrewNumber = 4,
                    EmptyWeight = 15,
                    Height = 3,
                    Length = 6,
                    LoadedWeight = 17,
                    Name = "M551 Sherdian",
                    OfficerNumber = 1,
                    Powerplant = new Powerplant() { Name = "Detroit Diesel 6V53T", NumberOf = 1, PowerGeneration = 224, TypeOfPower = Powerplant.PowerPlantType.diesel },
                    ProgramName = "XM551",
                    TotalNumberBuilt = 1662
                },
                ObjectHistory = new ObjectHistory(),
                UnitCharacteristics = new UnitCharacteristics()
                {
                    #region Characteristics
                    Cost = 780000,
                    DetectionRadius = 1500,
                    Ecm = 1,
                    FuelMax = 500,
                    FuelRange = 560,
                    Generation = 3,
                    HasFCS = false,
                    HasTurret = true,
                    HasStablizer = true,
                    Instability = 0.85f,
                    PilotExp = 0,
                    Rcs = 1,
                    Size = 2,
                    UnitSize = 4,
                    TargetTime = 3,
                    ThermalRating = 1,
                    DeploymentCost = 55,
                    Value = 2,
                    Year = "1966"
                    #endregion
                },

            });
            #endregion

            #region Vehicle M551A1 Sherdian
            tanksList.Add(new GroundVehicleObject
            {
                GroundVehicleType = GroundVehicleType.lighttank,
                #region ARMOR
                armorslots = new List<Armor> {
                new Armor() {
                    Position = ArmorPosition.Front, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = false,
                    ArmorRating = 6,
                    ArmorType = ArmorType.Alunminium,
                    RHARating = SetRHARating(ArmorType.Alunminium),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = false
                },
                new Armor() {
                    Position = ArmorPosition.Side, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = false,
                    ArmorRating = 4,
                    ArmorType = ArmorType.Alunminium,
                    RHARating = SetRHARating(ArmorType.Alunminium),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = false
                },new Armor() {
                    Position = ArmorPosition.Rear, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = false,
                    ArmorRating = 3,
                    ArmorType = ArmorType.Alunminium,
                    RHARating = SetRHARating(ArmorType.Alunminium),
                    IsBoltOn = false, IsElectricCharged = false,  IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = false
                },new Armor() {
                    Position = ArmorPosition.Top, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = false,
                    ArmorRating = 4,
                    ArmorType = ArmorType.Alunminium,
                    RHARating = SetRHARating(ArmorType.Alunminium),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                }},
                #endregion
                GroundVehicleWeaponConfig = new List<WeaponConfig>() {
                    weaponConfigFactory.ReturnWeaponConfigBy("M551 Sheridan") },
                #region Sensors
                sensors = sensorFactory.GetSensorsByName(new string[] { "Avanced Ballistic Computer", "CBRN Protection", "Intergrated Thermal Sight" }, this),
                #endregion
                IsInService = true,
                Name = "M551A1 Sheridan",
                CreateState = 1,
                IsAlive = false, //spawned in the game or not default off
                ObjectGeneralInfo = new ObjectGeneralInfo()
                {
                    CountryOfOrigin = "US",
                    CountryOfOriginIndex = 1,
                    CrewNumber = 4,
                    EmptyWeight = 15,
                    Height = 3,
                    Length = 6,
                    LoadedWeight = 17,
                    Name = "M551A1 Sherdian",
                    OfficerNumber = 1,
                    Powerplant = new Powerplant() { Name = "Detroit Diesel 6V53T", NumberOf = 1, PowerGeneration = 224, TypeOfPower = Powerplant.PowerPlantType.diesel },
                    ProgramName = "XM551",
                    TotalNumberBuilt = 1662
                },
                ObjectHistory = new ObjectHistory(),
                UnitCharacteristics = new UnitCharacteristics()
                {
                    #region Characteristics
                    Cost = 780000,
                    DetectionRadius = 1500,
                    Ecm = 1,
                    FuelMax = 500,
                    FuelRange = 560,
                    Generation = 3,
                    HasFCS = false,
                    HasTurret = true,
                    HasStablizer = true,
                    Instability = 0.85f,
                    PilotExp = 0,
                    Rcs = 1,
                    Size = 2,
                    UnitSize = 4,
                    TargetTime = 2,
                    ThermalRating = 1,
                    DeploymentCost = 55,
                    Value = 2,
                    Year = "1986"
                    #endregion
                },

            });
            #endregion

            #region Vehicle M48A1 Patton
            tanksList.Add(new GroundVehicleObject
            {
                GroundVehicleType = GroundVehicleType.MBT,
                #region ARMOR
                armorslots = new List<Armor> {
                new Armor() {
                    Position = ArmorPosition.Front, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 16,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                },
                new Armor() {
                    Position = ArmorPosition.Side, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 15, //ggg
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = true
                },new Armor() {
                    Position = ArmorPosition.Rear, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 12,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false,  IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = false
                },new Armor() {
                    Position = ArmorPosition.Top, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 13,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                }},
                #endregion
                GroundVehicleWeaponConfig = new List<WeaponConfig>() {
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank Sabot Patton"),
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank HEAT Patton") },
                #region Sensors
                sensors = sensorFactory.GetSensorsByName(new string[] { "Ballistic Computer", "CBRN Protection", "IR Search Light", "Laser Range Finder" }, this),
                #endregion
                IsInService = true,
                Name = "M48A1 Patton",
                CreateState = 1,
                IsAlive = false, //spawned in the game or not default off
                ObjectGeneralInfo = new ObjectGeneralInfo()
                {
                    CountryOfOrigin = "US",
                    CountryOfOriginIndex = 1,
                    CrewNumber = 4,
                    EmptyWeight = 47,
                    Height = 3,
                    Length = 7,
                    LoadedWeight = 49,
                    Name = "M48A1 Patton",
                    OfficerNumber = 1,
                    Powerplant = new Powerplant() { Name = "Continental AVDS-1790-2 V12, air-cooled Twin-turbo diesel engine", NumberOf = 1, PowerGeneration = 750, TypeOfPower = Powerplant.PowerPlantType.diesel },
                    ProgramName = "M41",
                    TotalNumberBuilt = 15000
                },
                ObjectHistory = new ObjectHistory(),
                UnitCharacteristics = new UnitCharacteristics()
                {
                    #region Characteristics
                    Cost = 1700000,
                    DetectionRadius = 2000,
                    Ecm = 2,
                    FuelMax = 1457,
                    FuelRange = 500,
                    Generation = 3,
                    HasFCS = false,
                    HasTurret = true,
                    HasStablizer = true,
                    Instability = 0.95f,
                    PilotExp = 1,
                    Rcs = 1,
                    Size = 3,
                    UnitSize = 4,
                    TargetTime = 2,
                    ThermalRating = 1,
                    DeploymentCost = 70,
                    Value = 3,
                    Year = "1996"
                    #endregion
                },
            });

            #endregion

            #region Vehicle M48A3 Patton
            tanksList.Add(new GroundVehicleObject
            {
                GroundVehicleType = GroundVehicleType.MBT,
                #region ARMOR
                armorslots = new List<Armor> {
                new Armor() {
                    Position = ArmorPosition.Front, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 16,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                },
                new Armor() {
                    Position = ArmorPosition.Side, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 15, //ggg
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = true
                },new Armor() {
                    Position = ArmorPosition.Rear, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 12,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false,  IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = false
                },new Armor() {
                    Position = ArmorPosition.Top, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 13,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                }},
                #endregion
                GroundVehicleWeaponConfig = new List<WeaponConfig>() {
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank Sabot Patton"),
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank HEAT Patton") },
                #region Sensors
                sensors = sensorFactory.GetSensorsByName(new string[] { "Ballistic Computer", "CBRN Protection", "IR Search Light", "Laser Range Finder" }, this),
                #endregion
                IsInService = true,
                Name = "M48A3 Patton",
                CreateState = 1,
                IsAlive = false, //spawned in the game or not default off
                ObjectGeneralInfo = new ObjectGeneralInfo()
                {
                    CountryOfOrigin = "US",
                    CountryOfOriginIndex = 1,
                    CrewNumber = 4,
                    EmptyWeight = 47,
                    Height = 3,
                    Length = 7,
                    LoadedWeight = 49,
                    Name = "M48A3 Patton",
                    OfficerNumber = 1,
                    Powerplant = new Powerplant() { Name = "Continental AVDS-1790-2 V12, air-cooled Twin-turbo diesel engine", NumberOf = 1, PowerGeneration = 750, TypeOfPower = Powerplant.PowerPlantType.diesel },
                    ProgramName = "M48",
                    TotalNumberBuilt = 15000
                },
                ObjectHistory = new ObjectHistory(),
                UnitCharacteristics = new UnitCharacteristics()
                {
                    #region Characteristics
                    Cost = 1700000,
                    DetectionRadius = 2000,
                    Ecm = 2,
                    FuelMax = 1457,
                    FuelRange = 500,
                    Generation = 3,
                    HasFCS = false,
                    HasTurret = true,
                    HasStablizer = true,
                    Instability = 0.95f,
                    PilotExp = 1,
                    Rcs = 1,
                    Size = 3,
                    UnitSize = 4,
                    TargetTime = 2,
                    ThermalRating = 1,
                    DeploymentCost = 70,
                    Value = 3,
                    Year = "1996"
                    #endregion
                },
            });

            #endregion

            #region Vehicle M48A5 Patton
            tanksList.Add(new GroundVehicleObject
            {
                GroundVehicleType = GroundVehicleType.MBT,
                #region ARMOR
                armorslots = new List<Armor> {
                new Armor() {
                    Position = ArmorPosition.Front, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 16,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                },
                new Armor() {
                    Position = ArmorPosition.Side, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 15, //ggg
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = true
                },new Armor() {
                    Position = ArmorPosition.Rear, APSAmmo = 0, APSRate = 0,  HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 12,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false,  IsReactive = false, IsSlat = false, IsSloped = false, IsSpaced = false
                },new Armor() {
                    Position = ArmorPosition.Top, APSAmmo = 0, APSRate = 0, HasAPS = false, HasSpallLiner = true,
                    ArmorRating = 13,
                    ArmorType = ArmorType.Steel,
                    RHARating = SetRHARating(ArmorType.Steel),
                    IsBoltOn = false, IsElectricCharged = false, IsReactive = false, IsSlat = false, IsSloped = true, IsSpaced = true
                }},
                #endregion
                GroundVehicleWeaponConfig = new List<WeaponConfig>() {
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank Sabot Patton"),
                    weaponConfigFactory.ReturnWeaponConfigBy("Anti-tank HEAT Patton") },
                #region Sensors
                sensors = sensorFactory.GetSensorsByName(new string[] { "Ballistic Computer", "CBRN Protection", "IR Search Light", "Laser Range Finder" }, this),
                #endregion
                IsInService = true,
                Name = "M48A5 Patton",
                CreateState = 1,
                IsAlive = false, //spawned in the game or not default off
                ObjectGeneralInfo = new ObjectGeneralInfo()
                {
                    CountryOfOrigin = "US",
                    CountryOfOriginIndex = 1,
                    CrewNumber = 4,
                    EmptyWeight = 47,
                    Height = 3,
                    Length = 7,
                    LoadedWeight = 49,
                    Name = "M48A5 Patton",
                    OfficerNumber = 1,
                    Powerplant = new Powerplant() { Name = "Continental AVDS-1790-2 V12, air-cooled Twin-turbo diesel engine", NumberOf = 1, PowerGeneration = 750, TypeOfPower = Powerplant.PowerPlantType.diesel },
                    ProgramName = "M48",
                    TotalNumberBuilt = 2069
                },
                ObjectHistory = new ObjectHistory(),
                UnitCharacteristics = new UnitCharacteristics()
                {
                    #region Characteristics
                    Cost = 1700000,
                    DetectionRadius = 2000,
                    Ecm = 2,
                    FuelMax = 1457,
                    FuelRange = 500,
                    Generation = 3,
                    HasFCS = false,
                    HasTurret = true,
                    HasStablizer = true,
                    Instability = 0.95f,
                    PilotExp = 1,
                    Rcs = 1,
                    Size = 3,
                    UnitSize = 4,
                    TargetTime = 2,
                    ThermalRating = 1,
                    DeploymentCost = 70,
                    Value = 3,
                    Year = "1996"
                    #endregion
                },
            });

            #endregion



            return tanksList;
        }
    }
}
