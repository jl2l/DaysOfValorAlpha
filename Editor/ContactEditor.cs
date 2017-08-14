using UnityEngine;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using Assets;
using static Assets.ContactGenerator;


[CustomPropertyDrawer(typeof(Contact))]
public class ContactEditor : Editor
{
    [ContextMenuItem("Randomize Name", "Randomize")]
    public string ContactName;
    public string NameRegion;
    public Subregions ContactSubregion;

    private void Randomize()
    {
        NameRegion = ContactSubregion.ToDescription();
        ContactName = ContactGenerator.GenerateARegionName(ContactGenerator.ContactGender.male, NameRegion);
    }
}


[CustomPropertyDrawer(typeof(RangeAttribute))]
public class RangeDrawer : PropertyDrawer
{

    // Draw the property inside the given rect
    void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {

        // First get the attribute since it contains the range for the slider
        RangeAttribute range = attribute as RangeAttribute;

        // Now draw the property as a Slider or an IntSlider based on whether it's a float or integer.
        if (property.propertyType == SerializedPropertyType.Float)
            EditorGUI.Slider(position, property, range.min, range.max, label);
        else if (property.propertyType == SerializedPropertyType.Integer)
            EditorGUI.IntSlider(position, property, (int)range.min, (int)range.max, label);
        else
            EditorGUI.LabelField(position, label.text, "Use Range with float or int.");
    }
}

public class RangeAttribute : PropertyAttribute
{
    public float min;
    public float max;

    public RangeAttribute(float min, float max)
    {
        this.min = min;
        this.max = max;
    }
}
