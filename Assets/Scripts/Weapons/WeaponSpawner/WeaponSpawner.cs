using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _weaponBonusPrefabs;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _spawnRate = 10f;

    private float _nextSpawnTime = 0f;
    private WeaponBonusFactory _weaponBonusFactory;

    void Start()
    {
        _nextSpawnTime = Time.time + _spawnRate;
        _weaponBonusFactory = new WeaponBonusFactory(_weaponBonusPrefabs);
    }

    void Update()
    {
        if (Time.time >= _nextSpawnTime)
        {
            SpawnBonus();
            _nextSpawnTime = Time.time + _spawnRate;
        }
    }

    void SpawnBonus()
    {
        Vector3 spawnPosition = GetSpawnPosition();
        WeaponType currentWeaponType = WeaponManager.Instance.PlayerWeaponState._currentWeaponType;
        GameObject selectedBonus = _weaponBonusFactory.CreateRandomWeaponBonus(currentWeaponType);

        if (selectedBonus != null)
        {
            GameObject bonusGO = Instantiate(selectedBonus, spawnPosition, Quaternion.identity);
            Destroy(bonusGO, 5f);
        }
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
