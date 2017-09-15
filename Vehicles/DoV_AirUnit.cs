using UnityEngine;
using System.Collections;

public class DoV_AirUnit : MonoBehaviour
{

    //==============================================================================
    // Main Constructions
    // 1. Initialization Part (value, variable, reference points, Etc.)
    // 2. GUI Part(References)
    // 3. General Flight Part
    // 4. Flight Function Part(Dogfight, Bombing, Formation Flight, Custom Flight)
    // 5. Order and Receive Part
    // 6. Sound, View, Velocity, HP, Flight Manager, Etc Part
    //==============================================================================

    //==============================================================================
    // 1. Initialization Part
    //==============================================================================

    public string str_Name;
    // 0: Propeller fighter.
    // 1: Bomber.
    // 2: Jet fighter.
    // 3: Helicopter.
    [Range(0, 4)] public int type_Aircraft;
    // Pilot-Level
    // 0: Random
    // 1: Recruit
    // 2: Middle Class
    // 3: Ace
    [Range(0, 3)] public int level_Pilot;
    float init_Pilotage;
    float pilotage;
    // Be decided by WingCommand
    //  0: Return/Combat-Ready
    //  1: Taking off
    // -1: Landing
    //  2: DogFight
    //  3: Bombing
    //  4: Formation Flight
    [Range(-1, 10)] public int flightOrder = 0;
    // -1: Land 
    //  1: Air
    // -2: Crashed on Land
    // -3: Falling Down from the sky
    public int statusFlight;
    public int aircraftGroup;
    // 0: Not Leader
    // 1: Is Leader
    public int signal_IsFormationLeader;
    public int num_Formation;
    public int num_FormationOrder;
    // Hit-Point
    public float hitpoint;
    public int viewNum_OurForces = 0;
    public int viewNum_Enemy = 0;
    // 0: Basic Type         _-_-_
    // 1: Rush Type           _-_
    // 2: Following Type       I
    public int formationType;
    // 0: Our forces
    // 1: The Enemy
    public int signal_IsEnemy;
    public int signal_DoEvasiveFlight = 0;
    public int signal_Dismiss;
    int rndFallingLR;
    // General
    Rigidbody m_rigidbody;
    float velocity_Standard;
    public float velocityAircraft;
    [Range(0f, 450f)] public float velocityAdvanced = 0;
    float velocityEffectByGravity = 0;
    float velocityInAirport;
    float maxAircraftVelocity = 450f;
    public float throttle_Aircraft;
    public int signal_InAirport;
    public int signal_LandingGearOn = 0;
    Ctrl_WingCommander_FA wingCommand;
    Transform pos_View;
    Ctrl_MainView_FA view;
    // General Points
    public Transform point_Left, point_Right, point_Front, point_Behind, point_Up, point_Down;
    public Transform point_GunLeft, point_GunRight, point_Bomb, point_RocketLeft, point_RocketRight, point_RaycastL, point_RaycastM, point_RaycastR;
    // View Points
    public Transform point_3rdView, point_CockpitView;
    // Wheel points;
    public Transform point_LeftWingWheel, point_RightWingWheel, point_TailWheel;
    // Environment Points.
    Transform point_FieldCenter, point_LandZero, point_RunwayZero, point_ViewOperationField;
    Transform point_TL1, point_TL2, point_TL3, point_TL4, point_TL5, point_Return, point_BombingTarget, point_MainTarget;
    // Weapons.
    public GameObject bullet;
    public GameObject bomb;
    public GameObject rocket;
    // Modern aircraft only.
    public GameObject flare;
    // Destroying Effects
    public GameObject effect_Smoke;
    public GameObject effect_Fire;
    public GameObject effect_MuzzleFlashL;
    public GameObject effect_MuzzleFlashR;
    public GameObject effect_Fragments;
    // Sound
    public AudioClip engineSoundClip;
    AudioSource engineSoundSource;
    public AudioClip gunFireSoundClip;
    AudioSource gunFireSoundSource;
    public AudioClip explosionSoundClip;
    AudioSource explosionSoundSource;
    // The min distance of the engine audio source.
    public float engineMinDistance = 10f;
    // The max distance of the engine audio source.
    [Range(100f, 500f)] public float engineMaxDistance = 300f;
    // The doppler level of the engine audio source.
    [Range(0f, 10f)] public float engineDopplerLevel = 5f;
    // An overall 
    [Range(0f, 1f)] public float engineMasterVolume = 0.5f;
    // The min distance of the engine audio source.
    public float gunFireMinDistance = 10f;
    // The max distance of the engine audio source.
    [Range(100f, 300f)] public float gunFireMaxDistance = 300f;
    // The doppler level of the engine audio source.
    public float gunFireDopplerLevel = 5f;
    // An overall 
    [Range(0f, 1f)] public float gunFireMasterVolume = 1f;
    // Pitch of the engine sound when at minimum throttle.
    [SerializeField] private float engineMinThrottlePitch = 0.0f;
    // Pitch of the engine sound when at maximum throttle.
    [SerializeField] private float engineMaxThrottlePitch = 3f;
    // Additional multiplier for an increase in pitch of the engine from the plane's speed.
    [SerializeField] private float engineFwdSpeedMultiplier = 0.0005f;
    // Use this for initialization
    void Awake()
    {

        m_rigidbody = GetComponent<Rigidbody>();
        wingCommand = GameObject.Find("WingCommander_FA").GetComponent<Ctrl_WingCommander_FA>();
        pos_View = GameObject.Find("MainView_FA").GetComponent<Transform>();
        view = GameObject.Find("MainView_FA").GetComponent<Ctrl_MainView_FA>();
        // Engine sound of Aircraft.
        engineSoundSource = gameObject.AddComponent<AudioSource>();
        engineSoundSource.clip = engineSoundClip;
        engineSoundSource.Play();
        engineSoundSource.minDistance = 1;
        engineSoundSource.maxDistance = 5000;
        engineSoundSource.loop = true;
        engineSoundSource.dopplerLevel = 1;
        engineSoundSource.rolloffMode = AudioRolloffMode.Linear;

        gunFireSoundSource = gameObject.AddComponent<AudioSource>();
        gunFireSoundSource.clip = gunFireSoundClip;
        gunFireSoundSource.Play();
        gunFireSoundSource.volume = 0;
        gunFireSoundSource.minDistance = 1;
        gunFireSoundSource.maxDistance = 3500;
        gunFireSoundSource.loop = true;
        gunFireSoundSource.dopplerLevel = 1;
        gunFireSoundSource.rolloffMode = AudioRolloffMode.Linear;

        explosionSoundSource = gameObject.AddComponent<AudioSource>();
        explosionSoundSource.clip = explosionSoundClip;
        explosionSoundSource.loop = false;
        explosionSoundSource.rolloffMode = AudioRolloffMode.Linear;

        // Falling Down Aircraft Effects by Burning.
        effect_Smoke.SetActive(false);
        effect_Fire.SetActive(false);
        effect_MuzzleFlashL.SetActive(false);
        effect_MuzzleFlashR.SetActive(false);

        // Init. points.
        point_FieldCenter = GameObject.Find("point_FieldCenter").GetComponent<Transform>();
        point_Return = GameObject.Find("point_FieldCenter").GetComponent<Transform>();
        point_BombingTarget = GameObject.Find("point_FieldCenter").GetComponent<Transform>();
        point_LandZero = GameObject.Find("point_LandZero").GetComponent<Transform>();
        point_RunwayZero = GameObject.Find("point_RunwayZero").GetComponent<Transform>();

        point_TL1 = GameObject.Find("point_TL1").GetComponent<Transform>();
        point_TL2 = GameObject.Find("point_TL2").GetComponent<Transform>();
        point_TL3 = GameObject.Find("point_TL3").GetComponent<Transform>();
        point_TL4 = GameObject.Find("point_TL4").GetComponent<Transform>();
        point_TL5 = GameObject.Find("point_TL5").GetComponent<Transform>();

        point_ViewOperationField = GameObject.Find("point_ViewOperationField").GetComponent<Transform>();

        // Initializing Pilot level
        // Random level.
        if (level_Pilot == 0)
            level_Pilot = Random.Range(1, 4);
        // Raw Recruit.
        if (level_Pilot == 1)
            init_Pilotage = Random.Range(0.75f, 0.9f);
        // Middle Class.
        else if (level_Pilot == 2)
            init_Pilotage = Random.Range(0.9f, 1.2f);
        // Ace.
        else if (level_Pilot == 3)
            init_Pilotage = Random.Range(1.4f, 1.8f);

        // Init. pilotage.
        pilotage = init_Pilotage;

        // Random rotation for falling down to land.
        rndFallingLR = Random.Range(0, 2);

        if (signal_IsEnemy == 0)
        {
            gameObject.tag = "OurForces";

            // Initialize the Ourforces Aircraft ID.
            viewNum_OurForces = wingCommand.UnregisteredNumber_OurForces(type_Aircraft);

            wingCommand.unitOn_OurForces[viewNum_OurForces] = 1;
            wingCommand.status_OurForces[viewNum_OurForces] = 1;
            wingCommand.type_OurForces[viewNum_OurForces] = type_Aircraft;
            wingCommand.group_OurForces[viewNum_OurForces] = aircraftGroup;
            wingCommand.transform_OurForces[viewNum_OurForces] = transform;
            wingCommand.Init_FormationLeader_OurForces(viewNum_OurForces, type_Aircraft);
            wingCommand.Init_FormationNumAndOrder_OurForces(viewNum_OurForces, type_Aircraft);

            signal_IsFormationLeader = wingCommand.isLeader_OurForces[viewNum_OurForces];
            num_Formation = wingCommand.formationNum_OurForces[viewNum_OurForces];
            num_FormationOrder = wingCommand.formationOrder_OurForces[viewNum_OurForces];

            wingCommand.initNum_OurForces += 1;
            wingCommand.totalNum_OurForces += 1;
        }
        else
        {
            gameObject.tag = "Enemy";

            // Initialize the Enemy Aircraft ID.
            viewNum_Enemy = wingCommand.UnregisteredNumber_Enemy(type_Aircraft);

            wingCommand.unitOn_Enemy[viewNum_Enemy] = 1;
            wingCommand.status_Enemy[viewNum_Enemy] = 1;
            wingCommand.type_Enemy[viewNum_Enemy] = type_Aircraft;
            wingCommand.group_Enemy[viewNum_Enemy] = type_Aircraft;
            wingCommand.transform_Enemy[viewNum_Enemy] = transform;
            wingCommand.Init_FormationLeader_Enemy(viewNum_Enemy, type_Aircraft);
            wingCommand.Init_FormationNumAndOrder_Enemy(viewNum_Enemy, type_Aircraft);

            signal_IsFormationLeader = wingCommand.isLeader_Enemy[viewNum_Enemy];
            num_Formation = wingCommand.formationNum_Enemy[viewNum_Enemy];
            num_FormationOrder = wingCommand.formationOrder_Enemy[viewNum_Enemy];

            wingCommand.initNum_Enemy += 1;
            wingCommand.totalNum_Enemy += 1;
        }
        // Update the information to wing commander.
        UpdateInformationToWingCommandInfo();

        // Init. Status.
        if (type_Aircraft == 0)
        {
            velocity_Standard = 200f;
            throttle_Aircraft = 200f;
        }
        if (type_Aircraft == 1)
        {
            velocity_Standard = 170f;
            throttle_Aircraft = 170f;
        }
        if (type_Aircraft == 2)
        {
            velocity_Standard = 250f;
            throttle_Aircraft = 250f;
        }
        if (type_Aircraft == 3)
        {
            velocity_Standard = 160f;
            throttle_Aircraft = 160f;
        }

        // In Airport by Init.
        if (statusFlight == -1)
            signal_InAirport = 1;

        if (signal_InAirport == 1)
            throttle_Aircraft = 0;

        // Init. Random Position for avoiding collapse.
        if (statusFlight == 1)
        {
            Vector3 pos_Temp = new Vector3();
            pos_Temp.x = transform.position.x + num_Formation * 50 + num_FormationOrder * 50;
            pos_Temp.y = transform.position.y + Random.Range(-30f, 30f);
            pos_Temp.z = transform.position.z + Random.Range(-150f, 150f);
            transform.position = pos_Temp;
        }
    }

    //==============================================================================
    // 2. GUI Part
    //==============================================================================

    // GUI Code: This is a just reference code.
    public Texture image_Mark;
    public Texture image_TargetRed;
    public Texture image_TargetGreen;
    public Texture image_CrashedAircraft;
    int size_TI = Screen.height * 1 / 30;
    void OnGUI()
    {

        if (view.viewFrom == 1)
        {
            // Target Indicator.
            Vector3 pos_OnScreen = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 toTargetFromView;
            toTargetFromView = pos_View.position - transform.position;

            // Aircraft Location Indicator on screen.
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
                    if (signal_IsDestroyed == 0)
                    {
                        GUI.DrawTexture(new Rect(pos_OnScreen.x - size_TI / 2, Screen.height - pos_OnScreen.y - size_TI / 2, size_TI, size_TI),
                            image_Mark, ScaleMode.StretchToFill, true, 0);
                    }
                }
                // In Screen.
                else
                {
                    if (signal_IsDestroyed == 0 && view.signal_TargetIndicatorOn == true)
                    {
                        // Very Long Distance.
                        if (Vector3.Distance(transform.position, view.transform.position) > 15550f)
                        {
                            if (view.camPos != 120)
                            {
                                GUI.DrawTexture(new Rect(pos_OnScreen.x - size_TI / 3, Screen.height - pos_OnScreen.y - size_TI / 3, size_TI / 1.5f, size_TI / 1.5f),
                                    image_Mark, ScaleMode.StretchToFill, true, 0);
                            }
                            else
                            {
                                if (signal_IsEnemy == 0)
                                    GUI.DrawTexture(new Rect(pos_OnScreen.x - size_TI / 3, Screen.height - pos_OnScreen.y - size_TI / 3, size_TI / 1.5f, size_TI / 1.5f),
                                        image_TargetGreen, ScaleMode.StretchToFill, true, 0);
                                else
                                    GUI.DrawTexture(new Rect(pos_OnScreen.x - size_TI / 3, Screen.height - pos_OnScreen.y - size_TI / 3, size_TI / 1.5f, size_TI / 1.5f),
                                        image_TargetRed, ScaleMode.StretchToFill, true, 0);
                            }
                        }

                        // Long Distance.
                        if (Vector3.Distance(transform.position, view.transform.position) > 4550f && Vector3.Distance(transform.position, view.transform.position) <= 15550f)
                        {
                            if (signal_IsEnemy == 0)
                                GUI.DrawTexture(new Rect(pos_OnScreen.x - size_TI / 3, Screen.height - pos_OnScreen.y - size_TI / 3, size_TI / 1.5f, size_TI / 1.5f),
                                                 image_TargetGreen, ScaleMode.StretchToFill, true, 0);
                            else
                                GUI.DrawTexture(new Rect(pos_OnScreen.x - size_TI / 3, Screen.height - pos_OnScreen.y - size_TI / 3, size_TI / 1.5f, size_TI / 1.5f),
                                                 image_TargetRed, ScaleMode.StretchToFill, true, 0);
                        }
                        // 3rd View.
                        if (Vector3.Distance(transform.position, view.transform.position) <= 4550f && Vector3.Distance(transform.position, view.transform.position) > 150f)
                        {
                            // If Enemy.
                            if (signal_IsEnemy == 1)
                            {
                                GUI.DrawTexture(new Rect(pos_OnScreen.x - size_TI / 2, Screen.height - pos_OnScreen.y - size_TI / 2, size_TI, size_TI),
                                    image_TargetRed, ScaleMode.StretchToFill, true, 0);
                            }
                            // If OurForces
                            else
                            {
                                GUI.DrawTexture(new Rect(pos_OnScreen.x - size_TI / 2, Screen.height - pos_OnScreen.y - size_TI / 2, size_TI, size_TI),
                                    image_TargetGreen, ScaleMode.StretchToFill, true, 0);
                            }

                        }
                    }
                    // Destroyed.
                    if (signal_IsDestroyed == 1 && view.signal_TargetIndicatorOn == true)
                    {
                        if (view.camPos == 120)
                        {
                            GUI.DrawTexture(new Rect(pos_OnScreen.x - size_TI / 2, Screen.height - pos_OnScreen.y - size_TI / 2, size_TI, size_TI),
                                         image_CrashedAircraft, ScaleMode.StretchToFill, true, 0);
                        }
                    }
                }
            }
            // Behind of View.
            else
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
                    if (signal_IsDestroyed == 0)
                        GUI.DrawTexture(new Rect(Screen.width - pos_OnScreen.x - size_TI / 2, pos_OnScreen.y - size_TI / 2, size_TI, size_TI),
                            image_Mark, ScaleMode.StretchToFill, true, 0);
                }
                // In Screen.
                else
                {
                    if (pos_OnScreen.x <= Screen.width / 2)
                    {
                        pos_OnScreen.x = size_TI / 2;
                        pos_OnScreen.y = (Camera.main.WorldToScreenPoint(transform.position).y - Screen.height / 2) /
                            (Camera.main.WorldToScreenPoint(transform.position).x - Screen.width / 2) * (pos_OnScreen.x - Screen.width / 2)
                            + Screen.height / 2;
                    }
                    if (pos_OnScreen.x > Screen.width / 2)
                    {
                        pos_OnScreen.x = Screen.width - size_TI / 2;
                        pos_OnScreen.y = (Camera.main.WorldToScreenPoint(transform.position).y - Screen.height / 2) /
                            (Camera.main.WorldToScreenPoint(transform.position).x - Screen.width / 2) * (pos_OnScreen.x - Screen.width / 2)
                            + Screen.height / 2;
                    }

                    if (pos_OnScreen.y <= Screen.height / 2)
                    {
                        pos_OnScreen.y = size_TI / 2;
                        pos_OnScreen.x = (Camera.main.WorldToScreenPoint(transform.position).x - Screen.width / 2) /
                            (Camera.main.WorldToScreenPoint(transform.position).y - Screen.height / 2) * (pos_OnScreen.y - Screen.height / 2)
                            + Screen.width / 2;
                    }
                    if (pos_OnScreen.y > Screen.height / 2)
                    {
                        pos_OnScreen.y = Screen.height - size_TI / 2;
                        pos_OnScreen.x = (Camera.main.WorldToScreenPoint(transform.position).x - Screen.width / 2) /
                            (Camera.main.WorldToScreenPoint(transform.position).y - Screen.height / 2) * (pos_OnScreen.y - Screen.height / 2)
                            + Screen.width / 2;

                    }
                    if (pos_OnScreen.x < size_TI / 2)
                        pos_OnScreen.x = size_TI / 2;
                    if (pos_OnScreen.x > Screen.width - size_TI / 2)
                        pos_OnScreen.x = Screen.width - size_TI / 2;
                    if (signal_IsDestroyed == 0)
                    {
                        GUI.DrawTexture(new Rect(Screen.width - pos_OnScreen.x - size_TI / 2, pos_OnScreen.y - size_TI / 2, size_TI, size_TI),
                            image_Mark, ScaleMode.StretchToFill, true, 0);
                    }
                }
            }
        }
    }

    //==============================================================================
    // 3. General Flight Part
    //==============================================================================

    // Control lever
    private float accelerationPull = 0.05f;
    private float accelerationPush = 0.05f;
    private float accelerationTiltL = 0.05f;
    private float accelerationTiltR = 0.05f;
    private float accelerationTurnL = 0.05f;
    private float accelerationTurnR = 0.05f;

    // Angles for AircraftControl
    public float angleFlap = 0;
    public float angleElevator = 0;
    public float angleAileronL = 0;
    public float angleAileronR = 0;
    public float angleRudder = 0;

    // Used by Tail wheel at runway.
    public float angleTailWheel = 0;

    // Wing Controller.
    void WingControl()
    {

        // Flap.
        if ((signal_Landing == 1 || signal_TakingOff == 1) && (destination_TL == 3 || destination_TL == 2))
        {
            if (angleFlap > -15f)
                angleFlap -= Time.deltaTime;
        }
        else
        {
            angleFlap = Mathf.Lerp(angleFlap, 0, Time.deltaTime * 2f);
        }

        // Elevator.
        if (angleElevator > 0.01f || angleElevator < -0.01f)
            angleElevator = Mathf.Lerp(angleElevator, 0, Time.deltaTime * 2f);

        // Aileron.
        if (angleAileronL > 0.01f || angleAileronL < -0.01f)
            angleAileronL = Mathf.Lerp(angleAileronL, 0, Time.deltaTime * 2f);

        if (angleAileronR > 0.01f || angleAileronR < -0.01f)
            angleAileronR = Mathf.Lerp(angleAileronR, 0, Time.deltaTime * 2f);

        // Rudder.
        if (angleRudder > 0.01f || angleRudder < -0.01f)
            angleRudder = Mathf.Lerp(angleRudder, 0, Time.deltaTime * 2f);

        // Tail Wheel.
        if (angleTailWheel > 0.01f || angleTailWheel < -0.01f)
            angleTailWheel = Mathf.Lerp(angleTailWheel, 0, Time.deltaTime * 2f);
    }

    private void Lever_Pull(float angle)
    {

        accelerationPush = 0.01f;
        if (accelerationPull < 1)
            accelerationPull += Time.deltaTime;
        transform.Rotate(-angle * pilotage * Time.deltaTime * 40f * accelerationPull, 0, 0);
        if (angleElevator < 20f)
            angleElevator += Time.deltaTime * 120f * angle;
    }
    private void Lever_Push(float angle)
    {

        accelerationPull = 0.01f;
        if (accelerationPush < 1)
            accelerationPush += Time.deltaTime;
        transform.Rotate(angle * pilotage * Time.deltaTime * 40f * accelerationPush, 0, 0);
        if (angleElevator > -20f)
            angleElevator -= Time.deltaTime * 120f * angle;
    }
    private void Lever_TiltL(float angle)
    {

        accelerationTiltR = 0.01f;
        if (accelerationTiltL < 1)
            accelerationTiltL += Time.deltaTime;
        transform.Rotate(0, 0, angle * pilotage * Time.deltaTime * 70f * accelerationTiltL);
        if (angleAileronL < 20f)
            angleAileronL += Time.deltaTime * 120f * angle;
        if (angleAileronR > -20f)
            angleAileronR -= Time.deltaTime * 120f * angle;
    }
    private void Lever_TiltR(float angle)
    {

        accelerationTiltL = 0.01f;
        if (accelerationTiltR < 1)
            accelerationTiltR += Time.deltaTime;
        transform.Rotate(0, 0, -angle * pilotage * Time.deltaTime * 70f * accelerationTiltR);
        if (angleAileronL > -20f)
            angleAileronL -= Time.deltaTime * 120f * angle;
        if (angleAileronR < 20f)
            angleAileronR += Time.deltaTime * 120f * angle;
    }
    private void Lever_TurnL(float angle)
    {

        accelerationTurnR = 0.01f;
        if (accelerationTurnL < 1)
            accelerationTurnL += Time.deltaTime;
        transform.Rotate(0, -angle * pilotage * Time.deltaTime * 30f * accelerationTurnL, 0);
        if (angleRudder < 20f)
            angleRudder += Time.deltaTime * 120f * angle;
    }
    private void Lever_TurnR(float angle)
    {

        accelerationTurnL = 0.01f;
        if (accelerationTurnR < 1)
            accelerationTurnR += Time.deltaTime;
        transform.Rotate(0, angle * pilotage * Time.deltaTime * 30f * accelerationTurnR, 0);
        if (angleRudder > -20f)
            angleRudder -= Time.deltaTime * 120f * angle;
    }

    // Control to main wing horizontality
    public void Control_WingToHorizontality(float angle)
    {

        if (Mathf.Round(point_Left.position.y * 10f) > Mathf.Round(point_Right.position.y * 10f))
        {
            Lever_TiltL(angle);
        }
        if (Mathf.Round(point_Left.position.y * 10f) < Mathf.Round(point_Right.position.y * 10f))
        {
            Lever_TiltR(angle);
        }
    }

    // Control main body to horizontality
    public void Control_MainBodyToHorizontally(float angle)
    {

        if (Mathf.Round(point_Front.position.y * 10f) > Mathf.Round(point_Behind.position.y * 10f))
        {
            Lever_Push(angle);
        }
        if (Mathf.Round(point_Front.position.y * 10f) < Mathf.Round(point_Behind.position.y * 10f))
        {
            Lever_Pull(angle);
        }
    }

    // Control  wing to Enemy
    public void Control_WingToTargetVertically(Vector3 target, float angle)
    {

        if (Mathf.Round(Vector3.Distance(point_Left.position, target) * 5f) >
            Mathf.Round(Vector3.Distance(point_Right.position, target) * 5f))
        {
            Lever_TiltR(angle);
        }
        if (Mathf.Round(Vector3.Distance(point_Left.position, target) * 5f) <
            Mathf.Round(Vector3.Distance(point_Right.position, target) * 5f))
        {
            Lever_TiltL(angle);
        }
    }

    // Control main Head to Target
    public void Control_HeadToTarget(Vector3 target, float angle)
    {

        if (Mathf.Round(Vector3.Distance(point_Up.position, target) * 5f) <
            Mathf.Round(Vector3.Distance(point_Down.position, target) * 5f))
        {
            Lever_Pull(angle);
        }
        if (Mathf.Round(Vector3.Distance(point_Up.position, target) * 5f) >
            Mathf.Round(Vector3.Distance(point_Down.position, target) * 5f))
        {
            Lever_Push(angle);
        }
    }

    public void Control_HeadToTargetAdvanced(Vector3 target, float angle)
    {

        // The target is on my head only.
        if (Vector3.Distance(point_Up.position, target) < Vector3.Distance(point_Down.position, target))
        {
            Lever_Pull(0.3f);
        }
    }

    // Control main wing horizontality to Enemy
    public void Control_WingToTargetByTurning(Vector3 target, float angle)
    {
        if (Mathf.Round(Vector3.Distance(point_Left.position, target) * 10f) >
            Mathf.Round(Vector3.Distance(point_Right.position, target) * 10f))
        {
            Lever_TurnR(angle);
        }
        if (Mathf.Round(Vector3.Distance(point_Left.position, target) * 10f) <
            Mathf.Round(Vector3.Distance(point_Right.position, target) * 10f))
        {
            Lever_TurnL(angle);
        }
    }

    public void Control_WingToTargetByTurningInRunway(Vector3 target, float angle, float angle_TailWheel)
    {

        if (Mathf.Round(Vector3.Distance(point_Left.position, target) * 10f) >
            Mathf.Round(Vector3.Distance(point_Right.position, target) * 10f))
        {
            Lever_TurnR(angle);
            if (angle_TailWheel > -30f)
                angle_TailWheel -= Time.deltaTime * 150 * angle;
        }
        else if (Mathf.Round(Vector3.Distance(point_Left.position, target) * 10f) <
            Mathf.Round(Vector3.Distance(point_Right.position, target) * 10f))
        {
            Lever_TurnL(angle);
            if (angle_TailWheel < 30f)
                angle_TailWheel += Time.deltaTime * 150 * angle;
        }
    }

    // General Flight.
    void GeneralFlight(Vector3 targetAdvanced, int typeAircraft)
    {

        // Propeller.
        if (typeAircraft == 0)
        {

            // Fly to enemy behind of aircraft.
            if (Vector3.Angle(targetAdvanced - transform.position, transform.forward) > 120f)
            {
                Lever_Pull(0.15f);
            }
            // High Angle Target.
            if (Vector3.Angle(targetAdvanced - transform.position, transform.forward) > angleHigh * 0.33f)
            {
                // Up Target.
                if (Vector3.Distance(point_Up.position, targetAdvanced) < Vector3.Distance(point_Down.position, targetAdvanced))
                {
                    Control_WingToTargetVertically(targetAdvanced, 0.5f);

                    Lever_Pull(0.15f);
                }
                // Down Target.
                else
                {
                    Control_WingToTargetVertically(targetAdvanced, 0.5f);

                }
                Control_WingToTargetByTurning(targetAdvanced, 0.15f);
            }
            // Low Angle Target.
            if (Vector3.Angle(targetAdvanced - transform.position, transform.forward) <= angleHigh * 0.33f && Vector3.Angle(targetAdvanced - transform.position, transform.forward) > angleLow * 0.15)
            {
                // Up Target.
                if (Vector3.Distance(point_Up.position, targetAdvanced) < Vector3.Distance(point_Down.position, targetAdvanced))
                {
                    Control_WingToTargetVertically(targetAdvanced, 0.5f);
                    Lever_Pull(0.15f);
                }
                // Down Target.
                else
                {
                    Control_WingToTargetVertically(targetAdvanced, 0.5f);

                }
                Control_WingToTargetByTurning(targetAdvanced, 0.15f);
            }
            // Aim Angle Target.
            if (Vector3.Angle(targetAdvanced - transform.position, transform.forward) <= angleLow * 0.15f)
            {
                Control_WingToTargetVertically(targetAdvanced, 0.5f);
                Control_WingToTargetByTurning(targetAdvanced, 0.15f);
                Control_HeadToTarget(targetAdvanced, 0.2f);
                Control_WingToHorizontality(0.1f);
            }
        }
        // Bomber.
        if (typeAircraft == 1)
        {
            // Fly to enemy behind of aircraft.
            if (Vector3.Angle(targetAdvanced - transform.position, transform.forward) > 120f)
            {
                Lever_Pull(0.15f);
            }
            // High Angle Target.
            if (Vector3.Angle(targetAdvanced - transform.position, transform.forward) > angleHigh * 0.33f)
            {
                // Up Target.
                if (Vector3.Distance(point_Up.position, targetAdvanced) < Vector3.Distance(point_Down.position, targetAdvanced))
                {
                    Control_WingToTargetVertically(targetAdvanced, 0.15f);

                    Lever_Pull(0.15f);
                }
                // Down Target.
                else
                {
                    Control_WingToTargetVertically(targetAdvanced, 0.15f);

                }
                Control_WingToTargetByTurning(targetAdvanced, 0.2f);
                Control_WingToHorizontality(0.15f);
            }
            // Low Angle Target.
            if (Vector3.Angle(targetAdvanced - transform.position, transform.forward) <= angleHigh * 0.33f && Vector3.Angle(targetAdvanced - transform.position, transform.forward) > angleLow * 0.15)
            {
                // Up Target.
                if (Vector3.Distance(point_Up.position, targetAdvanced) < Vector3.Distance(point_Down.position, targetAdvanced))
                {
                    Control_WingToTargetVertically(targetAdvanced, 0.15f);
                    Lever_Pull(0.15f);
                }
                // Down Target.
                else
                {
                    Control_WingToTargetVertically(targetAdvanced, 0.15f);

                }
                Control_WingToTargetByTurning(targetAdvanced, 0.2f);
            }
            // Aim Angle Target.
            if (Vector3.Angle(targetAdvanced - transform.position, transform.forward) <= angleLow * 0.15f)
            {
                Control_WingToTargetVertically(targetAdvanced, 0.05f);
                Control_WingToTargetByTurning(targetAdvanced, 0.2f);
                Control_HeadToTarget(targetAdvanced, 0.2f);
                Control_WingToHorizontality(0.1f);
                if (Vector3.Distance(transform.position, targetAdvanced) > 1850f)
                    Control_WingToHorizontality(0.3f);
            }
        }
        // Jet.
        if (typeAircraft == 2)
        {
            // Fly to enemy behind of aircraft.
            if (Vector3.Angle(targetAdvanced - transform.position, transform.forward) > 120f)
            {
                Lever_Pull(0.2f);
            }
            // High Angle Target.
            if (Vector3.Angle(targetAdvanced - transform.position, transform.forward) > angleHigh * 0.33f)
            {
                // Up Target.
                if (Vector3.Distance(point_Up.position, targetAdvanced) < Vector3.Distance(point_Down.position, targetAdvanced))
                {
                    Control_WingToTargetVertically(targetAdvanced, 0.7f);

                    Lever_Pull(0.2f);
                }
                // Down Target.
                else
                {
                    Control_WingToTargetVertically(targetAdvanced, 0.7f);

                }
                Control_WingToTargetByTurning(targetAdvanced, 0.15f);
            }
            // Low Angle Target.
            if (Vector3.Angle(targetAdvanced - transform.position, transform.forward) <= angleHigh * 0.33f && Vector3.Angle(targetAdvanced - transform.position, transform.forward) > angleLow * 0.15)
            {
                // Up Target.
                if (Vector3.Distance(point_Up.position, targetAdvanced) < Vector3.Distance(point_Down.position, targetAdvanced))
                {
                    Control_WingToTargetVertically(targetAdvanced, 0.7f);
                    Lever_Pull(0.2f);
                }
                // Down Target.
                else
                {
                    Control_WingToTargetVertically(targetAdvanced, 0.7f);

                }
                Control_WingToTargetByTurning(targetAdvanced, 0.15f);
            }
            // Aim Angle Target.
            if (Vector3.Angle(targetAdvanced - transform.position, transform.forward) <= angleLow * 0.15f)
            {
                Control_WingToTargetVertically(targetAdvanced, 0.7f);
                Control_WingToTargetByTurning(targetAdvanced, 0.15f);
                Control_HeadToTarget(targetAdvanced, 0.2f);
                Control_WingToHorizontality(0.1f);
                if (Vector3.Distance(transform.position, targetAdvanced) > 1850f)
                    Control_WingToHorizontality(0.3f);
            }
        }
        // Helicopter
        if (typeAircraft == 3)
        {
            // High Angle Target.
            if (Vector3.Angle(targetAdvanced - transform.position, transform.forward) > angleHigh * 0.33f)
            {
                // Up Target.
                if (Vector3.Distance(point_Up.position, targetAdvanced) < Vector3.Distance(point_Down.position, targetAdvanced))
                {
                    Control_WingToTargetVertically(targetAdvanced, 0.15f);

                    transform.position += new Vector3(0, Time.deltaTime * 1f, 0);
                }
                // Down Target.
                else
                {
                    transform.position -= new Vector3(0, Time.deltaTime * 1f, 0);

                }
                Control_HeadToTarget(targetAdvanced, 0.25f);
                Control_WingToTargetByTurning(targetAdvanced, 0.3f);
                Control_WingToHorizontality(0.15f);
            }
            // Low Angle Target.
            if (Vector3.Angle(targetAdvanced - transform.position, transform.forward) <= angleHigh * 0.33f && Vector3.Angle(targetAdvanced - transform.position, transform.forward) > angleLow * 0.25)
            {
                // Up Target.
                if (Vector3.Distance(point_Up.position, targetAdvanced) < Vector3.Distance(point_Down.position, targetAdvanced))
                {
                    Control_WingToTargetVertically(targetAdvanced, 0.3f);
                    Lever_Pull(0.3f);

                    transform.position -= new Vector3(0, Time.deltaTime * 1f, 0);
                }
                // Down Target.
                else
                {
                    Control_WingToTargetVertically(targetAdvanced, 0.5f);

                    transform.position -= new Vector3(0, Time.deltaTime * 1f, 0);
                }
                Control_HeadToTarget(targetAdvanced, 0.25f);
                Control_WingToTargetByTurning(targetAdvanced, 0.15f);
            }
            // Aim Angle Target.
            if (Vector3.Angle(targetAdvanced - transform.position, transform.forward) <= angleLow * 0.25f)
            {
                Control_WingToTargetVertically(targetAdvanced, 0.2f);
                Control_WingToTargetByTurning(targetAdvanced, 0.3f);
                Control_HeadToTarget(targetAdvanced, 0.2f);
                Control_WingToHorizontality(0.1f);
            }
            Control_WingToHorizontality(0.3f);
        }

    }

    // Falling Down To land
    private void FallingDownToLand(int typeAircraft)
    {

        // Falling Down From Air
        if (statusFlight == -3)
        {
            if (typeAircraft == 3)
            {
                // Head to Land.
                if (point_Up.position.y > point_Down.position.y)
                    transform.Rotate(0.02f, 0, 0);
                else
                    transform.Rotate(-0.02f, 0, 0);

                if (point_Left.position.y > point_Right.position.y)
                    transform.Rotate(0, 0.02f, 0);

                else
                    transform.Rotate(0, -0.02f, 0);

                // Increasing velocity of aircraft.
                if (velocityAircraft < 310f)
                    velocityAircraft += Time.deltaTime;
            }
            else
            {
                // Head to Land.
                if (point_Up.position.y > point_Down.position.y)
                    transform.Rotate(0.08f, 0, 0);
                else
                    transform.Rotate(-0.08f, 0, 0);

                if (point_Left.position.y > point_Right.position.y)
                    transform.Rotate(0, 0.08f, 0);

                else
                    transform.Rotate(0, -0.08f, 0);

                // Increasing velocity of aircraft.
                if (velocityAircraft < 410f)
                    velocityAircraft += Time.deltaTime;

                if (rndFallingLR == 0)
                    transform.Rotate(0, 0, -2f);
                if (rndFallingLR == 1)
                    transform.Rotate(0, 0, 2f);
            }
        }
    }

    //==============================================================================
    // 4. Flight Function Part
    //==============================================================================

    // Dogfight Target Manager
    void DogfightTarget_Manager()
    {

        // OurForces.
        if (signal_IsEnemy == 0)
        {
            // Find my air target.
            if (wingCommand.haveAirTarget_OurForces[viewNum_OurForces] == 0)
            {
                wingCommand.FindMyAirTarget_OurForces(viewNum_OurForces);
            }
            // If the target was allocated on me. then, get the target's position.
            else
            {
                if (wingCommand.status_Enemy[wingCommand.myAirTargetID_OurForces[viewNum_OurForces]] == 1 ||
                    wingCommand.status_Enemy[wingCommand.myAirTargetID_OurForces[viewNum_OurForces]] == -1)
                {
                    point_MainTarget = wingCommand.FindMyAirTargetTransform_OurForces(viewNum_OurForces);
                }
                // My target was destroyed, so... Find new air target.
                else
                {
                    bool status = wingCommand.FindMyNewAirTarget_OurForces(viewNum_OurForces);
                    if (status == false)
                    {
                        // Dogfight is ended. Return to base.
                        ResetDogfightTarget();
                        point_MainTarget = point_Return;
                        Control_WingToHorizontality(0.1f);
                        if (flightOrder == 2)
                            StartCoroutine(Order_FlyToReturnPoint(3, 0, viewNum_OurForces));
                    }
                }
            }
        }
        // Enemy.
        else
        {
            // Find my air target.
            if (wingCommand.haveAirTarget_Enemy[viewNum_Enemy] == 0)
            {
                wingCommand.FindMyAirTarget_Enemy(viewNum_Enemy);
            }
            // If the target was allocated on me. then, get the target's position.
            else
            {
                if (wingCommand.status_OurForces[wingCommand.myAirTargetID_Enemy[viewNum_Enemy]] == 1 ||
                    wingCommand.status_OurForces[wingCommand.myAirTargetID_Enemy[viewNum_Enemy]] == -1)
                {
                    point_MainTarget = wingCommand.FindMyAirTargetTransform_Enemy(viewNum_Enemy);

                }
                // My target was destroyed, so... Find new air target.
                else
                {
                    bool status = wingCommand.FindMyNewAirTarget_Enemy(viewNum_Enemy);
                    if (status == false)
                    {
                        // Dogfight is ended. Return to base.
                        ResetDogfightTarget();
                        point_MainTarget = point_Return;
                        Control_WingToHorizontality(0.1f);
                        if (flightOrder == 2)
                            StartCoroutine(Order_FlyToReturnPoint(3, 0, viewNum_Enemy));
                    }
                }
            }
        }
    }

    // Dogfight Tactic.
    Vector3 toTarget;
    Vector3 targetAdvanced = new Vector3();
    void DogfightTactic(Transform target, int typeAircraft)
    {

        if (target == null)
            return;

        if (Vector3.Angle(toTarget, transform.forward) > 90f)
        {
            // Fly to body.
            targetAdvanced.x = target.position.x;
            targetAdvanced.y = (transform.position.y + point_FieldCenter.position.y + point_FieldCenter.position.y) * 0.33f;
            targetAdvanced.z = target.position.z;
            toTarget = targetAdvanced - transform.position;
        }
        else
        {
            // Fly to body.
            targetAdvanced = target.position;
            toTarget = targetAdvanced - transform.position;
        }

        // Velocity up for closing to target.
        if (Vector3.Distance(transform.position, targetAdvanced) > 750f)
            if (throttle_Aircraft < velocity_Standard * 1.3f)
                throttle_Aircraft = Mathf.Lerp(throttle_Aircraft, velocity_Standard * 1.3f, Time.deltaTime * 0.1f);
            // Basic Velocity.
            else
                throttle_Aircraft = Mathf.Lerp(throttle_Aircraft, velocity_Standard, Time.deltaTime * 0.1f);

        // Evasive tactic.
        RaycastHit hitEnemy;
        if (Physics.Raycast(point_RaycastM.position, transform.TransformDirection(Vector3.forward), out hitEnemy, 750f))
        {
            if (signal_IsEnemy == 0)
            {
                if (hitEnemy.collider.gameObject.tag == "Enemy")
                    hitEnemy.collider.gameObject.GetComponent<Ctrl_Aircraft_FA>().signal_DoEvasiveFlight = 1;
            }
            else
            {
                if (hitEnemy.collider.gameObject.tag == "OurForces")
                    hitEnemy.collider.gameObject.GetComponent<Ctrl_Aircraft_FA>().signal_DoEvasiveFlight = 1;
            }
        }

        // Fly to Target.
        // Propeller Fighter.
        if (typeAircraft == 0)
        {
            GeneralFlight(targetAdvanced, 0);

            if (Vector3.Angle(toTarget, transform.forward) <= angleLow * 0.1f)
            {
                if (Vector3.Distance(transform.position, target.position) < 450f * pilotage)
                {
                    signal_Gunfire = 1;
                    Lever_Pull(0.15f);
                }
            }
        }
        // Bomber.
        if (typeAircraft == 1)
        {
            GeneralFlight(targetAdvanced, 1);

            if (Vector3.Angle(toTarget, transform.forward) <= angleLow * 0.1f)
            {
                if (Vector3.Distance(transform.position, target.position) < 350f * pilotage)
                {
                    signal_Gunfire = 1;
                    Lever_Pull(0.15f);
                }
            }
        }

        // JetFighter.
        if (typeAircraft == 2)
        {
            GeneralFlight(targetAdvanced, 2);

            if (Vector3.Angle(toTarget, transform.forward) <= angleLow * 0.5f)
            {
                if (Vector3.Distance(transform.position, target.position) < 750f * pilotage &&
                    Vector3.Distance(transform.position, target.position) >= 350f)
                {
                    signal_LaunchingRocket = 1;
                    signal_DoEvasiveFlight = 1;
                }
                if (Vector3.Angle(toTarget, transform.forward) <= angleLow * 0.15f)
                {
                    if (Vector3.Distance(transform.position, target.position) < 2750f)
                    {
                        signal_Gunfire = 1;
                        Control_HeadToTarget(targetAdvanced, 0.15f);
                    }
                }
            }
        }
        // Helicopter.
        if (typeAircraft == 3)
        {
            GeneralFlight(targetAdvanced, 3);

            // Aim Angle Target.
            if (Vector3.Angle(toTarget, transform.forward) <= angleLow * 0.25f)
            {
                if (Vector3.Distance(transform.position, target.position) < 550f * pilotage)
                {
                    signal_Gunfire = 1;
                }
                point_GunLeft.LookAt(targetAdvanced);
                point_GunRight.LookAt(targetAdvanced);
            }


        }

        // Commence fire when the enemy is located in front of Player.
        GunfireBySignal();
        LaunchingRocketBySignal();

        // Return to base.
        if (signal_IsEnemy == 0)
        {
            if (hitpoint < 9 && flightOrder != 0)
            {
                signal_Dismiss = 1;
                StartCoroutine(Order_FlyToReturnPoint(3, 0, viewNum_OurForces));
            }
        }
        else
        {
            if (hitpoint < 9 && flightOrder != 0)
            {
                signal_Dismiss = 1;
                StartCoroutine(Order_FlyToReturnPoint(3, 0, viewNum_Enemy));
            }
        }
    }

    // Reset Dogfight Target after it destroyed.
    void ResetDogfightTarget()
    {

        // OurForces.
        if (signal_IsEnemy == 0)
        {
            if (wingCommand.haveAirTarget_OurForces[viewNum_OurForces] == 1)
            {
                wingCommand.myAirTargetID_OurForces[viewNum_OurForces] = 0;
                wingCommand.haveAirTarget_OurForces[viewNum_OurForces] = 0;
            }
        }
        // Enemy.
        else
        {
            if (wingCommand.haveAirTarget_Enemy[viewNum_Enemy] == 1)
            {
                wingCommand.myAirTargetID_Enemy[viewNum_Enemy] = 0;
                wingCommand.haveAirTarget_Enemy[viewNum_Enemy] = 0;
            }
        }
    }

    // Avoiding Enemy's attack
    float timeAT = 0;
    float waitAT = 6f;
    int switchEvasionLR = 0;
    public void EvasionFlight(int typeAircraft)
    {

        if (signal_DoEvasiveFlight == 1)
        {
            // Ace.
            if (level_Pilot == 3)
            {
                velocityAdvanced -= Time.deltaTime * 2f;
                Lever_Pull(0.25f);
                Control_HeadToTargetAdvanced(point_Return.position, 0.3f);
                // Wing To Verticality
                // General rotation.
                if ((point_Up.position.y >= point_Down.position.y))
                {
                    // Tilted Left
                    if (point_Left.position.y < point_Right.position.y)
                    {
                        Lever_TiltL(0.9f);
                    }
                    // Tilted Right
                    else
                    {
                        Lever_TiltR(0.9f);
                    }
                }
                else
                {
                    // Tilted Left
                    if (point_Left.position.y < point_Right.position.y)
                    {
                        Lever_TiltL(0.9f);
                    }
                    // Tilted Right
                    else
                    {
                        Lever_TiltR(0.9f);
                    }
                }
            }
            // Middle Class.
            if (level_Pilot == 2)
            {
                if (switchEvasionLR == 0)
                {
                    if (Vector3.Angle(point_Return.position - transform.position, transform.forward) > angleLow * 1 / 9)
                    {
                        // Up Target.
                        if (Vector3.Distance(point_Up.position, point_Return.position) < Vector3.Distance(point_Down.position, point_Return.position))
                        {
                            Control_WingToTargetVertically(point_Return.position, 0.7f);
                            Lever_Pull(0.3f);
                        }
                        // Down Target.
                        else
                        {
                            Control_WingToTargetVertically(point_Return.position, 0.7f);
                        }
                        Control_WingToTargetByTurning(point_Return.position, 0.15f);
                    }
                    if (Vector3.Angle(point_Return.position - transform.position, transform.forward) <= angleLow * 1 / 9)
                    {
                        switchEvasionLR = 1;
                    }
                }
                else
                {
                    if (Vector3.Angle(point_FieldCenter.position - transform.position, transform.forward) > angleLow * 1 / 9)
                    {
                        // Up Target.
                        if (Vector3.Distance(point_Up.position, point_FieldCenter.position) < Vector3.Distance(point_Down.position, point_FieldCenter.position))
                        {
                            Control_WingToTargetVertically(point_FieldCenter.position, 0.7f);
                            Lever_Pull(0.3f);
                        }
                        // Down Target.
                        else
                        {
                            Control_WingToTargetVertically(point_FieldCenter.position, 0.7f);
                        }
                        Control_WingToTargetByTurning(point_FieldCenter.position, 0.15f);
                    }
                    if (Vector3.Angle(point_FieldCenter.position - transform.position, transform.forward) <= angleLow * 1 / 9)
                    {
                        switchEvasionLR = 0;
                    }
                }
            }
            // Recruit.
            if (level_Pilot == 1)
            {
                Lever_Pull(0.3f);
                Control_WingToTargetVertically(point_FieldCenter.position, 0.7f);
            }
        }
    }

    // Bombing Target Manager
    void BombingTarget_Manager()
    {

        // OurForces.
        if (signal_IsEnemy == 0)
        {
            // Find my air target.
            if (wingCommand.haveLandTarget_OurForces[viewNum_OurForces] == 0)
            {
                signal_FlyToBombingTarget = 0;
                wingCommand.FindMyLandTarget_OurForces(viewNum_OurForces);
            }
            // If the target was allocated on me. then, get the target's position.
            else
            {
                if (wingCommand.status_LandUnit[wingCommand.myLandTargetID_OurForces[viewNum_OurForces]] == 1 &&
                    wingCommand.affiliatedGroup_LandUnit[wingCommand.myLandTargetID_OurForces[viewNum_OurForces]] == 2)
                {
                    point_BombingTarget = wingCommand.FindMyLandUnitTransform_OurForces(viewNum_OurForces);
                }
                // My target was destroyed, so... Find new land target.
                else
                {
                    signal_FlyToBombingTarget = 0;
                    bool status = wingCommand.FindMyNewLandTarget_OurForces(viewNum_OurForces);
                    if (status == false)
                    {
                        // Bombing is ended. Return to base.
                        point_BombingTarget = point_Return;
                        Control_WingToHorizontality(0.1f);
                        if (flightOrder == 3)
                            StartCoroutine(Order_FlyToReturnPoint(3, 0, viewNum_OurForces));
                    }
                }
            }
        }
        // Enemy.
        else
        {
            // Find my Land target.
            if (wingCommand.haveLandTarget_Enemy[viewNum_Enemy] == 0)
            {
                signal_FlyToBombingTarget = 0;
                wingCommand.FindMyLandTarget_Enemy(viewNum_Enemy);
            }
            // If the target was allocated on me. then, get the target's position.
            else
            {
                if (wingCommand.status_LandUnit[wingCommand.myLandTargetID_Enemy[viewNum_Enemy]] == 1 &&
                    wingCommand.affiliatedGroup_LandUnit[wingCommand.myLandTargetID_OurForces[viewNum_OurForces]] == 1)
                {
                    point_BombingTarget = wingCommand.FindMyAirTargetTransform_Enemy(viewNum_Enemy);
                }
                // My target was destroyed, so... Find new land target.
                else
                {
                    signal_FlyToBombingTarget = 0;
                    bool status = wingCommand.FindMyNewLandTarget_Enemy(viewNum_Enemy);
                    if (status == false)
                    {
                        // Bombing is ended. Return to base.
                        point_BombingTarget = point_Return;
                        Control_WingToHorizontality(0.1f);
                        if (flightOrder == 3)
                            StartCoroutine(Order_FlyToReturnPoint(3, 0, viewNum_Enemy));
                    }
                }
            }
        }
    }

    // Fly To target for Bombardment
    Vector3 head_Target = new Vector3(0, 0, 0);
    float distance_TargetHead;
    float distance_RequiredToTH;
    float distance_ConfirmBombingTarget;
    void BombingTactic(Transform target, int typeAircraft)
    {

        // Combat-Ready if target is none.
        if (target == null)
            flightOrder = 0;

        // Helicopter.
        if (typeAircraft == 3)
        {
            distance_TargetHead = 1200f * pilotage;
            distance_RequiredToTH = 5500f * pilotage;
            distance_ConfirmBombingTarget = 3300f;
        }
        // Others.
        else
        {
            distance_TargetHead = 2500f * pilotage;
            distance_RequiredToTH = 5500f * pilotage;
            distance_ConfirmBombingTarget = 4300f;
        }

        // Fly to Target head.
        if (signal_FlyToBombingTarget == 0)
        {
            head_Target.x = target.position.x;
            head_Target.y = target.position.y + distance_TargetHead;
            head_Target.z = target.position.z;

            // After reached to head of target, Order to fly to bombing Target.
            // Propeller.
            if (typeAircraft == 0)
            {
                GeneralFlight(head_Target, 0);
                if (Vector3.Distance(transform.position, head_Target) < distance_RequiredToTH && (transform.position.y - point_LandZero.position.y) > 2400f)
                    signal_FlyToBombingTarget = 1;

            }
            // Bomber.
            if (typeAircraft == 1)
            {
                GeneralFlight(head_Target, 1);
                Control_WingToHorizontality(0.45f);
                if (Vector3.Distance(transform.position, head_Target) < distance_RequiredToTH * 0.38f && (transform.position.y - point_LandZero.position.y) > 1800f)
                    signal_FlyToBombingTarget = 1;
            }
            // Jet.
            if (typeAircraft == 2)
            {
                GeneralFlight(head_Target, 2);
                if (Vector3.Distance(transform.position, head_Target) < distance_RequiredToTH && (transform.position.y - point_LandZero.position.y) > 3400f)
                    signal_FlyToBombingTarget = 1;
            }
            // Helicopter.
            if (typeAircraft == 3)
            {
                GeneralFlight(head_Target, 3);
                if (Vector3.Distance(transform.position, head_Target) < distance_RequiredToTH && (transform.position.y - point_LandZero.position.y) > 500f)
                    signal_FlyToBombingTarget = 1;
                Control_WingToHorizontality(0.6f);
            }
        }
        // Fly to Target.
        else
        {
            // Type Propeller Or A10.
            if (typeAircraft == 0)
            {
                GeneralFlight(target.position, 0);

                // Bombing
                if (Vector3.Distance(transform.position, target.position) < distance_ConfirmBombingTarget)
                {
                    if (Vector3.Angle(transform.forward, target.position - transform.position) < 7f - pilotage)
                    {
                        signal_Gunfire = 1;
                    }
                }
                if (Vector3.Distance(transform.position, target.position) < distance_ConfirmBombingTarget * 0.8f)
                {
                    if (Vector3.Angle(transform.forward, target.position - transform.position) < 5f - pilotage)
                        signal_Bombing = 1;
                    ResetBombTarget();
                    signal_FlyToBombingTarget = 0;
                    signal_LaunchingRocket = 1;
                    flightOrder = 0;
                }

                // Avoiding Land Crashing
                if (Vector3.Distance(transform.position, target.position) < distance_ConfirmBombingTarget * 0.7f)
                {
                    ResetBombTarget();
                    signal_FlyToBombingTarget = 0;
                    flightOrder = 0;

                    Lever_Pull(0.3f);
                    signal_Bombing = 0;
                }
            }
            // Type Bomber.
            if (typeAircraft == 1)
            {
                GeneralFlight(target.position, 1);

                signal_Bombing = 1;
                Control_WingToHorizontality(0.45f);
                StartCoroutine(End_BombingMission(5f));
            }
            // Type Jet.
            if (typeAircraft == 2)
            {
                GeneralFlight(target.position, 2);
                if (Vector3.Distance(transform.position, target.position) < distance_ConfirmBombingTarget * 1.5f)
                {
                    signal_Bombing = 1;
                    signal_LaunchingRocket = 1;
                    ResetBombTarget();
                    signal_FlyToBombingTarget = 0;
                    signal_LaunchingRocket = 1;
                    flightOrder = 0;
                }
            }
            // Type Helicopter.
            if (typeAircraft == 3)
            {
                Control_WingToHorizontality(0.15f);
                Control_HeadToTarget(target.position, 0.3f);
                Control_WingToTargetByTurning(target.position, 0.1f);
                if (Vector3.Distance(transform.position, target.position) < distance_ConfirmBombingTarget)
                {
                    signal_LaunchingRocket = 1;
                    StartCoroutine(End_BombingMission(7f));
                }

            }
        }

        AvoidCrashToLand(550f, typeAircraft);

        // Fire.
        GunfireBySignal();
        BombingBySignal(type_Aircraft);
        LaunchingRocketBySignal();
    }

    IEnumerator End_BombingMission(float time)
    {

        yield return new WaitForSeconds(time);

        ResetBombTarget();
        signal_FlyToBombingTarget = 0;
        signal_LaunchingRocket = 0;
        flightOrder = 0;
    }

    // Reset Bombing Target after it destroyed.
    void ResetBombTarget()
    {
        // OurForces.
        if (signal_IsEnemy == 0)
        {
            if (wingCommand.haveLandTarget_OurForces[viewNum_OurForces] == 1)
            {
                wingCommand.myLandTargetID_OurForces[viewNum_OurForces] = 0;
                wingCommand.haveLandTarget_OurForces[viewNum_OurForces] = 0;
            }
        }
        // Enemy.
        else
        {
            if (wingCommand.haveLandTarget_Enemy[viewNum_Enemy] == 1)
            {
                wingCommand.myLandTargetID_Enemy[viewNum_Enemy] = 0;
                wingCommand.haveLandTarget_Enemy[viewNum_Enemy] = 0;
            }
        }
    }

    // Flying To target
    int signal_FlyToBombingTarget = 0;
    int signal_FlyInFormation = 0;
    float angleHigh = 15f;
    float angleLow = 5f;
    public void FlyToDogfightTarget()
    {
        // Avoid Crash to Land.
        AvoidCrashToLand(1750f, type_Aircraft);
        if (signal_DoEvasiveFlight == 0)
        {
            // Dogfight Tactic.
            DogfightTarget_Manager();
            // Propeller Aircraft.
            DogfightTactic(point_MainTarget, type_Aircraft);
        }
        else
        {
            // Avoid the Tail Catcher's Attack.
            // Propeller Aircraft.
            EvasionFlight(type_Aircraft);
        }
    }

    public void FlyToBombingTarget()
    {

        // Bombing Tactic.
        BombingTarget_Manager();
        // Propeller Aicraft.
        BombingTactic(point_BombingTarget, type_Aircraft);
    }

    // Fly to Return point
    int switch_ReturnPoint = 0;
    Vector3 mainReturnPoint = new Vector3();
    Vector3 anotherReturnPoint1 = new Vector3();
    Vector3 anotherReturnPoint2 = new Vector3();
    Vector3 anotherReturnPoint3 = new Vector3();
    Vector3 anotherReturnPoint4 = new Vector3();
    void FlyToReturnPoint(Transform point_Return)
    {

        // Rotate triagle points
        anotherReturnPoint1.x = point_Return.position.x - 4500;
        anotherReturnPoint1.y = point_Return.position.y;
        anotherReturnPoint1.z = point_Return.position.z - 4500;

        anotherReturnPoint2.x = point_Return.position.x + 4500;
        anotherReturnPoint2.y = point_Return.position.y;
        anotherReturnPoint2.z = point_Return.position.z - 4500;

        anotherReturnPoint3.x = point_Return.position.x + 4500;
        anotherReturnPoint3.y = point_Return.position.y;
        anotherReturnPoint3.z = point_Return.position.z + 4500;

        anotherReturnPoint4.x = point_Return.position.x + 4500;
        anotherReturnPoint4.y = point_Return.position.y;
        anotherReturnPoint4.z = point_Return.position.z + 4500;

        if (Vector3.Distance(transform.position, point_Return.position) < 2550f) switch_ReturnPoint = 1;
        if (Vector3.Distance(transform.position, anotherReturnPoint1) < 2550f) switch_ReturnPoint = 2;
        if (Vector3.Distance(transform.position, anotherReturnPoint2) < 2550f) switch_ReturnPoint = 3;
        if (Vector3.Distance(transform.position, anotherReturnPoint3) < 2550f) switch_ReturnPoint = 4;
        if (Vector3.Distance(transform.position, anotherReturnPoint4) < 2550f) switch_ReturnPoint = 0;

        if (switch_ReturnPoint == 0) mainReturnPoint = point_Return.position;
        if (switch_ReturnPoint == 1) mainReturnPoint = anotherReturnPoint1;
        if (switch_ReturnPoint == 2) mainReturnPoint = anotherReturnPoint2;
        if (switch_ReturnPoint == 3) mainReturnPoint = anotherReturnPoint3;
        if (switch_ReturnPoint == 4) mainReturnPoint = anotherReturnPoint4;

        GeneralFlight(mainReturnPoint, type_Aircraft);
        AvoidCrashToLand(750f, type_Aircraft);
    }

    // Fly to Indicated Path
    int switch_IndicatedPoint = 1;
    Vector3 mainIndicatedPoint = new Vector3();
    Vector3 anotherIndicatedPoint1 = new Vector3();
    Vector3 anotherIndicatedPoint2 = new Vector3();
    Vector3 anotherIndicatedPoint3 = new Vector3();
    Vector3 anotherIndicatedPoint4 = new Vector3();
    Vector3 anotherIndicatedPoint5 = new Vector3();
    Vector3 anotherIndicatedPoint6 = new Vector3();
    Vector3 anotherIndicatedPoint7 = new Vector3();
    void FlyToIndicatedPoint(Transform point_Indicated)
    {

        // Rotate 8-shaped points
        anotherIndicatedPoint1.x = point_Indicated.position.x;
        anotherIndicatedPoint1.y = point_Indicated.position.y;
        anotherIndicatedPoint1.z = point_Indicated.position.z;

        anotherIndicatedPoint2.x = point_Indicated.position.x - 1500;
        anotherIndicatedPoint2.y = point_Indicated.position.y;
        anotherIndicatedPoint2.z = point_Indicated.position.z + 1500;

        anotherIndicatedPoint3.x = point_Indicated.position.x - 3000;
        anotherIndicatedPoint3.y = point_Indicated.position.y;
        anotherIndicatedPoint3.z = point_Indicated.position.z;

        anotherIndicatedPoint4.x = point_Indicated.position.x - 1500;
        anotherIndicatedPoint4.y = point_Indicated.position.y;
        anotherIndicatedPoint4.z = point_Indicated.position.z - 1500;

        anotherIndicatedPoint5.x = point_Indicated.position.x + 1500;
        anotherIndicatedPoint5.y = point_Indicated.position.y;
        anotherIndicatedPoint5.z = point_Indicated.position.z + 1500;

        anotherIndicatedPoint6.x = point_Indicated.position.x + 3000;
        anotherIndicatedPoint6.y = point_Indicated.position.y;
        anotherIndicatedPoint6.z = point_Indicated.position.z;

        anotherIndicatedPoint7.x = point_Indicated.position.x + 1500;
        anotherIndicatedPoint7.y = point_Indicated.position.y;
        anotherIndicatedPoint7.z = point_Indicated.position.z - 1500;

        if (Vector3.Distance(transform.position, point_Indicated.position) < 250f) switch_IndicatedPoint = 1;
        if (Vector3.Distance(transform.position, anotherIndicatedPoint1) < 250f) switch_IndicatedPoint = 2;
        if (Vector3.Distance(transform.position, anotherIndicatedPoint2) < 250f) switch_IndicatedPoint = 3;
        if (Vector3.Distance(transform.position, anotherIndicatedPoint3) < 250f) switch_IndicatedPoint = 4;
        if (Vector3.Distance(transform.position, anotherIndicatedPoint4) < 250f) switch_IndicatedPoint = 5;
        if (Vector3.Distance(transform.position, anotherIndicatedPoint5) < 250f) switch_IndicatedPoint = 6;
        if (Vector3.Distance(transform.position, anotherIndicatedPoint6) < 250f) switch_IndicatedPoint = 7;
        if (Vector3.Distance(transform.position, anotherIndicatedPoint7) < 250f) switch_IndicatedPoint = 1;

        if (switch_IndicatedPoint == 1) mainIndicatedPoint = anotherIndicatedPoint1;
        if (switch_IndicatedPoint == 2) mainIndicatedPoint = anotherIndicatedPoint2;
        if (switch_IndicatedPoint == 3) mainIndicatedPoint = anotherIndicatedPoint3;
        if (switch_IndicatedPoint == 4) mainIndicatedPoint = anotherIndicatedPoint4;
        if (switch_IndicatedPoint == 5) mainIndicatedPoint = anotherIndicatedPoint5;
        if (switch_IndicatedPoint == 6) mainIndicatedPoint = anotherIndicatedPoint6;
        if (switch_IndicatedPoint == 7) mainIndicatedPoint = anotherIndicatedPoint7;

        GeneralFlight(mainIndicatedPoint, type_Aircraft);
        AvoidCrashToLand(750f, type_Aircraft);
    }


    Vector3 genPos = new Vector3();
    private int signal_SelectedFlightPath = 0;
    void FormationFlightPath()
    {

        // Get the mouse position and convert it to world position.
        if (view.camPos == 120 && wingCommand.signal_SelectFlightPath == 1 && viewNum_OurForces == wingCommand.selectedViewNum_OurForces)
        {
            if (Input.GetMouseButtonDown(1))
                signal_SelectedFlightPath = 1;
        }
        // Select the flight path from mouse position.
        if (signal_SelectedFlightPath == 1)
        {
            genPos.x = (Input.mousePosition.x - Screen.width / 2) * (21000f) / Screen.width;
            genPos.y = (Input.mousePosition.y - Screen.height / 2) * (11000f) / Screen.height;

            // Insert the flight path position.
            wingCommand.transform_FormationFlightPath_OurForces[wingCommand.selectedFormationNum_OurForces].x = transform.position.x + genPos.x;
            wingCommand.transform_FormationFlightPath_OurForces[wingCommand.selectedFormationNum_OurForces].y = transform.position.y;
            wingCommand.transform_FormationFlightPath_OurForces[wingCommand.selectedFormationNum_OurForces].z = transform.position.z + genPos.y;

            // have flight path.
            wingCommand.haveFormationFlightPath_OurForces[wingCommand.selectedFormationNum_OurForces] = 1;

            // Generate flightpath image.
            Instantiate(wingCommand.flightPath, wingCommand.transform_FormationFlightPath_OurForces[wingCommand.selectedFormationNum_OurForces], Quaternion.Euler(Vector3.forward));
            signal_SelectedFlightPath = 0;
        }
    }

    // Fly in flight formation.
    public void FlyInFormation()
    {

        if (signal_FlyInFormation == 1 && statusFlight == 1)
        {

            //Vector3 toLeader = transform.position;
            Vector3 pos_Target = transform.position;
            Transform formationLeaderOrigin = null;

            AvoidCrashToLand(750f, type_Aircraft);

            // Indicate the formation flight path.
            FormationFlightPath();

            // Not Leader
            if (signal_IsFormationLeader == 0)
            {
                // Get the leader's position.
                if (signal_IsEnemy == 0)
                    formationLeaderOrigin = wingCommand.FindFormationLeaderTransform_OurForces(viewNum_OurForces, num_Formation);
                else
                    formationLeaderOrigin = wingCommand.FindFormationLeaderTransform_Enemy(viewNum_Enemy, num_Formation);
            }
            // Leader
            else
            {
                // Fly to Flight Path.
                if (wingCommand.haveFormationFlightPath_OurForces[num_Formation] == 1)
                {
                    pos_Target = wingCommand.transform_FormationFlightPath_OurForces[num_Formation];

                    // If aircraft reach the destination...
                    if (Vector3.Distance(transform.position, pos_Target) < 1200f)
                        wingCommand.haveFormationFlightPath_OurForces[num_Formation] = 0;
                }
                // Fly to Return Point.
                else
                {
                    pos_Target = point_Return.position;

                }
            }

            // Direction to leader.
            //toLeader = formationLeaderOrigin.position - transform.position;
            Vector3 myFormationPosition = transform.position;

            // Recieve formation from WingCommand.
            formationType = wingCommand.formationTypeByWingCommand;

            if (signal_IsFormationLeader == 0 && formationLeaderOrigin != null)
            {
                // Basic Formation
                if (formationType == 0)
                {
                    if (num_FormationOrder > 2)
                    {
                        myFormationPosition = formationLeaderOrigin.TransformPoint(Vector3.right * (-1f) * num_FormationOrder * 16.7f + Vector3.forward * 50f);

                        pos_Target = myFormationPosition;
                    }
                    else
                    {
                        myFormationPosition = formationLeaderOrigin.TransformPoint(Vector3.right * (1f) * num_FormationOrder * 50f + Vector3.forward * 50f);

                        pos_Target = myFormationPosition;
                    }
                }
                // Rush Formation
                if (formationType == 1)
                {
                    if (num_FormationOrder > 2)
                    {
                        myFormationPosition.x = formationLeaderOrigin.TransformPoint(Vector3.right * (-1f) * num_FormationOrder * 16.7f).x;
                        myFormationPosition.y = formationLeaderOrigin.TransformPoint(Vector3.right * (-1f) * num_FormationOrder * 16.7f).y;
                        myFormationPosition.z = formationLeaderOrigin.TransformPoint(Vector3.forward * (-1f) * num_FormationOrder * 15f + Vector3.forward * 50f).x;
                        pos_Target = myFormationPosition;
                    }
                    else
                    {
                        myFormationPosition.x = formationLeaderOrigin.TransformPoint(Vector3.right * (1f) * num_FormationOrder * 15f).x;
                        myFormationPosition.y = formationLeaderOrigin.TransformPoint(Vector3.right * (1f) * num_FormationOrder * 15f).y;
                        myFormationPosition.z = formationLeaderOrigin.TransformPoint(Vector3.forward * (-1f) * num_FormationOrder * 15f + Vector3.forward * 50f).z;
                        pos_Target = myFormationPosition;
                    }
                }
                // Following Formation
                if (formationType == 2)
                {
                    myFormationPosition = formationLeaderOrigin.TransformPoint(Vector3.forward * (-1f) * num_FormationOrder * 50);

                    pos_Target = myFormationPosition;
                }

                // Revise the distance of Leader.
                // In my formation area.
                if (Vector3.Distance(transform.position, pos_Target) < 35f)
                {

                    // Fit the velocity to leader.
                    if (signal_IsEnemy == 0)
                        throttle_Aircraft = Mathf.Lerp(throttle_Aircraft, velocity_Standard, Time.deltaTime * 10f);
                    else
                        throttle_Aircraft = Mathf.Lerp(throttle_Aircraft, velocity_Standard, Time.deltaTime * 10f);

                }
                // In my formation area.
                if (Vector3.Distance(transform.position, pos_Target) < 350f && Vector3.Distance(transform.position, pos_Target) >= 35f)
                {

                    // Fit the velocity to leader.
                    if (throttle_Aircraft > velocity_Standard * 1.03f)
                        throttle_Aircraft -= 2f;
                }
                // Out of my formation area.
                if (Vector3.Distance(transform.position, pos_Target) >= 350f)
                {

                    // My formation position is in front of me.
                    if ((Vector3.Angle(pos_Target - transform.position, transform.forward) > 0 &&
                        Vector3.Angle(pos_Target - transform.position, transform.forward) < 60) &&
                        Vector3.Distance(pos_Target, point_Front.position) < Vector3.Distance(pos_Target, point_Behind.position))
                    {
                        if (throttle_Aircraft < velocity_Standard * 1.1f)
                            throttle_Aircraft += 0.1f;
                    }
                }
                // Out of my formation area.
                if (Vector3.Distance(transform.position, pos_Target) >= 650f)
                {

                    // My formation position is in front of me.
                    if ((Vector3.Angle(pos_Target - transform.position, transform.forward) > 0 &&
                        Vector3.Angle(pos_Target - transform.position, transform.forward) < 60) &&
                        Vector3.Distance(pos_Target, point_Front.position) < Vector3.Distance(pos_Target, point_Behind.position))
                    {
                        if (throttle_Aircraft < velocity_Standard * 1.2f)
                            throttle_Aircraft += 0.1f;
                    }
                }
            }
            // Is Formation Leader.
            else
            {
                if (signal_IsEnemy == 0)
                {
                    throttle_Aircraft = Mathf.Lerp(throttle_Aircraft, velocity_Standard, Time.deltaTime * 10f);
                }
                else
                {
                    throttle_Aircraft = Mathf.Lerp(throttle_Aircraft, velocity_Standard, Time.deltaTime * 10f);
                }
            }
            GeneralFlight(pos_Target, type_Aircraft);
        }
    }

    // Move or Fly to TakingOff/Landing point
    void MoveOrFlyToTLPoint(Vector3 point_TL, int process)
    {

        // Indicated TOL Process.
        if (process == 1 || process == 2 || process == 3 || process == -1 || process == -2 || process == -3)
        {
            if (process == -1 || process == 1 || process == 2)
            {
                // For Tail wheel rotation.
                Control_WingToTargetByTurningInRunway(point_TL, 0.8f, angleTailWheel);
            }
            else
            {
                Control_WingToTargetByTurning(point_TL, 0.15f);
            }

            Control_WingToHorizontality(0.15f);
            if (process == -3)
            {
                Control_MainBodyToHorizontally(0.01f);
                Control_HeadToTarget(point_TL, 0.05f);
            }
            else
            {
                Control_MainBodyToHorizontally(0.05f);
            }
        }
        else
        {
            GeneralFlight(point_TL, type_Aircraft);
        }
    }

    // Avoiding Crash to Aircraft
    public void AvoidCrashToAircraft(Vector3 otherPosition)
    {

        // Collider is left from me.
        if (Vector3.Distance(otherPosition, point_Left.position) <
            Vector3.Distance(otherPosition, point_Right.position))
        {
            Lever_TiltR(0.5f);
            Lever_Pull(0.5f);
        }
        // Collider is right from me.
        if (Vector3.Distance(otherPosition, point_Left.position) >
            Vector3.Distance(otherPosition, point_Right.position))
        {
            Lever_TiltL(0.5f);
            Lever_Pull(0.5f);
        }
    }

    // Avoiding Crash to Land
    public void AvoidCrashToLand(float distance, int typeAircraft)
    {

        // Confirm Land Distance.
        float range_ConfirmLandDistance = distance;

        // Check the distance from the Aircraft to Land.
        if (signal_IsDestroyed == 0)
        {
            // Helicopter.
            if (typeAircraft == 3)
            {
                RaycastHit hit;
                if (Physics.Raycast(point_RaycastL.position, transform.TransformDirection(Vector3.forward), out hit, range_ConfirmLandDistance * 0.7f) ||
                    Physics.Raycast(point_RaycastM.position, transform.TransformDirection(Vector3.forward), out hit, range_ConfirmLandDistance * 0.7f) ||
                    Physics.Raycast(point_RaycastR.position, transform.TransformDirection(Vector3.forward), out hit, range_ConfirmLandDistance * 0.7f) ||
                    Physics.Raycast(point_RaycastM.position, transform.TransformDirection(Vector3.down), out hit, range_ConfirmLandDistance * 0.7f))
                {
                    if (hit.collider.gameObject.tag == "Land")
                    {
                        Lever_Pull(0.3f);
                    }
                }
                if (Physics.Raycast(point_RaycastM.position, point_RaycastM.right * (-1f), out hit, range_ConfirmLandDistance * 2f))
                {
                    if (hit.collider.gameObject.tag == "Land")
                    {
                        Lever_TiltR(0.8f);
                    }
                }
                if (Physics.Raycast(point_RaycastM.position, point_RaycastM.right, out hit, range_ConfirmLandDistance * 2f))
                {
                    if (hit.collider.gameObject.tag == "Land")
                    {
                        Lever_TiltL(0.8f);
                    }
                }
            }
            // Others.
            else
            {
                RaycastHit hit;
                if (Physics.Raycast(point_RaycastL.position, transform.TransformDirection(Vector3.forward), out hit, range_ConfirmLandDistance) ||
                    Physics.Raycast(point_RaycastM.position, transform.TransformDirection(Vector3.forward), out hit, range_ConfirmLandDistance) ||
                    Physics.Raycast(point_RaycastR.position, transform.TransformDirection(Vector3.forward), out hit, range_ConfirmLandDistance) ||
                    Physics.Raycast(point_RaycastM.position, transform.TransformDirection(Vector3.down), out hit, range_ConfirmLandDistance))
                {
                    if (hit.collider.gameObject.tag == "Land")
                    {
                        Lever_Pull(0.3f);
                    }
                }
                if (Physics.Raycast(point_RaycastM.position, point_RaycastM.right * (-1f), out hit, range_ConfirmLandDistance * 2f))
                {
                    if (hit.collider.gameObject.tag == "Land")
                    {
                        Lever_TiltR(0.8f);
                    }
                }
                if (Physics.Raycast(point_RaycastM.position, point_RaycastM.right, out hit, range_ConfirmLandDistance * 2f))
                {
                    if (hit.collider.gameObject.tag == "Land")
                    {
                        Lever_TiltL(0.8f);
                    }
                }
            }
        }
    }

    // Gunfire
    int signal_Gunfire = 0;
    float timeFire = 0;
    float waitFire = 0.8f;
    int switch_Bullet = 0;
    void Fire()
    {

        if (switch_Bullet == 0)
        {
            Instantiate(bullet, point_GunLeft.position, point_GunLeft.rotation);
            Instantiate(bullet, point_GunRight.position, point_GunRight.rotation);
            switch_Bullet = 1;
            return;
        }
        if (switch_Bullet == 1) { switch_Bullet = 2; return; }
        if (switch_Bullet == 2) { switch_Bullet = 3; return; }
        if (switch_Bullet == 3) { switch_Bullet = 4; return; }
        if (switch_Bullet == 4) { switch_Bullet = 5; return; }
        if (switch_Bullet == 5) { switch_Bullet = 6; return; }
        if (switch_Bullet == 6) { switch_Bullet = 7; return; }
        if (switch_Bullet == 7) { switch_Bullet = 8; return; }
        if (switch_Bullet == 8) { switch_Bullet = 9; return; }
        if (switch_Bullet == 9) { switch_Bullet = 0; return; }
    }

    public void GunfireBySignal()
    {

        if (signal_Gunfire == 1)
        {
            gunFireSoundSource.volume = 1;

            // Creat the Bullets.
            Fire();
            effect_MuzzleFlashL.SetActive(true);
            effect_MuzzleFlashR.SetActive(true);

        }
    }

    // Bombing.
    int signal_Bombing = 0;
    float timeBombing;
    float waitBombing = 0.5f;
    public void BombingBySignal(int typeAircraft)
    {

        if (signal_Bombing == 1)
        {
            // Type Propeller or A10.
            if (typeAircraft == 0)
            {
                Instantiate(bomb, point_Bomb.position, point_Bomb.rotation);
                signal_Bombing = 0;
            }
            // Type Bomber.
            if (typeAircraft == 1)
            {
                timeBombing += Time.deltaTime;
                if (timeBombing > waitBombing)
                {
                    Instantiate(bomb, point_Bomb.position, point_Bomb.rotation);
                    signal_Bombing = 0;
                    timeBombing = 0;
                }

            }
            // Type Jet.
            if (typeAircraft == 2)
            {
                Instantiate(bomb, point_Bomb.position, point_Bomb.rotation);
                signal_Bombing = 0;
            }
        }
    }

    // Launching Rocket.
    int signal_LaunchingRocket = 0;
    int selectedRocket = 0;
    float timeLaunching;
    float waitLaunching = 0.5f;
    public void LaunchingRocketBySignal()
    {

        if (signal_LaunchingRocket == 1)
        {
            if (type_Aircraft == 3)
            {
                timeLaunching += Time.deltaTime;
                if (timeLaunching > waitLaunching)
                {
                    if (selectedRocket == 0)
                    {
                        Instantiate(rocket, point_RocketLeft.position, point_RocketLeft.rotation);
                        selectedRocket = 1;
                        signal_LaunchingRocket = 0;
                        timeLaunching = 0;
                        return;
                    }
                    if (selectedRocket == 1)
                    {
                        Instantiate(rocket, point_RocketRight.position, point_RocketRight.rotation);
                        selectedRocket = 0;
                        signal_LaunchingRocket = 0;
                        timeLaunching = 0;
                        return;
                    }
                    timeLaunching = 0;
                }
            }
            else
            {
                if (selectedRocket == 0)
                {
                    Instantiate(rocket, point_RocketLeft.position, point_RocketLeft.rotation);
                    selectedRocket = 1;
                    signal_LaunchingRocket = 0;
                    return;
                }
                if (selectedRocket == 1)
                {
                    Instantiate(rocket, point_RocketRight.position, point_RocketRight.rotation);
                    selectedRocket = 0;
                    signal_LaunchingRocket = 0;
                    return;
                }
            }
        }
    }

    // Hit-Point Manager
    public void HP_Manager()
    {

        if (hitpoint <= 30 - pilotage * 5)
            effect_Smoke.SetActive(true);
        if (hitpoint > 0 && hitpoint <= 20 - pilotage * 5)
            hitpoint -= Time.deltaTime * 0.01f;
        if (hitpoint <= 10 - pilotage * 5)
            effect_Fire.SetActive(true);
        if (hitpoint <= 0)
        {
            signal_IsDestroyed = 1;
            if (statusFlight == 1)
                statusFlight = -3;
        }
    }

    // Destroyed aircraft Event.
    public int signal_IsDestroyed = 0;
    int callOneTimeWingCommandInfo = 1;
    public void DestroyedAircraft()
    {

        if (signal_IsDestroyed == 1)
        {
            if (hitpoint != 0)
                hitpoint = 0;

            if (signal_IsFormationLeader == 1)
                signal_IsFormationLeader = 0;

            FallingDownToLand(type_Aircraft);
            engineSoundSource.volume = 0;
            gunFireSoundSource.volume = 0;
            signal_Gunfire = 0;
            effect_MuzzleFlashL.SetActive(false);
            effect_MuzzleFlashR.SetActive(false);

            if (callOneTimeWingCommandInfo == 1)
            {
                // Update WingCommand Information.
                UpdateInformationToWingCommandInfo();

                if (signal_IsEnemy == 0)
                {
                    // Appoint New Formation Leader
                    wingCommand.Init_NewFormationLeader_OurForces(viewNum_OurForces, type_Aircraft);

                    // Reset Wingcommand Info.
                    wingCommand.isLeader_OurForces[viewNum_OurForces] = 0;
                    wingCommand.formationNum_OurForces[viewNum_OurForces] = 0;
                    wingCommand.formationOrder_OurForces[viewNum_OurForces] = 0;
                    wingCommand.flightOrder_OurForces[viewNum_OurForces] = 0;
                    wingCommand.myAirTargetID_OurForces[viewNum_OurForces] = 0;
                    wingCommand.haveAirTarget_OurForces[viewNum_OurForces] = 0;
                    wingCommand.myLandTargetID_OurForces[viewNum_OurForces] = 0;

                    wingCommand.totalNum_OurForces -= 1;
                }
                else
                {
                    // Appoint New Formation Leader
                    wingCommand.Init_NewFormationLeader_Enemy(viewNum_Enemy, type_Aircraft);

                    // Reset Wingcommand Info.
                    wingCommand.isLeader_Enemy[viewNum_Enemy] = 0;
                    wingCommand.formationNum_Enemy[viewNum_Enemy] = 0;
                    wingCommand.formationOrder_Enemy[viewNum_Enemy] = 0;
                    wingCommand.flightOrder_Enemy[viewNum_Enemy] = 0;
                    wingCommand.myAirTargetID_Enemy[viewNum_Enemy] = 0;
                    wingCommand.haveAirTarget_Enemy[viewNum_Enemy] = 0;
                    wingCommand.myLandTargetID_Enemy[viewNum_Enemy] = 0;

                    wingCommand.totalNum_Enemy -= 1;
                }
                callOneTimeWingCommandInfo = 0;
            }
        }
    }

    // Taking Off/Landing Mission.
    Vector3 point_FollowToTLPath;
    public int signal_TakingOff = 0;
    public int signal_Landing = 0;
    public int destination_TL = 0;
    // Taking off Mission.
    public void TakingOffMission()
    {

        // On Land
        if (statusFlight == -1 && signal_TakingOff == 1 && signal_Landing == 0)
        {
            // Helicopter
            if (type_Aircraft == 3)
            {
                transform.position += new Vector3(0, Time.deltaTime * 2.5f, 0);
                Invoke("Ended_TakingOffMission", 20f);
            }
            // Others.
            else
            {
                // TakingOff Process 1.
                if (destination_TL == 1)
                {
                    // Align Position.
                    point_FollowToTLPath = point_TL1.TransformPoint(Vector3.right * num_FormationOrder * 25);
                    // Move to TL1.
                    MoveOrFlyToTLPoint(point_FollowToTLPath, 1);
                    // Increase the aircraft velocity.
                    if (throttle_Aircraft < velocity_Standard * 0.1f)
                        throttle_Aircraft += Time.deltaTime * 3f;

                    // Attach the aircraft on runway.
                    if (point_RunwayZero.position.y < point_RightWingWheel.position.y)
                        transform.position -= new Vector3(0, Time.deltaTime * 2f, 0);
                    if (point_RunwayZero.position.y >= point_RightWingWheel.position.y)
                        transform.position += new Vector3(0, Time.deltaTime * 2f, 0);

                    if (Vector3.Distance(transform.position, point_TL1.position) < 250f)
                        destination_TL = 2;
                }
                // TakingOff Process 2.
                if (destination_TL == 2)
                {
                    // Align Position.
                    point_FollowToTLPath = point_TL2.TransformPoint(Vector3.right * num_FormationOrder * 25);
                    // Move to TL2.
                    MoveOrFlyToTLPoint(point_FollowToTLPath, 2);
                    // Increase the aircraft velocity.
                    if (throttle_Aircraft < velocity_Standard * 0.15f)
                        throttle_Aircraft += Time.deltaTime * 3f;

                    // Attach the aircraft on runway.
                    if (point_RunwayZero.position.y < point_RightWingWheel.position.y)
                        transform.position -= new Vector3(0, Time.deltaTime * 2f, 0);

                    if (point_RunwayZero.position.y >= point_RightWingWheel.position.y)
                        transform.position += new Vector3(0, Time.deltaTime * 2f, 0);

                    if (Vector3.Distance(transform.position, point_TL2.position) < 200f)
                        destination_TL = 3;
                }
                // TakingOff Process 3.
                if (destination_TL == 3)
                {
                    // Align Position.
                    point_FollowToTLPath = point_TL3.TransformPoint(Vector3.right * num_FormationOrder * 25);
                    // Move to TL3.
                    MoveOrFlyToTLPoint(point_FollowToTLPath, 3);

                    if (Vector3.Distance(transform.position, point_TL2.position) < 250f)
                        Control_WingToTargetByTurningInRunway(point_FollowToTLPath, 0.3f, angleTailWheel);
                    // Increase the aircraft velocity.
                    if (throttle_Aircraft < velocity_Standard * 0.9f)
                        throttle_Aircraft += Time.deltaTime * 5f;
                    if (Vector3.Distance(transform.position, point_TL3.position) < 350f)
                        destination_TL = 4;
                }
                // TakingOff Process 4.
                if (destination_TL == 4)
                {
                    // Align Position.
                    point_FollowToTLPath = point_TL4.TransformPoint(Vector3.right * num_FormationOrder * 25);
                    // Fly to TL4.
                    MoveOrFlyToTLPoint(point_FollowToTLPath, 4);
                    // Increase the aircraft velocity.
                    if (velocityInAirport < velocity_Standard * 0.95f)
                        velocityInAirport += Time.deltaTime * 5.5f;
                    if (Vector3.Distance(transform.position, point_TL3.position) > 370f)
                        if (signal_LandingGearOn == 1)
                            signal_LandingGearOn = 0;
                    if (Vector3.Distance(transform.position, point_TL4.position) < 750f)
                        destination_TL = 5;
                }
                // TakingOff Process 5.
                if (destination_TL == 5)
                {
                    // Align Position.
                    point_FollowToTLPath = point_TL5.TransformPoint(Vector3.right * num_FormationOrder * 250);
                    // Fly to TL5.
                    MoveOrFlyToTLPoint(point_FollowToTLPath, 5);
                    // Increase the aircraft velocity.
                    if (throttle_Aircraft < velocity_Standard)
                        throttle_Aircraft += Time.deltaTime * 6f;
                    else
                        throttle_Aircraft = velocity_Standard;

                    if (Vector3.Distance(transform.position, point_TL5.position) < 5200f)
                        Ended_TakingOffMission();
                }
            }
        }
    }

    void Ended_TakingOffMission()
    {

        statusFlight = 1;

        if (signal_IsEnemy == 0)
            wingCommand.status_OurForces[viewNum_OurForces] = statusFlight;
        else
            wingCommand.status_OurForces[viewNum_OurForces] = statusFlight;

        // Formation Flight.
        flightOrder = 4;
        if (signal_IsEnemy == 0)
        {
            wingCommand.flightOrder_OurForces[viewNum_OurForces] = flightOrder;
            StartCoroutine(Order_FormationFlight(3, num_Formation, viewNum_OurForces));
        }
        else
        {
            wingCommand.flightOrder_Enemy[viewNum_Enemy] = flightOrder;
            StartCoroutine(Order_FormationFlight(3, num_Formation, viewNum_Enemy));
        }

        // Init. TL Process.
        destination_TL = 0;
        signal_TakingOff = 0;
        signal_Landing = 0;
        signal_LandingGearOn = 0;
        signal_InAirport = 0;
        velocityInAirport = 0;
    }

    float descendAcceleration;
    public void LandingMission()
    {

        // Landing.
        if (statusFlight == 1 && signal_Landing == 1 && signal_TakingOff == 0)
        {
            // Helicopter
            if (type_Aircraft == 3)
            {
                // Fly to TL5.
                if (destination_TL == 0 && signal_InAirport == 0)
                {
                    // Align Position.
                    point_FollowToTLPath = point_TL1.TransformPoint(Vector3.up * 200);

                    // Fly to TL Point.
                    MoveOrFlyToTLPoint(point_FollowToTLPath, -5);
                    Control_HeadToTarget(point_FollowToTLPath, 0.1f);

                    if (Vector3.Distance(transform.position, point_FollowToTLPath) < 2550f)
                    {
                        // Decrease the velocity.
                        if (throttle_Aircraft > velocity_Standard * 0.9f)
                            throttle_Aircraft -= Time.deltaTime * 3f;
                        if (velocityAircraft > 20)
                            velocityAircraft -= Time.deltaTime * 8f;
                    }
                    // descend.
                    if (Vector3.Distance(transform.position, point_FollowToTLPath) < Random.Range(200f, 350f))
                        destination_TL = 1;

                }
                // Destination for TOL is 1.
                if (destination_TL == 1 && signal_InAirport == 0)
                {
                    if (point_LeftWingWheel.position.y - point_RunwayZero.position.y > 0.1f)
                    {
                        // descend.
                        if (descendAcceleration < 0.1f)
                            descendAcceleration += Time.deltaTime * 0.1f;
                        transform.position = Vector3.Lerp(transform.position, point_TL1.TransformPoint(Vector3.right * num_FormationOrder * 70 + Vector3.forward * num_Formation * 5), Time.deltaTime * descendAcceleration);

                        // Balance.
                        Control_WingToHorizontality(0.2f);
                        Control_MainBodyToHorizontally(0.2f);

                        velocityAdvanced = 0;
                        velocityInAirport = 0;
                        velocityAircraft = 0;
                    }
                    else
                    {
                        Ended_LandingMission();
                    }
                }
            }
            // Others.
            else
            {
                // Landing Process -5.
                if (destination_TL == 0)
                {
                    // Align Position.
                    point_FollowToTLPath = point_TL5.TransformPoint(Vector3.right * num_FormationOrder * 50);
                    // Fly to TL5.
                    MoveOrFlyToTLPoint(point_FollowToTLPath, -5);
                    if (Vector3.Distance(transform.position, point_TL5.position) < 1200f)
                    {
                        destination_TL = 4;
                        signal_InAirport = 1;
                        velocityInAirport = velocityAdvanced;
                    }
                    // Decrease the aircraft velocity.
                    if (Vector3.Distance(transform.position, point_TL5.position) < 1500f)
                    {
                        if (throttle_Aircraft > velocity_Standard * 0.9f)
                        {
                            throttle_Aircraft -= Time.deltaTime * 3f;
                        }
                    }

                }
                // Landing Process -4.
                if (destination_TL == 4)
                {
                    // Align Position.
                    point_FollowToTLPath = point_TL4.TransformPoint(Vector3.right * num_FormationOrder * 50);
                    // Fly to TL4.
                    MoveOrFlyToTLPoint(point_FollowToTLPath, -4);
                    // Decrease the aircraft velocity.
                    if (throttle_Aircraft > velocity_Standard * 0.8f)
                        throttle_Aircraft -= Time.deltaTime * 3f;
                    if (Vector3.Distance(transform.position, point_TL4.position) < 1450f)
                        destination_TL = 3;
                }
                // Landing Process -3.
                // Landing Success.
                if (destination_TL == 3)
                {
                    // Align Position.
                    point_FollowToTLPath = point_TL3.TransformPoint(Vector3.right * num_FormationOrder * 50);
                    // Fly to TL3.
                    MoveOrFlyToTLPoint(point_FollowToTLPath, -3);
                    // Decrease the aircraft velocity.
                    if (throttle_Aircraft > velocity_Standard * 0.6f)
                        throttle_Aircraft -= Time.deltaTime * 3f;

                    if (Vector3.Distance(transform.position, point_TL3.position) < 950f)
                        if (signal_LandingGearOn == 0)
                            signal_LandingGearOn = 1;

                    if (Vector3.Distance(transform.position, point_TL3.position) < 350)
                        destination_TL = 2;

                }
                // Landing Process -2.
                if (destination_TL == 2)
                {
                    // Re-confirm Landing Gear.
                    if (signal_LandingGearOn == 0)
                        signal_LandingGearOn = 1;
                    // Align Position.
                    point_FollowToTLPath = point_TL2.TransformPoint(Vector3.right * num_FormationOrder * 50);
                    // Move to TL2.
                    MoveOrFlyToTLPoint(point_FollowToTLPath, -2);
                    // Decrease the aircraft velocity.
                    if (throttle_Aircraft > velocity_Standard * 0.3f)
                        throttle_Aircraft -= Time.deltaTime * 6f;
                    if (Vector3.Distance(transform.position, point_TL2.position) < 150)
                        destination_TL = 1;

                    // Attach the aircraft on runway.
                    if (point_RunwayZero.position.y < point_RightWingWheel.position.y)
                        transform.position -= new Vector3(0, Time.deltaTime * 3f, 0);

                    if (point_RunwayZero.position.y >= point_RightWingWheel.position.y)
                        transform.position += new Vector3(0, Time.deltaTime * 3f, 0);
                }
                // Landing Process -1.
                if (destination_TL == 1)
                {
                    // Align Position.               
                    point_FollowToTLPath = point_TL1.TransformPoint(Vector3.right * num_FormationOrder * 50 - Vector3.forward * num_Formation * 10);

                    // Move to TL1.
                    MoveOrFlyToTLPoint(point_FollowToTLPath, -1);
                    // Decrease the aircraft velocity.
                    if (throttle_Aircraft > velocity_Standard * 0.05f)
                        throttle_Aircraft -= Time.deltaTime * 8f;

                    if (Vector3.Distance(transform.position, point_FollowToTLPath) < 35f)
                        destination_TL = 10;

                    // Attach the aircraft on runway.
                    if (point_RunwayZero.position.y < point_RightWingWheel.position.y)
                        transform.position -= new Vector3(0, Time.deltaTime * 2f, 0);

                    if (point_RunwayZero.position.y >= point_RightWingWheel.position.y)
                        transform.position += new Vector3(0, Time.deltaTime * 2f, 0);
                }
                if (destination_TL == 10)
                {
                    if (throttle_Aircraft > 0)
                        throttle_Aircraft -= Time.deltaTime * 3f;
                    else
                        Ended_LandingMission();
                }
            }
        }
    }

    // Reset the values for landing mission.
    void Ended_LandingMission()
    {

        statusFlight = -1;
        velocityInAirport = 0;

        if (signal_IsEnemy == 0)
            wingCommand.status_OurForces[viewNum_OurForces] = statusFlight;
        else
            wingCommand.status_Enemy[viewNum_Enemy] = statusFlight;

        flightOrder = 0;
        if (signal_IsEnemy == 0)
            wingCommand.flightOrder_OurForces[viewNum_OurForces] = flightOrder;
        else
            wingCommand.flightOrder_Enemy[viewNum_Enemy] = flightOrder;

        // Init. Landing Process.
        destination_TL = 0;
        signal_TakingOff = 0;
        signal_Landing = 0;
        signal_LandingGearOn = 1;
        signal_InAirport = 1;
    }

    //==============================================================================
    // 5. Order and Receive Part
    //==============================================================================

    // Order Type
    // 1: All.
    // 2: formation.
    // 3: Individual.
    // Initializing and Ordering Returning to Base.
    IEnumerator Order_FlyToReturnPoint(int orderType, int numFormation, int viewNum)
    {

        yield return new WaitForSeconds(num_FormationOrder * 1f);
        if (signal_InAirport == 0 && statusFlight == 1)
        {
            // OurForces.
            if (signal_IsEnemy == 0)
            {
                // All.
                if (orderType == 1)
                {
                    flightOrder = 0;
                    signal_FlyToBombingTarget = 0;
                    signal_FlyInFormation = 0;
                    signal_TakingOff = 0;
                    signal_Landing = 0;

                    wingCommand.flightOrder_OurForces[viewNum_OurForces] = flightOrder;

                    // Update the Flight Information
                    UpdateInformationToWingCommandInfo();
                }
                // Formation.
                if (orderType == 2)
                {
                    if (numFormation == num_Formation)
                    {
                        flightOrder = 0;
                        signal_FlyToBombingTarget = 0;
                        signal_FlyInFormation = 0;
                        signal_TakingOff = 0;
                        signal_Landing = 0;

                        wingCommand.flightOrder_OurForces[viewNum_OurForces] = flightOrder;

                        // Update the Flight Information
                        UpdateInformationToWingCommandInfo();
                    }
                }
                // Individual.
                if (orderType == 3)
                {
                    if (viewNum == viewNum_OurForces)
                    {
                        flightOrder = 0;
                        signal_FlyToBombingTarget = 0;
                        signal_FlyInFormation = 0;
                        signal_TakingOff = 0;
                        signal_Landing = 0;

                        wingCommand.flightOrder_OurForces[viewNum_OurForces] = flightOrder;

                        // Update the Flight Information
                        UpdateInformationToWingCommandInfo();
                    }
                }
            }
            // Enemy.
            else
            {
                // All.
                if (orderType == 1)
                {
                    flightOrder = 0;
                    signal_FlyToBombingTarget = 0;
                    signal_FlyInFormation = 0;
                    signal_TakingOff = 0;
                    signal_Landing = 0;

                    wingCommand.flightOrder_Enemy[viewNum_Enemy] = flightOrder;

                    // Update the Flight Information
                    UpdateInformationToWingCommandInfo();
                }
                // Formation.
                if (orderType == 2)
                {
                    if (numFormation == num_Formation)
                    {
                        flightOrder = 0;
                        signal_FlyToBombingTarget = 0;
                        signal_FlyInFormation = 0;
                        signal_TakingOff = 0;
                        signal_Landing = 0;

                        wingCommand.flightOrder_Enemy[viewNum_Enemy] = flightOrder;

                        // Update the Flight Information
                        UpdateInformationToWingCommandInfo();
                    }
                }
                // Individual.
                if (orderType == 3)
                {
                    if (viewNum == viewNum_Enemy)
                    {
                        flightOrder = 0;
                        signal_FlyToBombingTarget = 0;
                        signal_FlyInFormation = 0;
                        signal_TakingOff = 0;
                        signal_Landing = 0;

                        wingCommand.flightOrder_Enemy[viewNum_Enemy] = flightOrder;

                        // Update the Flight Information
                        UpdateInformationToWingCommandInfo();
                    }
                }
            }
        }
    }

    // Order Type
    // 1: All.
    // 2: formation.
    // 3: Individual.
    // Initializing and Ordering Taking Off.
    IEnumerator Order_TakingOff(int orderType, int numFormation, int viewNum)
    {

        yield return new WaitForSeconds(num_FormationOrder * 7f);

        if (signal_Landing == 0 && statusFlight == -1)
        {
            // OurForces.
            if (signal_IsEnemy == 0)
            {
                // All.
                if (orderType == 1)
                {
                    flightOrder = 1;
                    destination_TL = 1;
                    signal_FlyToBombingTarget = 0;
                    signal_FlyInFormation = 0;
                    signal_TakingOff = 1;
                    signal_Landing = 0;

                    wingCommand.flightOrder_OurForces[viewNum_OurForces] = flightOrder;

                    // Update the Flight Information
                    UpdateInformationToWingCommandInfo();
                }
                // Formation.
                if (orderType == 2)
                {
                    if (numFormation == num_Formation)
                    {
                        flightOrder = 1;
                        destination_TL = 1;
                        signal_FlyToBombingTarget = 0;
                        signal_FlyInFormation = 0;
                        signal_TakingOff = 1;
                        signal_Landing = 0;

                        wingCommand.flightOrder_OurForces[viewNum_OurForces] = flightOrder;

                        // Update the Flight Information
                        UpdateInformationToWingCommandInfo();
                    }
                }
                // Individual.
                if (orderType == 3)
                {
                    if (viewNum == viewNum_OurForces)
                    {
                        flightOrder = 1;
                        destination_TL = 1;
                        signal_FlyToBombingTarget = 0;
                        signal_FlyInFormation = 0;
                        signal_TakingOff = 1;
                        signal_Landing = 0;

                        wingCommand.flightOrder_OurForces[viewNum_OurForces] = flightOrder;

                        // Update the Flight Information
                        UpdateInformationToWingCommandInfo();
                    }
                }
            }
            // Enemy.
            else
            {
                // All.
                if (orderType == 1)
                {
                    flightOrder = 1;
                    destination_TL = 1;
                    signal_FlyToBombingTarget = 0;
                    signal_FlyInFormation = 0;
                    signal_TakingOff = 1;
                    signal_Landing = 0;

                    wingCommand.flightOrder_Enemy[viewNum_Enemy] = flightOrder;

                    // Update the Flight Information
                    UpdateInformationToWingCommandInfo();
                }
                // Formation.
                if (orderType == 2)
                {
                    if (numFormation == num_Formation)
                    {
                        flightOrder = 1;
                        destination_TL = 1;
                        signal_FlyToBombingTarget = 0;
                        signal_FlyInFormation = 0;
                        signal_TakingOff = 1;
                        signal_Landing = 0;

                        wingCommand.flightOrder_Enemy[viewNum_Enemy] = flightOrder;

                        // Update the Flight Information
                        UpdateInformationToWingCommandInfo();
                    }
                }
                // Individual.
                if (orderType == 3)
                {
                    if (viewNum == viewNum_Enemy)
                    {
                        flightOrder = 1;
                        destination_TL = 1;
                        signal_FlyToBombingTarget = 0;
                        signal_FlyInFormation = 0;
                        signal_TakingOff = 1;
                        signal_Landing = 0;

                        wingCommand.flightOrder_Enemy[viewNum_Enemy] = flightOrder;

                        // Update the Flight Information
                        UpdateInformationToWingCommandInfo();
                    }
                }
            }
        }
    }

    // Order Type
    // 1: All.
    // 2: formation.
    // 3: Individual.
    // Initializing and Ordering Landing.
    IEnumerator Order_Landing(int orderType, int numFormation, int viewNum)
    {

        yield return new WaitForSeconds(num_FormationOrder * 7f);

        if (signal_TakingOff == 0 && statusFlight == 1)
        {
            // OurForces.
            if (signal_IsEnemy == 0)
            {
                // All.
                if (orderType == 1)
                {
                    flightOrder = -1;
                    destination_TL = 0;
                    signal_FlyToBombingTarget = 0;
                    signal_FlyInFormation = 0;
                    signal_TakingOff = 0;
                    signal_Landing = 1;

                    wingCommand.flightOrder_OurForces[viewNum_OurForces] = flightOrder;

                    // Update the Flight Information
                    UpdateInformationToWingCommandInfo();
                }
                // Formation.
                if (orderType == 2)
                {
                    if (numFormation == num_Formation)
                    {
                        flightOrder = -1;
                        signal_FlyToBombingTarget = 0;
                        signal_FlyInFormation = 0;
                        signal_TakingOff = 0;
                        signal_Landing = 1;

                        wingCommand.flightOrder_OurForces[viewNum_OurForces] = flightOrder;

                        // Update the Flight Information
                        UpdateInformationToWingCommandInfo();
                    }
                }
                // Individual.
                if (orderType == 3)
                {
                    if (viewNum == viewNum_OurForces)
                    {
                        flightOrder = -1;
                        signal_FlyToBombingTarget = 0;
                        signal_FlyInFormation = 0;
                        signal_TakingOff = 0;
                        signal_Landing = 1;

                        wingCommand.flightOrder_OurForces[viewNum_OurForces] = flightOrder;

                        // Update the Flight Information
                        UpdateInformationToWingCommandInfo();
                    }
                }
            }
            // Enemy.
            else
            {
                // All.
                if (orderType == 1)
                {
                    flightOrder = -1;
                    signal_FlyToBombingTarget = 0;
                    signal_FlyInFormation = 0;
                    signal_TakingOff = 0;
                    signal_Landing = 1;

                    wingCommand.flightOrder_Enemy[viewNum_Enemy] = flightOrder;

                    // Update the Flight Information
                    UpdateInformationToWingCommandInfo();
                }
                // Formation.
                if (orderType == 2)
                {
                    if (numFormation == num_Formation)
                    {
                        flightOrder = -1;
                        signal_FlyToBombingTarget = 0;
                        signal_FlyInFormation = 0;
                        wingCommand.flightOrder_Enemy[viewNum_Enemy] = flightOrder;

                        // Update the Flight Information
                        UpdateInformationToWingCommandInfo();
                    }
                }
                // Individual.
                if (orderType == 3)
                {
                    if (viewNum == viewNum_Enemy)
                    {
                        flightOrder = -1;
                        signal_FlyToBombingTarget = 0;
                        signal_FlyInFormation = 0;
                        wingCommand.flightOrder_Enemy[viewNum_Enemy] = flightOrder;

                        // Update the Flight Information
                        UpdateInformationToWingCommandInfo();
                    }
                }
            }
        }
    }

    // Order Type
    // 1: All.
    // 2: formation.
    // 3: Individual.
    // Initializing and Ordering Dogfight Mission.
    IEnumerator Order_DogfightMission(int orderType, int numFormation, int viewNum)
    {

        yield return new WaitForSeconds(num_FormationOrder * 2f);

        if (signal_InAirport == 0 && statusFlight == 1)
        {
            // OurForces.
            if (signal_IsEnemy == 0)
            {
                // All.
                if (orderType == 1)
                {
                    flightOrder = 2;
                    signal_FlyToBombingTarget = 0;
                    signal_FlyInFormation = 0;
                    signal_TakingOff = 0;
                    signal_Landing = 0;

                    wingCommand.flightOrder_OurForces[viewNum_OurForces] = flightOrder;

                    // Update the Flight Information
                    UpdateInformationToWingCommandInfo();
                }
                // Formation.
                if (orderType == 2)
                {
                    if (numFormation == num_Formation)
                    {
                        flightOrder = 2;
                        signal_FlyToBombingTarget = 0;
                        signal_FlyInFormation = 0;
                        signal_TakingOff = 0;
                        signal_Landing = 0;

                        wingCommand.flightOrder_OurForces[viewNum_OurForces] = flightOrder;

                        // Update the Flight Information
                        UpdateInformationToWingCommandInfo();
                    }
                }
                // Individual.
                if (orderType == 3)
                {
                    if (viewNum == viewNum_OurForces)
                    {
                        flightOrder = 2;
                        signal_FlyToBombingTarget = 0;
                        signal_FlyInFormation = 0;
                        signal_TakingOff = 0;
                        signal_Landing = 0;

                        wingCommand.flightOrder_OurForces[viewNum_OurForces] = flightOrder;

                        // Update the Flight Information
                        UpdateInformationToWingCommandInfo();
                    }
                }
            }
            // Enemy.
            else
            {
                // All.
                if (orderType == 1)
                {
                    flightOrder = 2;
                    signal_FlyToBombingTarget = 0;
                    signal_FlyInFormation = 0;
                    signal_TakingOff = 0;
                    signal_Landing = 0;

                    wingCommand.flightOrder_Enemy[viewNum_Enemy] = flightOrder;

                    // Update the Flight Information
                    UpdateInformationToWingCommandInfo();
                }
                // Formation.
                if (orderType == 2)
                {
                    if (numFormation == num_Formation)
                    {
                        flightOrder = 2;
                        signal_FlyToBombingTarget = 0;
                        signal_FlyInFormation = 0;
                        signal_TakingOff = 0;
                        signal_Landing = 0;

                        wingCommand.flightOrder_Enemy[viewNum_Enemy] = flightOrder;

                        // Update the Flight Information
                        UpdateInformationToWingCommandInfo();
                    }
                }
                // Individual.
                if (orderType == 3)
                {
                    if (viewNum == viewNum_Enemy)
                    {
                        flightOrder = 2;
                        signal_FlyToBombingTarget = 0;
                        signal_FlyInFormation = 0;
                        signal_TakingOff = 0;
                        signal_Landing = 0;

                        wingCommand.flightOrder_Enemy[viewNum_Enemy] = flightOrder;

                        // Update the Flight Information
                        UpdateInformationToWingCommandInfo();
                    }
                }
            }
        }
    }

    // Order Type
    // 1: All.
    // 2: formation.
    // 3: Individual.
    // Initializing and Ordering Bombardment Mission.
    IEnumerator Order_BombingMission(int orderType, int numFormation, int viewNum)
    {

        yield return new WaitForSeconds(num_FormationOrder * 1f);

        if (signal_InAirport == 0 && statusFlight == 1)
        {
            // OurForces.
            if (signal_IsEnemy == 0)
            {
                // All.
                if (orderType == 1)
                {
                    flightOrder = 3;
                    signal_FlyToBombingTarget = 0;
                    signal_FlyInFormation = 0;
                    signal_TakingOff = 0;
                    signal_Landing = 0;

                    wingCommand.flightOrder_OurForces[viewNum_OurForces] = flightOrder;

                    // Update the Flight Information
                    UpdateInformationToWingCommandInfo();
                }
                // Formation.
                if (orderType == 2)
                {
                    if (numFormation == num_Formation)
                    {
                        flightOrder = 3;
                        signal_FlyToBombingTarget = 0;
                        signal_FlyInFormation = 0;
                        signal_TakingOff = 0;
                        signal_Landing = 0;

                        wingCommand.flightOrder_OurForces[viewNum_OurForces] = flightOrder;

                        // Update the Flight Information
                        UpdateInformationToWingCommandInfo();
                    }
                }
                // Individual.
                if (orderType == 3)
                {
                    if (viewNum == viewNum_OurForces)
                    {
                        flightOrder = 3;
                        signal_FlyToBombingTarget = 0;
                        signal_FlyInFormation = 0;
                        signal_TakingOff = 0;
                        signal_Landing = 0;

                        wingCommand.flightOrder_OurForces[viewNum_OurForces] = flightOrder;

                        // Update the Flight Information
                        UpdateInformationToWingCommandInfo();
                    }
                }
            }
            // Enemy.
            else
            {
                // All.
                if (orderType == 1)
                {
                    flightOrder = 3;
                    signal_FlyToBombingTarget = 01;
                    signal_FlyInFormation = 0;
                    signal_TakingOff = 0;
                    signal_Landing = 0;

                    wingCommand.flightOrder_Enemy[viewNum_Enemy] = flightOrder;

                    // Update the Flight Information
                    UpdateInformationToWingCommandInfo();
                }
                // Formation.
                if (orderType == 2)
                {
                    if (numFormation == num_Formation)
                    {
                        flightOrder = 3;
                        signal_FlyToBombingTarget = 0;
                        signal_FlyInFormation = 0;
                        signal_TakingOff = 0;
                        signal_Landing = 0;

                        wingCommand.flightOrder_Enemy[viewNum_Enemy] = flightOrder;

                        // Update the Flight Information
                        UpdateInformationToWingCommandInfo();
                    }
                }
                // Individual.
                if (orderType == 3)
                {
                    if (viewNum == viewNum_Enemy)
                    {
                        flightOrder = 3;
                        signal_FlyToBombingTarget = 0;
                        signal_FlyInFormation = 0;
                        signal_TakingOff = 0;
                        signal_Landing = 0;

                        wingCommand.flightOrder_Enemy[viewNum_Enemy] = flightOrder;

                        // Update the Flight Information
                        UpdateInformationToWingCommandInfo();
                    }
                }
            }
        }
    }

    // Order Type
    // 1: All.
    // 2: formation.
    // 3: Individual.
    // Initializing and Ordering Bombardment Mission.
    IEnumerator Order_FormationFlight(int orderType, int numFormation, int viewNum)
    {

        yield return new WaitForSeconds(num_FormationOrder * 1f);

        if (signal_InAirport == 0 && statusFlight == 1)
        {
            // OurForces.
            if (signal_IsEnemy == 0)
            {
                // All.
                if (orderType == 1)
                {
                    flightOrder = 4;
                    signal_FlyToBombingTarget = 0;
                    signal_FlyInFormation = 1;

                    wingCommand.flightOrder_OurForces[viewNum_OurForces] = flightOrder;

                    // Update the Flight Information
                    UpdateInformationToWingCommandInfo();
                }
                // Formation.
                if (orderType == 2)
                {
                    if (numFormation == num_Formation)
                    {
                        flightOrder = 4;
                        signal_FlyToBombingTarget = 0;
                        signal_FlyInFormation = 1;

                        wingCommand.flightOrder_OurForces[viewNum_OurForces] = flightOrder;

                        // Update the Flight Information
                        UpdateInformationToWingCommandInfo();
                    }
                }
                // Individual.
                if (orderType == 3)
                {
                    if (viewNum == viewNum_OurForces)
                    {
                        flightOrder = 4;
                        signal_FlyToBombingTarget = 0;
                        signal_FlyInFormation = 1;

                        wingCommand.flightOrder_OurForces[viewNum_OurForces] = flightOrder;

                        // Update the Flight Information
                        UpdateInformationToWingCommandInfo();
                    }
                }
            }
            // Enemy.
            else
            {
                // All.
                if (orderType == 1)
                {
                    flightOrder = 4;
                    signal_FlyToBombingTarget = 0;
                    signal_FlyInFormation = 1;

                    wingCommand.flightOrder_Enemy[viewNum_Enemy] = flightOrder;

                    // Update the Flight Information
                    UpdateInformationToWingCommandInfo();
                }
                // Formation.
                if (orderType == 2)
                {
                    if (numFormation == num_Formation)
                    {
                        flightOrder = 4;
                        signal_FlyToBombingTarget = 0;
                        signal_FlyInFormation = 1;

                        wingCommand.flightOrder_Enemy[viewNum_Enemy] = flightOrder;

                        // Update the Flight Information
                        UpdateInformationToWingCommandInfo();
                    }
                }
                // Individual.
                if (orderType == 3)
                {
                    if (viewNum == viewNum_Enemy)
                    {
                        flightOrder = 4;
                        signal_FlyToBombingTarget = 0;
                        signal_FlyInFormation = 1;

                        wingCommand.flightOrder_Enemy[viewNum_Enemy] = flightOrder;

                        // Update the Flight Information
                        UpdateInformationToWingCommandInfo();
                    }
                }
            }
        }
    }

    // Update WingCommand Information
    // Send the information from Aircraft to WingCommand.
    void UpdateInformationToWingCommandInfo()
    {

        if (signal_IsEnemy == 0)
        {
            // Update status at WingCommand
            wingCommand.status_OurForces[viewNum_OurForces] = statusFlight;
        }
        else
        {
            // Update status at WingCommand
            wingCommand.status_Enemy[viewNum_Enemy] = statusFlight;
        }
    }

    // Process 
    // 1. Receive order from WingCommand 
    // 2. Call order method by All, Formation, Individual.
    // Receive wingcommand's order.
    void UpdateInformationFromWingCommandInfo_OurForces()
    {

        // Update status at WingCommand
        statusFlight = wingCommand.status_OurForces[viewNum_OurForces];
        signal_IsFormationLeader = wingCommand.isLeader_OurForces[viewNum_OurForces];

        // All Updates.
        if (wingCommand._updateAllWingCommandOrder_OurForces == 1)
        {
            if (wingCommand.allOrderByWingCommander_OurForces == 0)
            {
                StartCoroutine(Order_FlyToReturnPoint(1, 0, 0));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_OurForces[viewNum_OurForces] = wingCommand.allOrderByWingCommander_OurForces;
            }
            if (wingCommand.allOrderByWingCommander_OurForces == 1)
            {
                StartCoroutine(Order_TakingOff(1, 0, 0));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_OurForces[viewNum_OurForces] = wingCommand.allOrderByWingCommander_OurForces;
            }
            if (wingCommand.allOrderByWingCommander_OurForces == -1)
            {
                StartCoroutine(Order_Landing(1, 0, 0));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_OurForces[viewNum_OurForces] = wingCommand.allOrderByWingCommander_OurForces;
            }
            if (wingCommand.allOrderByWingCommander_OurForces == 2)
            {
                StartCoroutine(Order_DogfightMission(1, 0, 0));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_OurForces[viewNum_OurForces] = wingCommand.allOrderByWingCommander_OurForces;
            }
            if (wingCommand.allOrderByWingCommander_OurForces == 3)
            {
                StartCoroutine(Order_BombingMission(1, 0, 0));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_OurForces[viewNum_OurForces] = wingCommand.allOrderByWingCommander_OurForces;
            }
            if (wingCommand.allOrderByWingCommander_OurForces == 4)
            {
                StartCoroutine(Order_FormationFlight(1, 0, 0));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_OurForces[viewNum_OurForces] = wingCommand.allOrderByWingCommander_OurForces;
            }
        }
        // Formation Updates.
        if (wingCommand._updateFormationWingCommandOrder_OurForces == 1)
        {
            if (wingCommand.formationOrderByWingCommander_OurForces == 0)
            {
                StartCoroutine(Order_FlyToReturnPoint(2, wingCommand.selectedFormationNum_OurForces, 0));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_OurForces[viewNum_OurForces] = wingCommand.formationOrderByWingCommander_OurForces;
            }
            if (wingCommand.formationOrderByWingCommander_OurForces == 1)
            {
                StartCoroutine(Order_TakingOff(2, wingCommand.selectedFormationNum_OurForces, 0));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_OurForces[viewNum_OurForces] = wingCommand.formationOrderByWingCommander_OurForces;
            }
            if (wingCommand.formationOrderByWingCommander_OurForces == -1)
            {
                StartCoroutine(Order_Landing(2, wingCommand.selectedFormationNum_OurForces, 0));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_OurForces[viewNum_OurForces] = wingCommand.formationOrderByWingCommander_OurForces;
            }
            if (wingCommand.formationOrderByWingCommander_OurForces == 2)
            {
                StartCoroutine(Order_DogfightMission(2, wingCommand.selectedFormationNum_OurForces, 0));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_OurForces[viewNum_OurForces] = wingCommand.formationOrderByWingCommander_OurForces;
            }
            if (wingCommand.formationOrderByWingCommander_OurForces == 3)
            {
                StartCoroutine(Order_BombingMission(2, wingCommand.selectedFormationNum_OurForces, 0));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_OurForces[viewNum_OurForces] = wingCommand.formationOrderByWingCommander_OurForces;
            }
            if (wingCommand.formationOrderByWingCommander_OurForces == 4)
            {
                StartCoroutine(Order_FormationFlight(2, wingCommand.selectedFormationNum_OurForces, 0));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_OurForces[viewNum_OurForces] = wingCommand.formationOrderByWingCommander_OurForces;
            }
        }
        // Individual Updates.
        if (wingCommand._updateIndividualWingCommandOrder_OurForces == 1)
        {
            if (wingCommand.individualOrderByWingCommander_OurForces == 1)
            {
                StartCoroutine(Order_FlyToReturnPoint(3, 0, wingCommand.selectedIndividualNum_OurForces));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_OurForces[viewNum_OurForces] = wingCommand.individualOrderByWingCommander_OurForces;
            }
            if (wingCommand.individualOrderByWingCommander_OurForces == 1)
            {
                StartCoroutine(Order_TakingOff(3, 0, wingCommand.selectedIndividualNum_OurForces));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_OurForces[viewNum_OurForces] = wingCommand.individualOrderByWingCommander_OurForces;
            }
            if (wingCommand.individualOrderByWingCommander_OurForces == -1)
            {
                StartCoroutine(Order_Landing(3, 0, wingCommand.selectedIndividualNum_OurForces));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_OurForces[viewNum_OurForces] = wingCommand.individualOrderByWingCommander_OurForces;
            }
            if (wingCommand.individualOrderByWingCommander_OurForces == 2)
            {
                StartCoroutine(Order_DogfightMission(3, 0, wingCommand.selectedIndividualNum_OurForces));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_OurForces[viewNum_OurForces] = wingCommand.individualOrderByWingCommander_OurForces;
            }
            if (wingCommand.individualOrderByWingCommander_OurForces == 3)
            {
                StartCoroutine(Order_BombingMission(3, 0, wingCommand.selectedIndividualNum_OurForces));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_OurForces[viewNum_OurForces] = wingCommand.individualOrderByWingCommander_OurForces;
            }
            if (wingCommand.individualOrderByWingCommander_OurForces == 4)
            {
                StartCoroutine(Order_FormationFlight(3, 0, wingCommand.selectedIndividualNum_OurForces));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_OurForces[viewNum_OurForces] = wingCommand.individualOrderByWingCommander_OurForces;
            }
        }
    }

    void UpdateInformationFromWingCommandInfo_Enemy()
    {

        // Update status at WingCommand
        statusFlight = wingCommand.status_Enemy[viewNum_Enemy];
        signal_IsFormationLeader = wingCommand.isLeader_Enemy[viewNum_Enemy];

        // All Updates.
        if (wingCommand._updateAllWingCommandOrder_Enemy == 1)
        {
            if (wingCommand.allOrderByWingCommander_Enemy == 1)
            {
                StartCoroutine(Order_FlyToReturnPoint(1, 0, 0));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_Enemy[viewNum_Enemy] = wingCommand.allOrderByWingCommander_Enemy;
            }
            if (wingCommand.allOrderByWingCommander_Enemy == 1)
            {
                StartCoroutine(Order_TakingOff(1, 0, 0));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_Enemy[viewNum_Enemy] = wingCommand.allOrderByWingCommander_Enemy;
            }
            if (wingCommand.allOrderByWingCommander_Enemy == -1)
            {
                StartCoroutine(Order_Landing(1, 0, 0));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_Enemy[viewNum_Enemy] = wingCommand.allOrderByWingCommander_Enemy;
            }
            if (wingCommand.allOrderByWingCommander_Enemy == 2)
            {
                StartCoroutine(Order_DogfightMission(1, 0, 0));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_Enemy[viewNum_Enemy] = wingCommand.allOrderByWingCommander_Enemy;
            }
            if (wingCommand.allOrderByWingCommander_Enemy == 3)
            {
                StartCoroutine(Order_BombingMission(1, 0, 0));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_Enemy[viewNum_Enemy] = wingCommand.allOrderByWingCommander_Enemy;
            }
            if (wingCommand.allOrderByWingCommander_Enemy == 4)
            {
                StartCoroutine(Order_FormationFlight(1, 0, 0));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_Enemy[viewNum_Enemy] = wingCommand.allOrderByWingCommander_Enemy;
            }
        }
        // Formation Updates.
        if (wingCommand._updateFormationWingCommandOrder_Enemy == 1)
        {
            if (wingCommand.formationOrderByWingCommander_Enemy == 1)
            {
                StartCoroutine(Order_FlyToReturnPoint(2, wingCommand.selectedFormationNum_Enemy, 0));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_Enemy[viewNum_Enemy] = wingCommand.formationOrderByWingCommander_Enemy;
            }
            if (wingCommand.formationOrderByWingCommander_Enemy == 1)
            {
                StartCoroutine(Order_TakingOff(2, wingCommand.selectedFormationNum_Enemy, 0));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_Enemy[viewNum_Enemy] = wingCommand.formationOrderByWingCommander_Enemy;
            }
            if (wingCommand.formationOrderByWingCommander_Enemy == -1)
            {
                StartCoroutine(Order_Landing(2, wingCommand.selectedFormationNum_Enemy, 0));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_Enemy[viewNum_Enemy] = wingCommand.formationOrderByWingCommander_Enemy;
            }
            if (wingCommand.formationOrderByWingCommander_Enemy == 2)
            {
                StartCoroutine(Order_DogfightMission(2, wingCommand.selectedFormationNum_Enemy, 0));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_Enemy[viewNum_Enemy] = wingCommand.formationOrderByWingCommander_Enemy;
            }
            if (wingCommand.formationOrderByWingCommander_Enemy == 3)
            {
                StartCoroutine(Order_BombingMission(2, wingCommand.selectedFormationNum_Enemy, 0));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_Enemy[viewNum_Enemy] = wingCommand.formationOrderByWingCommander_Enemy;
            }
            if (wingCommand.formationOrderByWingCommander_Enemy == 4)
            {
                StartCoroutine(Order_FormationFlight(2, wingCommand.selectedFormationNum_Enemy, 0));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_Enemy[viewNum_Enemy] = wingCommand.formationOrderByWingCommander_Enemy;
            }
        }

        // Individual Updates.
        if (wingCommand._updateIndividualWingCommandOrder_Enemy == 1)
        {
            if (wingCommand.individualOrderByWingCommander_Enemy == 1)
            {
                StartCoroutine(Order_FlyToReturnPoint(3, 0, wingCommand.selectedIndividualNum_Enemy));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_Enemy[viewNum_Enemy] = wingCommand.individualOrderByWingCommander_Enemy;
            }
            if (wingCommand.individualOrderByWingCommander_Enemy == 1)
            {
                StartCoroutine(Order_TakingOff(3, 0, wingCommand.selectedIndividualNum_Enemy));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_Enemy[viewNum_Enemy] = wingCommand.individualOrderByWingCommander_Enemy;
            }
            if (wingCommand.individualOrderByWingCommander_Enemy == -1)
            {
                StartCoroutine(Order_Landing(3, 0, wingCommand.selectedIndividualNum_Enemy));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_Enemy[viewNum_Enemy] = wingCommand.individualOrderByWingCommander_Enemy;
            }
            if (wingCommand.individualOrderByWingCommander_Enemy == 2)
            {
                StartCoroutine(Order_DogfightMission(3, 0, wingCommand.selectedIndividualNum_Enemy));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_Enemy[viewNum_Enemy] = wingCommand.individualOrderByWingCommander_Enemy;
            }
            if (wingCommand.individualOrderByWingCommander_Enemy == 3)
            {
                StartCoroutine(Order_BombingMission(3, 0, wingCommand.selectedIndividualNum_Enemy));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_Enemy[viewNum_Enemy] = wingCommand.individualOrderByWingCommander_Enemy;
            }
            if (wingCommand.individualOrderByWingCommander_Enemy == 4)
            {
                StartCoroutine(Order_FormationFlight(3, 0, wingCommand.selectedIndividualNum_Enemy));
                // Update the Info. to WingCommand.
                wingCommand.flightOrder_Enemy[viewNum_Enemy] = wingCommand.individualOrderByWingCommander_Enemy;
            }
        }
    }

    //==============================================================================
    // 6. Sound, View, Velocity, HP, Flight Manager, Etc Part
    //==============================================================================

    // Gravity Effect by aircraft direction.
    void GravityEffects()
    {

        // Gravity Effect influencing aircraft Velocity
        if (point_Front.position.y > point_Behind.position.y)
            velocityEffectByGravity = (point_Behind.position.y - point_Front.position.y) * pilotage * 700f / velocityAircraft;

        if (point_Front.position.y < point_Behind.position.y)
            velocityEffectByGravity = (point_Behind.position.y - point_Front.position.y) * pilotage * 700f / velocityAircraft;

        // Gravity Effect influencing aircraft Direction
        if (point_Left.position.y > point_Right.position.y)
            transform.Rotate(0, 0.003f, 0);

        if (point_Left.position.y < point_Right.position.y)
            transform.Rotate(0, -0.003f, 0);

    }

    // Control the aircraft velocity.
    public void Velocity_Manager(int typeAircraft)
    {

        // Velocity control by throttle.
        if (signal_IsDestroyed == 0)
        {
            // Helicopter
            if (typeAircraft == 3)
            {
                // Not in Landing Mission.
                if (signal_Landing == 0)
                {
                    if (signal_InAirport == 0)
                    {
                        // In air.
                        velocityAircraft = Mathf.Lerp(velocityAircraft, throttle_Aircraft, Time.deltaTime * 0.5f);
                    }
                    else
                    {
                        // In Airport.
                        velocityInAirport = 0;//Mathf.Lerp (velocityInAirport, throttle_Aircraft, Time.deltaTime * 0.5f);
                        velocityAdvanced = 0;
                    }
                }
            }
            // Others.
            else
            {
                if (signal_InAirport == 0)
                {
                    // In air.
                    velocityAircraft = Mathf.Lerp(velocityAircraft, throttle_Aircraft, Time.deltaTime * 0.5f);
                }
                else
                {
                    // In Airport.
                    velocityInAirport = Mathf.Lerp(velocityInAirport, throttle_Aircraft, Time.deltaTime * 0.5f);
                }
            }
        }
        else
        {
            // Destroyed.
            throttle_Aircraft = Mathf.Lerp(throttle_Aircraft, 0, Time.deltaTime * 0.5f);
        }

        // In air.
        if (statusFlight == 1 && signal_InAirport == 0)
        {
            // Velocity of aircraft.
            // Helicopter.
            if (typeAircraft == 3)
            {
                // TO.
                if (signal_TakingOff == 1)
                {
                    velocityAdvanced = 0;
                    velocityAircraft = 0;
                }
                // Other Missions.
                else
                {
                    velocityAdvanced = velocityAircraft;
                }
            }
            // Others.
            else
            {
                velocityAdvanced = velocityAircraft + velocityEffectByGravity;
            }
        }

        // Keep the velocity of airplane.
        if (signal_IsDestroyed == 0 && (statusFlight == 1 || statusFlight == -1))
        {
            // Aircraft velocity finally.
            // Helicopter.
            if (typeAircraft == 3)
            {
                if (signal_InAirport == 0)
                    m_rigidbody.velocity = transform.forward * velocityAdvanced;
                else
                    m_rigidbody.velocity = transform.forward * velocityInAirport;
            }
            // Others.
            else
            {
                if (signal_InAirport == 0)
                    m_rigidbody.velocity = transform.forward * velocityAdvanced;
                else
                    m_rigidbody.velocity = transform.forward * velocityInAirport;
            }
        }
        // Drop to land by low velocity.
        if (signal_IsDestroyed == 0 && statusFlight == 1 && signal_InAirport == 0)
        {
            if (typeAircraft != 3)
            {
                if (velocityAdvanced < 92f && velocityAdvanced > 0.0f)
                    transform.position -= new Vector3(0, Time.deltaTime * (93f - velocityAdvanced), 0);
            }
        }

        if (signal_IsDestroyed == 1)
        {
            // Crashed on Land.
            if (statusFlight == -2)
                m_rigidbody.velocity = transform.forward * 0f;
            // Falling Down in the sky.
            if (statusFlight == -3)
                m_rigidbody.velocity = transform.forward * velocityAdvanced;
        }
    }


    void Flight_Manager()
    {

        GravityEffects();
        if (signal_LimitedAltitude == 0 && signal_LimitedArea == 0)
        {
            // Combat-Ready.
            if (flightOrder == 0 && statusFlight == 1 && signal_InAirport == 0)
            {
                FlyToReturnPoint(point_Return);
                AvoidCrashToLand(150f, type_Aircraft);
            }
            // Taking off.
            if (flightOrder == 1)
                TakingOffMission();

            // Landing.
            if (flightOrder == -1)
                LandingMission();

            // Dogfight.
            if (flightOrder == 2)
                // Fly to Selected Target by the signal
                FlyToDogfightTarget();

            // Bombing.
            if (flightOrder == 3)
                // Fly to Selected Target by the signal
                FlyToBombingTarget();


            // Formation Flight
            if (flightOrder == 4)
                // Formation Flight
                FlyInFormation();

            // Custom Order.
            // Flight to Indicated Path.
            if (flightOrder == 9)
                FlyToIndicatedPoint(point_FieldCenter);

            // Helicopter.
            if (type_Aircraft == 3)
                Control_WingToHorizontality(0.2f);
        }
    }

    int signal_NeverView;
    Vector3 newViewPos = new Vector3();
    void View_Manager()
    {

        if (signal_NeverView == 0)
        {
            // OurForces
            if (signal_IsEnemy == 0)
            {
                if (viewNum_OurForces == wingCommand.selectedViewNum_OurForces && wingCommand.view_Group == 1)
                {
                    if (view.viewFrom == 1)
                    {
                        // 3rd View.
                        if (view.viewMode == -1)
                        {
                            pos_View.position = Vector3.Lerp(pos_View.position, point_3rdView.position, Time.deltaTime * 3f);
                            if (view.viewDirection == 0)
                                pos_View.rotation = Quaternion.Lerp(pos_View.rotation, point_3rdView.rotation, Time.deltaTime * 3f);
                            if (view.viewDirection == 1)
                                pos_View.rotation = Quaternion.Euler(transform.right * (-1f));
                            if (view.viewDirection == 2)
                                pos_View.rotation = Quaternion.Euler(transform.right);
                            if (view.viewDirection == 3)
                                pos_View.rotation = Quaternion.Euler(transform.up);
                            if (view.viewDirection == 4)
                                pos_View.rotation = Quaternion.Euler(transform.forward * (-1f));
                        }
                        // Cockpit View.
                        if (view.viewMode == 0)
                        {
                            pos_View.position = point_CockpitView.position;
                            // Forward
                            if (view.viewDirection == 0)
                                pos_View.rotation = Quaternion.Lerp(pos_View.rotation, point_CockpitView.rotation, Time.deltaTime * 3f);
                            // Left
                            if (view.viewDirection == 1)
                                pos_View.LookAt(transform.TransformPoint(Vector3.right * (-100f)), transform.TransformDirection(Vector3.up));
                            // Right
                            if (view.viewDirection == 2)
                                pos_View.LookAt(transform.TransformPoint(Vector3.right * (100f)), transform.TransformDirection(Vector3.up));
                            // Up
                            if (view.viewDirection == 3)
                                pos_View.LookAt(transform.TransformPoint(Vector3.up * (100f)), transform.TransformDirection(Vector3.forward * (-1f)));
                            // Back
                            if (view.viewDirection == 4)
                                pos_View.LookAt(transform.TransformPoint(Vector3.forward * (-100f)), transform.TransformDirection(Vector3.up));
                        }
                        // LookingAt MySelf.
                        if (view.viewMode == 1)
                        {
                            if (Vector3.Distance(transform.position, view.transform.position) > 920f && view.camPos != 120)
                            {
                                newViewPos = transform.TransformPoint(Vector3.forward + new Vector3(0, 0, 650f));
                                view.transform.position = newViewPos;
                            }
                            pos_View.LookAt(transform.position, Vector3.up);
                        }
                        // LookingAt Target.
                        if (view.viewMode == 2)
                        {
                            pos_View.position = Vector3.Lerp(pos_View.position, point_CockpitView.position, Time.deltaTime * 4f);

                            if (flightOrder == 2 && point_MainTarget != null)
                                pos_View.LookAt(point_MainTarget.position, transform.TransformDirection(Vector3.up));
                            else if (flightOrder == 3 && point_BombingTarget != null)
                                pos_View.LookAt(point_BombingTarget.position, transform.TransformDirection(Vector3.up));
                            else
                                pos_View.LookAt(transform.position, transform.TransformDirection(Vector3.up));
                        }
                        // LookingAt MyHead.
                        if (view.viewMode == 3)
                        {
                            newViewPos = transform.TransformPoint(Vector3.forward + new Vector3(0, 0, 400f) + new Vector3(0, 10f, 0));
                            pos_View.position = Vector3.Lerp(pos_View.position, newViewPos, Time.deltaTime * 1f);
                            pos_View.LookAt(transform.position, transform.TransformDirection(Vector3.up * 150f));

                        }
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
                if (viewNum_Enemy == wingCommand.selectedViewNum_Enemy && wingCommand.view_Group == 2)
                {
                    if (view.viewFrom == 1)
                    {
                        // 3rd View.
                        if (view.viewMode == -1)
                        {
                            pos_View.position = Vector3.Lerp(pos_View.position, point_3rdView.position, Time.deltaTime * 3f);
                            if (view.viewDirection == 0)
                                pos_View.rotation = Quaternion.Lerp(pos_View.rotation, point_3rdView.rotation, Time.deltaTime * 3f);
                            if (view.viewDirection == 1)
                                pos_View.rotation = Quaternion.Euler(transform.right * (-1f));
                            if (view.viewDirection == 2)
                                pos_View.rotation = Quaternion.Euler(transform.right);
                            if (view.viewDirection == 3)
                                pos_View.rotation = Quaternion.Euler(transform.up);
                            if (view.viewDirection == 4)
                                pos_View.rotation = Quaternion.Euler(transform.forward * (-1f));
                        }
                        // Cockpit View.
                        if (view.viewMode == 0)
                        {
                            pos_View.position = point_CockpitView.position;
                            if (view.viewDirection == 0)
                                pos_View.rotation = Quaternion.Lerp(pos_View.rotation, point_CockpitView.rotation, Time.deltaTime * 3f);
                            if (view.viewDirection == 1)
                                pos_View.LookAt(transform.TransformPoint(Vector3.right * (-100f)), transform.TransformDirection(Vector3.up));
                            if (view.viewDirection == 2)
                                pos_View.LookAt(transform.TransformPoint(Vector3.right * (100f)), transform.TransformDirection(Vector3.up));
                            if (view.viewDirection == 3)
                                pos_View.LookAt(transform.TransformPoint(Vector3.up * (100f)), transform.TransformDirection(Vector3.up));
                            if (view.viewDirection == 4)
                                pos_View.LookAt(transform.TransformPoint(Vector3.forward * (-100f)), transform.TransformDirection(Vector3.up));
                        }
                        // LookingAt MySelf.
                        if (view.viewMode == 1)
                        {
                            if (Vector3.Distance(transform.position, view.transform.position) > 920f && view.camPos != 120)
                            {
                                newViewPos = transform.TransformPoint(Vector3.forward + new Vector3(0, 0, 650f));
                                view.transform.position = newViewPos;
                            }
                            pos_View.LookAt(transform.position, Vector3.up);
                        }
                        // LookingAt Target.
                        if (view.viewMode == 2)
                        {
                            pos_View.position = Vector3.Lerp(pos_View.position, point_CockpitView.position, Time.deltaTime * 4f);

                            if (flightOrder == 2 && point_MainTarget != null)
                                pos_View.LookAt(point_MainTarget.position, transform.TransformDirection(Vector3.up));
                            else if (flightOrder == 3 && point_BombingTarget != null)
                                pos_View.LookAt(point_BombingTarget.position, transform.TransformDirection(Vector3.up));
                            else
                                pos_View.LookAt(transform.position, transform.TransformDirection(Vector3.up));
                        }
                        // LookingAt MyHead.
                        if (view.viewMode == 3)
                        {
                            newViewPos = transform.TransformPoint(Vector3.forward + new Vector3(0, 0, 400f) + new Vector3(0, 10f, 0));
                            pos_View.position = Vector3.Lerp(pos_View.position, newViewPos, Time.deltaTime * 1f);
                            pos_View.LookAt(transform.position, transform.TransformDirection(Vector3.up * 150f));

                        }
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
    }

    void Sound_Manager()
    {

        if (statusFlight == -3)
        {
            engineSoundSource.volume = 0;
        }
        else
        {
            if (signal_IsEnemy == 0)
            {
                if (viewNum_OurForces == wingCommand.selectedViewNum_OurForces)
                {
                    engineSoundSource.volume = 1f;
                    if (signal_Gunfire == 1)
                        gunFireSoundSource.volume = 1f;
                }
                else
                {
                    engineSoundSource.volume = 0.05f;
                    if (signal_Gunfire == 0)
                        gunFireSoundSource.volume = 0.00f;
                }

                // OP View.
                if (view.camPos == 55 || view.camPos == 99 || view.camPos == 100 || view.camPos == 110 || view.camPos == 120)
                    engineSoundSource.volume = 0;

                if (signal_IsDestroyed == 0)
                {
                    // Find what proportion of the engine's power is being used.
                    var enginePowerProportion = Mathf.InverseLerp(0, maxAircraftVelocity * 5, throttle_Aircraft);
                    // Set the engine's pitch to be proportional to the engine's current power.
                    engineSoundSource.pitch = Mathf.Lerp(engineMinThrottlePitch, engineMaxThrottlePitch * 3f, enginePowerProportion);
                    // Increase the engine's pitch by an amount proportional to the aeroplane's forward speed.
                    engineSoundSource.pitch += throttle_Aircraft * engineFwdSpeedMultiplier;

                }
                else
                {
                    // Find what proportion of the engine's power is being used.
                    var enginePowerProportion = Mathf.InverseLerp(0, 1f, throttle_Aircraft);
                    // Set the engine's pitch to be proportional to the engine's current power.
                    engineSoundSource.pitch = Mathf.Lerp(engineMinThrottlePitch, engineMaxThrottlePitch * 0.25f, enginePowerProportion);
                    // Increase the engine's pitch by an amount proportional to the aeroplane's forward speed.
                    engineSoundSource.pitch += 10f * engineFwdSpeedMultiplier;
                }
            }
            else
            {
                if (viewNum_Enemy == wingCommand.selectedViewNum_Enemy)
                {
                    engineSoundSource.volume = 1f;
                    if (signal_Gunfire == 1)
                        gunFireSoundSource.volume = 1f;
                }
                else
                {
                    engineSoundSource.volume = 0.05f;
                    if (signal_Gunfire == 0)
                        gunFireSoundSource.volume = 0.00f;
                }
                // OP View.
                if (view.camPos == 55 || view.camPos == 99 || view.camPos == 100 || view.camPos == 110 || view.camPos == 120)
                    engineSoundSource.volume = 0;

                if (signal_IsDestroyed == 0)
                {
                    // Find what proportion of the engine's power is being used.
                    var enginePowerProportion = Mathf.InverseLerp(0, maxAircraftVelocity * 5, throttle_Aircraft);
                    // Set the engine's pitch to be proportional to the engine's current power.
                    engineSoundSource.pitch = Mathf.Lerp(engineMinThrottlePitch, engineMaxThrottlePitch * 3f, enginePowerProportion);
                    // Increase the engine's pitch by an amount proportional to the aeroplane's forward speed.
                    engineSoundSource.pitch += throttle_Aircraft * engineFwdSpeedMultiplier;
                }
                else
                {
                    // Find what proportion of the engine's power is being used.
                    var enginePowerProportion = Mathf.InverseLerp(0, 1f, throttle_Aircraft);
                    // Set the engine's pitch to be proportional to the engine's current power.
                    engineSoundSource.pitch = Mathf.Lerp(engineMinThrottlePitch, engineMaxThrottlePitch * 0.25f, enginePowerProportion);
                    // Increase the engine's pitch by an amount proportional to the aeroplane's forward speed.
                    engineSoundSource.pitch += 10f * engineFwdSpeedMultiplier;
                }
            }
        }
    }

    // Control the aircraft out of operational Field.
    int signal_LimitedAltitude;
    int signal_LimitedArea;
    float operationalAltitude = 6500f;
    float operationalRadius = 45000f;
    void OperationField_Manager(Transform point_FieldCenter)
    {

        // Altitude Part.
        //  Maximum Altitude.
        if (transform.position.y - point_LandZero.position.y > operationalAltitude)
            signal_LimitedAltitude = 1;

        if (signal_LimitedAltitude == 1)
        {
            // Fly to FieldCenter.
            if (Vector3.Angle(transform.forward, point_FieldCenter.position - transform.position) > 70)
                Lever_Pull(0.3f);
            Control_HeadToTarget(point_FieldCenter.position, 0.3f);
            Control_WingToHorizontality(0.2f);
            Control_WingToTargetByTurning(point_FieldCenter.position, 0.2f);
            Control_WingToTargetVertically(point_FieldCenter.position, 0.2f);
            transform.position -= new Vector3(0, Time.deltaTime * 10f, 0);
            // Release the pauseMission when the aircraft is in operational field.
            if (transform.position.y - point_LandZero.position.y < operationalAltitude * 0.65f)
            {
                signal_LimitedAltitude = 0;
            }
        }

        //  Minimum Altitude.
        if (signal_InAirport == 0)
        {
            if (transform.position.y - point_LandZero.position.y < 300f && point_Front.position.y <= point_Down.position.y)
                Lever_Pull(0.3f);

            // If aicraft is flying below the land...
            if (transform.position.y - point_LandZero.position.y < 0f)
            {
                hitpoint = 0;
                signal_IsDestroyed = 1;
                statusFlight = -2;
                velocityAdvanced = 0f;
            }
        }

        // Area Part.
        // Limit the position on operational radius.
        if (Vector3.Distance(transform.position, point_FieldCenter.position) > operationalRadius)
            signal_LimitedArea = 1;

        if (signal_LimitedArea == 1)
        {
            // Fly to FieldCenter.
            if (Vector3.Angle(transform.forward, point_FieldCenter.position - transform.position) > 70)
                Lever_Pull(0.3f);
            Control_HeadToTarget(point_FieldCenter.position, 0.2f);
            Control_WingToHorizontality(0.3f);
            Control_WingToTargetByTurning(point_FieldCenter.position, 0.2f);
            Control_WingToTargetVertically(point_FieldCenter.position, 0.2f);
            // Release the pauseMission when the aircraft is in operational field.
            if (Vector3.Distance(transform.position, point_FieldCenter.position) < operationalRadius * 0.65f)
                signal_LimitedArea = 0;
        }
    }

    //-----------------------------------------------------------------------------------------
    // Manage the collision
    int signal_SoundOneTime1 = 1;
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Land")
        {
            if (signal_IsDestroyed == 0)
            {
                hitpoint = 0;
                velocityAdvanced = 0;
                if (hitpoint <= 0)
                {
                    // Crashed On Land
                    signal_NeverView = 1;
                    statusFlight = -2;
                }
            }
            statusFlight = -2;
            engineSoundSource.volume = 0;
        }

        if (other.gameObject.tag == "Bullet")
        {
            if (signal_IsDestroyed == 0)
            {
                hitpoint -= Random.Range(15f, 25f);
                Instantiate(effect_Fragments, transform.position, Random.rotation);
                if (hitpoint <= 0 && statusFlight == 1)
                {
                    // Falling Down
                    statusFlight = -3;
                    if (signal_IsEnemy == 0)
                        wingCommand.status_OurForces[viewNum_OurForces] = statusFlight;
                    else
                        wingCommand.status_Enemy[viewNum_Enemy] = statusFlight;
                }
            }
        }

        if (other.gameObject.tag == "Rocket")
        {
            if (signal_IsDestroyed == 0)
                hitpoint = 0;
        }

        if (other.gameObject.tag == "OurForces")
        {
            if (signal_IsEnemy == 0)
            {
                // Avoid Crash.
                AvoidCrashToAircraft(other.gameObject.transform.position);
            }
            else
            {
                hitpoint -= Random.Range(5f, 20f);
                if (hitpoint <= 0)
                    // Falling Down
                    statusFlight = -3;

                if (signal_SoundOneTime1 == 1)
                {
                    explosionSoundSource.Play();
                    signal_SoundOneTime1 = 0;
                }
                engineSoundSource.volume = 0;
            }
        }

        if (other.gameObject.tag == "Enemy")
        {
            if (signal_IsEnemy == 1)
            {
                // Avoid Crash.
                AvoidCrashToAircraft(other.gameObject.transform.position);
            }
            else
            {
                hitpoint -= Random.Range(5f, 20f);
                if (hitpoint <= 0)
                    // Falling Down
                    statusFlight = -3;

                if (signal_SoundOneTime1 == 1)
                {
                    explosionSoundSource.Play();
                    signal_SoundOneTime1 = 0;
                }
                engineSoundSource.volume = 0;
            }
        }
    }

    // FixedUpdate
    void FixedUpdate()
    {

        // Control the Aircraft velocity.
        Velocity_Manager(type_Aircraft);

        // Sound Manager.
        Sound_Manager();

        // Manage the view position and rotation by view ID
        View_Manager();

        // Hit point Manager.
        HP_Manager();

        // Limit the operation field.
        OperationField_Manager(point_FieldCenter);

        // Aircraft Wing Control.
        WingControl();

        if (signal_Gunfire == 1)
        {
            // Automatically Seize Firing.
            timeFire += Time.deltaTime;
            if (timeFire > waitFire)
            {
                signal_Gunfire = 0;
                effect_MuzzleFlashL.SetActive(false);
                effect_MuzzleFlashR.SetActive(false);
                timeFire = 0;
            }
        }

        if (signal_Gunfire == 0)
        {
            gunFireSoundSource.volume = 0;
            effect_MuzzleFlashL.SetActive(false);
            effect_MuzzleFlashR.SetActive(false);
        }

        if (signal_DoEvasiveFlight == 1)
        {
            timeAT += Time.deltaTime;
            if (timeAT > waitAT)
            {
                signal_DoEvasiveFlight = 0;
                timeAT = 0;
            }
        }

        if (signal_IsDestroyed == 0)
        {
            Flight_Manager();

            // Aircraft Microvibrating Effect.
            transform.Rotate(Random.Range(-0.02f, 0.02f), 0, 0);

            // Update information from wing commander.
            if (signal_Landing == 0 && signal_TakingOff == 0 && signal_Dismiss == 0)
            {
                if (signal_IsEnemy == 0)
                {
                    // Get the information from Wing Command.
                    UpdateInformationFromWingCommandInfo_OurForces();
                }
                else
                {
                    // Get the information from Wing Command.
                    UpdateInformationFromWingCommandInfo_Enemy();
                }
            }
        }
        // Destroyed Aircraft.
        DestroyedAircraft();
    }
}