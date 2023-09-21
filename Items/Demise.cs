using UnityEngine;

public class Demise : Item
{
    public override void Init()
    {
        id = 25;
        name = "Demise";
        description = "Half Health, Double Damage";
        icon = Resources.Load<Sprite>(name);
        rarity = Rarity.Evil;
    }

    public override void Activate()
    {
        base.Activate();
        PlayerStats.Instance.damage *= 2;

        PlayerStats.Instance.maxHealth /= 2;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>().maxHealth /= 2;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>().currentHealth /= 2;
    }
}
