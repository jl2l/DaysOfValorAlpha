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
using Newtonsoft.Json.Linq;

public static class Helpers
{

    public static float WeightedAverage<T>(this IEnumerable<T> records, Func<T, float> value, Func<T, float> weight)
    {
        float weightedValueSum = records.Sum(x => value(x) * weight(x));
        float weightSum = records.Sum(x => weight(x));

        if (weightSum != 0)
            return weightedValueSum / weightSum;
        else
            throw new DivideByZeroException("Your message here");
    }

    public static string ToDescription(this Enum value)
    {
        DescriptionAttribute[] da = (DescriptionAttribute[])(value.GetType().GetField(value.ToString())).GetCustomAttributes(typeof(DescriptionAttribute), false);
        return da.Length > 0 ? da[0].Description : value.ToString();
    }

    public static RegionInfo GetRegionInfo(string countryName)
    {

        var regions = CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(x => new RegionInfo(x.LCID)).ToList();
        return regions.FirstOrDefault(region => region.EnglishName.Contains(countryName));
    }

    public static List<RegionInfo> GetRegions()
    {

        return CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(x => new RegionInfo(x.LCID)).ToList();
    }

    public static string GetRegionCurrency(string countryName)
    {
        var f = GetRegionInfo(countryName);
        return f.CurrencyEnglishName;
    }
    public static string GetRegionCurrencySymbol(string countryName)
    {
        var f = GetRegionInfo(countryName);
        return f.CurrencySymbol;
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

    public List<JObject> CIACountryIndex()
    {
        var allJsons = Directory.GetFiles(@"Assets\DoVAlpha\GovernmentsDefault\cia", "*.json", SearchOption.AllDirectories);
        var list = new List<JObject>();
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
                    var s = JsonConvert.DeserializeObject<JObject>(jsonObj);
                    var ciaDataObj = JsonConvert.DeserializeAnonymousType<CountryCiaDbObject>(jsonObj, model);
                    list.Add(s);
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
            return new List<JObject>();
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
    public JObject GetCIAInfo(string CountryName)
    {
        return CIACountryIndex().FirstOrDefault();
    }

    public JProperty GetCIAProperty(string PropertyXPath)
    {
        if (PropertyXPath.Length > 0)
        {
            var indexes = PropertyXPath.Split('.');
            if (indexes.Length == 1)
            {
                foreach (var item in indexes)
                {
                    var Dig = CIACountryIndex().FirstOrDefault().Property(item);
                }
            }
            else {

            }
           return CIACountryIndex().FirstOrDefault().Property(PropertyXPath);
        }
   
        else
        foreach (JProperty prop in CIACountryIndex().FirstOrDefault().Properties())
        {
            if (prop.Path == PropertyXPath) {
                return prop;
            }
        }
        return null;
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

    public List<KeyValuePair<SectorManager.Sectors, string>> SubSectors()
    {

        return new List<KeyValuePair<SectorManager.Sectors, string>>()
    {
        new KeyValuePair<SectorManager.Sectors, string>( SectorManager.Sectors.Aerospace, "non-alcoholic beverages"),
        new KeyValuePair<SectorManager.Sectors, string>( SectorManager.Sectors.Agriculture, "fertilizer"),
        new KeyValuePair<SectorManager.Sectors, string>( SectorManager.Sectors.Mining, "oilfield equipment"),
        new KeyValuePair<SectorManager.Sectors, string>( SectorManager.Sectors.Mining, "aluminum smelting"),
        new KeyValuePair<SectorManager.Sectors, string>( SectorManager.Sectors.Telecom, "telecommunications equipment"),
         new KeyValuePair<SectorManager.Sectors, string>( SectorManager.Sectors.Aerospace, "commercial space launch vehicles"),
       
    };
    }
}



/// <summary>
/// The country is usually backed by a reserve currency this is it
/// </summary>
public enum ReserveCurrency
{
    Gold,
    Crypto,
    USD,
    EURO,
    Yen,
    Pound,
    Franc,
    IndiaRupee,
    AustralianDollar,
    Rand,
    RussianRUB,
    ChineseRMB
}

public enum CityType
{

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




