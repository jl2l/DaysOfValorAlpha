using UnityEngine;
using System.Collections;


[System.Serializable]
public class UprisingEvent : WorldEvent
{
    public enum UprisingStage
    {
        civilprotestStage1,
        civilprotestStage2,
        civilprotestStage3,
        civilprotestStage4,
        civilprotestStage5,
        civilResistanceStage1,
        civilResistanceStage2,
        civilResistanceStage3,
        civilResistanceStage4,
        civilStrikesStage1, //local strikes
        civilStrikesStage2, //province strikes,
        civilStrikesStage3, //country strikes
        tippingPoint

    }

    public enum PeacefulUprisingStage
    {
        RefferedumVote,
        VoteYes,
        VoteNo,
        Negioations,
        InternationalReconized,
        NewGovernmentFormed

    }

    public enum ArmedUprisingStage
    {
        PalaceCoup,
        MilitayCoup,
        ArmedProtest,
        Insurrection,
        OpenRevoltCities,
        OpenRevoltProvinces,
        OpenRevoltState,
        RebelControl,
        RebelState,
        InternationalReconized,
        NewGovernmentFormed
    }
}