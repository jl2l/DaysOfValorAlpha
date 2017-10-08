using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Assets;
using System.Timers;

[System.Serializable]
public class WorldEvent : ScriptableObject
{
    public string EventName;
    public string EventDescription;
    public string StartTime;
    public DateTime EventGameDate;


    /// <summary>
    /// The country making the diplomatic offer
    /// </summary>
    public CountryToGlobalCountry.GenericCountry EventInCountry;
    /// <summary>
    /// The country getting the diplomatic offer
    /// </summary>
    public CountryToGlobalCountry.GenericProvince EventInProvince;
    /// <summary>
    /// The country getting the diplomatic offer
    /// </summary>
    public CountryToGlobalCountry.GenericCity EventInCity;

    public bool IsBlowback;

    public EventGenerator.WorldEventType EventType;
    public List<WorldEvent> BlowbackEvents;

    public List<Contact> EventContacts;
    public float EventWeight;
    /// <summary>
    /// True is a gain false is a lost ie - minus
    /// </summary>
    [Range(-100.0f, 100.0f)]
    public float GainLost;
    public long EventCost;
    public bool IsEventInFuture;
    public bool HasEnded;
    public bool IsUprisingEvent;
    public Timer EventTimer;


    public void onTimerComplete(object source, ElapsedEventArgs e)
    {
        //do things 
    }


    public TimeSpan EventTimeSpan;
    public WorldEvent NextWorldEvent;
    // Use this for initialization
    void Start()
    {
        //        minutes = Mathf.Floor(timer / 60).ToString("00");
        //seconds = (timer % 60).ToString("00);
        EventTimer = new Timer();
        EventTimer.Elapsed += new ElapsedEventHandler(onTimerComplete);
        EventTimer.Interval = 500;
        EventTimer.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnEventComplete() { }
}
