using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    public class WeaponsConfigFactory
    {

        public enum WeaponFactoryType
        {
            Air,
            Sea,
            Ground
        }

        public WeaponConfig ReturnWeaponConfigBy(string name)
        {

            var weapon = GetWeaponsConfigList().FirstOrDefault(e => e.Name == name);
            return weapon;
        }

        public WeaponConfig CreateConfigure(string name, float payload, WeaponStationType.PointType type, string[] Weapons)
        {

            var WeaponsStations = CreateWeaponStationType(type, Weapons, WeaponFactoryType.Ground);

            return new WeaponConfig()
            {
                Name = name,
                MaxWeaponsPayload = payload,
                WeaponsStations = new List<WeaponStationType> { WeaponsStations }
            };
        }

        public WeaponStationType CreateWeaponStationType(WeaponStationType.PointType type, string[] Weapons, WeaponFactoryType factoryType)
        {
            var weaponFactory = new ForcesWeaponsFactory();
            var airweapons = new List<AircraftWeapon>();
            var groundweapons = new List<GroundVehicleWeapon>();
            var seaweapons = new List<SeaObjectWeapon>();

            var we = new WeaponStationType()
            {
                WeaponsStationType = type
            };

            if (Weapons.Length > 0)
            {
                for (int i = 0; i < Weapons.Length; i++)
                {
                    switch (factoryType)
                    {
                        case WeaponFactoryType.Ground:
                            we.ConfigWeapons.Add(weaponFactory.GetGroundWeaponBy(Weapons[i]));
                            break;
                        case WeaponFactoryType.Air:
                            break;
                        case WeaponFactoryType.Sea:
                            we.ConfigWeapons.Add(weaponFactory.GetSeaWeaponBy(Weapons[i]));
                            break;

                    }

                }
            }
            return we;
        }

        public SeaObjectWeaponConfig CreateSeaConfigure(string name, float payload, WeaponStationType.PointType type, string[] Weapons)
        {

            var WeaponsStations = CreateWeaponStationType(type, Weapons, WeaponFactoryType.Sea);
            return new SeaObjectWeaponConfig()
            {
                Name = name,
                MaxWeaponsPayload = payload,
                WeaponsStations = new List<WeaponStationType> { WeaponsStations }
            };
        }

        public SeaObjectWeaponConfig ReturnSeaWeaponConfigBy(string name)
        {



            var weapon = GetSeaWeaponsConfigList().FirstOrDefault(e => e.Name == name);
            return weapon;
        }

        public List<SeaObjectWeaponConfig> GetSeaWeaponsConfigList()
        {
            var localList = new List<SeaObjectWeaponConfig>();
            var weaponFactory = new ForcesWeaponsFactory();

            localList.Add(CreateSeaConfigure("USS Wasp", 660f, WeaponStationType.PointType.CrewServered, new string[] { "Phalanx CIWS", "RIM-162 Evolved Sea Sparrow Missile", "Mark 38 20mm Cannon" }));
            return localList;
        }

        public List<WeaponConfig> GetWeaponsConfigList()
        {
            var localList = new List<WeaponConfig>();
            var weaponFactory = new ForcesWeaponsFactory();

            localList.Add(CreateConfigure("Anti-tank Sabot", 60f, WeaponStationType.PointType.FullRotation, new string[] { "L7 APFSDT", "M240", "M2 Browning" }));
            localList.Add(CreateConfigure("Anti-tank HEAT", 60f, WeaponStationType.PointType.FullRotation, new string[] { "L7 HEAT", "M240", "M2 Browning" }));


            #region Base Defenses
            localList.Add(CreateConfigure("155mm Firebase", 60f, WeaponStationType.PointType.FullRotation, new string[] { "M198", "Mk19", "M2 Browning" }));
            #endregion


            //TODO give germany MG
            localList.Add(CreateConfigure("Anti-tank Sabot Leopard 1", 60f, WeaponStationType.PointType.FullRotation, new string[] { "L7 APFSDT", "M240", "M2 Browning" }));
            localList.Add(CreateConfigure("Anti-tank HEAT Leopard 1", 60f, WeaponStationType.PointType.FullRotation, new string[] { "L7 HEAT", "M240", "M2 Browning" }));

            localList.Add(CreateConfigure("Anti-tank Sabot Leopard 2", 60f, WeaponStationType.PointType.FullRotation, new string[] { "L44A1 APFSDT", "M240", "M2 Browning" }));
            localList.Add(CreateConfigure("Anti-tank HEAT Leopard 2", 60f, WeaponStationType.PointType.FullRotation, new string[] { "L44A4 HEAT", "M240", "M2 Browning" }));

            localList.Add(CreateConfigure("Anti-tank Sabot Patton ", 60f, WeaponStationType.PointType.FullRotation, new string[] { "M68A1E4 APFSDS", "M73", "M2 Browning" }));
            localList.Add(CreateConfigure("Anti-tank HEAT Patton", 60f, WeaponStationType.PointType.FullRotation, new string[] { "M68A1E4 HEAT", "M73", "M2 Browning" }));

            localList.Add(CreateConfigure("Anti-tank Sabot Patton 2", 60f, WeaponStationType.PointType.FullRotation, new string[] { "M256 (L/44) APFSDS", "M73", "M2 Browning" }));
            localList.Add(CreateConfigure("Anti-tank HEAT Patton 2", 60f, WeaponStationType.PointType.FullRotation, new string[] { "M256 (L/44) HEAT", "M73", "M2 Browning" }));

            localList.Add(CreateConfigure("Anti-tank Sabot M1A1", 60f, WeaponStationType.PointType.FullRotation, new string[] { "M68A1E4 APFSDS", "M240", "M2 Browning" }));
            localList.Add(CreateConfigure("Anti-tank HEAT M1A1", 60f, WeaponStationType.PointType.FullRotation, new string[] { "M68A1E4 HEAT", "M240", "M2 Browning" }));

            localList.Add(CreateConfigure("Anti-tank Sabot M1A2", 60f, WeaponStationType.PointType.FullRotation, new string[] { "M256 (L/44) APFSDS", "M240", "M2 Browning" }));
            localList.Add(CreateConfigure("Anti-tank HEAT M1A2", 60f, WeaponStationType.PointType.FullRotation, new string[] { "M256 (L/44) HEAT", "M240", "M2 Browning" }));

            localList.Add(CreateConfigure("M1128 Mobile Gun System", 60f, WeaponStationType.PointType.FullRotation, new string[] { "M68A1E4 CANISTER", "M68A1E4 HEAT", "M2 Browning" }));

            localList.Add(CreateConfigure("M551 Sheridan", 60f, WeaponStationType.PointType.FullRotation, new string[] { "XM551 HEAT", "MGM51 Shillelagh", "M2 Browning" }));

            #region Sabra
            localList.Add(CreateConfigure("Anti-tank Sabot Sabra", 60f, WeaponStationType.PointType.FullRotation, new string[] { "L44A1 APFSDT", "60mm Mortar HE", "M2 Browning" }));
            localList.Add(CreateConfigure("Anti-tank HEAT Sabra", 60f, WeaponStationType.PointType.FullRotation, new string[] { "L44A4 HEAT", "60mm Mortar HE", "M2 Browning" }));
            #endregion
            #region M48A5
            localList.Add(CreateConfigure("Anti-tank Sabot M48A5", 60f, WeaponStationType.PointType.FullRotation, new string[] { "M68A1E4 APFSDS", "M73", "M2 Browning" }));
            localList.Add(CreateConfigure("Anti-tank HEAT M48A5", 60f, WeaponStationType.PointType.FullRotation, new string[] { "M68A1E4 HEAT", "M73", "M2 Browning" }));
            #endregion
            return localList;

        }
    }
}
