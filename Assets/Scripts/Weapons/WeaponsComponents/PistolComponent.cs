using UnityEngine;

/// <summary>
/// Класс, отвечающий за повведение компонента пистолета. Автомат также реализует этот класс
/// </summary>
public sealed class PistolComponent : Weapon
{
    [SerializeField] private GameObject _bulletPrefab;
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
            GameObject bullet = Instantiate(_bulletPrefab, WeaponManager.Instance.GetWeaponManagerTransform().position, WeaponManager.Instance.GetWeaponManagerTransform().rotation);
            Debug.Log($"{WeaponStats.WeaponName} выстрелил");
        }
        else
        {
            Debug.Log("Нет стрельбы");
        }

    }
}
