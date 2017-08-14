using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GetCountryDroplist : MonoBehaviour {


    IEnumerator GetCountiesDroplist(Dropdown CountryDropList)
    {

        var list = CultureInfo.GetCultures(CultureTypes.NeutralCultures).ToList();
        // Iterate the Framework Cultures...
        foreach (var ci in list)
        {
            RegionInfo ri = null;
            try
            {
                ri = new RegionInfo(ci.Name);
                CountryDropList.options.Add(new Dropdown.OptionData() { text = ri.EnglishName });
            }
            catch
            {
                // If a RegionInfo object could not be created we don't want to use the CultureInfo
                //    for the country list.
                continue;
            }
        }

        yield return null;
    }

    public Dropdown CountryDropList;
	// Use this for initialization
	void Start () {
        CountryDropList.options.Clear();

        StartCoroutine(GetCountiesDroplist(CountryDropList));
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
