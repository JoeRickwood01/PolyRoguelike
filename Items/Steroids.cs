using UnityEngine;

public class Steroids : Item
{
    public override void Init()
    {
        id = 18;
        name = "Steroids";
        description = "Speed Up, Damage Up, Max Health Down";
        icon = Resources.Load<Sprite>(name);
        rarity = Rarity.Common;
    }

    public override void Activate()
    {
        base.Activate();
        PlayerStats.Instance.speed += 0.5f;
        PlayerStats.Instance.damage += 1.5f;

        PlayerStats.Instance.maxHealth -= 15;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>().maxHealth -= 15;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>().currentHealth -= 15;
    }
}
