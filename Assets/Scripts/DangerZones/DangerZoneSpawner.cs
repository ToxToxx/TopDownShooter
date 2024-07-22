using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Спавнер для опасных зон, он создаёт объект фабричного метода и вычисляет позицию для спавна
/// </summary>
public class DangerZoneSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _slowZonePrefab; 
    [SerializeField] private GameObject _deathZonePrefab; 
    [SerializeField] private int _slowZoneCount = 3;
    [SerializeField] private int _deathZoneCount = 2;
    [SerializeField] private float _slowZoneRadius = 3f;
    [SerializeField] private float _deathZoneRadius = 1f;
    [SerializeField] private float _minDistanceBetweenZones = 3f;
    [SerializeField] private float _minDistanceFromEdge = 3f;
    [SerializeField] private float _Xdistance = 37f;
    [SerializeField] private float _Zdistance = 27f;

    private readonly List<Vector3> _spawnPositions = new();
    private DangerZoneFactory _dangerZoneFactory;

    void Start()
    {
        _dangerZoneFactory = new DangerZoneFactory(_slowZonePrefab, _deathZonePrefab);
        GenerateDangerZones();
    }

    void GenerateDangerZones()
    {
        for (int i = 0; i < _slowZoneCount; i++)
        {
            Vector3 position = GetValidSpawnPosition(_slowZoneRadius);
            _spawnPositions.Add(position);
            GameObject slowZone = _dangerZoneFactory.CreateDangerZone(DangerZoneType.Slow);
            Instantiate(slowZone, position, Quaternion.identity);
        }

        for (int i = 0; i < _deathZoneCount; i++)
        {
            Vector3 position = GetValidSpawnPosition(_deathZoneRadius);
            _spawnPositions.Add(position);
            GameObject deathZone = _dangerZoneFactory.CreateDangerZone(DangerZoneType.Death);
            Instantiate(deathZone, position, Quaternion.identity);
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
