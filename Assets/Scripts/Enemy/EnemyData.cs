using UnityEngine;

/// <summary>
/// Класс статов врагов, хранит основную о них информацию
/// </summary>
[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    public string EnemyName;
    public int Hp;
    public float Speed;
    public int Points;
    public float SpawnChance;
}
