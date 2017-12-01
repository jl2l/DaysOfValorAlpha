using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class SensorPanel : MonoBehaviour
{

    public DoV_Vehicle Vehicle;
    public Text UnitCallsign;
    public Text LowAmmoWarning;
    public Text LowFuelWarning;
    public Text NoAmmoWarning;
    public Text NoFuelWarning;

    public Text MinSensorRange;
    public UICircle MinSensorCircle;
    public Text SensorSpectrums;
    public Text MaxSensorRange;
    public UICircle MaxSensorCircle;
    public Text SensorTrackTime;
    public Text SensorName;

    public UIPolygon FacingDirectionMarker;
    public UIPolygon LookingAtDirectionMarker;
    // Use this for initialization
    void Start()
    {
        SetSensorPanel();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSensorOrientation();
    }


    public void UpdateSensorOrientation()
    {
        var vehicle = FindObjectOfType<GarageManager>().SelectedDoV_CombatVehicle;
        if (vehicle == null)
        {
            return;
        }

        Vehicle = vehicle.Vehicle;
        UnitCallsign.text = Vehicle.DisplayName;

        LowAmmoWarning.gameObject.SetActive(false);
        LowFuelWarning.gameObject.SetActive(false);
        NoAmmoWarning.gameObject.SetActive(false);
        NoFuelWarning.gameObject.SetActive(false);

        float rotAmount = Mathf.Clamp(vehicle.Turret.transform.localEulerAngles.y, 0, 360f);
        float rotAmount2 = Mathf.Clamp(vehicle.Frame.transform.localEulerAngles.y, 0, 360f);

        FindObjectOfType<GarageManager>().DebugText.text = rotAmount.ToString();

        if (vehicle.VehicleArmorState == ArmorState.ActiveDefenseDectecting)
        {
            MinSensorCircle.color = Colors.YellowGreen;
        }
        if (vehicle.VehicleArmorState == ArmorState.ActiveDefenseOnline)
        {
            MinSensorCircle.color = Colors.LimeGreen;
        }
        if (vehicle.VehicleArmorState == ArmorState.ActiveDefenseHit)
        {
            MinSensorCircle.color = Colors.OrangePeel;
        }
        if (vehicle.VehicleArmorState == ArmorState.ActiveDefenseMiss)
        {
            MinSensorCircle.color = Colors.LightYellow;
        }

        if (vehicle.VehicleArmorState == ArmorState.ActiveDefenseOffline)
        {
            MinSensorCircle.color = Colors.GraniteGray;
        }

        if (vehicle.VehicleArmorState == ArmorState.Damaged)
        {
            MinSensorCircle.color = Colors.OrangeRed;
        }

        if (vehicle.VehicleArmorState == ArmorState.Destoryed)
        {
            MinSensorCircle.color = Colors.Black;
        }


        if (vehicle.VehicleSenorState == SensorState.IsConfused)
        {
            MaxSensorCircle.color = Colors.GraniteGray;
        }
        if (vehicle.VehicleSenorState == SensorState.IsTracking)
        {
            MaxSensorCircle.color = Colors.LimeGreen;
        }
        if (vehicle.VehicleSenorState == SensorState.IsJammed)
        {
            MaxSensorCircle.color = Colors.RedCrayola;
        }
        if (vehicle.VehicleSenorState == SensorState.IsTargeted)
        {
            MaxSensorCircle.color = Colors.YellowGreen;
        }

        if (vehicle.VehicleWeaponState == WeaponState.IsTracking)
        {
            LookingAtDirectionMarker.color = Colors.LimeGreen;
        }
        if (vehicle.VehicleWeaponState == WeaponState.IsLockedOn)
        {
            LookingAtDirectionMarker.color = Colors.OrangePantone;
        }
        if (vehicle.VehicleWeaponState == WeaponState.IsFiring)
        {
            LookingAtDirectionMarker.color = Colors.RedCrayola;
        }

        if (vehicle.VehicleWeaponState == WeaponState.IsReloading)
        {
            LookingAtDirectionMarker.color = Colors.Bluebonnet;
        }

        if (vehicle.VehicleWeaponState == WeaponState.IsOutOfAmmo)
        {
            LookingAtDirectionMarker.color = Colors.GraniteGray;
        }

        float curRot = LookingAtDirectionMarker.rectTransform.localRotation.eulerAngles.z;
        float curRot2 = FacingDirectionMarker.rectTransform.localRotation.eulerAngles.z;
        FacingDirectionMarker.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, vehicle.Frame.transform.localEulerAngles.y));
        LookingAtDirectionMarker.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, vehicle.Turret.transform.localEulerAngles.y));
        LookingAtDirectionMarker.SetAllDirty();
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
            Vehicle.VehicleSensors.ForEach(e => { SensorSpectrums.text += string.Format("{0} ", e.SensorSpectrum.ToDescription()); });
        }
    }
}
