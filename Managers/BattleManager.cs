using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Assets;
using System;

public class BattleManager : MonoBehaviour
{

    /// <summary>
    /// Managers all of the combatants in the conflict a combatant is a country, and its decks
    /// </summary>
    public List<Tuple<CountryToGlobalCountry.GenericCountry, List<DeckDataItem>>> BattleSpaceManager;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
