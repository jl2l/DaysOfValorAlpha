using UnityEngine;
using System.Collections;
using Assets;
using System.Collections.Generic;

[System.Serializable]
public class ResearchItem : ScriptableObject
{
    /// <summary>
    ///  Neodymium based magnets, green phosphors, lasers, fluorescent lamps, magnetostrictive alloys such as terfenol-D, naval sonar systems, stabilizer of fuel cells
    ///  , magnetostrictive alloys such as terfenol-D, hard disk drives Chemical oxidizing agent, polishing powder, yellow colors in glass and ceramics, catalyst for self-cleaning ovens, fluid catalytic cracking catalyst for oil refineries, ferrocerium flints for lighters
    ///  High refractive index and alkali-resistant glass, flint, hydrogen storage, battery-electrodes, camera lenses, fluid catalytic cracking catalyst for oil refineries
    ///  Infrared lasers, chemical reducing agent, decoy flares, stainless steel, stress gauges, nuclear medicine, monitoring earthquakes
    ///  Infrared lasers, vanadium steel, fiber-optic technology wavelength calibration standards for optical spectrophotometers, magnets
    ///  Nuclear batteries, luminous paint Portable X-ray machines, metal-halide lamps, lasers Positron emission tomography – PET scan detectors, high-refractive-index glass, lutetium tantalate hosts for phosphors, catalyst used in refineries, LED light bulb
    ///  Rare-earth magnets, lasers, core material for carbon arc lighting, colorant in glasses and enamels, additive in didymium glass used in welding goggles,[4] ferrocerium firesteel (flint) products.
    ///  aluminium-scandium alloys for aerospace components, additive in metal-halide lamps and mercury-vapor lamps,[4] radioactive tracing agent in oil refineries
    ///  Rare-earth magnets, lasers, neutron capture, masers, control rods of nuclear reactors
    ///  are-earth magnets, lasers, violet colors in glass and ceramics, didymium glass, ceramic capacitors, electric motors of electric automobiles
    ///  High refractive index glass or garnets, lasers, X-ray tubes, computer memories, neutron capture, MRI contrast agent, NMR relaxation agent, magnetostrictive alloys such as Galfenol, steel additive
    /// </summary>
    public string ResearchName;
    public string ResearchDescription;
    public enum ResearchTech
    {
        StartingTech,
        AcquiredTech,
        RareTech,
        DangerTech,
        Repeatable
    }


    public Texture2D ResearchIcon;
    public ResearchManager.ResearchSector ResearchSector;

    public ResearchAgent AssignedResearchAgent;

    public List<DoV_Vehicle> UnlockVehicles;
    public List<Weapon> UnlockWeapons;
    public List<Sensor> UnlockSensors;
    public ResearchTech Tier;
    public WorldEvent ResearchWorldEvent;
    public IntelEvent ResearchTriggersIntelEvent;
    public bool IsRootNode;
    public bool IsResearchKnownToPlayer;
    //research manager calcates this and determines what the total number of days is so it research capacity - (goal cost / Research Points Per day)
    public int DaysToResearch;
    public List<ResearchItem> RequiredTech;
    public float ResearchPoints;

    public ResearchItem ParentResearch;
    public List<ResearchItem> ChildrenResearch;
}