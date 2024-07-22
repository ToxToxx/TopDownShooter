using UnityEngine;

/// <summary>
/// Абстрактный класс оружия, который наследуется компонентами
/// </summary>
public abstract class Weapon : MonoBehaviour
{
    public WeaponData WeaponStats;
    public virtual void Shoot() { }
}
