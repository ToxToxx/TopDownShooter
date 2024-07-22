using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBonusFactory
{
    private GameObject[] _weaponBonusPrefabs;

    public WeaponBonusFactory(GameObject[] weaponBonusPrefabs)
    {
        _weaponBonusPrefabs = weaponBonusPrefabs;
    }

    public GameObject CreateRandomWeaponBonus(WeaponType currentWeaponType)
    {
        List<GameObject> availableBonuses = new();

        foreach (GameObject bonus in _weaponBonusPrefabs)
        {
            WeaponType bonusWeaponType = bonus.GetComponent<WeaponBonus>().GetWeaponType();

            if (bonusWeaponType != currentWeaponType)
            {
                availableBonuses.Add(bonus);
            }
        }

        if (availableBonuses.Count > 0)
        {
            int randomIndex = Random.Range(0, availableBonuses.Count);
            return availableBonuses[randomIndex];
        }

        return null;
    }
}
