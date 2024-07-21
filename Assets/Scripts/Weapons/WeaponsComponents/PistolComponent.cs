using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolComponent : Weapon
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    private float _lastShotTime;
    private float _bulletSpeed;

    public override void Shoot()
    {
        if (Time.time - _lastShotTime >= 1f / WeaponData.FireRate)
        {
            _lastShotTime = Time.time;
            GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = _firePoint.forward * _bulletSpeed; // Примерная скорость пули
            Debug.Log($"{WeaponData.WeaponName} выстрелил");
        }
    }
}