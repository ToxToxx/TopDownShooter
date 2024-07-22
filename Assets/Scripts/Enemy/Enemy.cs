using UnityEngine;

/// <summary>
///  ласс реализующий врага, он двигаетс€ к игроку, у него есть здоровье и он хранит свои статы
/// </summary>
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData;
    private float _currentHP;
    private float _maxHP;

    private Transform _playerTransform;

    private void Awake()
    {
        _maxHP = _enemyData.Hp;
        _currentHP = _maxHP;
    }

    private void Update()
    {
        MoveTowardsPlayer();
    }

    public void Initialize(Transform playerTransform)
    {
        _playerTransform = playerTransform;
        _maxHP = _enemyData.Hp;
        _currentHP = _maxHP;
    }

    private void MoveTowardsPlayer()
    {
        if (_playerTransform != null)
        {
            Vector3 direction = (_playerTransform.position - transform.position).normalized;
            transform.position += _enemyData.Speed * Time.deltaTime * direction;
        }
    }

    public void TakeDamage(float damage)
    {
        _currentHP -= damage;
        if (_currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(_enemyData.EnemyName + " уничтожен!");
        ScoreManager.Instance.AddScore(_enemyData.Points);
        Destroy(gameObject);
    }
}
