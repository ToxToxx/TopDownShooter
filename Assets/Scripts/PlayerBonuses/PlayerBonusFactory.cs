using UnityEngine;

/// <summary>
/// Класс фабрика для создания бонусов
/// </summary>
public class PlayerBonusFactory
{
    private GameObject[] _playerBonusPrefabs;

    public PlayerBonusFactory(GameObject[] playerBonusPrefabs)
    {
        _playerBonusPrefabs = playerBonusPrefabs;
    }

    public GameObject CreateRandomPlayerBonus()
    {
        int randomIndex = Random.Range(0, _playerBonusPrefabs.Length);
        return _playerBonusPrefabs[randomIndex];
    }
}
