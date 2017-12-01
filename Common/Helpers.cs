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
using Accord.Statistics.Distributions.Univariate;

public static class Helpers
{
    public static string NumberToText(int n)
    {
        if (n < 0)
            return "Minus " + NumberToText(-n);
        else if (n == 0)
            return "";
        else if (n <= 19)
            return new string[] {"One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight",
         "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
         "Seventeen", "Eighteen", "Nineteen"}[n - 1] + " ";
        else if (n <= 99)
            return new string[] {"Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy",
         "Eighty", "Ninety"}[n / 10 - 2] + " " + NumberToText(n % 10);
        else if (n <= 199)
            return "One Hundred " + NumberToText(n % 100);
        else if (n <= 999)
            return NumberToText(n / 100) + "Hundreds " + NumberToText(n % 100);
        else if (n <= 1999)
            return "One Thousand " + NumberToText(n % 1000);
        else if (n <= 999999)
            return NumberToText(n / 1000) + "Thousands " + NumberToText(n % 1000);
        else if (n <= 1999999)
            return "One Million " + NumberToText(n % 1000000);
        else if (n <= 999999999)
            return NumberToText(n / 1000000) + "Millions " + NumberToText(n % 1000000);
        else if (n <= 1999999999)
            return "One Billion " + NumberToText(n % 1000000000);
        else
            return NumberToText(n / 1000000000) + "Billions " + NumberToText(n % 1000000000);
    }

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

        regions.OrderBy(pet => pet.EnglishName);

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

    public Texture2D LoadFlagFromCountryName(string countryName)
    {

        var twocode = GetTwoCountryCodeFromName(countryName).ToLower();
        var countTewoCode = string.Format("UI/icons/Flags/png100px/{0}", twocode);
        var g = Resources.Load<Texture2D>("UI/icons/Flags/png100px/ar");
        var texture = Resources.Load(countTewoCode) as Texture2D;
        return texture;
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

    public string GetTwoCountryCodeFromName(string countryName)
    {
        if (countryName == "United States of America")
        {
            return "us";
        }
        if (countryName == "Hati")
        {
            return "ht";
        }

        var region = Helpers.GetRegionInfo(countryName);
        if (region == null)
        {
            Console.Write(countryName);
        }
        else
        {
            return region.TwoLetterISORegionName;
        }
        return string.Empty;
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
            else
            {

            }
            return CIACountryIndex().FirstOrDefault().Property(PropertyXPath);
        }

        else
            foreach (JProperty prop in CIACountryIndex().FirstOrDefault().Properties())
            {
                if (prop.Path == PropertyXPath)
                {
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


    public BinomialDistribution DemographicDistribution;
}

public enum ArmorState
{
    ActiveDefenseOffline,
    ActiveDefenseOnline,
    ActiveDefenseDectecting,
    ActiveDefenseHit,
    ActiveDefenseMiss,
    Damaged,
    Destoryed
}
public enum SensorState
{
    IsJammed,
    IsConfused,
    IsTracking,
    IsLockedOn,
    IsTargeted

}

public enum WeaponState
{
    IsTracking,
    IsLockedOn,
    IsFiring,
    IsReloading,
    IsOutOfAmmo
}
public enum TurretState
{
    Idle,
    IdleRotating,
    Tracking,
    LockedOn,
}
public enum MoveState
{
    [Description("no contact reported")]
    Idle,
    [Description("ready for orders")]
    IdleStart,
    [Description("orders confirmed")]
    StartMoving,
    [Description("on the move")]
    Moving,
    [Description("near target")]
    PrepearToStop,
    [Description("arrived at target")]
    Stopped,

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
    [Description("an isolated dwelling would only have 1 or 2 buildings or families in it. It would have negligible services, if any.")]
    Remote,
    [Description("a hamlet has a tiny population (<100) and very few (if any) services, and few buildings")]
    Hamlet,
    [Description("a village is a human settlement or community that is larger than a hamlet but, smaller than a town. A village generally does not have many services, most likely a church or only a small shop or post office. The population of a village varies however, the average population can range from hundreds to thousands.")]
    SmallVillage,
    [Description("a village is a human settlement or community that is larger than a hamlet but, smaller than a town. A village generally does not have many services, most likely a church or only a small shop or post office. The population of a village varies however, the average population can range from hundreds to thousands.")]
    Village,
    [Description("a town has a population of 1,000 to 20,000")]
    SmallTown,
    [Description("a town has a population of 1,000 to 20,000")]
    SmallTownEuropean,
    [Description("a town has a population of 1,000 to 20,000")]
    SmallTownAmericas,
    [Description("a town has a population of 1,000 to 20,000")]
    SmallTownAsia,
    [Description("a town has a population of 1,000 to 20,000")]
    SmallTownAfrica,
    [Description("a town has a population of 1,000 to 20,000")]
    SmallTownMiddleEastern,
    [Description("a large town has a population of 20,000 to 100,000")]
    Town,
    [Description("a city would have abundant services, but not as many as a large city. The population of a city is between 100,000 and 300,000 people.")]
    SmallCity,
    [Description("a city with a large population and many services. The population is <1 million people but over 300,000 people")]
    City,
    [Description("a city with a large population and many services. The population is <1 million people but over 300,000 people")]
    LargeCity,
    [Description("a large city and its suburbs consisting of multiple cities and towns. The population is usually one to three million.")]
    Metropolis,
    [Description("A rural farming village commonly found in the third world")]
    RegionalCaptial,
    [Description("A rural farming village commonly found in the third world")]
    GovernmentCaptial,
    [Description(" a group of conurbations, consisting of more than ten million people each.")]
    MegaCity


}




