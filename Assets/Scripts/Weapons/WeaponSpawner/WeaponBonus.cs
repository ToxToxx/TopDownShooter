using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
