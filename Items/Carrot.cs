using UnityEngine;

public class Carrot : Item
{
    public override void Init()
    {
        id = 19;
        name = "Carrot";
        description = "Max Health + Sight Up";
        icon = Resources.Load<Sprite>(name);
        rarity = Rarity.Common;
    }

    public override void Activate()
    {
        base.Activate();
        PlayerStats.Instance.maxHealth += 15;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>().maxHealth += 15;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>().currentHealth += 15;

        PlayerStats.Instance.sight += 1f;
    }
}
