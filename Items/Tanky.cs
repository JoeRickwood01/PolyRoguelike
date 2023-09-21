using UnityEngine;

public class Tanky : Item
{
    public override void Init()
    {
        id = 11;
        name = "Tanky";
        description = "Damage Up, Max Health Up, Speed Down";
        icon = Resources.Load<Sprite>(name);
        rarity = Rarity.Uncommon;
    }

    public override void Activate()
    {
        base.Activate();
        PlayerStats.Instance.speed *= 0.75f;
        PlayerStats.Instance.damage *= 1.2f;
        PlayerStats.Instance.maxHealth += 15;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>().maxHealth += 15;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>().currentHealth += 15;
    }
}
