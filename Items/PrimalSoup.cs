using UnityEngine;

public class PrimalSoup : Item
{
    public override void Init()
    {
        id = 21;
        name = "Primal Soup";
        description = "Damage Up, Speed Up, Sight Up, Bullet Size Up, Health Up";
        icon = Resources.Load<Sprite>(name);
        rarity = Rarity.Epic;
    }

    public override void Activate()
    {
        base.Activate();
        PlayerStats.Instance.damage += 5;
        PlayerStats.Instance.speed += 2;
        PlayerStats.Instance.sight += 1;
        PlayerStats.Instance.bulletSize += 0.05f;

        PlayerStats.Instance.maxHealth += 25;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>().maxHealth += 25;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Entity>().currentHealth += 25;
    }
}
