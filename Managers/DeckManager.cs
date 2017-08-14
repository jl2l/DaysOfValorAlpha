using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets;

using System.Linq;
using System;

public class DeckManager : MonoBehaviour
{
    public List<DeckDataItem> PlayerDecks;


    /// <summary>
    /// A list of all the countries known decks, the country can keep a virtual number of decks maxxed
    /// hidden from the player, these decks in memory can be uncovered via intel and then added to this list MilitaryPowerScore
    /// </summary>
    List<Tuple<CountryToGlobalCountry.GenericCountry, List<DeckDataItem>>> WorldDeckList;

    public Texture2D Rank1Icon { get; internal set; }
    public Texture2D Rank2Icon { get; internal set; }
    public Texture2D Rank3Icon { get; internal set; }
    public Texture2D Rank4Icon { get; internal set; }
    public Texture2D DefaultDeckIcon { get; internal set; }
    public Texture2D Rank5Icon { get; internal set; }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public DeckDataItem GetDeckByName(string deckName)
    {
        return PlayerDecks.FirstOrDefault(e => e.DeckName == deckName);
    }
    public List<DeckDataItem> GetDecksByType(DeckFactory.DeckType deckType)
    {
        return PlayerDecks.Where(e => e.DeckType == deckType).ToList();
    }
    public Contact GetDeckCommander(DeckDataItem deck) {
        return deck.DeckCommander;
    }
    public void AddDeckPlayerDeck(DeckDataItem deck) {
        PlayerDecks.Add(deck);
        //Trigger add effect animations
    }
    public void SaveDecks(MilitaryManager GameMilitaryManager) {

        //PlayerDecks.ForEach(MilitaryDecks => {
        //    GameMilitaryManager.PlayerMilitaryList.Add(new Tuple<List<DeckDataItem>,Vector2>(MilitaryDecks, MilitaryDecks.DeckCurrentWorldLocation));
        //    if (MilitaryDecks.)
        //});
    }
    public void DestroyDeck(List<DeckDataItem> DeckList, DeckDataItem deckDestroy) {

        DeckList.RemoveAll(e => e.DeckName == deckDestroy.DeckName);
    }
    public void AddUnitToDeck(DoV_Vehicle vehicle, DeckDataItem deck) {
        deck.VehiclesInDeck.Add(vehicle);
    }
}
