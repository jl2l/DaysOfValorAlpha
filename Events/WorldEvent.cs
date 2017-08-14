using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Assets;

[System.Serializable]
public class WorldEvent : ScriptableObject
{
    public string EventName { get; set; }
    public string EventDescription { get; set; }
    public string StartTime { get; set; }
    /// <summary>
    /// The country making the diplomatic offer
    /// </summary>
    public CountryToGlobalCountry.GenericCountry EventInCountry { get; set; }
    /// <summary>
    /// The country getting the diplomatic offer
    /// </summary>
    public CountryToGlobalCountry.GenericProvince EventInProvince { get; set; }

    public string EventInCity { get; set; }

    public bool IsBlowback { get; set; }

    public EventGenerator.WorldEventType EventType { get; set; }
    public List<WorldEvent> BlowbackEvents { get; set; }

    public List<Contact> EventContacts { get; set; }
    public float EventWeight { get; set; }

    public double EventRiskIncrease { get; set; }
    public double EventRiskDecrease { get; set; }
    /// <summary>
    /// True is a gain false is a lost ie - minus
    /// </summary>
    public bool GainLost { get; set; }
    public double EventCost { get; set; }

    public TimeSpan NextPhaseEventTimeSpan { get; set; }
    public WorldEvent NextWorldEvent { get; set; }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnEventComplete() { }
}
