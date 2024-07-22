using UnityEngine;

/// <summary>
/// Компонент, который отвечает за поведение гранатомёта
/// </summary>
public sealed class GrenadeLauncherComponent : Weapon
{
    [SerializeField] private GameObject _grenadePrefab;
    public float explosionRadius = 2f;
    private float lastShotTime;

    public override void Shoot()
    {
        if (Time.time - lastShotTime >= 1f / WeaponStats.FireRate)
        {
            lastShotTime = Time.time;
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
            GameObject grenade = Instantiate(_grenadePrefab, WeaponManager.Instance.GetWeaponManagerTransform().position, Quaternion.identity);
            Grenade grenadeScript = grenade.GetComponent<Grenade>();
            grenadeScript.Launch(targetPosition, explosionRadius, WeaponStats.Damage);
            Debug.Log($"{WeaponStats.WeaponName} выстрелил");
        }
    }
}
