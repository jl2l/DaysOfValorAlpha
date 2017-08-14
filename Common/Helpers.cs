using UnityEngine;
using System.Collections;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Globalization;
using System.Linq;
using System.Text;
using System.IO;
using static Assets.JsonCountryCIAModel;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

public static class Helpers
{
    public static string ToDescription(this Enum value)
    {
        DescriptionAttribute[] da = (DescriptionAttribute[])(value.GetType().GetField(value.ToString())).GetCustomAttributes(typeof(DescriptionAttribute), false);
        return da.Length > 0 ? da[0].Description : value.ToString();
    }

    public static RegionInfo GetRegionInfo(string countryName)
    {

        var regions = CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(x => new RegionInfo(x.LCID));
        return regions.FirstOrDefault(region => region.EnglishName.Contains(countryName));
    }

    public static List<RegionInfo> GetRegions()
    {

        return CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(x => new RegionInfo(x.LCID)).ToList();
    }

    // Utility functions called from OnGUI:
    public static string EntityListToString<T>(List<T> entities)
    {
        StringBuilder sb = new StringBuilder("Neighbours: ");
        for (int k = 0; k < entities.Count; k++)
        {
            if (k > 0)
            {
                sb.Append(", ");
            }
            sb.Append(((WorldMapStrategyKit.IAdminEntity)entities[k]).name);
        }
        return sb.ToString();
    }
}

public class Helper
{
    [Serializable]
    public class GameTimeZone
    {
        public int ID;
        public string ZoneName;
        public string Country;
        public string RuleName;
        public int GmtOffset;
        public string Format;
        public string StandardName;

        // {"ID":13,"ZoneName":"Africa/Cairo","Country":"Cairo","RuleName":"Egypt","GmtOffset":7200,"Format":"EEST","StandardName":"Egypt Standard Time"},
    }


    public List<TimeZone> GameTimeZones()
    {
        return new List<TimeZone>();
    }

    public List<CountryCiaDbObject> CIACountryIndex()
    {
        var allJsons = Directory.GetFiles(@"Assets\DoVAlpha\GovernmentsDefault\cia", "*.json", SearchOption.AllDirectories);
        var list = new List<CountryCiaDbObject>();
        foreach (var file in allJsons)
        {
            var g = @"Assets/DoVAlpha /GovernmentsDefault/cia/africa/ag.json";
            string jsonObj = Regex.Replace(File.ReadAllText(file), @"[\r\n\t ]+", " ");
            var model = new CountryCiaDbObject();
            if (jsonObj != null)
            {
                try
                {

                    var f = JsonUtility.FromJson(jsonObj, typeof(CountryCiaDbObject));
                    var s = JsonConvert.DeserializeObject<CountryCiaDbObject>(jsonObj);
                    var ciaDataObj = JsonConvert.DeserializeAnonymousType<CountryCiaDbObject>(jsonObj, model);

                }
                catch (Exception s)
                {
                    var f = s.InnerException;
                    Console.Write("{0} failed", file);
                }

            }
        }

        if (list.Count > 0)
        {
            return list;
        }
        else
        {
            return new List<CountryCiaDbObject>();
        }

    }

    public string GetTwoCountryCodeFromName(string countrName)
    {
        return Helpers.GetRegionInfo(countrName).TwoLetterISORegionName;
    }

    public void GetCIAInfoFromFile(string regionName, out CountryCiaDbObject ciaObject)
    {
        ciaObject = null;
        var countryCode = GetTwoCountryCodeFromName(regionName);
        var countryJsonCIAFile = string.Format("{0}.json", countryCode);
        string[] dirs = Directory.GetFiles(@"Assets\DoVAlpha\GovernmentsDefault\cia", countryJsonCIAFile, SearchOption.AllDirectories);
        if (dirs.Length > 0)
        {
            var ciaFile = dirs.FirstOrDefault();
            TextAsset jsonObj = Resources.Load(ciaFile) as TextAsset;
            if (jsonObj != null)
            {
                List<CountryCiaDbObject> gameTimeZone = JsonUtility.FromJson<List<CountryCiaDbObject>>(jsonObj.text);
                var foundCiaObject = gameTimeZone.FirstOrDefault(e => e.CountryName.Contains(regionName));
                ciaObject = foundCiaObject;
            }
        }
    }
    public CountryCiaDbObject GetCIAInfo(string CountryName)
    {
        return CIACountryIndex().FirstOrDefault(e => e.CountryName == CountryName);
    }

    public GameTimeZone GetTimeZoneInfo(string regionName)
    {
        var file = "Assets//DoVAlpha//GovernmentsDefault//timezone//timezone.json";
        string jsonObj = Regex.Replace(File.ReadAllText(file), @"[\r\n\t ]+", " ");
        List<GameTimeZone> gameTimeZone = JsonUtility.FromJson<List<GameTimeZone>>(jsonObj);
        var foundZone = gameTimeZone.FirstOrDefault(e => e.Country.Contains(regionName));
        if (foundZone != null)
        {
            return foundZone;
        }
        foundZone = gameTimeZone.FirstOrDefault(e => e.RuleName.Contains(regionName));
        if (foundZone != null)
        {
            return foundZone;
        }

        return foundZone;
    }
    
    public Color ColorCell(float value)
    {
        var red = value < 50f ? 255f : Mathf.Round(256f - (value - 50f) * 5.12f);
        var green = value > 50f ? 255f : Mathf.Round((value) * 5.12f);
        return new Color(red, green, 0, 1);

    }
}






public enum CityType {

    [Description("A rural farming village commonly found in the third world")]
    SmallVillage,
    [Description("A rural farming village commonly found in the third world")]
    FishingVillage,
    [Description("A rural farming village commonly found in the third world")]
    SmallTown,
    [Description("A rural farming village commonly found in the third world")]
    SmallTownEuropean,
    [Description("A rural farming village commonly found in the third world")]
    SmallTownAmericas,
    [Description("A rural farming village commonly found in the third world")]
    SmallTownAsia,
    [Description("A rural farming village commonly found in the third world")]
    SmallTownAfrica,
    [Description("A rural farming village commonly found in the third world")]
    SmallCity,
    [Description("A rural farming village commonly found in the third world")]
    City,
    [Description("A rural farming village commonly found in the third world")]
    LargeCity,
    [Description("A rural farming village commonly found in the third world")]
    RegionalCaptial,
    [Description("A rural farming village commonly found in the third world")]
    GovernmentCaptial,
    [Description("A rural farming village commonly found in the third world")]
    MegaCity,
}




