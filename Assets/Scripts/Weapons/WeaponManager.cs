using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance;

    [Header("Pistol Data")]
    [SerializeField] private PistolComponent _pistol;
    [SerializeField] private GameObject _pistolGameObject;

    [Header("Shotgun Data")]
    [SerializeField] private ShotgunComponent _shotgun;
    [SerializeField] private GameObject _shotgunGameObject;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        ChangeWeapon(_pistol);
    }

    public void ChangeWeapon(Weapon weapon)
    {
        ShootController.Instance.SetWeapon(weapon);
    }

}
