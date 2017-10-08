using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Reflection;
using Assets;

public class EditorHelper
{
    const string countryFlag = "DoVAlpha/Vehicles/data/USA/";
    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create Vehicle", false, 101)]
    public static void CreateItemTypeVpCustomType()
    {
        DoV_Vehicle asset = (DoV_Vehicle)CreateAsset(countryFlag, typeof(DoV_Vehicle));
        if (asset != null)
            asset.DisplayName = "custom";
    }
    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create Stock Deck", false, 101)]
    public static void CreateItemDeck()
    {
        DeckDataItem asset = (DeckDataItem)CreateAsset(countryFlag + "weapon/configs", typeof(DeckDataItem));
        if (asset != null)
            asset.DeckName = "custom deck name";
    }
    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create Special Operations Unit", false, 101)]
    public static void CreateSpecialOperations()
    {
        SpecialOperationsTeam asset = (SpecialOperationsTeam)CreateAsset("DoVAlpha/GovernmentsDefault/data/militaries", typeof(SpecialOperationsTeam));
        if (asset != null)
            asset.TeamName = "SEALs";
    }

    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create Weapon Config", false, 101)]
    public static void CreateItemWeaponConfig()
    {
        WeaponConfig asset = (WeaponConfig)CreateAsset(countryFlag + "weapon/configs", typeof(WeaponConfig));
        if (asset != null)
            asset.Name = "custom weapon";
    }

    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create Weapon", false, 101)]
    public static void CreateItemWeapon()
    {
        Weapon asset = (Weapon)CreateAsset(countryFlag + "weapon", typeof(Weapon));
        if (asset != null)
            asset.WeaponName = "custom weapon";
    }

    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create Sensor", false, 101)]
    public static void CreateItemSensor()
    {
        Sensor asset = (Sensor)CreateAsset(countryFlag + "sensor", typeof(Sensor));
        if (asset != null)
            asset.SensorName = "custom air sensor";
    }

    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create Armor", false, 101)]
    public static void CreateItemArmor()
    {
        Armor asset = (Armor)CreateAsset(countryFlag + "armor", typeof(Armor));
        if (asset != null)
            asset.ArmorName = "custom land object";
    }

    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create New Government", false, 101)]
    public static void CreateGovernment()
    {
        CountryGovernment asset = (CountryGovernment)CreateAsset("DoVAlpha/GovernmentsDefault/data", typeof(CountryGovernment));
        if (asset != null)
            asset.NameOfGovernment = "some government";
    }

    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create New Military", false, 101)]
    public static void CreateMilitary()
    {
        CountryMilitary asset = (CountryMilitary)CreateAsset("DoVAlpha/GovernmentsDefault/data/militaries", typeof(CountryMilitary));
        if (asset != null)
            asset.ArmyName = "some army";
    }
    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create StrategicWeapon", false, 101)]
    public static void CreateStrategicWeapon()
    {
        StrategicWeapon asset = (StrategicWeapon)CreateAsset("DoVAlpha/GovernmentsDefault/data/militaries/", typeof(StrategicWeapon));
        if (asset != null)
            asset.WeaponName = "some WMD";
    }
    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create New Deal", false, 101)]
    public static void CreateNewDeal()
    {
        Deal asset = (Deal)CreateAsset("DoVAlpha/GovernmentsDefault/data/deals/", typeof(Deal));
        if (asset != null)
            asset.DealName = "a deal";
    }

    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create New Terrost Group", false, 101)]
    public static void CreateTerrorGroup()
    {
        TerroristGroup asset = (TerroristGroup)CreateAsset("DoVAlpha/GovernmentsDefault/data", typeof(TerroristGroup));
        if (asset != null)
            asset.GroupName = "some terror group";
    }
    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create New Rebel Group", false, 101)]
    public static void CreateRebelGroup()
    {
        RebelGroup asset = (RebelGroup)CreateAsset("DoVAlpha/GovernmentsDefault/data", typeof(RebelGroup));
        if (asset != null)
            asset.GroupName = "some rebel group";
    }
    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create New Military Base", false, 101)]
    public static void CreateMilitaryBase()
    {
        MilitaryBase asset = (MilitaryBase)CreateAsset("DoVAlpha/GovernmentsDefault/data/bases", typeof(MilitaryBase));
        if (asset != null)
            asset.BaseName = "some army";
    }


    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create New Sector Market", false, 101)]
    public static void CreateCountrySector()
    {
        CountrySectors asset = (CountrySectors)CreateAsset("DoVAlpha/GovernmentsDefault/data", typeof(CountrySectors));
        if (asset != null)
            asset.CountryName = "some sector";
    }
    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create New CountryResource", false, 101)]
    public static void CreateCountryResource()
    {
        SectorManager.CountryResource asset = (SectorManager.CountryResource)CreateAsset("DoVAlpha/GovernmentsDefault/data/resources", typeof(SectorManager.CountryResource));
        if (asset != null)
            asset.name = "some resource";
    }

    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create New Country Budget", false, 101)]
    public static void CreateCountryBudget()
    {
        CountryBudget asset = (CountryBudget)CreateAsset("DoVAlpha/GovernmentsDefault/data", typeof(CountryBudget));
        if (asset != null)
            asset.name = "some government";
    }


    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create New Country Law", false, 101)]
    public static void CreateCountryLaw()
    {
        CountryLaw asset = (CountryLaw)CreateAsset("DoVAlpha/GovernmentsDefault/data/laws", typeof(CountryLaw));
        if (asset != null)
            asset.LawName = "Some Law";
    }
    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create New Political Party", false, 101)]
    public static void CreatePoliticalParty()
    {
        PoliticalParties asset = (PoliticalParties)CreateAsset("DoVAlpha/GovernmentsDefault/data/politicals", typeof(PoliticalParties));
        if (asset != null)
            asset.PartyName = "some party";
    }

    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create New Demographic", false, 101)]
    public static void CreateDemogroup()
    {
        DemographicGroups asset = (DemographicGroups)CreateAsset("DoVAlpha/GovernmentsDefault/data/demogroups", typeof(DemographicGroups));
        if (asset != null)
            asset.GroupName = "Some group";
    }

    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create New Generic Country Infrastructure", false, 101)]
    public static void CreateGenericCountryInfrastructure()
    {
        CountryToGlobalCountry.GenericCountryInfrastructure asset = (CountryToGlobalCountry.GenericCountryInfrastructure)CreateAsset("DoVAlpha/GovernmentsDefault/data/infrastructure/", typeof(CountryToGlobalCountry.GenericCountryInfrastructure));
        if (asset != null)
            asset.DisplayName = "Some group";
    }
    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create New City Data", false, 101)]
    public static void CreateCityData()
    {
        CityData asset = (CityData)CreateAsset("DoVAlpha/GovernmentsDefault/data/cities/", typeof(CityData));
        if (asset != null)
            asset.CityName = "Some group";
    }
    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create New World Event", false, 101)]
    public static void CreateWorldEvent()
    {
        WorldEvent asset = (WorldEvent)CreateAsset("DoVAlpha/GovernmentsDefault/data/events/", typeof(WorldEvent));
        if (asset != null)
            asset.EventName = "some government";
    }


    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create New CulturalEvent", false, 101)]
    public static void CreateCulturalEvent()
    {
        CulturalEvent asset = (CulturalEvent)CreateAsset("DoVAlpha/GovernmentsDefault/data/events/", typeof(CulturalEvent));
        if (asset != null)
            asset.EventName = "some government";
    }

    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create New DiplomaticEvent", false, 101)]
    public static void CreateDiplomaticEvent()
    {
        DiplomaticEvent asset = (DiplomaticEvent)CreateAsset("DoVAlpha/GovernmentsDefault/data/events/", typeof(DiplomaticEvent));
        if (asset != null)
            asset.EventName = "some government";
    }
    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create New Uprising", false, 101)]
    public static void CreateUprising()
    {
        UprisingEvent asset = (UprisingEvent)CreateAsset("DoVAlpha/GovernmentsDefault/data/events/", typeof(UprisingEvent));
        if (asset != null)
            asset.EventName = "some government";
    }

    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create New NewsEvent", false, 101)]
    public static void CreateNewsEvent()
    {
        NewsEvent asset = (NewsEvent)CreateAsset("DoVAlpha/GovernmentsDefault/data/events/", typeof(NewsEvent));
        if (asset != null)
            asset.EventName = "some government";
    }

    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create New TerroristEvent", false, 101)]
    public static void CreateTerroristEvent()
    {
        TerroristEvent asset = (TerroristEvent)CreateAsset("DoVAlpha/GovernmentsDefault/data/events/", typeof(TerroristEvent));
        if (asset != null)
            asset.EventName = "some government";
    }


    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create New Intel Event", false, 101)]
    public static void CreateIntelEvent()
    {
        IntelEvent asset = (IntelEvent)CreateAsset("DoVAlpha/GovernmentsDefault/data/events/", typeof(IntelEvent));
        if (asset != null)
            asset.EventName = "some government";
    }

    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create New Intel Action", false, 101)]
    public static void CreateIntelAction()
    {
        IntelActions asset = (IntelActions)CreateAsset("DoVAlpha/GovernmentsDefault/data", typeof(IntelActions));
        if (asset != null)
            asset.MissionName = "Operation some government";
    }

    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create New Base Contact", false, 101)]
    public static void CreateNewContactn()
    {
        Contact asset = (Contact)CreateAsset("DoVAlpha/GovernmentsDefault/data/contacts/", typeof(Contact));
        if (asset != null)
            asset.ContactName = "a name";
    }

    // -------- duplicate this code block to create your own custom item type --------
    // for more info, see the comments in "vp_CustomType.cs"
    [MenuItem("DOV/Create New Research Item", false, 101)]
    public static void CreateNewResearch()
    {
        ResearchItem asset = (ResearchItem)CreateAsset("DoVAlpha/GovernmentsDefault/data/research/", typeof(ResearchItem));
        if (asset != null)
            asset.ResearchName = "a name";
    }


    /// 
    /// </summary>
    public static Object CreateAsset(string path, System.Type type)
    {

        if (!System.IO.Directory.Exists("Assets/" + path))
        {
            path = "UFPS";
            if (!System.IO.Directory.Exists("Assets/DoVAlpha/Vehicles/data"))
                System.IO.Directory.CreateDirectory("Assets/DoVAlpha/Vehicles/data");
        }

        string fileName = path + "/" + "New " + ((type.Name.StartsWith("DoV_") ? type.Name.Substring(3) : type.Name));

        fileName = NewValidAssetName(fileName);

        Object asset = ScriptableObject.CreateInstance(type);

        AssetDatabase.CreateAsset(asset, "Assets/" + fileName + ".asset");
        if (asset != null)
        {
            EditorGUIUtility.PingObject(asset);
            Selection.activeObject = asset;
        }

        return asset;
    }


    /// <summary>
    /// creates a new filename from a base filename by appending
    /// the next number that will result in a non-existing filename
    /// NOTE: 'baseFileName' should not include "Assets/"
    /// </summary>
    public static string NewValidAssetName(string baseFileName)
    {

        string fileName = baseFileName;

        int n = 1;
        FileInfo fileInfo = null;
        fileInfo = new FileInfo("Assets/" + fileName + ".asset");
        while (fileInfo.Exists)
        {
            n++;
            fileName = fileName.Substring(0, baseFileName.Length) + " " + n.ToString();
            fileInfo = new FileInfo("Assets/" + fileName + ".asset");
        }

        return fileName;

    }


    /// <summary>
    /// creates a new directory name from a base name by appending
    /// the next number that will result in a non-existing dir name
    /// NOTE: 'baseFolderName' should not include "Assets/"
    /// </summary>
    public static string NewValidFolderName(string baseFolderName)
    {

        string folderName = baseFolderName;

        int n = 1;
        DirectoryInfo dirInfo = null;
        dirInfo = new DirectoryInfo("Assets/" + folderName);

        while (dirInfo.Exists)
        {
            n++;
            folderName = folderName.Substring(0, baseFolderName.Length) + ((n < 10) ? "0" : "") + n.ToString();
            dirInfo = new DirectoryInfo("Assets/" + folderName);
        }

        return folderName;

    }


    /// <summary>
    /// 
    /// </summary>
    public static bool CopyValuesFromDerivedComponent(Component derivedComponent, Component baseComponent, bool copyValues, bool copyContent, string prefix, Dictionary<string, object> forcedValues = null)
    {

        System.Type derivedType = derivedComponent.GetType();
        System.Type baseType = baseComponent.GetType();

        if (!IsSameOrSubclass(baseType, derivedType))
            return false;

        foreach (FieldInfo f in baseType.GetFields())
        {

            if (!f.IsPublic)
                continue;

            if (!string.IsNullOrEmpty(prefix) && !f.Name.StartsWith(prefix))
                continue;

            if (forcedValues != null)
            {
                object v = null;
                if (forcedValues.TryGetValue(f.Name, out v))
                {
                    f.SetValue(baseComponent, v);
                    continue;
                }
            }

            if (copyContent &&
                (f.FieldType == typeof(UnityEngine.GameObject) ||
                f.FieldType == typeof(UnityEngine.AudioClip)))
                goto copy;

            if (copyValues && (
                    f.FieldType == typeof(float)
                || f.FieldType == typeof(Vector4)
                || f.FieldType == typeof(Vector3)
                || f.FieldType == typeof(Vector2)
                || f.FieldType == typeof(int)
                || f.FieldType == typeof(bool)
                || f.FieldType == typeof(string)
#if ANTICHEAT
				||	f.FieldType == typeof(ObscuredFloat)
				||	f.FieldType == typeof(ObscuredVector3)
				||	f.FieldType == typeof(ObscuredVector2)
				||	f.FieldType == typeof(ObscuredInt)
				||	f.FieldType == typeof(ObscuredBool)
				||	f.FieldType == typeof(ObscuredString)
#endif
                ))
                goto copy;

            continue;

            copy:

            f.SetValue(baseComponent, derivedType.GetField(f.Name).GetValue(derivedComponent));

            //Debug.Log(f.Name + " (" + f.FieldType + ")");

        }

        return true;

    }



    /// <summary>
    /// determines if type 'potentialDescendant' is derived from or
    /// equal to 'potentialBase'
    /// </summary>
    public static bool IsSameOrSubclass(System.Type potentialBase, System.Type potentialDescendant)
    {
        return potentialDescendant.IsSubclassOf(potentialBase)
               || potentialDescendant == potentialBase;
    }

}
