using System.Collections.Generic;
using UnityEngine;

public class DangerZoneSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _slowZonePrefab; // Префаб зоны замедления
    [SerializeField] private GameObject _deathZonePrefab; // Префаб зоны смерти
    [SerializeField] private int _slowZoneCount = 3;
    [SerializeField] private int _deathZoneCount = 2;
    [SerializeField] private float _slowZoneRadius = 3f;
    [SerializeField] private float _deathZoneRadius = 1f;
    [SerializeField] private float _minDistanceBetweenZones = 3f;
    [SerializeField] private float _minDistanceFromEdge = 3f;
    [SerializeField] private float _Xdistance = 37f;
    [SerializeField] private float _Zdistance = 27f;

    private readonly List<Vector3> _spawnPositions = new();

    void Start()
    {
        GenerateDangerZones();
    }

    void GenerateDangerZones()
    {
        // Генерация зон замедления
        for (int i = 0; i < _slowZoneCount; i++)
        {
            Vector3 position = GetValidSpawnPosition(_slowZoneRadius);
            _spawnPositions.Add(position);
            Instantiate(_slowZonePrefab, position, Quaternion.identity);
        }

        // Генерация зон смерти
        for (int i = 0; i < _deathZoneCount; i++)
        {
            Vector3 position = GetValidSpawnPosition(_deathZoneRadius);
            _spawnPositions.Add(position);
            Instantiate(_deathZonePrefab, position, Quaternion.identity);
        }
    }

    Vector3 GetValidSpawnPosition(float radius)
    {
        Vector3 position;
        bool validPosition = false;

        do
        {
            position = GetRandomPosition();

            if (IsValidPosition(position, radius))
            {
                validPosition = true;
            }

        } while (!validPosition);

        return position;
    }

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(-_Xdistance + _minDistanceFromEdge, _Xdistance - _minDistanceFromEdge);
        float z = Random.Range(-_Zdistance + _minDistanceFromEdge, _Zdistance - _minDistanceFromEdge);

        return new Vector3(x, 0, z);
    }

    bool IsValidPosition(Vector3 position, float radius)
    {
        foreach (Vector3 existingPosition in _spawnPositions)
        {
            float distance = Vector3.Distance(existingPosition, position);
            if (distance < (radius + _minDistanceBetweenZones))
            {
                return false;
            }
        }
        return true;
    }
}
