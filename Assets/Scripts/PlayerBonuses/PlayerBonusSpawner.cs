using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBonusSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _playerBonusPrefabs;
    [SerializeField] private Transform _playerTransform;
    private float _spawnRate = 27f;
    private float _nextSpawnTime = 0f;

    void Start()
    {
        _nextSpawnTime = Time.time + _spawnRate;
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
        GameObject selectedPowerUp = GetRandomPowerUp();
        _ = Instantiate(selectedPowerUp, spawnPosition, Quaternion.identity);
    }

    Vector3 GetSpawnPosition()
    {
        Vector3 spawnPosition = Vector3.zero;
        float cameraHeight = 2f * Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        float x = Random.Range(Camera.main.transform.position.x - cameraWidth / 2, Camera.main.transform.position.x + cameraWidth / 2);
        float z = Random.Range(Camera.main.transform.position.z - cameraHeight / 2, Camera.main.transform.position.z + cameraHeight / 2);

        spawnPosition = new Vector3(x, 1, z);
        return spawnPosition;
    }

    GameObject GetRandomPowerUp()
    {
        int randomIndex = Random.Range(0, _playerBonusPrefabs.Length);
        return _playerBonusPrefabs[randomIndex];
    }

}
