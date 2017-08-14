using UnityEngine;
using System.Collections;

/// <summary>
/// Logic for this is if your married then describe your kids, if your not married describe your family.
/// </summary>
[System.Serializable]
public class Family
{
    public bool IsFatherDeceased;
    public bool IsMotherDeceased;
    public bool IsOnlyChild;
    public bool IsMarried;
    public int SisterCount;
    public int BrotherCount;
    public int ChildrenCount;
}

