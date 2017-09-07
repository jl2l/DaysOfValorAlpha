using UnityEngine;
using System.Collections;
using Assets;
using System.Collections.Generic;
using WorldMapStrategyKit;
using System.Linq;

[System.Serializable]
public class SpecialOperationsTeam : ScriptableObject
{



    public float UnitExp;
    public int UnitMissionsComplete;
    public float UnitHealth;
    public float UnitMorale;
    [Tooltip("The Total number of guys in the team, this will determine how many are generated")]
    public int UnitSize;
    [Tooltip("The likelyhood of completing there mission.")]
    [Range(0.0f, 100.0f)]
    public float UnitEffectiveness;

    public Texture2D TeamFlag;
    public Texture2D Insigna;
    public string TeamName;
    public long TeamCountryIndex;
    public string TeamCountryName;
    public string TeamCountryRegion;
    public string TeamHomeBase;

    public Vector2 TeamLocation;
    public List<KitType> TeamBaseConfig;
    public List<TeamSpecialization> Skill;
    [ContextMenuItem("Build Squad", "BuildTeam")]

    public List<Operator> TeamSquad;

    private void BuildTeam()
    {
        var keeepers = TeamSquad.Where(e => !e.Teammate.DoNotDelete);
        TeamSquad.Clear();
        var cg = new ContactGenerator();
        var country = WMSK.instance.GetCountry(TeamCountryName);
        TeamCountryRegion = country.continent;
        TeamCountryIndex = WMSK.instance.GetCountryIndex(TeamCountryName);
        //60 in unit / 10 man squad
        //6 squads random names for each

        var SquadSize = UnitSize / TeamBaseConfig.Count;

        TeamSquad = cg.GenerateSpecialOpsTeam(SquadSize, TeamBaseConfig, TeamCountryName, TeamCountryRegion);
        TeamSquad.AddRange(keeepers);
    }

    public Contact TeamCommander;
}

