using UnityEngine;

public class SniperRounds : Item
{
    public override void Init()
    {
        id = 6;
        name = "Sniper Rounds";
        description = "Doubled Damage, Halfed Firerate, Tripled Accuracy, Bullet Speed Up";
        icon = Resources.Load<Sprite>(name);
        rarity = Rarity.Rare;
    }

    public override void Activate()
    {
        base.Activate();
        PlayerStats.Instance.damage *= 2f;
        PlayerStats.Instance.firerate *= 0.5f;
        PlayerStats.Instance.accuracy *= 3f;
        PlayerStats.Instance.bulletSpeed += 2f;
    }
}
