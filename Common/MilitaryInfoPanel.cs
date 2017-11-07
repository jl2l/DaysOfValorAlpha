using System.Collections;
using System.Collections.Generic;
using UIWidgets;
using UnityEngine;
using UnityEngine.UI;

public class MilitaryInfoPanel : MonoBehaviour
{

    public CountryMilitary SelectedCountryMilitary;
    public Text MilitaryForces;
    public Slider MilitaryIndustrialCapacityCurrent;
    public Slider MilitaryIndustrialCapacityFurture;

    public GameObject MilitaryNavyListOfShips;
    public GameObject ShipInfoPanel;

    public GameObject MilitaryNavyContainer;
    public GameObject NavalGroupItemTemplate;
    public GameObject NavalGroupHeader;
    public GameObject NavalGroupContent;
    public GameObject NavalGroupSizeTemplate;
    public Accordion NavalGroups;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
