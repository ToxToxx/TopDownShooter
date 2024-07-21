using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public WeaponData WeaponData;
    public virtual void Shoot() { }
}
