using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UIWidgets;
using UnityEngine;
using UnityEngine.UI;
using WorldMapStrategyKit;
using static MapManager;

public class CountryInfoPanel : MonoBehaviour
{
    public WorldManager GameWorldManager;
    public MapManager GameMapManager;
    public CountryGovernment CountryGovernment;
    public CountryManager GameCountryManager;
    public WorldMapStrategyKit.Country GameMapCountry;
    public WMSK wmslObj;
    public int countryIndex;

    public Text GovernmentName;
    public Text CaptialName;
    public Text CountryGovernmentInfoText;
    public Text CountryNationals;
    public Text CountryFounding;
    public RawImage CountryFlag;

    public Progressbar PlayerPopulationTrustLevel;


    public Progressbar CountryPopulationTrustLevel;
    //MilitaryToGovernmentTrustLevel
    //    GovernmentToMilitaryTrustLevel
    //    PoliticalStability

    // Use this for initialization
    void Start()
    {
        wmslObj = WMSK.instance;
        GameWorldManager = FindObjectOfType<WorldManager>();
        GameMapManager = FindObjectOfType<MapManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ColorizeCountry()
    {

        for (int p = 0; p < GameMapCountry.provinces.Length; p++)
        {
            Color color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            int provinceIndex = wmslObj.GetProvinceIndex(GameMapCountry.provinces[p]);
            wmslObj.ToggleProvinceSurface(provinceIndex, true, color);
        }
    }

    public void SelectOnCountry()
    {

        if (GameMapManager.SelectedCountryManager != null)
        {
            GameCountryManager = GameWorldManager.WorldCountryManagement.FirstOrDefault(e => e.CountryGovernment.CountryOfGovernment.name == wmslObj.countryHighlighted.name);
            if (GameCountryManager != null)
            {
                GameMapManager.DebugText.text = string.Format("SELET {0}, {1}", GameCountryManager.name, GameCountryManager.CountryGovernment.MapLookUpName);
                gameObject.SetActive(true);
                wmslObj.FlyToCountry(GameCountryManager.CountryGovernment.MapLookUpName, 1f, wmslObj.lastKnownZoomLevel);
                GameMapManager.DebugText.text = string.Format("elected Country Government {0}", wmslObj.countryHighlighted.name);
                GovernmentName.text = wmslObj.countryHighlighted.name;
                CountryNationals.text = GameCountryManager.CountryGovernment.TitleOfPopulation;
                CountryFounding.text = GameCountryManager.CountryGovernment.FoundingYear.ToString();
                CaptialName.text = GameCountryManager.CountryGovernment.CaptialName;
                GameMapManager.GameMapSelectedType = MapSelected.Country;
            }
            else
            {
                GameMapManager.DebugText.text = string.Format("Missing Government {0}", wmslObj.countryHighlighted.name);
                gameObject.SetActive(false);
                GovernmentName.text = wmslObj.countryHighlighted.name;
                wmslObj.FlyToCountry(wmslObj.countryHighlighted.name, 1f, wmslObj.lastKnownZoomLevel);
            }

            // SetPanelsByModeOnClick();
            ColorizeCountry();
        }
        else
        {
            // relations
            GameMapManager.DebugText.text = "NO RELATIONS OPEN EMBASSY";
        }

    }
}
