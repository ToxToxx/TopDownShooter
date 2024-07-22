using UnityEngine;

/// <summary>
/// Класс реализующий стандартную пулю пистолета, дробовика, автомата
/// </summary>
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 20f;
    [SerializeField] private float _range = 25f;
    private Vector3 _startPosition;

    private void OnEnable()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        float distance = _speed * Time.deltaTime;
        transform.Translate(Vector3.forward * distance);

        if (Vector3.Distance(_startPosition, transform.position) >= _range)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(ShootController.Instance.GetWeaponDamage());
            Destroy(gameObject);
            Debug.Log($"{other.name} получил {ShootController.Instance.GetWeaponDamage()} урона");
        }
    }
}