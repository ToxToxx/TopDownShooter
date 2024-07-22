using UnityEngine;

/// <summary>
/// Спавнер врагов, он реализует логику спавна, подсчёта позиции для спавна
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private float[] _spawnChances;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _spawnRate = 2f;
    [SerializeField] private float _minSpawnRate = 0.5f;
    [SerializeField] private float _spawnRateReduction = 0.1f;
    [SerializeField] private float _spawnRateReductionInterval = 10f;

    private float _nextSpawnTime = 0f;
    private float _nextRateReductionTime = 0f;
    private EnemyFactory _enemyFactory;

    void Start()
    {
        _nextSpawnTime = Time.time + _spawnRate;
        _nextRateReductionTime = Time.time + _spawnRateReductionInterval;
        _enemyFactory = new EnemyFactory(_enemyPrefabs, _spawnChances);
    }

    void Update()
    {
        if (Time.time >= _nextSpawnTime)
        {
            SpawnEnemy();
            _nextSpawnTime = Time.time + _spawnRate;
        }

        if (Time.time >= _nextRateReductionTime && _spawnRate > _minSpawnRate)
        {
            _spawnRate = Mathf.Max(_spawnRate - _spawnRateReduction, _minSpawnRate);
            _nextRateReductionTime = Time.time + _spawnRateReductionInterval;
        }
    }

    void SpawnEnemy()
    {
        GameObject enemyGO = Instantiate(_enemyFactory.CreateRandomEnemy(), GetSpawnPosition(), Quaternion.identity);
        Enemy enemy = enemyGO.GetComponent<Enemy>();
        enemy.Initialize(_playerTransform);
    }

    Vector3 GetSpawnPosition()
    {
        // Spawn outside the camera view
        float x = 0f, z = 0f;
        float cameraHeight = 2f * Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;
        int side = Random.Range(0, 4);

        switch (side)
        {
            case 0: // Left
                x = Camera.main.transform.position.x - cameraWidth / 2 - 1;
                z = Random.Range(Camera.main.transform.position.z - cameraHeight / 2, Camera.main.transform.position.z + cameraHeight / 2);
                break;
            case 1: // Right
                x = Camera.main.transform.position.x + cameraWidth / 2 + 1;
                z = Random.Range(Camera.main.transform.position.z - cameraHeight / 2, Camera.main.transform.position.z + cameraHeight / 2);
                break;
            case 2: // Top
                x = Random.Range(Camera.main.transform.position.x - cameraWidth / 2, Camera.main.transform.position.x + cameraWidth / 2);
                z = Camera.main.transform.position.z + cameraHeight / 2 + 1;
                break;
            case 3: // Bottom
                x = Random.Range(Camera.main.transform.position.x - cameraWidth / 2, Camera.main.transform.position.x + cameraWidth / 2);
                z = Camera.main.transform.position.z - cameraHeight / 2 - 1;
                break;
        }

        return new Vector3(x, 1.5f, z);
    }
}
