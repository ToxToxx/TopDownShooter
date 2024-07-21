using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponState
{
    public WeaponType _currentWeaponType = WeaponType.None;

    public void EquipWeapon(WeaponType newWeaponType)
    {
        switch (newWeaponType)
        {
            case WeaponType.Pistol:
                EquipPistol();
                break;
            case WeaponType.Shotgun:
                EquipShotgun();
                break;
            case WeaponType.Rifle:
                EquipRifle();
                break;
            case WeaponType.GrenadeLauncher:
                EquipGrenadeLauncher();
                break;
        }
    }

    private void EquipPistol()
    {
        WeaponManager.Instance.PistolGameObject.SetActive(true);
        WeaponManager.Instance.ShotgunGameObject.SetActive(false);
        WeaponManager.Instance.RifleGameObject.SetActive(false);
        WeaponManager.Instance.GrenadeLauncher.SetActive(false);
        ShootController.Instance.SetWeapon(WeaponManager.Instance.PistolGameObject.GetComponent<PistolComponent>());
    }

    private void EquipShotgun()
    {
        WeaponManager.Instance.PistolGameObject.SetActive(false);
        WeaponManager.Instance.ShotgunGameObject.SetActive(true);
        WeaponManager.Instance.RifleGameObject.SetActive(false);
        WeaponManager.Instance.GrenadeLauncher.SetActive(false);
        ShootController.Instance.SetWeapon(WeaponManager.Instance.ShotgunGameObject.GetComponent<ShotgunComponent>());
    } 
    private void EquipRifle()
    {
        WeaponManager.Instance.PistolGameObject.SetActive(false);
        WeaponManager.Instance.ShotgunGameObject.SetActive(false);
        WeaponManager.Instance.RifleGameObject.SetActive(true);
        WeaponManager.Instance.GrenadeLauncher.SetActive(false);
        ShootController.Instance.SetWeapon(WeaponManager.Instance.RifleGameObject.GetComponent<PistolComponent>());
    }

    private void EquipGrenadeLauncher()
    {
        WeaponManager.Instance.PistolGameObject.SetActive(false);
        WeaponManager.Instance.ShotgunGameObject.SetActive(false);
        WeaponManager.Instance.RifleGameObject.SetActive(false);
        WeaponManager.Instance.GrenadeLauncher.SetActive(true);
        ShootController.Instance.SetWeapon(WeaponManager.Instance.GrenadeLauncher.GetComponent<GrenadeLauncherComponent>());
    }
}
