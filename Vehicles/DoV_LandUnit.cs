using UnityEngine;
using System.Collections;

public class DoV_LandUnit : MonoBehaviour
{

    public string str_Name;

    // 1: Tank.
    // 2: Anti-Aircraft Gun.
    // 3: Anti-Aircraft Missile.
    public int unitType;

    Transform pos_View;
    Ctrl_MainView_FA view;
    Ctrl_WingCommander_FA wingCommand;

    public int signal_IsDestroyed;
    public int signal_IsEnemy;

    public int statusLandUnit;
    public int viewNum_LandUnit;

    public float hitpoint = 100f;


    Transform point_ViewOperationField;


    // Use this for initialization
    void Start()
    {

        pos_View = GameObject.Find("MainView_FA").GetComponent<Transform>();
        view = GameObject.Find("MainView_FA").GetComponent<Ctrl_MainView_FA>();
        wingCommand = GameObject.Find("WingCommander_FA").GetComponent<Ctrl_WingCommander_FA>();

        point_ViewOperationField = GameObject.Find("point_ViewOperationField").GetComponent<Transform>();

        statusLandUnit = 1;

        if (signal_IsEnemy == 0)
        {
            // Initialize the Ourforces Aircraft ID.
            viewNum_LandUnit = wingCommand.UnregisteredNumber_LandUnit();

            wingCommand.unitOn_LandUnit[viewNum_LandUnit] = 1;
            wingCommand.status_LandUnit[viewNum_LandUnit] = 1;
            wingCommand.transform_LandUnit[viewNum_LandUnit] = transform;
            wingCommand.affiliatedGroup_LandUnit[viewNum_LandUnit] = 1;
            wingCommand.initNum_LandUnit_OurForces += 1;
            wingCommand.totalNum_LandUnit_OurForces += 1;
        }
        else
        {
            // Initialize the Ourforces Aircraft ID.
            viewNum_LandUnit = wingCommand.UnregisteredNumber_LandUnit();

            wingCommand.unitOn_LandUnit[viewNum_LandUnit] = 1;
            wingCommand.status_LandUnit[viewNum_LandUnit] = 1;
            wingCommand.transform_LandUnit[viewNum_LandUnit] = transform;
            wingCommand.affiliatedGroup_LandUnit[viewNum_LandUnit] = 2;
            wingCommand.initNum_LandUnit_Enemy += 1;
            wingCommand.totalNum_LandUnit_Enemy += 1;

        }

        UpdateInformationToWingCommandInfo();
    }

    public Texture image_Mark;
    public Texture image_TargetGreen;
    public Texture image_TargetRed;
    int size_TI = Screen.height * 1 / 25;
    void OnGUI()
    {

        if (view.viewFrom == 1)
        {

            GUIStyle styleInfo;
            styleInfo = new GUIStyle();
            styleInfo.richText = true;
            styleInfo.fontSize = Screen.height * 1 / 45;
            styleInfo.fontStyle = FontStyle.Bold;
            styleInfo.normal.textColor = Color.white;
            //			GUIContent contentInfo = new GUIContent (str_TargetName);
            //			Vector2 sizeInfo = styleInfo.CalcSize (contentInfo);

            GUIStyle styleForm;
            styleForm = new GUIStyle();
            styleForm.richText = true;
            styleForm.fontSize = Screen.height * 1 / 75;
            //styleForm.fontStyle = FontStyle.Bold;
            if (signal_IsEnemy == 0)
                styleForm.normal.textColor = Color.green;
            else
                styleForm.normal.textColor = Color.red;
            //GUIContent contentForm = new GUIContent ("xx");
            //Vector2 sizeForm = styleForm.CalcSize (contentForm);

            //----------------------------------------------------------------------------------------------------
            // Target Indicator.
            Vector3 pos_OnScreen = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 pos_TargetName;
            pos_TargetName.x = pos_OnScreen.x;
            pos_TargetName.y = pos_OnScreen.y;
            pos_TargetName.z = pos_OnScreen.z;

            Vector3 toTargetFromView;
            toTargetFromView = pos_View.position - transform.position;

            // In front of View.
            if (Vector3.Dot(toTargetFromView, pos_View.forward) <= 0)
            {
                // Out of Screen.
                if (pos_OnScreen.x < size_TI / 2 || pos_OnScreen.x > Screen.width - size_TI / 2 || pos_OnScreen.y < size_TI / 2 || pos_OnScreen.y > Screen.height - size_TI / 2)
                {
                    if (pos_OnScreen.x < size_TI / 2)
                    {
                        pos_OnScreen.x = size_TI / 2;
                        pos_OnScreen.y = (Camera.main.WorldToScreenPoint(transform.position).y - Screen.height / 2) /
                            (Camera.main.WorldToScreenPoint(transform.position).x - Screen.width / 2) * (pos_OnScreen.x - Screen.width / 2)
                            + Screen.height / 2;
                    }
                    if (pos_OnScreen.x > Screen.width - size_TI / 2)
                    {
                        pos_OnScreen.x = Screen.width - size_TI / 2;
                        pos_OnScreen.y = (Camera.main.WorldToScreenPoint(transform.position).y - Screen.height / 2) /
                            (Camera.main.WorldToScreenPoint(transform.position).x - Screen.width / 2) * (pos_OnScreen.x - Screen.width / 2)
                            + Screen.height / 2;

                    }

                    if (pos_OnScreen.y < size_TI / 2)
                    {
                        pos_OnScreen.y = size_TI / 2;
                        pos_OnScreen.x = (Camera.main.WorldToScreenPoint(transform.position).x - Screen.width / 2) /
                            (Camera.main.WorldToScreenPoint(transform.position).y - Screen.height / 2) * (pos_OnScreen.y - Screen.height / 2)
                            + Screen.width / 2;
                    }
                    if (pos_OnScreen.y > Screen.height - size_TI / 2)
                    {
                        pos_OnScreen.y = Screen.height - size_TI / 2;
                        pos_OnScreen.x = (Camera.main.WorldToScreenPoint(transform.position).x - Screen.width / 2) /
                            (Camera.main.WorldToScreenPoint(transform.position).y - Screen.height / 2) * (pos_OnScreen.y - Screen.height / 2)
                            + Screen.width / 2;
                    }

                }
                // In Screen.
                else
                {
                    if (signal_IsDestroyed == 0)
                    {
                        if (Vector3.Distance(transform.position, view.transform.position) > 150f)
                        {
                            if (signal_IsEnemy == 0)
                            {
                                GUI.DrawTexture(new Rect(pos_OnScreen.x - size_TI * 2 / 3 / 2, Screen.height - pos_OnScreen.y - size_TI * 2 / 3 / 2, size_TI * 2 / 3, size_TI * 2 / 3),
                                    image_TargetGreen, ScaleMode.StretchToFill, true, 0);
                            }
                            else
                            {
                                GUI.DrawTexture(new Rect(pos_OnScreen.x - size_TI * 2 / 3 / 2, Screen.height - pos_OnScreen.y - size_TI * 2 / 3 / 2, size_TI * 2 / 3, size_TI * 2 / 3),
                                    image_TargetRed, ScaleMode.StretchToFill, true, 0);
                            }
                            // Name.
                            GUI.Label(new Rect(pos_OnScreen.x - size_TI * 0.5f, Screen.height - pos_OnScreen.y - size_TI, size_TI * 3, size_TI), str_Name, styleForm);

                        }

                    }
                }
            }
        }
    }

    // Destroyed aircraft Event.
    int callOneTimeWingCommandInfo = 1;
    public void DestroyedLandUnit()
    {

        if (signal_IsDestroyed == 1)
        {
            if (hitpoint != 0)
                hitpoint = 0;

            if (callOneTimeWingCommandInfo == 1)
            {
                statusLandUnit = -1;

                // Update WingCommand Information.
                UpdateInformationToWingCommandInfo();

                // Reset Wingcommand Info.
                wingCommand.status_LandUnit[viewNum_LandUnit] = statusLandUnit;
                wingCommand.myAirTargetID_LandUnit[viewNum_LandUnit] = 0;
                wingCommand.haveAirTarget_LandUnit[viewNum_LandUnit] = 0;

                if (signal_IsEnemy == 0)
                {
                    wingCommand.totalNum_LandUnit_OurForces -= 1;
                }
                else
                {
                    wingCommand.totalNum_LandUnit_Enemy -= 1;
                }

                callOneTimeWingCommandInfo = 0;
            }
        }
    }

    void HP_Manager()
    {

        if (hitpoint <= 0)
        {
            signal_IsDestroyed = 1;
        }
    }

    // Update WingCommand Information
    // Send the information from Aircraft to WingCommand.
    void UpdateInformationToWingCommandInfo()
    {

        // Update status at WingCommand
        wingCommand.status_LandUnit[viewNum_LandUnit] = statusLandUnit;
    }

    Vector3 newViewPos = new Vector3();
    void View_Manager()
    {

        // OurForces
        if (signal_IsEnemy == 0)
        {
            if (viewNum_LandUnit == wingCommand.selectedViewNum_LandUnit && wingCommand.view_Group == 3)
            {
                if (view.viewFrom == 1)
                {
                    // 3rd View.
                    pos_View.position = Vector3.Lerp(pos_View.position, transform.TransformPoint(Vector3.up * 15f + Vector3.forward * (-60f)), Time.deltaTime * 4f);
                    pos_View.rotation = transform.rotation;

                    // Operation Field View.
                    if (view.camPos == 120)
                    {
                        newViewPos.x = transform.position.x;
                        newViewPos.y = 15000f;
                        newViewPos.z = transform.position.z;

                        view.transform.position = newViewPos;
                        view.transform.rotation = point_ViewOperationField.rotation;
                    }
                }
            }
        }
        // Enemy
        else
        {
            if (viewNum_LandUnit == wingCommand.selectedViewNum_LandUnit && wingCommand.view_Group == 3)
            {
                if (view.viewFrom == 1)
                {
                    // 3rd View.
                    pos_View.position = Vector3.Lerp(pos_View.position, transform.TransformPoint(Vector3.up * 15f + Vector3.forward * (-60f)), Time.deltaTime * 4f);
                    pos_View.rotation = transform.rotation;

                    // Operation Field View.
                    if (view.camPos == 120)
                    {
                        newViewPos.x = transform.position.x;
                        newViewPos.y = 15000f;
                        newViewPos.z = transform.position.z;

                        view.transform.position = newViewPos;
                        view.transform.rotation = point_ViewOperationField.rotation;
                    }
                }
            }
        }
    }



    //-----------------------------------------------------------------------------------------
    // Manage the collision
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Bullet")
        {
            if (signal_IsDestroyed == 0)
            {
                hitpoint -= Random.Range(5f, 10f);

            }

        }
        if (other.gameObject.tag == "Bomb" || other.gameObject.tag == "Rocket")
        {
            hitpoint = 0;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        DestroyedLandUnit();
        View_Manager();
        HP_Manager();

    }
}
