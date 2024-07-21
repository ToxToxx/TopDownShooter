using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance;
    private WeaponState _weaponState;

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
        _weaponState = new WeaponState();
    }

    private void Start()
    {
        _weaponState.EquipWeapon(WeaponType.Pistol);
    }

    public void ChangeWeaponState(WeaponType weaponType)
    {
        _weaponState.EquipWeapon(weaponType);
    }

    public Transform GetWeaponManagerTransform()
    {
        return transform;
    }
}
