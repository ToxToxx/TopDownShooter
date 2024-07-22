using UnityEngine;

/// <summary>
/// ����������� ����� ������, ������� ����������� ������������
/// </summary>
public abstract class Weapon : MonoBehaviour
{
    public WeaponData WeaponStats;
    public virtual void Shoot() { }
}
