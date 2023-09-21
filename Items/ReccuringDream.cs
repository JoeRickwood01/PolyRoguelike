using System;
using UnityEngine;

public class ReccuringDream : Item
{
    public override void Init()
    {
        id = 2;
        name = "Reccuring Dream";
        description = "Grants Random Permanent Stat Ups After Each Item Chosen";
        icon = Resources.Load<Sprite>(name);
        rarity = Rarity.Rare;
    }

    public override void Activate()
    {
        InventoryManager.Instance.addItemEvent += OnItemAdded;
    }

    public override void OnItemAdded(int itemID)
    {
        System.Random rand = new System.Random();
        int randNumber = rand.Next(0, 9);
        switch(randNumber) {
            case 0:
                PlayerStats.Instance.maxHealth += 3;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>().maxHealth += 1;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>().currentHealth += 1;
                break;
            case 1:
                PlayerStats.Instance.damage += 1;
                break;
            case 2:
                PlayerStats.Instance.firerate += 0.2f;
                break;
            case 3:
                PlayerStats.Instance.speed += 0.1f;
                break;
            case 4:
                PlayerStats.Instance.bulletSpeed += 0.4f;
                break;
            case 5:
                PlayerStats.Instance.bulletRange += 1;
                break;
            case 6:
                PlayerStats.Instance.sight += 0.2f;
                break;
            case 7:
                PlayerStats.Instance.luck += 0.2f;
                break;
            case 8:
                PlayerStats.Instance.accuracy += 0.3f;
                break;
            case 9:
                PlayerStats.Instance.bulletSize += 0.02f;
                break;
        }
    }
}
