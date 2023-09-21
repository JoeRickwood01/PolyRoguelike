using UnityEngine;

public class StrongHeart : Item
{
    public override void Init()
    {
        id = 4;
        name = "Strong Heart";
        description = "Increased Max HP";
        icon = Resources.Load<Sprite>(name);
        rarity = Rarity.Common;
    }

    public override void Activate()
    {
        base.Activate();
        PlayerStats.Instance.maxHealth += 15;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>().maxHealth += 15;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>().currentHealth += 15;
    }
}
