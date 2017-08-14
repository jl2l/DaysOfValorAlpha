using System;
using UnityEngine.Events;

public class IntelActions : GameAction
{
    public string MissionName;
    public enum SecurityLevels
    {
        TOPSECRET,
        SECRET,
        CONFIDENTIAL
    }

   
    public UnityEvent ActionEvent;
    public UnityEvent OutCome;

    public bool IsIllegal;
    public enum IntelActionType {
        RecruitHUMINT,
        Assassinate,
        CyberIntel,
        Sabotage,
        CyberAttack,
        AirRebelGroup,
        FormRebelGroup,
        Coup,
        Subverison
    }

    public IntelActionType ActionType;
}