using UnityEngine;

/// <summary>
/// Хранит статы оружия
/// </summary>
[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponData : ScriptableObject
{
    public string WeaponName;
    public int Damage;
    public float FireRate;
    public string Description;
}