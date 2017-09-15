using UnityEngine;
using System.Collections;
using Assets;
using System;

[Serializable]
public class Sensor : ScriptableObject
{
    [Header("Sensor Settings")]

    /// <summary>
    /// Display name
    /// </summary>
    public string SensorName;
    public SensorType SensorType;
    public string CountryOfOrigin;
    /// <summary>
    /// How many threats can it track at once 
    /// </summary> -1 means its 
    public int ThreatTrack;
    /// <summary>
    /// // important determines distance of dections radius 1m if -1 is unlimited
    /// </summary>
    public int MaxRange;
    /// <summary>
    /// // total number of times it can use this detection -1 is infintie
    /// </summary>
    public int TotalNumSensors;

    /// <summary>
    /// // min dection radius inside of this it cant see anything
    /// </summary>
    public int MinRange;
    /// <summary>
    /// // the time it will take to detect something inside of the radius once it enters
    /// </summary>
    [Tooltip("the delay it will take to detect something inside of the radius once it enters")]
    [Range(0.0f, 100.0f)]
    public float SensorReliablity;
    /// <summary>
    /// // the percentage that it will not be detected when it is sensed by another sensor
    /// </summary>
    [Tooltip("The percentage that it will not be detected when it is sensed by another sensor, if a countermeasures is the higher of weapon resistance will defeat the weapon")]
    [Range(0.0f, 100.0f)]
    public float SensorResistance;
    /// <summary>
    ///  // the total weight of the system this effects cost/fuel / deployment points
    /// </summary>
    [Tooltip("The cost to have the system onboard, huge sensors can't be placed on small vehicles")]

    public int SensorWeight;
    /// <summary>
    /// Sensor power draw to use effectively
    /// </summary>
    [Tooltip("The amount of power required to use the sensor if its not enough the sensor will deactive")]

    public float SensorPowerRate;


    /// <summary>
    /// The base tech level of the sensor 1-5 being latest tech
    /// </summary>
    public int TechLevel;
    /// <summary>
    /// The sensor works without any impact on the weather in the game world 1 = percentage of degrading
    /// </summary>
    public bool IsAllWeather;
    /// <summary>
    /// The sensor works the same any time of day during the game combat otherwise 1 = percentage of degrading
    /// </summary>
    public bool IsDayNight;
    public bool IsElectronicWarfare;
    public bool IsJammingDevice;
    /// <summary>
    /// The spectrum the sensor sees in effects jamming an combat
    /// </summary>
    public SensorSpectrum SensorSpectrum;
    public string SensorDescription;

    [Header("Gameplay Settings")]
    public bool IsActive;
    public bool IsJammed;
}
