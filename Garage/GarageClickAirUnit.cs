using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GarageClickAirUnit : MonoBehaviour
{


    public DoV_Vehicle SelectedAirUnit;
    public bool IsUnlocked;
    public bool IsRepairing;
    public GameObject SelectedUnitObjectModel;
    public GameObject AssignedDovMarkerContainer;
    public Texture2D ButtonBackgroundImage;

    public UnityEvent OnUnitSelected;
    public UnityEvent OnMouseOver;

    // Use this for initialization
    void Start()
    {
        SelectedUnitObjectModel = SelectedAirUnit.LowPolyModel;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnSelectAirUnit()
    {
        OnUnitSelected.Invoke();
    }


}
