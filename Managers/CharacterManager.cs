using UnityEngine;
using System.Collections;
using Assets;
using System.Collections.Generic;
using System;

public class CharacterManager : MonoBehaviour
{
    List<Contact> AllGameContacts;
    List<Tuple<CountryToGlobalCountry.GenericCountry, List<Contact>>> GameCountryCharacterManager;

    List<Contact> PlayerSeniorLeaders;
    List<Contact> PlayerMilitaryLeaders;
    List<Contact> PlayerWantedList;
    ContactGenerator PlayerContactGenerator;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetCharactersByProvince() { }
    public void CreateCharacter(ContactGenerator.ContactType contactType)
    {

    }
    public void CreateHostileActor() { }

    public void AddToTerroristList() { }
    public void AddToWatchList() { }
    public void RemoveCharacter() { }
}
