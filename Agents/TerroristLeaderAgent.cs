using System.Collections;
using Assets;

public class TerroristLeaderAgent : Contact
{

    /// <summary>
    /// How much influence does this person have in the government and population at large
    /// </summary>
    public int DiplomaticInfluence { get; set; }
    public int DiplomaticIntelligence { get; set; }
    public int DiplomaticTact { get; set; }
    public int DiplomaticRapport { get; set; }
    public int DiplomaticLuck { get; set; }
    public bool IsAmbassdor { get; set; }
    public bool IsCoverAgent { get; set; }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
