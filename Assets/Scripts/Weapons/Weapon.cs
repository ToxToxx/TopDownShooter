using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public WeaponData WeaponStats;
    public virtual void Shoot() { }
}
