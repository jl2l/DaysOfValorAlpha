using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UIWidgets;
using System.Collections.Generic;
using WorldMapStrategyKit;

public class MilitaryShipInfoPanel : MonoBehaviour
{
    private Helper helper;
    public RawImage ShipBackground;
    public Text ShipClassName;
    public Text ShipName;
    public Text ShipType;
    public GameObject ShipSensorList;
    public GameObject ShipWeaponList;
    public GameObject ShipArmorList;
    public Text ShipStatus;
    public Progressbar ShipHp;
    public Progressbar ShipFuel;
    public GameObject ShipWeaponItemTemplate;
    public GameObject ShipSensorItemTemplate;
    public GameObject ShipArmorItemTemplate;
    public DoV_Vehicle Ship;
    public List<Sensor> ShipSensors;
    public List<WeaponConfig> ShipWeaponsList;
    public List<Armor> ShipArmor;
    // Use this for initialization
    public GameObjectAnimator ShipOnMap;
    public GameObject ShipModel;

    void Start()
    {
        helper = new Helper();

        if (Ship != null)
        {
            ShipSensors = Ship.VehicleSensors;
            ShipWeaponsList = Ship.VehicleWeapons;
            ShipArmor = Ship.VehicleArmor;
            ShipModel = Ship.LowPolyModel;

        }
        ShipWeaponsList.ForEach(config =>
        {
            var newWeaponTemplate = Instantiate(ShipWeaponItemTemplate);
            var name = newWeaponTemplate.GetComponentInChildren<Text>();
            var ammo = newWeaponTemplate.GetComponentInChildren<Slider>();

            var totalAmmoleft = config.WeaponsStations.SumFloat(w => w.ConfigWeapons.SumFloat(g => g.WeaponsRemaining));
            var totalMaxAmmoLeft = config.WeaponsStations.SumFloat(w => w.ConfigWeapons.SumFloat(g => g.MaxNumWeaponsRemaining));

            var percent = (totalAmmoleft / totalMaxAmmoLeft * 100);
            name.text = string.Format("{0} - {1}%", config.Name, (int)percent);
            ammo.maxValue = totalMaxAmmoLeft;
            ammo.value = totalAmmoleft;
            name.color = helper.ColorCell(percent);
            newWeaponTemplate.transform.SetParent(ShipWeaponList.transform);

        });

        var panel1 = new GameObject("panel1");
        var panel2 = new GameObject("panel2");
        int index = 0;
        ShipSensors.ForEach(sensor =>
        {
            var newSensor = Instantiate(ShipSensorItemTemplate);
            var newSensorName = newSensor.GetComponentsInChildren<Text>().ToObservableList<Text>();
            newSensorName[0].text = sensor.SensorName;
            newSensorName[1].text = string.Format("{0} <color=lime>({1} m)</color> <color=orange>{2}</color> <color=orange>{3}</color> <color=orange>{4}</color> <color=orange>{5}</color> <color=orange>{6}</color>",
                sensor.SensorType.ToDescription(),
                sensor.MaxRange, sensor.IsAllWeather ? "All Weather " : string.Empty,
                sensor.IsDayNight ? "Day Night " : string.Empty,
                sensor.IsElectronicWarfare ? "Electronic Warfare " : string.Empty,
                sensor.IsJammingDevice ? "All Purpose Jamming " : string.Empty
                );

            if (index > 4)
            {
                newSensor.transform.SetParent(panel2.transform);
            }
            else
            {
                newSensor.transform.SetParent(panel1.transform);
            }

            index++;
        });
        panel1.transform.SetParent(ShipSensorList.transform);
        panel2.transform.SetParent(ShipSensorList.transform);

        ShipArmor.ForEach(armor =>
        {
            var newArmor = Instantiate(ShipArmorItemTemplate);
            var textArmor = newArmor.GetComponentsInChildren<Text>();
            var ArmorHP = newArmor.GetComponentInChildren<Slider>();
            textArmor[0].text = armor.ArmorName;
            textArmor[1].text = armor.ArmorType.ToDescription();
            textArmor[2].text = armor.RHARating.ToString();
            ArmorHP.maxValue = armor.RHARating;
            ArmorHP.value = armor.CurrentArmorHP;
            newArmor.transform.SetParent(ShipArmorList.transform);


        });
    }

    public void UpdateSensorsList()
    {

    }
    public void UpdateArmorList()
    {

    }
    public void UpdateWeaponsList()
    {

    }

    public void SetSensorPanel()
    {
        ShipSensorList.SetActive(true);
        ShipWeaponList.SetActive(false);
        ShipArmorList.SetActive(false);
    }
    public void SetWeaponsPanel()
    {
        ShipSensorList.SetActive(false);
        ShipWeaponList.SetActive(true);
        ShipArmorList.SetActive(false);
    }
    public void SetArmorPanel()
    {
        ShipSensorList.SetActive(false);
        ShipWeaponList.SetActive(false);
        ShipArmorList.SetActive(true);
    }
    public void UpdatedShipStatus()
    {

    }
    public void DrainShipFuel()
    {

    }
    public void ShipUpdateNewDamage()
    {

    }
    public void ShipReturnToPort() { }
    public void ShipMoveToTarget() { }
    public void ShipAttackTarget() { }
    public void ShipZoomTo() { }
    // Update is called once per frame
    public void Update()
    {
        DrainShipFuel();
    }
}
