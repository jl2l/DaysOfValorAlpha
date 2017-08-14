using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Assets
{
    public class ForcesWeaponsFactory
    {
        public static WarheadType ReturnWarheadType(WarheadType type)
        {
            return type;
        }
        public static WeaponPerks ReturnWeaponPerksType(WeaponPerks type)
        {
            return type;
        }

        public GroundVehicleWeapon GetGroundWeaponBy(string Name)
        {
            return GetListWeapons().FirstOrDefault(e => e.WeaponName == Name);
        }
        public SeaObjectWeapon GetSeaWeaponBy(string Name)
        {
            return GetSeaWeaponList().FirstOrDefault(e => e.WeaponName == Name);
        }

        public List<SeaObjectWeapon> GetSeaWeaponList()
        {
            return new List<SeaObjectWeapon>() {
                //AK-130 130 mm Gun
                //AK-100 100 mm Gun
                //AK–176 76.2 mm Gun
                //AK-230 twin 30mm Gun
                //AK-630 Gun
                //Ak-725 57 mm Gun
                //UK
                //Sting Ray
                //Spearfish torpedo 
                //Sea Wolf (missile)
                //UNITED STATES OF AMERICA
                  #region Weapon  RIM-162 Evolved Sea Sparrow Missile
            new SeaObjectWeapon
            {
                WeaponName = "Mark 38 20mm Cannon",
                IsNuclearWeapon = false,
            },
                #endregion
                #region Weapon  Mark 45 5-inch gun
                new SeaObjectWeapon
            {
                WeaponName = "Mk 45 5-inch Gun",
                weaponType = SeaWeaponType.C127mm,
                WeaponAmmoName = "127mm x AP",
                RearmCost = 1,
                CountryOfOrigin = "US",
                IsNuclearWeapon = false,
                
                TechLevel = 1,
                ThreatRange = Weapon.ThreatRanges.MediumRange,
                MaxNumWeaponsRemaining = 680,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.SensorFuze), ReturnWarheadType(WarheadType.Airbust) },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>() { ReturnWeaponPerksType(WeaponPerks.HEAT), ReturnWeaponPerksType(WeaponPerks.RIFLED) },
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 15000,
                WeaponRangeGround = 24000,
                WeaponRateOfFire = 20,
                WeaponAP = 1,
                WeaponHE = 0,
                WeaponReliablity = 0.95f,
                WeaponResistance = 1,
                WeaponSpeed = 800,
            },

               new SeaObjectWeapon
            {
                WeaponName = "Mk 45 5-inch Gun Rocket Assist",
                weaponType = SeaWeaponType.C127mm,
                WeaponAmmoName = "127mm x Rocket",
                RearmCost = 1,
                CountryOfOrigin = "US",
                IsNuclearWeapon = false,
                
                TechLevel = 1,
                ThreatRange = Weapon.ThreatRanges.LongRange,
                MaxNumWeaponsRemaining = 700,
                WarheadSize = 5,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.SensorFuze), ReturnWarheadType(WarheadType.Airbust) },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>() { ReturnWeaponPerksType(WeaponPerks.HEAT), ReturnWeaponPerksType(WeaponPerks.RocketAssist) },
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 22000,
                WeaponRangeGround = 42000,
                WeaponRateOfFire = 20,
                WeaponAP = 0,
                WeaponHE = 3,
                WeaponReliablity = 0.95f,
                WeaponResistance = 1,
                WeaponSpeed = 800,
            },
               new SeaObjectWeapon
            {
                WeaponName = "Mk 45 5-inch HVP",
                weaponType = SeaWeaponType.C127mm,
                WeaponAmmoName = "127mm x Hypersonic",
                RearmCost = 1,
                CountryOfOrigin = "US",
                IsNuclearWeapon = false,
                
                TechLevel = 1,
                ThreatRange = Weapon.ThreatRanges.MediumRange,
                MaxNumWeaponsRemaining = 680,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.SensorFuze), ReturnWarheadType(WarheadType.Airbust) },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>() { ReturnWeaponPerksType(WeaponPerks.HEAT), ReturnWeaponPerksType(WeaponPerks.RIFLED) },
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 15000,
                WeaponRangeGround = 24000,
                WeaponRateOfFire = 20,
                WeaponAP = 1,
                WeaponHE = 0,
                WeaponReliablity = 0.95f,
                WeaponResistance = 1,
                WeaponSpeed = 800,
            },
                #endregion 
             #region Weapon  Phalanx CIWS
            new SeaObjectWeapon
            {
                WeaponName = "Phalanx CIWS",
                weaponType = SeaWeaponType.CIWS30m,
                WeaponAmmoName = "30mm x AP",
                RearmCost = 1,
                CountryOfOrigin = "US",
                IsNuclearWeapon = false,
                
                TechLevel = 1,
                ThreatRange = Weapon.ThreatRanges.ShortRange,
                MaxNumWeaponsRemaining = 1550,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.ArmorPenator), ReturnWarheadType(WarheadType.Airbust) },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>() { ReturnWeaponPerksType(WeaponPerks.APFSDT), ReturnWeaponPerksType(WeaponPerks.Gatling ) },
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 2200,
                WeaponRangeGround = 3500,
                WeaponRateOfFire = 4500,
                WeaponAP = 1,
                WeaponHE = 0,
                WeaponReliablity = 0.95f,
                WeaponResistance = 1,
                WeaponSpeed = 1100,
            },
             new SeaObjectWeapon
            {
                WeaponName = "SeaRAM CIWS",
                weaponType = SeaWeaponType.CIWSMissle,
                WeaponAmmoName = "11x RIM-116 Rolling Airframe Missile",
                RearmCost = 1,
                CountryOfOrigin = "US",
                IsNuclearWeapon = false,
                
                TechLevel = 1,
                ThreatRange = Weapon.ThreatRanges.ShortRange,
                MaxNumWeaponsRemaining = 11,
                WarheadSize = 3,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.ArmorPenator), ReturnWarheadType(WarheadType.Airbust) },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>() { ReturnWeaponPerksType(WeaponPerks.IR)},
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 2200,
                WeaponRangeGround = 3500,
                WeaponRateOfFire = 4500,
                WeaponAP = 1,
                WeaponHE = 0,
                WeaponReliablity = 0.95f,
                WeaponResistance = 1,
                WeaponSpeed = 1100,
            },
                #endregion
             #region Weapon  RGM-84 Harpoon
            new SeaObjectWeapon
            {
                WeaponName = "RGM-84 Harpoon",
                weaponType = SeaWeaponType.AntiShipMissileRadar,
                WeaponAmmoName = "RGM-84 Harpoon",
                RearmCost = 1,
                CountryOfOrigin = "US",
                IsNuclearWeapon = false,
                
                TechLevel = 4,
                ThreatRange = Weapon.ThreatRanges.MediumRange,
                MaxNumWeaponsRemaining = 1,
                WarheadSize = 5,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.ArmorPenator), ReturnWarheadType(WarheadType.Blast) },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>() { ReturnWeaponPerksType(WeaponPerks.SeaSkimmning), ReturnWeaponPerksType(WeaponPerks.ActiveRadarGuided ) },
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 70000,
                WeaponRangeGround = 120000,
                WeaponRateOfFire = 1,
                WeaponAP = 5,
                WeaponHE = 0,
                WeaponReliablity = 0.55f,
                WeaponResistance = 1,
                WeaponSpeed = 240,
            },
            #endregion
               #region Weapon AGM-158C LRASM
            new SeaObjectWeapon
            {
                WeaponName = "LRASM",
                weaponType = SeaWeaponType.AntiShipMissileRadar,
                WeaponAmmoName = "AGM-158C",
                RearmCost = 1,
                CountryOfOrigin = "US",
                IsNuclearWeapon = false,
                
                TechLevel = 4,
                ThreatRange = Weapon.ThreatRanges.MediumRange,
                MaxNumWeaponsRemaining = 1,
                WarheadSize = 5,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.ArmorPenator), ReturnWarheadType(WarheadType.Blast) },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>() { ReturnWeaponPerksType(WeaponPerks.SeaSkimmning), ReturnWeaponPerksType(WeaponPerks.ActiveRadarGuided ) },
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 70000,
                WeaponRangeGround = 120000,
                WeaponRateOfFire = 1,
                WeaponAP = 5,
                WeaponHE = 0,
                WeaponReliablity = 0.55f,
                WeaponResistance = 1,
                WeaponSpeed = 240,
            },
            #endregion
            
             #region Weapon BGM-109 Tomahawk
            new SeaObjectWeapon
            {
                WeaponName = "BGM-109 Tomahawk",
                IsNuclearWeapon = false,
            },
            new SeaObjectWeapon
            {
                WeaponName = "BGM-109 Tomahawk TLAM-N",
                IsNuclearWeapon = true,
            },
            #endregion
             #region Weapon RIM-66 Standard
            new SeaObjectWeapon
            {
                WeaponName = "RIM-66 Standard",
                IsNuclearWeapon = false,
            },
             new SeaObjectWeapon
            {
                WeaponName = "RIM-67 Standard",
                IsNuclearWeapon = false,
            },
              new SeaObjectWeapon
            {
                WeaponName = "RIM-161 Standard",
                IsNuclearWeapon = false,
            },
                new SeaObjectWeapon
            {
                WeaponName = "RIM-174 Standard",
                IsNuclearWeapon = false,
            },
            #endregion
             #region Weapon  RIM-162 Evolved Sea Sparrow Missile
            new SeaObjectWeapon
            {
                WeaponName = "RIM-162 Evolved Sea Sparrow Missile",
                IsNuclearWeapon = false,
            },
            #endregion
             #region Weapon  RUM-139 VL-ASROC
            new SeaObjectWeapon
            {
                WeaponName = "RUM-139 VL-ASROC",
                IsNuclearWeapon = false,
            },
            #endregion
             #region Weapon  Mark 46 torpedo
            new SeaObjectWeapon
            {
                WeaponName = "Mark 46 torpedo",
                IsNuclearWeapon = false,
            },
            #endregion
             #region Weapon  Mark 48 torpedo
            new SeaObjectWeapon
            {
                WeaponName = "Mark 48 torpedo ADCAP",
                IsNuclearWeapon = false,
            },
            #endregion
             #region Weapon Mark 50 torpedo
            new SeaObjectWeapon
            {
                WeaponName = "Mark 50 torpedo",
                IsNuclearWeapon = false,
            },
            #endregion
             #region Weapon  Mark 54 torpedo
            new SeaObjectWeapon
            {
                WeaponName = "Mark 54 torpedo",
                IsNuclearWeapon = false,
            },
            #endregion
             #region Weapon Mark 60 Captor Mine
            new SeaObjectWeapon
            {
                WeaponName = "Mark 60 Captor Mine",
                IsNuclearWeapon = false,
            },
            #endregion
             #region Weapon Trident (D5) Ballistic missile
            new SeaObjectWeapon
            {
                WeaponName = "UGM-133 Trident II",
                IsNuclearWeapon = false,
            },
            #endregion
             #region Weapon  Naval Strike Missile
            new SeaObjectWeapon
            {
                WeaponName = "Naval Strike Missile",
                IsNuclearWeapon = false,
            },
            #endregion
             #region Weapon AN/SEQ-3 Laser Weapon System
            new SeaObjectWeapon
            {
                WeaponName = "AN/SEQ-3 Laser Weapon System",
                IsNuclearWeapon = false,
            },
            #endregion
            };

        }

        public List<AircraftWeapon> GetAirWeaponList()
        {
            return new List<AircraftWeapon>() {
             #region Weapon 
            new AircraftWeapon
            {
                IsNuclearWeapon = false,
            },
              #endregion 
            new AircraftWeapon
            {
                IsNuclearWeapon = false,
            },
            new AircraftWeapon
            {
                IsNuclearWeapon = false,
            },
            };
        }


        /// <summary>
        /// The default list of ground weapons, TODO refactor to a country list index so we can pull them faster per country
        /// </summary>
        /// <returns></returns>
        public List<GroundVehicleWeapon> GetListWeapons()
        {

            var Weapons = new List<GroundVehicleWeapon>();

            #region Weapon 
            Weapons.Add(new GroundVehicleWeapon()
            {
                weaponType = GroundVehicleWeaponType.MG7_62mm,
                WeaponName = "M240",
                WeaponAmmoName = "7.62mm x FMJ",
                RearmCost = 1,
                CountryOfOrigin = "US",
                IsNuclearWeapon = false,
                
                TechLevel = 1,
                ThreatRange = (int)Weapon.ThreatRanges.Tactical,
                MaxNumWeaponsRemaining = 600,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.ArmorPenator), ReturnWarheadType(WarheadType.FMJ) },
                WeaponIconName = new UnityEngine.Texture2D(32, 32),
                WeaponPerks = new List<WeaponPerks>(),
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 1000,
                WeaponRangeGround = 1800,
                WeaponRateOfFire = 600,
                WeaponAP = 1,
                WeaponHE = 0,
                WeaponReliablity = 0.95f,
                WeaponResistance = 1,
                WeaponSpeed = 890
            });
            #endregion

            #region Weapon 
            Weapons.Add(new GroundVehicleWeapon()
            {
                weaponType = GroundVehicleWeaponType.MG7_62mm,
                WeaponName = "M73",
                WeaponAmmoName = "7.62×51mm NATO",
                RearmCost = 1,
                CountryOfOrigin = "US",
                IsNuclearWeapon = false,
                
                TechLevel = 1,
                ThreatRange = (int)Weapon.ThreatRanges.Tactical,
                MaxNumWeaponsRemaining = 600,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.ArmorPenator), ReturnWarheadType(WarheadType.FMJ) },
                WeaponIconName = new UnityEngine.Texture2D(32, 32),
                WeaponPerks = new List<WeaponPerks>(),
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 1000,
                WeaponRangeGround = 1800,
                WeaponRateOfFire = 600,
                WeaponAP = 1,
                WeaponHE = 0,
                WeaponReliablity = 0.95f,
                WeaponResistance = 1,
                WeaponSpeed = 890
            });
            #endregion

            #region Weapon 
            Weapons.Add(new GroundVehicleWeapon()
            {
                weaponType = GroundVehicleWeaponType.MG5_56mm,
                WeaponName = "M249",
                WeaponAmmoName = "5.56mm x AP",
                RearmCost = 1,
                CountryOfOrigin = "US",
                IsNuclearWeapon = false,
                
                TechLevel = 1,
                ThreatRange = (int)Weapon.ThreatRanges.Tactical,
                MaxNumWeaponsRemaining = 500,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.ArmorPenator) },
                WeaponIconName = new UnityEngine.Texture2D(32, 32),
                WeaponPerks = new List<WeaponPerks>(),
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 1000,
                WeaponRangeGround = 1800,
                WeaponRateOfFire = 600,
                WeaponAP = 1,
                WeaponHE = 0,
                WeaponReliablity = 0.95f,
                WeaponResistance = 1,
                WeaponSpeed = 890
            });
            #endregion


            #region Weapon 
            //Centurion
            //and derivatives such as Olifant
            //EE - T1 Osório
            //Leopard 1
            //M1 Abrams in early models (the M1 and M1IP models)
            //M47 Patton in some upgraded variants(examples: Spanish M47E1 and M47E2)
            //M48 Patton in some upgraded variants(M48A5, Israeli - rebuilt M48s, etc.)
            //M60 Patton Tank[7]
            //M1128 Mobile Gun System
            //K1 Type 88
            //Merkava I and II
            //OF - 40
            //CM11 Brave Tiger
            //Pz - 61 & Pz - 68
            //Stingray light tank
            //T - 54 in several upgraded variants(for example Israeli Tiran - 4Sh)
            //T - 55 in several upgraded variants(for example Egyptian and Israeli modified T - 55s)
            //TAM medium tank
            //Type 74
            //Vickers MBT
            //Vijayanta
            //Ramses II
            //Chinese Type 88 tank.
            //Chinese ZTD-05 Light tank
            Weapons.Add(new GroundVehicleWeapon()
            {
                weaponType = GroundVehicleWeaponType.C105mm,
                WeaponName = "L7 APFSDT",
                WeaponAmmoName = "105mm Cannnon APFSDS",
                RearmCost = 1,
                CountryOfOrigin = "UK",
                IsNuclearWeapon = false,
                
                TechLevel = 2,
                ThreatRange = (int)Weapon.ThreatRanges.Tactical,
                MaxNumWeaponsRemaining = 60,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.Sabot), ReturnWarheadType(WarheadType.ArmorPenator) },
                WeaponIconName = new UnityEngine.Texture2D(32, 32),
                WeaponPerks = new List<WeaponPerks>() { ReturnWeaponPerksType(WeaponPerks.APFSDT), ReturnWeaponPerksType(WeaponPerks.RIFLED) },
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 0,
                WeaponRangeGround = 3500,
                WeaponRateOfFire = 10,
                WeaponAP = 11,
                WeaponHE = 0,
                WeaponReliablity = 0.95f, // likelyness the weapon will hit its target once detected targeted and fired at
                WeaponResistance = 1, // 1 bullets, % for weapon being jammed
                WeaponSpeed = 730 // the kinetic energy of the weapons 
            });
            Weapons.Add(new GroundVehicleWeapon()
            {
                weaponType = GroundVehicleWeaponType.C105mm,
                WeaponName = "L7 HEAT",
                WeaponAmmoName = "105mm Cannon HEAT",
                RearmCost = 1,
                CountryOfOrigin = "UK",
                IsNuclearWeapon = false,
                TechLevel = 2,
                ThreatRange = (int)Weapon.ThreatRanges.Tactical,
                MaxNumWeaponsRemaining = 60,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.ArmorPenator), ReturnWarheadType(WarheadType.Blast), },
                WeaponIconName = new UnityEngine.Texture2D(32, 32),
                WeaponPerks = new List<WeaponPerks>() { ReturnWeaponPerksType(WeaponPerks.APFSDT), ReturnWeaponPerksType(WeaponPerks.RIFLED) },
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 0,
                WeaponRangeGround = 3500,
                WeaponRateOfFire = 10,
                WeaponAP = 0,
                WeaponHE = 8,
                WeaponReliablity = 0.95f, // likelyness the weapon will hit its target once detected targeted and fired at
                WeaponResistance = 1, // 1 bullets, % for weapon being jammed
                WeaponSpeed = 730 // the kinetic energy of the weapons 
            });
            #endregion
            //M1A1
            #region Weapon 
            Weapons.Add(new GroundVehicleWeapon()
            {
                weaponType = GroundVehicleWeaponType.C105mm,
                WeaponName = "M68A1E4 HEAT",
                WeaponAmmoName = "105mm M830A1 HEAT",
                RearmCost = 1,
                CountryOfOrigin = "US",
                IsNuclearWeapon = false,
                
                TechLevel = 2,
                ThreatRange = (int)Weapon.ThreatRanges.Tactical,
                MaxNumWeaponsRemaining = 60,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.ArmorPenator), ReturnWarheadType(WarheadType.Blast), },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>() { ReturnWeaponPerksType(WeaponPerks.HEAT), ReturnWeaponPerksType(WeaponPerks.RIFLED) },
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 0,
                WeaponRangeGround = 3500,
                WeaponRateOfFire = 10,
                WeaponAP = 0,
                WeaponHE = 8,
                WeaponReliablity = 0.95f, // likelyness the weapon will hit its target once detected targeted and fired at
                WeaponResistance = 1, // 1 bullets, % for weapon being jammed
                WeaponSpeed = 730 // the kinetic energy of the weapons 
            });
            Weapons.Add(new GroundVehicleWeapon()
            {
                weaponType = GroundVehicleWeaponType.C105mm,
                WeaponName = "M68A1E4 APFSDS",
                WeaponAmmoName = "105mm M456A2 APFSDS",
                RearmCost = 1,
                CountryOfOrigin = "US",
                IsNuclearWeapon = false,
                
                TechLevel = 2,
                ThreatRange = (int)Weapon.ThreatRanges.Tactical,
                MaxNumWeaponsRemaining = 60,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.ArmorPenator), ReturnWarheadType(WarheadType.Blast), },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>() { ReturnWeaponPerksType(WeaponPerks.HEAT), ReturnWeaponPerksType(WeaponPerks.RIFLED) },
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 0,
                WeaponRangeGround = 3500,
                WeaponRateOfFire = 10,
                WeaponAP = 0,
                WeaponHE = 8,
                WeaponReliablity = 0.95f, // likelyness the weapon will hit its target once detected targeted and fired at
                WeaponResistance = 1, // 1 bullets, % for weapon being jammed
                WeaponSpeed = 730 // the kinetic energy of the weapons 
            });
            Weapons.Add(new GroundVehicleWeapon()
            {
                weaponType = GroundVehicleWeaponType.C105mm,
                WeaponName = "M68A1E4 CANISTER",
                WeaponAmmoName = "105mm M1040 Canister",
                RearmCost = 1,
                CountryOfOrigin = "US",
                IsNuclearWeapon = false,
                
                TechLevel = 2,
                ThreatRange = (int)Weapon.ThreatRanges.Tactical,
                MaxNumWeaponsRemaining = 60,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.ArmorPenator), ReturnWarheadType(WarheadType.Blast), },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>() { ReturnWeaponPerksType(WeaponPerks.HEAT), ReturnWeaponPerksType(WeaponPerks.RIFLED) },
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 0,
                WeaponRangeGround = 3500,
                WeaponRateOfFire = 10,
                WeaponAP = 0,
                WeaponHE = 8,
                WeaponReliablity = 0.95f, // likelyness the weapon will hit its target once detected targeted and fired at
                WeaponResistance = 1, // 1 bullets, % for weapon being jammed
                WeaponSpeed = 730 // the kinetic energy of the weapons 
            });
            #endregion
            //UK
            #region Weapon 
            Weapons.Add(new GroundVehicleWeapon()
            {
                weaponType = GroundVehicleWeaponType.C120mm,
                WeaponName = "L11 APFSDT",
                WeaponAmmoName = "120mm Cannnon APFSDT",
                RearmCost = 1,
                CountryOfOrigin = "UK",
                IsNuclearWeapon = false,
                
                TechLevel = 2,
                ThreatRange = (int)Weapon.ThreatRanges.Tactical,
                MaxNumWeaponsRemaining = 55,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.Sabot) },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>() { ReturnWeaponPerksType(WeaponPerks.APFSDT), ReturnWeaponPerksType(WeaponPerks.RIFLED) },
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 0,
                WeaponRangeGround = 2000,
                WeaponRateOfFire = 8,
                WeaponAP = 14,
                WeaponHE = 0,
                WeaponReliablity = 0.95f, // likelyness the weapon will hit its target once detected targeted and fired at
                WeaponResistance = 1, // 1 bullets, % for weapon being jammed
                WeaponSpeed = 1370 // the kinetic energy of the weapons 
            });

            Weapons.Add(new GroundVehicleWeapon()
            {
                weaponType = GroundVehicleWeaponType.C120mm,
                WeaponName = "L11 HESH", //HESH shaped
                WeaponAmmoName = "120mm Cannnon HESH",
                RearmCost = 1,
                CountryOfOrigin = "UK",
                IsNuclearWeapon = false,
                
                TechLevel = 2,
                ThreatRange = (int)Weapon.ThreatRanges.Tactical,
                MaxNumWeaponsRemaining = 55,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.Blast), ReturnWarheadType(WarheadType.Shaped) },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>() { ReturnWeaponPerksType(WeaponPerks.HESH), ReturnWeaponPerksType(WeaponPerks.RIFLED) },
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 0,
                WeaponRangeGround = 2000,
                WeaponRateOfFire = 8,
                WeaponAP = 0,
                WeaponHE = 8,
                WeaponReliablity = 0.95f, // likelyness the weapon will hit its target once detected targeted and fired at
                WeaponResistance = 1, // 1 bullets, % for weapon being jammed
                WeaponSpeed = 670 // the kinetic energy of the weapons 
            });
            #endregion
            #region Weapon 
            Weapons.Add(new GroundVehicleWeapon()
            {
                weaponType = GroundVehicleWeaponType.C120mm,
                WeaponName = "L11A5 120mm Cannnon APFSDT",
                RearmCost = 1,
                CountryOfOrigin = "UK",
                IsNuclearWeapon = false,
                
                TechLevel = 2,
                ThreatRange = (int)Weapon.ThreatRanges.Tactical,
                MaxNumWeaponsRemaining = 55,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.Sabot) },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>() { ReturnWeaponPerksType(WeaponPerks.APFSDT), ReturnWeaponPerksType(WeaponPerks.SmoothBore) },
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 0,
                WeaponRangeGround = 2000,
                WeaponRateOfFire = 8,
                WeaponAP = 11,
                WeaponHE = 0,
                WeaponReliablity = 0.95f, // likelyness the weapon will hit its target once detected targeted and fired at
                WeaponResistance = 1, // 1 bullets, % for weapon being jammed
                WeaponSpeed = 1370 // the kinetic energy of the weapons 
            });

            Weapons.Add(new GroundVehicleWeapon()
            {
                weaponType = GroundVehicleWeaponType.C120mm,
                WeaponName = "L11A5 120mm Cannnon HESH", //HESH shaped
                RearmCost = 1,
                CountryOfOrigin = "UK",
                IsNuclearWeapon = false,
                
                TechLevel = 2,
                ThreatRange = (int)Weapon.ThreatRanges.Tactical,
                MaxNumWeaponsRemaining = 55,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.Blast), ReturnWarheadType(WarheadType.Shaped) },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>() { ReturnWeaponPerksType(WeaponPerks.HESH), ReturnWeaponPerksType(WeaponPerks.RIFLED) },
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 0,
                WeaponRangeGround = 2000,
                WeaponRateOfFire = 8,
                WeaponAP = 0,
                WeaponHE = 8,
                WeaponReliablity = 0.95f, // likelyness the weapon will hit its target once detected targeted and fired at
                WeaponResistance = 1, // 1 bullets, % for weapon being jammed
                WeaponSpeed = 670 // the kinetic energy of the weapons 
            });
            #endregion
            //L30
            #region Weapon 
            Weapons.Add(new GroundVehicleWeapon()
            {
                weaponType = GroundVehicleWeaponType.C120mm,
                WeaponName = "L30 120mm Cannnon APFSDS",
                RearmCost = 1,
                CountryOfOrigin = "UK",
                IsNuclearWeapon = false,
                
                TechLevel = 2,
                ThreatRange = (int)Weapon.ThreatRanges.Tactical,
                MaxNumWeaponsRemaining = 55,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.Sabot) },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>() { ReturnWeaponPerksType(WeaponPerks.APFSDT), ReturnWeaponPerksType(WeaponPerks.RIFLED) },
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 0,
                WeaponRangeGround = 2000,
                WeaponRateOfFire = 8,
                WeaponAP = 9,
                WeaponHE = 0,
                WeaponReliablity = 0.95f, // likelyness the weapon will hit its target once detected targeted and fired at
                WeaponResistance = 1, // 1 bullets, % for weapon being jammed
                WeaponSpeed = 1370 // the kinetic energy of the weapons 
            });

            Weapons.Add(new GroundVehicleWeapon()
            {
                weaponType = GroundVehicleWeaponType.C120mm,
                WeaponName = "L30 120mm Cannnon HESH", //HESH shaped
                RearmCost = 1,
                CountryOfOrigin = "UK",
                IsNuclearWeapon = false,
                
                TechLevel = 2,
                ThreatRange = (int)Weapon.ThreatRanges.Tactical,
                MaxNumWeaponsRemaining = 55,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.Blast), ReturnWarheadType(WarheadType.Shaped) },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>() { ReturnWeaponPerksType(WeaponPerks.HESH), ReturnWeaponPerksType(WeaponPerks.RIFLED) },
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 0,
                WeaponRangeGround = 2000,
                WeaponRateOfFire = 8,
                WeaponAP = 1,
                WeaponHE = 7,
                WeaponReliablity = 0.95f, // likelyness the weapon will hit its target once detected targeted and fired at
                WeaponResistance = 1, // 1 bullets, % for weapon being jammed
                WeaponSpeed = 670 // the kinetic energy of the weapons 
            });
            #endregion
            //M1A2
            #region Weapon 
            Weapons.Add(new GroundVehicleWeapon()
            {
                weaponType = GroundVehicleWeaponType.C120mm,
                WeaponName = "M256 (L/44) APFSDS", //HESH shaped
                WeaponAmmoName = "120mm M829A1 APFSDS",
                RearmCost = 1,
                CountryOfOrigin = "US",
                IsNuclearWeapon = false,
                
                TechLevel = 2,
                ThreatRange = (int)Weapon.ThreatRanges.Tactical,
                MaxNumWeaponsRemaining = 55,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.Sabot) },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>() { ReturnWeaponPerksType(WeaponPerks.APFSDT), ReturnWeaponPerksType(WeaponPerks.SmoothBore) },
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 0,
                WeaponRangeGround = 2000,
                WeaponRateOfFire = 8,
                WeaponAP = 11,
                WeaponHE = 0,
                WeaponReliablity = 0.95f, // likelyness the weapon will hit its target once detected targeted and fired at
                WeaponResistance = 1, // 1 bullets, % for weapon being jammed
                WeaponSpeed = 1370 // the kinetic energy of the weapons 
            });

            Weapons.Add(new GroundVehicleWeapon()
            {
                weaponType = GroundVehicleWeaponType.C120mm,
                WeaponName = "M256 (L/44) HEAT", //HESH shaped
                WeaponAmmoName = "120mm M830A1 HEAT MP-T",
                RearmCost = 1,
                CountryOfOrigin = "GR",
                IsNuclearWeapon = false,
                
                TechLevel = 2,
                ThreatRange = (int)Weapon.ThreatRanges.Tactical,
                MaxNumWeaponsRemaining = 55,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.Blast), ReturnWarheadType(WarheadType.Shaped) },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>() { ReturnWeaponPerksType(WeaponPerks.HEAT), ReturnWeaponPerksType(WeaponPerks.SmoothBore) },
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 0,
                WeaponRangeGround = 2000,
                WeaponRateOfFire = 8,
                WeaponAP = 3,
                WeaponHE = 5,
                WeaponReliablity = 0.95f, // likelyness the weapon will hit its target once detected targeted and fired at
                WeaponResistance = 1, // 1 bullets, % for weapon being jammed
                WeaponSpeed = 670 // the kinetic energy of the weapons 
            });
            #endregion
            //L44
            #region Weapon 
            Weapons.Add(new GroundVehicleWeapon()
            {
                weaponType = GroundVehicleWeaponType.C120mm,
                WeaponName = "L44A1 APFSDT",
                WeaponAmmoName = "120mm Cannnon DM65 APFSDT",
                RearmCost = 1,
                CountryOfOrigin = "GR",
                IsNuclearWeapon = false,
                
                TechLevel = 2,
                ThreatRange = (int)Weapon.ThreatRanges.Tactical,
                MaxNumWeaponsRemaining = 55,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.Sabot) },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>() { ReturnWeaponPerksType(WeaponPerks.APFSDT), ReturnWeaponPerksType(WeaponPerks.SmoothBore) },
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 0,
                WeaponRangeGround = 2000,
                WeaponRateOfFire = 8,
                WeaponAP = 11,
                WeaponHE = 0,
                WeaponReliablity = 0.95f, // likelyness the weapon will hit its target once detected targeted and fired at
                WeaponResistance = 1, // 1 bullets, % for weapon being jammed
                WeaponSpeed = 1370 // the kinetic energy of the weapons 
            });

            Weapons.Add(new GroundVehicleWeapon()
            {
                weaponType = GroundVehicleWeaponType.C120mm,
                WeaponName = "L44A4 HEAT", //HESH shaped
                WeaponAmmoName = "120mm Cannnon DM12 HEAT",
                RearmCost = 1,
                CountryOfOrigin = "GR",
                IsNuclearWeapon = false,
                
                TechLevel = 2,
                ThreatRange = (int)Weapon.ThreatRanges.Tactical,
                MaxNumWeaponsRemaining = 55,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.Blast), ReturnWarheadType(WarheadType.Shaped) },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>() { ReturnWeaponPerksType(WeaponPerks.HESH), ReturnWeaponPerksType(WeaponPerks.SmoothBore) },
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 0,
                WeaponRangeGround = 2000,
                WeaponRateOfFire = 8,
                WeaponAP = 1,
                WeaponHE = 11,
                WeaponReliablity = 0.95f, // likelyness the weapon will hit its target once detected targeted and fired at
                WeaponResistance = 1, // 1 bullets, % for weapon being jammed
                WeaponSpeed = 670 // the kinetic energy of the weapons 
            });
            #endregion
            //L55
            #region Weapon 
            Weapons.Add(new GroundVehicleWeapon()
            {
                weaponType = GroundVehicleWeaponType.C120mm,
                WeaponName = "L55 120mm Cannnon APFSDT",
                RearmCost = 1,
                CountryOfOrigin = "GR",
                IsNuclearWeapon = false,
                
                TechLevel = 2,
                ThreatRange = (int)Weapon.ThreatRanges.Tactical,
                MaxNumWeaponsRemaining = 55,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.Sabot) },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>() { ReturnWeaponPerksType(WeaponPerks.APFSDT), ReturnWeaponPerksType(WeaponPerks.SmoothBore) },
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 0,
                WeaponRangeGround = 2000,
                WeaponRateOfFire = 8,
                WeaponAP = 9,
                WeaponHE = 0,
                WeaponReliablity = 0.95f, // likelyness the weapon will hit its target once detected targeted and fired at
                WeaponResistance = 1, // 1 bullets, % for weapon being jammed
                WeaponSpeed = 1370 // the kinetic energy of the weapons 
            });

            Weapons.Add(new GroundVehicleWeapon()
            {
                weaponType = GroundVehicleWeaponType.C120mm,
                WeaponName = "L55 120mm Cannnon HESH", //HESH shaped
                WeaponAmmoName = "12.7×108mm AP",
                RearmCost = 1,
                CountryOfOrigin = "GR",
                IsNuclearWeapon = false,
                
                TechLevel = 2,
                ThreatRange = (int)Weapon.ThreatRanges.Tactical,
                MaxNumWeaponsRemaining = 55,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.Blast), ReturnWarheadType(WarheadType.Shaped) },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>() { ReturnWeaponPerksType(WeaponPerks.HESH), ReturnWeaponPerksType(WeaponPerks.SmoothBore) },
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 0,
                WeaponRangeGround = 2000,
                WeaponRateOfFire = 8,
                WeaponAP = 0,
                WeaponHE = 6,
                WeaponReliablity = 0.95f, // likelyness the weapon will hit its target once detected targeted and fired at
                WeaponResistance = 1, // 1 bullets, % for weapon being jammed
                WeaponSpeed = 670 // the kinetic energy of the weapons 
            });
            #endregion
            //DSKM
            #region Weapon 
            Weapons.Add(new GroundVehicleWeapon()
            {
                weaponType = GroundVehicleWeaponType.MG12_7mm,
                WeaponName = "DShK 1938/46",
                WeaponAmmoName = "12.7×108mm AP",
                RearmCost = 1,
                CountryOfOrigin = "RU",
                IsNuclearWeapon = false,
                
                TechLevel = 1,
                ThreatRange = (int)Weapon.ThreatRanges.Tactical,
                MaxNumWeaponsRemaining = 500,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.ArmorPenator) },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>(),
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 1000,
                WeaponRangeGround = 2000,
                WeaponRateOfFire = 600,
                WeaponAP = 2,
                WeaponHE = 0,
                WeaponReliablity = 0.95f,
                WeaponResistance = 1,
                WeaponSpeed = 850
            });
            #endregion

            #region Weapon 
            Weapons.Add(new GroundVehicleWeapon()
            {
                weaponType = GroundVehicleWeaponType.MG12_7mm,
                WeaponName = "DShKM",
                WeaponAmmoName = "12.7×108mm AP",
                RearmCost = 1,
                CountryOfOrigin = "RU",
                IsNuclearWeapon = false,
                
                TechLevel = 2,
                ThreatRange = (int)Weapon.ThreatRanges.Tactical,
                MaxNumWeaponsRemaining = 600,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.ArmorPenator) },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>(),
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 1000,
                WeaponRangeGround = 2000,
                WeaponRateOfFire = 600,
                WeaponAP = 2,
                WeaponHE = 0,
                WeaponReliablity = 0.95f,
                WeaponResistance = 1,
                WeaponSpeed = 850
            });
            #endregion
            //M2
            #region Weapon 
            Weapons.Add(new GroundVehicleWeapon()
            {
                weaponType = GroundVehicleWeaponType.MG12_7mm,
                WeaponName = "M2 Browning",
                WeaponAmmoName = "12.7×99mm NATO",
                RearmCost = 1,
                CountryOfOrigin = "US",
                IsNuclearWeapon = false,
                
                TechLevel = 2,
                ThreatRange = (int)Weapon.ThreatRanges.Tactical,
                MaxNumWeaponsRemaining = 600,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.ArmorPenator) },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>(),
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 1000,
                WeaponRangeGround = 2000,
                WeaponRateOfFire = 600,
                WeaponAP = 2,
                WeaponHE = 0,
                WeaponReliablity = 0.95f,
                WeaponResistance = 1,
                WeaponSpeed = 850
            });
            #endregion
            #region Weapon 
            Weapons.Add(new GroundVehicleWeapon()
            {
                weaponType = GroundVehicleWeaponType.MG12_7mm,
                WeaponName = "M2A1 Browning",
                WeaponAmmoName = "12.7×99mm NATO",
                RearmCost = 1,
                CountryOfOrigin = "US",
                IsNuclearWeapon = false,
                
                TechLevel = 2,
                ThreatRange = (int)Weapon.ThreatRanges.Tactical,
                MaxNumWeaponsRemaining = 600,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.ArmorPenator) },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>(),
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 1000,
                WeaponRangeGround = 2000,
                WeaponAP = 2,
                WeaponHE = 0,
                WeaponRateOfFire = 600,
                WeaponReliablity = 0.95f,
                WeaponResistance = 1,
                WeaponSpeed = 850
            });
            #endregion

            #region Weapon 
            Weapons.Add(new GroundVehicleWeapon()
            {
                weaponType = GroundVehicleWeaponType.MG12_7mm,
                WeaponName = "60mm Mortar HE",
                WeaponAmmoName = "60mm High Explosive",
                RearmCost = 1,
                CountryOfOrigin = "US",
                IsNuclearWeapon = false,
                
                TechLevel = 2,
                ThreatRange = (int)Weapon.ThreatRanges.Tactical,
                MaxNumWeaponsRemaining = 600,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.Blast) },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>(),
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 0,
                WeaponRangeGround = 3500,
                WeaponAP = 0,
                WeaponHE = 5,
                WeaponRateOfFire = 20,
                WeaponReliablity = 0.95f,
                WeaponResistance = 1,
                WeaponSpeed = 850
            });
            #endregion


            //
            #region Weapon MGM52 Lance
            Weapons.Add(new GroundVehicleWeapon()
            {
                weaponType = GroundVehicleWeaponType.MG12_7mm,
                WeaponName = "MGM52 Lance",
                WeaponAmmoName = "500lb HE",
                RearmCost = 1,
                CountryOfOrigin = "US",
                IsNuclearWeapon = false,
                
                TechLevel = 2,
                ThreatRange = Weapon.ThreatRanges.TheaterShortRange,
                MaxNumWeaponsRemaining = 600,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.Blast) },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>(),
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 0,
                WeaponRangeGround = 3500,
                WeaponAP = 0,
                WeaponHE = 5,
                WeaponRateOfFire = 20,
                WeaponReliablity = 0.95f,
                WeaponResistance = 1,
                WeaponSpeed = 850
            });
            #endregion

            #region Weapon MGM52N Lance
            Weapons.Add(new GroundVehicleWeapon()
            {
                weaponType = GroundVehicleWeaponType.MG12_7mm,
                WeaponName = "MGM52 Lance",
                WeaponAmmoName = "70 kiloton W85",
                RearmCost = 1,
                CountryOfOrigin = "US",
                IsNuclearWeapon = true,
                
                TechLevel = 2,
                ThreatRange = Weapon.ThreatRanges.TheaterShortRange,
                MaxNumWeaponsRemaining = 600,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.Blast) },
                WeaponIconName = new UnityEngine.Texture2D(32,32),
                WeaponPerks = new List<WeaponPerks>(),
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 0,
                WeaponRangeGround = 3500,
                WeaponAP = 0,
                WeaponHE = 5,
                WeaponRateOfFire = 20,
                WeaponReliablity = 0.95f,
                WeaponResistance = 1,
                WeaponSpeed = 850
            });
            #endregion

            #region Weapon M198 155mm
            Weapons.Add(new GroundVehicleWeapon()
            {
                weaponType = GroundVehicleWeaponType.MG12_7mm,
                WeaponName = "M198 155mm",
                WeaponAmmoName = "155mm High Explosive",
                RearmCost = 1,
                CountryOfOrigin = "US",
                IsNuclearWeapon = false,
                
                TechLevel = 2,
                ThreatRange = Weapon.ThreatRanges.MediumRange,
                MaxNumWeaponsRemaining = 600,
                WarheadSize = 1,
                warheadType = new List<WarheadType> { ReturnWarheadType(WarheadType.Blast) },
                WeaponIconName = new UnityEngine.Texture2D(32, 32),
                WeaponPerks = new List<WeaponPerks>(),
                WeaponRangeAirHigh = 0,
                WeaponRangeAirLow = 0,
                WeaponRangeGround = 3500,
                WeaponAP = 0,
                WeaponHE = 5,
                WeaponRateOfFire = 20,
                WeaponReliablity = 0.95f,
                WeaponResistance = 1,
                WeaponSpeed = 850
            });
            #endregion
            return Weapons;
        }
    }
}
