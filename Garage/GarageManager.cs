using UnityEngine;
using System.Collections;
using Assets;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;

public class GarageManager : MonoBehaviour
{

    public enum GarageMode
    {
        Land,
        Air,
        Sea,
        Other

    }

    public GarageMode TypeOfSelectedGarage;

    public GroundVehicleType TypeOfGarageGround;
    public SeaObjectType TypeOfGarageSea;
    public AircraftTypeStr TypeOfGarageAir;
    public CountryManager GarageCountryManager;
    public CountryGovernment GarageCountryGovernment;

    public BaseAirType SelectedAirType;
    public BaseGroundType SelectedGroundType;
    public BaseSeaType SelectedSeaType;
    public Text DebugText;

    public Text SelectedUnitName;
    public Text SelectedDisplayName;
    public Text SelectedBasicStats;
    public Text Description;
    public Text DisplayGarageName;
    public Text SelectedUnitWeapons;
    public Text SelectedUnitSensors;
    public RawImage SelectedType;
    public RawImage SelectedCountryFlag;
    public RawImage SelectedVehicleMapNATOIcon;

    //the transform position of the vehicle
    public GameObject VehicleCenterMarker;


    public GameObject VehicleListOfUnits;
    //the image of the vehicle and the flag
    public GameObject VehicleButtonTemplate;


    public GameObject VehicleArmorTemplate;
    public GameObject VehicleSensorTemplate;
    public GameObject VehicleGunTemplate;

    public GameObject VehicleListOfClasses;
    public GameObject VehicleButtonClickTemplate;

    public GameObject VehicleListPanel;


    public List<GameObject> VehicleClasses;
    public List<GarageClickAirUnit> Vehicles;
    public List<DoV_Vehicle> VehiclesToLoad;

    public void SetButtons()
    {

    }

    public void OpenMap()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenVehicleOnClick()
    {

    }
    public void OpenVehicleHover()
    {

    }
    public IEnumerator OpenVehicleType(BaseGroundType drawType)
    {
        VehicleButtonTemplate.SetActive(true);
        VehicleListOfUnits.GetComponentsInChildren<GarageClickAirUnit>().ToList().ForEach(g =>

        Destroy(g.gameObject)

        );

        var selectedUnits = VehiclesToLoad.Where(unit => unit.BaseGroundType == drawType).ToList();
        selectedUnits.ForEach(vehicle =>
        {
            var newVehicle = Instantiate(VehicleButtonTemplate);
            var configClick = newVehicle.GetComponent<GarageClickAirUnit>();
            newVehicle.GetComponentInChildren<Text>().text = vehicle.name;
            var img = newVehicle.GetComponentsInChildren<RawImage>();
            configClick.GarageIcon.texture = vehicle.ClassIcon;
            configClick.GarageFlag.texture = vehicle.CountryOfOriginFlag;
            configClick.GarageUnitName.text = vehicle.DisplayName;
            configClick.ButtonBackgroundImage.texture = vehicle.MenuIcon;
            configClick.OnClickSelectThisVehicle = vehicle;
            newVehicle.gameObject.transform.SetParent(VehicleListOfUnits.transform);
        });
        VehicleButtonTemplate.SetActive(false);

        yield return new WaitForEndOfFrame();
    }
    public void OpenLandGarage()
    {
        TypeOfSelectedGarage = GarageMode.Land;
        SelectedAirType = BaseAirType.None;
        SelectedSeaType = BaseSeaType.None;

        var landMilitary = GarageCountryGovernment.Military.CountryMilitaryInventory.Where(vehicle => vehicle.Vehicle.BaseGroundType == BaseGroundType.APC
        || vehicle.Vehicle.BaseGroundType == BaseGroundType.Artillery
        || vehicle.Vehicle.BaseGroundType == BaseGroundType.Log
        || vehicle.Vehicle.BaseGroundType == BaseGroundType.Misc
        || vehicle.Vehicle.BaseGroundType == BaseGroundType.TANK
        || vehicle.Vehicle.BaseGroundType == BaseGroundType.X4).ToList();

        VehiclesToLoad = landMilitary.Select(e => e.Vehicle).ToList();

        var buttons = landMilitary.Select(item => item.Vehicle.BaseGroundType).Distinct().ToList();

        buttons.ForEach(button =>
        {
            var newButton = Instantiate(VehicleButtonClickTemplate);
            var assignButtonType = newButton.GetComponent<GarageVehicleTypeClick>();
            assignButtonType.SelectedGroundType = button;

            newButton.gameObject.GetComponentInChildren<Text>().text = button.ToDescription();
            newButton.transform.SetParent(VehicleListOfClasses.transform);
        });
        VehicleButtonClickTemplate.SetActive(false);
    }
    public void Start()
    {
        OpenLandGarage();
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void SetSelectedUnitUI(DoV_Vehicle DoV)
    {
        SelectedUnitName.text = DoV.Name;
        SelectedDisplayName.text = DoV.DisplayName;
        SelectedType.texture = DoV.ClassIcon;
        SelectedCountryFlag.texture = DoV.CountryOfOriginFlag;
        SelectedVehicleMapNATOIcon.texture = DoV.MapIcon;
        var statsPanel = FindObjectOfType<StatsInfoPanel>();
        var statsCube = FindObjectOfType<StatsCubePanel>();
        var sensorPanel = FindObjectOfType<SensorPanel>();

        sensorPanel.Vehicle = statsCube.Vehicle = statsPanel.Vehicle = DoV;

        statsCube.SetStats();
        statsPanel.SetStats();
        sensorPanel.SetSensorPanel();
        VehicleListPanel.SetActive(false);
    }


    public void OnSelectUnitType()
    {
        var selectType = EventSystem.current.currentSelectedGameObject.GetComponent<GarageVehicleTypeClick>();
        SelectedGroundType = selectType.SelectedGroundType;
        StartCoroutine(OpenVehicleType(SelectedGroundType));
        DebugText.text = selectType.SelectedGroundType.ToDescription();
        VehicleListPanel.SetActive(true);

    }
    public void OnCountryChange() { }

    public void NextUnityClass() { }
}
