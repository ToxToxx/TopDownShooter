using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _weaponBonusPrefabs; 
    [SerializeField] private Transform _playerTransform;
    private WeaponType _playerWeaponState; 

    [SerializeField] private float _spawnRate = 10f;

    private float _nextSpawnTime = 0f;

    void Start()
    {
        _nextSpawnTime = Time.time + _spawnRate;
        _playerWeaponState = WeaponManager.Instance.PlayerWeaponState._currentWeaponType;
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
        GameObject selectedBonus = GetRandomWeaponBonus();

        GameObject bonusGO = Instantiate(selectedBonus, spawnPosition, Quaternion.identity);
        Destroy(bonusGO, 5f); 
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

    GameObject GetRandomWeaponBonus()
    {
        List<GameObject> availableBonuses = new();
        _playerWeaponState = WeaponManager.Instance.PlayerWeaponState._currentWeaponType;

        foreach (GameObject bonus in _weaponBonusPrefabs)
        {
            WeaponType bonusWeaponType = bonus.GetComponent<WeaponBonus>().GetWeaponType();

            if (bonusWeaponType != _playerWeaponState)
            {
                availableBonuses.Add(bonus);
            }
        }

        if (availableBonuses.Count > 0)
        {
            int randomIndex = Random.Range(0, availableBonuses.Count);
            return availableBonuses[randomIndex];
        }
        else
        {
            return null;
        }
    }
}
