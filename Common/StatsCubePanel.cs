using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class StatsCubePanel : MonoBehaviour
{

    public DoV_Vehicle Vehicle;

    public UIPolygon Panel;

    //percantage of 100%

    public float RCS;
    public float ECM;
    public float Range;
    public float ThermalRating;
    public float Instability;
    public float FuelRange;
    public float TargetTime;

    // Use this for initialization
    void Start()
    {
        SetStats();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetStats()
    {
        if (Vehicle != null)
        {
            Panel.VerticesDistances[0] = RCS = Vehicle.Rcs;
            Panel.VerticesDistances[1] = ECM = Vehicle.Ecm;
            Panel.VerticesDistances[2] = Range = Vehicle.FuelRange;
            Panel.VerticesDistances[3] = Instability = Vehicle.Instability;
            Panel.VerticesDistances[4] = TargetTime = Vehicle.TargetTime;
            Panel.VerticesDistances[5] = ThermalRating = Vehicle.ThermalRating;


        }
    }
}
