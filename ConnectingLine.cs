using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class ConnectingLine : MonoBehaviour
{
    public UILineRenderer RenderLiner;
    public GameObject Target;
    public GameObject UIBox;
    //this is the ui element
    RectTransform UI_Element;
    RectTransform CanvasRect;
    //this is your object that you want to have the UI element hovering over
    GameObject WorldObject;
    // Use this for initialization
    void Start()
    {
        if (Target != null)
        {
            RectTransform CanvasRect = Target.GetComponent<RectTransform>();
            RenderLiner.Points.ToList().Add(CanvasRect.position);
        }
        //first you need the RectTransform component of your canvas
        if (UIBox != null)
        {
            RectTransform CanvasRect = UIBox.GetComponent<RectTransform>();
            RenderLiner.Points.ToList().Add(CanvasRect.position);
        }

    }







    // Update is called once per frame
    void Update()
    {
        //then you calculate the position of the UI element
        //0,0 for the canvas is at the center of the screen, whereas WorldToViewPortPoint treats the lower left corner as 0,0. Because of this, you need to subtract the height / width of the canvas * 0.5 to get the correct position.

        //var gun = FindObjectOfType<GunController>().GripMarker;
        //Target = gun;

        if (Target != null)
            RenderLiner.Points[0].Set(Target.transform.position.x, Target.transform.position.y);
        if (UIBox != null)
            RenderLiner.Points[1].Set(UIBox.transform.position.x, UIBox.transform.position.y);
    }
}