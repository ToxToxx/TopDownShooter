using UnityEngine;

/// <summary>
/// Класс реализующий движение игрока и поворот
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    [SerializeField] private float _moveSpeed = 4.0f;
    [SerializeField] private float _turnSpeed = 180.0f;

    [Header("Movement Boundaries")]
    [SerializeField] private float _minX = -40f;
    [SerializeField] private float _maxX = 40f;
    [SerializeField] private float _minZ = -30f;
    [SerializeField] private float _maxZ = 30f;

    private Rigidbody _playerRb;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        _playerRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 movementInput = InputManager.Movement;

        Vector3 movement = new Vector3(movementInput.x, 0, movementInput.y).normalized * _moveSpeed;

        Vector3 newPosition = transform.position + movement * Time.fixedDeltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, _minX, _maxX);
        newPosition.z = Mathf.Clamp(newPosition.z, _minZ, _maxZ);

        _playerRb.MovePosition(newPosition);
    }

    public void RotateTowardsMouse(Vector3 mousePosition)
    {
        Vector3 direction = (mousePosition - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _turnSpeed * Time.deltaTime);
    }

    public void MultiplySpeed(float speedMultiplier)
    {
        _moveSpeed *= speedMultiplier;
    }

    public float GetMoveSpeed() { return _moveSpeed; }
}
