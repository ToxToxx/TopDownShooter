using UnityEngine;

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

    void Start()
    {
        _nextSpawnTime = Time.time + _spawnRate;
        _nextRateReductionTime = Time.time + _spawnRateReductionInterval;
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
        GameObject enemyGO = Instantiate(GetRandomEnemyPrefab(), GetSpawnPosition(), Quaternion.identity);
        Enemy enemy = enemyGO.GetComponent<Enemy>();
        enemy.Initialize(_playerTransform);
    }

    Vector3 GetSpawnPosition()
    {
        // Спавн за пределами видимости камеры
        _ = Vector3.zero;
        float x = 0f, z = 0f;
        float cameraLength = 2f * Camera.main.orthographicSize;
        float cameraWidth = cameraLength * Camera.main.aspect;
        int side = Random.Range(0, 4);

        switch (side)
        {
            case 0: // Left
                x = Camera.main.transform.position.x - cameraWidth / 2 - 1;
                z = Random.Range(Camera.main.transform.position.z - cameraLength / 2, Camera.main.transform.position.z + cameraLength / 2);
                break;
            case 1: // Right
                x = Camera.main.transform.position.x + cameraWidth / 2 + 1;
                z = Random.Range(Camera.main.transform.position.z - cameraLength / 2, Camera.main.transform.position.z + cameraLength / 2);
                break;
            case 2: // Top
                x = Random.Range(Camera.main.transform.position.x - cameraWidth / 2, Camera.main.transform.position.x + cameraWidth / 2);
                z = Camera.main.transform.position.z + cameraLength / 2 + 1;
                break;
            case 3: // Bottom
                x = Random.Range(Camera.main.transform.position.x - cameraWidth / 2, Camera.main.transform.position.x + cameraWidth / 2);
                z = Camera.main.transform.position.z - cameraLength / 2 - 1;
                break;
        }

        Vector3 spawnPosition = new Vector3(x, 1.5f, z);
        return spawnPosition;
    }

    GameObject GetRandomEnemyPrefab()
    {
        float rand = Random.Range(0f, 100f);
        float cumulativeChance = 0f;

        for (int i = 0; i < _enemyPrefabs.Length; i++)
        {
            cumulativeChance += _spawnChances[i];
            if (rand < cumulativeChance)
            {
                return _enemyPrefabs[i];
            }
        }

        return _enemyPrefabs[0]; // Возвращаем первый префаб по умолчанию
    }
}
