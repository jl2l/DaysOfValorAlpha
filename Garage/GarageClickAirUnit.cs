using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GarageClickAirUnit : MonoBehaviour
{


    public DoV_Vehicle OnClickSelectThisVehicle;

    public Text GarageUnitName;

    public GameObject SelectedUnitObjectModel;
    public GameObject AssignedDovMarkerContainer;
    public RawImage ButtonBackgroundImage;
    public RawImage GarageFlag;
    public RawImage GarageIcon;

    public UnityEvent OnUnitSelected;
    public UnityEvent OnMouseOver;

    // Use this for initialization
    void Start()
    {
        if (OnClickSelectThisVehicle != null)
            SelectedUnitObjectModel = OnClickSelectThisVehicle.Model;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnSelectAirUnit()
    {
        OnUnitSelected.Invoke();
    }


    public void OpenVehicleOnClick()
    {
        AssignedDovMarkerContainer.GetComponentsInChildren<Animator>().ToList().ForEach(e =>
        {
            Destroy(e.gameObject);
        });
        var newModel = Instantiate(SelectedUnitObjectModel);
        newModel.transform.SetParent(AssignedDovMarkerContainer.transform);
        FindObjectOfType<GarageManager>().SetSelectedUnitUI(OnClickSelectThisVehicle);

    }
    public void OpenVehicleHover()
    {

    }

}
