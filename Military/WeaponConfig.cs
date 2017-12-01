using UnityEngine;
using System.Collections;
using Assets;
using System.Collections.Generic;
using System;

[Serializable]
public class WeaponConfig : ScriptableObject

{
    [SerializeField]
    public string Name;

    /// <summary>
    /// Used for aircraft to set the limit of the bombs they can carry in customizing the weapons payloads.
    /// </summary>
    public float MaxWeaponsPayload;

    /// <summary>
    /// The list of weapon stations on a vehicle, if its a tank it will have one, but some can have more then one 
    /// </summary>
    public List<WeaponStationType> WeaponsStations;

    public int CountryIndex;
    public string CountryName;
}