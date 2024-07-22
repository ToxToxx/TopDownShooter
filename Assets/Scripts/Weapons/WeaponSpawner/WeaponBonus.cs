using UnityEngine;

/// <summary>
/// ����� ����������� ��������� ������� ������ - ������ �� ��� � ������ ������ � ������ ��� �������
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
