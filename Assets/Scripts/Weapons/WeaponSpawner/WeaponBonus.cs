using UnityEngine;

/// <summary>
/// Класс реализующий поведение бонусов оружия - хранит их тип и меняет оружие у игрока при подборе
/// </summary>
public class WeaponBonus : MonoBehaviour
{
    [SerializeField] private WeaponType _weaponType;

    public WeaponType GetWeaponType()
    {
        return _weaponType;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            WeaponManager.Instance.ChangeWeaponState(_weaponType);
        }
    }
}
