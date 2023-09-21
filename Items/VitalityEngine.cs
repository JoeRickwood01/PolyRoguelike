using UnityEngine;

public class VitalityEngine : Item
{
    int[] ids;
    public override void Init()
    {
        id = 23;
        name = "Vitality Engine";
        description = "Adds Max Health Per Max Health Upgrade You Have \n Adds Max Health When A Health Upgrade Is Added";
        icon = Resources.Load<Sprite>(name);
        rarity = Rarity.Epic;
    }

    public override void Activate()
    {
        base.Activate();
        ids = new int[]
        {
            19, 21, 4, 11, 23
        };

        for (int i = 0; i < InventoryManager.Instance.playerInventory.Count; i++)
        {
            for (int j = 0; j < ids.Length; j++)
            {
                if (InventoryManager.Instance.playerInventory[i].id == ids[j])
                {
                    PlayerStats.Instance.maxHealth += 10;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>().maxHealth += 10;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>().currentHealth += 10;
                }
            }
        }
    }

    public override void OnItemAdded(int itemID)
    {
        base.OnItemAdded(itemID);
        for (int j = 0; j < ids.Length; j++)
        {
            if (itemID == ids[j])
            {
                PlayerStats.Instance.maxHealth += 10;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>().maxHealth += 10;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>().currentHealth += 10;
                return;
            }
        }
    }
}
