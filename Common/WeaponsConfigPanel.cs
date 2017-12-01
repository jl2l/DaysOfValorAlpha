using System.Collections;
using System.Collections.Generic;
using UIWidgets;
using UIWidgetsSamples;
using UnityEditorUI;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UI;

public class WeaponsConfigPanel : MonoBehaviour
{

    public DoV_CombatVehicle SelectedVehicle;
    public GameObject WeaponPanelList;
    public GameObject WeaponConfigTemplate;
    public GameObject WeaponList;
    public WeaponConfigPanel WeaponConfigPanel;

    public WeaponSlotPanel WeaponSlotTemplate;
    public GameObject WeaponButtonContainer;
    public GameObject WeaponButtonTemplate;

    public Text WeaponConfigText;
    // Use this for initialization
    void Start()
    {
        SetTabWeaponConfig();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void DrawWeapons(WeaponConfig weapons, GameObject WeaponConfigTemplate)
    {
        weapons.WeaponsStations.ForEach(weaponStation =>
        {
            var WeaponList = WeaponConfigTemplate.GetComponent<WeaponConfigPanel>().WeaponList;
            var WeaponSlot = Instantiate(WeaponConfigTemplate.GetComponent<WeaponConfigPanel>().WeaponSlot);
            var WeaponSlotPanel = WeaponSlot.GetComponent<WeaponSlotPanel>();
            WeaponSlotPanel.CurrentWeapon = weaponStation.ConfigWeapons.FirstOrDefault();
            WeaponSlotPanel.SetWeapon();
            WeaponSlot.transform.SetParent(WeaponList.transform);
        });
        WeaponConfigTemplate.GetComponent<WeaponConfigPanel>().WeaponSlot.SetActive(false);
    }

    public void SetTabWeaponConfig()
    {

        SelectedVehicle = FindObjectOfType<DoV_CombatVehicle>();

        SelectedVehicle.Vehicle.VehicleWeapons.ForEach(weaponconfig =>
        {
            var newWeaponConfigButton = Instantiate(WeaponButtonTemplate);
            var newWeaponConfigTemplate = Instantiate(WeaponConfigTemplate);




            newWeaponConfigButton.GetComponentInChildren<Text>().text = weaponconfig.Name;

            DrawWeapons(weaponconfig, newWeaponConfigTemplate);
            UnityEngine.Events.UnityAction action1 = () => { newWeaponConfigTemplate.SetActive(false); };
            newWeaponConfigButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(action1);//find the button and set
            newWeaponConfigButton.transform.SetParent(WeaponButtonContainer.transform);

            newWeaponConfigTemplate.transform.SetParent(WeaponPanelList.transform);
        });


        WeaponConfigTemplate.SetActive(false);
        WeaponButtonTemplate.SetActive(false);

    }
}
