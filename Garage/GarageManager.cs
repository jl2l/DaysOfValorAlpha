using UnityEngine;
using System.Collections;
using Assets;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GarageManager : MonoBehaviour
{
    public GroundVehicleType TypeOfGarageGround;
    public SeaObjectType TypeOfGarageSea;
    public AircraftTypeStr TypeOfGarageAir;
    public CountryManager GarageCountryManager;

    public BaseAirType SelectedType;

    public Text SelecteMapCountry;
    public Text SelectedMilitaryAirforceName;
    public Text SelectedAircraftRole;
    public RawImage SelectedAircraftType;
    public RawImage SelectedAircraftCountryFlag;


    public void OpenMap()
    {
        SceneManager.LoadScene(0);
    }

    public void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }

    public void OnCountryChange() { }

    public void NextUnityClass() { }
}
