using System.Collections;
using Assets;

public class TerroristLeaderAgent : Contact
{

    /// <summary>
    /// How much influence does this person have in the government and population at large
    /// </summary>
    public int Brutality;
    public int Charisma;
    public int Idealogy;
    public int MilitaryEffective;
    public int PoliticalEffective;
    public float PopularSupport;
    public Contact Deputy;
    public bool RandomDeputy;

    public bool IsRebelPuppet;
    public CountryToGlobalCountry.GenericCountry Patron { get; set; }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
