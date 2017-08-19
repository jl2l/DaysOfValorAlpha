using UnityEngine;
using System.Collections;
using WorldMapStrategyKit;
using System.Linq;
using System.Collections.Generic;

namespace WorldMapStrategyKit
{
 
    public partial class WMSK
    {
        [SerializeField]
        bool
         _showCitiesoverCountry = true;

        /// <summary>
        /// Toggle cities visibility.
        /// </summary>
        public bool showCitiesOverCountry
        {
            get
            {
                return _showCitiesoverCountry;
            }
            set
            {
                if (_showCitiesoverCountry != value)
                {
                    _showCitiesoverCountry = value;
                    isDirty = true;
                    if (citiesLayer != null)
                    {
                        citiesLayer.SetActive(_showCitiesoverCountry);
                    }
                    else if (_showCitiesoverCountry)
                    {
                        DrawCitiesOverCountry();
                    }
                }
            }
        }
        

        /// <summary>
        /// Redraws the cities. This is automatically called by Redraw(). Used internally by the Map Editor. You should not need to call this method directly.
        /// </summary>
        public void DrawCitiesOverCountry(int countryIndex = 0)
        {

            if (!_showCitiesoverCountry || !gameObject.activeInHierarchy)
                return;
            var map = FindObjectOfType<WMSK>();
            var gameManager = FindObjectOfType<GameManager>();

            CheckCityIcons();

            // Create cities layer
            Transform t = transform.Find("Cities");
            if (t != null)
                DestroyImmediate(t.gameObject);
            citiesLayer = new GameObject("Cities");
            citiesLayer.hideFlags = HideFlags.DontSave;
            citiesLayer.transform.SetParent(transform, false);
            citiesLayer.transform.localPosition = Misc.Vector3back * 0.001f;
            citiesLayer.layer = gameObject.layer;

            // Create cityclass parents
            GameObject countryCapitals = new GameObject("Country Capitals");
            countryCapitals.hideFlags = HideFlags.DontSave;
            countryCapitals.transform.SetParent(citiesLayer.transform, false);
            GameObject regionCapitals = new GameObject("Region Capitals");
            regionCapitals.hideFlags = HideFlags.DontSave;
            regionCapitals.transform.SetParent(citiesLayer.transform, false);
            GameObject normalCities = new GameObject("Normal Cities");
            normalCities.hideFlags = HideFlags.DontSave;
            normalCities.transform.SetParent(citiesLayer.transform, false);

            if (cities == null)
                return;
            // Draw city marks
            numCitiesDrawn = 0;
            var citiestoDraw = new List<City>();
            int minPopulation = map.minPopulation * 1000;
            int visibleCount = 0;
            if (map.countryHighlightedIndex != -1)
                citiestoDraw = map.cities.Where(e => e.countryIndex == map.countryHighlightedIndex).ToList();
            else if(countryIndex != 0)
            citiestoDraw = map.cities.Where(e => e.countryIndex == countryIndex).ToList();

            int cityCount = citiestoDraw.Count();
            foreach (var city in citiestoDraw)
            {
              
                    GameObject cityObj, cityParent;
                    Material mat;
                    switch (city.cityClass)
                    {

                        case CITY_CLASS.COUNTRY_CAPITAL:
                        var cap = Resources.Load<GameObject>("WMSK/Prefabs/CityCapitalCountrySpot");
                            cityObj = Instantiate(cap);
                            mat = citiesCountryCapitalMat;

                            cityParent = countryCapitals;
                           // mat.color = gameManager.GameWorldManager.CityStatus(gameManager.GamePlayerCountryManager.CountryGovernment,
                                // new CountryToGlobalCountry.GenericCity(gameManager.GameWorldManager.WorldCityData.FirstOrDefault(e => e.index == city.uniqueId)), city);
                            break;
                        case CITY_CLASS.REGION_CAPITAL:
                            cityObj = Instantiate(Resources.Load<GameObject>("WMSK/Prefabs/CityCapitalRegionSpot"));
                           mat = citiesRegionCapitalMat;
                            cityParent = regionCapitals;
                           // mat.color = gameManager.GameWorldManager.CityStatus(gameManager.GamePlayerCountryManager.CountryGovernment,
                              //   new CountryToGlobalCountry.GenericCity(gameManager.GameWorldManager.WorldCityData.FirstOrDefault(e => e.index == city.uniqueId)), city);
                            break;
                        default:
                            cityObj = Instantiate(Resources.Load<GameObject>("WMSK/Prefabs/CitySpot"));
                            mat = citiesNormalMat;
                            cityParent = normalCities;
                            //mat.color = gameManager.GameWorldManager.CityStatus(gameManager.GamePlayerCountryManager.CountryGovernment,
                               //  new CountryToGlobalCountry.GenericCity(gameManager.GameWorldManager.WorldCityData.FirstOrDefault(e => e.index == city.uniqueId)), city);
                            break;
                    }

                    cityObj.name = city.name.ToString();
                    cityObj.hideFlags = HideFlags.DontSave | HideFlags.HideInHierarchy;
                    cityObj.layer = citiesLayer.layer;
                    cityObj.transform.SetParent(cityParent.transform, false);
                    cityObj.transform.localPosition = city.unity2DLocation;
                    Renderer rr = cityObj.GetComponent<Renderer>();
                    if (rr != null)
                        rr.sharedMaterial = mat;

                    numCitiesDrawn++;
                    visibleCount++;
                }
            




            // Toggle cities layer visibility according to settings
            citiesLayer.SetActive(_showCitiesoverCountry);
            ScaleCities();
            ReloadCitiesAttributes();
            //HighlightCity();
        }
    }
}
