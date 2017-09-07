using UnityEngine;
using System.Collections;
using System.Timers;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using Assets;

public class IntelOperation : MonoBehaviour
{

    //FADE IN OPERATION NAME ON MOUSE OVER FROM BLACK TO WHITE
    #region UI
    public Text OperationName;
    public Text TopSecrectLevel;
    #endregion


    #region Data



    /// <summary>
    /// The country making the diplomatic offer
    /// </summary>
    public CountryToGlobalCountry.GenericCountry TargetCountry;

    /// <summary>
    /// The country making the diplomatic offer
    /// </summary>
    public CountryToGlobalCountry.GenericCountry IntelCountry;

    public bool IsInformationSharing;
    public Timer OperationTimer;
    public float OperationalStartTime;
    public bool LimitedOperation;
    public int OperationDays;
    public int OperationCost;
    public float OperationalRisk;
    public int OperationAgents;
    public int OperationBudget;
    public float OperationBudgetFundingRate;


    public List<Contact> OperationContacts;

    #endregion
    public void onTimerComplete(object source, ElapsedEventArgs e)
    {
        //do things 
    }

    

    public void OnMouseOver()
    {
        gameObject.GetComponent<Animation>().Play("FadeInOperationName");
    }
    


    public TimeSpan EventTimeSpan;
    public WorldEvent NextWorldEvent;
    

    // Use this for initialization
    void Start()
    {
        //        minutes = Mathf.Floor(timer / 60).ToString("00");
        //seconds = (timer % 60).ToString("00);
        OperationTimer = new Timer();
        OperationTimer.Elapsed += new ElapsedEventHandler(onTimerComplete);
        OperationTimer.Interval = 500;
        OperationTimer.Start();
     
    }


    // Update is called once per frame
    void Update()
    {

    }
}
