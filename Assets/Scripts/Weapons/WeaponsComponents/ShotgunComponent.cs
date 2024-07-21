using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunComponent : Weapon
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private int _pellets = 5;
    [SerializeField] private float _spreadAngle = 10f;
    private float lastShotTime;

    public override void Shoot()
    {
        if (Time.time - lastShotTime >= 1f / WeaponData.FireRate)
        {
            lastShotTime = Time.time;
            for (int i = 0; i < _pellets; i++)
            {
                float angle = _spreadAngle * (i - (_pellets - 1) / 2f);
                Quaternion rotation = Quaternion.Euler(new Vector3(0, angle, 0)) * _firePoint.rotation;
                _ = Instantiate(_bulletPrefab, _firePoint.position, rotation);
            }
            Debug.Log($"{WeaponData.WeaponName} выстрелил");
        }
    }
}
