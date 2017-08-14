using UnityEngine;
using System.Collections;
using static Assets.ContactGenerator;

/// <summary>
/// The gene profile.
/// </summary>
[System.Serializable]
public class GeneProfile
{

    
    /// <summary>
    /// Gets or sets the gender.
    /// </summary>
    public ContactGender Sex;

    /// <summary>
    /// Gets or sets the country of origin.
    /// </summary>
    public string CountryOfOrigin;

    /// <summary>
    /// Gets or sets the birth month.
    /// </summary>
    public int BirthMonth;

    /// <summary>
    /// Gets or sets the home town.
    /// </summary>
    public string HomeTown;

    /// <summary>
    /// True straight false gay
    /// </summary>
    public bool IsStraight;
}
