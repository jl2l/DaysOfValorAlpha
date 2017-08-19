using UnityEngine;
using System.Collections;
using Assets;
using System.Collections.Generic;

[System.Serializable]

public class Deal : ScriptableObject
{
    public enum DealFor { Buy, Sell, Transfer, Hold }

//    he following are not necessarily the best Forex pairs to trade, but they are the ones that have high liquidity and occupy the most foreign exchange transactions:
//EUR/USD(Euro - US dollar)
//USD/JPY(US dollar - yen)
//GBP/USD(GB pound - US dollar)
//AUD/USD(Australian dollar - US dollar)
//USD/CHF(US dollar - Swiss franc)
    public enum DealType
    {
        Treaty,
        Accord,
        Convention,
        Alliance,
        FMS,
        SectorTrade,
        Currency,
        Advisors,
        StateVisit,
        MilitaryCoop,
        Expel,
        Embassy,
        NoFlyZone,
        PeaceKeepers,
        AirRelief,
        Embargo,
        Sanctions,

    }
    public string DealName { get; set; }
    public DealType TypeOfDeal { get; set; }
    public DealFor TypeOfDealFor { get; set; }

    public CountryToGlobalCountry.GenericCountry TransferSoverightyTo { get; set; }
    public bool RequiresPopularSupport { get; set; }
    public bool IsExileDeal { get; set; }
    public List<CountryToGlobalCountry.GenericCountry> PartyA { get; set; }
    public List<CountryToGlobalCountry.GenericCountry> PartyB { get; set; }
    /// <summary>
    /// this is used for transfering province from party a to b, enforce noflyzone over provinces, peacekeepers to provinces, aid relief to provinces
    /// </summary>
    public List<CountryToGlobalCountry.GenericProvince> TransferProvince { get; set; }
    public List<DoV_Vehicle> TransferMilitaryHardware { get; set; }
    public List<Contact> TransferAdvisors { get; set; }

    /// <summary>
    /// Used for trade deal, sanctions on a sector, embargo on a sector, 
    /// </summary>
    public SectorManager.Sectors DealSector { get; set; }
    public long HardCurrency { get; set; }
}