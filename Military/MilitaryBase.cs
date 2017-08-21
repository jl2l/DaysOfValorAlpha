using UnityEngine;
using System.Collections;
using Assets;
using System.Collections.Generic;
using WorldMapStrategyKit;

[System.Serializable]
public class MilitaryBase : ScriptableObject
{

    public float BaseLong;
    public float BaseLat;
    [ContextMenuItem("GetBase Info", "GetFromMap")]

    public Vector2 BaseLocation;
    public CountryToGlobalCountry.GenericProvince BaseInProvinceName;
    public CountryToGlobalCountry.GenericCountry BaseInCountryName;



   
    public CountryToGlobalCountry.GenericCountry CountryOfGovernment;

    private void GetFromMap()
    {
        var localMap = WMSK.instance;
       
      
        localMap.calc.fromLatDec = BaseLong;   // 40.71 decimal degrees north
        localMap.calc.fromLonDec = BaseLat;  // 74.00 decimal degrees to the west
        localMap.calc.fromUnit = UNIT_TYPE.DecimalDegrees;
        localMap.calc.Convert();
        var planeLocation = localMap.calc.toPlaneLocation;
        var provinceIndex = 0;
        var provinceRegionIndex = 0;

        var regionProvince = localMap.GetProvinceRegion(planeLocation);
       //localMap.GetProvinceRegionIndex(planeLocation, out provinceIndex, out provinceRegionIndex);
        BaseLocation = planeLocation;
       BaseInProvinceName.location = regionProvince.center;
  
       BaseInProvinceName.index = regionProvince.entity.uniqueId;
        BaseInProvinceName.name = regionProvince.entity.name;
        var c  = localMap.GetCountry(localMap.GetCountryIndex(regionProvince.center));
        BaseInCountryName.name = c.name;
         BaseInCountryName.index = c.uniqueId;
        BaseInCountryName.location = c.mainRegion.center;
        BaseInCountryName.regionName = c.continent;

        //var localCountry = localMap.GetCountry(countryIndex);
        //var captialCity = localMap.cities.FirstOrDefault(e => e.countryIndex == countryIndex && e.cityClass == CITY_CLASS.COUNTRY_CAPITAL);
        //var captialProvinceName = captialCity.province;
        //CaptialName = captialCity.name;

        //var captialProvince = localMap.GetProvince(captialProvinceName, localCountry.name);
        //CountryOfGovernment.index = localCountry.mainRegionIndex;
        //CountryOfGovernment.name = localCountry.name;
        //CountryOfGovernment.regionName = CustomRegionName.Length > 0 ? CustomRegionName : localCountry.continent;

        //CaptialProvince.index = captialProvince.uniqueId;
        //CaptialProvince.name = captialProvince.name;
        //CaptialProvince.location.x = captialProvince.center.x;
        //CaptialProvince.location.y = captialProvince.center.y;
        //ControlsProvincesNames.Clear();
        //for (int i = 0; i < localCountry.provinces.Length; i++)
        //{
        //    var selectedProvince = localCountry.provinces[i];
        //    var newProvince = new CountryToGlobalCountry.GenericProvince(selectedProvince.name);
        //    newProvince.index = selectedProvince.uniqueId;
        //    newProvince.location.x = selectedProvince.center.x;
        //    newProvince.location.y = selectedProvince.center.y;
        //    ControlsProvincesNames.Add(newProvince);
        //}
    }


    public string BaseName;
    public GeneralAgent BaseCommander;
    public Texture2D BaseIcon;
    public Texture2D MilitaryCountryBattleFlag;
    public GameObject BaseMarker;
    public MilitaryBaseFactory.BaseType GameBasetype;
    public List<MilitaryBaseFactory.BaseSpecialize> GameBaseSkills;
    public List<WeaponStationType> GameBaseWeapons;
    public List<BaseDefenses> GameBaseDefenses;
    public List<DeckDataItem> GameBaseDeck;
 
}
