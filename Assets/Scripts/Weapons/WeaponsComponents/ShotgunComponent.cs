using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunComponent : Weapon
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private int _pellets = 5;
    [SerializeField] private float _spreadAngle = 10f;
    private float _timeSinceLastShot;
    private float _shotInterval;

    private void Start()
    {
        _shotInterval = 1f / WeaponStats.FireRate;
    }

    private void Update()
    {
        _timeSinceLastShot += Time.deltaTime;
    }

    public override void Shoot()
    {
        if (_timeSinceLastShot >= _shotInterval)
        {
            _timeSinceLastShot = 0f;
            for (int i = 0; i < _pellets; i++)
            {
                float angle = _spreadAngle * (i - (_pellets - 1) / 2f);
                Quaternion rotation = Quaternion.Euler(new Vector3(0, angle, 0)) * WeaponManager.Instance.GetWeaponManagerTransform().rotation;
                Instantiate(_bulletPrefab, WeaponManager.Instance.GetWeaponManagerTransform().position, rotation);
            }

            Debug.Log($"{WeaponStats.WeaponName} выстрелил");
        }
        else
        {
            Debug.Log("Нет стрельбы");
        }

    }
}
