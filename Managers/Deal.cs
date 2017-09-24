using UnityEngine;
using System.Collections;
using Assets;
using System.Collections.Generic;

[System.Serializable]

public class Deal : ScriptableObject
{
    public enum DealFor { Buy, Sell, Transfer, Hold, Aid }

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
        AidRelief,
        Embargo,
        Sanctions,
        DeclareWar

    }
    public string DealName;
    public DealType TypeOfDeal;
    public DealFor TypeOfDealFor;

    public int DealStartDate;
    public int DealStartMonth;
    public int DealStartYear;
    public int DealEndDate;
    public int DealEndMonth;
    public int DealEndYear;
    public bool IsDealExpired;
    public bool IsDealEnforced;
    public bool RequiresPopularSupport;
    public bool IsExileDeal;
    public CountryToGlobalCountry.GenericCountry TransferSoverightyTo;
    public List<CountryGovernment> PartyA;
    public List<CountryGovernment> PartyB;
    //for sanctions and declaring war against
    public List<CountryGovernment> PartyC;
    /// <summary>
    /// this is used for transfering province from party a to b, enforce noflyzone over provinces, peacekeepers to provinces, aid relief to provinces
    /// </summary>
    public List<CountryToGlobalCountry.GenericProvince> TransferProvince;
    public List<CountryMilitary.MilitaryInventory> TransferMilitaryHardware;
    public List<AdvisorAgent> TransferAdvisorsTeam;
    public List<SpecialOperationsTeam> TransferSpecialForcesTeam;
    public List<Contact> ExileList;

    public long HardCurrency;

    /// <summary>
    /// Used for trade deal, sanctions on a sector, embargo on a sector, 
    /// </summary>
    public SectorManager.CountryResource DealSector;
    public float ShareBuyPrice;
    public CountrySectors DealMarket;

    public List<WorldEvent> CountryDealEvents;
    public List<DiplomaticEvent> DiplomaticDealEvents;
    public List<CulturalEvent> GovernmentCulturalDealEvents;
    public List<IntelEvent> GovernmentIntelDealEvents;
    public List<NewsEvent> GovernmentNewsDealEvents;
    public List<TerroristEvent> GovernmentTerroristDealEvents;
    public List<UprisingEvent> GovernmentUprisingDealEvents;


}