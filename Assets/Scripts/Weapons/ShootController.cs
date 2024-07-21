using UnityEngine;

public class ShootController : MonoBehaviour
{
    public static ShootController Instance;

    [SerializeField] private PlayerMovement _playerMovement;
    private Weapon _currentWeapon;

    private void Awake()
    {
        Instance = this;
    }
    public void SetWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }

    private void Update()
    {
        if (InputManager.ShootWasHeld || InputManager.ShootWasPressed)
        {
            if (_currentWeapon != null)
            {
                Debug.Log(_currentWeapon + " Стреляет");
                _currentWeapon.Shoot();
              
            } else
            {
                Debug.Log("No Current Weapon");
            }
        }
        RotatePlayerTowardsMouse();
    }

    private void RotatePlayerTowardsMouse()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        if (_playerMovement != null)
        {
            _playerMovement.RotateTowardsMouse(mousePosition);
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new(Vector3.up, Vector3.zero);
        if (plane.Raycast(ray, out float distance))
        {
            return ray.GetPoint(distance);
        }
        return Vector3.zero; // На случай, если не удалось определить позицию
    }

    public float GetWeaponDamage()
    {
        return _currentWeapon.WeaponStats.Damage;
    }
}
