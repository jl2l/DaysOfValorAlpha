using Assets;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSlotPanel : MonoBehaviour
{

    public Weapon CurrentWeapon;
    public RawImage CurrentWeaponImage;
    public RawImage CurrentAmmoImage;
    public Text WeaponName;
    public Text WeaponStationInfo;
    public Text WeaponPerks;
    public Text WeaponWarheadPerks;
    public Text WeaponGroundRange;
    public Text WeaponLowAirRange;
    public Text WeaponHighAirRange;
    public GameObject WeaponModel;
    public Text WeaponHEDamage;
    public Text WeaponAPDamage;
    public Text WeaponAmmo;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetWeapon()
    {

        WeaponName.text = CurrentWeapon.WeaponName;
        WeaponAPDamage.text = CurrentWeapon.WeaponAP.ToString();
        WeaponHEDamage.text = CurrentWeapon.WeaponHE.ToString();
        WeaponGroundRange.text = CurrentWeapon.WeaponRangeGround.ToString();
        WeaponHighAirRange.text = CurrentWeapon.WeaponRangeAirHigh.ToString();
        WeaponLowAirRange.text = CurrentWeapon.WeaponRangeAirLow.ToString();
        var perks = string.Empty;
        CurrentWeaponImage.texture = CurrentWeapon.WeaponIconName;
        CurrentWeapon.WeaponPerks.ForEach(e => { perks += string.Format("{0}, ", e); });
        WeaponPerks.text = perks;

        var Warhead = string.Empty;

        CurrentWeapon.WeaponPerks.ForEach(e => { perks += string.Format("{0}, ", e); });
        WeaponPerks.text = perks;
    }
}
