using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance;
    public WeaponState PlayerWeaponState;

    [Header("Pistol Data")]
    public GameObject PistolGameObject;

    [Header("Shotgun Data")]
    public GameObject ShotgunGameObject;

    [Header("Rifle Data")]
    public GameObject RifleGameObject;

    [Header("Grenade Launcher Data")]
    public GameObject GrenadeLauncher;

    private void Awake()
    {
        Instance = this;
        PlayerWeaponState = new WeaponState();
    }

    private void Start()
    {
        PlayerWeaponState.EquipWeapon(WeaponType.Pistol);
    }

    public void ChangeWeaponState(WeaponType weaponType)
    {
        PlayerWeaponState.EquipWeapon(weaponType);
    }

    public Transform GetWeaponManagerTransform()
    {
        return transform;
    }
}
