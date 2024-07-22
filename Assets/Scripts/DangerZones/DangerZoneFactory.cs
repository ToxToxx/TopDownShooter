using System.Collections.Generic;
using UnityEngine;

public class DangerZoneFactory
{
    private GameObject _slowZonePrefab;
    private GameObject _deathZonePrefab;

    public DangerZoneFactory(GameObject slowZonePrefab, GameObject deathZonePrefab)
    {
        _slowZonePrefab = slowZonePrefab;
        _deathZonePrefab = deathZonePrefab;
    }

    public GameObject CreateDangerZone(DangerZoneType zoneType)
    {
        switch (zoneType)
        {
            case DangerZoneType.Slow:
                return _slowZonePrefab;
            case DangerZoneType.Death:
                return _deathZonePrefab;
            default:
                return null;
        }
    }
}

public enum DangerZoneType
{
    Slow,
    Death
}
