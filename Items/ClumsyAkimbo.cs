using System;
using UnityEngine;

public class ClumsyAkimbo : Item
{
    int gunPrefabId;
    public override void Init()
    {
        id = 3;
        name = "Clumsy Akimbo";
        description = "Grants A Gun Pointing In A Random Direction, Decreased Fire Rate";
        icon = Resources.Load<Sprite>(name);
        rarity = Rarity.Uncommon;

        gunPrefabId = 0;
    }

    public override void Activate()
    {
        Transform gunTransform = GameObject.FindGameObjectWithTag("WeaponRotationPoint").transform;

        System.Random random = new System.Random();
        GameObject.Instantiate(GameManager.Instance.GetSpawnablePrefabWithID(gunPrefabId), gunTransform.position, Quaternion.Euler(0f, 0f, random.Next(0, 360)),  gunTransform);

        PlayerStats.Instance.firerate *= 0.5f;
    }
}
