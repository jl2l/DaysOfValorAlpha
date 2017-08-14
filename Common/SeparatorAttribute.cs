/////////////////////////////////////////////////////////////////////////////////
//
//	SeparatorAttribute.cs
//	© Opsive. All Rights Reserved.
//	https://twitter.com/Opsive
//	http://www.opsive.com
//
//	description:	editor class for rendering an Inspector separator
//
/////////////////////////////////////////////////////////////////////////////////

#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;


/// <summary>
/// 
/// </summary>
[System.Serializable]
public class Separator
{
}


/// <summary>
/// 
/// </summary>
public class SeparatorAttribute : PropertyAttribute
{
    public SeparatorAttribute() { }
}


/// <summary>
/// 
/// </summary>
[CustomPropertyDrawer(typeof(SeparatorAttribute))]
public class SeparatorDrawer : PropertyDrawer
{

    /// <summary>
    /// 
    /// </summary>
    public override void OnGUI(Rect pos, SerializedProperty prop, GUIContent label)
    {

       PropertyDrawerUtility.Separator(pos);

    }

}


#endif