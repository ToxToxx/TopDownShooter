using UnityEngine;

/// <summary>
/// Класс фабрика реализующий создание врагов
/// </summary>
public class EnemyFactory
{
    private GameObject[] _enemyPrefabs;
    private float[] _spawnChances;

    public EnemyFactory(GameObject[] enemyPrefabs, float[] spawnChances)
    {
        _enemyPrefabs = enemyPrefabs;
        _spawnChances = spawnChances;
    }

    public GameObject CreateRandomEnemy()
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

        return _enemyPrefabs[0];
    }
}
