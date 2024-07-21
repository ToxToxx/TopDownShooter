using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    public string EnemyName;
    public int Hp;
    public float Speed;
    public int Points;
    public float SpawnChance;
}