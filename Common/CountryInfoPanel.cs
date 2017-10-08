using System.Collections;
using System.Collections.Generic;
using UIWidgets;
using UnityEngine;
using UnityEngine.UI;

public class CountryInfoPanel : MonoBehaviour
{

    public GameObject CountryAccordion;
    public Text GovernmentName;
    public Text CaptialName;

    public Text CountryNationals;
    public Text CountryFounding;
    public GameObject CountryMoreDetailsPanel;
    public Texture2D CountryFlag;



    public Progressbar PlayerPopulationTrustLevel;


    public Progressbar CountryPopulationTrustLevel;
    //MilitaryToGovernmentTrustLevel
    //    GovernmentToMilitaryTrustLevel
    //    PoliticalStability

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
