using Assets;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoV_CombatVehicle : MonoBehaviour
{


    public GameObject TargetCone;
    public GameObject DetectionAir;
    public GameObject DetectionGround;
    public GameObject ArmorShield;

    public GameObject Turret;
    public GameObject Cannon;
    public GameObject Gun;
    public GameObject Frame;

    public BoxCollider HitBox;

    public DoV_Vehicle Vehicle;
    public List<GameObject> WeaponMoundPoints;





    public ArmorState VehicleArmorState;
    public SensorState VehicleSenorState;
    public WeaponState VehicleWeaponState;
    public TurretState VehicleTurretState;
    public MoveState VehicleMoveState;

    public List<rotation> Wheels;


    public GameObject TargetTracker;
    public List<GameObject> FireAtTargets;

    public float MaxSensorRange;
    public float SensorDelay;



    public int ReloadTime;
    public bool IsEnemyUnit;
    public bool IsLocationKnownToPlayer;
    public bool IsDamaged;
    public bool IsCivilian;
    public bool IsFiring;

    public float FiringSpeed;
    public float FiringRateOfFire;

    public bool DeployToFire;
    [Tooltip("Tanks/IFV have commander turrets can target another enemy while it reloads ")]
    public bool HasCommanderTurret;
    [Tooltip("Tanks/IFV can move and shoot")]
    public bool FireOnMove;
    [Tooltip("Tanks/IFV can hit moving targets artillery not so much")]
    public bool CanTargetMoving;
    [Tooltip("Artillery/missiles can hit a stationary target or bunker")]
    public bool CanTargetStationary;
    public bool Amphibious;
    public SeaState AmphibiousIn;

    public List<Sensor> JammingSensors;
    public List<Sensor> DetectorSesnors;

    public WeaponConfig SelectedWeaponConfig;

    public Weapon WeaponFiring;
    public GroundRadar CombatVehicleRadar;

    // Use this for initialization
    void Start()
    {
        Wheels = Frame.GetComponentsInChildren<rotation>().ToList();
        StartCoroutine("CheckMoving");

        DeployToFire = Vehicle.DeployToFire;
        HasCommanderTurret = Vehicle.HasCommanderTurret;
        FireOnMove = Vehicle.FireOnMove;
        CanTargetMoving = Vehicle.CanTargetMoving;
        CanTargetStationary = Vehicle.CanTargetStationary;
    }

    //scan for  the enemey
    //repeat
    //detect enemy
    //classify enemy
    //select the best weapon against enemy
    //lock on target / start animations
    //notify game-state firing
    //fire weapon
    //start reload and firing animations
    //reload and detect hit
    //scan for the enemy
    // Update is called once per frame
    void Update()
    {


    }


    public IEnumerator CheckMoving()
    {
        yield return new WaitForEndOfFrame();
    }

    public void StopMoving()
    {
        Wheels.ForEach(e => e.enabled = false);

    }

    public void StartMoving()
    {
        Wheels.ForEach(e => e.enabled = true);
    }

    public float GetMaxWeaponRange(DoV_Vehicle Vehicle)
    {
        return Vehicle.VehicleSensors.Max(e => e.MaxRange);
    }
    public float GetMinWeaponRange(DoV_Vehicle Vehicle)
    {
        return Vehicle.VehicleSensors.Min(e => e.MaxRange);
    }

    public float CalculateSensorDelay(DoV_Vehicle Vehicle)
    {
        var delay = 0;
        Vehicle.VehicleSensors.ForEach(sensor =>
        {
            if (sensor.IsJammingDevice || sensor.IsElectronicWarfare)
            {
                JammingSensors.Add(sensor);

            }
            else
            {
                DetectorSesnors.Add(sensor);
            }

        });
        return delay;
    }
    public void PickWeaponSystem(int SelectOption)
    {
        WeaponFiring = SelectedWeaponConfig.WeaponsStations[SelectOption].ConfigWeapons.FirstOrDefault();
    }
    public void PickWeaponConfigSystem(int SelectOption)
    {
        SelectedWeaponConfig = Vehicle.VehicleWeapons[SelectOption];

    }
    public void SetWeaponConfig(WeaponConfig SetWeapon, Weapon FiringWeapon)
    {
        //SetWeapon.WeaponsStations.Where(weapon => weapon.)
        //WeaponFiring =

    }

    public void LockOnTarget(Weapon Weapon)
    {

    }
}
