using UnityEngine;

public class HeavyRounds : Item
{
    public override void Init()
    {
        id = 7;
        name = "Heavy Rounds";
        description = "Damage Up, Small Bullet Size Up";
        icon = Resources.Load<Sprite>(name);
        rarity = Rarity.Uncommon;
    }

    public override void Activate()
    {
        base.Activate();
        PlayerStats.Instance.damage += 2f;
        PlayerStats.Instance.bulletSize += 0.02f;
    }
}
