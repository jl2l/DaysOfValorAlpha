using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;
using System.Linq;

public class StatsCubePanel : MonoBehaviour
{

    public DoV_Vehicle Vehicle;

    public UIPolygon BestOfClassPanel;
    public UIPolygon Panel;

    //percantage of 100%

    public float RCS;
    public float ECM;
    public float ThermalRating;
    public float Instability;
    public float FuelRange;
    public float TargetTime;

    // Use this for initialization
    void Start()
    {
        SetStats(Vehicle);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GetBestOfClass()
    {
        var garageManager = FindObjectOfType<GarageManager>();

        if (garageManager != null && Vehicle != null)
        {

            var currentVehicleType = Vehicle.BaseGroundType;
            var currentVehicleSubclass = Vehicle.GroundVehicleType;
            BestOfClassPanel.VerticesDistances[0] = garageManager.GarageCountryGovernment.Military.CountryMilitaryInventory.OrderBy(e => e.Vehicle.Rcs).FirstOrDefault(v => v.Vehicle.BaseGroundType == currentVehicleType && v.Vehicle.GroundVehicleType == currentVehicleSubclass).Vehicle.Rcs;
            BestOfClassPanel.VerticesDistances[1] = garageManager.GarageCountryGovernment.Military.CountryMilitaryInventory.OrderBy(e => e.Vehicle.Ecm).FirstOrDefault(v => v.Vehicle.BaseGroundType == currentVehicleType && v.Vehicle.GroundVehicleType == currentVehicleSubclass).Vehicle.Ecm;
            BestOfClassPanel.VerticesDistances[2] = garageManager.GarageCountryGovernment.Military.CountryMilitaryInventory.OrderBy(e => e.Vehicle.TargetTime).FirstOrDefault(v => v.Vehicle.BaseGroundType == currentVehicleType && v.Vehicle.GroundVehicleType == currentVehicleSubclass).Vehicle.TargetTime;
            BestOfClassPanel.VerticesDistances[3] = garageManager.GarageCountryGovernment.Military.CountryMilitaryInventory.OrderBy(e => e.Vehicle.FuelRange).FirstOrDefault(v => v.Vehicle.BaseGroundType == currentVehicleType && v.Vehicle.GroundVehicleType == currentVehicleSubclass).Vehicle.FuelRange;
            BestOfClassPanel.VerticesDistances[4] = garageManager.GarageCountryGovernment.Military.CountryMilitaryInventory.OrderBy(e => e.Vehicle.Instability).FirstOrDefault(v => v.Vehicle.BaseGroundType == currentVehicleType && v.Vehicle.GroundVehicleType == currentVehicleSubclass).Vehicle.Instability;
            BestOfClassPanel.VerticesDistances[5] = garageManager.GarageCountryGovernment.Military.CountryMilitaryInventory.OrderBy(e => e.Vehicle.ThermalRating).FirstOrDefault(v => v.Vehicle.BaseGroundType == currentVehicleType && v.Vehicle.GroundVehicleType == currentVehicleSubclass).Vehicle.ThermalRating;
            BestOfClassPanel.SetAllDirty();
        }
    }

    /// <summary>
    /// order in 
    /// 0 RCS
    /// 1 ECM
    /// 2 TARGET
    /// 3 RANGE
    /// 
    /// </summary>
    public void SetStats(DoV_Vehicle Vehicle)
    {
        if (Vehicle != null)
        {
            GetBestOfClass();
            Panel.VerticesDistances[0] = RCS = Vehicle.Rcs;
            Panel.VerticesDistances[1] = ECM = Vehicle.Ecm;
            Panel.VerticesDistances[2] = TargetTime = Vehicle.TargetTime;
            Panel.VerticesDistances[3] = FuelRange = Vehicle.FuelRange;
            Panel.VerticesDistances[4] = Instability = Vehicle.Instability;
            Panel.VerticesDistances[5] = ThermalRating = Vehicle.ThermalRating;
            Panel.SetAllDirty();

        }
    }
}
