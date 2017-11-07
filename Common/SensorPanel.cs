using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class SensorPanel : MonoBehaviour
{

    public DoV_Vehicle Vehicle;

    public Text MinSensorRange;
    public UICircle MinSensorCircle;
    public Text SensorSpectrums;
    public Text MaxSensorRange;
    public UICircle MaxSensorCircle;
    public Text SensorTrackTime;
    public Text SensorName;

    // Use this for initialization
    void Start()
    {
        SetSensorPanel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public string ToMeter(string value)
    {
        return string.Format("{0}m", value);
    }

    public void SetSensorPanel()
    {
        if (Vehicle != null)
        {
            MinSensorRange.text = ToMeter(Vehicle.VehicleSensors.Min(e => e.MinRange).ToString());
            MaxSensorRange.text = ToMeter(Vehicle.VehicleSensors.Max(e => e.MaxRange).ToString());
            SensorName.text = Vehicle.VehicleSensors.Sum(e => e.ThreatTrack).ToString();
            SensorTrackTime.text = string.Format("{0}s", Vehicle.VehicleSensors.Average(e => e.SensorReliablity));
            SensorSpectrums.text = string.Empty;
            Vehicle.VehicleSensors.ForEach(e => { SensorSpectrums.text += string.Format("{0}|", e.SensorSpectrum.ToDescription()); });
        }
    }
}
