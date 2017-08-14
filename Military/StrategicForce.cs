using UnityEngine;
using System.Collections;
using Assets;
using System.Collections.Generic;
using System.ComponentModel;

[System.Serializable]
public class StrategicForce : ScriptableObject
{
    public enum DefconLevel
    {
        DEFCONZero = 0,
        DEFCONOne = 1,
        DEFCONTwo = 2,
        DEFCONThree = 3,
        DEFCONFour = 4,
        DEFCONFive = 5,
    }

    public enum COGCONLevel
    {
        [Description("Activate classified CONPLAN 3600 evacuating the President and those in the line of presidential succession. Activate classified CONPLAN 3502 deploying the military to enforce law and order within the Civilian Control Districts. Seize all private communication facilities and assume control over all civilian voice and data communications. Activate internet kill switch under SOP 303. Commandeer all U.S. domestic resources including food and water. Seize all domestic energy and transportation infrastructure. Deploy the national citizen conscription plan to fulfill any labor required for the purpose of national defense and reconstitution.")]
        COGCONZero = 0,
        [Description("Full deployment of designated leadership and continuity staffs to perform the organization’s essential functions from alternate facilities either as a result of, or in preparation for, a catastrophic emergency.")]
        COGCONOne = 1,
        [Description("Routine protective security measures appropriate to the business concerned.Deployment of 50-75% of Emergency Relocation Group continuity staff to alternate locations. Establish their ability to conduct operations and prepare to perform their organization’s essential functions in the event of a catastrophic emergency.")]
        COGCONTwo = 2,
        [Description("Federal agencies and departments Advance Relocation Teams “warm up” their alternate sites and capabilities, which include testing communications and IT systems. Ensure that alternate facilities are prepared to receive continuity staff. Track agency leaders and successors daily.")]
        COGCONThree = 3,
        [Description("Federal executive branch government employees at their normal work locations. Maintain alternate facility and conduct periodic continuity readiness exercises.")]
        COGCONFour = 4,
    }

    public enum ThreatResponse
    {
        [Description("Routine protective security measures appropriate to the business concerned.")]
        Normal,
        [Description("Additional and sustainable protective security measures reflecting the broad nature of the threat combined with specific business and geographical vulnerabilities and judgements on acceptable risk.")]
        Heightened,
        [Description("Maximum protective security measures to meet specific threats and to minimise vulnerability and risk. Critical may also be used if a nuclear attack is expected.")]
        Exceptional
    }
    public enum ThreatLevel
    {
        [Description("An attack is very unlikely.")]
        Low,
        [Description("An attack is possible, but not likely.")]
        Moderate,
        [Description("An attack is a strong possibility.")]
        Substantial,
        [Description("An attack is highly likely.")]
        Severe,
        [Description("An attack is expected imminently.")]
        Critical
    }


    List<Weapon> WMDList;
}