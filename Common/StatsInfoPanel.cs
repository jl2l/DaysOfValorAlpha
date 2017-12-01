using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsInfoPanel : MonoBehaviour
{


    public DoV_Vehicle Vehicle;
    public Text ModelName;
    public Text BasicStats;
    public RawImage MapIcon;
    public Text Description;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public string BuildBasicStats()
    {
        return string.Format("LENGTH <color=red> {0}m </color> HEIGHT <color=red> {1}m </color> WIDTH <color=red> {2}m </color> \n WEIGHT LOADED  <color=red> {4}t </color>  WEIGHT EMPTY <color=red>  {3}t </color> CREW <color=red> {5} ({6}) </color>  YEAR <color=red>  {7} </color> ", Vehicle.Length.ToString(), Vehicle.Height, Vehicle.Width, Vehicle.LoadedWeight, Vehicle.EmptyWeight, Vehicle.CrewNumber, Vehicle.OfficerNumber, Vehicle.Year);
    }

    public void SetStats()
    {
        if (Vehicle != null)
        {
            ModelName.text = Vehicle.Name;
            MapIcon.texture = Vehicle.MapIcon;
            Description.text = Vehicle.Description;
            BasicStats.text = BuildBasicStats();
        }
    }
}
