using UnityEngine;

/// <summary>
/// Спавнер бонусов игрока
/// </summary>
public class PlayerBonusSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _playerBonusPrefabs;
    [SerializeField] private Transform _playerTransform;
    private readonly float _spawnRate = 27f;
    private float _nextSpawnTime = 0f;
    private PlayerBonusFactory _playerBonusFactory;

    void Start()
    {
        _nextSpawnTime = Time.time + _spawnRate;
        _playerBonusFactory = new PlayerBonusFactory(_playerBonusPrefabs);
    }

    void Update()
    {
        if (Time.time >= _nextSpawnTime)
        {
            SpawnPowerUp();
            _nextSpawnTime = Time.time + _spawnRate;
        }
    }

    void SpawnPowerUp()
    {
        Vector3 spawnPosition = GetSpawnPosition();
        GameObject selectedPowerUp = _playerBonusFactory.CreateRandomPlayerBonus();
        _ = Instantiate(selectedPowerUp, spawnPosition, Quaternion.identity);
    }

    Vector3 GetSpawnPosition()
    {
        _ = Vector3.zero;
        float cameraHeight = 2f * Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        float x = Random.Range(Camera.main.transform.position.x - cameraWidth / 2, Camera.main.transform.position.x + cameraWidth / 2);
        float z = Random.Range(Camera.main.transform.position.z - cameraHeight / 2, Camera.main.transform.position.z + cameraHeight / 2);

        Vector3 spawnPosition = new(x, 1, z);
        return spawnPosition;
    }
}
