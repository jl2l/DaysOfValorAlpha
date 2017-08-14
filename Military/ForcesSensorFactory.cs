using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    public class ForcesSensorFactory
    {
        public List<Sensor> GetSensorsByName(string[] v, ForcesFactory context)
        {
            var localList = new List<Sensor>();
            foreach (var sensorKey in context.sensorFactory.FactorySensorList)
            {
                if (v.Any(n => n == sensorKey.SensorName))
                {
                    localList.Add(sensorKey);
                };
            }
            return localList;
        }

        public int MaxRangeOFSensor(List<Sensor> sensorList)
        {
            return sensorList.OrderBy(e => e.MaxRange).FirstOrDefault().MaxRange;
        }

        #region Sensors Construction
        public static List<Sensor> ConstructSeaSensors()
        {
            return new List<Sensor>() { 

            //At RWR
            //LCS
            #region Sensor SPY1
            new Sensor
            {
                CountryOfOrigin = "US",
                MaxRange = 150000,
                TotalNumSensors = 1,
                SensorName = "ADS",
                MinRange = 1000,
                SensorType = SensorType.SonarBouy,
                SensorReliablity = 0.9f,
                SensorResistance = 0.9f,
                SensorPowerRate = 1,
                SensorSpectrum = SensorSpectrum.Sound,
                IsAllWeather = true,
                IsDayNight = true,
                SensorWeight = 380,
                TechLevel = 9,
                ThreatTrack = 23,
                SensorDescription = "ADS is based on distributed passive acoustic bottom mounted arrays wirelessly linked to an analysis and reporting system to provide continuous acoustic coverage over large areas of the ocean. Its primary goal of this advanced sensor system is to detect and track modern diesel and nuclear-powered submarines. In addition, the system would provide capability for tracking surface ships and detecting sea mine laying. ADS comprises four major subsystems: analysis and reporting system; sensor; tactical interface, and; installation support."
            },
            #endregion
             #region Sensor SPY1
             new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 460000,
                TotalNumSensors = 1,
                SensorName = "AN/SPY-1",
                MinRange = 5600,
                SensorType = SensorType.SPY1,
                SensorReliablity = 0.9f,
                SensorResistance = 0.9f,
                SensorPowerRate = 50f,
                SensorSpectrum = SensorSpectrum.Radar,
                IsAllWeather = true,
                IsDayNight = true,
                SensorWeight = 380,
                TechLevel = 9,
                ThreatTrack = 23,
                SensorDescription = "AN/SPY-1 radar system is the primary air and surface radar for the AEGIS weapon system. It is a multifunction phased-array radar capable of search, automatic detection, transition to track, tracking of air and surface targets, and missile engagement support. Typically each AEGIS-equipped ship has 4 SPY-1 radar antennas continuously covering 360-degree and providing a search and tracking capability for hundreds of targets at the same time."
            },
            #endregion

             // Search radar for CV LHD,LHA
            #region Sensor SPY1
             new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 460000,
                TotalNumSensors = 1,
                SensorName = "AN/SPS-48E",
                MinRange = 1000,
                SensorType = SensorType.AirSearchRadar,
                SensorReliablity = 0.9f,
                SensorResistance = 0.9f,
                SensorPowerRate = 90f,
                SensorSpectrum = SensorSpectrum.Radar,
                IsAllWeather = true,
                IsDayNight = true,
                SensorWeight = 380,
                TechLevel = 9,
                ThreatTrack = 23,
                SensorDescription = "The AN/SPS-48E was developed as a long range surveillance 3D volume radar for large high value US Navy ships. SPS-48E can operate in an intense Countermeasures environment due to variation of working frequency. This radar is not only capable of detecting and tracking aircraft and missiles, but even it supports RAM, ESSM and Standard missiles. The AN/SPS-48E is operational onboard US Navy's aircraft carriers, LHD and LHA ships and, in the future, it will be provided to the LPD-17-class assault ships."
            },
            #endregion
            #region Sensor
             new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 150000,
                TotalNumSensors = 1,
                SensorName = "AN/SPQ-9B",
                MinRange = 1000,
                SensorType = SensorType.PulseDopplerRadar,
                SensorReliablity = 0.9f,
                SensorResistance = 0.9f,
                SensorPowerRate = 50f,
                SensorSpectrum = SensorSpectrum.Radar,
                IsAllWeather = true,
                IsDayNight = true,
                SensorWeight = 380,
                TechLevel = 9,
                ThreatTrack = 23,
                SensorDescription = "The Sperry Marine AN/SPQ-9B is a multimode X-band pulse Doppler radar designed to support anti-ship missile defense (ASMD) in surface combatants providing early warning. The AN/SPQ-9A was designed as the gun fire control radar for the Mk-86 fire control system. The improved AN/SPQ-9B radar, introduced in 2000, was designed to detect all known and projected sea skimming missiles in the littoral environment. "
            },
            #endregion
            #region Sensor
            new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 150000,
                TotalNumSensors = 1,
                SensorName = "AN/SQS-56",
                MinRange = 1000,
                SensorType = SensorType.TowSonar,
                SensorReliablity = 0.9f,
                SensorResistance = 0.9f,
                SensorPowerRate = 10f,
                SensorSpectrum = SensorSpectrum.Sound,
                IsAllWeather = false,
                IsDayNight = true,
                SensorWeight = 380,
                TechLevel = 9,
                ThreatTrack = 23,
                SensorDescription = "The AN/SQS-56 is a modern active/passive sonar which can be implemented utilizing a hull transducer or a towed active transducer for mine avoidance and torpedo defense system. It features automatic computer-aided detection and tracking, multiple simultaneous receivers for enhanced shallow water performance, a small object avoidance detection function, torpedo defense algorithms and COTS (Commercial Off The Shelf) technology."
            },
            #endregion
            #region Sensor
             new Sensor
            {
                CountryOfOrigin = "JP",
                MaxRange = 150000,
                TotalNumSensors = 1,
                SensorName = "FCS-3",
                MinRange = 1000,
                SensorType = SensorType.XBandPhaseArrayRadar,
                SensorReliablity = 0.9f,
                SensorResistance = 0.9f,
                SensorPowerRate = 50f,
                SensorSpectrum = SensorSpectrum.Radar,
                IsAllWeather = true,
                IsDayNight = true,
                SensorWeight = 380,
                TechLevel = 9,
                ThreatTrack = 23,
                SensorDescription = "The FCS-3 is an anti-aircraft active phased array fire control radar developed for the Japan Marine Self Defense Force (JMSDF) surface ships. The FCS-3 was provided to Murasame- and Takanami-class destroyers. An enhanced version of FCS-3 is expected to be integrated onto a new class of destroyers ordered by the JMSDF with the lead ship to be commissioned in 2011."
            },
            #endregion
            #region Sensor
            new Sensor
            {
                CountryOfOrigin = "GP",
                MaxRange = 150000,
                TotalNumSensors = 1,
                SensorName = "APAR Advanced Phased Array Radar",
                MinRange = 1000,
                SensorType = SensorType.XBandPhaseArrayRadar,
                SensorReliablity = 0.9f,
                SensorResistance = 0.9f,
                SensorWeight = 380,
                TechLevel = 9,
                ThreatTrack = 23,
                SensorDescription = "is a 3D, multi-functional, X-band, active phased array radar system. It provides surveillance, tracking, and missile guidance. The APAR radar system features 150 km range and will provide the same advanced capabilities to European frigates than AN / SPY - 1 provides to US cruisers and destroyers.Typically each APAR - equipped ship will carry 4 APAR antennas covering 360 - degree of possible threat."
            },
            #endregion
            #region Sensor
            #endregion
        };

        }

        public static List<Sensor> ConstructAircraftSensors()
        {
            var dbSeedSensors = new List<Sensor>();

            //AESA radar defeat RWR
            //F-35
            #region Sensor
            var APGP81 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 150000,
                TotalNumSensors = 1,
                SensorName = "AN/APG-81",
                MinRange = 1000,
                SensorType = SensorType.AESAradar,
                SensorReliablity = 0.9f,
                SensorResistance = 0.9f,
                SensorWeight = 380,
                TechLevel = 9,
                ThreatTrack = 23
            };

            dbSeedSensors.Add(APGP81);
            #endregion
            //F-16UAE
            var APG80 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 100000,
                TotalNumSensors = 1,
                SensorName = " AN/APG-80",
                MinRange = 500,
                SensorType = SensorType.AESAradar,
                SensorReliablity = 0.85f,
                SensorResistance = 0.7f,
                SensorWeight = 430,
                TechLevel = 8,
                ThreatTrack = 12
            };
            dbSeedSensors.Add(APG80);
            //F-22
            var APG77 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 150000,
                TotalNumSensors = 1,
                SensorName = "AN/APG-77",
                MinRange = 500,
                SensorType = SensorType.AESAradar,
                SensorReliablity = 0.9f,
                SensorResistance = 0.9f,
                SensorWeight = 520,
                TechLevel = 9,
                ThreatTrack = 20
            };
            dbSeedSensors.Add(APG77);

            //F-15AC Japan
            var APG63v1 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 90000,
                TotalNumSensors = 1,
                SensorName = " AN/APG-63 V1",
                MinRange = 100,
                SensorType = SensorType.MMWRDR,
                SensorReliablity = 0.75f,
                SensorResistance = 0.7f,
                SensorWeight = 530,
                TechLevel = 7,
                ThreatTrack = 14,
                SensorDescription =
                    "The APG-63 radar system combines long range acquisition and attack capabilities with automatic features to provide the instant information and computations required during air-to-air and air-to-surface engagements. It was the first airborne radar system to incorporate software programmable signal processor. That means APG-63s software can be upgraded without replacing the hardware. The APG-63 radars are installed on F-15A/B and early F-15C/D aircraft. The AN/APG-63(V)1 is an upgraded variant of baseline APG-63 radar. APG-63(V)1 upgrade improves reliability and maintainability through replacement of some radar parts with new state-of-the-art hardware. The US Air Force procurred up to 160 upgraded APG-63(V)1 radars through 2005. These radar systems were integrated on the F-15C/D aircraft."
            };
            dbSeedSensors.Add(APG63v1);
            //F-15CE SE SA SG Japan Korea Saudis
            var APG63v3 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 100000,
                TotalNumSensors = 1,
                SensorName = " AN/APG-63 V1",
                MinRange = 100,
                SensorType = SensorType.AESAradar,
                SensorReliablity = 0.85f,
                SensorResistance = 0.75f,
                SensorWeight = 501,
                TechLevel = 8,
                ThreatTrack = 14,
                SensorDescription =
                    "The APG-63 radar system combines long range acquisition and attack capabilities with automatic features to provide the instant information and computations required during air-to-air and air-to-surface engagements. It was the first airborne radar system to incorporate software programmable signal processor. That means APG-63s software can be upgraded without replacing the hardware. The APG-63 radars are installed on F-15A/B and early F-15C/D aircraft. The AN/APG-63(V)2 is a major radar upgrade for the US Air Force F-15C aircraft. This upgrade will add AESA (Active Electronically Scanned Array) capabilities to the proven APG-63 radar. AESA technology will increase F-15C's combat performance, while enhancing reliability and maintainability. The promising AESA technology is being developed for the fifth generation fighter aircraft like the F/A-22 Raptor and the F-35 Lightning II. In 2006 the APG-63(V)2 was operational with an US Air Force F-15C/D squadron based at Elmendorf Air Force Base, Alaska. The AN/APG-63(V)3 is a follow-on AESA radar that leverages the APG-63(V)2 improvements and the US Navy's APG-79 AESA radar technology. It is intended to equip F-15C/D aircraft owned by the Air National Guard. The APG-63(V)3 entered operational evaluation in late 2006 and became fully operational on the F-15C/D aircraft by the end of 2010."
            };
            dbSeedSensors.Add(APG63v3);
            //F-18A-D F-4 Greek/German AV8B USMC
            var APG65 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 85000,
                TotalNumSensors = 1,
                SensorName = " AN/APG-65",
                MinRange = 100,
                SensorType = SensorType.MMWRDR,
                SensorReliablity = 0.9f,
                SensorResistance = 0.7f,
                SensorWeight = 430,
                TechLevel = 6,
                ThreatTrack = 10,
                SensorDescription =
                    "The AN/APG-65 is an all-weather multimode radar system that enables both air-to-air and air-to-surface missions. The key to the APG-65's flexibility is its programmable digital computers. The built-in test system provides end-to-end radar preflight checkout and continuous monitoring. It also has look-down/shoot-down capability during air-to-air engagements. APG-65 is capable of tracking 10 targets simultaneously while displays 8 targets. For air-to-surface operations, the radar provides ground mapping modes and other features that make possible the use of guided precision munitions. The APG-65 is operational in the F/A-18 Hornet worldwide. APG-65s were also supplied to the Greek and German F-4 Phantom aircraft and AV-8B+ Harrier II of the USMC, Spain and Italy.",
            };
            dbSeedSensors.Add(APG65);

            //F-16A Paksitan A-4 F-4PII
            var APG66 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 70000,
                TotalNumSensors = 1,
                SensorName = " AN/APG-66",
                MinRange = 500,
                SensorType = SensorType.PulseDopplerRadar,
                SensorReliablity = 0.7f,
                SensorResistance = 0.5f,
                SensorWeight = 560,
                TechLevel = 6,
                ThreatTrack = 8,
                SensorDescription =
                   "The AN/APG-66 is a pulse-Doppler radar designed for the F-16 Fighting Falcon aircraft. It was deployed in the early models of the F-16 providing mainly air-to-air capabilities. APG-66M is a variant provided to the Hawk 200 multi-role aircraft.",

            };

            dbSeedSensors.Add(APG66);

            //F-16 CD US Greek Egypt Romina Morocco Paksitan turkey Polish Oma Indoenian Iraq Thailand Isreal
            var APG68 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 95000,
                TotalNumSensors = 1,
                SensorName = " AN/APG-68",
                MinRange = 500,
                SensorType = SensorType.PulseDopplerRadar,
                SensorReliablity = 0.85f,
                SensorResistance = 0.6f,
                SensorWeight = 430,
                TechLevel = 7,
                ThreatTrack = 12,
                SensorDescription =
                   "The AN/APG-68 is an advanced pulse-Doppler radar with increased range, more modes and better resolution compared to the APG-66 radar. "
            };

            dbSeedSensors.Add(APG68);
            //F-15E Strike ground Isreali Saudis
            var APG70 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 100000,
                TotalNumSensors = 1,
                SensorName = " AN/APG-70",
                MinRange = 100,
                SensorType = SensorType.AirGroundAttackRadar,
                SensorReliablity = 0.85f,
                SensorResistance = 0.85f,
                SensorWeight = 410,
                TechLevel = 8,
                ThreatTrack = 15,
                SensorDescription =
                   "The AN/APG-70 is a vastly-improved APG-63 radar. The APG-70 features new air-to-air and air-to-surface modes allowing ground attack capability. ",

            };

            dbSeedSensors.Add(APG70);

            //F-18D E Super Hornet
            var APG73 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 90000,
                TotalNumSensors = 1,
                SensorName = " AN/APG-73",
                MinRange = 100,
                SensorType = SensorType.MMWRDR,
                SensorReliablity = 0.92f,
                SensorResistance = 0.84f,
                SensorWeight = 430,
                TechLevel = 8,
                ThreatTrack = 14,
                SensorDescription =
                   "The AN/APG-73 is an all-weather, coherent, multimode, multiwaveform search and track sensor that uses programmable digital processors to provide the features and flexibility required for both air-to-air and air-to-surface missions. The APG-73 is a derivative of APG-65 radar with greater memory capacity, improved reliability, higher throughputs and easier maintenance.",

            };

            dbSeedSensors.Add(APG73);

            //F-18D E Super Hornet ASEA Finland Kuwait Malaysia Switzelrand
            var APG79 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 110000,
                TotalNumSensors = 1,
                SensorName = " AN/APG-79",
                MinRange = 500,
                SensorType = SensorType.AESAradar,
                SensorReliablity = 0.95f,
                SensorResistance = 0.9f,
                SensorWeight = 560,
                TechLevel = 9,
                ThreatTrack = 24,
                SensorDescription =
                   "The APG-79 provides superior air-to-air and air-to-surface capability while increasing the aircraft's situational awareness. In the air-to-air role the APG-79 provides longer range engagements and reduced pilot workload. In air-to-surface missions the APG-79 will provide enhanced precision attack through high resolution ground mapping at long standoff ranges. ",

            };

            dbSeedSensors.Add(APG79);

            //F-16V Viper most modern F-16 B-1B F-16 Tawian
            var APG83 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 100000,
                TotalNumSensors = 1,
                SensorName = " AN/APG-83",
                MinRange = 500,
                SensorType = SensorType.SABRradar,
                SensorReliablity = 0.87f,
                SensorResistance = 0.86f,
                SensorWeight = 310,
                TechLevel = 8,
                ThreatTrack = 15,
                SensorDescription =
                   "The AN/APG-83 Scalable Agile Beam Radar (SABR) is an active electronically scanned array (AESA) fire control radar being developed by Northrop Grumman using its own funding to equip light tactical aircraft such as the F-16 Fighting Falcon. The SABR multi-function array will offer the same performance and advantages of AESA radars provided to 5th generation fighters such as F-22 and F-35, but at an affordable cost. The new SABR radar will support the F-16 platform worldwide ",
            };

            dbSeedSensors.Add(APG83);

            var APN242 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 400000,
                TotalNumSensors = 1,
                SensorName = " AN/APN-242",
                MinRange = 20000,
                SensorType = SensorType.NavWeatherRadar,
                SensorReliablity = 0.5f,
                SensorResistance = 0.3f,
                SensorWeight = 93,
                TechLevel = 7,
                ThreatTrack = 10,
                SensorDescription =
                   "The radar system provides: weather detection and avoidance out to 240 nautical miles (400 km) delivering color images; fighter aircraft detection; high resolution terrain mapping and coastal navigation; and ground and airborne beacon detection. Additionally, the AN/APN-242 radar can interrogate IFF equipped aircraft out to 100 nautical miles (185 km).",
            };

            dbSeedSensors.Add(APN242);

            //Ground attack radar fo AC-130
            var APQ180 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 35000,
                TotalNumSensors = 1,
                SensorName = " AN/APQ-180",
                MinRange = 10,
                SensorType = SensorType.TADSSAR,
                SensorReliablity = 0.9f,
                SensorResistance = 0.4f,
                SensorWeight = 450,
                TechLevel = 8,
                ThreatTrack = 22,
                SensorDescription =
                   "The AN/APQ-180 is an enhanced version of the AN/APG-70 radar system. It has ground fixed target track, moving target indication and track, projectile impact point position, beacon track and a weather mode. The APG-70 antenna and analog signal processor were modified to become the APQ-180.",

            };

            dbSeedSensors.Add(APQ180);

            //Super reliable attack radar for B-2 low probity
            var APQ181 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 70000,
                TotalNumSensors = 2,
                SensorName = " AN/APQ-181",
                MinRange = 500,
                SensorType = SensorType.AESAradar,
                SensorReliablity = 0.99f,
                SensorResistance = 0.89f,
                SensorWeight = 520,
                TechLevel = 8,
                ThreatTrack = 10,
                SensorDescription =
                   "The AN/APQ-181 was developed to meet the US Air Force requirements of a low probability of intercept radar for the B-2 stealth bomber. APQ-181's physical design provides two completely redundant radar sets, each consisting of antenna, transmitter signal, signal processor, data processor and receiver/exciter. In the event of a malfunction, this design architecture will continue to provide a fully functioning radar system."

            };

            dbSeedSensors.Add(APQ181);

            //terrian guidance V-22
            var APQ186 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 300,
                TotalNumSensors = 1,
                SensorName = " AN/APQ-181",
                MinRange = 30,
                SensorType = SensorType.TCNAV,
                SensorReliablity = 0.99f,
                SensorResistance = 0.89f,
                SensorWeight = 110,
                TechLevel = 9,
                ThreatTrack = 1,
                SensorDescription =
                   "The AN/APQ-174/186 multimode radar family provides terrain following and terrain avoidance for military aircraft. It allows flight operations down to 100-ft (30 meters) at night, with adverse weather and in high threat environments. It also lowers the probability of detection by enemy forces. "

            };

            dbSeedSensors.Add(APQ186);

            //P-8 HH60 SAR radar ASW
            var APS137 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 70000,
                TotalNumSensors = 1,
                SensorName = " AN/APS-137",
                MinRange = 1000,
                SensorType = SensorType.SAR,
                SensorReliablity = 0.78f,
                SensorResistance = 0.89f,
                SensorWeight = 320,
                TechLevel = 9,
                ThreatTrack = 1,
                SensorDescription =
                   " The AN/APS-17B(V)5 is a Synthetic Aperture Radar (SAR) and Inverse Synthetic Aperture Radar (ISAR) system. APS-137 is used for anti-surface warfare and anti-submarine warfare. It performs long range surface search and target tracking, periscope detection, ship imaging and classification using ISAR. The SAR capability is used for overland surveillance, targeting and ground mapping."

            };

            dbSeedSensors.Add(APS137);


            //Egypt France Japan Mexico Singapore Tai US E-2 AWACS
            var APS145 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 450000,
                TotalNumSensors = 1,
                SensorName = " AN/APS-145",
                MinRange = 1000,
                SensorType = SensorType.AWACS,
                SensorReliablity = 0.78f,
                SensorResistance = 0.75f,
                SensorWeight = 640,
                TechLevel = 7,
                ThreatTrack = 100,
                SensorDescription =
                   " The AN/APS-145 radar detects, classifies, and tracks distant targets both surface and airborne. It features increased sensitivity to noise and clutter with sophisticated false alarm control and electronic counter-countermeasures ECCM. The APS-145 are jamming- and ECM-resistant radars. "

            };

            dbSeedSensors.Add(APS145);

            //E-2 Digital hawkeye AWACS
            var APY9 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 148000,
                TotalNumSensors = 1,
                SensorName = " AN/APY-9",
                MinRange = 500,
                SensorType = SensorType.AWACS,
                SensorReliablity = 0.88f,
                SensorResistance = 0.85f,
                SensorWeight = 640,
                TechLevel = 9,
                ThreatTrack = 168,
                SensorDescription =
                   " The new radar will fit into approximately the same space as the housing for the AN/APS-145, the current Hawkeye's radar system. The AHE radar will be more sophisticated and complex than the APS-145 with enhanced warning and battle management capabilities"

            };

            dbSeedSensors.Add(APS145);

            //E-3 AWACS
            var APY1 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 60000,
                TotalNumSensors = 1,
                SensorName = " AN/APY-1",
                MinRange = 500,
                SensorType = SensorType.AWACS,
                SensorReliablity = 0.78f,
                SensorResistance = 0.75f,
                SensorWeight = 1250,
                TechLevel = 6,
                ThreatTrack = 450,
                SensorDescription =
                   "The AN/APY-1 is a rotodome-mounted pulse Doppler radar system developed by Westinghouse for the United States Air Force E-3 Sentry Airborne Warning and Control System (AWACS). Rotating six times per minute this radar system has the ability to detect and track targets over the horizon, sea surface and/or flying at low altitude. "

            };

            dbSeedSensors.Add(APY1);

            var APY2 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 60000,
                TotalNumSensors = 1,
                SensorName = " AN/APY-2",
                MinRange = 500,
                SensorType = SensorType.AWACS,
                SensorReliablity = 0.87f,
                SensorResistance = 0.85f,
                SensorWeight = 1250,
                TechLevel = 67,
                ThreatTrack = 600,
                SensorDescription =
                   "The AN/APY-1 is a rotodome-mounted pulse Doppler radar system developed by Westinghouse for the United States Air Force E-3 Sentry Airborne Warning and Control System (AWACS). Rotating six times per minute this radar system has the ability to detect and track targets over the horizon, sea surface and/or flying at low altitude. "

            };

            dbSeedSensors.Add(APY2);

            var APY3 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 175000,
                TotalNumSensors = 1,
                SensorName = " AN/APY-3",
                MinRange = 500,
                SensorType = SensorType.SAR,
                SensorReliablity = 0.87f,
                SensorResistance = 0.85f,
                SensorWeight = 650,
                TechLevel = 7,
                ThreatTrack = 120,
                SensorDescription =
                   "Mounted beneath the forward fuselage provides detection of ground targets at 175 kilometers using its synthetic aperture radar mode. The pulse Doppler mode allows to detect and track moving targets on the ground. "

            };

            dbSeedSensors.Add(APY3);

            var APY8 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 87000,
                TotalNumSensors = 1,
                SensorName = " AN/APY-8",
                MinRange = 500,
                SensorType = SensorType.SAR,
                SensorReliablity = 0.95f,
                SensorResistance = 0.85f,
                SensorWeight = 115,
                TechLevel = 8,
                ThreatTrack = 1,
                SensorDescription =
                   "AN/APY-8 Lynx is a high-resolution, all-weather, Synthetic Aperture Radar (SAR), Ground Moving Target Indicator (GMTI) radar system. It produces photographic-like radar images with maximum resolution of 4-inch (approx. 10cm) with the SAR spotlight mode, and tracks ground moving targets using the GMTI mode. "

            };

            dbSeedSensors.Add(APY3);

            //radar warnng reiever F-16C-D A-10 F-4 Mh53 F-16 C-130 A-7 MC-130
            var ALR69 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 50000,
                TotalNumSensors = 1,
                SensorName = " AN/ALR-69",
                MinRange = 10,
                SensorType = SensorType.RFWARN,
                SensorReliablity = 0.5f,
                SensorResistance = 0.7f,
                SensorWeight = 450,
                TechLevel = 8,
                ThreatTrack = 3,
                SensorDescription =
                   "The AN/ALR-69 is an improved variant of the aircraft-mounted AN/ALR-46 radar warning receiver. ALR-69 is used on the A-10 Thunderbolt II, F-4 Phantom, MH-53, F-16 Fighting Falcon, C-130 Hercules, A-7D Corsair aircraft. This radar warner performs rapid and accurate radar enemy emissions location. ",

            };

            dbSeedSensors.Add(ALR69);

            //IR countermeaue 
            var AAR58 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 2000,
                TotalNumSensors = 1,
                SensorName = " AN/ALR-69",
                MinRange = 10,
                SensorType = SensorType.IRCM,
                SensorReliablity = 0.8f,
                SensorResistance = 0.85f,
                SensorWeight = 19,
                TechLevel = 8,
                ThreatTrack = 6,
                SensorDescription =
                   "This IR-based system detects continuously and passively incoming missiles. It is compatible with laser-based IR countermeasures. The AAR-58 warning system is reliable and is not confused by flares or multiple objects. The AAR-58 has been designed to be installed virtually on any existing aircraft. ",

            };

            dbSeedSensors.Add(AAR58);

            //F18 Av8 F-15E SG Ah64 Oh8 kiowa ChinnokEh Melrine HH60 Ah1
            var AAR57 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 2000,
                TotalNumSensors = 1,
                SensorName = " AN/ALR-57",
                MinRange = 10,
                SensorType = SensorType.CMWS,
                SensorReliablity = 0.8f,
                SensorResistance = 0.85f,
                SensorWeight = 19,
                TechLevel = 8,
                ThreatTrack = 6,
                SensorDescription =
                   "AN/AAR-57 Common Missile Warning System (CMWS) is a infrared-guided missile warning system available for fixed and rotary wing aircraft.",

            };

            dbSeedSensors.Add(AAR57);
            //F18
            var ALR2002 = new Sensor
            {
                CountryOfOrigin = "AU",

                MaxRange = 50000,
                TotalNumSensors = 1,
                SensorName = "ALR2002 ComBat",
                MinRange = 10,
                SensorType = SensorType.RFWARN,
                SensorReliablity = 0.6f,
                SensorResistance = 0.7f,
                SensorWeight = 450,
                TechLevel = 8,
                ThreatTrack = 3,
                SensorDescription =
                   "The AN/ALR-69 is an improved variant of the aircraft-mounted AN/ALR-46 radar warning receiver. ALR-69 is used on the A-10 Thunderbolt II, F-4 Phantom, MH-53, F-16 Fighting Falcon, C-130 Hercules, A-7D Corsair aircraft. This radar warner performs rapid and accurate radar enemy emissions location. ",

            };

            dbSeedSensors.Add(ALR2002);
            //a400 AIRBUS warning radar
            //BELGM FRANE GERM SPAN TURKEY UK LUXMBO
            var ALR400 = new Sensor
            {
                CountryOfOrigin = "DE",

                MaxRange = 50000,
                TotalNumSensors = 1,
                SensorName = "ALR-400",
                MinRange = 10,
                SensorType = SensorType.RFWARN,
                SensorReliablity = 0.6f,
                SensorResistance = 0.7f,
                SensorWeight = 450,
                TechLevel = 8,
                ThreatTrack = 3,
                SensorDescription =
                   "The ALR-400 is an advanced radar warning system developed specifically for the Airbus A400M tactical military transport aircraft. ALR-400 would be able to effectively detect any incoming radar-based threat. ",

            };

            dbSeedSensors.Add(ALR400);


            //Germany Tornado JSA Gripen
            //Hungry South Afric Sweden Thailand Czech Germany
            var BOW21 = new Sensor
            {
                CountryOfOrigin = "SE",

                MaxRange = 50000,
                TotalNumSensors = 1,
                SensorName = "ALR-400",
                MinRange = 10,
                SensorType = SensorType.RFWARN,
                SensorReliablity = 0.6f,
                SensorResistance = 0.7f,
                SensorWeight = 18,
                TechLevel = 8,
                ThreatTrack = 3,
                SensorDescription =
                   "is a modular radar warning receiver incorporating COTS technology designed for the JAS-39 Gripen aircraft and selected for the German Tornado strike aircraft under an upgrade program.",

            };

            dbSeedSensors.Add(BOW21);

            //UAVFLIR pod
            var ADFLIRGSP = new Sensor
            {
                CountryOfOrigin = "UAE",

                MaxRange = 1500,
                TotalNumSensors = 1,
                SensorName = "AADFLIR GSP",
                MinRange = 10,
                SensorType = SensorType.TADS,
                SensorReliablity = 0.9f,
                SensorResistance = 0.9f,
                SensorWeight = 100,
                TechLevel = 8,
                ThreatTrack = 1,
                SensorDescription =
                   "The ADCOM Systems ADFLIR GSP is a gyro-stabilized platform for a variety of sensors and payloads to meet the customer's mission requirements. The pod can be provided with laser rangefinder, satellite-based GPS (global positioning system), high resolution camera, thermal imager, video and infrared day/night cameras for aerial observation, intelligence, surveillance, target acquisition and reconnaissance ",

            };

            dbSeedSensors.Add(ADFLIRGSP);


            //UK Oman F-16
            var AARS = new Sensor
            {
                CountryOfOrigin = "UK",

                MaxRange = 1500,
                TotalNumSensors = 1,
                SensorName = "AADFLIR GSP",
                MinRange = 10,
                SensorType = SensorType.ISR,
                SensorReliablity = 0.8f,
                SensorResistance = 0.8f,
                SensorWeight = 100,
                TechLevel = 8,
                ThreatTrack = 1,
                SensorDescription =
                   "The Advanced Airborne Reconnaissance System (AARS) is an aircraft-mounted, completely digital, intelligence gathering system that provides multiple fields of view in a single package intended for reconnaissance missions. It is fully compatible with many US and NATO reconnaissance ground interpretation systems. The AARS provides near real time imagery, ground exploitation, moving target indication and intelligence dissemination capabilities. It generates visual and infrared imaging in manual or autonomous operation modes.",

            };

            dbSeedSensors.Add(AARS);

            var ACESHY = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 45000,
                TotalNumSensors = 1,
                SensorName = "ACES HY",
                MinRange = 25,
                SensorType = SensorType.IRST,
                SensorReliablity = 0.8f,
                SensorResistance = 0.8f,
                SensorWeight = 100,
                TechLevel = 8,
                ThreatTrack = 1,
                SensorDescription =
                   "This tactical sensor is intended to identify targets based on their spectral characteristics. ",

            };

            dbSeedSensors.Add(AARS);


            //F-14D radar
            var AWG9 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 200000,
                TotalNumSensors = 1,
                SensorName = " AN/AWG-9",
                MinRange = 100,
                SensorType = SensorType.PulseDopplerRadar,
                SensorReliablity = 0.82f,
                SensorResistance = 0.78f,
                SensorWeight = 320,
                TechLevel = 7,
                ThreatTrack = 24,
                SensorDescription =
                   "The AN/AWG-9 long-range, pulse-Doppler radar system allows the F-14 Tomcat to detect and track up to 24 airborne targets and selectively attack up to 6 of them in any weather at ranges of 200 kilometers. The AWG-9 radar also provides the ability to detect small, low-flying targets. The AWG-9 radar system is installed on US Navy's F-14A/B Tomcat aircraft.",

            };

            dbSeedSensors.Add(AWG9);


            //UAS ELTO Opic
            var DAS2 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 10000,
                TotalNumSensors = 1,
                SensorName = " AN/DAS-2",
                MinRange = 100,
                SensorType = SensorType.EOTS,
                SensorReliablity = 0.9f,
                SensorResistance = 0.85f,
                SensorWeight = 25,
                TechLevel = 9,
                ThreatTrack = 1,
                SensorDescription =
                   "a third-generation mid-wave sensor that has six fields of view, WAS, continuous zoom and targeting color televisions, and an eye-safe laser range finder. The multi-sensor could be expanded in the near future through the addition of high definition video formatting, laser target marking and image intensified TV.",

            };

            dbSeedSensors.Add(AWG9);

            var ZPY4 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 32000,
                TotalNumSensors = 1,
                SensorName = " AN/ZPY-4",
                MinRange = 100,
                SensorType = SensorType.MMWRDR,
                SensorReliablity = 0.8f,
                SensorResistance = 0.76f,
                SensorWeight = 19,
                TechLevel = 8,
                ThreatTrack = 8,
                SensorDescription =
                   "is a multi-mode maritime surveillance radar developed by Telephonics Corporation for manned and unmanned aircraft. A modification of the ZPY-4 radar was integrated onto the US Navy's MQ-8B Fire Scout in June 2014.",

            };

            dbSeedSensors.Add(ZPY4);


            //FRANCE M2000D France India
            var Antilope5 = new Sensor
            {
                CountryOfOrigin = "FR",

                MaxRange = 300,
                TotalNumSensors = 1,
                SensorName = " AN/APQ-181",
                MinRange = 30,
                SensorType = SensorType.TCNAV,
                SensorReliablity = 0.99f,
                SensorResistance = 0.89f,
                SensorWeight = 110,
                TechLevel = 8,
                ThreatTrack = 1,
                SensorDescription =
                   "The Antilope-5 terrain-following radar is used aboard Mirage 2000-D and Mirage 2000-N providing high resolution ground mapping capability day/night and in all-weather conditions. It enables aircraft to fly safely at low-altitudes, to use precision guided weaponry against ground targets, and provides accurate navigation. "

            };

            dbSeedSensors.Add(Antilope5);
            //T-50 Golden eagle
            var APG67v4 = new Sensor
            {
                CountryOfOrigin = "SK",

                MaxRange = 75000,
                TotalNumSensors = 1,
                SensorName = " AN/APG-67 v4",
                MinRange = 500,
                SensorType = SensorType.MMWRDR,
                SensorReliablity = 0.87f,
                SensorResistance = 0.86f,
                SensorWeight = 270,
                TechLevel = 8,
                ThreatTrack = 12,
                SensorDescription =
                   "is a multimode fire control radar designed to be installed on the T-50 LIFT, also known as the A-50, light attack variant of the T-50 Golden Eagle advanced trainer."

            };

            dbSeedSensors.Add(APG67v4);

            //Very high resolution ground SAR radar MC-12
            var ARLMCrazy = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 1000000,
                TotalNumSensors = 1,
                SensorName = " ARL-M Crazy Hawk",
                MinRange = 10000,
                SensorType = SensorType.SAR,
                SensorReliablity = 0.95f,
                SensorResistance = 0.45f,
                SensorWeight = 150,
                TechLevel = 8,
                ThreatTrack = 48,
                SensorDescription =
                   " capable of reconnaissance and surveillance missions. Its WAMTI mode scans a 10,000 square-kilometer area in less than a minute detecting ground movers/targets. The ground movers/targets' direction and location information is also displayed by the ARL-M system. The SAR spot mode provides 1.8 meter resolution imagery of a 10 square-kilometer area. "

            };

            dbSeedSensors.Add(ARLMCrazy);


            //U2 Global Hawk Long range SAR
            var ASARS2 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 1000000,
                TotalNumSensors = 1,
                SensorName = " ASARS-2",
                MinRange = 10000,
                SensorType = SensorType.SAR,
                SensorReliablity = 0.75f,
                SensorResistance = 0.35f,
                SensorWeight = 240,
                TechLevel = 7,
                ThreatTrack = 16,
                SensorDescription =
                   " It provides high resolution radar imagery from long ranges during day or night even with adverse weather. ASARS-2 detects and accurately locates fixed and moving ground targets. It gathers detailed information, formats the data, and transmits high resolution images. "

            };

            dbSeedSensors.Add(ASARS2);

            //SAR gor Global Hawk
            var EISS = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 21000,
                TotalNumSensors = 1,
                SensorName = " EISS",
                MinRange = 100,
                SensorType = SensorType.SAR,
                SensorReliablity = 0.95f,
                SensorResistance = 0.95f,
                SensorWeight = 120,
                TechLevel = 9,
                ThreatTrack = 24,
                SensorDescription =
                   "The ISS is capable of continuous operation during more than 40 hours at an altitude of over 21,000 meters at day and night and in adverse weather condition. It gathers information to provide commander's with accurate situational awareness, targeting, and bomb damage assessment. The CCD-TV and IR sensors enable intelligence users to distinguish between types of aircraft, vehicles and missiles. The SAR radar has three modes: 0.3 m resolution Spot mode, 1 meter resolution Wide Area Search mode and a 2.1 m/s (7.5 km/h or 4 kn) minimum detectable velocity Moving Target Indicator mode."

            };

            dbSeedSensors.Add(EISS);

            var ASIP = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 18000,
                TotalNumSensors = 1,
                SensorName = " ASIP",
                MinRange = 100,
                SensorType = SensorType.SIGINT,
                SensorReliablity = 0.85f,
                SensorResistance = 0.65f,
                SensorWeight = 240,
                TechLevel = 9,
                ThreatTrack = 1,
                SensorDescription =
                   "ASIP dramatically increases signals-collection capability of airborne platforms. It enables detection and identification of radar and other types of electronic devices from altitudes of up to 60,000-ft "

            };

            dbSeedSensors.Add(ASIP);

            var Aurora = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 5400,
                TotalNumSensors = 1,
                SensorName = " Aurora",
                MinRange = 100,
                SensorType = SensorType.EOTS,
                SensorReliablity = 0.65f,
                SensorResistance = 0.85f,
                SensorWeight = 35,
                TechLevel = 9,
                ThreatTrack = 1,
                SensorDescription =
                   "It combines daytime hyperspectral imaging technology, featuring high-resolution electro-optic sensors, with an airborne processing system to automatically detect and identify targets. The system is entitled to search for potential targets and download location results to ground stations in real-time. "

            };

            dbSeedSensors.Add(Aurora);

            //SU30 MKI Su33
            var Bars = new Sensor
            {
                CountryOfOrigin = "RU",

                MaxRange = 140000,
                TotalNumSensors = 1,
                SensorName = " Bars",
                MinRange = 1000,
                SensorType = SensorType.XBandPhaseArrayRadar,
                SensorReliablity = 0.75f,
                SensorResistance = 0.65f,
                SensorWeight = 140,
                TechLevel = 8,
                ThreatTrack = 15,
                SensorDescription =
                   "It combines daytime hyperspectral imaging technology, featuring high-resolution electro-optic sensors, with an airborne processing system to automatically detect and identify targets. The system is entitled to search for potential targets and download location results to ground stations in real-time. "

            };

            dbSeedSensors.Add(Bars);
            //Eurofighter
            //Iltary Germany Spain UK
            var CAPTOR = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 240000,
                TotalNumSensors = 1,
                SensorName = "CAPTOR ",
                MinRange = 100,
                SensorType = SensorType.PulseDopplerRadar,
                SensorReliablity = 0.85f,
                SensorResistance = 0.88f,
                SensorWeight = 245,
                TechLevel = 9,
                ThreatTrack = 32,
                SensorDescription =
                   " It can detect, identify, prioritize, and engage airborne threats beyond the visual range. In air-to-surface mode the CAPTOR will provide navigation as well as detection and engagement of both moving and stationary surface targets delivering precision-guided weapons. The CAPTOR features look-down/shoot-down capability, multi-target capability, countermeasures-resistance, fully software re-programmable, high reliability and availability, and low costs of ownership.",

            };

            dbSeedSensors.Add(CAPTOR);

            var CHALSC = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 240000,
                TotalNumSensors = 1,
                SensorName = "CHALS-C ",
                MinRange = 100,
                SensorType = SensorType.PESAradar,
                SensorReliablity = 0.93f,
                SensorResistance = 0.92f,
                SensorWeight = 245,
                TechLevel = 9,
                ThreatTrack = 40,
                SensorDescription =
                   "will allow cooperative search of signal emitters with other signals intelligence systems on a variety of platforms. Two or more aircraft equipped with this new device would be capable of pinpointing the location of signal emissions by measuring the arrival time and frequency shift at each platform.",

            };

            dbSeedSensors.Add(CHALSC);
            //F-16 UK US JAP SAUDI P-3 TorandoGr4
            var DB110 = new Sensor
            {
                CountryOfOrigin = "US",

                MaxRange = 80000,
                TotalNumSensors = 1,
                SensorName = "DB-110",
                MinRange = 100,
                SensorType = SensorType.FLIR,
                SensorReliablity = 0.93f,
                SensorResistance = 0.92f,
                SensorWeight = 110,
                TechLevel = 8,
                ThreatTrack = 1,
                SensorDescription =
                   "system has been designed for operations at medium and high altitude (10,000- to 80,000-ft) and low subsonic and supersonic speed (0.1 to 1.6 Mach) delivering high resolution infrared and visible bands imagery at extremely long ranges. ",

            };

            dbSeedSensors.Add(DB110);

            //IR countermeaue  Rafale Mirgae 20D
            var DDM = new Sensor
            {
                CountryOfOrigin = "FR",

                MaxRange = 1500,
                TotalNumSensors = 1,
                SensorName = " DDM",
                MinRange = 10,
                SensorType = SensorType.IRCM,
                SensorReliablity = 0.9f,
                SensorResistance = 0.95f,
                SensorWeight = 25,
                TechLevel = 9,
                ThreatTrack = 1,
                SensorDescription =
                   "The DDM is a high precision totally passive missile detector posing no electromagnetic incompatibility. It has been designed for French Mirage 2000 and Rafale fighter aircraft, but it is suitable for many aircraft types.",

            };

            dbSeedSensors.Add(DDM);
            var Spectra = new Sensor
            {
                CountryOfOrigin = "FR",

                MaxRange = 45000,
                TotalNumSensors = 1,
                SensorName = " Spectra",
                MinRange = 500,
                SensorType = SensorType.DEWS,
                SensorReliablity = 0.92f,
                SensorResistance = 0.95f,
                SensorWeight = 260,
                TechLevel = 10,
                ThreatTrack = 16,
                SensorDescription =
                   "suite provides long-range detection, identification and accurate localisation of infrared homing, radio frequency and laser threats. The system incorporates radar warning receiver, laser warning and Missile Approach Warning for threat detection plus a phased array radar jammer and a decoy dispenser for threat countering. It also includes a dedicated management unit for data fusion and reaction decision",

            };

            dbSeedSensors.Add(Spectra);

            var AISIS = new Sensor
            {
                CountryOfOrigin = "IS",

                MaxRange = 18000,
                TotalNumSensors = 1,
                SensorName = " AISIS",
                MinRange = 100,
                SensorType = SensorType.SIGINT,
                SensorReliablity = 0.95f,
                SensorResistance = 0.95f,
                SensorWeight = 240,
                TechLevel = 9,
                ThreatTrack = 1,
                SensorDescription =
                   " Elta Systems optimized the AISIS system with the ability to effectively deal with low probability of intercept transmission sources. is aircraft mounted suite designed to perform long-range, high-endurance missions thus providing tactical and strategic intelligence. The system comprises ELINT (Electronic Intelligence) and COMINT (Communications Intelligence) sensors to search, intercept, measure, locate, analyze, classify and monitor communication and radar transmissions. "

            };

            dbSeedSensors.Add(ASIP);

            var L8265 = new Sensor
            {
                CountryOfOrigin = "IS",

                MaxRange = 18000,
                TotalNumSensors = 1,
                SensorName = " L8265",
                MinRange = 100,
                SensorType = SensorType.MMJammer,
                SensorReliablity = 0.95f,
                SensorResistance = 0.95f,
                SensorWeight = 240,
                TechLevel = 9,
                ThreatTrack = 30,
                SensorDescription =
                   " can effectively detect, identify, warn and accurately locate radar threats. It is flexible enough to operate using the existing Radar Warning Receiver (RWR) antennas for a given aircraft. Alternatively, it can be fitted with mission-specific antennas. Its functionality can be expanded encompassing radar jamming capabilities. "

            };

            dbSeedSensors.Add(L8265);
            //intergrates with F-4 F-5 F16 Mirage Mig21 MIg29
            var ELM2032 = new Sensor
            {
                CountryOfOrigin = "IS",

                MaxRange = 150000,
                TotalNumSensors = 1,
                SensorName = " L8265",
                MinRange = 150,
                SensorType = SensorType.MMSARDR,
                SensorReliablity = 0.71f,
                SensorResistance = 0.65f,
                SensorWeight = 100,
                TechLevel = 9,
                ThreatTrack = 8,
                SensorDescription =
                   "multimode fire control radar intended for multi-mission fighter aircraft. It is suitable for air-to-air and air-to-surface modes. In the air-to-air mode the radar delivers long-range target detection and tracking capability. "

            };

            dbSeedSensors.Add(ELM2032);
            //very lightweight SAR
            var ELM2054 = new Sensor
            {
                CountryOfOrigin = "IS",

                MaxRange = 20000,
                TotalNumSensors = 1,
                SensorName = " ELM2054",
                MinRange = 150,
                SensorType = SensorType.SAR,
                SensorReliablity = 0.71f,
                SensorResistance = 0.65f,
                SensorWeight = 15,
                TechLevel = 9,
                ThreatTrack = 1,
                SensorDescription =
                   "has been designed to operate in all-weather conditions providing air-to-surface intelligence, surveillance, target acquisition and reconnaissance"

            };

            dbSeedSensors.Add(ELM2054);
            //Heavy SAR for UAV
            var ELM2055 = new Sensor
            {
                CountryOfOrigin = "IS",

                MaxRange = 100000,
                TotalNumSensors = 1,
                SensorName = " ELM2055",
                MinRange = 150,
                SensorType = SensorType.SAR,
                SensorReliablity = 0.81f,
                SensorResistance = 0.75f,
                SensorWeight = 100,
                TechLevel = 9,
                ThreatTrack = 1,
                SensorDescription =
                   "It utilizes the latest technologies to substantially reduce weight, volume and power consumption, concurrent with significant performance improvement."

            };

            dbSeedSensors.Add(ELM2055);

            return dbSeedSensors;
        }

        public List<Sensor> ConstructGroundSensors()
        {
            return new List<Sensor>()
                {

                    new Sensor() {
                        CountryOfOrigin = "US",
                        MaxRange = 3000,
                        MinRange = 10,
                        SensorDescription = "Allows nightfighting",
                        SensorName = "Intergrated Thermal Sight",
                        SensorReliablity = 1,
                        SensorResistance = 1,
                        SensorType = SensorType.FLIR,
                        SensorPowerRate = 0.4f,
                        SensorSpectrum = SensorSpectrum.Ir,
                        IsAllWeather = true,
                        IsDayNight = true,
                        SensorWeight = 1,
                        TechLevel = 2,
                        ThreatTrack = -1,
                        TotalNumSensors = -1,
                    },
                     new Sensor() {
                        CountryOfOrigin = "US",
                        MaxRange = 7000,
                        MinRange = 10,
                        SensorDescription = "Allows nightfighting",
                        SensorName = "Intergrated Thermal Sight Gen IV",
                        SensorReliablity = 1,
                        SensorResistance = 1,
                        SensorType = SensorType.FLIR4G,
                        SensorPowerRate = 0.7f,
                        SensorSpectrum = SensorSpectrum.Ir,
                        IsAllWeather = true,
                        IsDayNight = true,
                        SensorWeight = 1,
                        TechLevel = 4,
                        ThreatTrack = -1,
                        TotalNumSensors = -1,
                    },
                       new Sensor() {
                        CountryOfOrigin = "US",
                        MaxRange = 1000,
                        MinRange = 10,
                        SensorDescription = "Allows nightfighting",
                        SensorName = "IR Search Light",
                        SensorReliablity = 1,
                        SensorResistance = 1,
                        SensorType = SensorType.IRScope,
                        SensorPowerRate = 0.8f,
                        SensorSpectrum = SensorSpectrum.Ir,
                        IsAllWeather = false,
                        IsDayNight = true,
                        SensorWeight = 1,
                        TechLevel = 1,
                        ThreatTrack = -1,
                        TotalNumSensors = -1,
                    },
                      new Sensor() {
                        CountryOfOrigin = "US",
                        MaxRange = 3000,
                        MinRange = 10,
                        SensorDescription = "Allows nightfighting",
                        SensorName = "Nightvision Sight Gen 2",
                        SensorReliablity = 1,
                        SensorResistance = 1,
                        SensorType = SensorType.NVG2G,
                        SensorPowerRate = 0.4f,
                        SensorSpectrum = SensorSpectrum.Visible,
                        IsAllWeather = true,
                        IsDayNight = true,
                        SensorWeight = 1,
                        TechLevel = 2,
                        ThreatTrack =  -1,
                        TotalNumSensors = -1,
                    },
                     new Sensor() {
                        CountryOfOrigin = "US",
                        MaxRange = 5000,
                        MinRange = 10,
                        SensorDescription = "Allows nightfighting",
                        SensorName = "Avanced Ballistic Computer",
                        SensorReliablity = 1,
                        SensorResistance = 1,
                        SensorType = SensorType.BallisticComputer,
                        SensorWeight = 1,
                        SensorPowerRate = 0.2f,
                        SensorSpectrum = SensorSpectrum.Processor,
                        IsAllWeather = true,
                        IsDayNight = true,
                        TechLevel = 2,
                        ThreatTrack = 1,
                        TotalNumSensors = -1,
                    },
                      new Sensor() {
                        CountryOfOrigin = "US",
                        MaxRange = 3000,
                        MinRange = 10,
                        SensorDescription = "Allows nightfighting",
                        SensorName = "Ballistic Computer",
                        SensorReliablity = 1,
                        SensorResistance = 1,
                        SensorType = SensorType.BallisticComputer,
                        SensorWeight = 1,
                        SensorPowerRate = 0.2f,
                        SensorSpectrum = SensorSpectrum.Processor,
                        IsAllWeather = true,
                        IsDayNight = true,
                        TechLevel = 2,
                        ThreatTrack = 1,
                        TotalNumSensors = -1,
                    },
                       new Sensor() {
                        CountryOfOrigin = "US",
                        MaxRange = 3000,
                        MinRange = 10,
                        SensorDescription = "Allows nightfighting",
                        SensorName = "Laser Range Finder",
                        SensorReliablity = 1,
                        SensorResistance = 0.6f,
                        SensorType = SensorType.LaserRangeFinder,
                        SensorWeight = 1,
                        SensorPowerRate = 0.2f,
                        SensorSpectrum = SensorSpectrum.Ir,
                        IsAllWeather = true,
                        IsDayNight = true,
                        TechLevel = 2,
                        ThreatTrack = 1,
                        TotalNumSensors = -1,
                    },
                         new Sensor() {
                        CountryOfOrigin = "US",
                        MaxRange = 0,
                        MinRange = 0,
                        SensorDescription = "Allows long range navigation without having to check in with command",
                        SensorName = "GPS Navigation",
                        SensorReliablity = 1,
                        SensorResistance = 0.5f,
                        SensorType = SensorType.GPSNAV,
                        SensorWeight = 1,
                        SensorPowerRate = 0.2f,
                        SensorSpectrum = SensorSpectrum.Processor,
                        IsAllWeather = true,
                        IsDayNight = true,
                        TechLevel = 2,
                        ThreatTrack =  -1,
                        TotalNumSensors = -1,
                    },
                     new Sensor() {
                        CountryOfOrigin = "US",
                        MaxRange = 0,
                        MinRange = 0,
                        SensorDescription = "Allows protection of crew during chemical or nuclear battlefield",
                        SensorName = "CBRN Protection",
                        SensorReliablity = 1,
                        SensorResistance = 1,
                        SensorType = SensorType.ChemicalDector,
                        SensorWeight = 1,
                        SensorPowerRate = 0.2f,
                        SensorSpectrum = SensorSpectrum.Chemical,
                        IsAllWeather = true,
                        IsDayNight = true,
                        TechLevel = 2,
                        ThreatTrack =  -1,
                        TotalNumSensors = 1,
                    },
                      new Sensor() {
                        CountryOfOrigin = "US",
                        MaxRange = 1000,
                        MinRange = 0,
                        SensorDescription = "Allows protection of crew during chemical or nuclear battlefield",
                        SensorName = "Commander Thermal Viewer",
                        SensorReliablity = 1,
                        SensorResistance = 1,
                        SensorType = SensorType.FLIR,
                        SensorWeight = 1,
                        SensorPowerRate = 0.2f,
                        SensorSpectrum = SensorSpectrum.Ir,
                        IsAllWeather = true,
                        IsDayNight = true,
                        TechLevel = 2,
                        ThreatTrack = 1,
                        TotalNumSensors = 1,
                    },
            };
        }

        #endregion

        public List<Sensor> FactorySensorList;

        public List<Sensor> InitalizeSensorList()
        {

            var airSensors = ConstructAircraftSensors();
            var seaSensors = ConstructSeaSensors();
            var groundSensors = ConstructGroundSensors();

            FactorySensorList = new List<Sensor>();
            FactorySensorList.AddRange(airSensors);
            FactorySensorList.AddRange(seaSensors);
            FactorySensorList.AddRange(groundSensors);
            return FactorySensorList;
        }
    }
}
